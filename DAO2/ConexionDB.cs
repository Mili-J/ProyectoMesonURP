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
                 return "Data Source = (Local); initial catalog=DB_MesonURP; integrated security=true;";
              // FIORELA 
                //return "Data Source =DESKTOP-GJ83E50\\MSSQLSERVER01; Initial Catalog = BD_MesonURP; Integrated Security = True";

            }
        }
    }
}
