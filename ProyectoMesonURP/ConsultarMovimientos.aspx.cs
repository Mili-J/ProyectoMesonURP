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

            int tipo = Convert.ToInt32(ddlTipoMovimiento.SelectedValue);
            gvMovimientos.DataSource = _Cmo.ListarMovimiento(txtFechaInicial.Text, txtFechaFinal.Text,tipo);
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
            int tipo = Convert.ToInt32(ddlTipoMovimiento.SelectedValue);
            _Cmo.ExportarExcelMovimientos(txtFechaInicial.Text, txtFechaFinal.Text, tipo);
            ClientScript.RegisterStartupScript(Page.GetType(), "alertIns", "alertaExcel('');", true);
        }
    }
}