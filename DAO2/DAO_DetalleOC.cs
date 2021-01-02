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
        public void InsertDetalleOC(DTO_DetalleOC objDTO)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("SP_INSERT_DETALLEOC", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@DOC_precioUnitario", objDTO.DOC_precioUnitario));
            unComando.Parameters.Add(new SqlParameter("@DOC_totalPrecio", objDTO.DOC_totalPrecio));
            unComando.Parameters.Add(new SqlParameter("@DOC_cantidadEntregada", objDTO.DOC_cantidadEntregada));
            unComando.Parameters.Add(new SqlParameter("@OC_idOC", objDTO.OC_idOC));
            unComando.Parameters.Add(new SqlParameter("@DC_idDetalleCotizacion", objDTO.DC_idDetalleCotizacion));

            unComando.ExecuteNonQuery();
            conexion.Close();
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
        public bool SelectExistenciaDetalleOC(int C_idCotizacion)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_SELECT_EXISTENCIA_DETALLEOC", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@C_idCotizacion", C_idCotizacion);
                cmd.ExecuteNonQuery();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    conexion.Close();
                    return false;
                }
                else
                {
                    conexion.Close();
                    return true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public DataTable SelectDetalleOC(int C_idCotizacion)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_DETALLEOC", conexion);
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
