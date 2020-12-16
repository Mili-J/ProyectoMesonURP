using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class DAO_EstadoCotizacion
    {
        SqlConnection conexion;
        public DAO_EstadoCotizacion()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public DTO_EstadoCotizacion DAO_ConsultarEstadoCotizacion(int id)
        {
            DTO_EstadoCotizacion estCot = new DTO_EstadoCotizacion();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarEstadoCotizacion", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@EC_idEstadoCotizacion", id);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                estCot.EC_idEstadoCotizacion = Convert.ToInt32(reader[0]);
                estCot.EC_nombreEstadoC = Convert.ToString(reader[1]);
            }
            conexion.Close();
            return estCot;
        }

    }
}
