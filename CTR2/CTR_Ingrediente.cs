using DAO;
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
        public string ListarNombreIngrediente(int idIngrediente)
        {
            return objDAO.SelectNombreIngrediente(idIngrediente);
        }
    }
}
