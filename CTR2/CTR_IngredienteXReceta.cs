using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTO;
using DAO;

namespace CTR
{
    public class CTR_IngredienteXReceta
    {
        DAO_IngredienteXReceta dao_ing_x_receta;
        public CTR_IngredienteXReceta()
        {
            dao_ing_x_receta = new DAO_IngredienteXReceta();
        }

        public DataTable CTR_CONSULTAR_INSUMO_X_RECETA(DTO_Receta objReceta)
        {
            dao_ing_x_receta = new DAO_IngredienteXReceta();
            return dao_ing_x_receta.DAO_Consultar_Insumo_x_Receta(objReceta);
        }
        public DTO_IngredienteXReceta CTR_Consultar_IngredienteXReceta(int idReceta, int idIngrediente)
        {
            return dao_ing_x_receta.DAO_Consultar_IngredienteXReceta(idReceta, idIngrediente);
        }
    }
}
