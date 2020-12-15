﻿using CTR;
using DTO;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class GenerarOC : System.Web.UI.Page
    {
        CTR_DetalleCotizacion _Cdc = new CTR_DetalleCotizacion();
        DTO_OC _Doc = new DTO_OC();
        CTR_OC _Coc = new CTR_OC();

        private decimal _Total = 0;
        string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                CargarCotizacion();
                CargargvInsumos();
            }
            txtFechaEmision.Text = FechaActual;
        }
        public void CargarCotizacion()
        {
            txtNdeCompra.Text = Convert.ToString(Session["nCompra"]);
            //txtNdeCompra.Enabled = false;
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
        public void CorreoOC()
        {
            _Doc.OC_numeroOc = Convert.ToInt32(txtNdeCompra.Text);
            string proveedor = txtProveedor.Text;
            _Doc.OC_fechaEmision = Convert.ToDateTime(txtFechaEmision.Text);
            _Doc.OC_fechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
            _Doc.OC_tipoPago = ddlComprobante.SelectedValue;
            string comprobante = ddlComprobante.SelectedValue;
            int idCotizacion = Convert.ToInt32(Session["idcotizacion"]);



            string htmlBody = Resource.MensajeOC;
            htmlBody = htmlBody.Replace("#IDOC#", _Doc.OC_numeroOc.ToString());
            htmlBody = htmlBody.Replace("#FORMADEPAGO#", comprobante);
            htmlBody = htmlBody.Replace("#TIPOCOMPROBANTE#", _Doc.OC_tipoPago);
            htmlBody = htmlBody.Replace("#PROVEEDOR#", proveedor);
            htmlBody = htmlBody.Replace("#FECHAEMISION#", _Doc.OC_fechaEmision.ToString());
            htmlBody = htmlBody.Replace("#FECHAENTREGA#", _Doc.OC_fechaEntrega.ToString());
            htmlBody = htmlBody.Replace("#GRID#", gridviewHTML());

            _Coc.EnviarOC(_Doc, idCotizacion, htmlBody);
        }
        public string gridviewHTML()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    gvInsumos.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());

                    return sw.ToString();
                }
            }

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnEnviar_ServerClick(object sender, EventArgs e)
        {
            CorreoOC();
            //ClientScript.RegisterStartupScript(Page.GetType(), "alertIns", "alertaCorreo('');", true);
        }
        protected void btnRegresar_ServerClick(object sender, EventArgs e)
        {
        }
        protected void btnLimpiar_ServerClick(object sender, EventArgs e)
        {
        }

        protected void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                int index = ((GridViewRow)txt.NamingContainer).RowIndex;
                string cantidad = txt.Text;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}