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
    }
    
}
