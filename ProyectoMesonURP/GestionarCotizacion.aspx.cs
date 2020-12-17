﻿using System;
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
            idCot = Convert.ToInt32(GridViewCotizacion.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["C_idCotizacion"].ToString());
            Session.Add("idCot", idCot);
            if (e.CommandName== "ConsultarCotizacion")
            {
                Response.Redirect("ConsultarCotizacion.aspx");
            }
            else if (e.CommandName== "EnviarEmailCotizacion")
            {
                DTO_Cotizacion cot = ctr_cotizacion.CTR_ConsultarCotizacion(idCot);
                DataTable dt = new CTR_DetalleCotizacion().CTR_ConsultarDetallesCotizacionXCotizacion(idCot);
                string htmlbody="";
                htmlbody = htmlbody.Replace("#IDOC#", cot.C_idCotizacion.ToString());
                htmlbody = htmlbody.Replace("#TIPOCOMPROBANTE#", cot.C_documento);
                htmlbody = htmlbody.Replace("#NUMEROCOMPROBANTE#", cot.C_numeroCotizacion);
                //htmlbody = htmlbody.Replace("#FORMADEPAGO#", formaPago);
                htmlbody = htmlbody.Replace("#TIEMPO PLAZO#", cot.C_tiempoPlazo);
                htmlbody = htmlbody.Replace("#FECHAEMISION#", cot.C_fechaEmision.ToString());

                string msj = "Solicitud de cotización<br />";
                msj += $"Número de cotización: {cot.C_numeroCotizacion}<br />";
                msj += $"Número de cotización: {cot.C_tiempoPlazo}<br />";
                msj += $"Número de cotización: {cot.C_fechaEmision.ToShortDateString()}<br />";
                msj += $"Número de cotización: {cot.C_documento}<br />";
               
                ctr_cotizacion.EnviarCorreo(cot, msj);
                
                ClientScript.RegisterStartupScript(Page.GetType(), "alertIns", "alertaCorreo('');", true);

            }
            else if (e.CommandName == "ActualizarCotizacion")
            {
                Response.Redirect("ActualizarCotizacion.aspx");
            }
            else if (e.CommandName == "AceptarCotizacion")
            {

            }
            else if (e.CommandName == "RechazarCotizacion")
            {

            }
            else if (e.CommandName == "RecibirCotizacion")
            {

            }
        }

        protected void GridViewCotizacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType==DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = Convert.ToDateTime(e.Row.Cells[2].Text).ToShortDateString();

                string estado = e.Row.Cells[6].Text.ToString();
                if (estado=="Creada")
                {
                    e.Row.Cells[11].FindControl("btnAceptada").Visible=false;
                    e.Row.Cells[11].FindControl("btnRechazada").Visible = false;
                    e.Row.Cells[11].FindControl("btnRecibida").Visible = false;
                }
                else if (estado=="Enviada")
                {

                }
                else if (estado == "Recibida")
                {
                    e.Row.Cells[9].FindControl("btnEditarCotizacion").Visible = false;
                    e.Row.Cells[8].FindControl("btnEnviarEmailCotizacion").Visible = false;
                }
                else if (estado == "Aceptada")
                {
                    e.Row.Cells[11].FindControl("btnAceptada").Visible = false;
                    e.Row.Cells[11].FindControl("btnRechazada").Visible = false;
                    e.Row.Cells[11].FindControl("btnRecibida").Visible = false;
                    e.Row.Cells[9].FindControl("btnEditarCotizacion").Visible = false;
                    e.Row.Cells[8].FindControl("btnEnviarEmailCotizacion").Visible = false;
                }
                else if (estado == "Rechazada")
                {
                    e.Row.Cells[11].FindControl("btnAceptada").Visible = false;
                    e.Row.Cells[11].FindControl("btnRechazada").Visible = false;
                    e.Row.Cells[11].FindControl("btnRecibida").Visible = false;
                    e.Row.Cells[9].FindControl("btnEditarCotizacion").Visible = false;
                    e.Row.Cells[8].FindControl("btnEnviarEmailCotizacion").Visible = false;
                }
            }
            
        }
    }
}