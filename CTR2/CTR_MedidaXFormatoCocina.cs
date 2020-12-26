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

        public DataSet ListarIDMedidaXFCocina(DTO_MedidaXFormatoCocina objFCocina)
        {
            return dao_MFCocina.ListarMedidaXFCocina(objFCocina);      
        }

        public DataTable ListarIDMedidaXFCocina2()
        {
            return dao_MFCocina.ListarMedidaXFCocina2();
        }
    }
}
