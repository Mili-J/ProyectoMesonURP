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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
