using System;
using System.Data;
using System.Data.SqlClient;
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
                    objUsuario.U_idUsuario = reader.GetInt32(0);
                    objUsuario.U_codigo = reader.GetString(1);
                    objUsuario.U_contraseña = reader.GetString(2);
                    objUsuario.TU_idTipoUsuario = reader.GetInt32(3);
                    objUsuario.P_idPersona = reader.GetInt32(4);
                    objUsuario.P_nombres = reader.GetString(5);
                    objUsuario.P_aPaterno = reader.GetString(6);
                    objUsuario.P_aMaterno = reader.GetString(7);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            conexion.Close();
            return objUsuario;
        }

        public void getPerfil(DTO_Usuario objUsuario, DTO_TipoUsuario objTipoU)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Tipo_Usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@codigo", objUsuario.U_codigo));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    objTipoU.TU_nombreTipoUsuario = reader.GetString(0);
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DTO_Usuario DAO_ConsultarUsuario(int id)
        {
            conexion.Open();
            DTO_Usuario usario = new DTO_Usuario();
            SqlCommand comando = new SqlCommand("SP_ConsultarUsuario", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@U_idUsuario", id);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                usario.U_idUsuario = Convert.ToInt32(reader[0]);
                usario.U_codigo = Convert.ToString(reader[1]);
                usario.U_contraseña = Convert.ToString(reader[2]);
                usario.TU_idTipoUsuario = Convert.ToInt32(reader[3]);
                usario.P_idPersona = Convert.ToInt32(reader[4]);

            }
            conexion.Close();
            return usario;
        }
    }
}
