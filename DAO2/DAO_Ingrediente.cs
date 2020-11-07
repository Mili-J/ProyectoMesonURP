using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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
        public string SelectNombreIngrediente(int I_idIngrediente)
        {
            string nombre = "";
            try
            {
                SqlCommand unComando = new SqlCommand("SP_SELECT_NOMBRE_INGREDIENTE", conexion);
                unComando.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                unComando.Parameters.AddWithValue("@I_idIngrediente", I_idIngrediente);
                SqlDataReader dReader = unComando.ExecuteReader();
                if (dReader.Read())
                {
                    nombre = dReader["I_nombreIngrediente"].ToString();
                }
                conexion.Close();
                return nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
