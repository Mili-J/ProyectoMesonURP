using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAO
{
    public class DAO_MedidaXFormato
    {
        SqlConnection conexion;
        public DataSet SelectFC_GI()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            string com = "select*from T_Formato_Compra";
            SqlDataAdapter adpt = new SqlDataAdapter(com, conexion);
            DataSet dt = new DataSet();
            adpt.Fill(dt);
            return dt;
        }
    }
}
