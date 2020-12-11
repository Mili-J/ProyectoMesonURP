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

            gvInsumos1.DataBind();
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
        public void CargarInsumosOC(int oc)
        {
            gvInsumos1.DataSource = _CO.ListarOC2(oc);
            gvInsumos1.DataBind();

        }
        protected void btnBuscar_ServerClick(object sender, EventArgs e)
        {

            try
            {
                if (txtBuscarInsumo.Text != "")
                {
                    gvOC.DataSource = _CO.BuscarOC(Int32.Parse(txtBuscarInsumo.Text));
                    gvOC.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese un numero de OC para la busqueda');", true);

            }
        }

        protected void gvOC_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Descargar")
            {
                int OC = Convert.ToInt32(gvOC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OC_idOC"].ToString());
                CargarInsumosOC(OC);
            }
            if (e.CommandName == "Recepcionar")
            {
                int OC = Convert.ToInt32(gvOC.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["OC_idOC"].ToString());
                Session.Add("OCSeleccionada", OC);
                Response.Redirect("Recepción_Insumos.aspx");
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