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
        CTR_Menu CTRMenu;
        DataTable dtMenu;  
        protected void Page_Load(object sender, EventArgs e)
        {           
            CTRMenu = new CTR_Menu();                  
            DTOMenu = new DTO_Menu();
            CTR_Receta objReceta = new CTR_Receta();                       
            dtMenu = new DataTable();
         
            if (!this.IsPostBack)
            {
                
            }

        }
        public void TransformarInsumos(int idReceta, string nombreReceta)
        {
            int idI = 0;
            int idI2 = 0;
            decimal racionTotalI = 0;
            decimal c = 0;
            decimal e = 0;
            string nomI = "";
            string nomIgv = "";
            CTR_Equivalencia CTREquivalencia = new CTR_Equivalencia();
            DataTable dtTransformarI = new DataTable();
            dtTransformarI = CTREquivalencia.CTR_ConsultarEquivalenciaXIngrediente(idReceta);
            CTR_IngredienteXReceta CTRIxR = new CTR_IngredienteXReceta();
            DataTable dtP = new DataTable();
            dtP = CTRIxR.CTR_SelectIngredientexR(GetIDReceta(nombreReceta));

            foreach(DataRow row in dtP.Rows)
            {
                idI = int.Parse(row["I_idIngrediente"].ToString());
                

                foreach (DataRow row2 in dtTransformarI.Rows)
                {
                    idI2 = int.Parse(row2["I_idIngrediente"].ToString());
                    nomI = row2["I_nombreInsumo"].ToString();

                    foreach (GridViewRow gvrow in gvIngrediente.Rows)
                    {
                        nomIgv = gvrow.Cells[3].Text;
                        if (idI == idI2 && nomI==nomIgv )
                        {
                            racionTotalI = Convert.ToDecimal(gvrow.Cells[1].Text);
                            e = Convert.ToDecimal(row2["E_cantidad"]);
                            decimal t = (e* racionTotalI) / Convert.ToDecimal(row["IR_cantidad"]);
                            row2["E_cantidad"] = t;
                            c = Convert.ToDecimal(row["IR_cantidad"]);
                            txtprueba.Text += racionTotalI + "E_cantidad:" + e + ";"+"cantidad receeta"+ c;

                        }
                       
                    }
                    
                }
            }
            
            gvInsumosTransformados.DataSource = dtTransformarI;
            gvInsumosTransformados.DataBind();
            //(0.5*50000gr)/500gr
        }
        public void DescontarStock()
        {
            string gvnombreInsumo = "";
            string nombreInsumo = "";
            decimal gvcantidad = 0;
            decimal stockActual = 0;
            CTR_Insumo CTRInsumo = new CTR_Insumo();
            DTO_Insumo DTOInsumo = new DTO_Insumo();
            DataTable dtInsumo = new DataTable();            
            dtInsumo = CTRInsumo.ListarInsumo();
            foreach (GridViewRow gvrow in gvInsumosTransformados.Rows)
            {
                gvnombreInsumo= gvrow.Cells[0].Text.ToString();
                gvcantidad= Convert.ToDecimal(gvrow.Cells[1].Text);

                foreach (DataRow row in dtInsumo.Rows)
                {                   
                    nombreInsumo = row["I_nombreInsumo"].ToString();
                    stockActual = Convert.ToDecimal(row["I_cantidad"]);

                    if (gvnombreInsumo == nombreInsumo)
                    {
                        stockActual = stockActual- gvcantidad;
                        DTOInsumo.I_cantidad = stockActual;
                        DTOInsumo.I_idInsumo = int.Parse(row["I_idInsumo"].ToString());
                        CTRInsumo.ActualizarCantidadI(DTOInsumo);
                        return;
                        //txtprueba.Text += nombreInsumo+"-"+stockActual+";";
                    }

                }
            }
            
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
        public void CantidadTotalIngredientes(int racionSolicitada, int porcionesReceta, string nombreReceta)
        {
            string s= "";
            CTR_IngredienteXReceta CTRIxR = new CTR_IngredienteXReceta();
            DataTable dtP = new DataTable();
            dtP = CTRIxR.CTR_SelectIngredientexR(GetIDReceta(nombreReceta));
            gvIngrediente.DataSource = dtP;
            gvIngrediente.DataBind();


            foreach (GridViewRow row in gvIngrediente.Rows)
            {
                s = ((Convert.ToDecimal(row.Cells[1].Text) * racionSolicitada) / porcionesReceta).ToString();
                row.Cells[1].Text = s;
            }
        }
        protected void gvRecetaMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarReceta")
            {                
                string nombreReceta= gvRecetaMenu.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_nombreReceta"].ToString();
                int racionSolicitada = Convert.ToInt32(gvRecetaMenu.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["MxR_numeroPorcion"].ToString());
                int porcionesReceta = Convert.ToInt32(gvRecetaMenu.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_numeroPorcion"].ToString());                             
                CantidadTotalIngredientes(racionSolicitada,porcionesReceta,nombreReceta);
                TransformarInsumos(GetIDReceta(nombreReceta),nombreReceta);
                lblMenu.Text = nombreReceta;
            }   
            
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            DescontarStock();
        }
        protected void clMenu_OnDayRender(object sender, DayRenderEventArgs e)
        {
           // DateTime week = DateTime.Today.DayOfWeek;
            if (e.Day.Date.DayOfWeek == DayOfWeek.Monday)
            {
                e.Day.IsSelectable = false;
            }
        }


    }
}