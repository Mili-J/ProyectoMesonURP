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
           
            if(!IsPostBack)
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

        }
        protected void btnAnadirEquivalencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEquivalencia.aspx");
        }

        protected void GVEquivalencia_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "EditarEquivalencia" || e.CommandName == "VerEquivalencia")
            {
                
                string insumo = gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_nombreInsumo"].ToString();
                string medida = gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["M_nombreMedida"].ToString();
                string cantidad = gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["E_cantidad"].ToString();
                string fcocina= gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["FCO_nombreFormatoCocina"].ToString();
                Session.Add("Equivalencia", LlenarDatosEquivalencia(insumo, medida, cantidad, fcocina));
                
                if(e.CommandName == "EditarEquivalencia") Response.Redirect("ActualizarEquivalencia.aspx");
                if (e.CommandName == "VerEquivalencia") Response.Redirect("ConsultarEquivalencia.aspx");
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

        protected void btnIngrediente_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gestionar Ingrediente.aspx");
        }

      
    }
}