using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAO
{
    public class DAO_Ingrediente
    {
        DTO_Ingrediente dto_ingrediente;
        SqlConnection conexion;
        public DAO_Ingrediente()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_ingrediente = new DTO_Ingrediente();
        }
        public DataSet SelectIngrediente()
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_SELECT_INGREDIENTE", conexion);
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
        public void DAO_Registrar_Ingrediente(DTO_Ingrediente dto_ingrediente)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_INGREDIENTE", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@I_nombreIngrediente", dto_ingrediente.I_nombreIngrediente);
            cmd.Parameters.AddWithValue("@I_pesoUnitario", dto_ingrediente.I_pesoUnitario);
            cmd.Parameters.AddWithValue("@I_cantidad", dto_ingrediente.I_cantidad);
            cmd.Parameters.AddWithValue("@I_idInsumo", dto_ingrediente.I_idInsumo);

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
        public DTO_Ingrediente DAO_Consultar_IngredienteXID(int i)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ConsultarIngrediente", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@I_idIngrediente", i);
            comando.ExecuteNonQuery();
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                dto_ingrediente.I_idIngrediente = i;
                dto_ingrediente.I_nombreIngrediente = reader[1].ToString();
                dto_ingrediente.I_pesoUnitario = Convert.ToDecimal(reader[2]);
                dto_ingrediente.I_cantidad = Convert.ToDecimal(reader[3]);
                dto_ingrediente.I_idInsumo = Convert.ToInt32(reader[4]);
                dto_ingrediente.E_idEquivalencia = Convert.ToInt32(reader[5]);
            }
            conexion.Close();
            return dto_ingrediente;
        }
        public DTO_Ingrediente SelectNombreIngrediente(int I_idIngrediente)
        {
                DTO_Ingrediente ingrediente = new DTO_Ingrediente();
                conexion.Open();
                SqlCommand comando = new SqlCommand("SP_SELECT_NOMBRE_INGREDIENTE", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@I_idIngrediente", I_idIngrediente);
                comando.ExecuteNonQuery();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    ingrediente.I_nombreIngrediente = Convert.ToString(reader[0]);
                }

                conexion.Close();
                return ingrediente;
        }
        public int SelectIdIngredientexNombre(string I_nombreIngrediente)
        {
            int idIngrediente = 0;
            SqlCommand unComando = new SqlCommand("SP_SELECT_IDINGREDIENTE_X_NOMBRE", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.AddWithValue("@I_nombreIngrediente", I_nombreIngrediente);

            conexion.Open();

            SqlDataReader dReader = unComando.ExecuteReader();
            if (dReader.Read())
            {
                idIngrediente = Convert.ToInt32(dReader["I_idIngrediente"]);
            }
            conexion.Close();
            return idIngrediente;
        }

        public DataSet ListarFormatoCocina()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Select_FCocina", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }

        public DataTable ListarIngredientes()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Select_Ingrediente_D", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public DataSet SelectMedidaxIdIngrediente(int I_idIngrediente)
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_SELECT_MEDIDA_X_ID_INGREDIENTE", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                unComando.SelectCommand.Parameters.AddWithValue("@I_idIngrediente", I_idIngrediente);
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public void ActualizarIngrediente(DTO_Ingrediente objIngre)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Update_Ingrediente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@I_idIngrediente", objIngre.I_idIngrediente));
                cmd.Parameters.Add(new SqlParameter("@I_nombreIngrediente", objIngre.I_nombreIngrediente));
                cmd.Parameters.Add(new SqlParameter("@I_pesoUnitario", objIngre.I_pesoUnitario));
                cmd.Parameters.Add(new SqlParameter("@I_cantidad", objIngre.I_cantidad));
                cmd.Parameters.Add(new SqlParameter("@I_idnsumo", objIngre.I_idInsumo));
                cmd.Parameters.Add(new SqlParameter("@E_idEquivalencia", objIngre.E_idEquivalencia));
               

                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public DataTable Validar_IngredientesXReceta()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_Validar_IngredientesxReceta", conexion);
            comando.CommandType = CommandType.StoredProcedure;            
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
        public DataTable DAO_Consultar_Ingrediente(string @nombreIngrediente)
        {
            try
            {
                SqlDataAdapter cmd = new SqlDataAdapter("SP_Consultar_Ingrediente", conexion);
                cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd.SelectCommand.Parameters.AddWithValue("@nombreIngrediente", nombreIngrediente);
                DataSet dSet = new DataSet();
                cmd.Fill(dSet);
                return dSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DAO_ExisteNombreIngrediente(DTO_Ingrediente objIng)
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ExisteIngrediente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@I_nombreIngrediente", objIng.I_nombreIngrediente);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
