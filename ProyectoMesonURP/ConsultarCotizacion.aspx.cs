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
    public partial class ConsultarCotizacion : System.Web.UI.Page
    {
        DTO_Cotizacion dto_cot;
        CTR_Cotizacion ctr_cot;
        //--------------------
        CTR_Proveedor ctr_pro;
        DTO_Proveedor dto_pro;
        //--------------------
        CTR_EstadoCotizacion ctr_estCot;
        DTO_EstadoCotizacion dto_estCot;
        //--------------------
        CTR_Usuario ctr_usuario;
        DTO_Usuario dto_usuario;
        //--------------------
        CTR_Persona ctr_persona;
        DTO_Persona dto_persona;
        //--------------------
        CTR_DetalleCotizacion ctr_detCot;
        CTR_Menu ctr_menu;
        int idCot;
        CTR_CotizacionXMenu ctr_cotMen;
        //--------------------
        CTR_MedidaXFormatoCompra ctr_medXFormatoCompra;
        DTO_MedidaXFormatoCompra dto_medXFormatoCompra;
        //--------------------
        CTR_Medida ctr_medida;
        DTO_Medida dto_medida;
        //--------------------
        DataTable dtDetCot;
        DataTable dtDetDetCot;
       static  DataTable dtCotMen;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 idCot = (int)Session["idCot"];
                ctr_cot = new CTR_Cotizacion();
                dto_cot=ctr_cot.CTR_ConsultarCotizacion(idCot);
                //--------
                txtNumCot.Text = dto_cot.C_numeroCotizacion;
                txtFechaEmision.Text = dto_cot.C_fechaEmision.ToShortDateString();
                txtTiempoPlazo.Text = dto_cot.C_tiempoPlazo;
                //txtDoc.Text = dto_cot.C_documento;
                //--------Proveedor
                ctr_pro = new CTR_Proveedor();
                dto_pro = ctr_pro.CTR_ConsultarProveedor(dto_cot.PR_idProveedor);
                txtProveedor.Text = dto_pro.PR_razonSocial;
                //--------Estado
                ctr_estCot = new CTR_EstadoCotizacion();
                dto_estCot = ctr_estCot.CTR_ConsultarEstadoCotizacion(dto_cot.EC_idEstadoCotizacion);
                txtEstado.Text = dto_estCot.EC_nombreEstadoC;
                //--------Usuario(Persona nombres)
                ctr_usuario = new CTR_Usuario();
                dto_usuario = ctr_usuario.CTR_ConsultarUsuario(dto_cot.U_idUsuario);
                ctr_persona = new CTR_Persona();
                dto_persona = ctr_persona.CTR_ConsultarPersona(dto_usuario.P_idPersona);
                txtUsuario.Text=$"{dto_persona.P_nombres} {dto_persona.P_aPaterno}";
                //----------
                ctr_medXFormatoCompra = new CTR_MedidaXFormatoCompra();
                ctr_medida = new CTR_Medida();
                //--------GV
                dtDetCot = new DataTable();
                ctr_detCot = new CTR_DetalleCotizacion();
                dtDetCot= ctr_detCot.CTR_ConsultarDetallesCotizacionXCotizacion(idCot);
                //---------
                
                //---------
                dtDetDetCot = new DataTable();
                int i = 0;
                while (i<dtDetCot.Rows.Count)
                {

                    if (dtDetDetCot.Columns.Count == 0)
                    {
                        dtDetDetCot.Columns.Add("DC_idDetalleCotizacion", typeof(int));
                        dtDetDetCot.Columns.Add("I_idInsumo", typeof(int));

                        dtDetDetCot.Columns.Add("I_nombreInsumo", typeof(string));
                        dtDetDetCot.Columns.Add("DC_cantidadCotizacion", typeof(decimal));
                        dtDetDetCot.Columns.Add("FC_nombreFormatoCompra", typeof(string));

                        dtDetDetCot.Columns.Add("CantidadUnidad", typeof(decimal));
                        dtDetDetCot.Columns.Add("Medida", typeof(string));
                    }
                    DataRow dr = dtDetDetCot.NewRow();
                    dr[0] = Convert.ToInt32(dtDetCot.Rows[i]["DC_idDetalleCotizacion"]);
                    dr[1] = Convert.ToInt32(dtDetCot.Rows[i]["I_idInsumo"]);
                    dr[2] = Convert.ToString(dtDetCot.Rows[i]["I_nombreInsumo"]);
                    dr[3] = Convert.ToDecimal(dtDetCot.Rows[i]["DC_cantidadCotizacion"]);
                    dr[4] = Convert.ToString(dtDetCot.Rows[i]["FC_nombreFormatoCompra"]);

                    int idMedXForCompra = Convert.ToInt32(dtDetCot.Rows[i]["MXF_idMedidaFCompra"]);
                    dto_medXFormatoCompra = ctr_medXFormatoCompra.CTR_ConsultarMedidaXFormatoCompra(idMedXForCompra);
                    dr[5] = dto_medXFormatoCompra.MXF_cantidadContenida;

                    dto_medida = ctr_medida.CTR_ConsultarMedida(dto_medXFormatoCompra.M_idMedida);
                    dr[6] = dto_medida.M_nombreMedida;
                    
                    dtDetDetCot.Rows.Add(dr);
                    i++;
                }
                GVDetalleCot.DataSource = dtDetDetCot;
                GVDetalleCot.DataBind();
                //-------------------
                ctr_cotMen = new CTR_CotizacionXMenu();
               
                dtCotMen = ctr_cotMen.CTR_ConsultarCotizacionXMenuXCotizacion(idCot);


            }


        }

        protected void btnCal_Click(object sender, EventArgs e)
        {
            CldFecha.Visible = !CldFecha.Visible;
        }

        protected void CldFecha_DayRender(object sender, DayRenderEventArgs e)
        {
            ctr_menu = new CTR_Menu();
            int i = 0;
            while (i < dtCotMen.Rows.Count)
            {
                DTO_Menu menu = ctr_menu.CTR_ConsultarMenuXID(Convert.ToInt32(dtCotMen.Rows[i].ItemArray[2]));
                //CldFecha.SelectedDate = Convert.ToDateTime(menu.ME_fechaMenu);
                CldFecha.SelectedDates.Add(Convert.ToDateTime(menu.ME_fechaMenu));
                i++;

            }
            e.Day.IsSelectable = false;
        }
    }
}