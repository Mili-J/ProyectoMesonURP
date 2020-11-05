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
    public partial class Transformar_Insumo : System.Web.UI.Page
    {
        CTR_Insumo ctr_insumo;
        CTR_IngredienteXReceta ctr_ing_x_receta;
        DTO_Insumo dto_insumo;
        DataTable dt;
        DataTable dt_ing_x_receta;
        DTO_Receta dto_receta;
        protected void Page_Load(object sender, EventArgs e)
        {
            dto_receta = new DTO_Receta();
            dto_receta.R_idReceta = (int)Session["idReceta"];
            ctr_insumo = new CTR_Insumo();
            dto_insumo = new DTO_Insumo();
            ctr_ing_x_receta = new CTR_IngredienteXReceta();
            dt_ing_x_receta = new DataTable();
            dt_ing_x_receta = ctr_ing_x_receta.CTR_CONSULTAR_INSUMO_X_RECETA(dto_receta);
          
                gvIngredienteReceta.DataSource = dt_ing_x_receta;
                gvIngredienteReceta.DataBind();
            
            //dto_insumo.I_idInsumo = int.Parse(txtInsumo.Text);
            //dt=ctr_insumo.CTR_CONSULTAR_EQUIVALENCIA_X_INSUMO(dto_insumo);

        }
        public void FormatoCocina()
        {
            ListItem i;
            foreach (DataRow r in dt.Rows)
            {
                i = new ListItem(r["FCO_nombreFormatoCocina"].ToString());
                ddlFormatoCocina.Items.Add(i);
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }
    }
}