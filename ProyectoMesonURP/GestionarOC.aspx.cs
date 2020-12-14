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
            //if (Session["Usuario"] == null)
            //{
            //    Response.Redirect("Login?x=1");
            //}
            if (!Page.IsPostBack)
            {
                dto_o = new DTO_OC();
                CargarOC();

                ListItem ddl1 = new ListItem("5", "5");
                ddlp.Items.Insert(0, ddl1);
                ListItem ddl2 = new ListItem("10", "10");
                ddlp.Items.Insert(1, ddl2);
                ListItem ddl3 = new ListItem("20", "20");
                ddlp.Items.Insert(2, ddl3);
            }

        }
        public void CargarOC()
        {
            gvOC.DataSource = _CO.ListarOC(txtBuscarOC.Text);
            gvOC.DataBind();

        }
        public void CargarInsumosOC(int oc)
        {
            gvInsumos1.DataSource = _CO.ListarOC2(oc);
            gvInsumos1.DataBind();

        }
        protected void fidOC_TextChanged(object sender, EventArgs e)
        {
            CargarOC();
        }

        //protected void btnBuscar_ServerClick(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        if (txtBuscarInsumo.Text != "")
        //        {
        //            gvOC.DataSource = _CO.BuscarOC(Int32.Parse(txtBuscarInsumo.Text));
        //            gvOC.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese un numero de OC para la busqueda');", true);

        //    }
        //}
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
        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvOC.PageSize = Convert.ToInt32(ddlp.SelectedValue);
            CargarOC();
        }
        protected void gvOC_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EOC_nombreEstadoOC").ToString());

                if (estado == "Incompleto")
                {
                    e.Row.Cells[5].Text = "<span class='badge badge-warning'>" + e.Row.Cells[5].Text + "</span>";
                }
                else
                {
                    e.Row.Cells[5].Text = "<span class='badge badge-success'>" + e.Row.Cells[5].Text + "</span>";
                }
            }
        }
    }
}