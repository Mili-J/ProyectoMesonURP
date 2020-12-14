using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class DAO_EstadoPlato
    {
        SqlConnection conexion;
        public DAO_EstadoPlato()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
    }
}
