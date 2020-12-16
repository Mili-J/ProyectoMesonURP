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
                GridViewCotizacion.DataSource = ctr_cotizacion.CTR_Consultar_Cotizaciones();
                GridViewCotizacion.DataBind();
            }
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
        }

        protected void GridViewCotizacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType==DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = Convert.ToDateTime(e.Row.Cells[2].Text).ToShortDateString();
            }
            
        }
    }
}