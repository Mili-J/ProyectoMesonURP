using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class CTR_Ingrediente
    {
        DAO_Ingrediente objDAO;

        public CTR_Ingrediente()
        {
            objDAO = new DAO_Ingrediente();
        }
        public DataSet CargarIngredientes()
        {
            return objDAO.SelectIngrediente();
        }

        public DataSet ListarFCocina()
        {
            return objDAO.ListarFormatoCocina();
        }
        public string ListarNombreIngrediente(int idIngrediente)
        public DTO_Ingrediente ListarNombreIngrediente(int idIngrediente)
        {
            return objDAO.SelectNombreIngrediente(idIngrediente);
        }
        public int ListarIdIngredientexNombre(string I_nombreIngrediente)
        {
            return objDAO.SelectIdIngredientexNombre(I_nombreIngrediente);
        }
    }
}
