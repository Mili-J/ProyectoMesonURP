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
            DateTime date = CalendarioMenu.SelectedDate;
            if (date.ToString("dddd") == "domingo")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alertaError()", true); return;
            }

            else
            {
                string fecha = date.ToShortDateString();
                Session.Add("fecha", date);
              
                if (ctr_menu.CTR_HayMenu(date))
                {
                    hay = true;
                    Session.Add("hay", hay);
                    Response.Redirect("ActualizarMenuDia.aspx");
                }
                else 
                {  
                    hay = false;
                    Session.Add("hay", hay);
                    Response.Redirect("SeleccionarMenu");
                }
                

                
            }
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
            e.Cell.ForeColor = Color.White;
            bool hay = ctr_menu.CTR_HayMenu(fecha);
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
            }
            else if (e.Day.Date<DateTime.Today)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = Color.Gray;
            }
            else if (e.Day.IsToday)
            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#629e6c");
                e.Cell.BackColor = col;
                //e.Cell.BackColor = Color.LightGreen;
                
            }
            else if (e.Day.Date > DateTime.Today)
            {
                //if (hay) e.Cell.BackColor = Color.Orange;
                //else 
                if(!hay)
                {
                    e.Cell.BackColor = Color.White;
                    e.Cell.ForeColor = Color.Gray;

                }
            }
            //--------------------------------------
            if (hay)
            {
                //System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#629e6c");
                //e.Cell.BackColor = col;
                //e.Cell.ForeColor = Color.White;
                if (dto_menu.EM_idEstadoMenu==1)
                {
                    e.Cell.BackColor = Color.MidnightBlue;
                }
                else if(dto_menu.EM_idEstadoMenu == 2)
                {
                    e.Cell.BackColor = Color.Red;
                    e.Day.IsSelectable = false;
                }
               
                DataTable dt = ctr_menuxreceta.CTR_ConsultarRecetasXMenuYCategoria(dto_menu.ME_idMenu,1);
                int i = 0;
                object[] recetas;
                DTO_Receta dto_receta;
                while (i < dt.Rows.Count)
                {
                    recetas = dt.Rows[i].ItemArray;
                    dto_receta = ctr_receta.CTR_Consultar_Receta(Convert.ToInt32(recetas[1]));
                    e.Cell.Controls.Add(new LiteralControl("<hr />" + dto_receta.R_nombreReceta));
                    i++;
                }
                //e.Cell.Controls.Add(new LiteralControl("<hr />" + dto_menu.ME_numRaciones + " raciones"));
            }
        }
    }
}
