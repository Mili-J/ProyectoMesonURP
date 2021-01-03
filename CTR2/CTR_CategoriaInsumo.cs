using System;
using System.Collections.Generic;
using System.Text;
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
        //public DataTable DAO_ConsultarCategoriasInsumo()
        //{
        //    return dao_catIns.DAO_ConsultarCategoriasInsumo();
        //}
        public List<DTO_CategoriaInsumo> ListarCategorias()
        {
            return dao_catIns.ListarCategoria();
        }

        public DataSet CTR_SelectInsumoXCategoria(DTO_CategoriaInsumo objCategoriaIn)
        {
            return dao_catIns.DAO_SelectInsumoXCategoria(objCategoriaIn);
        }

        public DataTable DAO_ConsultarCategoriasInsumo()
        {
            return dao_catIns.DAO_ConsultarCategoriasInsumo();
        }
        public DataSet CTR_SelectCategoriaI()
        {
            return dao_catIns.DAO_SelectCategoriaI();
        }
        public List<DTO_CategoriaInsumo> CTR_ConsultarCategoriasInsumo2()
        {
            return dao_catIns.DAO_ConsultarCategoriasInsumo2();
        }
        public void DAO_InsertCategoriaInsumo(DTO_CategoriaInsumo objCategoriaIn)
        {
            dao_catIns.DAO_InsertCategoriaInsumo(objCategoriaIn);
        }
        public void DAO_UpdateCategoriaInsumo(DTO_CategoriaInsumo objCategoriaIn)
        {
            dao_catIns.DAO_ActualizarCategoriaInsumo(objCategoriaIn);
        }
        public DataSet SelectCategoria_GI ()
        {
            return dao_catIns.SelectCategoria_GI();
        }
    }
}
