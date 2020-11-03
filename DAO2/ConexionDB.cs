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
                return "Data Source = CARLOS; initial catalog=BD_MesonURP; integrated security=true;"; 
            }
        }
    }
}
