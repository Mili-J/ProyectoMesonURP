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
    public class DAO_Menu
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
            comando.Parameters.AddWithValue("@ME_totalPorcion", dto_menu.ME_totalPorcion);
            comando.Parameters.AddWithValue("@EM_idEstadoMenu", dto_menu.EM_idEstadoMenu);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public void DAO_ActualizarMenu(DTO_Menu obj)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ActualizarMenu", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ME_totalPorcion", obj.ME_totalPorcion);
            comando.Parameters.AddWithValue("@ME_idMenu", obj.ME_idMenu);
            comando.Parameters.AddWithValue("@EM_idEstadoMenu", obj.EM_idEstadoMenu);
            comando.ExecuteNonQuery();
            conexion.Close();

        }
        public void DAO_ActualizaEstadoMenu(DTO_Menu obj)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ActualizarEstadoMenu", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ME_idMenu", obj.ME_idMenu);
            comando.Parameters.AddWithValue("@EM_idEstadoMenu", obj.EM_idEstadoMenu);
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
            comando.Parameters.AddWithValue("@ME_fechaMenu", fecha.ToShortDateString());
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                dto_menu.ME_idMenu = Convert.ToInt32(reader[0]);
                dto_menu.ME_fechaMenu = Convert.ToString(reader[1]);
                dto_menu.ME_totalPorcion = Convert.ToInt32(reader[2]);
                dto_menu.EM_idEstadoMenu = Convert.ToInt32(reader[3]);
            }
            conexion.Close();
            return dto_menu;
        }
        public DTO_Menu DAO_ConsultarMenuXID(int id)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarMenuXID", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ME_idMenu", id);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                dto_menu.ME_idMenu = Convert.ToInt32(reader[0]);
                dto_menu.ME_fechaMenu = Convert.ToString(reader[1]);
                dto_menu.ME_totalPorcion = Convert.ToInt32(reader[2]);
                dto_menu.EM_idEstadoMenu = Convert.ToInt32(reader[3]);
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
            comando.Parameters.AddWithValue("@ME_fechaMenu", fecha.ToShortDateString());
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read()) estado = true;
            else estado = false;

            conexion.Close();
            return estado;
        }
        public DataTable DAO_ConsultarMenusXEstadoYFecha(int estado, DateTime fecha)
        {
            DataTable dtMenu = new DataTable();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarMenusXEstadoYFecha", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@EM_idEstadoMenu", estado);
            comando.Parameters.AddWithValue("@ME_fechaMenu", fecha.ToShortDateString());
            comando.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dtMenu);
            conexion.Close();
            return dtMenu;
        }
        public DataTable DAO_ConsultarMenusXYFecha(DateTime fecha)
        {
            DataTable dtMenu = new DataTable();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarMenu", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ME_fechaMenu", fecha.ToShortDateString());
            comando.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dtMenu);
            conexion.Close();
            return dtMenu;
        }
    }
}
