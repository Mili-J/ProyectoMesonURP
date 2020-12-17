using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;

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
        public DataTable CTR_ConsultarCotizacionXMenuXCotizacion(int id)
        {
            return dao_cotizacionxmenu.DAO_ConsultarCotizacionXMenuXCotizacion(id);
        }
    }
}
