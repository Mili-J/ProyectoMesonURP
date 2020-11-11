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
        DTO_Formato dto_formato;
        DTO_IngredienteXReceta dto_ingredientexreceta;
        public DAO_IngredienteXReceta()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_ingredientexreceta = new DTO_IngredienteXReceta();
            dto_formato = new DTO_Formato();
        }
        public DataTable DAO_Consultar_Insumo_x_Receta(DTO_Receta objReceta)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_INGREDIENTE_X_RECETA", conexion);
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
                dto_ingredientexreceta.IR_cantidad = Convert.ToInt32(reader[1]);
                dto_ingredientexreceta.IR_formatoMedida = reader[2].ToString();
                dto_ingredientexreceta.R_idReceta = idReceta;
                dto_ingredientexreceta.I_idIngrediente = idIngrediente;
            }
            conexion.Close();
            return dto_ingredientexreceta;
        }
        public DataSet DAO_Consultar_IxR(DTO_Receta objReceta)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_INGREDIENTE_X_RECETA", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@R_idReceta", objReceta.R_idReceta));
            comando.ExecuteNonQuery();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public bool DAO_Get_ID_FormatoC(DTO_IngredienteXReceta objIReceta)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_FORMATOC_X_INGREDIENTE", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@I_idIngrediente", objIReceta.IR_idIngredienteReceta));
            comando.Parameters.Add(new SqlParameter("@R_idReceta", objIReceta.R_idReceta));
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                dto_formato.FCO_idFormatoCocina = (int)reader[0];
            }
            conexion.Close();
            return hayRegistros;
        }
        public void InsertIngredienteXReceta(DTO_IngredienteXReceta objDTO)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("SP_INSERT_INGREDIENTEXRECETA", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@IR_cantidad", objDTO.IR_cantidad));
            unComando.Parameters.Add(new SqlParameter("@IR_formatoMedida", objDTO.IR_formatoMedida));
            unComando.Parameters.Add(new SqlParameter("@R_idReceta", objDTO.R_idReceta));
            unComando.Parameters.Add(new SqlParameter("@I_idIngrediente", objDTO.I_idIngrediente));

            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable SelectIngredientesXReceta(int R_idReceta)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_INGREDIENTE_X_RECETA", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@R_idReceta", R_idReceta);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public void DeleteIngredientexReceta(int R_idReceta, int I_idIngrediente)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_DELETE_INGREDIENTE_X_RECETA", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@R_idReceta", R_idReceta));
                cmd.Parameters.Add(new SqlParameter("@I_idIngrediente", I_idIngrediente));
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
