using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ProyectoMesonURP
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Home", "Home", "~/Home.aspx", true);
            routes.MapPageRoute("Login", "Login", "~/Login.aspx", true);
            routes.MapPageRoute("Dashboard", "Dashboard", "~/Dashboard.aspx", true);
            routes.MapPageRoute("ManejarStock", "ManejarStock", "~/ManejarStock.aspx", true);
            routes.MapPageRoute("GestionarReceta", "GestionarReceta", "~/GestionarReceta.aspx", true);
            routes.MapPageRoute("RegistrarReceta", "RegistrarReceta", "~/RegistrarReceta.aspx", true);
            routes.MapPageRoute("ActualizarReceta", "ActualizarReceta", "~/ActualizarReceta.aspx", true);
            routes.MapPageRoute("TransformarInsumo", "TransformarInsumo", "~/Transformar_Insumo.aspx", true);
            routes.MapPageRoute("CalendarioMenu", "CalendarioMenu", "~/CalendariaMenu.aspx", true);
            routes.MapPageRoute("ElegirRecetaTransformar", "ElegirRecetaTransformar", "~/SeleccionarMenuTransformar.aspx", true);
            routes.MapPageRoute("SeleccionarMenu", "SeleccionarMenu", "~/SeleccionarMenuDia.aspx", true);
            routes.MapPageRoute("GenerarOC", "GenerarOC", "~/GenerarOC.aspx", true);
            routes.MapPageRoute("GestionarCotizacion", "GestionarCotizacion", "~/GestionarCotizacion.aspx", true);
            routes.MapPageRoute("GestionarEquivalencia", "GestionarEquivalencia", "~/GestionarEquivalencia.aspx", true);
            routes.MapPageRoute("AgregarEquivalencia", "AgregarEquivalencia", "~/AgregarEquivalencia.aspx", true);
            routes.MapPageRoute("ActualizarEquivalencia", "ActualizarEquivalencia", "~/ActualizarEquivalencia.aspx", true);
            routes.MapPageRoute("AgregarIngrediente", "AgregarIngrediente", "~/AgregarIngrediente.aspx", true);
            routes.MapPageRoute("ActualizarIngrediente", "ActualizarIngrediente", "~/ActualizarIngrediente.aspx", true);
            routes.MapPageRoute("GestionarIngrediente", "GestionarIngrediente", "~/GestionarIngrediente.aspx", true);
            routes.MapPageRoute("ConsultarEquivalencia", "ConsultarEquivalencia", "~/ConsultarEquivalencia.aspx", true);
            routes.MapPageRoute("ActualizarDíaMenú", "ActualizarDíaMenú", "~/ActualizarMenuDia.aspx", true);

        }
    }
}