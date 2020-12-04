﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Data.Sql;
using Label = System.Web.UI.WebControls.Label;

namespace ProyectoMesonURP
{
    public partial class SeleccionarMenuDia : System.Web.UI.Page
    {
        CTR_Receta ctr_receta;
        CTR_Menu ctr_menu;
        DTO_Menu dto_menu;
        CTR_MenuXReceta ctr_menuxreceta;
        DTO_MenuXReceta dto_menuxrecetaEntrada, dto_menuxrecetaFondo;
        static bool sEntrada, sSegundo;
        static bool hay;
        static string fecha;
        DTO_Menu objMenu;
        static DataTable dtCarta=new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_receta = new CTR_Receta();
            ctr_menuxreceta = new CTR_MenuXReceta();
            dto_menu = new DTO_Menu();
            ctr_menu = new CTR_Menu();
            objMenu = new DTO_Menu();

            if (Session["Usuario"] == null)
            {
                Response.Redirect("Home.aspx?x=1");
            }
            if (!IsPostBack)
            {

                fecha = Session["fecha"].ToString();
                txtFecha.Text = fecha;
                hay = (bool)Session["hay"];

                //-----------------------------------
                reapeterEntradas.DataSource = ctr_receta.CTR_Consultar_Recetas_X_SubCategoriaYCategoria(1,"Segundos");
                reapeterEntradas.DataBind();
                //-----------------------------------
                repeaterFondo.DataSource = ctr_receta.CTR_Consultar_Recetas_X_SubCategoriaYCategoria(1,"Entradas");
                repeaterFondo.DataBind();
                //-----------------------------------
                repeaterBebida.DataSource = ctr_receta.CTR_Consultar_Recetas_X_SubCategoriaYCategoria(1, "Bebidas");
                repeaterBebida.DataBind();
                //-----------------------------------
                repeaterCarta.DataSource = ctr_receta.CTR_Consultar_Recetas_X_Categoria(2);
                repeaterCarta.DataBind();
                //if (hay)
                //{
                //    objMenu = ctr_menu.CTR_ConsultarMenu(Convert.ToDateTime(fecha));
                //    txtNumRaciones.Text = objMenu.ME_numRaciones.ToString();
                //    DataTable dtmenu = ctr_menuxreceta.CTR_ConsultarRecetasXMenu(objMenu.ME_idMenu);
                //    if (dtmenu.Rows.Count == 0)
                //    {
                //        OcultarEntrada();
                //        OcultarFondo();
                //    }
                //    else
                //    {
                //        int i = 0;
                //        object[] recetas;
                //        DTO_Receta receta;

                //        while (i < dtmenu.Rows.Count)
                //        {
                //            recetas = dtmenu.Rows[i].ItemArray;
                //            receta = ctr_receta.CTR_Consultar_Receta(Convert.ToInt32(recetas[1]));
                //            if (receta.CR_idCategoriaReceta == 2)
                //            {

                //                try
                //                {
                //                    imgFondo.ImageUrl = "data:image;base64," + Convert.ToBase64String(receta.R_imagenReceta);
                //                }
                //                catch (Exception)
                //                {

                //                    imgFondo.AlternateText = "No se ha podido cargar la imagen";
                //                }

                //                lblIdFondo.Visible = false; lblIdFondo.Text = receta.R_idReceta.ToString();
                //                lblNombreFondo.Text = receta.R_nombreReceta;
                //                lblPorcionFondo.Text = receta.R_numeroPorcion.ToString();
                //                lblCatFondo.Text = new CTR_CategoriaReceta().CTR_Consultar_CategoriaXReceta(receta.CR_idCategoriaReceta).CR_nombreCategoria;
                //            }
                //            else
                //            {
                //                try
                //                {
                //                    imgEntrada.ImageUrl = "data:image;base64," + Convert.ToBase64String(receta.R_imagenReceta);
                //                }
                //                catch (Exception)
                //                {

                //                    imgEntrada.AlternateText = "No se ha podido cargar la imagen";
                //                }

                //                lblIdEntrada.Visible = false; lblIdEntrada.Text = receta.R_idReceta.ToString();
                //                lblNombreEntrada.Text = receta.R_nombreReceta;
                //                lblPorcionEntrada.Text = receta.R_numeroPorcion.ToString();
                //                lblCatEntrada.Text = new CTR_CategoriaReceta().CTR_Consultar_CategoriaXReceta(receta.CR_idCategoriaReceta).CR_nombreCategoria;
                //            }
                //            i++;
                //        }


                //        sEntrada = false;
                //        sSegundo = false;
                //        //---------------------}
                //        //---------------------
                //    }
                //}
                //else
                //{
                OcultarEntrada();
                    OcultarFondo();
                //}
            }
        }
        public void OcultarEntrada()
        {
            imgEntrada.Visible = false;
            lblIdEntrada.Visible = false;
            lblNombreEntrada.Visible = false;
            lblPorcionEntrada.Visible = false;
            lblCatEntrada.Visible = false;
            btnQuitarEntrada.Visible = false;
            sEntrada = true;
        }
        public void MostrarEntrada()
        {
            imgEntrada.Visible = true;
            lblIdEntrada.Visible = true;
            lblNombreEntrada.Visible = true;
            lblPorcionEntrada.Visible = true;
            lblCatEntrada.Visible = true;
            btnQuitarEntrada.Visible = true;
            sEntrada = false;
        }
        public void OcultarFondo()
        {
            imgFondo.Visible = false;
            lblIdFondo.Visible = false;
            lblNombreFondo.Visible = false;
            lblPorcionFondo.Visible = false;
            lblCatFondo.Visible = false;
            btnQuitarFondo.Visible = false;
            sSegundo = true;
        }
        public void MostrarFondo()
        {
            imgFondo.Visible = true;
            lblIdFondo.Visible = true;
            lblNombreFondo.Visible = true;
            lblPorcionFondo.Visible = true;
            lblCatFondo.Visible = true;
            btnQuitarFondo.Visible = true;
            sSegundo = false;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(txtNumRaciones.Text)==0)
            //{
            //    revNumRac.ErrorMessage = "No puede ser 0";
            //    revNumRac.ValidationExpression = @"[^0]";
            //}
            //else
            //{
            //    revNumRac.ErrorMessage = "Número inválido";
            //    revNumRac.ValidationExpression = @"\d{1,}";
            //}

