using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_IngredienteXReceta
    {
        SqlConnection conexion;
        DTO_IngredienteXReceta dto_ingredientexreceta;
        public DAO_IngredienteXReceta()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_ingredientexreceta = new DTO_IngredienteXReceta();
        }
        public DataTable DAO_Consultar_Insumo_x_Receta(DTO_Receta objReceta)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarIngredientesXReceta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@R_idReceta", objReceta.R_idReceta));
           
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public DTO_IngredienteXReceta DAO_Consultar_IngredienteXReceta(int idReceta,int idIngrediente)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarIngredienteXReceta", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@R_idReceta", idReceta);
            comando.Parameters.AddWithValue("@I_idIngrediente", idIngrediente);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if(reader.Read())
            {
                dto_ingredientexreceta.IR_idIngredienteReceta = Convert.ToInt32(reader[0]);
                dto_ingredientexreceta.IR_Cantidad = Convert.ToInt32(reader[1]);
                dto_ingredientexreceta.IR_formatoMedida = reader[2].ToString();
                dto_ingredientexreceta.R_idReceta = idReceta;
                dto_ingredientexreceta.I_idIngrediente = idIngrediente;
            }
            conexion.Close();
            return dto_ingredientexreceta;
        }
    }
}
