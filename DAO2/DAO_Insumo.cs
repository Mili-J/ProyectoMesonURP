using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DAO_Insumo
    {
        SqlConnection conexion;
        DTO_Medida dto_medida;

        public DAO_Insumo()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_medida = new DTO_Medida();
        }

        public DataTable DAO_Consultar_Equivalencia_x_Insumo(DTO_Insumo dto_insumo)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_EQUIVALENCIA_X_INSUMO", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@I_idInsumo", dto_insumo.I_idInsumo));
            SqlDataReader reader = comando.ExecuteReader();
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public DTO_Medida DAO_Consultar_Medida_x_Insumo(DTO_Insumo objInsumo)
        {
            
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_SELECT_MEDIDA_X_INSUMO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@I_idInsumo", objInsumo.I_idInsumo));
            SqlDataReader reader = cmd.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {
                dto_medida.M_nombreMedida = (string)reader[0];
                dto_medida.M_idMedida = (int)reader[1];

            }
            conexion.Close();
            return dto_medida;

        }
    }
}
