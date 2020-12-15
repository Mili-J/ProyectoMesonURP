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
        public void DAO_Registrar_Cotizacion(DTO_Cotizacion cot)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_RegistrarCotizacion", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@C_numeroCotizacion", cot.C_numeroCotizacion);
            comando.Parameters.AddWithValue("@C_fechaEmision", cot.C_fechaEmision);
            comando.Parameters.AddWithValue("@C_tiempoPlazo", cot.C_tiempoPlazo);
            comando.Parameters.AddWithValue("@C_documento", cot.C_documento);
            comando.Parameters.AddWithValue("@PR_idProveedor", cot.PR_idProveedor);
            comando.Parameters.AddWithValue("@EC_idEstadoCotizacion", cot.EC_idEstadoCotizacion);
            comando.Parameters.AddWithValue("@U_idUsuario", cot.U_idUsuario);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public int DAO_IdCotizacionMayor()
        {
            int id;
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarIdCotizacionMayor", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            comando.ExecuteNonQuery();
            id = Convert.ToInt32(comando.Parameters["@id"].Value);
            conexion.Close();
            return id;
        }
    }
    
}
