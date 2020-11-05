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
        public DataTable CTR_Consultar_Recetas()
        {
            return dao_receta.DAO_Consultar_Recetas();
        }
        public DataTable CTR_Consultar_Recetas_X_Categoria(int categoria)
        {
            return dao_receta.DAO_Consultar_Recetas_X_Categoria(categoria);
        }
        public DataTable CTR__Consultar_Recetas_Disponibles(int racion,int caso)
        {
            return dao_receta.DAO_Consultar_Recetas_Disponibles(racion,caso);
        }
        public DTO_Receta CTR_Consultar_Receta(int i)
        {
            return dao_receta.DAO_Consultar_Receta(i);
        }
        public DataTable CTR_Consultar_Recetas_X_Categoria_Seleccionada(int caso)
        {
            return dao_receta.DAO_Consultar_Recetas_X_Categoria_Seleccionada(caso);
        }
    }
}
