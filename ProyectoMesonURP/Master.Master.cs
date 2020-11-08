using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DTO;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    DTO_Usuario dto = (DTO_Usuario)Session["Usuario"];
            //    switch (dto.TU_idTipoUsuario)
            //    {
            //        case 1:
            //            menuCotizacion.Visible = true;
            //            menuReceta.Visible = true;
            //            menuProveedor.Visible = true;
            //            menuMovimiento.Visible = true;
            //            menuDashboard.Visible = true;
            //            menuInsumo.Visible = true;
            //            menuInsumosOC.Visible = true;
            //            menuStock.Visible = true;
            //            menuSepararIngredientes.Visible = true;
            //            menuMenuDelDia.Visible = true;

            //            break;
            //        case 2:
            //            menuCotizacion.Visible = false;
            //            menuReceta.Visible = false;
            //            menuProveedor.Visible = false;
            //            menuMovimiento.Visible = false;
            //            menuDashboard.Visible = false;
            //            menuInsumo.Visible = true;
            //            menuInsumosOC.Visible = true;
            //            menuStock.Visible = true;
            //            menuSepararIngredientes.Visible = false;
            //            break;
            //        case 3:
            //            menuCotizacion.Visible = false;
            //            menuReceta.Visible = true;
            //            menuProveedor.Visible = false;
            //            menuMovimiento.Visible = false;
            //            menuDashboard.Visible = false;
            //            menuInsumo.Visible = false;
            //            menuInsumosOC.Visible = false;
            //            menuStock.Visible = false;
            //            menuSepararIngredientes.Visible = true;
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }
    }
}


