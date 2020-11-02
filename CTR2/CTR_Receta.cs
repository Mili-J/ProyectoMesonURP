using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class CTR_Receta
    {
        DAO_Receta dao_receta;
        public DataTable CTR_Consultar_Receta()
        {
            dao_receta = new DAO_Receta();
            return dao_receta.DAO_Consultar_Receta();
        }
    }
}
