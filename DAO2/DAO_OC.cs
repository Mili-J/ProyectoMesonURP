using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Data;
using DTO2;

namespace DAO
{
    public class DAO_OC
    {
        SqlConnection conexion;
        DTO_Medida dto_medida;
        DAO_Cotizacion objCotizacion;

        public DAO_OC()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            objCotizacion = new DAO_Cotizacion();
        }
        public void InsertOC(DTO_OC objDTO)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("SP_INSERT_OC", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@OC_numeroOC", objDTO.OC_numeroOc));
            unComando.Parameters.Add(new SqlParameter("@OC_fechaEmision", objDTO.OC_fechaEmision));
            unComando.Parameters.Add(new SqlParameter("@OC_fechaEntrega", objDTO.OC_fechaEntrega));
            unComando.Parameters.Add(new SqlParameter("OC_tipoPago", objDTO.OC_tipoPago));
            unComando.Parameters.Add(new SqlParameter("@OC_totalCompra", objDTO.OC_totalCompra));
            unComando.Parameters.Add(new SqlParameter("@EOC_idEstadoOC", objDTO.EOC_idEstadoOC));
            unComando.Parameters.Add(new SqlParameter("@U_idUsuario", objDTO.U_idUsuario));


            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public int SelectIdOC()
        {
            int idOC = 0;
            SqlCommand unComando = new SqlCommand("SP_SELECT_ID_OC", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            SqlDataReader dReader = unComando.ExecuteReader();
            if (dReader.Read())
            {
                idOC = Convert.ToInt32(dReader["OC_idOC"]);
            }
            conexion.Close();
            return idOC;

        }
        public DataTable ListarOC(string numOC)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Listar_OC_GO", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@OC_numeroOC", numOC);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        public DataTable BuscarOC(int idOC)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Buscar_OC_GO", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@OC_idOC", idOC);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarOC_2(int idOC)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Listar_OC_2_GO", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@OC_idOC", idOC);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UPDATE_EstadoOC(int idOC)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("SP_UPDATE_OC_GO", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@OC_idOC", idOC));
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public void EnviarCorreo(DTO_OC objDto, int idCotizacion, string msj)
        {
            try
            {
                string correo = objCotizacion.SelectProveedorxCotizacion(idCotizacion);

                MailMessage msg = new MailMessage();
                msg.To.Add(correo);
                msg.Subject = "Orden de Compra" + objDto.OC_idOC;
                msg.SubjectEncoding = Encoding.UTF8;
                msg.IsBodyHtml = true;
                msg.Body = msj;
                msg.BodyEncoding = Encoding.UTF8;
                msg.From = new MailAddress("mesonurp@gmail.com");
                SmtpClient cliente = new SmtpClient
                {
                    Credentials = new NetworkCredential("mesonurp@gmail.com", "meson123456"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true
                };
                cliente.Send(msg);
            }
            catch (System.Net.Mail.SmtpException)
            {
                throw;
            }
        }
        public string SelectNumeroOC()
        {
            string numeroOC = "";
            SqlCommand unComando = new SqlCommand("SP_numeroOC", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            SqlDataReader dReader = unComando.ExecuteReader();
            if (dReader.Read())
            {
                numeroOC = Convert.ToString(dReader["CODIGO"]);
            }
            conexion.Close();
            return numeroOC;

        }
       public List<DTO_OC_SP> ListarOC_3(int idOC)
        {
            
            List<DTO_OC_SP> lista = new List<DTO_OC_SP>();
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Listar_OC_2_GO", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@OC_idOC", idOC);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    
                    lista.Add(new DTO_OC_SP
                    {
                        OC_idOC = Convert.ToInt32(dr["OC_idOC"]),
                        DOC_idDetalleOC = Convert.ToInt32(dr["DOC_idDetalleOC"]),
                        OC_numeroOC = Convert.ToInt32(dr["OC_numeroOC"]),
                        I_idInsumo = Convert.ToInt32(dr["I_idInsumo"]),
                        I_nombreInsumo = Convert.ToString(dr["I_nombreInsumo"]),
                        DC_cantidadCotizacion = Convert.ToDouble(dr["DC_cantidadCotizacion"]),
                        Estado = Convert.ToString(dr["Estado"]),
                        Datos = Convert.ToString(dr["Datos"])
                    });

                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelectPieEstadoOC()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand unComando = new SqlCommand("SP_Pie_EstadoOC", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter data = new SqlDataAdapter(unComando);
                data.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
