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
    public partial class AgregarEquivalencia : System.Web.UI.Page
    {
        CTR_MedidaXFormatoCocina objFormatoC = new CTR_MedidaXFormatoCocina();
        CTR_Ingrediente objIngrediente = new CTR_Ingrediente();
        static int id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFCocina();
                LoadIngrediente();
            }
            
        }
        public void LoadIngrediente()
        {
            txtInsumo.Text = Convert.ToString(Session["insumo"]);
            txtIngrediente.Text = Convert.ToString(Session["ingrediente"]);
        }
        public void LoadFCocina()
        {
            ddlFormatoCocina.DataSource = objIngrediente.ListarFCocina();
            ddlFormatoCocina.DataTextField = "FCO_nombreFormatoCocina";
            ddlFormatoCocina.DataValueField = "FCO_idFCocina";
            ddlFormatoCocina.DataBind();
            ddlFormatoCocina.Items.Insert(0, "--seleccionar--");
        }
        public void ListarMedidaXFormatoCocina(DTO_MedidaXFormatoCocina objFCocina)
        {
            ddlMedida.DataSource = objFormatoC.ListarIDMedidaXFCocina(objFCocina);
            ddlMedida.DataTextField = "M_nombreMedida";
            ddlMedida.DataValueField = "M_idMedida";
            ddlMedida.DataBind();
            ddlMedida.Items.Insert(0, "--seleccionar--");
        }
        protected void ddlFormatoCocina_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (ddlFormatoCocina.SelectedValue != "")
            {
                DTO_MedidaXFormatoCocina objFCocina = new DTO_MedidaXFormatoCocina();
                objFCocina.FCO_idFCocina = int.Parse(ddlFormatoCocina.SelectedValue);

                if (objFCocina.FCO_idFCocina != 0)
                {
                    ListarMedidaXFormatoCocina(objFCocina);
                } 
            }
        }
        protected void btnAñadirEquivalencia_Click(object sender, EventArgs e)
        {
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarEquivalencia.aspx");
        }
        protected void gvEquivalencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = Convert.ToInt32(gvEquivalencia.SelectedRow.RowIndex);
            lblIndex.Text = id.ToString();

        }
        protected void gvEquivalencia_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvEquivalencia, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Haga click para seleccionar la fila.";
                id = e.Row.RowIndex;
            }
        }

    }
   
}   
