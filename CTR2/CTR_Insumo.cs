using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTO;
using DAO;

using DAO;
using DTO;
using System.Data;

namespace CTR
{
    public class CTR_Insumo
    {
        DAO_Insumo dao_insumo;
        public CTR_Insumo()
        {
            dao_insumo = new DAO_Insumo();
        }
        public DataTable ListarInsumo()
        {
            return dao_insumo.ListarInsumo();
        }
        public DataTable ListarInsumo2()
        {
            return dao_insumo.ListarInsumo2();
        }
        public DataTable BuscarInsumo(string nombreInsumo)
        {
            return dao_insumo.BuscarInsumo(nombreInsumo);
        }
        public DataTable CTR_CONSULTAR_EQUIVALENCIA_X_INSUMO(DTO_Insumo dto_insumo)
        {
            return dao_insumo.DAO_Consultar_Equivalencia_x_Insumo(dto_insumo);
        }
    }
}
