using System;
using System.Collections.Generic;
using System.Text;

using DAO;
using System.Data;

namespace CTR
{
    public class CTR_OC
    {
        DAO_OC dao_oc;
        public CTR_OC()
        {
            dao_oc = new DAO_OC();
        }
        public DataTable ListarOC()
        {
            return dao_oc.ListarOC();
        }
        public DataTable BuscarOC(string numeroOC)
        {
            return dao_oc.BuscarOC(numeroOC);
        }
    }
}
