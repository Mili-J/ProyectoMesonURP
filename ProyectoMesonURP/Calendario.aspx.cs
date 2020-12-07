using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class Calendario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            int M = Convert.ToInt32(DrpMonth.SelectedValue);
            Calendar1.TodaysDate = new DateTime(2020, M, 01);
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {




            // Change the background color of the days in the month
            // to yellow.
            if (e.Day.IsOtherMonth)
            {
                e.Cell.Text = String.Empty;
                e.Cell.Height = 0;
                e.Cell.CssClass = "isOtherMonth";
            }




            // Add custom text to cell in the Calendar control.
            if (e.Day.Date.Month == 06)
            {
                if (e.Day.Date.Day == 05)
                {
                    e.Cell.Controls.Add(new LiteralControl("<table style='height:50px;width:100%;'><tr><td style='vertical-align:bottom;padding:5px;'><span class='label label-primary'>Holiday</span></td></tr></table>"));
                    e.Cell.BackColor = System.Drawing.Color.Green;
                    e.Cell.ForeColor = System.Drawing.Color.White;
                }

            }
            if (e.Day.Date.Month == 06)
            {
                if (e.Day.Date.Day == 10)
                {
                    e.Cell.Controls.Add(new LiteralControl("<table style='height:50px;width:100%;'><tr><td style='vertical-align:bottom;padding:5px;'><span class='label label-primary'>Holiday</span></td></tr></table>"));
                    e.Cell.BackColor = System.Drawing.Color.DarkSlateBlue;
                    e.Cell.ForeColor = System.Drawing.Color.White;
                }

            }
            if (e.Day.Date.Month == 06)
            {
                if (e.Day.Date.Day == 07)
                {
                    e.Cell.Controls.Add(new LiteralControl("<table style='height:50px;width:100%;'><tr><td style='vertical-align:bottom;padding:5px;'><span class='label label-primary'>Holiday</span></td></tr></table>"));
                    e.Cell.BackColor = System.Drawing.Color.DarkMagenta;
                    e.Cell.ForeColor = System.Drawing.Color.White;
                }

            }
            if (e.Day.Date.Month == 06)
            {
                if (e.Day.Date.Day == 30)
                {
                    e.Cell.Controls.Add(new LiteralControl("<table style='height:50px;width:100%;'><tr><td style='vertical-align:bottom;padding:5px;'><span class='label label-primary'>Holiday</span></td></tr></table>"));
                    e.Cell.BackColor = System.Drawing.Color.DarkOrchid;
                    e.Cell.ForeColor = System.Drawing.Color.White;
                }

            }
            if (e.Day.Date.Month == 06)
            {
                if (e.Day.Date.Day == 22)
                {
                    e.Cell.Controls.Add(new LiteralControl("<table style='height:50px;width:100%;'><tr><td style='vertical-align:bottom;padding:5px;'><span class='label label-primary'>Holiday</span></td></tr></table>"));
                    e.Cell.BackColor = System.Drawing.Color.DeepPink;
                    e.Cell.ForeColor = System.Drawing.Color.White;
                }

            }

        }
    }
}