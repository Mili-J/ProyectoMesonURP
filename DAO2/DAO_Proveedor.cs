using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class DAO_Proveedor
    {
        SqlConnection conexion;
        public DAO_Proveedor()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public DataTable DAO_ConsultarProveedores()
        {
            DataTable dt = new DataTable();
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarProveedores", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public DTO_Proveedor DAO_ConsultarProveedor(int id)
        {
            conexion.Open();
            DTO_Proveedor pro = new DTO_Proveedor();
            SqlCommand comando = new SqlCommand("SP_ConsultarProveedor", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PR_idProveedor", id);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                pro.PR_idProveedor = Convert.ToInt32(reader[0]);
                pro.PR_razonSocial = Convert.ToString(reader[1]);
                pro.PR_numeroDocumento = Convert.ToString(reader[2]);
                pro.PR_direccion = Convert.ToString(reader[3]);
                pro.PR_nombreContacto = Convert.ToString(reader[4]);
                pro.PR_telefonoContacto = Convert.ToString(reader[5]);
                pro.PR_correoContacto = Convert.ToString(reader[6]);
                pro.EP_idEstadoProveedor = Convert.ToInt32(reader[7]);
            }
            conexion.Close();
            return pro;
        }
    }
}
