using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class DAO_Ingrediente
    {
        SqlConnection conexion;
        public DAO_Ingrediente()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }

        public DataSet SelectIngrediente()
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_SELECT_INGREDIENTE", conexion);
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
