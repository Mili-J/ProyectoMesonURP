using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class GenerarOC : System.Web.UI.Page
    {
        string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack){

                CargarCotizacion();
            }
            txtFechaEmision.Text = FechaActual;
        }
        public void CargarCotizacion() {
            txtNdeCompra.Text = Convert.ToString(Session["nCompra"]);
            txtNdeCompra.Enabled = false;
            txtProveedor.Text = Convert.ToString(Session["proveedor"]);
            txtProveedor.Enabled = false;
            txtFechaEmision.Enabled = false;
        }
        protected void gvInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void gvInsumos_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
        }
        protected void btnEnviar_ServerClick(object sender, EventArgs e)
        { 
        }
        protected void btnRegresar_ServerClick(object sender, EventArgs e)
        {
        }
        protected void btnLimpiar_ServerClick(object sender, EventArgs e)
        { 
        }
    }
}