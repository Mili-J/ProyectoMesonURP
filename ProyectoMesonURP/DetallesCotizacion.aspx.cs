using CTR;
using DTO;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class DetallesCotizacion : System.Web.UI.Page
    {
            DTO_DetalleOC _Ddc = new DTO_DetalleOC();
            CTR_DetalleOC _Cdoc = new CTR_DetalleOC();
            CTR_DetalleCotizacion _Cdc = new CTR_DetalleCotizacion();
            DTO_OC _Doc = new DTO_OC();
            CTR_OC _Coc = new CTR_OC();
            DTO_Cotizacion dto_cot;
            CTR_Cotizacion ctr_cot;
            CTR_Proveedor ctr_pro;
            DTO_Proveedor dto_pro;
            //private decimal _Total = 0;
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
            int idCot = (int)Session["idCot"];
            ctr_cot = new CTR_Cotizacion();
            dto_cot = ctr_cot.CTR_ConsultarCotizacion(idCot);
            //--------
            txtNCotizacion.Text = dto_cot.C_numeroCotizacion;
            txtFechaEmision.Text = dto_cot.C_fechaEmision.ToShortDateString();
            txtTiempoPlazo.Text = dto_cot.C_tiempoPlazo;
            //txtDoc.Text = dto_cot.C_documento;
            //--------Proveedor
            ctr_pro = new CTR_Proveedor();
            dto_pro = ctr_pro.CTR_ConsultarProveedor(dto_cot.PR_idProveedor);
            txtProveedor.Text = dto_pro.PR_razonSocial;
            string nOC = _Coc.ListarNumeroOC();
            txtProveedor.Text = Convert.ToString(Session["proveedor"]);
            }
            public void CargargvInsumos()
            {
                gvInsumos.DataSource = _Cdc.CargarDetalleCotizacion(Convert.ToInt32(Session["idcotizacion"]));
                gvInsumos.DataBind();
            }
            public void CorreoOC()
            {
                _Doc.OC_numeroOc = txtNCotizacion.Text;
                string proveedor = txtProveedor.Text;
                _Doc.OC_fechaEmision = Convert.ToDateTime(txtFechaEmision.Text);
                _Doc.OC_fechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
                _Doc.OC_tipoPago = ddlFormaPago.SelectedValue;
                int idCotizacion = Convert.ToInt32(Session["idcotizacion"]);

                string htmlBody = Resource.MensajeOC;
                htmlBody = htmlBody.Replace("#IDOC#", _Doc.OC_numeroOc.ToString());
                htmlBody = htmlBody.Replace("#TIPODEPAGO#", _Doc.OC_tipoPago);
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
                if (ddlFormaPago.SelectedIndex != 0)
                {
                    _Doc.OC_numeroOc = _Coc.ListarNumeroOC();
                    _Doc.OC_fechaEmision = Convert.ToDateTime(txtFechaEmision.Text);
                    _Doc.OC_fechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
                    _Doc.OC_tipoPago = ddlFormaPago.SelectedValue;
                    _Doc.OC_totalCompra = Convert.ToDecimal(Session["Totaldecompra"]);
                    _Doc.EOC_idEstadoOC = 1;
                    _Doc.U_idUsuario = Convert.ToInt32(Session["idUsuario"]);

                    _Coc.RegistrarOC(_Doc);

                    for (int i = 0; i < gvInsumos.Rows.Count; i++)
                    {
                        _Ddc.DOC_totalPrecio = Convert.ToDecimal(((Label)gvInsumos.Rows[i].FindControl("lblPrecioTotal")).Text);
                        _Ddc.DOC_precioUnitario = Convert.ToDecimal(((TextBox)gvInsumos.Rows[i].FindControl("txtPrecioUnitario")).Text);
                        _Ddc.OC_idOC = _Coc.IdOC();
                        int idCotizacion = Convert.ToInt32(Session["idcotizacion"]);
                        string nombre = Convert.ToString(gvInsumos.Rows[i].Cells[0].Text);

                        _Ddc.DC_idDetalleCotizacion = _Cdc.IdDetalleCotizacion(idCotizacion, nombre);
                        _Cdoc.RegistrarDetalleOC(_Ddc);
                    }
                    CorreoOC();
                    ClientScript.RegisterStartupScript(Page.GetType(), "alertIns", "alertaExito('');", true);
                }
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
