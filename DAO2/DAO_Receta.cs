using System;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_Receta
    {
        SqlConnection conexion;
        DAO_IngredienteXReceta dao_ingredientexreceta;
        DTO_Receta dto_receta;
        DAO_Ingrediente dao_ingrediente;
        public DAO_Receta()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dao_ingredientexreceta = new DAO_IngredienteXReceta();
            dto_receta = new DTO_Receta();
            dao_ingrediente = new DAO_Ingrediente();
        }

        public void InsertReceta(DTO_Receta objDTO)
        {
            try
            {
                conexion.Open();
                SqlCommand unComando = new SqlCommand("SP_INSERT_RECETA", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add(new SqlParameter("@R_nombreReceta", objDTO.R_nombreReceta));
                unComando.Parameters.Add(new SqlParameter("@R_numeroPorcion", objDTO.R_numeroPorcion));
                unComando.Parameters.Add(new SqlParameter("@R_imagenReceta", objDTO.R_imagenReceta));
                unComando.Parameters.Add(new SqlParameter("@CR_idCategoriaReceta", objDTO.CR_idCategoriaReceta));
                unComando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DAO_Consultar_Receta()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarRecetas", conexion);
            comando.CommandType = CommandType.StoredProcedure;           
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public DataTable DAO_Consultar_Receta_X_Categoria(int categoria)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarRecetasXCategoria", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CR_idCategoriaReceta", categoria);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        
        public DataTable DAO_Consultar_Recetas_Disponibles(int racion)
        {
            //TODO
            //><
            int i = 0;
            DataTable dtRecetas = DAO_Consultar_Receta(),dtIngredientesxReceta;
            DTO_IngredienteXReceta aux;
            DTO_Ingrediente dto_ingrediente;
            while (i<dtRecetas.Rows.Count)
            {
                dto_receta.R_idReceta = i + 1;
                dtIngredientesxReceta = dao_ingredientexreceta.DAO_Consultar_Insumo_x_Receta(dto_receta);
                int j = 0;
                while (j <dtIngredientesxReceta.Rows.Count)
                {
                    dto_ingrediente = dao_ingrediente.DAO_Consultar_IngredienteXID(j);
                    j++;
                }
                i++;
            }

            return new DataTable();
        }
    }
}
