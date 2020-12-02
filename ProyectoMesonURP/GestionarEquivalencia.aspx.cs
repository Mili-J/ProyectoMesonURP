using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class GestionarEquivalencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAnadirEquivalencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEquivalencia.aspx");
        }

        protected void btnEditarEquivalencia_Click(object sender, EventArgs e)
        {

        }
    }
}