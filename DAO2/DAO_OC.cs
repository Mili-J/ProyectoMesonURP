using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;

using System.Data.SqlClient;
using DTO;
using System.Data;

namespace DAO
{
    public class DAO_OC
    {
        SqlConnection conexion;
        DTO_Medida dto_medida;

        public DAO_OC()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }

        public DataTable ListarOC(string OC_numeroOC)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Listar_OC_GO", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@OC_idOC", OC_numeroOC);
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
    }
}
