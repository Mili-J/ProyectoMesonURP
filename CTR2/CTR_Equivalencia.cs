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
        
    }
}
