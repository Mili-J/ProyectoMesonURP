using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    public class ConexionDB
    {
        public static string CadenaConexion
        {
            get
            {
                return "data source=DESKTOP-928V5LN\\MSSQLSERVER01; initial catalog=BD_MesonURP; integrated security=SSPI;";
            }
        }
    }
}
