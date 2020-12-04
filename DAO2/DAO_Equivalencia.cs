using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_Equivalencia
    {
        SqlConnection conexion;
        DTO_Equivalencia dto_eq;
        

        public DAO_Equivalencia()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_eq = new DTO_Equivalencia();
        }

        public void AgregarEquivalencia(DTO_Equivalencia objEquivalencia)
        {
            //conexion.Open();
            //SqlCommand unComando = new SqlCommand("SP_Insert_Equivalencia", conexion);
            //unComando.CommandType = CommandType.StoredProcedure;
            //unComando.Parameters.Add(new SqlParameter("@R_nombreReceta", objDTO.R_nombreReceta));
            //unComando.Parameters.Add(new SqlParameter("@R_numeroPorcion", objDTO.R_numeroPorcion));
            //unComando.Parameters.Add(new SqlParameter("@R_descripcion", objDTO.R_descripcion));
            //unComando.Parameters.Add(new SqlParameter("@R_imagenReceta", objDTO.R_imagenReceta));
            //unComando.Parameters.Add(new SqlParameter("@CR_idCategoriaReceta", objDTO.CR_idCategoriaReceta));

            //unComando.ExecuteNonQuery();
            //conexion.Close();
        }
        public DataTable ListarEquivalencias()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_Select_Equivalencias", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
