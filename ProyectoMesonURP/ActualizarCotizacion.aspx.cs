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
    public partial class ActualizarCotizacion : System.Web.UI.Page
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
        DTO_Usuario dto_usuario,dto_usuarioAux;
        //--------------------
        CTR_Persona ctr_persona;
        DTO_Persona dto_persona;
        //--------------------
        CTR_DetalleCotizacion ctr_detCot;
        //---
        CTR_Menu ctr_menu;
        int idCot;
        //--------
        DataTable dtDetCot;
        //------
        CTR_CotizacionXMenu ctr_cotMen;
        CTR_IngredienteXReceta ctr_ingxrec;
        CTR_MenuXReceta ctr_menuxreceta;
        protected void Page_Load(object sender, EventArgs e)
        {
            dto_cot = new DTO_Cotizacion();
            idCot = (int)Session["idCot"];
            ctr_cot = new CTR_Cotizacion();
            dto_usuario = new DTO_Usuario();
            //dto_usuarioAux = new DTO_Usuario();
            //dto_usuarioAux = (DTO_Usuario)Session["Usuario"];
            ctr_usuario = new CTR_Usuario();
            ctr_cotMen = new CTR_CotizacionXMenu();
            ctr_menu = new CTR_Menu();
            ctr_ingxrec = new CTR_IngredienteXReceta();
            ctr_menuxreceta = new CTR_MenuXReceta();
            if (!IsPostBack)
            {
                dtDetCot = new DataTable();
                dto_cot = ctr_cot.CTR_ConsultarCotizacion(idCot);
                //--------
                txtNumCot.Text = dto_cot.C_numeroCotizacion;
                txtFechaEmision.Text = dto_cot.C_fechaEmision.ToShortDateString();
                //TiempoPlazo
                
                DdlTiempoPlazo.SelectedValue= dto_cot.C_tiempoPlazo;
                //txtTiempoPlazo.Text = dto_cot.C_tiempoPlazo;
                //------------------
                txtDoc.Text = dto_cot.C_documento;
                //--------Proveedor
                ctr_pro = new CTR_Proveedor();
                dto_pro = ctr_pro.CTR_ConsultarProveedor(dto_cot.PR_idProveedor);
                DdlProveedor.DataTextField = "PR_razonSocial";
                DdlProveedor.DataValueField = "PR_idProveedor";
                DdlProveedor.DataSource = ctr_pro.CTR_ConsultarProveedores();
                DdlProveedor.DataBind();
                DdlProveedor.SelectedValue = dto_pro.PR_idProveedor.ToString();
                //txtProveedor.Text = dto_pro.PR_razonSocial;
                //--------Estado
                ctr_estCot = new CTR_EstadoCotizacion();
                dto_estCot = ctr_estCot.CTR_ConsultarEstadoCotizacion(dto_cot.EC_idEstadoCotizacion);
                txtEstado.Text = dto_estCot.EC_nombreEstadoC;
                //--------Usuario(Persona nombres)


                dto_usuario = ctr_usuario.CTR_ConsultarUsuario(dto_cot.U_idUsuario);
                ctr_persona = new CTR_Persona();
                dto_persona = ctr_persona.CTR_ConsultarPersona(dto_usuario.P_idPersona);
                txtUsuario.Text = $"{dto_persona.P_nombres} {dto_persona.P_aPaterno}";
                //--------GV
                ctr_detCot = new CTR_DetalleCotizacion();
                dtDetCot= ctr_detCot.CTR_ConsultarDetallesCotizacionXCotizacion(idCot);
                GVDetalleCot.DataSource = dtDetCot;
                GVDetalleCot.DataBind();
                //----------
                
                

            }
        }

        protected void btnCal_Click(object sender, EventArgs e)
        {
            CldFecha.Visible = !CldFecha.Visible;
        }

        protected void CldFecha_DayRender(object sender, DayRenderEventArgs e)
        {
            DataTable dtCotMen = ctr_cotMen.CTR_ConsultarCotizacionXMenuXCotizacion(idCot);
            int i = 0;
            while (i<dtCotMen.Rows.Count)
            {
                DTO_Menu menu = ctr_menu.CTR_ConsultarMenuXID(Convert.ToInt32(dtCotMen.Rows[i].ItemArray[2]));
                
                CldFecha.SelectedDates.Add(Convert.ToDateTime(menu.ME_fechaMenu));
                i++;
                
            }
          
        }

        protected void CldFecha_SelectionChanged(object sender, EventArgs e)
        {

        }

        protected void btnActualizarCotizacion_Click(object sender, EventArgs e)
        {
            
            dto_cot.C_idCotizacion = idCot;
            dto_cot.C_numeroCotizacion = txtNumCot.Text;
            dto_cot.C_tiempoPlazo = DdlTiempoPlazo.SelectedValue;
            dto_cot.C_documento = txtDoc.Text;
            dto_cot.PR_idProveedor = Convert.ToInt32(DdlProveedor.SelectedValue);
            
            
            ctr_cot.CTR_Actualizar_Cotizacion(dto_cot);
            ClientScript.RegisterStartupScript(Page.GetType(), "alertaExito", "alertaExito('Se ha logrado ingresar correctamente');", true);

            //Response.Redirect("GestionarCotizacion.aspx");
        }
        //public void ConsultarInsumosXCat()
        //{

        //    // Seleccionar menu de la fecha seleccionada
        //    DateTime fecha = CldFecha.SelectedDate;
        //    DataTable dtmenu = new DataTable();
        //    DataTable dtMenuXReceta, dtMenuXRecetas = new DataTable();
        //    foreach (DateTime item in CldFecha.SelectedDates)
        //    {
        //        dtmenu.Merge(ctr_menu.CTR_ConsultarMenusXEstadoYFecha(1, item));
        //    }
        //    //dtmenu= ctr_menu.CTR_ConsultarMenusXEstadoYFecha(1, fecha);
        //    int h = 0;
        //    object[] menuxreceta, ingrxrec, menu;

        //    //DTO_Menu dto_menu = ctr_menu.CTR_ConsultarMenusXEstadoYFecha(1,fecha);
        //    // Seleccionar los menuxreceta del menu seleccionado
        //    while (h < dtmenu.Rows.Count)
        //    {
        //        menu = dtmenu.Rows[h].ItemArray;
        //        dtMenuXReceta = ctr_menuxreceta.CTR_ConsultarRecetasXMenu(Convert.ToInt32(menu[0]));
        //        dtMenuXRecetas.Merge(dtMenuXReceta);
        //        h++;
        //    }

        //    // Seleccionar las recetas del menuxreceta de las fechas selccionadas


        //    // Seleccionar los ingredientesxreceta de cada receta
        //    int i = 0;

        //    DTO_Ingrediente dto_ingrediente;
        //    DTO_Insumo dto_insumo;
        //    DataTable dtIng = new DataTable();
        //    int cat = 1;
        //    while (i < dtMenuXRecetas.Rows.Count)
        //    {
        //        //int j = 0;
        //        menuxreceta = dtMenuXRecetas.Rows[i].ItemArray;
        //        DataTable dtIngXRec = ctr_ingxrec.CTR_ConsultarIngredientesXReceta(Convert.ToInt32(menuxreceta[1]), cat,0);
        //        dtIng.Merge(dtIngXRec);
        //        //while (j < dtMenuXReceta.Rows.Count)
        //        //{
        //        //    ingrxrec = dtIngXRec.Rows[j].ItemArray;
        //        //    // Seleccionar los ingredientes en funcion al ingredientexreceta del turno
        //        //    dto_ingrediente = ctr_ingrediente.CTR_Consultar_IngredienteXID(Convert.ToInt32(ingrxrec[4]));
        //        //    // Seleccionar el insumo del ingrediente

        //        //    j++;
        //        //}

        //        i++;

        //    }
        //    foreach (DataRow item in dtIng.Rows)
        //    {

        //    }
        //    GVDetalleCot.DataSource = dtIng;
        //    GVDetalleCot.DataBind();

        //}
    }
}