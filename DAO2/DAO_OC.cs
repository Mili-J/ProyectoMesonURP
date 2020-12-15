using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DAO
{
    public class DAO_OC
    {
        SqlConnection conexion;
        DAO_Cotizacion objCotizacion;
        public DAO_OC()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            objCotizacion = new DAO_Cotizacion();
        }
        public void EnviarCorreo(DTO_OC objDto,int idCotizacion, string msj)
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
