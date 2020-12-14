using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO2
{
    public class DAO_EstadoReceta
    {
        SqlConnection conexion;
        public DAO_EstadoReceta()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
        public DataSet SelectEstadoReceta()
        {
            try
            {
                SqlDataAdapter unComando = new SqlDataAdapter("SP_SELECT_ESTADO_RECETA", conexion);
                unComando.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dSet = new DataSet();
                unComando.Fill(dSet);
                return dSet;
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public string SelectEstadoxIdReceta(int R_idReceta)
        {
            string estado = "";
            SqlCommand unComando = new SqlCommand("SP_SELECT_ESTADO_RECETA_X_ID", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.AddWithValue("@R_idReceta", R_idReceta);
            conexion.Open();
            SqlDataReader dReader = unComando.ExecuteReader();
            if (dReader.Read())
            {
                estado = Convert.ToString(dReader["EP_nombreEstadoR"]);
            }
            conexion.Close();
            return estado;

        }
        public int SelectIdEstadoxIdReceta(int R_idReceta)
        {
            int estado = 0;
            SqlCommand unComando = new SqlCommand("SP_SELECT_ESTADO_RECETA_X_ID", conexion);
            unComando.CommandType = CommandType.StoredProcedure;
            unComando.Parameters.AddWithValue("@R_idReceta", R_idReceta);
            conexion.Open();
            SqlDataReader dReader = unComando.ExecuteReader();
            if (dReader.Read())
            {
                estado = Convert.ToInt32(dReader["EP_idEstadoReceta"]);
            }
            conexion.Close();
            return estado;

        }
    }
}
