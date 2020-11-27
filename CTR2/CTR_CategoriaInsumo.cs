using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAO;

namespace CTR
{
    class CTR_CategoriaInsumo
    {
        DAO_CategoriaInsumo objCategoriaI;

        public CTR_CategoriaInsumo()
        {
            objCategoriaI = new DAO_CategoriaInsumo();
        }
        public DataSet CTR_SelectCategoriaI()
        {
            return objCategoriaI.DAO_SelectCategoriaI();
        }
            
    }
}
