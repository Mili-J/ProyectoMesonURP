using CTR;
using DTO;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class GestionarReceta : System.Web.UI.Page
    {
        CTR_Receta _Cr = new CTR_Receta();
        CTR_MenuXReceta _Cmxr = new CTR_MenuXReceta();
        public int a = 0;
        string FechaActual = DateTime.Now.ToString("dd/MM/yyyy");

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Usuario"] == null)
            //{
            //    Response.Redirect("Home.aspx?x=1");
            //}
            if (!IsPostBack)
            {
                CargarReceta();
                CargarRecetaTab1();
                CargarRecetaTab2();
                CargarRecetaTab3();
                CargarRecetaTab4();
            }
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
                if (e.CommandName == "ActualizarReceta")
                {
                Label lblidRecet = e.Item.FindControl("lblIdReceta") as Label;
                int IdRecet = Convert.ToInt32(lblidRecet.Text);
                Session["IdRecet"] = IdRecet;

                bool Emxr = _Cmxr.ExistenciaMenuxReceta(IdRecet, FechaActual);
                if (Emxr)
                {
                    a = 1;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alertaError1()", true);
                    return;

                }
                else if (a == 0)
                {
                    Label lblidReceta = e.Item.FindControl("lblIdReceta") as Label;
                    int IdReceta = Convert.ToInt32(lblidReceta.Text);
                    Session["IdReceta"] = IdReceta;

                    Label lblnombre = e.Item.FindControl("lblNombreReceta") as Label;
                    string nombre = lblnombre.Text;
                    Session["nombreReceta"] = nombre;

                    Label lblporciones = e.Item.FindControl("lblPorciones") as Label;
                    int porciones = Convert.ToInt32(lblporciones.Text);
                    Session["porciones"] = porciones;

                    Label lblcategoria = e.Item.FindControl("lblCategoria") as Label;
                    string Categoria = Convert.ToString(lblcategoria.Text);
                    Session["categoria"] = Categoria;

                    Label lbldescripcion = e.Item.FindControl("lblDescripcion") as Label;
                    string Descripcion = Convert.ToString(lbldescripcion.Text);
                    Session["descripcion"] = Descripcion;

                    Response.Redirect("ActualizarReceta");
                }
                
                } 
            if (e.CommandName == "EliminarReceta")
            {
                Label lblidReceta = e.Item.FindControl("lblIdReceta") as Label;
                int IdReceta = Convert.ToInt32(lblidReceta.Text);
                Session["IdReceta"] = IdReceta;
                
                bool Emxr = _Cmxr.ExistenciaMenuxReceta(IdReceta, FechaActual);
                if (Emxr) 
                {
                    a = 1;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alertaError()", true);
                    return;
                    
                }
                else if(a==0){
                    _Cr.EliminarReceta(IdReceta);
                    CargarReceta();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alertaExito()", true);
                    return;
                    
                }
            }
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
        protected void btnRegistrarReceta_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarReceta");
        }
        public void CargarRecetaTab1()
        {
            Repeater2.DataSource = _Cr.CTR_Consultar_RecetaTabEntM();
            Repeater2.DataBind();
        }
        public void CargarRecetaTab2()
        {
            Repeater3.DataSource = _Cr.CTR_Consultar_RecetaTabSegM();
            Repeater3.DataBind();
        }
        public void CargarRecetaTab3()
        {
            Repeater4.DataSource = _Cr.CTR_Consultar_RecetaTabBebM();
            Repeater4.DataBind();
        }
        public void CargarRecetaTab4()
        {
            Repeater5.DataSource = _Cr.CTR_Consultar_RecetaTabCarta();
            Repeater5.DataBind();
        }
    }
}