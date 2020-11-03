using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAO
{
    public class DAO_Insumo
    {
        SqlConnection conexion;

        public DAO_Insumo()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }

        public DataTable ListarInsumo()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_Listar_Insumo_MS", conexion);
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
        public DataTable ListarInsumo2()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_Listar_Insumo_2_MS", conexion);
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
        public DataTable BuscarInsumo(string nombreInsumo)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Buscar_Insumo_MS", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@I_nombreInsumo", nombreInsumo);
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
