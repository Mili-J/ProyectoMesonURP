using DTO;
using System;
using System.Data;
using System.Data.SqlClient;


namespace DAO
{
    public class DAO_CategoriaReceta
    {
        SqlConnection conexion;
        public DAO_CategoriaReceta()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }

        public DataSet SelectCategoriaReceta()
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_SELECT_CATEGORIA_RECETA", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet;
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public int SelectCategoriaRecetaxNombre(string CR_nombreCategoria)
        { 
            int idCategoria = 0;
            SqlCommand unComando = new SqlCommand("SP_SELECT_CATEGORIA_RECETA_X_NOMBRE", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.AddWithValue("@CR_nombreCategoria", CR_nombreCategoria);
            conexion.Open();
            SqlDataReader dReader = unComando.ExecuteReader();
            if (dReader.Read())
            {
                idCategoria = Convert.ToInt32(dReader["CR_idCategoriaReceta"]);
            }
            conexion.Close();
            return idCategoria;

        }
    }
}
