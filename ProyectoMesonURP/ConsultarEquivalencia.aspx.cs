using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;

namespace ProyectoMesonURP
{
    public partial class ConsultarEquivalencia : System.Web.UI.Page
    {
        CTR_Equivalencia _Ce = new CTR_Equivalencia();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            LLenarDatosE();
            LoadIngrediente();
        }
        public void LoadIngrediente()
        {
            txtIngrediente.Text = Convert.ToString(Session["ingrediente"]);
        }
        public void LLenarDatosE()
        {
            dt = _Ce.CTRconsultarDetalleExI((Convert.ToInt32(Session["idIngrediente"])));
            gvEquivalencia.DataSource = dt;
            gvEquivalencia.DataBind();
        }
        protected void gvEquivalencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEquivalencia.PageIndex = e.NewPageIndex;
            LLenarDatosE();
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarEquivalencia");
        }
    }
}