using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAO;

namespace CTR
{
    public class CTR_MedidaXFormato
    {
        DAO_MedidaXFormato dao_MXF;
        public CTR_MedidaXFormato()
        {
            dao_MXF = new DAO_MedidaXFormato();
        }
        public DataSet SelectFC_GI()
        {
            return dao_MXF.SelectFC_GI();
        }

    }
}
