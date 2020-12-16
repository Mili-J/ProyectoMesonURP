using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class DAO_DetalleCotizacion
    {
        SqlConnection conexion;
        
        public DAO_DetalleCotizacion()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            
        }
        public int SelectIdDetalleCotizacion(int C_idCotizacion)
        {
            int IdDetalleCotizacion = 0;
            SqlCommand unComando = new SqlCommand("SP_ID_DETALLECOTIZACION", conexion);
            unComando.Parameters.AddWithValue("@C_idCotizacion", C_idCotizacion);
            unComando.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            SqlDataReader dReader = unComando.ExecuteReader();
            if (dReader.Read())
            {
                IdDetalleCotizacion = Convert.ToInt32(dReader["C_idCotizacion"]);
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
