using DAO;
using DTO;

using System.Data;


namespace CTR
{
    public class CTR_Receta
    {
        DAO_Receta objDAO;

        public CTR_Receta()
        {
            objDAO = new DAO_Receta();
        }
        public void RegistrarReceta(DTO_Receta objDto)
        {
            objDAO.InsertReceta(objDto);
        }
        public DataTable CargarRecetaxNombre(string @nombreReceta)
        {
            return objDAO.SelectRecetaxNombre(@nombreReceta);
        }
        public int IdReceta()
        {
            return objDAO.SelectIdReceta();
        }
        public void ActualizarReceta(DTO_Receta objDTO)
        {
            objDAO.UpdateReceta(objDTO);
        }
    }
}
