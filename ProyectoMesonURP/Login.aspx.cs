using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using DTO;
using CTR;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //try 
            //{

            //    DTO_Usuario dto = new DTO_Usuario()
            //    {
            //        U_contraseña = password.Value,
            //        U_codigo = usuario.Value
            //    };
            //    dto = new CTR_Usuario().validarUsuario(dto);
            //    if (dto.P_idPersona != 0)
            //    {
            //        //ENTRO
            //        Session["Usuario"] = dto;
            //        Response.Redirect("Dashboard");
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this.PanelLogin, this.PanelLogin.GetType(), "alertLogin1", "alertLogin1();", true);

            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}

            Response.Redirect("Manejar_Stock_Prueba.aspx");
        }
    }
}
