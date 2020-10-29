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
                return "data source=DESKTOP-GJ83E50\\MSSQLSERVER01; initial catalog=BD_MesonURP; integrated security=SSPI;";
            }
        }
    }
}
