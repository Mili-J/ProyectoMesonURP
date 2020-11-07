using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTO;
using DAO;

namespace CTR
{
    public class CTR_Insumo
    {
        DAO_Insumo dao_insumo;

        public CTR_Insumo()
        {
            dao_insumo = new DAO_Insumo();
        }

        public DataTable CTR_CONSULTAR_EQUIVALENCIA_X_INSUMO(DTO_Insumo dto_insumo)
        {
            return dao_insumo.DAO_Consultar_Equivalencia_x_Insumo(dto_insumo);
        }
        public DTO_Medida CTR_Consultar_Medida_x_Insumo(DTO_Insumo objInsumo )
        {
            return dao_insumo.DAO_Consultar_Medida_x_Insumo(objInsumo);    
        }
    }
}
