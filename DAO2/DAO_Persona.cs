using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DAO_Persona
    {
        SqlConnection conexion;
        public DAO_Persona()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public DTO_Persona DAO_ConsultarPersona(int id)
        {
            conexion.Open();
            DTO_Persona persona = new DTO_Persona();
            SqlCommand comando = new SqlCommand("SP_ConsultarPersona", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@P_idPersona", id);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                persona.P_idPersona = Convert.ToInt32(reader[0]);
                persona.P_nombres = Convert.ToString(reader[1]);
                persona.P_aPaterno = Convert.ToString(reader[2]);
                persona.P_aMaterno = Convert.ToString(reader[3]);
                persona.P_celular = Convert.ToString(reader[4]);
                persona.P_correo = Convert.ToString(reader[5]);
                persona.P_tipoDoc = Convert.ToString(reader[6]);
                persona.P_numeroDoc = Convert.ToString(reader[7]);
                
                try
                {
                    persona.P_imagen = (byte[])reader[8];
                }
                catch (Exception)
                {

                    persona.P_imagen = null;
                }
            }
            conexion.Close();
            return persona;
        }
    }
}
