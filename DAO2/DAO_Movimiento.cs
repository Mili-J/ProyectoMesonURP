using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAO
{
    public class DAO_Movimiento
    {
        DTO_Movimiento dto_movimiento;
        SqlConnection conexion;
        public DAO_Movimiento()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_movimiento = new DTO_Movimiento();
        }
        public void InsertMovimientoGO(DTO_Movimiento objDTO)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("SP_Insertar_Movimiento_GO", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@M_cantidad", objDTO.M_cantidad));
            unComando.Parameters.Add(new SqlParameter("@M_fechaMovimiento", objDTO.M_fechaMovimiento));
            unComando.Parameters.Add(new SqlParameter("@I_idInsumo", objDTO.I_idInsumo));
            unComando.Parameters.Add(new SqlParameter("@U_idUsuario", objDTO.U_idUsuario));

            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable SelectMovimiento(string FechaInicial, string FechaFinal)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_MOVIMIENTOS_X_FECHA", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@FechaInicial", FechaInicial);
            comando.Parameters.AddWithValue("@FechaFinal", FechaFinal);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
    }
}
