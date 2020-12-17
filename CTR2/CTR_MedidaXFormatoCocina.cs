using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_MedidaXFormatoCocina
    {
        DAO_MedidaXFormatoCocina dao_MFCocina;

        public CTR_MedidaXFormatoCocina()
        {
            dao_MFCocina = new DAO_MedidaXFormatoCocina();
        }

        public DataTable ListarIDMedidaXFCocina()
        {
            return dao_MFCocina.ListarMedidaXFCocina();      
        }
    }
}
