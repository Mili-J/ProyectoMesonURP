using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class ActualizarEquivalencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LLenarDatosE();
            
           
        }
        public void LLenarDatosE()
        {
            //string[] E = new string[4];
            string i = (string)Session["insumo"];
            string c = (string)Session["cantidad"];
            string m = (string)Session["medida"];
            //txtInsumo.Text = E[0];
            //txtMedida.Text = E[1];
            txtInsumo.Text = i;
            txtCantidad.Text = c;
            txtMedida.Text = m;

        }
        protected void ddlFormatoC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}