            if (hay == false)
            {
                if (sSegundo == false && sEntrada == false)
                {
                    dto_menu.ME_fechaMenu = txtFecha.Text;
                    dto_menu.ME_totalPorcion = Convert.ToInt32(txtNumRaciones.Text);
                    ctr_menu.CTR_RegistrarMenu(dto_menu);
                    int id = ctr_menu.CTR_IdMenuMayor();
                    //--------------------------------------
                    RegistrarMenuXReceta(id);
                    //--------------------------------------
                    Response.Redirect("CalendariaMenu.aspx");

                }
            }
            else if (hay == true)
            {
                if (sSegundo == false && sEntrada == false)
                {
                    DTO_Menu objmenu = ctr_menu.CTR_ConsultarMenu(Convert.ToDateTime(fecha));
                    objmenu.ME_totalPorcion = Convert.ToInt32(txtNumRaciones.Text);
                    DataTable dtMenuReceta = ctr_menuxreceta.CTR_ConsultarRecetasXMenu(objmenu.ME_idMenu);
                    ctr_menu.CTR_ActualizarMenu(objmenu);
                    if (dtMenuReceta.Rows.Count == 2)
                    {
                        dtMenuReceta.Rows[0][1] = Convert.ToInt32(lblIdEntrada.Text);
                        dtMenuReceta.Rows[1][1] = Convert.ToInt32(lblIdFondo.Text);
                        ctr_menuxreceta.CTR_ActualizarMenuXReceta(dtMenuReceta);

                    }
                    else if (dtMenuReceta.Rows.Count == 0)
                    {

                        RegistrarMenuXReceta(objmenu.ME_idMenu);
                    }

                    Response.Redirect("CalendariaMenu.aspx");

                }

            }


        }

        public void RegistrarMenuXReceta(int id)
        {
            dto_menuxrecetaEntrada = new DTO_MenuXReceta();
            dto_menuxrecetaEntrada.ME_idMenu = id;
            dto_menuxrecetaEntrada.R_idReceta = int.Parse(lblIdEntrada.Text);
            ctr_menuxreceta.CTR_RegistrarMenuXReceta(dto_menuxrecetaEntrada);
            //--------------------------------------
            dto_menuxrecetaFondo = new DTO_MenuXReceta();
            dto_menuxrecetaFondo.ME_idMenu = id;
            dto_menuxrecetaFondo.R_idReceta = int.Parse(lblIdFondo.Text);
            ctr_menuxreceta.CTR_RegistrarMenuXReceta(dto_menuxrecetaFondo);
        }
        protected void reapeterEntradas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerEntrada")
            {

            }
            else if (e.CommandName == "AgregarEntrada" && sEntrada == true)
            {
                MostrarEntrada();
                System.Web.UI.WebControls.Label lblIdReceta = e.Item.FindControl("lblIdReceta") as System.Web.UI.WebControls.Label;
                System.Web.UI.WebControls.Label lblNombreReceta = e.Item.FindControl("lblNombreReceta") as System.Web.UI.WebControls.Label;
                System.Web.UI.WebControls.Label lblPorciones = e.Item.FindControl("lblPorciones") as System.Web.UI.WebControls.Label;
                System.Web.UI.WebControls.Label lblCategoria = e.Item.FindControl("lblCategoria") as System.Web.UI.WebControls.Label;
                int id = int.Parse(lblIdReceta.Text);
                byte[] imagen;
                //----------------------
                lblIdEntrada.Text = id.ToString();
                lblNombreEntrada.Text = lblNombreReceta.Text;
                lblPorcionEntrada.Text = "Porción: " + lblPorciones.Text;
                lblCatEntrada.Text = lblCategoria.Text;
                try
                {
                    imagen = ctr_receta.CTR_Consultar_Receta(id).R_imagenReceta;
                    imgEntrada.ImageUrl = "data:image;base64," + Convert.ToBase64String(imagen);
                }
                catch (Exception)
                {

                    imgEntrada.AlternateText = "No se ha podido cargar la imagen";
                }

                sEntrada = false;
                btnQuitarEntrada.Visible = true;
            }
            else if (sEntrada == false)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alertaRechazado", "alertaRechazado('Se ha logrado ingresar correctamente');", true);
            }
        }

        protected void btnQuitarFondo_Click(object sender, EventArgs e)
        {
            OcultarFondo();

        }

        protected void btnQuitarEntrada_Click(object sender, EventArgs e)
        {
            OcultarEntrada();
        }



        protected void repeaterBebida_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void repeaterCarta_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "VerCarta")
            {

            }
            else if (e.CommandName == "AgregarCarta")
            {
                DataRow dr = dtCarta.NewRow();
                int i = int.Parse(((Label)repeaterCarta.Items[e.Item.ItemIndex].FindControl("lblIdReceta")).Text);
                DTO_Receta receta = ctr_receta.CTR_Consultar_Receta(i);
                if (dtCarta.Columns.Count == 0)
                {
                    dtCarta.Columns.Add("R_imagenReceta");
                    dtCarta.Columns.Add("R_idReceta");
                    dtCarta.Columns.Add("R_nombreReceta");
                    dtCarta.Columns.Add("R_numeroPorcion");
                    dtCarta.Columns.Add("CP_nombreCategoriaR");
                }
                dr[0] = receta.R_imagenReceta;
                dr[1] = receta.R_idReceta;
                dr[2] = receta.R_nombreReceta;
                dr[3] = receta.R_numeroPorcion;
                dr[4] = receta.CP_idCategoriaReceta;
                dtCarta.Rows.Add(dr);
                repeaterCartaSeleccionada.DataSource = dtCarta;
                repeaterCartaSeleccionada.DataBind();
            }

        }

        protected void repeaterCartaSeleccionada_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void repeaterFondo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerFondo")
            {

            }
            else if (e.CommandName == "AgregarFondo" && sSegundo == true)
            {
                MostrarFondo();
                System.Web.UI.WebControls.Label lblIdReceta = e.Item.FindControl("lblIdReceta") as System.Web.UI.WebControls.Label;
                System.Web.UI.WebControls.Label lblNombreReceta = e.Item.FindControl("lblNombreReceta") as System.Web.UI.WebControls.Label;
                System.Web.UI.WebControls.Label lblPorciones = e.Item.FindControl("lblPorciones") as System.Web.UI.WebControls.Label;
                System.Web.UI.WebControls.Label lblCategoria = e.Item.FindControl("lblCategoria") as System.Web.UI.WebControls.Label;
                int id = int.Parse(lblIdReceta.Text);
                //----------------------
                lblIdFondo.Text = id.ToString();
                lblNombreFondo.Text = lblNombreReceta.Text;
                lblPorcionFondo.Text = "Porción: " + lblPorciones.Text;
                lblCatFondo.Text = lblCategoria.Text;
                try
                {
                    byte[] imagen = ctr_receta.CTR_Consultar_Receta(id).R_imagenReceta;
                    imgFondo.ImageUrl = "data:image;base64," + Convert.ToBase64String(imagen);
                }
                catch (Exception)
                {

                    imgFondo.AlternateText = "No se ha podido cargar la imagen";
                }

                sSegundo = false;
                btnQuitarFondo.Visible = true;
            }
            else if (sSegundo == false)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alertaRechazado", "alertaRechazado('Se ha logrado ingresar correctamente');", true);
            }
        }

        //protected void btnprueba_Click(object sender, EventArgs e)
        //{          
        //    int i = int.Parse(txtid.Text);
        //    byte[] aa = new byte[1000];
        //            aa = ctr_receta.prueba(i);
        //    string sb64 = Convert.ToBase64String(aa);     
        //    Image1.ImageUrl = "data:image;base64," + sb64;
        //}

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CalendariaMenu.aspx");
        }
    }
}