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
        CTR_CategoriaReceta ctr_cat_receta;
        DataTable dtPlatoFondo, dtEntrada;
        DTO_CategoriaReceta dto_cat_receta;
        static DataTable dt;
        static bool sEntrada, sSegundo;



        protected void gvEntrada_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarEntrada"&&sEntrada==true)
            {
                
                int i = Convert.ToInt32(gvEntrada.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_idReceta"].ToString());
                string nombre= gvEntrada.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_nombreReceta"].ToString();
              
                LLenarDataTable(i, nombre,1);
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

        protected void txtNumRaciones_TextChanged(object sender, EventArgs e)
        {
            int racion = Convert.ToInt32(txtNumRaciones.Text);
            //DTO_IngredienteXReceta a = new CTR_IngredienteXReceta().CTR_Consultar_IngredienteXReceta(1,5);
            gvPlatoFondo.DataSource = ctr_receta.CTR__Consultar_Recetas_Disponibles(racion,2);
            gvPlatoFondo.DataBind();
            //-------
            gvEntrada.DataSource = ctr_receta.CTR__Consultar_Recetas_Disponibles(racion, 1);
            gvEntrada.DataBind();
        }

        protected void gvMenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string cat = gvMenu.Rows[e.RowIndex].Cells[2].Text;
            if (cat == "Entradas" || cat=="Sopas")sEntrada = true;
            else if(cat=="Segundos")sSegundo = true;
            dt.Rows.RemoveAt(e.RowIndex);
            gvMenu.DataSource = dt;
            gvMenu.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_receta = new CTR_Receta();
            ctr_cat_receta = new CTR_CategoriaReceta();

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
                int i= Convert.ToInt32(gvPlatoFondo.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_idReceta"].ToString());
                string nombre= gvPlatoFondo.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_nombreReceta"].ToString();
                LLenarDataTable(i,nombre,2);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alertaRechazado", "alertaRechazado('Se ha logrado ingresar correctamente');", true);
            }
        }
        public void LLenarDataTable(int id, string nombre,int caso)
        {
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("R_idReceta");
                dt.Columns.Add("R_nombreReceta");
                dt.Columns.Add("NumRaciones");
                dt.Columns.Add("CR_nombreCatgoria");
            }
            DataRow dr = dt.NewRow();
            dto_cat_receta = ctr_cat_receta.CTR_Consultar_CategoriaXReceta(ctr_receta.CTR_Consultar_Receta(id).CR_idCategoriaReceta);
            dr[0] = id;
            dr[1] = nombre;
            dr[2] = txtNumRaciones.Text;
            dr[3] = dto_cat_receta.CR_nombreCategoria;
            dt.Rows.Add(dr);
            gvMenu.DataSource = dt;
            gvMenu.DataBind();

            if (caso == 1) sEntrada = false;
            else sSegundo = false;
        }
    }
}