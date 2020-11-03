using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
