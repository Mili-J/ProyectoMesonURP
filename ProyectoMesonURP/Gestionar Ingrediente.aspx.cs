using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;

namespace ProyectoMesonURP
{
    public partial class Gestionar_Ingrediente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LlenarGVIngredientes();
            }

        }
        public void LlenarGVIngredientes()
        {
            CTR_Ingrediente objIngrediente = new CTR_Ingrediente();
            DataTable dtIngrediente = new DataTable();
            dtIngrediente = objIngrediente.ListarIngredientes();
            gvIngrediente.DataSource = dtIngrediente;
            gvIngrediente.DataBind();

        }
        protected void GVIngrediente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarEquivalencia")
            {
            }
        }   
    }
}