using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
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
        public void DAO_Actualizar_Cotizacion(DTO_Cotizacion cot)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ActualizarCotizacion", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@C_idCotizacion", cot.C_idCotizacion);
            comando.Parameters.AddWithValue("@C_numeroCotizacion", cot.C_numeroCotizacion);
            comando.Parameters.AddWithValue("@C_tiempoPlazo", cot.C_tiempoPlazo);
            comando.Parameters.AddWithValue("@C_documento", cot.C_documento);
            comando.Parameters.AddWithValue("@PR_idProveedor", cot.PR_idProveedor);
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
        public DTO_Cotizacion DAO_ConsultarCotizacion(int id)
        {
            conexion.Open();
            DTO_Cotizacion cot = new DTO_Cotizacion();
            SqlCommand comando = new SqlCommand("SP_ConsultarCotizacion", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@C_idCotizacion", id);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                cot.C_idCotizacion = Convert.ToInt32(reader[0]);
                cot.C_numeroCotizacion = Convert.ToString(reader[1]);
                cot.C_fechaEmision = Convert.ToDateTime(reader[2]);
                cot.C_tiempoPlazo = Convert.ToString(reader[3]);
                cot.C_documento = Convert.ToString(reader[4]);
                cot.PR_idProveedor = Convert.ToInt32(reader[5]);
                cot.EC_idEstadoCotizacion = Convert.ToInt32(reader[6]);
                cot.U_idUsuario = Convert.ToInt32(reader[7]);
            }
            conexion.Close();
            return cot;
        }
        public bool EnviarCorreo(DTO_Cotizacion dto_cot, string msj)
        {
            DTO_Proveedor dto_proveedor = new DTO_Proveedor();
            DAO_Proveedor dao_proveedor = new DAO_Proveedor();
            try
            {
                dto_proveedor = dao_proveedor.DAO_ConsultarProveedor(dto_cot.PR_idProveedor);
                
                
                MailMessage msg = new MailMessage();
                msg.To.Add(dto_proveedor.PR_correoContacto);
                msg.Subject = "Solicitudad de cotización " + dto_cot.C_numeroCotizacion;
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
                return true;
            }
            catch (Exception)
            {
                //throw;
                return false;
            }
        }
        public void DAO_ActualizarEstadoCotizacion(DTO_Cotizacion cot)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ActualizarEstadoCotizacion", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@C_idCotizacion", cot.C_idCotizacion);
            comando.Parameters.AddWithValue("@EC_idEstadoCotizacion", cot.EC_idEstadoCotizacion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
    
}
