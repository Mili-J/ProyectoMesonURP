using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;
using System.Collections;

namespace ProyectoMesonURP
{
    public partial class GestionarInsumo: System.Web.UI.Page
    {
        CTR_Insumo _CI = new CTR_Insumo();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                CargarStockInsumo();

                ListItem ddl1 = new ListItem("5", "5");
                ddlp.Items.Insert(0, ddl1);
                ListItem ddl2 = new ListItem("10", "10");
                ddlp.Items.Insert(1, ddl2);
                ListItem ddl3 = new ListItem("20", "20");
                ddlp.Items.Insert(2, ddl3);
            }

        }
        private void CargarStockInsumo()
        {
            gvInsumos.DataSource = _CI.ConsultarInsumo(txtBuscarInsumo.Text);
            gvInsumos.DataBind();

        }
        protected void fNombreInsumo_TextChanged(object sender, EventArgs e)
        {
            CargarStockInsumo();
        }
        protected void gvInsumos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInsumos.PageIndex = e.NewPageIndex;
            CargarStockInsumo();

        }
        protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int id = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "I_idInsumo"));

                if (_CI.ValInsumo_GI(id))
                {
                    ImageButton btnEditar = (ImageButton)e.Row.FindControl("btnEditar");
                    btnEditar.Enabled = true;
                }
                else
                {
                    ImageButton btnEditar = (ImageButton)e.Row.FindControl("btnEditar");
                    btnEditar.Enabled = false;
                    btnEditar.ImageUrl = "img/editar-b.png";
                }
            }
        }
        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvInsumos.PageSize = Convert.ToInt32(ddlp.SelectedValue);
            CargarStockInsumo();
        }
        protected void gvInsumos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int Insumo = Convert.ToInt32(gvInsumos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_idInsumo"].ToString());
                Session.Add("InsumoSeleccionado", Insumo);
                Response.Redirect("EditarInsumo.aspx");
            }
            if (e.CommandName == "Consultar")
            {
                int Insumo = Convert.ToInt32(gvInsumos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_idInsumo"].ToString());
                Session.Add("InsumoSeleccionado", Insumo);
                Response.Redirect("ConsultarInsumo.aspx");
            }
        }
    }
}