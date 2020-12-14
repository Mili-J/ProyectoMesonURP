using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class GestionarEquivalencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void fnombreEq_TextChanged(object sender, EventArgs e)
        {
           
        }
        protected void btnEditarEquivalencia_Click(object sender, EventArgs e)
        {

        }
    }
}