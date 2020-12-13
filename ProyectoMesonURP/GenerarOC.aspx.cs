using CTR;
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
        CTR_DetalleCotizacion _Cdc = new CTR_DetalleCotizacion();
        private decimal _Total = 0;
        string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack){

                CargarCotizacion();
                CargargvInsumos();
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
        public void CargargvInsumos()
        {
            gvInsumos.DataSource = _Cdc.CargarDetalleCotizacion(Convert.ToInt32(Session["idcotizacion"]));
            gvInsumos.DataBind();
        }
        protected void gvInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void gvInsumos_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    _Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "lblTotal"));
                }
                else if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[3].Text = "TOTAL:";
                    e.Row.Cells[4].Text = _Total.ToString();
                    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Font.Bold = true;
                }
            }
            catch (Exception err)
            {
                string error = err.Message.ToString() + " - " + err.Source.ToString();
            }
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