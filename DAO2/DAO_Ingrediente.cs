using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    class DAO_Ingrediente
    {
        DTO_Ingrediente dto_ingrediente;
        SqlConnection conexion;
        public DAO_Ingrediente()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_ingrediente = new DTO_Ingrediente();
        }
        public void DAO_Registrar_Ingrediente(DTO_Ingrediente dto_ingrediente)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_INGREDIENTE", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@I_nombreIngrediente", dto_ingrediente.I_nombreIngrediente);
            cmd.Parameters.AddWithValue("@I_pesoUnitario", dto_ingrediente.I_pesoUnitario);
            cmd.Parameters.AddWithValue("@I_cantidad", dto_ingrediente.I_cantidad);
            cmd.Parameters.AddWithValue("@I_idInsumo", dto_ingrediente.I_idInsumo);
            cmd.Parameters.AddWithValue("@E_idEquivalencia", dto_ingrediente.E_idEquivalencia);

            cmd.ExecuteNonQuery();
            conexion.Close();
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
        
    }
}
