using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAO;
using System.Data;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_CategoriaInsumo
    {
        DAO_CategoriaInsumo dao_catIns;
        public CTR_CategoriaInsumo()
        {
            dao_catIns = new DAO_CategoriaInsumo();
        }
        public DataTable DAO_ConsultarCategoriasInsumo()
        {
            return dao_catIns.DAO_ConsultarCategoriasInsumo();
        }
    public class CTR_CategoriaInsumo
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

        public DataSet CTR_SelectInsumoXCategoria(DTO_CategoriaInsumo objCategoriaIn)
        {
            return objCategoriaI.DAO_SelectInsumoXCategoria(objCategoriaIn);
        }

    }
}
