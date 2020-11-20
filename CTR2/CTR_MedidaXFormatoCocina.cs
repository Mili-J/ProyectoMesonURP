using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public int CTR_Consultar_Medida_x_FCocina(DTO_MedidaXFormatoCocina objMFCocina)
        {
            return dao_MFCocina.DAO_Consultar_Medida_x_FCocina(objMFCocina);      
        }
    }
}
