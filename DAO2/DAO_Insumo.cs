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
        

        public DAO_Insumo()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }

        public DataTable ListarInsumo()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_Listar_Insumo_MS", conexion);
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
        public DataTable ListarInsumo2()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_Listar_Insumo_2_MS", conexion);
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
        public DataTable BuscarInsumo(int IdInsumo)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Select_Medida_X_Insumo", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@I_idInsumo", IdInsumo);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable BuscarInsumoF(string nombreInsumo)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Buscar_Insumo_MS", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@I_nombreInsumo", nombreInsumo);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            DTO_Medida dtoM = new DTO_Medida();
            SqlCommand cmd = new SqlCommand("SP_SELECT_MEDIDA_X_INSUMO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@I_idInsumo", objInsumo.I_idInsumo));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dtoM.M_nombreMedida = reader[0].ToString();
                dtoM.M_idMedida = int.Parse(reader[1].ToString());
            }
            conexion.Close();
            return dtoM;
        }

        public DataTable BuscarInsumoP(int IdInsumo)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Buscar_Insumo_Prueba", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@I_idInsumo", IdInsumo);
                DataSet ds = new DataSet();
                cmd.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DAO_Actualizar_Cantidad_Insumo(DTO_Insumo objInsumo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_UPDATE_CANTIDAD_INSUMO", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@I_cantidad", objInsumo.I_cantidad);
                cmd.Parameters.AddWithValue("@I_idInsumo", objInsumo.I_idInsumo);
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UPDATE_cantidadInsumo(decimal cantidad, int idInsumo)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("SP_UPDATE_Insumo_GO", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@cantidad", cantidad));
            unComando.Parameters.Add(new SqlParameter("@I_idInsumo", idInsumo));
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable ConsultarInsumo(string @nombreInsumo)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Consultar_Insumo_MS", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@nombreInsumo", nombreInsumo);
                DataSet dSet = new DataSet();
                cmd.Fill(dSet);
                return dSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable SelectBarChartInsumoD()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand unComando = new SqlCommand("SP_BarChart_Insumos_Disponibles", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter data = new SqlDataAdapter(unComando);
                data.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelectBarChartInsumoComprar()
        {
            try
            {
                DataTable dtable = new DataTable();
                SqlCommand unComando = new SqlCommand("SP_BarChart_Insumos_Comprar", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter data = new SqlDataAdapter(unComando);
                data.Fill(dtable);
                return dtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}