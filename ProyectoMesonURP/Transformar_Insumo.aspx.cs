using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Globalization;
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
                            decimal t = (e* racionTotalI);
                           /* decimal t = (e * racionTotalI) / Convert.ToDecimal(row["IR_cantidad"]);*///lo cambie, me ayuda en capturar decimal
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
        public void RegistrarMovimiento()
        {
            string gvnombreInsumo = "";
            string nombreInsumo = "";
            CTR_Movimiento CTRMovimiento = new CTR_Movimiento();
            CTR_Insumo CTRInsumo = new CTR_Insumo();
            DTO_Insumo DTOInsumo = new DTO_Insumo();
            DTO_Movimiento DTOMovimiento = new DTO_Movimiento();
            DataTable dtInsumo = new DataTable();
            dtInsumo = CTRInsumo.ListarInsumo();
            foreach (GridViewRow gvrow in gvInsumosTransformados.Rows)
            {
                gvnombreInsumo = gvrow.Cells[0].Text.ToString();
                

                foreach (DataRow row in dtInsumo.Rows)
                {
                    nombreInsumo = row["I_nombreInsumo"].ToString();
                    

                    if (gvnombreInsumo == nombreInsumo)
                    {
                        
                        DTOMovimiento.I_idInsumo = int.Parse(row["I_idInsumo"].ToString());
                        DTOMovimiento.M_cantidad= Convert.ToDecimal(gvrow.Cells[1].Text);
                        DTOMovimiento.M_fechaMovimiento = DateTime.Now.Date;
                        DTOMovimiento.U_idUsuario = (int)Session["idUsuario"];
                        CTRMovimiento.InsertMovGO(DTOMovimiento);
                       
                        
                    }

                }
            }

        }
        public void ActualizarEstadoMenu()
        {
            int ME_idMenu = 0;
            dtMenu = CTRMenu.CTR_SelectMenuXFecha(cldMenu.SelectedDate.ToShortDateString());
            foreach(DataRow row in dtMenu.Rows)
            {
                if (Convert.ToInt32(row["ME_idMenu"].ToString()) != 0) ME_idMenu = Convert.ToInt32(row["ME_idMenu"].ToString());
            }
            DTO_Menu DTOMenu = new DTO_Menu();
            CTR_EstadoMenu CTREMenu = new CTR_EstadoMenu();
            DTOMenu.ME_idMenu = ME_idMenu;
            DTOMenu.EM_idEstadoMenu = 1003;
            CTRMenu.CTR_ActualizaEstadoMenu(DTOMenu);

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
            int id = 0;
            if (e.CommandName == "SeleccionarReceta")
            {                
                string nombreReceta= gvRecetaMenu.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_nombreReceta"].ToString();
                int racionSolicitada = Convert.ToInt32(gvRecetaMenu.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["MxR_numeroPorcion"].ToString());
                int porcionesReceta = Convert.ToInt32(gvRecetaMenu.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_numeroPorcion"].ToString());                             
                CantidadTotalIngredientes(racionSolicitada,porcionesReceta,nombreReceta);
                TransformarInsumos(GetIDReceta(nombreReceta),nombreReceta);
                lblMenu.Text = nombreReceta;
                id = Convert.ToInt32(e.CommandArgument);
                gvRecetaMenu.Rows[id].Visible = false;
            }   
            
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            DescontarStock();
            RegistrarMovimiento();
            ActualizarEstadoMenu();

        }
        protected void clMenu_OnDayRender(object sender, DayRenderEventArgs e)
        {
            CTR_Menu CTRMenu = new CTR_Menu();
            DataTable dtMenu = new DataTable();
            int day = (int)DateTime.Today.DayOfWeek;
            DateTime dayOfWeek = new DateTime();

            switch (day)
            {
                //Lunes
                case 1: dayOfWeek = DateTime.Today; break;
                //Martes        
                case 2: dayOfWeek = DateTime.Today.AddDays(-1); break;
                //Miercoles        
                case 3: dayOfWeek = DateTime.Today.AddDays(-2); break;
                //Jueves        
                case 4: dayOfWeek = DateTime.Today.AddDays(-3); break;
                //Viernes        
                case 5: dayOfWeek = DateTime.Today.AddDays(-4); break;
                //Sabado        
                case 6: dayOfWeek = DateTime.Today.AddDays(-5); break;
            }                   
            if(e.Day.Date==dayOfWeek || (e.Day.Date <= dayOfWeek.AddDays(5) && e.Day.Date >= dayOfWeek))
            {
                ////for(int i=1;i<=6;i++)
                ////{
                ////    if (i != 1) dayOfWeek = dayOfWeek.AddDays(i-1);
                //dtMenu = CTRMenu.CTR_ConsultarMenusXEstadoYFecha(3, dayOfWeek);
                //if (dtMenu.Rows.Count >= 1)
                //{
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#629e6c");
                e.Cell.BackColor = col;
                //}
                //else
                //{
                //    e.Cell.BackColor = Color.Red;
                //}


                ////}

            }
            else
            {
                e.Cell.BackColor = Color.Gray;
                e.Day.IsSelectable = false;
            }

            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = Color.Gray;
            }

        }  
               

        
    }
}