using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace ProyectoMesonURP
{
    public partial class Manejar_Stock_Prueba : System.Web.UI.Page
    {
        CTR_Receta ctr_receta;
        DataTable dtPlatoFondo,dtEntrada,dtSopa;
        static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_receta = new CTR_Receta();
            
            if (!Page.IsPostBack)
            {
                dtPlatoFondo = ctr_receta.CTR_Consultar_Recetas_X_Categoria(1);
                dtEntrada = ctr_receta.CTR_Consultar_Recetas_X_Categoria(2);
                dtSopa = ctr_receta.CTR_Consultar_Recetas_X_Categoria(3);
                //---------------------------------------------------------
                gvPlatoFondo.DataSource = dtPlatoFondo;
                gvPlatoFondo.DataBind();
                //---------------------------------------------------------
                dtEntrada.Merge(dtSopa);
                gvEntrada.DataSource = dtEntrada;
                gvEntrada.DataBind();
            }

        }




        protected void gvPlatoFondo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "TransformarI")
            {
                int idReceta = Convert.ToInt32(gvPlatoFondo.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_idReceta"].ToString());
                Session.Add("idReceta", idReceta);
                Response.Redirect("Transformar_Insumo.aspx");

            }
            else if (e.CommandName == "SeleccionarPlato")
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
            }
        }

        protected void gvEntrada_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarEntrada")
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
            }
        }

        protected void gvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void txtNumRaciones_TextChanged(object sender, EventArgs e)
        {
            //int racion = Convert.ToInt32(txtNumRaciones.Text);
            //DTO_IngredienteXReceta a = new CTR_IngredienteXReceta().CTR_Consultar_IngredienteXReceta(1,5);
            //gvPlatoFondo.DataSource = ctr_receta.CTR__Consultar_Recetas_Disponibles(racion);
            //gvPlatoFondo.DataBind();
            //int racionss = 1 + 1;

        }
    }  
}