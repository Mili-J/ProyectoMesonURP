﻿using System;
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
    }
}
