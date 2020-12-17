using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using System.Data;

namespace ProyectoMesonURP
{
    public partial class ActualizarMenuDia : System.Web.UI.Page
    {

        CTR_Receta ctr_receta;
        CTR_Menu ctr_menu;
        DTO_Menu dto_menu;
        CTR_MenuXReceta ctr_menuxreceta;
        DTO_MenuXReceta dto_menuxreceta;
        CTR_CategoriaReceta ctr_cat_receta;
        static DateTime fecha;
        DTO_Menu objMenu;
        static DataTable dtCarta;
        static DataTable dtMenu ;
        static int numBebidas, numEntradas, numFondos;
        static DataTable dtMenuSeleccionado; 
      static  DataTable dtCartaSeleccionada;
        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_receta = new CTR_Receta();
            ctr_menuxreceta = new CTR_MenuXReceta();
            dto_menu = new DTO_Menu();
            ctr_menu = new CTR_Menu();
            objMenu = new DTO_Menu();
            ctr_cat_receta = new CTR_CategoriaReceta();
            dto_menuxreceta = new DTO_MenuXReceta();

            if (Session["Usuario"] == null)
            {
                Response.Redirect("Home.aspx?x=1");
            }
            if (!IsPostBack)
            {
                dtMenuSeleccionado = new DataTable();
                dtCartaSeleccionada = new DataTable();
                dtCarta = new DataTable();
                dtMenu = new DataTable();
                numFondos = 0;
                numBebidas = 0;
                numEntradas = 0;
                fecha = (DateTime)Session["fecha"];
                txtFecha.Text = fecha.ToShortDateString();
                //hay = (bool)Session["hay"];
                //---------------------------------
                dto_menu = ctr_menu.CTR_ConsultarMenu(Convert.ToDateTime(fecha));
                int id_menu = dto_menu.ME_idMenu;
                dtMenuSeleccionado= ctr_receta.CTR_ConsultarMenuXRecetaYCategoria(id_menu, 1);
                repeaterMenu.DataSource = dtMenuSeleccionado;
                repeaterMenu.DataBind();

                dtCartaSeleccionada= ctr_receta.CTR_ConsultarMenuXRecetaYCategoria(id_menu, 2);
                repeaterCartaSeleccionada.DataSource = dtCartaSeleccionada;
                repeaterCartaSeleccionada.DataBind();
                //-----------------------------------
                reapeterEntradas.DataSource = ctr_receta.CTR_Consultar_Recetas_X_SubCategoriaYCategoria(1, "Entradas");
                reapeterEntradas.DataBind();
                //-----------------------------------
                repeaterFondo.DataSource = ctr_receta.CTR_Consultar_Recetas_X_SubCategoriaYCategoria(1, "Segundos");
                repeaterFondo.DataBind();
                //-----------------------------------
                repeaterBebida.DataSource = ctr_receta.CTR_Consultar_Recetas_X_SubCategoriaYCategoria(1, "Bebidas");
                repeaterBebida.DataBind();
                //-----------------------------------
                repeaterCarta.DataSource = ctr_receta.CTR_Consultar_Recetas_X_Categoria(2);
                repeaterCarta.DataBind();
                //----------------
                int porcionMenu = 0;
                int porcionCarta = 0;
                DTO_Receta dto_receta;
                foreach (DataRow item in dtMenuSeleccionado.Rows)
                {
                    porcionMenu +=Convert.ToInt32(item.ItemArray[3]);
                    dto_receta = ctr_receta.CTR_Consultar_Receta(Convert.ToInt32(item.ItemArray[1]));
                    if (dto_receta.R_subcategoria == "Entradas") numEntradas++;
                    if (dto_receta.R_subcategoria == "Segundos") numFondos++;
                    if (dto_receta.R_subcategoria == "Bebidas") numBebidas++;
                }
                foreach (DataRow item in dtCartaSeleccionada.Rows)
                {
                    porcionCarta += Convert.ToInt32(item.ItemArray[3]);
                }
                txtNumRacMenu.Text = porcionMenu.ToString();
                txtNumRacCarta.Text = porcionCarta.ToString();
            }
        }

