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
        DTO_Medida dto_medida;
        DTO_Formato dto_formato;
        DTO_IngredienteXReceta dto_ir;
        DTO_MedidaXFormatoCocina dto_MFCocina;
        CTR_Insumo ctr_insumo;
        CTR_Equivalencia ctr_eq;
        CTR_MedidaXFormatoCocina ctr_MFCocina;
        CTR_IngredienteXReceta ctr_ing_x_receta;
        DataTable dt_ing_x_receta;
        DataTable dt;
        DataSet dtInsumoR;
        DataSet dtIngredienteR;
        string medidaC = "";
        
     
        int porciones=0;
        decimal cantEq=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_eq = new CTR_Equivalencia();
            dto_ir = new DTO_IngredienteXReceta();
            dto_formato = new DTO_Formato();
            dto_medida = new DTO_Medida();
            dto_MFCocina = new DTO_MedidaXFormatoCocina();
            ctr_MFCocina = new CTR_MedidaXFormatoCocina();
            dto_receta = new DTO_Receta();
            dto_receta.R_idReceta = (int)Session["idReceta"];
            porciones = (int)Session["Porciones"];
            dto_receta.R_nombreReceta = (string)Session["Receta"];
            ctr_insumo = new CTR_Insumo();
            dto_insumo = new DTO_Insumo();
            ctr_ing_x_receta = new CTR_IngredienteXReceta();
            dt_ing_x_receta = new DataTable();
            dt = new DataTable();
            dt_ing_x_receta = ctr_ing_x_receta.CTR_CONSULTAR_INSUMO_X_RECETA_T(dto_receta);          
            gvIngredienteReceta.DataSource = dt_ing_x_receta;
            gvIngredienteReceta.DataBind();
            PorcionesReceta();
            //lblPlato.Text = dto_receta.R_nombreReceta;

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
        public void PorcionesReceta()
        {
            foreach (GridViewRow row in gvIngredienteReceta.Rows)
            {
                int cantIng = Convert.ToInt32(row.Cells[2].Text);
                int cantFIng = cantIng * porciones;
                row.Cells[2].Text = cantFIng.ToString();
            }

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
            int cantidadC = 0;       

                foreach (GridViewRow row_g in gvIngredienteReceta.Rows)
                {
                   foreach (DataRow row in dt_ing_x_receta.Rows)
                  {
                    int idI = Convert.ToInt32(row["I_idIngrediente"]);
                    if (idIngrediente == idI)
                    {
                        return cantidadC = Convert.ToInt32(row_g.Cells[2].Text);
                    }
                  }
                }
            
            return 0;
        }

        //public int SelectCantidadI(int idIngrediente)
        //{
        //    int cantidadC = 0;

        //    foreach (GridViewRow row in gvIngredienteReceta.Rows)
        //    {
        //        int idI = Convert.ToInt32(row.Cells[0].Text);
        //        if (idIngrediente == idI)
        //        {
        //            return cantidadC = Convert.ToInt32(row.Cells[3].Text);
        //        }
        //    }

        //    return 0;
        //}

        protected void ddlInsumo_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddlInsumo.SelectedValue != "")
            {
                dto_insumo.I_idInsumo = int.Parse(ddlInsumo.SelectedValue);
                dto_medida = new DTO_Medida();
                dto_medida=ctr_insumo.CTR_Consultar_Medida_x_Insumo(dto_insumo);
                txtMedida.Text = dto_medida.M_nombreMedida;
                txtCantidad.Text = dto_medida.M_idMedida.ToString();

            }
        }
        protected void ddlIngrediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInsumo.SelectedValue != "")
            {
                int idIng = int.Parse(ddlIngrediente.SelectedValue);
                txtFormatoC.Text = SelectMedidaI(idIng);
                //txtCantidadI.Text = SelectCantidadI(idIng).ToString();
            }
        }
        public decimal Transformar()
        {
            int i = Convert.ToInt32(ddlInsumo.SelectedValue);
            int ing = Convert.ToInt32(ddlIngrediente.SelectedValue);   
            DTO_Equivalencia dto_eq = new DTO_Equivalencia();
            DataTable dt_eq = new DataTable();
            dt_eq=ctr_ing_x_receta.CTR_Consultar_Equivalencia_x_Ingrediente(i,ing);
            foreach (DataRow row in dt_eq.Rows)
            {
                cantEq = Convert.ToDecimal(row["E_cantidad"]);
            }
            int cantIng = SelectCantidadI(ing);
            decimal cantIns = cantIng/cantEq;
            return cantIns;

        }
       protected void btnAñadirIngrediente_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = Transformar().ToString();
            int idInsumo = SelectCantidadI(Convert.ToInt32(ddlInsumo.SelectedValue));
            DescontarStock(idInsumo);
            ScriptManager.RegisterStartupScript(this, GetType(), "exito", "alertaExito()", true);
            return;
        }

       public void DescontarStock(int idInsumo)
       {
            decimal cantidad = decimal.Parse(txtCantidad.Text);
            dt=ctr_insumo.ListarInsumo();
          
            foreach (DataRow  row in dt.Rows)
            {
                dto_insumo.I_idInsumo = Convert.ToInt32(row["I_idInsumo"]);
                dto_insumo.I_cantidad= Convert.ToInt32(row["I_cantidad"]);

                if (dto_insumo.I_idInsumo == idInsumo)
                {
                    decimal cantActual = dto_insumo.I_cantidad - cantidad;
                    dto_insumo.I_cantidad = cantActual;
                    ctr_insumo.ActualizarCantidadI(dto_insumo);
                    return;
                }
               
            }

        }
    }
}