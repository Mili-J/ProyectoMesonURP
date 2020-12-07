using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class DAO_EstadoMenu
    {
        SqlConnection conexion;
        public DAO_EstadoMenu()
        {
            conexion = new SqlConnection(ConexionDB.CadenaConexion);
        }
    }
}
