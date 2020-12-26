using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO2;

namespace DAO2
{
    public class DAO_Formato_Cocina
    {
        SqlConnection conexion;
        DTO_FormatoCocina dto_fcocina;
        public DAO_Formato_Cocina()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
            dto_fcocina = new DTO_FormatoCocina();
        }
        public DTO_FormatoCocina DAO_SelectNombreFCocina(int FCO_idFCocina)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_SELECT_NOMBRE_FCOCINA", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@FCO_idFCocina", FCO_idFCocina);
            comando.ExecuteNonQuery();

            SqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                dto_fcocina.FCO_nombreFormatoCocina = Convert.ToString(reader[0]);
            }

            conexion.Close();
            return dto_fcocina;
        }
    }
}
