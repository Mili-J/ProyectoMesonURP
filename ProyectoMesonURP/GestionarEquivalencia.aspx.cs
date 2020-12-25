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
        protected void Page_Load(object sender, EventArgs e)
        {                     
            if (!IsPostBack)
            {
                LlenarGVEquivalencias();

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

        protected void btnAnadirEquivalencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEquivalencia");
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
                Response.Redirect("ConsultarEquivalencia");
               
            }
            else if (e.CommandName == "EditarEquivalencia")
            {

                string insumo = gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_nombreInsumo"].ToString();
                int  idI = ObtenerIDInsumo(insumo);
                int idEquival = ObtenerIDEquivalencia(insumo);
                string medida = gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["M_nombreMedida"].ToString();
                int idM = ObtenerIDMedida(medida);
                string cantidad = gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["E_cantidad"].ToString();
                string fcocina = gvEquivalencia.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["FCO_nombreFormatoCocina"].ToString();
                Session.Add("Equivalencia", LlenarDatosEquivalencia(insumo, medida, cantidad, fcocina));
                Session.Add("idInsumo",idI);
                Session.Add("idMedida", idM);
                Session.Add("idEquivalencia", idEquival);
                Response.Redirect("ActualizarEquivalencia");
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
        public string[] LlenarDatosEquivalencia(string i, string m, string c, string fc)
        {
            string[] Equivalencia = new string[4];
            Equivalencia[0] = i;
            Equivalencia[1] = m;
            Equivalencia[2] = c;
            Equivalencia[3] = fc;
            
            return Equivalencia;
        }
        public int ObtenerIDInsumo(string nomInsumo)
        {
            string nombreInsumo = "";
            int idInsumo = 0;

            CTR_Equivalencia objEquivalencia = new CTR_Equivalencia();
            DataTable dtEquivalencia = new DataTable();
            dtEquivalencia = objEquivalencia.ListaEquivalencias();

            foreach (DataRow row in dtEquivalencia.Rows)
            {
                nombreInsumo = row["I_nombreInsumo"].ToString();
                if (nombreInsumo == nomInsumo)
                {
                    return idInsumo = int.Parse(row["I_idInsumo"].ToString());
                }
            }


            return 0;
        }
        public int ObtenerIDMedida(string nomMedida)
        {
            string nombreMedida = "";
            int idMedida = 0;

            CTR_Equivalencia objEquivalencia = new CTR_Equivalencia();
            DataTable dtEquivalencia = new DataTable();
            dtEquivalencia = objEquivalencia.ListaEquivalencias();

            foreach (DataRow row in dtEquivalencia.Rows)
            {
                nombreMedida = row["M_nombreMedida"].ToString();
                if (nombreMedida == nomMedida)
                {
                    return idMedida = int.Parse(row["M_idMedida"].ToString());
                }
            }


            return 0;
        }

        public int ObtenerIDEquivalencia(string nomInsumo)
        {
            string nombreInsumo = "";
            int idEquival = 0;

            CTR_Equivalencia objEquivalencia = new CTR_Equivalencia();
            DataTable dtEquivalencia = new DataTable();
            dtEquivalencia = objEquivalencia.ListaEquivalencias();

            foreach (DataRow row in dtEquivalencia.Rows)
            {
                nombreInsumo = row["I_nombreInsumo"].ToString();
                if (nombreInsumo == nomInsumo)
                {
                    return idEquival = int.Parse(row["E_idEquivalencia"].ToString());
                }
            }


            return 0;
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
    } 
}
