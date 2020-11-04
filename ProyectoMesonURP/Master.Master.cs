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
            if (!IsPostBack)
            {
                DTO_Usuario dto = (DTO_Usuario)Session["Usuario"];
                switch (dto.TU_idTipoUsuario)
                {
                    case 1:
                        //PONER INVISIBLE ADMINISTAR
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