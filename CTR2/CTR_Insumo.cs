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

        public DataTable CTR_CONSULTAR_EQUIVALENCIA_X_INSUMO(DTO_Insumo dto_insumo)
        {
            return dao_insumo.DAO_Consultar_Equivalencia_x_Insumo(dto_insumo);
        }
    }
}
