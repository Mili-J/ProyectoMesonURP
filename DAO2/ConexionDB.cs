﻿using System;
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
                return "Data Source =(local); Initial Catalog = BD_MesonURP; Integrated Security = True";

            }
        }
    }
}
