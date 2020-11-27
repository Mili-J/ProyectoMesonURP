﻿using System;
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

        public DataSet DAO_SelectCategoriaI()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Listar_Categoria", conexion);
            comando.CommandType = CommandType.StoredProcedure;           
            comando.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);
            conexion.Close();
            return ds;
        }
        public DataSet DAO_SelectInsumoCategoria(DTO_CategoriaInsumo objCategoriaI)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_Listar_Insumo_x_Categoria", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter ("@idCategoria", objCategoriaI.CI_idCategoriaInsumo));
            cmd.ExecuteNonQuery();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            conexion.Close();
            return ds;
        }

    }
}
