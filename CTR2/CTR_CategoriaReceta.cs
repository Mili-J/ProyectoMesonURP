using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;
using DTO;

namespace CTR
{
    
    public class CTR_CategoriaReceta
    {
        DAO_CategoriaReceta dao_categoriareceta;
        public CTR_CategoriaReceta()
        {
            dao_categoriareceta = new DAO_CategoriaReceta();
        }
        public DTO_CategoriaReceta CTR_Consultar_CategoriaXReceta(int i)
        {
            return dao_categoriareceta.DAO_Consultar_CategoriaXReceta(i);
        }
        public DataSet CargarCategoriaReceta()
        {
            return dao_categoriareceta.SelectCategoriaReceta();
        }
        public int CargarCategoriaRecetaxNombre(string CR_nombreCategoria)
        {
            return dao_categoriareceta.SelectCategoriaRecetaxNombre(CR_nombreCategoria);
        }
    }
}
