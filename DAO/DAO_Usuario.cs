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


        public bool Login(DTO_Usuario objUsuario, DTO_Persona objPersona)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Iniciar_Sesion", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@correo", objPersona.P_correo));
                cmd.Parameters.Add(new SqlParameter("@contraseña", objUsuario.U_contraseña));
                cmd.ExecuteNonQuery();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if(count == 0)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
