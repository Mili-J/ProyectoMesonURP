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
        public CTR_Receta()
        {
            dao_receta = new DAO_Receta();
        }
        public DataTable CTR_Consultar_Receta()
        {
            return dao_receta.DAO_Consultar_Receta();
        }
        public DataTable CTR_Consultar_Recetas_X_Categoria(int categoria)
        {
            return dao_receta.DAO_Consultar_Receta_X_Categoria(categoria);
        }
    }
}
