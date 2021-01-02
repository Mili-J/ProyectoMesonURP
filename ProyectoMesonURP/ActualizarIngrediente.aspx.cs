using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

namespace ProyectoMesonURP
{
    public partial class ConsultarIngrediente : System.Web.UI.Page
    {
        DTO_Ingrediente DTOIngrediente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DTOIngrediente = new DTO_Ingrediente();
                DTOIngrediente = (DTO_Ingrediente)Session["Ingrediente"];
                Llenar(DTOIngrediente);
                LoadCategoriaI();
                LoadEquivalencia();
            }
        }

        public void Llenar(DTO_Ingrediente objIngrediente)
        {
           
            txtIngrediente.Text = objIngrediente.I_nombreIngrediente;
            txtPesoUnitario.Text = objIngrediente.I_pesoUnitario.ToString();
            txtCantidad.Text = objIngrediente.I_cantidad.ToString();
            txtInsumo.Text = objIngrediente.I_nombreInsumo;
            txtEquivalencia.Text = objIngrediente.equivalencia;
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
            ddlEquivalencia.DataTextField = "Equival";
            ddlEquivalencia.DataValueField = "E_idEquivalencia";
            ddlEquivalencia.DataSource = dtEquivalencia;
            ddlEquivalencia.DataBind();
            ddlEquivalencia.Items.Insert(0, "Seleccione");

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
            DTO_Ingrediente objIngrediente = new DTO_Ingrediente();
            DTOIngrediente = (DTO_Ingrediente)Session["Ingrediente"];
            objIngrediente.I_nombreIngrediente= txtIngrediente.Text;
            objIngrediente.I_pesoUnitario = Convert.ToDecimal(txtPesoUnitario.Text);
            objIngrediente.I_cantidad= Convert.ToDecimal(txtCantidad.Text);
            if(ddlInsumo.SelectedValue!="") objIngrediente.I_idInsumo = int.Parse(ddlInsumo.SelectedValue);
            else objIngrediente.I_idInsumo = DTOIngrediente.I_idInsumo;
            //if ( ddlEquivalencia.SelectedValue=="Seleccione") objIngrediente.E_idEquivalencia = DTOIngrediente.E_idEquivalencia;
            //else objIngrediente.E_idEquivalencia = int.Parse(ddlEquivalencia.SelectedValue);            
            objIngrediente.I_idIngrediente = DTOIngrediente.I_idIngrediente;
            CTR_Ingrediente CTRIngre = new CTR_Ingrediente();
            CTRIngre.ActualizarIngrediente(objIngrediente);
            lblMsj.Text = "Informacion actualizada correctamente";
        }
       
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gestionar Ingrediente.aspx");
        }
    }
}