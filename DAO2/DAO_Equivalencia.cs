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
        public bool DAO_Consultar_Equivalencia_x_Insumo(DTO_MedidaXFormatoCocina objMedidaFC, int idInsumo)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_SELECT_EQUIVALENCIA_X_INSUMO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@MedidaFCocina", objMedidaFC.M_idMedida));
            cmd.Parameters.Add(new SqlParameter("@I_idInsumo", idInsumo));
            SqlDataReader reader = cmd.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                dto_eq.E_cantidad = (int)reader[0];
            }
            conexion.Close();
            return hayRegistros;

        }
        
    }
}
