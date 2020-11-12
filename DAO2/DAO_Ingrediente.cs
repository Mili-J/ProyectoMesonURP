using DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Data.SqlClient;
using System.Data;
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

    }
}
