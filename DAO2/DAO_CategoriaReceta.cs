﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_CategoriaReceta
    {
        SqlConnection conexion;
        DTO_CategoriaReceta dto_categoriareceta;
        public DAO_CategoriaReceta ()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_categoriareceta = new DTO_CategoriaReceta();
        }
        public DTO_CategoriaReceta DAO_Consultar_CategoriaXReceta(int i)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarCategoriaXReceta", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CR_idCategoriaReceta",i);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                dto_categoriareceta.CR_idCategoriaReceta = i;
                dto_categoriareceta.CR_nombreCategoria = reader[1].ToString();
            }
            conexion.Close();
            return dto_categoriareceta;

        }
        public DataSet SelectCategoriaReceta()
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_SELECT_CATEGORIA_RECETA", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
