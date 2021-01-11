using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;
using System.Globalization;
using System.Text.RegularExpressions;
namespace ProyectoMesonURP
{
    public partial class RegistrarCotizacion : System.Web.UI.Page
    {
        CTR_Proveedor ctr_proveedor;
        CTR_Menu ctr_menu;
        CTR_MenuXReceta ctr_menuxreceta;
        CTR_IngredienteXReceta ctr_ingxrec;
        CTR_Ingrediente ctr_ingrediente;
        CTR_Insumo ctr_insumo;
        CTR_Cotizacion ctr_cotizacion;
        CTR_DetalleCotizacion ctr_detalleCot;
        CTR_CotizacionXMenu ctr_cotMen;
        CTR_CategoriaInsumo ctr_catIns;
        CTR_Medida ctr_medida;
        static DataTable dtCot;
        static List<DTO_Cotizacion> listCot = new List<DTO_Cotizacion>();
        static List<List<DTO_DetalleCotizacion>> listDetCotTotal = new List<List<DTO_DetalleCotizacion>>();
        static List<List<DateTime>> listFechaXCot = new List<List<DateTime>>();
        static DTO_Usuario dto_usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_proveedor = new CTR_Proveedor();
            ctr_menu = new CTR_Menu();
            ctr_menuxreceta = new CTR_MenuXReceta();
            ctr_ingxrec = new CTR_IngredienteXReceta();
            ctr_ingrediente = new CTR_Ingrediente();
            ctr_insumo = new CTR_Insumo();
            ctr_cotizacion = new CTR_Cotizacion();
            ctr_detalleCot = new CTR_DetalleCotizacion();
            ctr_cotMen = new CTR_CotizacionXMenu();
            dto_usuario = new DTO_Usuario();
            dto_usuario = (DTO_Usuario)Session["Usuario"];
            ctr_catIns = new CTR_CategoriaInsumo();
            ctr_medida = new CTR_Medida();
            if (!IsPostBack)
            {
                dtCot = new DataTable();
                txtFecha.Text = DateTime.Today.ToShortDateString();
                //-----------
                DdlProveedor.DataTextField = "PR_razonSocial";
                DdlProveedor.DataValueField = "PR_idProveedor";
                DdlProveedor.DataSource = ctr_proveedor.CTR_ConsultarProveedores();
                DdlProveedor.DataBind();
                //-----------
                DdlInsumo.DataTextField = "CI_nombreCategoria";
                DdlInsumo.DataValueField = "CI_idCategoriaInsumo";
                DdlInsumo.DataSource = ctr_catIns.DAO_ConsultarCategoriasInsumo();
                DdlInsumo.DataBind();
               //DdlInsumo.Items.Insert(0, "--seleccione--");
               //DdlInsumo.Items[0].Value = "0";
            }
        }

