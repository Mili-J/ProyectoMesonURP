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
        public DataTable CTR_Consultar_Recetas()
        {
            return objDAO.DAO_Consultar_Recetas();
        }
        public DataTable CTR_Consultar_Recetas_X_Categoria(int categoria)
        {
            return objDAO.DAO_Consultar_Recetas_X_Categoria(categoria);
        }
        public DataTable CTR__Consultar_Recetas_Disponibles(int racion, int caso)
        {
            return objDAO.DAO_Consultar_Recetas_Disponibles(racion, caso);
        }
        public DTO_Receta CTR_Consultar_Receta(int i)
        {
            return objDAO.DAO_Consultar_Receta(i);
        }
        public DataTable CTR_Consultar_Receta2()
        {
            objDAO = new DAO_Receta();
            return objDAO.DAO_ConsultarReceta2();
        }
        public DataTable CTR_Consultar_RecetaT()
        {
            objDAO = new DAO_Receta();
            return objDAO.DAO_ConsultarRecetaT();
        }
        public DataTable CTR_Consultar_Recetas_X_Categoria_Seleccionada(int caso)
        {
            return objDAO.DAO_Consultar_Recetas_X_Categoria_Seleccionada(caso);
        }
        public byte[] Consultar_ImagenReceta(int R_idReceta)
        {
            return objDAO.Select_ImagenReceta(R_idReceta);
        }
        public int IdReceta()
        {
            return objDAO.SelectIdReceta();
        }
        public void ActualizarReceta(DTO_Receta objDTO)
        {
            objDAO.UpdateReceta(objDTO);
        }
        public void EliminarReceta(int R_idReceta)
        {
            objDAO.DeleteReceta(R_idReceta);
        }
        public bool ExistenciaImagen(int R_idReceta)
        {
            return objDAO.SelectExistenciaImagen(R_idReceta);
        }
        public string CargarSubcategoriaxIdReceta(int R_idReceta)
        {
            return objDAO.SelectSubcategoriaxIdReceta(R_idReceta);
        }
    }
}
