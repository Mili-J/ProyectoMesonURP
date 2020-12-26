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
        //public void AgregarEquivalencia(DTO_Equivalencia DTOEquival)
        //{
        //    objEquivalencia.AgregarEquivalencia(DTOEquival);
        //}
        //public void ActualizarEquivalencia(DTO_Equivalencia DTOEquivalencia)
        //{
        //    objEquivalencia.ActualizarEquivalencia(DTOEquivalencia);
        //}
    }
}
