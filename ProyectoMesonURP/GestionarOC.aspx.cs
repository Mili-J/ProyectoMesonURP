using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DTO;
using CTR;
using System.Data;

namespace ProyectoMesonURP
{
    public partial class GestionarOC : System.Web.UI.Page
    {
        CTR_OC _CO = new CTR_OC();
        DTO_OC dto_o;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login?x=1");
            }
            if (!Page.IsPostBack)
            {
                dto_o = new DTO_OC();
                CargarOC();
            }

        }
        public void CargarOC()
        {
            gvOC.DataSource = _CO.ListarOC();
            gvOC.DataBind();

        }

        protected void btnBuscar_ServerClick(object sender, EventArgs e)
        {

            try
            {
                if (txtBuscarInsumo.Text != "")
                {
                    gvOC.DataSource = _CO.BuscarOC(txtBuscarInsumo.Text);
                    gvOC.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese un numero de OC para la busqueda');", true);

            }
        }
        protected void gvOC_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOC.PageIndex = e.NewPageIndex;
            CargarOC();
        }
        protected void gvOC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}