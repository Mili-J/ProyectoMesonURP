using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using System.Data;

namespace ProyectoMesonURP
{
    public partial class ActualizarMenuDia : System.Web.UI.Page
    {

        CTR_Receta ctr_receta;
        CTR_Menu ctr_menu;
        DTO_Menu dto_menu;
        CTR_MenuXReceta ctr_menuxreceta;
        DTO_MenuXReceta dto_menuxreceta;
        CTR_CategoriaReceta ctr_cat_receta;
        static string fecha;
        DTO_Menu objMenu;
        static DataTable dtCarta = new DataTable();
        static DataTable dtMenu = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_receta = new CTR_Receta();
            ctr_menuxreceta = new CTR_MenuXReceta();
            dto_menu = new DTO_Menu();
            ctr_menu = new CTR_Menu();
            objMenu = new DTO_Menu();
            ctr_cat_receta = new CTR_CategoriaReceta();
            dto_menuxreceta = new DTO_MenuXReceta();
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Home.aspx?x=1");
            }
            if (!IsPostBack)
            {

                fecha = Session["fecha"].ToString();
                txtFecha.Text = fecha;
                //hay = (bool)Session["hay"];
                //---------------------------------
                dto_menu = ctr_menu.CTR_ConsultarMenu(Convert.ToDateTime(fecha));
                int id_menu = dto_menu.ME_idMenu;
                repeaterMenu.DataSource = ctr_receta.CTR_ConsultarMenuXRecetaYCategoria(id_menu,1);
                repeaterMenu.DataBind();

                repeaterCartaSeleccionada.DataSource = ctr_receta.CTR_ConsultarMenuXRecetaYCategoria(id_menu,2);
                repeaterCartaSeleccionada.DataBind();
                //-----------------------------------
                reapeterEntradas.DataSource = ctr_receta.CTR_Consultar_Recetas_X_SubCategoriaYCategoria(1, "Entradas");
                reapeterEntradas.DataBind();
                //-----------------------------------
                repeaterFondo.DataSource = ctr_receta.CTR_Consultar_Recetas_X_SubCategoriaYCategoria(1, "Segundos");
                repeaterFondo.DataBind();
                //-----------------------------------
                repeaterBebida.DataSource = ctr_receta.CTR_Consultar_Recetas_X_SubCategoriaYCategoria(1, "Bebidas");
                repeaterBebida.DataBind();
                //-----------------------------------
                repeaterCarta.DataSource = ctr_receta.CTR_Consultar_Recetas_X_Categoria(2);
                repeaterCarta.DataBind();
                //Ocultar comentarios
                if (true)
                {
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
                    //OcultarEntrada();
                    //    OcultarFondo();
                    //}
                }
            }
        }

        protected void repeaterCartaSeleccionada_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void repeaterCarta_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void repeaterMenu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void reapeterEntradas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void repeaterFondo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void repeaterBebida_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {

        }
    }

}