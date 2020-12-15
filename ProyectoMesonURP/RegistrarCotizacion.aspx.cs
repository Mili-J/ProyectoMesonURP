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
    public partial class RegistrarCotizacion : System.Web.UI.Page
    {
        CTR_Proveedor ctr_proveedor;
        CTR_Menu ctr_menu;
        CTR_MenuXReceta ctr_menuxreceta;
        CTR_IngredienteXReceta ctr_ingxrec;
        CTR_Ingrediente ctr_ingrediente;
        CTR_Insumo ctr_insumo;
        CTR_Cotizacion ctr_cotizacion;
        static DataTable dtCot;
        static List<DTO_Cotizacion> listCot = new List<DTO_Cotizacion>();
        static List<DTO_DetalleCotizacion> listDetCot = new List<DTO_DetalleCotizacion>();
        //static List<List<DTO_DetalleCotizacion>> listDetCotTotal = new List<List<DTO_DetalleCotizacion>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_proveedor = new CTR_Proveedor();
            ctr_menu = new CTR_Menu();
            ctr_menuxreceta = new CTR_MenuXReceta();
            ctr_ingxrec = new CTR_IngredienteXReceta();
            ctr_ingrediente = new CTR_Ingrediente();
            ctr_insumo = new CTR_Insumo();
            ctr_cotizacion = new CTR_Cotizacion();
            if (!IsPostBack)
            {
                dtCot = new DataTable();
                txtFecha.Text = DateTime.Today.ToString();
                //--
                DdlProveedor.DataTextField = "PR_razonSocial";
                DdlProveedor.DataValueField = "PR_idProveedor";
                DdlProveedor.DataSource = ctr_proveedor.CTR_ConsultarProveedores();
                DdlProveedor.DataBind();

            }
        }

        protected void btnCrearCotizacion_Click(object sender, EventArgs e)
        {
            while (listCot.Count>=1)
            {
                ctr_cotizacion.CTR_Registrar_Cotizacion(listCot[listCot.Count-1]);
                listCot.RemoveAt(listCot.Count - 1);
            }
            
        }

        protected void btnCal_Click(object sender, EventArgs e)
        {
            CldFecha.Visible = !CldFecha.Visible;

        }

        protected void CldFecha_SelectionChanged(object sender, EventArgs e)
        {

            // Seleccionar menu de la fecha seleccionada
            DateTime fecha = CldFecha.SelectedDate;
            DataTable dtmenu = new DataTable();
            DataTable dtMenuXReceta,dtMenuXRecetas= new DataTable();
            foreach (DateTime item in CldFecha.SelectedDates)
            {
                dtmenu.Merge(ctr_menu.CTR_ConsultarMenusXEstadoYFecha(1, item));
            }
            //dtmenu= ctr_menu.CTR_ConsultarMenusXEstadoYFecha(1, fecha);
            int h = 0;
            object[] menuxreceta, ingrxrec,menu;

            //DTO_Menu dto_menu = ctr_menu.CTR_ConsultarMenusXEstadoYFecha(1,fecha);
            // Seleccionar los menuxreceta del menu seleccionado
            while (h < dtmenu.Rows.Count)
            {
                menu = dtmenu.Rows[h].ItemArray;
                dtMenuXReceta = ctr_menuxreceta.CTR_ConsultarRecetasXMenu(Convert.ToInt32(menu[0]));
                dtMenuXRecetas.Merge(dtMenuXReceta);
                h++;
            }
            

            // Seleccionar las recetas del menuxreceta de las fechas selccionadas


            // Seleccionar los ingredientesxreceta de cada receta
            int i = 0;
            
            DTO_Ingrediente dto_ingrediente;
            DTO_Insumo dto_insumo;
            DataTable dtIng= new DataTable();
            while (i < dtMenuXRecetas.Rows.Count)
            {
                //int j = 0;
                menuxreceta = dtMenuXRecetas.Rows[i].ItemArray;
                DataTable dtIngXRec = ctr_ingxrec.CTR_ConsultarIngredientesXReceta(Convert.ToInt32(menuxreceta[1]),3);
                dtIng.Merge(dtIngXRec);
                //while (j < dtMenuXReceta.Rows.Count)
                //{
                //    ingrxrec = dtIngXRec.Rows[j].ItemArray;
                //    // Seleccionar los ingredientes en funcion al ingredientexreceta del turno
                //    dto_ingrediente = ctr_ingrediente.CTR_Consultar_IngredienteXID(Convert.ToInt32(ingrxrec[4]));
                //    // Seleccionar el insumo del ingrediente
                   
                //    j++;
                //}

                i++;
            }

            GVVerdura.DataSource = dtIng;
            GVVerdura.DataBind();
           
            

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtCot.Columns.Count==0)
            {
                dtCot.Columns.Add("C_numeroCotizacion");
                dtCot.Columns.Add("C_tiempoPlazo");
                dtCot.Columns.Add("C_documento");
                dtCot.Columns.Add("PR_idProveedor");
                dtCot.Columns.Add("PR_razonSocial");
            }
            DTO_Cotizacion dto_cotizacion = new DTO_Cotizacion();
            dto_cotizacion.C_numeroCotizacion = "V00"+dtCot.Rows.Count;
            dto_cotizacion.C_tiempoPlazo= DdlTiempoPlazo.SelectedValue;
            dto_cotizacion.C_documento = txtDoc.Text;
            dto_cotizacion.PR_idProveedor= Convert.ToInt32(DdlProveedor.SelectedValue);
            DataRow dr = dtCot.NewRow();
            dr[0] = dto_cotizacion.C_numeroCotizacion;
            dr[1] = dto_cotizacion.C_tiempoPlazo;
            dr[2] = dto_cotizacion.C_documento;
            dr[3] = dto_cotizacion.PR_idProveedor;
            dr[4] = DdlProveedor.SelectedItem;
            dtCot.Rows.Add(dr);
            listCot.Add(dto_cotizacion);
            GVCot.DataSource = dtCot;
            GVCot.DataBind();
            //----------------
            int i = 0;
            while (i < GVVerdura.Rows.Count)
            {
                DTO_DetalleCotizacion dto_detcot = new DTO_DetalleCotizacion();
                //dto_detcot.C_idCotizacion = Convert.ToInt32(GVVerdura.Rows[i].Cells[0].Text);
                dto_detcot.I_idInsumo = Convert.ToInt32(GVVerdura.DataKeys[i]["I_idInsumo"]);
                dto_detcot.DC_cantidadCotizacion = Convert.ToDecimal(GVVerdura.Rows[i].Cells[2].Text);
                //dto_detcot.DC_idDetalleCotizacion = Convert.ToInt32(GVVerdura.Rows[i].Cells[0]);
                listDetCot.Add(dto_detcot);
                i++;
            }



        }
    }
}