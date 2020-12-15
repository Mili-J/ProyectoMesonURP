using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAO;
namespace CTR
{
    public class CTR_Proveedor
    {
        DAO_Proveedor dao_proveedor;
        public CTR_Proveedor()
        {
            dao_proveedor = new DAO_Proveedor();
        }
        public DataTable CTR_ConsultarProveedores()
        {
            return dao_proveedor.DAO_ConsultarProveedores();
        }
    }
}
