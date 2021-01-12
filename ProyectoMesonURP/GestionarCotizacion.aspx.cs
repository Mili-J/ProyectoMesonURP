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
                CargarCots();
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
            idCot = Convert.ToInt32(GridViewCotizacion.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["C_idCotizacion"].ToString());
            Session.Add("idCot", idCot);
            DTO_Cotizacion cot = ctr_cotizacion.CTR_ConsultarCotizacion(idCot);
            if (e.CommandName == "DetallesCotizacion")
            {
            //    Response.Redirect("ConsultarCotizacion.aspx");
            //}
            //else if (e.CommandName == "GenerarOc")
            //{
                int idCotizacion = Convert.ToInt32(GridViewCotizacion.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["C_idCotizacion"].ToString());
                Session["idcotizacion"] = idCotizacion;

                string proveedor = GridViewCotizacion.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
                Session["proveedor"] = proveedor;

                Response.Redirect("DetallesCotizacion");
            }
            else if (e.CommandName == "EnviarEmailCotizacion")
            {

                DataTable dt = new CTR_DetalleCotizacion().CTR_ConsultarDetallesCotizacionXCotizacion(idCot);
                string htmlbody = Resource.MensajeCotizacion;
                htmlbody = htmlbody.Replace("#IDOC#", cot.C_numeroCotizacion);
                htmlbody = htmlbody.Replace("#PROVEEDOR#", new CTR_Proveedor().CTR_ConsultarProveedor(cot.PR_idProveedor).PR_razonSocial);
                htmlbody = htmlbody.Replace("#FECHAEMISION#", cot.C_fechaEmision.ToShortDateString());
                htmlbody = htmlbody.Replace("#TIEMPOPLAZO#", cot.C_tiempoPlazo);
                htmlbody = htmlbody.Replace("#DOCUMENTO#", cot.C_documento);
                string dta = "";
                foreach (DataRow item in dt.Rows)
                {
                    dta += $"<tr><td>{item.ItemArray[4].ToString()}</td>" +
                        $"<td>{item.ItemArray[1].ToString()}</td>" +
                        $"<td>{item.ItemArray[8].ToString()}</td>" +
                        $"</tr>";
                }

                htmlbody = htmlbody.Replace("#GRID#", dta);


                if (ctr_cotizacion.EnviarCorreo(cot, htmlbody))
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "alertaCorreo", "alertaCorreo('');", true);
                    cot.EC_idEstadoCotizacion = 4;
                    ctr_cotizacion.CTR_ActualizarEstadoCotizacion(cot);//de creada a enviada
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "alertaCorreoNo", "alertaCorreoNo('');", true);
                }
            }
            else if (e.CommandName == "ActualizarCotizacion")
            {
                Response.Redirect("ActualizarCotizacion.aspx");
            }
            else if (e.CommandName == "AceptarCotizacion")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alertaAceptado", "alertaAceptado('');", true);
                cot.EC_idEstadoCotizacion = 1;
                ctr_cotizacion.CTR_ActualizarEstadoCotizacion(cot);//de recibida a aceptada
            }
            else if (e.CommandName == "RechazarCotizacion")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alertaRechazado", "alertaRechazado('');", true);
                cot.EC_idEstadoCotizacion = 2;
                ctr_cotizacion.CTR_ActualizarEstadoCotizacion(cot);//de recibida a rechazada

            }
            else if (e.CommandName == "RecibirCotizacion")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alertaRecibido", "alertaRecibido('');", true);
                cot.EC_idEstadoCotizacion = 5;
                ctr_cotizacion.CTR_ActualizarEstadoCotizacion(cot);//de enviada a recibida
            }
            CargarCots();
        }

        protected void GridViewCotizacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = Convert.ToDateTime(e.Row.Cells[2].Text).ToShortDateString();
                //string estadoColor = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EC_nombreEstadoC").ToString());
                string estado = e.Row.Cells[6].Text.ToString();
                if (estado == "Creada")
                {
                    e.Row.Cells[8].FindControl("btnVerDetallesCotizacion").Visible = false;
                    e.Row.Cells[11].FindControl("btnAceptada").Visible = false;
                    e.Row.Cells[11].FindControl("btnRechazada").Visible = false;
                    e.Row.Cells[11].FindControl("btnRecibida").Visible = false;
                    e.Row.Cells[6].Text = "<span class='badge badge-primary'>" + e.Row.Cells[6].Text + "</span>";
                    //e.Row.Cells[9].FindControl("btnGenerarOC").Visible = false;
                }
                else if (estado == "Enviada")
                {
                    LinkButton btnEnviarEmailCotizacion = (LinkButton)e.Row.FindControl("btnEnviarEmailCotizacion");
                    btnEnviarEmailCotizacion.Enabled = false;
                    btnEnviarEmailCotizacion.ControlStyle.CssClass = "<class='btn btn-infor btn-sm'>";
                    e.Row.Cells[8].FindControl("btnVerDetallesCotizacion").Visible = false;
                    e.Row.Cells[11].FindControl("btnAceptada").Visible = false;
                    e.Row.Cells[11].FindControl("btnRechazada").Visible = false;
                    e.Row.Cells[11].FindControl("btnRecibida").Visible = true;
                    e.Row.Cells[6].Text = "<span class='badge badge-info'>" + e.Row.Cells[6].Text + "</span>";
                    //e.Row.Cells[9].FindControl("btnGenerarOC").Visible = false;
                }
                else if (estado == "Recibida")
                {
                    e.Row.Cells[9].FindControl("btnEditarCotizacion").Visible = false;
                    //e.Row.Cells[7].FindControl("btnEnviarEmailCotizacion").Visible = false;
                    LinkButton btnEnviarEmailCotizacion = (LinkButton)e.Row.FindControl("btnEnviarEmailCotizacion");
                    btnEnviarEmailCotizacion.Enabled = false;
                    btnEnviarEmailCotizacion.ControlStyle.CssClass = "<class='btn btn-infor btn-sm'>";
                    e.Row.Cells[8].FindControl("btnVerDetallesCotizacion").Visible = false;
                    e.Row.Cells[11].FindControl("btnRecibida").Visible = false;
                    e.Row.Cells[11].FindControl("btnAceptada").Visible = true;
                    e.Row.Cells[11].FindControl("btnRechazada").Visible = true;
                    e.Row.Cells[6].Text = "<span class='badge badge-warning'>" + e.Row.Cells[6].Text + "</span>";
                    //e.Row.Cells[9].FindControl("btnGenerarOC").Visible = false;
                }
                else if (estado == "Aceptada")
                {
                    e.Row.Cells[11].FindControl("btnAceptada").Visible = false;
                    e.Row.Cells[11].FindControl("btnRechazada").Visible = false;
                    e.Row.Cells[11].FindControl("btnRecibida").Visible = false;
                    e.Row.Cells[9].FindControl("btnEditarCotizacion").Visible = false;
                    //e.Row.Cells[7].FindControl("btnEnviarEmailCotizacion").Visible = false;
                    LinkButton btnEnviarEmailCotizacion = (LinkButton)e.Row.FindControl("btnEnviarEmailCotizacion");
                    btnEnviarEmailCotizacion.Enabled = false;
                    btnEnviarEmailCotizacion.ControlStyle.CssClass = "<class='btn btn-infor btn-sm'>";
                    e.Row.Cells[8].FindControl("btnVerDetallesCotizacion").Visible = true;
                    //e.Row.Cells[8].FindControl("btnEnviarEmailCotizacion").Visible = false; Lau
                    
                    //e.Row.Cells[9].FindControl("btnGenerarOC").Visible = true; Lau
                    e.Row.Cells[6].Text = "<span class='badge badge-success'>" + e.Row.Cells[6].Text + "</span>";
                }
                else if (estado == "Rechazada")
                {
                    e.Row.Cells[11].FindControl("btnAceptada").Visible = false;
                    e.Row.Cells[11].FindControl("btnRechazada").Visible = false;
                    e.Row.Cells[11].FindControl("btnRecibida").Visible = false;
                    e.Row.Cells[9].FindControl("btnEditarCotizacion").Visible = false;
                    //e.Row.Cells[8].FindControl("btnVerDetallesCotizacion").Visible = false;
                    ////e.Row.Cells[7].FindControl("btnEnviarEmailCotizacion").Visible = false;
                    //e.Row.Cells[8].FindControl("btnEnviarEmailCotizacion").Visible = false; Lau
                    LinkButton btnEnviarEmailCotizacion = (LinkButton)e.Row.FindControl("btnEnviarEmailCotizacion");
                    btnEnviarEmailCotizacion.Enabled = false;
                    btnEnviarEmailCotizacion.ControlStyle.CssClass = "<class='btn btn-infor btn-sm'>";
                    LinkButton btnVerDetallesCotizacion = (LinkButton)e.Row.FindControl("btnVerDetallesCotizacion");
                    btnVerDetallesCotizacion.Enabled = false;
                    btnVerDetallesCotizacion.ControlStyle.CssClass = "<class='btn btn-infor btn-sm'>";
                    //e.Row.Cells[9].FindControl("btnGenerarOC").Visible = false; Lau
                    e.Row.Cells[6].Text = "<span class='badge badge-secondary'>" + e.Row.Cells[6].Text + "</span>";
                }
            }

        }
        public void CargarCots()
        {
            GridViewCotizacion.DataSource = ctr_cotizacion.CTR_Consultar_Cotizaciones();
            GridViewCotizacion.DataBind();
        }
        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void fNombreCotizacion_TextChanged(object sender, EventArgs e)
        {
        }
    }
}