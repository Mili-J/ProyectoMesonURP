using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DTO2;

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

            unComando.Parameters.AddWithValue("@E_cantidad", objEquivalencia.E_cantidad);
            unComando.Parameters.AddWithValue("@I_idIngrediente", objEquivalencia.I_idIngrediente);
            unComando.Parameters.AddWithValue("@MXFC_idMedidaFCocina", objEquivalencia.MXFC_idMedidaFCocina);
            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable ListarEquivalencias()
        {
            try
            {
                conexion.Open();
                DataTable dtable = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_Select_Equivalencias", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtable);
                conexion.Close();
                return dtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DAO_ConsultarEquivalenciaXIngrediente(int idReceta)
        {
            try
            {
                conexion.Open();
                DataTable dtable = new DataTable();
                SqlCommand cmd = new SqlCommand("SP_Equivalencia_x_Ingrediente", conexion);
                cmd.Parameters.Add(new SqlParameter("@R_idReceta", idReceta));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtable);
                conexion.Close();
                return dtable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable DAOSelectEquivalencia(int I_idIngrediente)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_EQUIV_X_INGREDIENTE", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@I_idIngrediente", I_idIngrediente);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        //public void ActualizarEquivalencia(DTO_Equivalencia objEquivalencia)
        //{
        //    try
        //    {
        //        conexion.Open();
        //        SqlCommand cmd = new SqlCommand("SP_Update_Equivalencia", conexion);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@E_idEquivalencia", objEquivalencia.E_idEquivalencia));
        //        cmd.Parameters.Add(new SqlParameter("@E_cantidad", objEquivalencia.E_cantidad));
        //        cmd.Parameters.Add(new SqlParameter("@I_idInsumo", objEquivalencia.I_idInsumo));
        //        cmd.Parameters.Add(new SqlParameter("@MXFC_idMedidaFCocina", objEquivalencia.MXFC_idMedidaFCocina));

        //        cmd.ExecuteNonQuery();
        //        conexion.Close();
        //    }
        //    catch (SqlException)
        //    {
        //        throw;
        //    }
        //}
        public bool SelectExistenciaIngredientexMxfc(int I_idIngrediente, int MXFC_idMedidaFCocina)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_SELECT_EXISTENCIA_INGREDIENTE_X_MXFC", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@I_idIngrediente", I_idIngrediente);
                cmd.Parameters.AddWithValue("@MXFC_idMedidaFCocina", MXFC_idMedidaFCocina);
                cmd.ExecuteNonQuery();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 0)
                {
                    conexion.Close();
                    return false;
                }
                else
                {
                    conexion.Close();
                    return true;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        //public DataTable DAOconsultarDetalleExI(int I_idIngrediente)
        //{
        //    try
        //    {
        //        conexion.Open();
        //        SqlDataAdapter _Data = new SqlDataAdapter("SP_Consultar_Detalle_ExI", conexion);
        //        _Data.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        _Data.SelectCommand.Parameters.AddWithValue("@I_idIngrediente", I_idIngrediente);
        //        DataSet _Ds = new DataSet();
        //        _Data.Fill(_Ds);
        //        return _Ds.Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void ActualizarEquivalencia(DTO_Equivalencia objEquivalencia)
        //{
        //    try
        //    {
        //        conexion.Open();
        //        SqlCommand cmd = new SqlCommand("SP_Update_Equivalencia", conexion);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("@E_idEquivalencia", objEquivalencia.E_idEquivalencia));
        //        cmd.Parameters.Add(new SqlParameter("@E_cantidad", objEquivalencia.E_cantidad));
        //        cmd.Parameters.Add(new SqlParameter("@I_idInsumo", objEquivalencia.I_idInsumo));
        //        cmd.Parameters.Add(new SqlParameter("@MXFC_idMedidaFCocina", objEquivalencia.MXFC_idMedidaFCocina));

        //        cmd.ExecuteNonQuery();
        //        conexion.Close();
        //    }
        //    catch (SqlException)
        //    {
        //        throw;
        //    }
        //}
        public List<DTO_Equivalencia_SP> DAOconsultarDetalleExI(int I_idIngrediente)
        {
            List<DTO_Equivalencia_SP> list = new List<DTO_Equivalencia_SP>();
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("SP_Consultar_Detalle_ExI", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                comando.Parameters.AddWithValue("@I_idIngrediente", I_idIngrediente);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    DTO_Equivalencia_SP dto = new DTO_Equivalencia_SP()
                    {
                        I_idIngrediente = int.Parse(reader[0].ToString()),
                        I_nombreIngrediente = reader[1].ToString(),
                        E_cantidad = decimal.Parse(reader[2].ToString()),
                        MXFC_idMedidaFCocina = int.Parse(reader[3].ToString()),
                        M_nombreMedida = reader[4].ToString(),
                        FCO_nombreFormatoCocina = reader[5].ToString(),
                    };
                    list.Add(dto);
                }
            }
            catch (Exception)
            {
                throw;
            }
            conexion.Close();
            return list;
        }
    }
}
