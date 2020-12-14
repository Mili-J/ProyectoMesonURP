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
                GridViewCotizacion.DataSource = ctr_cotizacion.DAO_Consultar_Cotizaciones();
                GridViewCotizacion.DataBind();
            }
        }
        protected void gvCotizacion_RowCommand(object source, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "GenerarOc")
            {
                int idCotizacion = Convert.ToInt32(GridViewCotizacion.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["C_idCotizacion"].ToString());
                Session["idcotizacion"] = idCotizacion;

                string proveedor = GridViewCotizacion.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
                Session["proveedor"] = proveedor;

                Response.Redirect("GenerarOC");
            }
        }
    }
}