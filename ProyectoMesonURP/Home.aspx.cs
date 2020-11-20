using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["x"] != null)
                {
                    int valor = Convert.ToInt32(Request.QueryString["x"]);
                    switch (valor)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                    }
                }
            }
        }
    }
}