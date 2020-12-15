using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CTR_CotizacionXMenu
    {
        DAO_CotizacionXMenu dao_cotizacionxmenu;
        public CTR_CotizacionXMenu()
        {
            dao_cotizacionxmenu = new DAO_CotizacionXMenu();
        }
        public void CTR_RegistrarCotizacionXMenu(DTO_CotizacionXMenu cotXmen)
        {
            dao_cotizacionxmenu.DAO_RegistrarCotizacionXMenu(cotXmen);
        }
    }
}
