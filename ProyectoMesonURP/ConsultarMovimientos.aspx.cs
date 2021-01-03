using CTR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class ConsultarMovimientos : System.Web.UI.Page
    {
        CTR_Movimiento _Cmo = new CTR_Movimiento();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarMovimientos();
                btnQuitar.Visible = false;
            }
        }
        public void CargarMovimientos() {

            gvMovimientos.DataSource = _Cmo.ListarMovimiento(txtFechaInicial.Text, txtFechaFinal.Text);
            gvMovimientos.DataBind();
         }
      
        protected void btnFiltrar_ServerClick(object sender, EventArgs e)
        {
            CargarMovimientos();
            btnQuitar.Visible = true;
            btnFiltrar.Visible = false;
        }
        protected void btnQuitarFiltro_ServerClick(object sender, EventArgs e)
        {
            txtFechaInicial.Text = "";
            txtFechaFinal.Text = "";
            CargarMovimientos();
            btnQuitar.Visible = false;
            btnFiltrar.Visible = true;
        }
        protected void btnDescargarExcel_ServerClick(object sender, EventArgs e)
        {
            //try
            //{
                ExportarGridViewExcel(gvMovimientos);
            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese otro dato para la busqueda');", true);

            //}
        }
        public void ExportarGridViewExcel(GridView grd)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page page = new Page();
            HtmlForm form = new HtmlForm();

            gvMovimientos.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(gvMovimientos);

            page.RenderControl(htw);

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=MesonURP_ConsultarMovimientos.xls");
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write("Movimientos del Meson URP" + "\n" + sb.ToString());
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
    }
}