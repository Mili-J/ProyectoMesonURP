using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;
using System.Data.Sql;

namespace ProyectoMesonURP
{
    public partial class MenuDelDia : System.Web.UI.Page
    {
        CTR_Receta ctr_receta;
        DataTable dtPlatoFondo, dtEntrada;
        static DataTable dt;
        static bool sEntrada, sSegundo;

  
        protected void gvEntrada_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarEntrada"&&sEntrada==true)
            {
                if (dt.Rows.Count == 0)
                {
                    dt.Columns.Add("R_nombreReceta");
                    dt.Columns.Add("NumRaciones");
                }
                DataRow dr = dt.NewRow();
                dr[0] = gvEntrada.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_nombreReceta"].ToString();
                dr[1] = txtNumRaciones.Text;
                dt.Rows.Add(dr);
                gvMenu.DataSource = dt;
                gvMenu.DataBind();
                sEntrada = false;
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alertaRechazado", "alertaRechazado('Se ha logrado ingresar correctamente');", true);
            }
        }

        protected void gvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName== "QuitarReceta")
            {
                
            }
        }

        //protected void txtNumRaciones_TextChanged(object sender, EventArgs e)
        //{
        //    int racion = Convert.ToInt32(txtNumRaciones.Text);
        //    //DTO_IngredienteXReceta a = new CTR_IngredienteXReceta().CTR_Consultar_IngredienteXReceta(1,5);
        //    gvPlatoFondo.DataSource = ctr_receta.CTR__Consultar_Recetas_Disponibles(racion,2);
        //    gvPlatoFondo.DataBind();
        //    //-------
        //    gvEntrada.DataSource = ctr_receta.CTR__Consultar_Recetas_Disponibles(racion, 1);
        //    gvEntrada.DataBind();
        //}

        protected void gvMenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            dt.Rows.RemoveAt(e.RowIndex);
            gvMenu.DataSource = dt;
            gvMenu.DataBind();
            sEntrada = true;
            sSegundo = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_receta = new CTR_Receta();

            if (!Page.IsPostBack)
            {
                dtEntrada = ctr_receta.CTR_Consultar_Recetas_X_Categoria_Seleccionada(1);
                dtPlatoFondo = ctr_receta.CTR_Consultar_Recetas_X_Categoria_Seleccionada(2);
                //---------------------------------------------------------
                gvPlatoFondo.DataSource = dtPlatoFondo;
                gvPlatoFondo.DataBind();
                //---------------------------------------------------------
                gvEntrada.DataSource = dtEntrada;
                gvEntrada.DataBind();
                sEntrada = true;
                sSegundo = true;
                dt = new DataTable();
            }
        }

        protected void gvPlatoFondo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarPlato"&&sSegundo==true)
            {
                  if (dt.Rows.Count == 0)
                   {
                    dt.Columns.Add("R_nombreReceta");
                    dt.Columns.Add("NumRaciones");
                   }
                DataRow dr = dt.NewRow();
                dr[0] = gvPlatoFondo.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_nombreReceta"].ToString();
                dr[1] = txtNumRaciones.Text;
                dt.Rows.Add(dr);
                gvMenu.DataSource = dt;
                gvMenu.DataBind();
                sSegundo = false;
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alertaRechazado", "alertaRechazado('Se ha logrado ingresar correctamente');", true);
            }
        }
    }
}