using CTR;
using DTO;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Globalization;
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
        string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarOc();
                CargargvInsumos();
                txtFechaEmision.Text = FechaActual;
                txtFechaEntrega.Text = FechaActual;
               
            }
            rvDateValidator.MinimumValue = DateTime.Now.Date.ToString("dd-MM-yyyy");
            rvDateValidator.MaximumValue = DateTime.Now.Date.AddYears(90).ToString("dd-MM-yyyy");
        }
        public void CargarOc()
        {
            int idCot = (int)Session["idCot"];
            _Doc = _Coc.Consultar_OC(idCot);
            txtNdeCompra.Text = _Doc.OC_numeroOc;
            txtProveedor.Text = Convert.ToString(Session["proveedor"]);
            txtFechaEmision.Text = Convert.ToString(_Doc.OC_fechaEmision);
            txtFechaEntrega.Text = Convert.ToString(_Doc.OC_fechaEntrega);
            txtFormaPago.Text = Convert.ToString(_Doc.OC_tipoPago);
        }
        public void CargargvInsumos()
        {
            gvInsumos.DataSource = _Cdoc.CargarDetalleOC(Convert.ToInt32(Session["idcotizacion"])); //CREAR OTRO PROCEDIMIENTO
            gvInsumos.DataBind();

            decimal sum = decimal.Zero;
            for (int i = 0; i < gvInsumos.Rows.Count; i++)
            {
                sum += decimal.Parse(((Label)gvInsumos.Rows[i].FindControl("lblTotalPrecio")).Text == string.Empty ? "0" : ((Label)gvInsumos.Rows[i].FindControl("lblTotalPrecio")).Text, CultureInfo.InvariantCulture);
            }
                   ((Label)gvInsumos.FooterRow.FindControl("lblTotal")).Text = sum.ToString();
            Session["Totaldecompra"] = ((Label)gvInsumos.FooterRow.FindControl("lblTotal")).Text;
        }
        public void CorreoOC()
        {
            _Doc.OC_numeroOc = txtNdeCompra.Text;
            string proveedor = txtProveedor.Text;
            _Doc.OC_fechaEmision = Convert.ToDateTime(txtFechaEmision.Text);
            _Doc.OC_fechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
            _Doc.OC_tipoPago = txtFormaPago.Text;
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
                    CorreoOC();
                    ClientScript.RegisterStartupScript(Page.GetType(), "alertIns", "alertaExito('');", true);
        }
    }
}