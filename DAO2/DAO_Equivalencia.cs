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
            conexion.Open();
            SqlCommand unComando = new SqlCommand("SP_Insert_Equivalencia", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@E_cantidad", objEquivalencia.E_cantidad));
            unComando.Parameters.Add(new SqlParameter("@I_idInsumo", objEquivalencia.I_idInsumo));
            unComando.Parameters.Add(new SqlParameter("@MXFC_idMedidaFCocina", objEquivalencia.MXFC_idMedidaFCocina));           
            unComando.ExecuteNonQuery();
            conexion.Close();
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
