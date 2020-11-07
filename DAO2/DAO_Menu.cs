using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public  class DAO_Menu
    {
        SqlConnection conexion;
        DTO_Menu dto_menu;
        public DAO_Menu()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_menu = new DTO_Menu();
        }
        public void DAO_RegistrarMenu(DTO_Menu dto_menu)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_RegistrarMenu", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ME_fechaMenu", dto_menu.ME_fechaMenu);
            comando.Parameters.AddWithValue("@ME_numRaciones", dto_menu.ME_numRaciones);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public int DAO_IdMenuMayor()
        {
            int id;
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarIdMenuMayor", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            comando.ExecuteNonQuery();
            id = Convert.ToInt32(comando.Parameters["@id"].Value);
            conexion.Close();
            return id;
        }
        public DTO_Menu DAO_ConsultarMenu(DateTime fecha)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarMenu", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ME_fechaMenu", fecha);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                dto_menu.ME_idMenu = Convert.ToInt32(reader[0]);
                dto_menu.ME_fechaMenu = Convert.ToDateTime(reader[1]);
                dto_menu.ME_numRaciones = Convert.ToInt32(reader[2]);
            }
            conexion.Close();
            return dto_menu;
        }
        public bool DAO_HayMenu(DateTime fecha)
        {
            bool estado;
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarMenu", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ME_fechaMenu", fecha);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read()) estado = true;      
            else estado = false;

            conexion.Close();
            return estado;
        }
    }
}
