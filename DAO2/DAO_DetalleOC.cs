using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAO
{
    public class DAO_DetalleOC
    {
        DTO_DetalleOC dto_detalleOC;
        SqlConnection conexion;
        public DAO_DetalleOC()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_detalleOC = new DTO_DetalleOC();
        }
        public void UPDATE_cantidadEntregada(decimal cantidad, int idDetalleOC)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("SP_UPDATE_DetalleOC_GO", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@cantidad", cantidad));
            unComando.Parameters.Add(new SqlParameter("@DOC_idDetalleOC", idDetalleOC));
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
