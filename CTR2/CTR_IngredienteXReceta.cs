using DAO;
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
        DAO_IngredienteXReceta objDAO;
        public CTR_IngredienteXReceta()
        {
            objDAO = new DAO_IngredienteXReceta();
        }

        public DataTable CTR_CONSULTAR_INSUMO_X_RECETA(DTO_Receta objReceta)
        {
            objDAO = new DAO_IngredienteXReceta();
            return objDAO.DAO_Consultar_Insumo_x_Receta(objReceta);
        }
        public DataTable CTR_CONSULTAR_INSUMO_X_RECETA_T(DTO_Receta objReceta)
        {
            objDAO = new DAO_IngredienteXReceta();
            return objDAO.DAO_Consultar_Insumo_x_Receta_T(objReceta);
        }
        public DTO_IngredienteXReceta CTR_Consultar_IngredienteXReceta(int idReceta, int idIngrediente)
        {
            return objDAO.DAO_Consultar_IngredienteXReceta(idReceta, idIngrediente);
        }

        public DataSet CTR_Consultar_IxR(DTO_Receta objReceta)
        {
            objDAO = new DAO_IngredienteXReceta();
            return objDAO.DAO_Consultar_IxR(objReceta);
        }
        public DataTable CTR_Consultar_Equivalencia_x_Ingrediente(int i, int ing)
        {
            return objDAO.DAO_Consultar_Equivalencia_X_Ingrediente(i,ing);
        }
        public void RegistrarIngredienteXReceta(DTO_IngredienteXReceta objDto)
        {
            objDAO.InsertIngredienteXReceta(objDto);
        }
        public DataTable ListarIngredientesXReceta(int R_idReceta)
        {
            return objDAO.SelectIngredientesXReceta(R_idReceta);
        }
        public void EliminarIngredientexReceta(int R_idReceta, int I_idIngrediente)
        {
            objDAO.DeleteIngredientexReceta(R_idReceta, I_idIngrediente);

        }
        public bool ExistenciaIngredientexReceta(int R_idReceta, int I_idIngrediente)
        {
            return objDAO.SelectExistenciaIngredientexReceta(R_idReceta, I_idIngrediente);
        }
    }
}
