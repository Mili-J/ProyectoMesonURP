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
        DTO_Menu DTOMenu;
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
        CTR_Menu CTRMenu;
        CTR_IngredienteXReceta ctr_ing_x_receta;
        DataTable dtMenu;
        DataTable dt_ing_x_receta;
        DataTable dt;
        DataTable dt_transformacion;
        //DataSet dtIngredienteR;
        //string medidaC = "";  
        //int porciones=0;
        //decimal equivalencia=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_eq = new CTR_Equivalencia();
            CTRMenu = new CTR_Menu();
            objIngrediente = new DTO_Ingrediente();
            dto_ir = new DTO_IngredienteXReceta();
            DTOMenu = new DTO_Menu();
            dto_formato = new DTO_Formato();
            dto_medida = new DTO_Medida();
            dto_receta = new DTO_Receta();
            dto_MFCocina = new DTO_MedidaXFormatoCocina();
            ctr_MFCocina = new CTR_MedidaXFormatoCocina();
            dto_receta = new DTO_Receta();
            //dto_receta.R_idReceta = (int)Session["idReceta"];
            //porciones = (int)Session["Porciones"];
            //dto_receta.R_nombreReceta = (string)Session["Receta"];
            ctr_insumo = new CTR_Insumo();
            CTR_Receta objReceta = new CTR_Receta();
            dto_insumo = new DTO_Insumo();
            ctr_ing_x_receta = new CTR_IngredienteXReceta();
            dt_ing_x_receta = new DataTable();
            dt = new DataTable();
            dtMenu = new DataTable();
            dt_transformacion = new DataTable();
            //dtMenu = CTRMenu.CTR_SelectMenuXFecha(cldMenu.SelectedDate.ToString());
            //dt_ing_x_receta = ctr_ing_x_receta.CTR_CONSULTAR_INSUMO_X_RECETA(dto_receta);
            //gvRecetaMenu.DataSource = dt_ing_x_receta;
            //gvRecetaMenu .DataBind();
            // PorcionesReceta();
         
            if (!this.IsPostBack)
            {
                
                //LlenarIngredienteR();               
            }

        }


        protected void btnAñadirIngrediente_Click(object sender, EventArgs e)
        {
            //objIngrediente.I_idIngrediente = int.Parse(ddlIngrediente.SelectedValue);
           // dto_insumo.I_idInsumo = Get_Insumo(objIngrediente.I_idIngrediente).I_idInsumo;
            int i = dto_insumo.I_idInsumo;
            //txtCantidad.Text = Transformar(i).ToString();
            //LlenarTransformados();
            //DescontarStock(i);
            
        }
        protected void ddlIngrediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlIngrediente.SelectedValue != "")
            //{
            //    objIngrediente.I_idIngrediente = int.Parse(ddlIngrediente.SelectedValue);
            //    //txtFormatoC.Text = Get_FormatoCocina(objIngrediente.I_idIngrediente);
            //    //txtInsumo.Text = Get_Insumo(objIngrediente.I_idIngrediente).I_nombreInsumo;
            //    dto_medida = new DTO_Medida();
            //   // dto_insumo.I_idInsumo= Get_Insumo(objIngrediente.I_idIngrediente).I_idInsumo;
            //    dto_medida = ctr_insumo.CTR_Consultar_Medida_x_Insumo(dto_insumo);
            //    txtMedida.Text = dto_medida.M_nombreMedida;
            //    txtCantidad.Text = "";
            //}
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {

        }

        protected void cldMenu_SelectionChanged(object sender, EventArgs e)
        {
            dtMenu = CTRMenu.CTR_SelectMenuXFecha(cldMenu.SelectedDate.ToShortDateString());
            lblFecha.Text = cldMenu.SelectedDate.ToString("dddd") + " "+ cldMenu.SelectedDate.Date.ToShortDateString();
            gvRecetaMenu.DataSource = dtMenu;
            gvRecetaMenu.DataBind();
            txtTotalPorciones.Text = InformacionMenu().ME_totalPorcion.ToString();
        }
        public DTO_Menu InformacionMenu()
        {
            dtMenu = CTRMenu.CTR_SelectMenuXFecha(cldMenu.SelectedDate.ToShortDateString());
            foreach (DataRow row in dtMenu.Rows)
            {
                DTOMenu.ME_totalPorcion = int.Parse(row["ME_totalPorcion"].ToString());
               
            }
            return DTOMenu;
        }

        public int GetIDReceta(string nomReceta)
        {
            int idReceta = 0;
            string nomR = "";
            dtMenu = CTRMenu.CTR_SelectMenuXFecha(cldMenu.SelectedDate.ToShortDateString());
            
            foreach (DataRow row in dtMenu.Rows)
            {               
                nomR = row["R_nombreReceta"].ToString();
                if(nomReceta==nomR) return idReceta = int.Parse(row["R_idReceta"].ToString());
            }
            return idReceta;
        }

        public void CantidadTotalIngredientes(int racionSolicitada, int porcionesReceta)
        {
            
            foreach(GridViewRow row2 in gvIngrediente.Rows)
            {
                
                 string s= Convert.ToString((int.Parse(row2.Cells[1].Text) * racionSolicitada)/porcionesReceta);
                 row2.Cells[1].Text = s;
            }            
        }

        protected void gvRecetaMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarReceta")
            {
                DataTable dtP = new DataTable();
                string nombreReceta= gvRecetaMenu.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_nombreReceta"].ToString();
                int racionSolicitada = Convert.ToInt32(gvRecetaMenu.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["MxR_numeroPorcion"].ToString());
                int porcionesReceta = Convert.ToInt32(gvRecetaMenu.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_numeroPorcion"].ToString());
                CTR_IngredienteXReceta CTRIxR = new CTR_IngredienteXReceta();
                dtP= CTRIxR.CTR_SelectIngredientexR(GetIDReceta(nombreReceta));
                gvIngrediente.DataSource = dtP;
                gvIngrediente.DataBind();
                CantidadTotalIngredientes(racionSolicitada,porcionesReceta);
                lblMenu.Text = nombreReceta;
            }   
            
        }
    }
}