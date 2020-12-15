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

        public DataTable ListarOC(string numOC)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Listar_OC_GO", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@OC_numeroOC", numOC);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public DataTable BuscarOC(int idOC)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Buscar_OC_GO", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@OC_idOC", idOC);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarOC_2(int idOC)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Listar_OC_2_GO", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@OC_idOC", idOC);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UPDATE_EstadoOC(int idOC)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("SP_UPDATE_OC_GO", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@OC_idOC", idOC));
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
