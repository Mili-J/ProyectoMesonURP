using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_CategoriaInsumo
    {
        SqlConnection conexion;
        public DAO_CategoriaInsumo()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public DataTable DAO_ConsultarCategoriasInsumo()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarCategoriasInsumo", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataTable dtCat = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dtCat);
            conexion.Close();
            return dtCat;
        }
    }
}
