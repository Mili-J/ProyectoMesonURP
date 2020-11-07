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
    public partial class ManejarStock : System.Web.UI.Page
    {
        CTR_Insumo _CI = new CTR_Insumo();
        DTO_Insumo dto_i;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dto_i = new DTO_Insumo();
                CargarStockInsumo();
            }
            
        }

        protected void btnBuscar_ServerClick(object sender, EventArgs e)
        {

            try
            {
                if (txtBuscarInsumo.Text != "")
                {
                    gvInsumos.DataSource = _CI.BuscarInsumo(txtBuscarInsumo.Text);
                    gvInsumos.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese un insumo para la busqueda');", true);

            }
        }

        protected void btnSolicitar_Click(object sender, EventArgs e)
        {

            try
            {
                CheckBox chk;
                DataTable dt = new DataTable();
                dt.Columns.Add("I_idInsumo");
                foreach (GridViewRow grvRow in gvInsumos2.Rows)
                {
                    chk = (CheckBox)grvRow.FindControl("chkBox");
                    if (chk.Checked)
                    {
                        int d = Convert.ToInt32(gvInsumos2.DataKeys[grvRow.RowIndex].Values["I_idInsumo"].ToString());
                        dt.Rows.Add(d);
                    }
                }
                Session.Add("InsumosSeleccionados", dt);
                Response.Redirect("SC_Prueba.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Ingrese un insumo para la busqueda');", true);

            }
        }
        public void CargarStockInsumo()
        {
            gvInsumos.DataSource = _CI.ListarInsumo();
            gvInsumos.DataBind();
            gvInsumos2.DataSource = _CI.ListarInsumo2();
            gvInsumos2.DataBind();

        }
        protected void gvInsumos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInsumos.PageIndex = e.NewPageIndex;
            CargarStockInsumo();
        }
        protected void gvInsumos2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInsumos2.PageIndex = e.NewPageIndex;
            CargarStockInsumo();
        }

        protected void gvInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvInsumos2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}