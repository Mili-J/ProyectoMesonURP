﻿using CTR;
using DTO;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class DetallesCotizacion : System.Web.UI.Page
    {
            DTO_DetalleOC _Ddc = new DTO_DetalleOC();
            CTR_DetalleOC _Cdoc = new CTR_DetalleOC();
            CTR_DetalleCotizacion _Cdc = new CTR_DetalleCotizacion();
            DTO_OC _Doc = new DTO_OC();
            CTR_OC _Coc = new CTR_OC();
            DTO_Cotizacion dto_cot;
            CTR_Cotizacion ctr_cot;
            CTR_Proveedor ctr_pro;
            DTO_Proveedor dto_pro;
            string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {

                    CargarDetalle();
                }
                txtFechaEmision.Text = FechaActual;
                txtFechaEntrega.Text = FechaActual;
        }
        public void CargarDetalle() {
            bool _Edc = _Cdoc.ExistenciaDetalleOC((int)Session["idCot"]);
            if (_Edc) {
                CargarOC();
            }
            else
            {
                btnGuardar.Visible = true;
                btnGenerarOC.Visible = false;
                CargarCotizacion();
            }
        }
        public void CargarCotizacion()
        {
            int idCot = (int)Session["idCot"];
            ctr_cot = new CTR_Cotizacion();
            dto_cot = ctr_cot.CTR_ConsultarCotizacion(idCot);
            //--------
            txtNCotizacion.Text = dto_cot.C_numeroCotizacion;
            txtFechaEmision.Text = dto_cot.C_fechaEmision.ToShortDateString();
            txtProveedor.Text = Convert.ToString(Session["proveedor"]);

            gvDetalles.Visible = false;
            gvInsumos.DataSource = _Cdc.CargarDetalleCotizacion(Convert.ToInt32(Session["idcotizacion"]));
            gvInsumos.DataBind();
        }
            public void CargarOC() {

                gvInsumos.Visible = false;
            int idCot = (int)Session["idCot"];
            ctr_cot = new CTR_Cotizacion();
            dto_cot = ctr_cot.CTR_ConsultarCotizacion(idCot);
            //--------
            txtNCotizacion.Text = dto_cot.C_numeroCotizacion;
            txtFechaEmision.Text = dto_cot.C_fechaEmision.ToShortDateString();
            string nOC = _Coc.ListarNumeroOC();
            txtProveedor.Text = Convert.ToString(Session["proveedor"]);
            txtFechaEntrega.Visible = false;
            btnGuardar.Visible = false;
            btnGenerarOC.Visible = true;

            gvDetalles.DataSource = _Cdoc.CargarDetalleOC(Convert.ToInt32(Session["idcotizacion"]));
            gvDetalles.DataBind();
        }
            protected void btnGuardar_ServerClick(object sender, EventArgs e)
            {
            if (ddlFormaPago.SelectedIndex != 0)
            {
                _Doc.OC_numeroOc = _Coc.ListarNumeroOC();
                Session["nOC"] = _Doc.OC_numeroOc;
                _Doc.OC_fechaEmision = Convert.ToDateTime(txtFechaEmision.Text);
                _Doc.OC_fechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
                _Doc.OC_tipoPago = ddlFormaPago.SelectedValue;
                _Doc.OC_totalCompra = Convert.ToDecimal(Session["Totaldecompra"]);
                _Doc.EOC_idEstadoOC = 2;
                _Doc.U_idUsuario = Convert.ToInt32(Session["idUsuario"]);

                _Coc.RegistrarOC(_Doc);

                for (int i = 0; i < gvInsumos.Rows.Count; i++)
                    {
                        _Ddc.DOC_totalPrecio = Convert.ToDecimal(((Label)gvInsumos.Rows[i].FindControl("lblPrecioTotal")).Text);
                        _Ddc.DOC_precioUnitario = Convert.ToDecimal(((TextBox)gvInsumos.Rows[i].FindControl("txtPrecioUnitario")).Text);
                        _Ddc.OC_idOC = _Coc.IdOC();
                        int idCotizacion = Convert.ToInt32(Session["idcotizacion"]);
                        string nombre = Convert.ToString(gvInsumos.Rows[i].Cells[0].Text);

                        _Ddc.DC_idDetalleCotizacion = _Cdc.IdDetalleCotizacion(idCotizacion, nombre);
                        _Cdoc.RegistrarDetalleOC(_Ddc);
                    }
                    ClientScript.RegisterStartupScript(Page.GetType(), "alertIns", "alertaExito('');", true);
                    btnGuardar.Visible = false; 
                    btnGenerarOC.Visible = true;
            }
        }
        protected void btnGenerarOC_ServerClick(object sender, EventArgs e)
        {
            Session["FEmision"] = Convert.ToDateTime(txtFechaEmision.Text);
            Session["FEntrega"] = Convert.ToDateTime(txtFechaEntrega.Text);
            Session["FPago"] = ddlFormaPago.SelectedValue;
            Response.Redirect("GenerarOC");
        }
            protected void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
            {
                try
                {
                    TextBox txt = (TextBox)sender;
                    int index = ((GridViewRow)txt.NamingContainer).RowIndex;
                    string precioCosto = txt.Text;
                    if (!decimal.TryParse(precioCosto, out decimal result))
                    {
                        //mensaje de que no es entero    
                    }
                    string cantidad = ((Label)gvInsumos.Rows[index].FindControl("lblCantidad")).Text;
                    decimal subtotal = decimal.Parse(precioCosto) * decimal.Parse(cantidad);
                    ((Label)gvInsumos.Rows[index].FindControl("lblPrecioTotal")).Text = subtotal.ToString();
                    decimal sum = decimal.Zero;
                    for (int i = 0; i < gvInsumos.Rows.Count; i++)
                    {
                        sum += decimal.Parse(((Label)gvInsumos.Rows[i].FindControl("lblPrecioTotal")).Text == string.Empty ? "0" : ((Label)gvInsumos.Rows[i].FindControl("lblPrecioTotal")).Text);
                    }
                   ((Label)gvInsumos.FooterRow.FindControl("lblTotal")).Text = sum.ToString();
                    Session["Totaldecompra"] = ((Label)gvInsumos.FooterRow.FindControl("lblTotal")).Text;
                }
                catch (Exception)
                {

                    throw;
                }
            }
    }
}
