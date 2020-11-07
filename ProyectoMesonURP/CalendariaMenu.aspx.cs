using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;
using System.Drawing;

namespace ProyectoMesonURP
{
    public partial class CalendariaMenu : System.Web.UI.Page
    {
        CTR_Menu ctr_menu;
        DTO_Menu dto_menu;
        CTR_MenuXReceta ctr_menuxreceta;
        CTR_Receta ctr_receta;
        bool hay;
        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_menu = new CTR_Menu();
            ctr_menuxreceta = new CTR_MenuXReceta();
            ctr_receta = new CTR_Receta();
            if (!IsPostBack)
            {
                
            }
        }


        protected void CalendarioMenu_SelectionChanged(object sender, EventArgs e)
        {
            string fecha = CalendarioMenu.SelectedDate.ToShortDateString();
            if (ctr_menu.CTR_HayMenu(Convert.ToDateTime(fecha))) hay = true;
            else hay = false;
            Session.Add("fecha",fecha);
            Session.Add("hay",hay);
            Response.Redirect("SeleccionarMenuDia.aspx");
        }

        protected void CalendarioMenu_DayRender(object sender, DayRenderEventArgs e)
        {
            //Aqui se puede cambiar algunas cosas
            DateTime fecha = e.Day.Date;
            dto_menu = new DTO_Menu();
            dto_menu = ctr_menu.CTR_ConsultarMenu(fecha);
            e.Cell.Width = Unit.Pixel(200);
            e.Cell.Height = Unit.Pixel(50);
            e.Cell.BorderWidth = Unit.Pixel(4);
            e.Cell.BorderStyle = BorderStyle.Dotted;
            if (e.Day.IsOtherMonth)
            {
                e.Cell.Visible = false;
            }
            //--------------------------------------
            if (ctr_menu.CTR_HayMenu(fecha))
            {
                DataTable dt = new DataTable();
                dt = ctr_menuxreceta.CTR_ConsultarRecetasXMenu(dto_menu.ME_idMenu);
                int i = 0;
                object[] recetas;
                DTO_Receta dto_receta;
                while (i<dt.Rows.Count)
                {
                    recetas = dt.Rows[i].ItemArray;
                    dto_receta = ctr_receta.CTR_Consultar_Receta(Convert.ToInt32(recetas[1]));

                    e.Cell.Controls.Add(new LiteralControl("<hr />" +dto_receta.R_nombreReceta));
                    i++;
                }
                e.Cell.Controls.Add(new LiteralControl("<hr />" + dto_menu.ME_numRaciones+" raciones"));

            }
          
            
        }
    }
}