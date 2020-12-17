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
            comando.Parameters.AddWithValue("@DC_cantidadCotizacion", detCot.DC_cantidadCotizacion);
            comando.Parameters.AddWithValue("@C_idCotizacion", detCot.C_idCotizacion);
            comando.Parameters.AddWithValue("@I_idInsumo", detCot.I_idInsumo);

            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable DAO_ConsultarDetallesCotizacionXCotizacion(int id)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarDetallesCotizacion", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@C_idCotizacion", id);
            comando.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dtDetCot = new DataTable();
            da.Fill(dtDetCot);
            conexion.Close();
            return dtDetCot;
        }
        public int SelectIdDetalleCotizacion(int C_idCotizacion, string I_nombreInsumo)
        {
            int IdDetalleCotizacion = 0;
            SqlCommand unComando = new SqlCommand("SP_ID_DETALLECOTIZACION", conexion);
            unComando.Parameters.AddWithValue("@C_idCotizacion", C_idCotizacion);
            unComando.Parameters.AddWithValue("@I_nombreInsumo", I_nombreInsumo);
            unComando.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            SqlDataReader dReader = unComando.ExecuteReader();
            if (dReader.Read())
            {
                IdDetalleCotizacion = Convert.ToInt32(dReader["DC_idDetalleCotizacion"]);
            }
            conexion.Close();
            return IdDetalleCotizacion;

        }
        public DataTable SelectDetalleCotizacion(int C_idCotizacion)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_INSUMO_X_COTIZACION", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@C_idCotizacion", C_idCotizacion);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
    }
}
