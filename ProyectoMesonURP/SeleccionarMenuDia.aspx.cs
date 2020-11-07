using System;
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

namespace ProyectoMesonURP
{
    public partial class SeleccionarMenuDia : System.Web.UI.Page
    {
        CTR_Receta ctr_receta;
        CTR_Menu ctr_menu;
        DTO_Menu dto_menu;       
        CTR_MenuXReceta ctr_menuxreceta;
        DTO_MenuXReceta dto_menuxrecetaEntrada,dto_menuxrecetaFondo;

        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_receta = new CTR_Receta();
            ctr_menuxreceta = new CTR_MenuXReceta();
            dto_menu = new DTO_Menu();
            ctr_menu = new CTR_Menu();
            if (!IsPostBack)
            {

                
        
                string fecha = Session["fecha"].ToString();
                txtFecha.Text = fecha;
                //-----------------------------------
                DdlEntrada.DataValueField = "R_idReceta";
                DdlEntrada.DataTextField = "R_nombreReceta";
                DdlEntrada.DataSource = ctr_receta.CTR_Consultar_Recetas_X_Categoria_Seleccionada(1);
                DdlEntrada.DataBind();
                //-----------------------------------
                DdlFondo.DataValueField = "R_idReceta";
                DdlFondo.DataTextField = "R_nombreReceta";
                DdlFondo.DataSource = ctr_receta.CTR_Consultar_Recetas_X_Categoria_Seleccionada(2);
                DdlFondo.DataBind();
                //-----------------------------------
                reapeterEntradas.DataSource= ctr_receta.CTR_Consultar_Recetas_X_Categoria_Seleccionada(1);
                reapeterEntradas.DataBind();
                //-----------------------------------
                repeaterFondo.DataSource = ctr_receta.CTR_Consultar_Recetas_X_Categoria_Seleccionada(2);
                repeaterFondo.DataBind();

                //byte[]  aa = File.ReadAllBytes("C:/Users/Carlos Lau/Desktop/Recetas/pescadofrito.jpg");
                //ctr_receta.pruebaa(aa,1);

                //byte[] ab = File.ReadAllBytes("C:/Users/Carlos Lau/Desktop/Recetas/arrozconpollo.jpg");
                //ctr_receta.pruebaa(ab, 4);
                //byte[] ac = File.ReadAllBytes("C:/Users/Carlos Lau/Desktop/Recetas/causalimeniaweb.jpg");
                //ctr_receta.pruebaa(ac, 5);
                //byte[] ad = File.ReadAllBytes("C:/Users/Carlos Lau/Desktop/Recetas/Sopa-de-pollo.jpg");
                //ctr_receta.pruebaa(ad, 6);
                //byte[] ae = File.ReadAllBytes("C:/Users/Carlos Lau/Desktop/Recetas/lomo-saltado-3.jpg");
                //ctr_receta.pruebaa(ae, 7);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            dto_menu.ME_fechaMenu = Convert.ToDateTime(txtFecha.Text);
            dto_menu.ME_numRaciones = Convert.ToInt32(txtNumRaciones.Text);
            ctr_menu.CTR_RegistrarMenu(dto_menu);
            int id = ctr_menu.CTR_IdMenuMayor();
            //--------------------------------------
            dto_menuxrecetaEntrada = new DTO_MenuXReceta();
            dto_menuxrecetaEntrada.ME_idMenu = id;
            dto_menuxrecetaEntrada.R_idReceta = int.Parse(DdlEntrada.SelectedValue);
            ctr_menuxreceta.CTR_RegistrarMenuXReceta(dto_menuxrecetaEntrada);
            //--------------------------------------
            dto_menuxrecetaFondo = new DTO_MenuXReceta();
            dto_menuxrecetaFondo.ME_idMenu = id;
            dto_menuxrecetaFondo.R_idReceta = int.Parse(DdlFondo.SelectedValue);
            ctr_menuxreceta.CTR_RegistrarMenuXReceta(dto_menuxrecetaFondo);
            //--------------------------------------
            Response.Redirect("CalendariaMenu.aspx");
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