﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using System.Data;
using System.Text;

namespace ProyectoMesonURP
{
    public partial class Dashboard : System.Web.UI.Page
    {
        CTR_OC _Coc = new CTR_OC();
        CTR_Insumo _Ci = new CTR_Insumo();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Usuario"] == null)
            //{
            //    Response.Redirect("Home.aspx?x=1");
            //}
            //if (!IsPostBack)
            //{
            //    DTO_Usuario dto = (DTO_Usuario)Session["Usuario"];
            //    switch (dto.TU_idTipoUsuario)
            //    {
            //        case 1:
            //            //CHARTS DE INSUMOS
            //            break;
            //        case 2:
            //            break;
            //        default:
            //            break;
            //    }
            //}
            if (!Page.IsPostBack)
            {
                CargarEstadoOc();
                CargarInsumoD();
                CargarInsumoComprar();
            }
            
        }
        protected string CargarEstadoOc()
        {
            DataTable datos = new DataTable();
            datos = _Coc.CTRPieEstadoOC();

            StringBuilder js = new StringBuilder();
            string strDatos = "";

            js.Append("[");

            foreach (DataRow dr in datos.Rows)
            {
                js.Append(strDatos + "{");
                js.Append("\"Estado\":" + "\"" + dr[0] + "\",");
                js.Append("\"Total\":" + dr[1]);
                js.Append("}");
                strDatos = ",";
            }
            js.Append("]");
            return js.ToString();
        }
        protected string CargarInsumoD()
        {
            DataTable datos = new DataTable();
            datos = _Ci.CTRSelectBarChartInsumoD();

            StringBuilder js = new StringBuilder();
            string strDatos = "";

            js.Append("[");

            foreach (DataRow dr in datos.Rows)
            {
                js.Append(strDatos + "{");
                js.Append("\"Insumo\":" + "\"" + dr[0] + "\",");
                js.Append("\"Medida\":" + "\"" + dr[1] + "\",");
                js.Append("\"Total\":" + dr[2]);
                js.Append("}");
                strDatos = ",";
            }
            js.Append("]");
            return js.ToString();
        }
        protected string CargarInsumoComprar()
        {
            DataTable datos = new DataTable();
            datos = _Ci.CTRSelectBarChartInsumoComprar();

            StringBuilder js = new StringBuilder();
            string strDatos = "";

            js.Append("[");

            foreach (DataRow dr in datos.Rows)
            {
                js.Append(strDatos + "{");
                js.Append("\"Insumo\":" + "\"" + dr[0] + "\",");
                js.Append("\"Formato\":" + "\"" + dr[1] + "\",");
                js.Append("\"CantidadCotizada\":" + "\"" + dr[2] + "\",");
                js.Append("\"Estado\":" + "\"" + dr[3] + "\",");
                js.Append("}");
                strDatos = ",";
            }
            js.Append("]");
            return js.ToString();
        }
    }
}