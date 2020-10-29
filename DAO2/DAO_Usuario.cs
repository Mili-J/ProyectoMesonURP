using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAO
{
    public class DAO_Usuario
    {
        SqlConnection conexion;
        public DAO_Usuario()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }


        public DTO_Usuario Login(DTO_Usuario objUsuario)
        {
            DTO_Usuario dto = new DTO_Usuario();
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_IniciarSesion", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@codigo", objUsuario.U_codigo));
                cmd.Parameters.Add(new SqlParameter("@contraseña", objUsuario.U_contraseña));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dto.U_idUsuario = reader.GetInt32(0);
                    dto.U_codigo = reader.GetString(1);
                    dto.U_contraseña = reader.GetString(2);
                    dto.TU_idTipoUsuario = reader.GetInt32(3);
                    dto.P_idPersona = reader.GetInt32(4);
                    dto.P_nombres = reader.GetString(5);
                    dto.P_aPaterno = reader.GetString(6);
                    dto.P_aMaterno = reader.GetString(7);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            conexion.Close();
            return dto;
        }
    }
}
