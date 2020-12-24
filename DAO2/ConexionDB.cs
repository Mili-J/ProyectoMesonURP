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
                //MILAGROS
                //return "Data Source=DESKTOP-928V5LN\\SQLEXPRESS; Initial Catalog = BD_MesonURP; Integrated Security = True";
                //FIORELLA
                // return "Data Source=DESKTOP-GJ83E50\\MSSQLSERVER01; Initial Catalog = BD_MesonURP; Integrated Security = True";
                //KATYA
                return "Data Source=(Local); Initial Catalog = BD_MesonURP; Integrated Security = True";




            }
        }
    }
}
