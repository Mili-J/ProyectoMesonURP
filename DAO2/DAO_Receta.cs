﻿using System;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_Receta
    {
        SqlConnection conexion;
        public DAO_Receta()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public void InsertReceta(DTO_Receta objDTO)
        {
                conexion.Open();
                SqlCommand unComando = new SqlCommand("SP_INSERT_RECETA", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                unComando.Parameters.Add(new SqlParameter("@R_nombreReceta", objDTO.R_nombreReceta));
                unComando.Parameters.Add(new SqlParameter("@R_numeroPorcion", objDTO.R_numeroPorcion));
                unComando.Parameters.Add(new SqlParameter("@R_descripcion", objDTO.R_descripcion));
                unComando.Parameters.Add(new SqlParameter("@R_imagenReceta", objDTO.R_imagenReceta));
                unComando.Parameters.Add(new SqlParameter("@CR_idCategoriaReceta", objDTO.CR_idCategoriaReceta));
                
                unComando.ExecuteNonQuery();
                conexion.Close();
        }
        public DataTable SelectRecetaxNombre(string @nombreReceta)
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_SELECT_RECETA_X_NOMBRE", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@nombreReceta", @nombreReceta);
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SelectIdReceta()
        {
            int idReceta = 0;
             SqlCommand unComando = new SqlCommand("SP_SELECT_ID_RECETA", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                SqlDataReader dReader = unComando.ExecuteReader();
                if (dReader.Read())
                {
                    idReceta = Convert.ToInt32(dReader["R_idReceta"]);
                }
                conexion.Close();
                return idReceta;
           
        }
    }
}
