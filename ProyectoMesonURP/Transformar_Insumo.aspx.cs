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
        DataSet dtInsumoR;
        DataSet dtIngredienteR;
        string medidaC = "";
        int cantidadC = 0;
        int idMedida = 0;
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
            ctr_insumo = new CTR_Insumo();
            dto_insumo = new DTO_Insumo();
            ctr_ing_x_receta = new CTR_IngredienteXReceta();
            dt_ing_x_receta = new DataTable();
            dt_ing_x_receta = ctr_ing_x_receta.CTR_CONSULTAR_INSUMO_X_RECETA(dto_receta);          
            gvIngredienteReceta.DataSource = dt_ing_x_receta;
            gvIngredienteReceta.DataBind();
            PorcionesReceta();

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
                    foreach (GridViewRow row_g in gvIngredienteReceta.Rows)
                    { 
                        return cantidadC = Convert.ToInt32(row_g.Cells[2].Text); 
                    }
                    
                }

            }
            return 0;
        }
        public int Get_IdFormatoC(int idIngrediente)
        {
            foreach (DataRow row in dt_ing_x_receta.Rows)
            {
                int idI = Convert.ToInt32(row["I_idIngrediente"]);
                int idR = dto_receta.R_idReceta;
                if (idIngrediente == idI)
                {
                    dto_ir.I_idIngrediente = idIngrediente;
                    dto_ir.R_idReceta = idR;
                    if (ctr_ing_x_receta.CTR_Get_ID_FormatoC(dto_ir)) 
                    {
                        return dto_formato.FCO_idFormatoCocina;                       
                    }                
                }

            }
            return dto_formato.FCO_idFormatoCocina;
        }
        public int Get_idMedida(int idInsumo)
        {
            foreach (DataRow row in dt_ing_x_receta.Rows)
            {
                int idI = Convert.ToInt32(row["I_idInsumo"]);
                if (idInsumo == idI)
                {
                    dto_insumo.I_idInsumo = idInsumo;
                    dto_medida.M_idMedida = ctr_insumo.CTR_Consultar_Medida_x_Insumo(dto_insumo).M_idMedida;
                    return idMedida = dto_medida.M_idMedida;
                }

            }
            return 0;
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
                txtCantidadI.Text = SelectCantidadI(idIng).ToString();
            }
        }
        public decimal Transformar()
        {
            dto_MFCocina.M_idMedida = Get_idMedida(Convert.ToInt32(ddlInsumo.SelectedValue));
            dto_MFCocina.FCO_idFCocina = Get_IdFormatoC(Convert.ToInt32(ddlIngrediente.SelectedValue));
            dto_MFCocina.MXFC_idMedidaFCocina= ctr_MFCocina.CTR_Consultar_Medida_x_FCocina(dto_MFCocina);
            int idI= int.Parse(ddlInsumo.SelectedValue);
            DTO_Equivalencia dto_eq = new DTO_Equivalencia();
            if (ctr_eq.CTR_Consulta_Equivalencia_x_Insumo(dto_MFCocina, idI))
            {
                 cantEq = dto_eq.E_cantidad;
            }
                        
            int cantIng = int.Parse(txtCantidadI.Text);
            decimal cantIns = cantIng / cantEq;
            return cantIns;

        }

        protected void btnAñadirIngrediente_Click(object sender, EventArgs e)
        {
            // txtCantidad.Text = Transformar().ToString();
            dto_MFCocina.FCO_idFCocina = Get_IdFormatoC(Convert.ToInt32(ddlIngrediente.SelectedValue));
            txtPesoUnitario.Text = dto_MFCocina.FCO_idFCocina.ToString();
        }
    }
}