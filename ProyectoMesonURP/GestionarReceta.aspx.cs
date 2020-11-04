using CTR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class GestionarReceta : System.Web.UI.Page
    {
        CTR_Receta _Cr = new CTR_Receta();

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarReceta();
            
        }
        protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {

        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
        protected void rbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
        
        }
        protected void rbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void fNombreReceta_TextChanged(object sender, EventArgs e)
        {
            
                CargarReceta();
            
        }
        public void CargarReceta()
        {
            Repeater1.DataSource = _Cr.CargarRecetaxNombre(txtBuscarReceta.Text);
            Repeater1.DataBind();
        }
    }
}