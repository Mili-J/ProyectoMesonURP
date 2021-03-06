﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;
using System.Collections;

namespace ProyectoMesonURP
{
    public partial class ManejarStock : System.Web.UI.Page
    {
        CTR_Insumo _CI = new CTR_Insumo();
        DTO_Insumo dto_i;
        DTO_Usuario dto_u;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Usuario"] == null)
            //{
            //    Response.Redirect("Login?x=1");
            //}
            if (!Page.IsPostBack)
            {
                dto_u=(DTO_Usuario)Session["Usuario"];
                dto_i = new DTO_Insumo();
                switch (dto_u.TU_idTipoUsuario)
                {
                    case 1: 
                        PanelInsumos2.Visible = false;
                    break;
                    case 2:
                        PanelInsumos2.Visible = false;
                        break;
                    case 3:
                        PanelInsumos2.Visible = false;
                        break;
                    default:
                        break;
                }
                CargarStockInsumo();
                CargarStockInsumo2();

                ListItem ddl1 = new ListItem("5", "5");
                ddlp.Items.Insert(0, ddl1);
                ListItem ddl2 = new ListItem("10", "10");
                ddlp.Items.Insert(1, ddl2);
                ListItem ddl3 = new ListItem("20", "20");
                ddlp.Items.Insert(2, ddl3);
            }

        }

        //protected void btnBuscar_ServerClick(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        if (txtBuscarInsumo.Text != "")
        //        {
        //            gvInsumos.DataSource = _CI.BuscarInsumoF(txtBuscarInsumo.Text);
        //            gvInsumos.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese un insumo para la busqueda');", true);

        //    }
        //}

        protected void btnSolicitar_Click(object sender, EventArgs e)
        {
            Guardar();
            gvInsumos2.AllowPaging = false;
            CargarStockInsumo2();
            Recuperar();


            CheckBox chk;
                DataTable dt = new DataTable();
                dt.Columns.Add("I_idInsumo");
                dt.Columns.Add("I_nomInsumo");
                foreach (GridViewRow grvRow in gvInsumos2.Rows)
                {
                    chk = (CheckBox)grvRow.FindControl("chkBox");
                    if (chk.Checked)
                    {
                        int d = Convert.ToInt32(gvInsumos2.DataKeys[grvRow.RowIndex].Values["I_idInsumo"].ToString());
                        string n = gvInsumos2.DataKeys[grvRow.RowIndex].Values["I_NombreInsumo"].ToString();
                        dt.Rows.Add(d, n);
                    }
                }

            gvInsumos2.AllowPaging = true;
            CargarStockInsumo2();
            Session.Add("InsumosSeleccionados", dt);
               Response.Redirect("SC_Prueba.aspx");

        }
        private void Guardar()
        {
            ArrayList Lista = new ArrayList();
            int index = -1;
            foreach (GridViewRow row in gvInsumos2.Rows)
            {
                index = (int)gvInsumos2.DataKeys[row.RowIndex].Value;
                bool result = ((CheckBox)row.FindControl("chkBox")).Checked;

                if (Session["CasillasMarcadas"] != null)
                    Lista = (ArrayList)Session["CasillasMarcadas"];
                if (result)
                {
                    if (!Lista.Contains(index))
                        Lista.Add(index);
                }
                else
                    Lista.Remove(index);
            }
            if (Lista != null && Lista.Count > 0)
                Session["CasillasMarcadas"] = Lista;
        }

        private void Recuperar()
        {
            ArrayList Lista = (ArrayList)Session["CasillasMarcadas"];
            if (Lista != null && Lista.Count > 0)
            {
                foreach (GridViewRow row in gvInsumos2.Rows)
                {
                    int index = (int)gvInsumos2.DataKeys[row.RowIndex].Value;
                    if (Lista.Contains(index))
                    {
                        CheckBox myCheckBox = (CheckBox)row.FindControl("chkBox");
                        myCheckBox.Checked = true;
                    }
                }
            }
        }

        public void CargarStockInsumo()
        {
            gvInsumos.DataSource = _CI.ConsultarInsumo(txtBuscarInsumo.Text);
            gvInsumos.DataBind();

        }
        protected void fNombreInsumo_TextChanged(object sender, EventArgs e)
        {
            CargarStockInsumo();
            //CargarRecetaTab1();
        }
        public void CargarStockInsumo2()
        {
            gvInsumos2.DataSource = _CI.ListarInsumo2();
            gvInsumos2.DataBind();

        }
        protected void gvInsumos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInsumos.PageIndex = e.NewPageIndex;
            CargarStockInsumo();

        }
        protected void gvInsumos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "El_nombreEstado").ToString());

                if (estado == "Agotado")
                {
                    e.Row.Cells[5].Text = "<span class='badge badge-secondary'>" + e.Row.Cells[5].Text + "</span>";
                }
                else if (estado == "Disponible")
                {
                    e.Row.Cells[5].Text = "<span class='badge badge-success'>" + e.Row.Cells[5].Text + "</span>";
                }
            }
        }

        protected void gvInsumos2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Guardar();
            gvInsumos2.PageIndex = e.NewPageIndex;
            CargarStockInsumo2();
            Recuperar();
        }
        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvInsumos.PageSize = Convert.ToInt32(ddlp.SelectedValue);
            CargarStockInsumo();
        }
        protected void gvInsumos2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "El_nombreEstado").ToString());

                if (estado == "Agotado")
                {
                    e.Row.Cells[4].Text = "<span class='badge badge-secondary'>" + e.Row.Cells[4].Text + "</span>";
                }
                else if (estado == "Disponible")
                {
                    e.Row.Cells[4].Text = "<span class='badge badge-success'>" + e.Row.Cells[4].Text + "</span>";
                }
            }
        }
        protected void gvInsumos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "selectItem")
                {
                    int codSer = Convert.ToInt32(gvInsumos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_idInsumo"].ToString());

                    Session["I_idInsumo"] = codSer;

                    Response.Redirect("ManejarStock.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}