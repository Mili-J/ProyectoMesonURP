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

        public void InsertarIngrediente(DTO_Ingrediente objIngrediente)
        {
            //if(objIngrediente.I_cantidad==0 || objIngrediente.I_cantidad<0) 
            objDAO.DAO_Registrar_Ingrediente(objIngrediente);
        }
        public DataSet CargarIngredientes()
        {
            return objDAO.SelectIngrediente();
        }

        public DataSet ListarFCocina()
        {
            return objDAO.ListarFormatoCocina();
        }
       
        public DTO_Ingrediente ListarNombreIngrediente(int idIngrediente)
        {
            return objDAO.SelectNombreIngrediente(idIngrediente);
        }
        public int ListarIdIngredientexNombre(string I_nombreIngrediente)
        {
            return objDAO.SelectIdIngredientexNombre(I_nombreIngrediente);
        }
        public DTO_Ingrediente CTR_Consultar_IngredienteXID(int i)
        {
            return objDAO.DAO_Consultar_IngredienteXID(i);
        }

        public DataTable ListarIngredientes()
        {
            return objDAO.ListarIngredientes();
        }
        //public DataSet CargarMedidaxIdIngrediente(int I_idIngrediente)
        //{
        //    return objDAO.SelectMedidaxIdIngrediente(I_idIngrediente);
        //}
        public void ActualizarIngrediente(DTO_Ingrediente ObjIngre)
        {
            objDAO.ActualizarIngrediente(ObjIngre);
        }
        //public DTO_Ingrediente CTR_Consultar_IngredienteXID(int i)
        //{
        //    return objDAO.DAO_Consultar_IngredienteXID(i);
        //}
        public DataTable Validar_IngredientesXReceta()
        {
            return objDAO.Validar_IngredientesXReceta();
        }
        public DataSet CargarMedidaxIdIngrediente(int I_idIngrediente)
        {
            return objDAO.SelectMedidaxIdIngrediente(I_idIngrediente);
        }
        public DataTable CTR_Consultar_Ingrediente(string nombreIngrediente)
        {
            return objDAO.DAO_Consultar_Ingrediente(nombreIngrediente);
        }
    }
}
