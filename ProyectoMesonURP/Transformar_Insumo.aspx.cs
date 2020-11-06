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
       
        DTO_Insumo dto_insumo;
        DTO_Receta dto_receta;
        CTR_Insumo ctr_insumo;
        CTR_IngredienteXReceta ctr_ing_x_receta;
        DataTable dt;
        DataTable dt_ing_x_receta;
        DataSet dtInsumoR;
        DataSet dtIngredienteR;
        string medidaC = "";
        int cantidadC = 0;


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

            if (!this.IsPostBack)
            {
                LlenarIngredienteR();
                LlenarInsumoR();
            }

        }
        public void LlenarInsumoR()
        {
            dtInsumoR = new DataSet();
            dtInsumoR = ctr_ing_x_receta.CTR_Consultar_IxR(dto_receta);
            
            ddlInsumo.DataTextField = "I_nombreInsumo";
            ddlInsumo.DataValueField = "I_idInsumo";
            ddlInsumo.DataSource = dtInsumoR;
            ddlInsumo.DataBind();
            ddlInsumo.Items.Insert(0, "-- Seleccione --");
        }
        public void LlenarIngredienteR()
        {
            dtIngredienteR = new DataSet();
            dtIngredienteR = ctr_ing_x_receta.CTR_Consultar_IxR(dto_receta);

            ddlIngrediente.DataTextField = "I_nombreIngrediente";
            ddlIngrediente.DataValueField = "I_idIngrediente";
            ddlIngrediente.DataSource = dtIngredienteR;
            ddlIngrediente.DataBind();
            ddlIngrediente.Items.Insert(0, "-- Seleccione --");
        }
        public string SelectMedidaI(int idIngrediente)
        {
            foreach (DataRow row in dt_ing_x_receta.Rows)
            {
                int idI= Convert.ToInt32(row["I_idIngrediente"]);               
                if (idIngrediente==idI)
                {
                    return  medidaC=row["IR_formatoMedida"].ToString();
                }
            
            }
            return "no hay";
        }

        public int SelectCantidadI(int idIngrediente)
        {
            foreach (DataRow row in dt_ing_x_receta.Rows)
            {
                int idI = Convert.ToInt32(row["I_idIngrediente"]);
                if (idIngrediente == idI)
                {
                    return cantidadC = Convert.ToInt32(row["IR_cantidad"]);
                }

            }
            return 0;
        }


        protected void ddlInsumo_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddlInsumo.SelectedValue != "")
            {
                dto_insumo.I_idInsumo = int.Parse(ddlInsumo.SelectedValue);
                txtMedida.Text = ctr_insumo.CTR_Consultar_Medida_x_Insumo(dto_insumo);
            }
        }


        protected void ddlIngrediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInsumo.SelectedValue != "")
            {
                int idIng = int.Parse(ddlIngrediente.SelectedValue);
                txtFormatoC.Text = SelectMedidaI(idIng);
                txtCantidadI.Text = SelectCantidadI(idIng).ToString();
            }
        }
    }
}