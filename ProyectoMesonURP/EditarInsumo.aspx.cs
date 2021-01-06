using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DTO;
using CTR;
using System.Data;
using System.Globalization;

namespace ProyectoMesonURP
{
    public partial class EditarInsumo : System.Web.UI.Page
    {
        CTR_Insumo _I = new CTR_Insumo();
        CTR_Medida _M = new CTR_Medida();
        CTR_MedidaXFormato _MXF = new CTR_MedidaXFormato();
        CTR_CategoriaInsumo _C = new CTR_CategoriaInsumo();
        DataSet dt = new DataSet();
        DataTable DT = new DataTable();
        private int idInsumo;
        protected void Page_Load(object sender, EventArgs e)
        {
            idInsumo = (int)Session["InsumoSeleccionado"];
            if (!Page.IsPostBack)
            {
                CargarDDLs();
                CargarDatos();


            }
            

        }
        private void CargarDatos()
        {            
            DT = _I.ConsultarInsumo_GI(idInsumo);
            txtInsumo.Text = DT.Rows[0]["I_nombreInsumo"].ToString();
            string cat= DT.Rows[0]["CI_idCategoriaInsumo"].ToString();
            DDLCategoria.Items.FindByValue(cat).Selected = true;
            string fc = DT.Rows[0]["FC_idFCompra"].ToString();
            int idfc = Convert.ToInt32(fc);
            DDLFC.Items.FindByValue(fc).Selected = true;
            FC_SelectedIndexChanged(DDLFC, EventArgs.Empty);
            string md = DT.Rows[0]["M_idMedida"].ToString();
            if (idfc ==1) 
            { 
                DDLMedida.Items.FindByValue(md).Selected = true; 
            }
            else if (idfc > 1)
            { 
                DDLMedida2.Items.FindByValue(md).Selected = true;
                int cantun = Convert.ToInt32(DT.Rows[0]["MXF_cantidadUnidad"].ToString());
                txtCantidadCo.Text = DT.Rows[0]["MXF_cantidadContenida"].ToString().Replace(",", ".");
                TxtCantUn.Text = ""+cantun;
                if (cantun > 1) 
                { 
                    CheckBox1.Checked = true;
                    ChckedChanged(CheckBox1, EventArgs.Empty);
                }
            }
            TxtCantmin.Text = DT.Rows[0]["I_cantidadMinima"].ToString().Replace(",", ".");


        }
            private void CargarDDLs()
        {

            dt = _C.SelectCategoria_GI();
            DDLCategoria.DataSource = dt;
            DDLCategoria.DataBind();
            DDLCategoria.DataTextField = "CI_nombreCategoria";
            DDLCategoria.DataValueField = "CI_idCategoriaInsumo";
            DDLCategoria.DataBind();
            DDLCategoria.Items.Insert(0, new ListItem("-- Seleccione --", ""));

            dt = _MXF.SelectFC_GI();
            DDLFC.DataSource = dt;
            DDLFC.DataBind();
            DDLFC.DataTextField = "FC_nombreFormatoCompra";
            DDLFC.DataValueField = "FC_idFCompra";
            DDLFC.DataBind();
            DDLFC.Items.Insert(0, new ListItem("-- Seleccione --", ""));
        }
        private void CargarDDLMedida(DropDownList DDLMedida)
        {
            dt = _M.SelectMedida_GI();
            DDLMedida.DataSource = dt;
            DDLMedida.DataBind();
            DDLMedida.DataTextField = "M_nombreMedida";
            DDLMedida.DataValueField = "M_idMedida";
            DDLMedida.DataBind();
            DDLMedida.Items.Insert(0, new ListItem("-- Seleccione --", ""));
        }
        protected void FC_SelectedIndexChanged(object sender, EventArgs e)
        {
            DT = _I.ConsultarInsumo_GI(idInsumo);
            string md = DT.Rows[0]["M_idMedida"].ToString();

            if (Convert.ToInt32(DDLFC.SelectedValue) != 0)
            {
                if (Convert.ToInt32(DDLFC.SelectedValue) == 1)
                {
                    CargarDDLMedida(DDLMedida);
                    DDLMedida.Items.FindByValue(md).Selected = true;
                    PanelMedida1.Visible = true;
                    PanelMedida2.Visible = false;
                    PanelMedida3.Visible = false;
                    Cantmin.Visible = true;
                }
                else
                {
                    Label1.InnerText = DDLFC.SelectedItem.ToString() + " de:";
                    CargarDDLMedida(DDLMedida2);
                    DDLMedida2.Items.FindByValue(md).Selected = true;
                    PanelMedida1.Visible = false;
                    PanelMedida2.Visible = true;
                    PanelMedida3.Visible = true;
                    Cantmin.Visible = true;
                }
            }

        }
        protected void btnEditar_ServerClick(object sender, EventArgs e)
        {
            object[] NuevoInsumo = new object[8];
            NuevoInsumo[0] = idInsumo;
            NuevoInsumo[1] = txtInsumo.Text;
            NuevoInsumo[2] = DDLCategoria.SelectedValue;
            NuevoInsumo[3] = DDLFC.SelectedValue;
            if (Convert.ToInt32(DDLFC.SelectedValue) == 1)
            {
                NuevoInsumo[4] = DDLMedida.SelectedValue;
            }
            else
            {
                NuevoInsumo[4] = DDLMedida2.SelectedValue;
            }
            NuevoInsumo[5] = Convert.ToDecimal(txtCantidadCo.Text, CultureInfo.InvariantCulture); 
            NuevoInsumo[6] = TxtCantUn.Text;
            NuevoInsumo[7] = Convert.ToDecimal(TxtCantmin.Text, CultureInfo.InvariantCulture);
            _I.EditarInsumo_GI(NuevoInsumo);
            Response.Redirect(Request.RawUrl);

        }
        public void ChckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                Label2.InnerText = "Pack de  ";
                TxtCantUn.Visible = true;
                Label3.InnerText = DDLFC.SelectedItem.ToString() + "s";
            }
            else
            {
                Label2.InnerText = "Pack  ";
                TxtCantUn.Visible = false;
                TxtCantUn.Text = "1";
                Label3.InnerText = "";
            }
        }
    }
}