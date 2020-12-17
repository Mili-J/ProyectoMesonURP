using CTR;
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
        DTO_DetalleOC _Ddc = new DTO_DetalleOC();
        CTR_DetalleOC _Cdoc = new CTR_DetalleOC();
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
            txtFechaEntrega.Text = FechaActual;
        }
        public void CargarCotizacion()
        {
            txtNdeCompra.Text = _Coc.ListarNumeroOC();
            //txtNdeCompra.Enabled = false;
            txtProveedor.Text = Convert.ToString(Session["proveedor"]);
            //txtProveedor.Enabled = false;
            //txtFechaEmision.Enabled = false;
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
        }
        public void CorreoOC()
        {
            _Doc.OC_numeroOc = txtNdeCompra.Text;
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
            if (ddlComprobante.SelectedIndex != 0)
            {
                _Doc.OC_numeroOc = txtNdeCompra.Text;
                _Doc.OC_fechaEmision = Convert.ToDateTime(txtFechaEmision.Text);
                _Doc.OC_fechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
                _Doc.OC_tipoPago = ddlComprobante.SelectedValue;
                _Doc.OC_totalCompra = Convert.ToDecimal(Session["Totaldecompra"]);
                _Doc.EOC_idEstadoOC = 1;
                _Doc.U_idUsuario = Convert.ToInt32(Session["idUsuario"]);
                _Coc.RegistrarOC(_Doc);

                foreach (GridViewRow GVRow in gvInsumos.Rows)
                {
                    _Ddc.DOC_precioUnitario = Convert.ToDecimal(GVRow.Cells[3].Text);
                    _Ddc.DOC_totalPrecio = Convert.ToDecimal(GVRow.Cells[4].Text);
                    _Ddc.OC_idOC = _Coc.IdOC();
                    _Ddc.DC_idDetalleCotizacion = _Cdc.IdDetalleCotizacion(Convert.ToInt32(Session["idcotizacion"]));

                    _Cdoc.RegistrarDetalleOC(_Ddc);
                }

                CorreoOC();
            }

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
                string precioCosto = txt.Text;
                if (!decimal.TryParse(precioCosto, out decimal result))
                {
                 //mensaje de que no es entero    
                }
                string cantidad = ((Label)gvInsumos.Rows[index].FindControl("lblCantidad")).Text;
                decimal subtotal = decimal.Parse(precioCosto) * decimal.Parse(cantidad);
                ((Label)gvInsumos.Rows[index].FindControl("lblPrecioTotal")).Text = subtotal.ToString();
                decimal sum = decimal.Zero;
                for (int i = 0; i < gvInsumos.Rows.Count; i++)
                {
                    sum += decimal.Parse(((Label)gvInsumos.Rows[i].FindControl("lblPrecioTotal")).Text == string.Empty ? "0" : ((Label)gvInsumos.Rows[i].FindControl("lblPrecioTotal")).Text);
                }
               ((Label)gvInsumos.FooterRow.FindControl("lblTotal")).Text = sum.ToString();
                Session["Totaldecompra"] = ((Label)gvInsumos.FooterRow.FindControl("lblTotal")).Text;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}