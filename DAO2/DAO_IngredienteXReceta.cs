using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_IngredienteXReceta
    {
        SqlConnection conexion;
        public DAO_IngredienteXReceta()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public void InsertIngredienteXReceta(DTO_IngredienteXReceta objDTO)
        {
            conexion.Open();
            SqlCommand unComando = new SqlCommand("SP_INSERT_INGREDIENTEXRECETA", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.Add(new SqlParameter("@IR_cantidad", objDTO.IR_cantidad));
            unComando.Parameters.Add(new SqlParameter("@IR_formatoMedida", objDTO.IR_formatoMedida));
            unComando.Parameters.Add(new SqlParameter("@R_idReceta", objDTO.R_idReceta));
            unComando.Parameters.Add(new SqlParameter("@I_idIngrediente", objDTO.I_idIngrediente));

            unComando.ExecuteNonQuery();
            conexion.Close();
        }
        public DataTable SelectIngredientesXReceta(int R_idReceta)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_INGREDIENTE_X_RECETA", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@R_idReceta", R_idReceta);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            conexion.Close();
            return dt;
        }
    }
}
