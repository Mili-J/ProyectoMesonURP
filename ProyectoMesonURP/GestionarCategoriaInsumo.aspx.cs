using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class GestionarCategoriaInsumo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("CI");
                CargarCategorias();
            }
        }

        public void CargarCategorias()
        {
            try
            {
                List<DTO_CategoriaInsumo> list = new CTR_CategoriaInsumo().CTR_ConsultarCategoriasInsumo2();
                Session["CI"] = list;
                GridViewCategoria.DataSource = list;
                GridViewCategoria.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void GridViewCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            if (e.CommandName == "Actualizar")
            {
                index = int.Parse(e.CommandArgument.ToString());
                string id = ((Label)GridViewCategoria.Rows[index].FindControl("lblIdCategoria")).Text;
                List<DTO_Insumo> li = new CTR_Insumo().CTR_ConsultarInsumoXCategoria(int.Parse(id));
                if (li.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertaInsumo", "alertaInsumo()", true);
                    return;
                }
                hidden.Value = id;
                ScriptManager.RegisterStartupScript(this, GetType(), "modal", "$('#modalActualizar').modal('show');", true);
            }
            else if(e.CommandName == "Consultar")
            {
                index = int.Parse(e.CommandArgument.ToString());
                hidden.Value = ((Label)GridViewCategoria.Rows[index].FindControl("lblIdCategoria")).Text;
                ScriptManager.RegisterStartupScript(this, GetType(), "modal", "$('#modalConsultar').modal('show');", true);
                string id = ((Label)GridViewCategoria.Rows[index].FindControl("lblIdCategoria")).Text;
                List<DTO_Insumo> lista = new CTR_Insumo().CTR_ConsultarInsumoXCategoria(int.Parse(id));
                GridViewConsulta.DataSource = lista;
                GridViewConsulta.DataBind();
            }

        }

        protected void btnAgregarCInsumo_Click(object sender, EventArgs e)
        {
            try
            {
                string categoria = txtRegistrarC.Text;
                List<DTO_CategoriaInsumo> list = (List<DTO_CategoriaInsumo>)Session["CI"];
                if (list.Exists(x => x.CI_nombreCategoria == categoria))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertaExistente", "alertaExistente()", true);
                    return;
                }
                DTO_CategoriaInsumo dto = new DTO_CategoriaInsumo
                {
                    CI_nombreCategoria = categoria
                };
                CTR_CategoriaInsumo ctr = new CTR_CategoriaInsumo();
                ctr.DAO_InsertCategoriaInsumo(dto);
                CargarCategorias();
                txtRegistrarC.Text = string.Empty;
                ScriptManager.RegisterStartupScript(this, GetType(), "alertaInsertado", "alertaInsertado()", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(hidden.Value);
               
                DTO_CategoriaInsumo objCategoriaIn = new DTO_CategoriaInsumo();
                objCategoriaIn.CI_idCategoriaInsumo = id;
                objCategoriaIn.CI_nombreCategoria = txtActualizar.Text;               
                CTR_CategoriaInsumo ctr = new CTR_CategoriaInsumo();
                ctr.DAO_UpdateCategoriaInsumo(objCategoriaIn);
                ScriptManager.RegisterStartupScript(this, GetType(), "alertaActualizar", "alertaActualizar()", true);
                CargarCategorias();         

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
