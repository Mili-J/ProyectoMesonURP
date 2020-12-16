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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LlenarGVEquivalencias();
            }
        }
        public void LlenarGVEquivalencias()
        {
            CTR_Equivalencia objEquivalencia = new CTR_Equivalencia();
            DataTable dtEquivalencias = new DataTable();
            dtEquivalencias = objEquivalencia.ListaEquivalencias();
            gvEquivalencia.DataSource = dtEquivalencias;
            gvEquivalencia.DataBind();
            ListItem ddl1 = new ListItem("5", "5");
            ddlp.Items.Insert(0, ddl1);
            ListItem ddl2 = new ListItem("10", "10");
            ddlp.Items.Insert(1, ddl2);
            ListItem ddl3 = new ListItem("20", "20");
            ddlp.Items.Insert(2, ddl3);
        }

        protected void btnAnadirEquivalencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEquivalencia.aspx");
        }

        protected void GVEquivalencia_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "VerEquivalencia" )
            {

                string insumo = gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_nombreInsumo"].ToString();
                string medida = gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["M_nombreMedida"].ToString();
                string cantidad = gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["E_cantidad"].ToString();
                string fcocina = gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["FCO_nombreFormatoCocina"].ToString();
                Session.Add("Equivalencia", LlenarDatosEquivalencia(insumo, medida, cantidad, fcocina));

               
            }

        }
        public string[] LlenarDatosEquivalencia(string i, string m, string c, string fc)
        {
            string[] Equivalencia = new string[4];
            Equivalencia[0] = i;
            Equivalencia[1] = m;
            Equivalencia[2] = c;
            Equivalencia[3] = fc;
            return Equivalencia;
        }

  

        protected void fnombreEq_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnVerIngredientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gestionar Ingrediente.aspx");
        }
        protected void fnombreEq1_TextChanged(object sender, EventArgs e)
        {
            
        }
        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    } 
}
