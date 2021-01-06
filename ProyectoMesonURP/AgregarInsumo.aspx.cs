using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DAO;
using CTR;
using System.Globalization;

namespace ProyectoMesonURP
{
    public partial class AgregarInsumo : System.Web.UI.Page
    {
        CTR_Insumo _I = new CTR_Insumo();
        CTR_Medida _M = new CTR_Medida();
        CTR_MedidaXFormato _MXF = new CTR_MedidaXFormato();
        CTR_CategoriaInsumo _C = new CTR_CategoriaInsumo();
        DataSet dt = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarDDLs();

            }

        }

        private void CargarDDLs()
        {
            
            dt = _C.SelectCategoria_GI();
            DDLCategoria.DataSource = dt;
            DDLCategoria.DataBind();
            DDLCategoria.DataTextField = "CI_nombreCategoria";
            DDLCategoria.DataValueField = "CI_idCategoriaInsumo";
            DDLCategoria.DataBind();
            DDLCategoria.Items.Insert(0, "--seleccionar--");

            dt = _MXF.SelectFC_GI();
            DDLFC.DataSource = dt;
            DDLFC.DataBind();
            DDLFC.DataTextField = "FC_nombreFormatoCompra";
            DDLFC.DataValueField = "FC_idFCompra";
            DDLFC.DataBind();
            DDLFC.Items.Insert(0, "--seleccionar--");
        }
        private void CargarDDLMedida(DropDownList DDLMedida)
        {
            dt = _M.SelectMedida_GI();
            DDLMedida.DataSource = dt;
            DDLMedida.DataBind();
            DDLMedida.DataTextField = "M_nombreMedida";
            DDLMedida.DataValueField = "M_idMedida";
            DDLMedida.DataBind();
            DDLMedida.Items.Insert(0, "--seleccionar--");
        }
        protected void FC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DDLFC.SelectedValue) != 0) 
            { 
                if (Convert.ToInt32(DDLFC.SelectedValue) == 1)
                {
                    CargarDDLMedida(DDLMedida);
                    PanelMedida1.Visible = true;
                    PanelMedida2.Visible = false;
                    PanelMedida3.Visible = false;
                    Cantmin.Visible = true;
                }
                else
                {
                    Label1.InnerText = DDLFC.SelectedItem.ToString() + " de:";
                    CargarDDLMedida(DDLMedida2);
                    PanelMedida1.Visible = false;
                    PanelMedida2.Visible = true;
                    PanelMedida3.Visible = true;
                    Cantmin.Visible = true;
                }
            }

        }
        protected void btnRegistrar_ServerClick(object sender, EventArgs e)
        {
            object[] NuevoInsumo = new object[7];
            NuevoInsumo[0]=  txtInsumo.Text;
            NuevoInsumo[1] = DDLCategoria.SelectedValue;
            NuevoInsumo[2] = DDLFC.SelectedValue;
            if (Convert.ToInt32(DDLFC.SelectedValue) == 1)
            {
                NuevoInsumo[3] = DDLMedida.SelectedValue;
            }
            else 
            { 
                NuevoInsumo[3] = DDLMedida2.SelectedValue; 
            }
            NuevoInsumo[4] = Convert.ToDecimal(txtCantidadCo.Text, CultureInfo.InvariantCulture);
            NuevoInsumo[5] = TxtCantUn.Text;
            NuevoInsumo[6] = Convert.ToDecimal(TxtCantmin.Text, CultureInfo.InvariantCulture);
            _I.InsertInsumo(NuevoInsumo);
            //Response.Redirect(Request.RawUrl);
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alertaExito()", true);
            return;
        }
        public void ChckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                Label2.InnerText = "Pack de  ";
                TxtCantUn.Visible = true;
                Label3.InnerText = DDLFC.SelectedItem.ToString()+"s";
            }
            else {
                Label2.InnerText = "Pack  ";
                TxtCantUn.Visible = false;
                Label3.InnerText = "";
            }
        }
    }
}