        protected void repeaterCartaSeleccionada_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "QuitarCarta")
            {
                dtCarta.Rows[e.Item.ItemIndex].Delete();
                int R_id = int.Parse(((Label)repeaterCartaSeleccionada.Items[e.Item.ItemIndex].FindControl("lblIdReceta")).Text);
                for (int i = 0; i < dtCartaSeleccionada.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtCartaSeleccionada.Rows[i].ItemArray[1]) == R_id)
                    {
                        dtCartaSeleccionada.Rows[i].Delete();
                    }
                }
                repeaterCartaSeleccionada.DataSource = dtCarta;
                repeaterCartaSeleccionada.DataBind();
            }
        }

        protected void repeaterCarta_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerCarta")
            {

            }
            else if (e.CommandName == "AgregarCarta")
            {
                int a = 0;
                AgregarFilas(repeaterCarta, dtCarta, e.Item.ItemIndex, repeaterCartaSeleccionada, ref a,dtCartaSeleccionada);
            }
        }

        protected void repeaterMenu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "QuitarMenu")
            {
                dtMenu.Rows[e.Item.ItemIndex].Delete();
                
                int R_id = int.Parse(((Label)repeaterMenu.Items[e.Item.ItemIndex].FindControl("lblIdReceta")).Text);
                DTO_Receta receta = ctr_receta.CTR_Consultar_Receta(R_id);
                
                for(int i=0;i<dtMenuSeleccionado.Rows.Count;i++)
                {
                    if (Convert.ToInt32(dtMenuSeleccionado.Rows[i].ItemArray[1])==R_id)
                    {
                        dtMenuSeleccionado.Rows[i].Delete();
                    }
                }
                
                if (receta.R_subcategoria == "Entradas") numEntradas--;
                else if (receta.R_subcategoria == "Segundos") numFondos--;
                else if (receta.R_subcategoria == "Bebidas") numBebidas--;

                repeaterMenu.DataSource = dtMenu;
                repeaterMenu.DataBind();
            }
        }

        protected void reapeterEntradas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerEntrada")
            {

            }
            else if (e.CommandName == "AgregarEntrada"/* && sEntrada == true*/)
            {
                if (numEntradas < 2)
                {

                    AgregarFilas(reapeterEntradas, dtMenu, e.Item.ItemIndex, repeaterMenu, ref numEntradas,dtMenuSeleccionado);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "alertaSeleccionado", "alertaSeleccionado('Se ha logrado ingresar correctamente');", true);
                }
            }
        }

        protected void repeaterFondo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerFondo")
            {

            }
            else if (e.CommandName == "AgregarFondo")
            {
                if (numFondos < 3)
                {

                    AgregarFilas(repeaterFondo, dtMenu, e.Item.ItemIndex, repeaterMenu, ref numFondos,dtMenuSeleccionado);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "alertaSeleccionado", "alertaSeleccionado('Se ha logrado ingresar correctamente');", true);
                }


            }
        }

        protected void repeaterBebida_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerBebida")
            {

            }
            else if (e.CommandName == "AgregarBebida")
            {

                if (numBebidas < 1)
                {
                    AgregarFilas(repeaterBebida, dtMenu, e.Item.ItemIndex, repeaterMenu, ref numBebidas,dtMenuSeleccionado);

                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "alertaSeleccionado", "alertaSeleccionado('Se ha logrado ingresar correctamente');", true);
                }


            }
        }
        public void CrearDt(DataTable dt)
        {
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("R_imagenReceta",typeof(byte[]));
                dt.Columns.Add("R_idReceta", typeof(int));
                dt.Columns.Add("R_nombreReceta",typeof(string));
                dt.Columns.Add("R_numeroPorcion", typeof(int));
                dt.Columns.Add("CP_nombreCategoriaR", typeof(string));
                dt.Columns.Add("R_subcategoria", typeof(string));
                dt.Columns.Add("MXR_numeroPorcion", typeof(int));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["R_idReceta"] };
            }
        }
        public void AgregarFilas(Repeater rp, DataTable dt, int i, Repeater rpFinal, ref int num,DataTable dtfinal)
        {
            DataRow dr = dt.NewRow();
            int R_id = int.Parse(((Label)rp.Items[i].FindControl("lblIdReceta")).Text);
            DTO_Receta receta = ctr_receta.CTR_Consultar_Receta(R_id);
            int CR_id = receta.CP_idCategoriaReceta;
            DTO_CategoriaReceta cat_receta = ctr_cat_receta.CTR_Consultar_CategoriaXReceta(CR_id);

            CrearDt(dt);

            dr[0] = receta.R_imagenReceta;
            dr[1] = receta.R_idReceta;
            dr[2] = receta.R_nombreReceta;
            dr[3] = receta.R_numeroPorcion;
            dr[4] = cat_receta.CR_nombreCategoria;
            dr[5] = receta.R_subcategoria;

            if (dt.Rows.Contains(dr["R_idReceta"]))//Si ya se seleccionó
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alertaRechazado", "alertaRechazado('Se ha logrado ingresar correctamente');", true);
            }
            else
            {
                dt.Rows.Add(dr);
                dt.Merge(dtfinal);
                rpFinal.DataSource = dt;
                rpFinal.DataBind();
                num++;
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            int sumaCarta = SumarPorciones(repeaterCartaSeleccionada);
            int sumaMenu = SumarPorciones(repeaterMenu);
            if (int.Parse(txtNumRacCarta.Text) == sumaCarta && int.Parse(txtNumRacMenu.Text) == sumaMenu)
            {
                string cat = "";
                int sumEntrada = 0, sumBebida = 0, s = 0;

                foreach (RepeaterItem item in repeaterMenu.Items)
                {
                    cat = ((Label)item.FindControl("lblCatRec")).Text;
                    s = int.Parse(((TextBox)item.FindControl("txtNumRaciones")).Text);
                    if (cat == "Entradas")
                    {
                        sumEntrada += s;
                    }
                    else if (cat == "Bebidas")
                    {
                        sumBebida += s;
                    }

                }
                if (sumEntrada == sumBebida)
                {
                    dto_menu.ME_fechaMenu = txtFecha.Text;
                    dto_menu.ME_totalPorcion = sumaCarta + sumaMenu;
                    dto_menu.EM_idEstadoMenu = 1;
                    ctr_menu.CTR_RegistrarMenu(dto_menu);
                    RegistrarMenuXReceta(repeaterCartaSeleccionada);
                    RegistrarMenuXReceta(repeaterMenu);
                    ClientScript.RegisterStartupScript(Page.GetType(), "alertaExito", "alertaExito('Se ha logrado ingresar correctamente');", true);
                    
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "alertaBebidayEntrada", "alertaBebidayEntrada('Se ha logrado ingresar correctamente');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "alertaPorcion", "alertaPorcion('Se ha logrado ingresar correctamente');", true);
            }
        }



       
        public void RegistrarMenuXReceta(Repeater rp)
        {
            int R_id;
            int M_id = ctr_menu.CTR_ConsultarMenu(fecha).ME_idMenu;
            ctr_menuxreceta.CTR_EliminarMenusXReceta(M_id);

            foreach (RepeaterItem item in rp.Items)
            {
                R_id = int.Parse(((Label)item.FindControl("lblIdReceta")).Text);
                dto_menuxreceta.ME_idMenu = M_id;
                dto_menuxreceta.R_idReceta = R_id;
                dto_menuxreceta.MXR_numeroPorcion = int.Parse(((TextBox)item.FindControl("txtNumRaciones")).Text);
                ctr_menuxreceta.CTR_RegistrarMenuXReceta(dto_menuxreceta);
                //receta = ctr_receta.CTR_Consultar_Receta(R_id);
            }


        }
        public int SumarPorciones(Repeater rp)
        {
            int sum = 0;
            int s = 0;
            foreach (RepeaterItem item in rp.Items)
            {
                s = int.Parse(((TextBox)item.FindControl("txtNumRaciones")).Text);
                sum += s;
            }
            return sum;
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CalendariaMenu.aspx");
        }
    }

}