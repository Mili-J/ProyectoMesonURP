using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_Ingrediente
    {
        SqlConnection conexion;
        public DAO_Ingrediente()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
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
                    ingrediente.I_idIngrediente = Convert.ToInt32(reader[0]);
                    ingrediente.I_nombreIngrediente = Convert.ToString(reader[1]);
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
