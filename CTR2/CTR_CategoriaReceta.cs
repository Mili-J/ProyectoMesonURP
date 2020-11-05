using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CTR
{
    public class CTR_CategoriaReceta
    {
        DAO_CategoriaReceta objDAO;

        public CTR_CategoriaReceta()
        {
            objDAO = new DAO_CategoriaReceta();
        }
        public DataSet CargarCategoriaReceta()
        {
            return objDAO.SelectCategoriaReceta();
        }
    }
}
