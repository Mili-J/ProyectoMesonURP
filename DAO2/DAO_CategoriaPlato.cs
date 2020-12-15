using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;


namespace DAO
{
    public class DAO_CategoriaPlato//Menu o Carta
    {
        SqlConnection conexion;
        public DAO_CategoriaPlato()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }

    }
}
