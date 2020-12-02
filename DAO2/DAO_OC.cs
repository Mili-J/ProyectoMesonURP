using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAO
{
    public class DAO_OC
    {
        SqlConnection conexion;
        DTO_Medida dto_medida;

        public DAO_OC()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }

        public DataTable ListarOC()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_Listar_OC_GO", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public DataTable BuscarOC(string numeroOC)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Buscar_OC_GO", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@OC_numeroOC", numeroOC);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
