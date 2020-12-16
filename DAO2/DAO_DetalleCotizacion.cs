using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data.SqlClient;
using System.Data;
namespace DAO
{
    public class DAO_DetalleCotizacion
    {
        SqlConnection conexion;
        public DAO_DetalleCotizacion()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public void DAO_RegistrarDetalleCotizacion(DTO_DetalleCotizacion detCot)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_RegistrarDetalleCotizacion", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@DC_cantidadCotizacion",detCot.DC_cantidadCotizacion);
            comando.Parameters.AddWithValue("@C_idCotizacion",detCot.C_idCotizacion);
            comando.Parameters.AddWithValue("@I_idInsumo",detCot.I_idInsumo);

            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable DAO_ConsultarDetallesCotizacionXCotizacion(int id)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarDetallesCotizacion",conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@C_idCotizacion", id);
            comando.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dtDetCot = new DataTable();
            da.Fill(dtDetCot);
            conexion.Close();
            return dtDetCot;
        }
    }
}
