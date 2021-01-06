using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Data.SqlClient;
using System.Data;
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
        public DataSet SelectMedida_GI()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            string com = "select*from T_Medida";
            SqlDataAdapter adpt = new SqlDataAdapter(com, conexion);
            DataSet dt = new DataSet();
            adpt.Fill(dt);
            return dt;
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
