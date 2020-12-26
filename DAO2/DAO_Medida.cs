using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAO
{
    public class DAO_Medida
    {
        SqlConnection conexion;
        DTO_Medida dto_medida;
        public DAO_Medida()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_medida = new DTO_Medida();
        }

        public DTO_Medida DAO_SelectNombreMedida(int M_idMedida)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_NOMBRE_MEDIDA", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@M_idMedida", M_idMedida);
            comando.ExecuteNonQuery();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                dto_medida.M_nombreMedida = Convert.ToString(reader[0]);
            }

            conexion.Close();
            return dto_medida;
        }
    }
}
