using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using DTO2;
using System.Drawing;
using System.Data;

namespace ProyectoMesonURP
{
    public partial class GestionarEquivalencia : System.Web.UI.Page
    {
        CTR_Ingrediente _Ci = new CTR_Ingrediente();
        DTO_Ingrediente _Di = new DTO_Ingrediente();
        DTO_Equivalencia_SP _Desp = new DTO_Equivalencia_SP();
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
        protected void fnombreIng_TextChanged(object sender, EventArgs e)
        {
            LlenarGVEquivalencias();
        }
        protected void gvEquivalencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEquivalencia.PageIndex = e.NewPageIndex;
            LlenarGVEquivalencias();
        }
        protected void GVEquivalencia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            if (e.CommandName == "AgregarEquivalencia")
            {
                int idIngrediente = Convert.ToInt32(gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_idIngrediente"].ToString());
                Session["idIngrediente"] = idIngrediente;

                string insumo = gvEquivalencia.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
                Session["insumo"] = insumo;
                string ingrediente = gvEquivalencia.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
                Session["ingrediente"] = ingrediente;

                Response.Redirect("RegistrarEquivalencia");
            }
            else if (e.CommandName == "VerEquivalencia")
            {
                index = int.Parse(e.CommandArgument.ToString());
                hidden.Value = ((Label)gvEquivalencia.Rows[index].FindControl("lblIdIngrediente")).Text;
                ScriptManager.RegisterStartupScript(this, GetType(), "modal", "$('#myModal').modal('show');", true);
                string id = ((Label)gvEquivalencia.Rows[index].FindControl("lblIdIngrediente")).Text;
                List<DTO_Equivalencia_SP> lista = new CTR_Equivalencia().CTRconsultarDetalleExI(int.Parse(id));
                GridView1.DataSource = lista;
                GridView1.DataBind();
            }
        }
        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvEquivalencia.PageSize = Convert.ToInt32(ddlp.SelectedValue);
            LlenarGVEquivalencias();
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
        protected void gvEquivalencia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal tot = (Literal)e.Row.FindControl("cantidad");
                string total = tot.Text;

                if (total == DBNull.Value.ToString())
                {
                    e.Row.ForeColor = System.Drawing.Color.DarkRed;
                }
                else
                {
                    //e.Row.BackColor = Color.FromName("#ffeb9c");
                    e.Row.ForeColor = System.Drawing.Color.Black;
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
