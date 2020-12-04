using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Home.aspx?x=1");
            }
            if (!IsPostBack)
            {
                DTO_Usuario dto = (DTO_Usuario)Session["Usuario"];
                switch (dto.TU_idTipoUsuario)
                {
                    case 1:
                        //CHARTS DE INSUMOS
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}