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

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CalendariaMenu.aspx");
        }
    }
}