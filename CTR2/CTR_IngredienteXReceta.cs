using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class CTR_IngredienteXReceta
    {
        DAO_IngredienteXReceta objDAO;

        public CTR_IngredienteXReceta()
        {
            objDAO = new DAO_IngredienteXReceta();
        }
        public void RegistrarIngredienteXReceta(DTO_IngredienteXReceta objDto)
        {
            objDAO.InsertIngredienteXReceta(objDto);
        }
        public DataTable ListarIngredientesXReceta(int R_idReceta)
        {
            return objDAO.SelectIngredientesXReceta(R_idReceta);
        }
    }
}