        protected void btnCrearCotizacion_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < listCot.Count)
            {
                ctr_cotizacion.CTR_Registrar_Cotizacion(listCot[i]);
                //listCot.RemoveAt(i);
                //----------
                int id = ctr_cotizacion.CTR_IdCotizacionMayor();
                int j = 0;
                while (j < listDetCotTotal[i].Count)
                {
                    listDetCotTotal[i][j].C_idCotizacion = id;
                    ctr_detalleCot.CTR_RegistrarDetalleCotizacion(listDetCotTotal[i][j]);
                    j++;
                }
                int k = 0;
                while (k < listFechaXCot[i].Count)
                {
                    if (ctr_menu.CTR_HayMenu(listFechaXCot[i][k]))
                    {
                        int idMenu= ctr_menu.CTR_ConsultarMenu(listFechaXCot[i][k]).ME_idMenu; ;
                        DTO_CotizacionXMenu dto_cotXmen = new DTO_CotizacionXMenu();
                        dto_cotXmen.C_idCotizacion = id;
                        dto_cotXmen.ME_idMenu = idMenu;
                        ctr_cotMen.CTR_RegistrarCotizacionXMenu(dto_cotXmen);
                        //_Actualizar Menus su estado
                        DTO_Menu dto_menu = new DTO_Menu();
                        dto_menu.ME_idMenu = idMenu;
                        dto_menu.EM_idEstadoMenu =2;
                        ctr_menu.CTR_ActualizaEstadoMenu(dto_menu);

                    }
                    k++;
                }

                i++;

            }
            ClientScript.RegisterStartupScript(Page.GetType(), "alertaExito", "alertaExito('Se ha logrado ingresar correctamente');", true);

            // Response.Redirect("GestionarCotizacion.aspx");

        }

        protected void btnCal_Click(object sender, EventArgs e)
        {
            CldFecha.Visible = !CldFecha.Visible;

        }

        protected void CldFecha_SelectionChanged(object sender, EventArgs e)
        {
            ConsultarInsumosXCat();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtCot.Columns.Count == 0)
            {
                dtCot.Columns.Add("C_numeroCotizacion");
                dtCot.Columns.Add("C_tiempoPlazo");
                dtCot.Columns.Add("C_documento");
                //dtCot.Columns.Add("PR_idProveedor");
                dtCot.Columns.Add("PR_razonSocial");
            }
            DTO_Cotizacion dto_cotizacion = new DTO_Cotizacion();

            //--------------------------------
            string pattern = "[A-Z]";
            Regex regex = new Regex(pattern);
            MatchCollection match = regex.Matches(DdlInsumo.SelectedItem.Text);
            string ini = "";
            foreach (Match item in match)
            {
                ini += item.ToString();
            }
            //--------------------------------
            var dt = ctr_cotizacion.CTR_Consultar_Cotizaciones();
            dto_cotizacion.C_numeroCotizacion = $"{ini}{dt.Rows.Count}{dtCot.Rows.Count}{DateTime.Today.Day}{DateTime.Today.Month}{DateTime.Today.Year}{DdlInsumo.SelectedValue}";
            dto_cotizacion.C_tiempoPlazo = DdlTiempoPlazo.SelectedValue;
            //dto_cotizacion.C_documento = txtDoc.Text;
            dto_cotizacion.PR_idProveedor = Convert.ToInt32(DdlProveedor.SelectedValue);
            dto_cotizacion.C_fechaEmision = DateTime.Today;
            dto_cotizacion.EC_idEstadoCotizacion = 3;

            dto_cotizacion.U_idUsuario = dto_usuario.U_idUsuario;
            DataRow dr = dtCot.NewRow();
            dr[0] = dto_cotizacion.C_numeroCotizacion;
            dr[1] = dto_cotizacion.C_tiempoPlazo;
            dr[2] = dto_cotizacion.C_documento;
            //dr[3] = dto_cotizacion.PR_idProveedor;
            dr[3] = DdlProveedor.SelectedItem;
            dtCot.Rows.Add(dr);
            listCot.Add(dto_cotizacion);
            GVCot.DataSource = dtCot;
            GVCot.DataBind();

            //----------------
            int i = 0;
            List<DTO_DetalleCotizacion> listDetCot = new List<DTO_DetalleCotizacion>();
            List<DateTime> listFecha = new List<DateTime>();
            while (i < GVVerdura.Rows.Count)
            {

                DTO_DetalleCotizacion dto_detcot = new DTO_DetalleCotizacion();
                //dto_detcot.C_idCotizacion = Convert.ToInt32(GVVerdura.Rows[i].Cells[0].Text);
                dto_detcot.I_idInsumo = Convert.ToInt32(GVVerdura.DataKeys[i]["I_idInsumo"]);
                dto_detcot.DC_cantidadCotizacion = Convert.ToDecimal(GVVerdura.Rows[i].Cells[2].Text);
                //dto_detcot.DC_idDetalleCotizacion = Convert.ToInt32(GVVerdura.Rows[i].Cells[0]);
                listDetCot.Add(dto_detcot);

                i++;
            }
            //---------------------------
            foreach (DateTime item in CldFecha.SelectedDates)
            {
                listFecha.Add(item);
            }
            //---------------------------
            listDetCotTotal.Add(listDetCot);
            listFechaXCot.Add(listFecha);




        }

        protected void DdlInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCat.Text = DdlInsumo.SelectedItem.Text;
            ConsultarInsumosXCat();

        }
        public void ConsultarInsumosXCat()
        {

            // Seleccionar menu de la fecha seleccionada
            DateTime fecha = CldFecha.SelectedDate;
            DataTable dtmenu = new DataTable();
            DataTable dtMenuXReceta, dtMenuXRecetas = new DataTable();
            foreach (DateTime item in CldFecha.SelectedDates)
            {
                dtmenu.Merge(ctr_menu.DAO_ConsultarMenusXYFecha(item));
            }
            //dtmenu= ctr_menu.CTR_ConsultarMenusXEstadoYFecha(1, fecha);
            int h = 0;
            object[] menuxreceta, ingrxrec, menu;

            //DTO_Menu dto_menu = ctr_menu.CTR_ConsultarMenusXEstadoYFecha(1,fecha);
            // Seleccionar los menuxreceta del menu seleccionado
            while (h < dtmenu.Rows.Count)
            {
                menu = dtmenu.Rows[h].ItemArray;
                dtMenuXReceta = ctr_menuxreceta.CTR_ConsultarRecetasXMenu(Convert.ToInt32(menu[0]));
                dtMenuXRecetas.Merge(dtMenuXReceta);
                h++;
            }

            // Seleccionar las recetas del menuxreceta de las fechas selccionadas


            // Seleccionar los ingredientesxreceta de cada receta
            int i = 0;

            DTO_Ingrediente dto_ingrediente;
            DTO_Insumo dto_insumo;
            DataTable dtIng = new DataTable();
            int cat = Convert.ToInt32(DdlInsumo.SelectedValue);
            while (i < dtMenuXRecetas.Rows.Count)
            {
                //int j = 0;
                menuxreceta = dtMenuXRecetas.Rows[i].ItemArray;
                int porcion =Convert.ToInt32(menuxreceta[3]);
                DataTable dtIngXRec = ctr_ingxrec.CTR_ConsultarIngredientesXReceta(Convert.ToInt32(menuxreceta[1]), cat,porcion);
               // dtIngXRec.PrimaryKey = new DataColumn[] { dtIngXRec.Columns["I_idInsumo"], dtIngXRec.Columns["FC_nombreFormatoCompra"] };
                dtIng.Merge(dtIngXRec);
                //while (j < dtMenuXReceta.Rows.Count)
                //{
                //    ingrxrec = dtIngXRec.Rows[j].ItemArray;
                //    // Seleccionar los ingredientes en funcion al ingredientexreceta del turno
                //    dto_ingrediente = ctr_ingrediente.CTR_Consultar_IngredienteXID(Convert.ToInt32(ingrxrec[4]));
                //    // Seleccionar el insumo del ingrediente

                //    j++;
                //}

                i++;

            }
            //decimal can = 0;
            //object[] auxA, auxB;
            //List<int> listIndices = new List<int>();
            //for (int j = 0; j < dtIng.Rows.Count; j++)
            //{
            //    auxA = dtIng.Rows[j].ItemArray;
            //    for (int k = 0; k < dtIng.Rows.Count; k++)
            //    {
            //        auxB = dtIng.Rows[k].ItemArray;
            //        int a = Convert.ToInt32(auxA[8]);
            //        int b = Convert.ToInt32(auxB[8]);
            //        int c = Convert.ToInt32(auxA[0]);
            //        int d = Convert.ToInt32(auxB[0]);
            //        if ( a == b && c != d)
            //        {
            //            can = Convert.ToDecimal(auxA[1]);
            //            can += Convert.ToDecimal(auxB[1]);
            //            auxA[1] = can;
            //            dtIng.Rows[j].ItemArray[1] = can;
            //            //dtIng.Rows[k].Delete();
            //            //listIndices.Add(k);


            //        }
            //    }
            //}
            //foreach (int item in listIndices)
            //{

            //}
            //dtIng.PrimaryKey = new DataColumn[] { dtIng.Columns["I_idInsumo"], dtIng.Columns["FC_nombreFormatoCompra"] };
           
            DataTable dt = new DataTable();
            int z = 0;
            while (z < dtIng.Rows.Count)
            {
                if (dt.Columns.Count == 0)
                {
                    dt.Columns.Add("I_idInsumo", typeof(int));
                    dt.Columns.Add("I_nombreInsumo", typeof(string));
                    dt.Columns.Add("numTotal", typeof(decimal));
                    dt.Columns.Add("FC_nombreFormatoCompra", typeof(string));
                    dt.Columns.Add("Cantidad", typeof(decimal));
                    dt.Columns.Add("Medida", typeof(string));
                    //dt.Columns.Add("IR_cantidad", typeof(decimal));
                    //dt.Columns.Add("numPorcion", typeof(decimal));
                    //dt.Columns.Add("E_cantidad", typeof(decimal));
                    //dt.Columns.Add("MXF_cantidadContenida", typeof(decimal));

                    dt.PrimaryKey = new DataColumn[] { dt.Columns["I_idInsumo"], dt.Columns["FC_nombreFormatoCompra"] };
                }

                DataRow dr = dt.NewRow();
               // object[] ingAux = dtIng.Rows[z].ItemArray;
                decimal numTo = Convert.ToDecimal(dtIng.Rows[z]["numTotal"], CultureInfo.InvariantCulture);
                dr[0] = Convert.ToInt32(dtIng.Rows[z]["I_idInsumo"]);
                dr[1] = Convert.ToString(dtIng.Rows[z]["I_nombreInsumo"]);
                dr[2] = numTo;
                dr[3] = Convert.ToString(dtIng.Rows[z]["FC_nombreFormatoCompra"]);
                dr[4] = Convert.ToDecimal(dtIng.Rows[z]["MXF_cantidadContenida"], CultureInfo.InvariantCulture);

                int idMed = Convert.ToInt32(dtIng.Rows[z].ItemArray[35]);
                DTO_Medida dto_medida = ctr_medida.CTR_ConsultarMedida(idMed);
                dr[5] = dto_medida.M_nombreMedida;

                //dr[4] = Convert.ToDecimal(dtIng.Rows[z]["IR_cantidad"]);
                //dr[5] = Convert.ToDecimal(dtIng.Rows[z]["numPorcion"]);
                //dr[6] = Convert.ToDecimal(dtIng.Rows[z]["E_cantidad"]);
                //dr[7] = Convert.ToDecimal(dtIng.Rows[z]["MXF_cantidadContenida"]);

                if (dt.Rows.Contains(new object[] { dr["I_idInsumo"], dr["FC_nombreFormatoCompra"] }))
                {
                    numTo = 0;
                    DataRow[] a; //= dtIng.Rows.Find(new object[] { dr["I_idInsumo"], dr["FC_nombreFormatoCompra"] });
                    a=dtIng.Select($"I_idInsumo={dr[0]} AND FC_nombreFormatoCompra='{dr[3]}'");
                    foreach (DataRow item in a)
                    {
                        numTo += Convert.ToDecimal(item.ItemArray[39], CultureInfo.InvariantCulture);

                    }
                    DataRow e= dt.Rows.Find(new object[] { dr["I_idInsumo"], dr["FC_nombreFormatoCompra"] });
                    dt.Rows[dt.Rows.IndexOf(e)]["numTotal"] = numTo;

                }
                else
                {
                    dt.Rows.Add(dr);
                }
                
                
                
                z++;
            }

            GVVerdura.DataSource = dt;
            //GVVerdura.DataSource = dtIng;
            GVVerdura.DataBind();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            dtCot= new DataTable();
            listCot = new List<DTO_Cotizacion>();
            listDetCotTotal = new List<List<DTO_DetalleCotizacion>>();
            listFechaXCot = new List<List<DateTime>>();
            
            Response.Redirect("GestionarCotizacion.aspx");
        }
    }
}