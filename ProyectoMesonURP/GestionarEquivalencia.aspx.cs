using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace ProyectoMesonURP
{
    public partial class GestionarEquivalencia : System.Web.UI.Page
    {
        CTR_Ingrediente _Ci = new CTR_Ingrediente();
        DTO_Ingrediente _Di = new DTO_Ingrediente();
        CTR_CategoriaInsumo objCatInsumo;
        DataSet dsCatInsumo;
        protected void Page_Load(object sender, EventArgs e)
        {                     
            if (!IsPostBack)
            {
                LlenarGVEquivalencias();
                LoadCategoriaI();
                ListItem ddl1 = new ListItem("5", "5");
                ddlp.Items.Insert(0, ddl1);
                ListItem ddl2 = new ListItem("10", "10");
                ddlp.Items.Insert(1, ddl2);
                ListItem ddl3 = new ListItem("20", "20");
                ddlp.Items.Insert(2, ddl3);
            }
        }
        public void LlenarGVEquivalencias()
        {
            gvEquivalencia.DataSource = _Ci.CTR_Consultar_Ingrediente(txtBuscarIngrediente.Text);
            gvEquivalencia.DataBind();
        }

        
        protected void GVEquivalencia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "VerEquivalencia" )
            {
               
            }
            else if (e.CommandName == "EditarEquivalencia")
            {

            }
            else if (e.CommandName == "AgregarEquivalencia")
            {
                int idIngrediente = Convert.ToInt32(gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_idIngrediente"].ToString());
                Session["idIngrediente"] = idIngrediente;

                string insumo = gvEquivalencia.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                Session["insumo"] = insumo;
                string ingrediente = gvEquivalencia.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
                Session["ingrediente"] = ingrediente;

                Response.Redirect("AgregarEquivalencia");
            }

        }
        protected void fnombreIng_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnVerIngredientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarIngrediente");
        }
        protected void fnombreEq1_TextChanged(object sender, EventArgs e)
        {
            
        }
        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void LoadCategoriaI()
        {
            objCatInsumo = new CTR_CategoriaInsumo();
            dsCatInsumo = new DataSet();
            dsCatInsumo = objCatInsumo.CTR_SelectCategoriaI();
            ddlCategoria.DataTextField = "CI_nombreCategoria";
            ddlCategoria.DataValueField = "CI_idCategoriaInsumo";
            ddlCategoria.DataSource = dsCatInsumo;
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, "--seleccionar--");
        }
        public void LoadInsumo(DTO_CategoriaInsumo objCInsumo)
        {
            DataSet dsInsumo = new DataSet();
            CTR_CategoriaInsumo objCatInsumo = new CTR_CategoriaInsumo();
            dsInsumo = objCatInsumo.CTR_SelectInsumoXCategoria(objCInsumo);
            ddlInsumo.DataTextField = "I_nombreInsumo";
            ddlInsumo.DataValueField = "I_idInsumo";
            ddlInsumo.DataSource = dsInsumo;
            ddlInsumo.DataBind();
            ddlInsumo.Items.Insert(0, "--seleccionar--");
        }
        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoria.SelectedValue != "")
            {
                DTO_CategoriaInsumo objCatInsumo = new DTO_CategoriaInsumo();
                objCatInsumo.CI_idCategoriaInsumo = int.Parse(ddlCategoria.SelectedValue);

                if (objCatInsumo.CI_idCategoriaInsumo != 0)
                {
                    LoadInsumo(objCatInsumo);
                }
            }
        }

        protected void btnAñadirIngrediente_Click(object sender, EventArgs e)
        {
            int a = 0;
            _Di.I_nombreIngrediente = txtIngrediente.Text;
            _Di.I_pesoUnitario = Convert.ToDecimal(txtPesoU.Text);
            _Di.I_cantidad = Convert.ToDecimal(txtCantidad.Text);
            _Di.I_idInsumo = Convert.ToInt16(ddlInsumo.SelectedValue);

            bool vc = _Ci.CTR_ExisteIngrediente(_Di);
            if (vc)
            {
                ClientScript.RegisterStartupScript(
                this.GetType(), "myalert", "myalert('" + "Ya existe un ingrediente con el nombre" + "');", true);
                a = 1;
            }
            if (a == 0)
            {
                if (txtIngrediente.Text != "" && ddlInsumo.SelectedValue != "")
                {
                    _Di.I_nombreIngrediente = txtIngrediente.Text;
                    _Di.I_pesoUnitario = Convert.ToDecimal(txtPesoU.Text);
                    _Di.I_cantidad = Convert.ToDecimal(txtCantidad.Text);
                    _Di.I_idInsumo = Convert.ToInt16(ddlInsumo.SelectedValue);
                    _Ci.InsertarIngrediente(_Di);
                    ClientScript.RegisterStartupScript(Page.GetType(), "myalertCorrecto", "myalertCorrecto('El ingrediente fue registrado correctamente');", true);
                }
            }
        }
    } 
}
