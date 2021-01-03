using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;
namespace DAO
{
    public class DAO_Medida
    {
        SqlConnection conexion;
        public DAO_Medida()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public DTO_Medida DAO_ConsultarMedida(int id)
        {
            DTO_Medida dto_medida = new DTO_Medida();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarMedida", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@M_idMedida", id);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                dto_medida.M_idMedida = Convert.ToInt32(reader[0]);
                dto_medida.M_nombreMedida = reader[1].ToString();
            }
            conexion.Close();
            return dto_medida;
        }
    }
}
