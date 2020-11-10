﻿using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class GestionarReceta : System.Web.UI.Page
    {
        DTO_Receta _Dr = new DTO_Receta(); 
        CTR_Receta _Cr = new CTR_Receta();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Home.aspx?x=1");
            }
            if (!IsPostBack)
            {
                CargarReceta();
            }
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
            if (e.CommandName == "ActualizarReceta")
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
                

                Response.Redirect("ActualizarReceta");
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
    }
}