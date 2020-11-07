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
    public class DAO_MenuXReceta
    {
        SqlConnection conexion;
        
        public DAO_MenuXReceta()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public void DAO_RegistrarMenuXReceta(DTO_MenuXReceta obj)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_RegistrarMenuXReceta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@R_idReceta", obj.R_idReceta);
            comando.Parameters.AddWithValue("@ME_idMenu", obj.ME_idMenu);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable DAO_ConsultarRecetasXMenu(int i)//Consultar las recetas de un menu
        {
            DataTable dtMXR = new DataTable();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarMenuXReceta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ME_idMenu",i);
            comando.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dtMXR);
            conexion.Close();
            return dtMXR;
        }
    }
}
