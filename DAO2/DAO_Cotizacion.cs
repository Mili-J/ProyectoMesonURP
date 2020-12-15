using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DAO_Cotizacion
    {
        SqlConnection conexion;
        public DAO_Cotizacion()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public DataTable DAO_Consultar_Cotizaciones()
        {
            DataTable dtCot = new DataTable();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarCotizaciones", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dtCot);
            conexion.Close();
            return dtCot;
        }
        public string SelectProveedorxCotizacion(int C_idCotizacion)
        {
            string correoContacto = "";
            SqlCommand unComando = new SqlCommand("SP_SELECT_PROVEEDOR_X_COTIZACION", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.AddWithValue("@C_idCotizacion", C_idCotizacion);
            conexion.Open();
            SqlDataReader dReader = unComando.ExecuteReader();
            if (dReader.Read())
            {
                correoContacto = Convert.ToString(dReader["PR_correoContacto"]);
            }
            conexion.Close();
            return correoContacto;
        }
    }
    
}
