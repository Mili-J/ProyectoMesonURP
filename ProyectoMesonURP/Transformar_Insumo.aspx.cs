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
        DTO_Ingrediente objIngrediente;
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
        DataTable dt_transformacion;
        DataSet dtIngredienteR;
        string medidaC = "";  
        int porciones=0;
        decimal equivalencia=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_eq = new CTR_Equivalencia();
            objIngrediente = new DTO_Ingrediente();
            dto_ir = new DTO_IngredienteXReceta();
            dto_formato = new DTO_Formato();
            dto_medida = new DTO_Medida();
            dto_receta = new DTO_Receta();
            dto_MFCocina = new DTO_MedidaXFormatoCocina();
            ctr_MFCocina = new CTR_MedidaXFormatoCocina();
            dto_receta = new DTO_Receta();
            dto_receta.R_idReceta = (int)Session["idReceta"];
            porciones = (int)Session["Porciones"];
            dto_receta.R_nombreReceta = (string)Session["Receta"];
            ctr_insumo = new CTR_Insumo();
            CTR_Receta objReceta = new CTR_Receta();
            dto_insumo = new DTO_Insumo();
            ctr_ing_x_receta = new CTR_IngredienteXReceta();
            dt_ing_x_receta = new DataTable();
            dt = new DataTable();
            dt_transformacion = new DataTable();
            dt_ing_x_receta = ctr_ing_x_receta.CTR_CONSULTAR_INSUMO_X_RECETA(dto_receta);          
            gvIngredienteReceta.DataSource = dt_ing_x_receta;
            gvIngredienteReceta.DataBind();
            PorcionesReceta();
            lblPlato.Text = dto_receta.R_nombreReceta;
            objReceta.CTR_Consultar_Receta(dto_receta.R_idReceta);
            string imageBase64 = Convert.ToBase64String(dto_receta.R_imagenReceta);           
            Imagen_Receta.ImageUrl = "data:Image/png;base64," + imageBase64;

            if (!this.IsPostBack)
            {                
                LlenarIngredienteR();               
            }

        }
        public DTO_Insumo Get_Insumo(int idIngrediente)
        {

            foreach(DataRow row in dt_ing_x_receta.Rows)
            {
                int idI = Convert.ToInt32(row["I_idIngrediente"]);
                if (idIngrediente == idI)
                {
                    dto_insumo.I_nombreInsumo = row["I_nombreInsumo"].ToString();
                    dto_insumo.I_idInsumo= Convert.ToInt32(row["I_idInsumo"]);

                    return dto_insumo;
                }
                
            }
            return dto_insumo;
            
        }
        public string Get_FormatoCocina(int idIngrediente)
        {
            foreach (DataRow row in dt_ing_x_receta.Rows)
            {
                int idI = Convert.ToInt32(row["I_idIngrediente"]);
                if (idIngrediente == idI)
                {
                    return medidaC = row["IR_formatoMedida"].ToString();
                }

            }
            return "no hay";
        }
        public string Get_Medida(int idIngrediente)
        {
            foreach (DataRow row in dt_ing_x_receta.Rows)
            {
                int idI = Convert.ToInt32(row["I_idIngrediente"]);
                if (idIngrediente == idI)
                {
                    return medidaC = row["IR_formatoMedida"].ToString();
                }

            }
            return "no hay";
        }
        public decimal Get_Cantidad_Ingrediente(int idIngrediente)
        {
            decimal cantidadC = 0;


            foreach (GridViewRow row_g in gvIngredienteReceta.Rows)
            {
                foreach (DataRow row in dt_ing_x_receta.Rows)
                {
                    int idI = Convert.ToInt32(row["I_idIngrediente"]);
                    if (idIngrediente == idI)
                    {
                        return cantidadC = Convert.ToDecimal(row_g.Cells[2].Text);
                    }
                }
            }

            return 0;
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
            if(gvIngredienteReceta.Rows.Count!=0)
            {
                foreach (GridViewRow row in gvIngredienteReceta.Rows)
                {
                    decimal cantIng = Convert.ToDecimal(row.Cells[2].Text);
                    decimal cantFIng = cantIng * porciones;
                    row.Cells[2].Text = cantFIng.ToString();
                }
            }            
        }
        public decimal Transformar(int i)
        {
          
            int i_ingrediente = Convert.ToInt32(ddlIngrediente.SelectedValue);
            DTO_Equivalencia objEquivalencia= new DTO_Equivalencia();
            DataTable dtEquivalencia = new DataTable();
            dtEquivalencia = ctr_ing_x_receta.CTR_Consultar_Equivalencia_x_Ingrediente(i, i_ingrediente);
            foreach (DataRow row in dtEquivalencia.Rows)
            {
                equivalencia = Convert.ToDecimal(row["E_cantidad"]);
            }
            decimal cantidad_Ingrediente = Get_Cantidad_Ingrediente(i_ingrediente);
            decimal cantidad_Insumo = cantidad_Ingrediente / equivalencia;
            return Math.Round(cantidad_Insumo,2);

        }
        public void DescontarStock(int idInsumo)
        {
            decimal cantidad = decimal.Parse(txtCantidad.Text);
            dt = ctr_insumo.ListarInsumo();

            foreach (DataRow row in dt.Rows)
            {
                dto_insumo.I_idInsumo = Convert.ToInt32(row["I_idInsumo"]);
                dto_insumo.I_cantidad = Convert.ToInt32(row["I_cantidad"]);

                if (dto_insumo.I_idInsumo == idInsumo)
                {
                    decimal cantActual = dto_insumo.I_cantidad - cantidad;
                    dto_insumo.I_cantidad = cantActual;
                    ctr_insumo.ActualizarCantidadI(dto_insumo);
                    return;
                }

            }

        }
        public void LlenarTransformados()
        {

            if (dt_transformacion.Rows.Count == 0)
            {
                dt_transformacion.Columns.Add("Insumo", System.Type.GetType("System.String"));
                dt_transformacion.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"));  
                
            }
            DataTable dt_T = new DataTable();
            dt_T = (DataTable)Session["dtTransformacion"];

            if (dt_T != null)
            {
                dt_transformacion = dt_T;
            } 
                DataRow row = dt_transformacion.NewRow();
                row["Insumo"] = txtInsumo.Text;
                row["Cantidad"] = decimal.Parse(txtCantidad.Text);
                dt_transformacion.Rows.Add(row);
                GridViewTransformacion.DataSource = dt_transformacion;
                GridViewTransformacion.DataBind();
                Session.Add("dtTransformacion", dt_transformacion);

        }
        protected void btnAñadirIngrediente_Click(object sender, EventArgs e)
        {
            objIngrediente.I_idIngrediente = int.Parse(ddlIngrediente.SelectedValue);
            dto_insumo.I_idInsumo = Get_Insumo(objIngrediente.I_idIngrediente).I_idInsumo;
            int i = dto_insumo.I_idInsumo;
            txtCantidad.Text = Transformar(i).ToString();
            LlenarTransformados();
            //DescontarStock(i);
            
        }
        protected void ddlIngrediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlIngrediente.SelectedValue != "")
            {
                objIngrediente.I_idIngrediente = int.Parse(ddlIngrediente.SelectedValue);
                txtFormatoC.Text = Get_FormatoCocina(objIngrediente.I_idIngrediente);
                txtInsumo.Text = Get_Insumo(objIngrediente.I_idIngrediente).I_nombreInsumo;
                dto_medida = new DTO_Medida();
                dto_insumo.I_idInsumo= Get_Insumo(objIngrediente.I_idIngrediente).I_idInsumo;
                dto_medida = ctr_insumo.CTR_Consultar_Medida_x_Insumo(dto_insumo);
                txtMedida.Text = dto_medida.M_nombreMedida;
                txtCantidad.Text = "";
            }
        }
    }
}