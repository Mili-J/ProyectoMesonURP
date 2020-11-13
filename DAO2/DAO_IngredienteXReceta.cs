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
        DTO_Equivalencia dto_eq;
        public DAO_IngredienteXReceta()
        {
            dto_ingredientexreceta = new DTO_IngredienteXReceta();
            dto_formato = new DTO_Formato();
            dto_eq = new DTO_Equivalencia();
            conexion = new SqlConnection(ConexionDB.CadenaConexion);           
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
        public DataTable DAO_Consultar_Insumo_x_Receta_T(DTO_Receta objReceta)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_INGREDIENTE_X_RECETA_T", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@R_idReceta", objReceta.R_idReceta));

            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public DTO_IngredienteXReceta DAO_Consultar_IngredienteXReceta(int idReceta, int idIngrediente)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarIngredienteXReceta", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@R_idReceta", idReceta);
            comando.Parameters.AddWithValue("@I_idIngrediente", idIngrediente);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
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
            SqlCommand comando = new SqlCommand("SP_SELECT_INGREDIENTE_X_RECETA_T", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@R_idReceta", objReceta.R_idReceta));
            comando.ExecuteNonQuery();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }

        public DataTable DAO_Consultar_Equivalencia_X_Ingrediente(int i, int ing)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_EQUIVALENCIA_X_INGREDIENTE", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@I_idIngrediente", ing);
            comando.Parameters.AddWithValue("@I_idInsumo", i);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
            
            
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
        public bool SelectExistenciaIngredientexReceta(int R_idReceta,int I_idIngrediente)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_SELECT_EXISTENCIA_INGREDIENTE_X_RECETA", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@R_idReceta", R_idReceta);
                cmd.Parameters.AddWithValue("@I_idIngrediente", I_idIngrediente);
                cmd.ExecuteNonQuery();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    conexion.Close();
                    return false;
                }
                else
                {
                    conexion.Close();
                    return true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
    }
}
