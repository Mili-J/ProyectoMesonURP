using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;

namespace ProyectoMesonURP
{
    public partial class Gestionar_Ingrediente : System.Web.UI.Page
    {
        DataTable dtIngrediente;
       
        CTR_Ingrediente objIngrediente;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LlenarGVIngredientes();
            }

        }
        public void LlenarGVIngredientes()
        {
            objIngrediente = new CTR_Ingrediente();
            dtIngrediente = new DataTable();
            dtIngrediente = objIngrediente.ListarIngredientes();
            gvIngrediente.DataSource = dtIngrediente;
            gvIngrediente.DataBind();

        }
        protected void GVIngrediente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditarIngrediente")
            {
                DTO_Ingrediente objIngrediente = new DTO_Ingrediente();
                objIngrediente.I_nombreIngrediente = gvIngrediente.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_nombreIngrediente"].ToString();
                objIngrediente.I_pesoUnitario = Convert.ToDecimal(gvIngrediente.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_pesoUnitario"].ToString());
                objIngrediente.I_cantidad = Convert.ToDecimal(gvIngrediente.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_Cantidad"].ToString());
                objIngrediente.I_nombreInsumo = gvIngrediente.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["I_nombreInsumo"].ToString();
                objIngrediente.equivalencia = "1";
                objIngrediente.equivalencia += gvIngrediente.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["M_nombreMedida"].ToString();
                objIngrediente.equivalencia += gvIngrediente.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["E_cantidad"].ToString();
                objIngrediente.equivalencia += gvIngrediente.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["FCO_nombreFormatoCocina"].ToString();
                objIngrediente.I_idIngrediente=ObternIDIngrediente(objIngrediente.I_nombreIngrediente);
                objIngrediente.I_idInsumo = ObternIDInsumo(objIngrediente.I_nombreIngrediente);
                //objIngrediente.E_idEquivalencia = ObternIDEquival(objIngrediente.I_nombreIngrediente);
                Session.Add("Ingrediente", objIngrediente);
                Response.Redirect("ActualizarIngrediente.aspx");
            }
        }
        public int ObternIDIngrediente(string  nomIngrediente)
        {
            string nombreIngrediente = "";
            int idIngrediente = 0;

            CTR_Ingrediente objIngrediente = new CTR_Ingrediente();
            dtIngrediente = new DataTable();
            dtIngrediente = objIngrediente.ListarIngredientes();

            foreach (DataRow row in dtIngrediente.Rows)
                {                   
                    nombreIngrediente = row["I_nombreIngrediente"].ToString();
                if (nombreIngrediente == nomIngrediente)
                    {
                        return idIngrediente = int.Parse(row["I_idIngrediente"].ToString());
                    }
                }
            

            return 0;
        }
        public int ObternIDInsumo(string nomIngrediente)
        {
            string nombreIngrediente = "";
            int idInsumo = 0;

            CTR_Ingrediente objIngrediente = new CTR_Ingrediente();
            dtIngrediente = new DataTable();
            dtIngrediente = objIngrediente.ListarIngredientes();

            foreach (DataRow row in dtIngrediente.Rows)
            {
                nombreIngrediente = row["I_nombreIngrediente"].ToString();
                if (nombreIngrediente == nomIngrediente)
                {
                    return idInsumo = int.Parse(row["I_idInsumo"].ToString());
                }
            }


            return 0;
        }

        public int ObternIDEquival(string nomIngrediente)
        {
            string nombreIngrediente = "";
            int idIngrediente = 0;

            CTR_Ingrediente objIngrediente = new CTR_Ingrediente();
            dtIngrediente = new DataTable();
            dtIngrediente = objIngrediente.ListarIngredientes();

            foreach (DataRow row in dtIngrediente.Rows)
            {
                nombreIngrediente = row["I_nombreIngrediente"].ToString();
                if (nombreIngrediente == nomIngrediente)
                {
                    return idIngrediente = int.Parse(row["E_idEquivalencia"].ToString());
                }
            }


            return 0;
        }


        protected void btnAnadirIngrediente_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarIngrediente.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarEquivalencia.aspx");
        }

        protected void gvIngrediente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Para deshabilitar la opcion Editar 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                dtIngrediente = objIngrediente.ListarIngredientes();
                DataTable dtReceta = new DataTable();
                dtReceta = objIngrediente.Validar_IngredientesXReceta();
                
                foreach (DataRow row in dtIngrediente.Rows)
                {
                    int idI = int.Parse(row["I_idIngrediente"].ToString());
                    foreach(DataRow row2 in dtReceta.Rows )
                    {
                        int idIn= int.Parse(row2["I_idIngrediente"].ToString());
                        if (idI==idIn) e.Row.Cells[5].FindControl("btnEditarIngrediente").Visible = false;
                    }
                   
                }            
            }
        }
    }
}