using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace ProyectoMesonURP
{
    public partial class AgregarIngrediente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                LoadCategoriaI();
                LoadEquivalencia();
            }
            
        }

        public void LoadCategoriaI()
        {
            CTR_CategoriaInsumo objCatInsumo = new CTR_CategoriaInsumo();
            DataSet dsCatInsumo = new DataSet();
            dsCatInsumo = objCatInsumo.CTR_SelectCategoriaI();
            ddlCategoria.DataTextField = "CI_nombreCategoria";
            ddlCategoria.DataValueField = "CI_idCategoriaInsumo";
            ddlCategoria.DataSource = dsCatInsumo;
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, "Seleccione");
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
            ddlInsumo.Items.Insert(0, "Seleccione");
        }
        public void LoadEquivalencia()
        {
            DataTable dtEquivalencia = new DataTable();
            CTR_Equivalencia objEquival = new CTR_Equivalencia();
            dtEquivalencia = objEquival.ListaEquivalencias();
            dtEquivalencia.Columns.Add("Equival", typeof(string), "1 + M_nombreMedida + E_cantidad + FCO_nombreFormatoCocina");
            ddlEquivalencia.DataTextField ="Equival";
            ddlEquivalencia.DataValueField = "E_idEquivalencia";
            ddlEquivalencia.DataSource = dtEquivalencia;
            ddlEquivalencia.DataBind();
            ddlEquivalencia.Items.Insert(0, "Seleccione");

        }
        protected void btnAñadirIngrediente_Click(object sender, EventArgs e)
        {
            DTO_Ingrediente objIngrediente = new DTO_Ingrediente();
            objIngrediente.I_nombreIngrediente = txtIngrediente.Text;
            objIngrediente.I_pesoUnitario = Convert.ToDecimal(txtPesoUnitario.Text);
            objIngrediente.I_cantidad = Convert.ToDecimal(txtCantidad.Text);
            objIngrediente.I_idInsumo = int.Parse(ddlInsumo.SelectedValue);
            //objIngrediente.E_idEquivalencia = int.Parse(ddlEquivalencia.SelectedValue);
            CTR_Ingrediente CTRIngrediente = new CTR_Ingrediente();
            CTRIngrediente.InsertarIngrediente(objIngrediente);

        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gestionar Ingrediente.aspx");
        }

        protected void ddlInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
          
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

        protected void ddlEquivalencia_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}