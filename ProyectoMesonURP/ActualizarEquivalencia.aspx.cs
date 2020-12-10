using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;

namespace ProyectoMesonURP
{
    public partial class ActualizarEquivalencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LLenarDatosE();
            
           
        }

        public void llenarDDLFormatoC()
        {
            DataSet dsFormatoC = new DataSet();
            CTR_Ingrediente objIngrediente = new CTR_Ingrediente();
            dsFormatoC = objIngrediente.ListarFCocina();
            ddlFormatoCocina.DataTextField = "FCO_nombreFormatoCocina";
            ddlFormatoCocina.DataValueField = "FCO_idFormatoCocina";
            ddlFormatoCocina.DataSource = dsFormatoC;
            ddlFormatoCocina.DataBind();
            ddlFormatoCocina.Items.Insert(0, "Seleccione");
        }
        public void LLenarDatosE()
        {
            string[] E = new string[4];
            E= (string[])Session["Equivalencia"];
            txtInsumo.Text = E[0];
            txtMedida.Text = E[1];       
            txtCantidad.Text = E[2];
            lblFormatoC.Text = E[3];
            
        }
        protected void ddlFormatoC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}