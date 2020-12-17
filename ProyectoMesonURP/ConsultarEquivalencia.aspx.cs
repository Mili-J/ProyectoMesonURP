using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class ConsultarEquivalencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LLenarDatosE();
        }
        public void LLenarDatosE()
        {
            string[] E = new string[4];
            E = (string[])Session["Equivalencia"];
            txtInsumo.Text = E[0];
            txtMedida.Text = E[1];
            txtCantidad.Text = E[2];
            txtFormatoC.Text = E[3];
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarEquivalencia");
        }
    }
}