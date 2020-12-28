using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTO;
using DAO;

namespace CTR
{
    public class CTR_Equivalencia
    {
       
        DAO_Equivalencia objEquivalencia;
        public CTR_Equivalencia()
        {
            objEquivalencia = new DAO_Equivalencia();
        }
        public DataTable ListaEquivalencias()
        {
            return objEquivalencia.ListarEquivalencias();
        }
        public void AgregarEquivalencia(DTO_Equivalencia DTOEquival)
        {
            objEquivalencia.AgregarEquivalencia(DTOEquival);
        }
        public DataTable CTRListarEquivalencia(int I_idIngrediente)
        {
            return objEquivalencia.DAOSelectEquivalencia(I_idIngrediente);
        }
        //public void ActualizarEquivalencia(DTO_Equivalencia DTOEquivalencia)
        //{
        //    objEquivalencia.ActualizarEquivalencia(DTOEquivalencia);
        //}
        public bool CTRExistenciaIngredientexMxfc(int I_idIngrediente, int MXFC_idMedidaFCocina)
        {
            return objEquivalencia.SelectExistenciaIngredientexMxfc(I_idIngrediente, MXFC_idMedidaFCocina);
        }
    }
}
