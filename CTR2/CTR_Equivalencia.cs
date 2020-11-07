using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAO;

namespace CTR
{
    public class CTR_Equivalencia
    {
       
        DAO_Equivalencia dao_eq;
        public CTR_Equivalencia()
        {
            dao_eq = new DAO_Equivalencia();
        }

        public bool CTR_Consulta_Equivalencia_x_Insumo(DTO_MedidaXFormatoCocina objMFCocina, int idInsumo)
        {
            return dao_eq.DAO_Consultar_Equivalencia_x_Insumo(objMFCocina,idInsumo);
        }
    }
}
