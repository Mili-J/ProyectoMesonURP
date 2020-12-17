using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;

namespace ProyectoMesonURP
{
    public partial class GestionarCotizacion : System.Web.UI.Page
    {
        CTR_Cotizacion ctr_cotizacion;
        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_cotizacion = new CTR_Cotizacion();
            if (!IsPostBack)
            {
                CargarCotizacion();
                ListItem ddl1 = new ListItem("5", "5");
                ddlp.Items.Insert(0, ddl1);
                ListItem ddl2 = new ListItem("10", "10");
                ddlp.Items.Insert(1, ddl2);
                ListItem ddl3 = new ListItem("20", "20");
                ddlp.Items.Insert(2, ddl3);
            }
        }
        public void CargarCotizacion()
        {
            GridViewCotizacion.DataSource = ctr_cotizacion.CTR_Consultar_Cotizaciones();
            GridViewCotizacion.DataBind();

        }
        protected void GridViewCotizacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idCot;
            if (e.CommandName== "ConsultarCotizacion")
            {
                idCot = Convert.ToInt32(GridViewCotizacion.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["C_idCotizacion"].ToString());
                Session.Add("idCot",idCot);
                Response.Redirect("ConsultarCotizacion.aspx");
            }
            if (e.CommandName == "GenerarOc")
            {
                int idCotizacion = Convert.ToInt32(GridViewCotizacion.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["C_idCotizacion"].ToString());
                Session["idcotizacion"] = idCotizacion;

                string proveedor = GridViewCotizacion.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
                Session["proveedor"] = proveedor;

                Response.Redirect("GenerarOC");
            }
        }

        protected void GridViewCotizacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType==DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = Convert.ToDateTime(e.Row.Cells[2].Text).ToShortDateString();
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EC_nombreEstadoC").ToString());

                if (estado == "Aceptada")
                {
                    e.Row.Cells[6].Text = "<span class='badge badge-success'>" + e.Row.Cells[6].Text + "</span>";
                }
                else if (estado == "Rechazada")
                {
                    e.Row.Cells[6].Text = "<span class='badge badge-secondary'>" + e.Row.Cells[6].Text + "</span>";
                }
            }

        }
        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        protected void fNombreCotizacion_TextChanged(object sender, EventArgs e)
        {
            
        }
        protected void GridViewCotizacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCotizacion.PageIndex = e.NewPageIndex;
            CargarCotizacion();

        }
    }
}