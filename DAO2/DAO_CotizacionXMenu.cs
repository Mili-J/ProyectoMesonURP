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
    public class DAO_CotizacionXMenu
    {
        SqlConnection conexion;
        public DAO_CotizacionXMenu()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public void DAO_RegistrarCotizacionXMenu(DTO_CotizacionXMenu cotXmen)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_RegistrarCotizacionXMenu", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@C_idCotizacion",cotXmen.C_idCotizacion);
            comando.Parameters.AddWithValue("@ME_idMenu", cotXmen.ME_idMenu);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable DAO_ConsultarCotizacionXMenuXCotizacion(int id)
        {
            DataTable dtCotMen = new DataTable();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarCotizacionXMenuXCotizacion", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@C_idCotizacion", id);
            
            comando.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dtCotMen);
            conexion.Close();
            return dtCotMen;
        }

    }
}
