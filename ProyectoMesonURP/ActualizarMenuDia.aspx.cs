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
        static string fecha;
        static bool hay;
        static bool sEntrada, sSegundo;
        DTO_Menu objMenu;
        static DataTable dtCarta = new DataTable();
        static DataTable dtMenu = new DataTable();
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

                fecha = Session["fecha"].ToString();
                txtFecha.Text = fecha;
                //hay = (bool)Session["hay"];
                //---------------------------------
                dto_menu = ctr_menu.CTR_ConsultarMenu(Convert.ToDateTime(fecha));
                int id_menu = dto_menu.ME_idMenu;
                txtNumRacMenu.Text = dto_menu.ME_totalPorcion.ToString();

                dtMenu.PrimaryKey = new DataColumn[] { dtMenu.Columns["R_idReceta"] };
                repeaterMenu.DataSource = dtMenu = ctr_receta.CTR_ConsultarMenuXRecetaYCategoria(id_menu, 1);
                repeaterMenu.DataBind();

                repeaterCartaSeleccionada.DataSource = ctr_receta.CTR_ConsultarMenuXRecetaYCategoria(id_menu, 2);
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
                 DataTable cartaf = ctr_receta.CTR_Consultar_Recetas_X_Categoria(2);
                repeaterCarta.DataSource = cartaf;
                repeaterCarta.DataBind();
                decimal totalcarta = decimal.Zero;

                txtNumRacCarta.Text = totalcarta.ToString();

                //Ocultar comentarios
                if (true)
                {
                   
                }
            }
        }

        protected void repeaterCartaSeleccionada_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void repeaterCarta_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerCarta")
            {

            }
            else if (e.CommandName == "AgregarCarta")
            {
                AgregarFilas(repeaterCarta, dtCarta, e.Item.ItemIndex, repeaterCartaSeleccionada);
            }
        }

        protected void repeaterMenu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "QuitarMenu")
            {
                dtMenu.Rows[e.Item.ItemIndex].Delete();
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
                int cantentrada = 0;
                foreach (RepeaterItem item in repeaterMenu.Items)
                {
                    if (((Label)item.FindControl("lblCatRec")).Text == "Entradas")
                    {
                        cantentrada++;
                    }
                }
                if (cantentrada == 2)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaEntradas()", true);
                    return;
                }
                AgregarFilas(reapeterEntradas, dtMenu, e.Item.ItemIndex, repeaterMenu);
            }
        }

        protected void repeaterFondo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerFondo")
            {

            }
            else if (e.CommandName == "AgregarFondo"/* && sSegundo == true*/)
            {
                int cantfondo = 0;
                foreach (RepeaterItem item in repeaterMenu.Items)
                {
                    if (((Label)item.FindControl("lblCatRec")).Text == "Segundos")
                    {
                        cantfondo++;
                    }
                }
                if (cantfondo == 3)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaSegundos()", true);
                    return;
                }
                AgregarFilas(repeaterFondo, dtMenu, e.Item.ItemIndex, repeaterMenu);
            }
        }

        protected void repeaterBebida_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerBebida")
            {

            }
            else if (e.CommandName == "AgregarBebida")
            {
                int cantbebida = 0;
                foreach (RepeaterItem item in repeaterMenu.Items)
                {
                    if (((Label)item.FindControl("lblCatRec")).Text == "Bebidas")
                    {
                        cantbebida++;
                    }
                }
                if (cantbebida == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaBebidas()", true);
                    return;
                }
                AgregarFilas(repeaterBebida, dtMenu, e.Item.ItemIndex, repeaterMenu);
            }
        }
        public void CrearDt(DataTable dt)
        {
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("R_imagenReceta", typeof(byte[]));
                dt.Columns.Add("R_idReceta", typeof(int));
                dt.Columns.Add("R_nombreReceta", typeof(string));
                dt.Columns.Add("R_numeroPorcion", typeof(int));
                dt.Columns.Add("CP_nombreCategoriaR", typeof(string));
                dt.Columns.Add("R_subcategoria", typeof(string));
                dt.PrimaryKey = new DataColumn[] { dt.Columns["R_idReceta"] };
            }
        }
        public void AgregarFilas(Repeater rp, DataTable dt, int i, Repeater rpFinal)
        {
            DataRow dr = dt.NewRow();
            int R_id = int.Parse(((Label)rp.Items[i].FindControl("lblIdReceta")).Text);
            DTO_Receta receta = ctr_receta.CTR_Consultar_Receta(R_id);
            int CR_id = receta.CP_idCategoriaReceta;
            DTO_CategoriaReceta cat_receta = ctr_cat_receta.CTR_Consultar_CategoriaXReceta(CR_id);

            CrearDt(dt);
            if (dr.ItemArray.Length == 6)
            {
                dr[0] = receta.R_imagenReceta;
                dr[1] = receta.R_idReceta;
                dr[2] = receta.R_nombreReceta;
                dr[3] = receta.R_numeroPorcion;
                dr[4] = cat_receta.CR_nombreCategoria;
                dr[5] = receta.R_subcategoria;
            }
            else
            {
                dr[5] = receta.R_imagenReceta;
                dr[1] = receta.R_idReceta;
                dr[4] = receta.R_nombreReceta;
                dr[7] = receta.R_numeroPorcion;
                dr[8] = cat_receta.CR_nombreCategoria;
                dr[6] = receta.R_subcategoria;
            }

            //if (dt.Rows.Contains(dr["R_idReceta"]))//Si ya se seleccionó
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaRechazado('Se ha logrado ingresar correctamente');", true);
            //}
            //else
            //{
            dt.Rows.Add(dr);
            rpFinal.DataSource = dt;
            rpFinal.DataBind();
            //}
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumRacMenu.Text == string.Empty)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaEmpty()", true);
                    return;
                }
                if (Convert.ToInt32(txtNumRacMenu.Text) == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaCero()", true);
                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaSimbolo()", true);
                //}
                int porciones = int.Parse(txtNumRacMenu.Text);
                int cantentrada = 0;
                int cantbebidas = 0;
                int cantpf = 0;
                foreach (RepeaterItem item in repeaterMenu.Items)
                {
                    if (((TextBox)item.FindControl("txtNumRaciones")).Text == string.Empty)
                    {
                        //alguna cantidad esta vacia
                        return;
                    }
                    switch (((Label)item.FindControl("lblCatRec")).Text)
                    {
                        case "Entradas":
                            cantentrada += int.Parse(((TextBox)item.FindControl("txtNumRaciones")).Text);
                            break;
                        case "Bebidas":
                            cantbebidas += int.Parse(((TextBox)item.FindControl("txtNumRaciones")).Text);
                            break;
                        case "Segundos":
                            cantpf += int.Parse(((TextBox)item.FindControl("txtNumRaciones")).Text);
                            break;
                    }
                }
                if (porciones != cantentrada)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaEntradasMax()", true);
                    return;
                }
                if (porciones != cantbebidas)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaSegundosMax()", true);
                    return;
                }
                if (porciones != cantpf)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaBebidasMax()", true);
                    return;
                }
                int sumaCarta = SumarPorciones(repeaterCartaSeleccionada);
                int sumaMenu = int.Parse(txtNumRacMenu.Text);
                if (int.Parse(txtNumRacCarta.Text == string.Empty ? "0" : txtNumRacCarta.Text) == sumaCarta && int.Parse(txtNumRacMenu.Text) == sumaMenu)
                {
                    dto_menu.ME_fechaMenu = txtFecha.Text;
                    dto_menu.EM_idEstadoMenu = 1;
                    dto_menu.ME_totalPorcion = Convert.ToInt32(txtNumRacMenu.Text);
                    int id = ctr_menu.CTR_IdMenuMayor();
                    new CTR_MenuXReceta().CTR_EliminarMenu(id);
                    dto_menu.ME_fechaMenu = txtFecha.Text;
                    dto_menu.EM_idEstadoMenu = 1;
                    dto_menu.ME_totalPorcion = Convert.ToInt32(txtNumRacMenu.Text);
                    ctr_menu.CTR_RegistrarMenu(dto_menu);
                    RegistrarMenuXReceta(repeaterCartaSeleccionada);
                    RegistrarMenuXReceta(repeaterMenu);
                    ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaExito()", true);
                    //Response.Redirect("CalendarioMenu");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void RegistrarMenuXReceta(Repeater rp)
        {
            int R_id;
            int M_id = ctr_menu.CTR_IdMenuMayor();

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
        public void ActualizarMenuXReceta(Repeater rp)
        {
            int R_id;
            int M_id = ctr_menu.CTR_IdMenuMayor();
            int MXR_id;

            foreach (RepeaterItem item in rp.Items)
            {
                R_id = int.Parse(((Label)item.FindControl("lblIdReceta")).Text);
                dto_menuxreceta.ME_idMenu = M_id;
                //dto_menuxreceta.MXR_idMenuReceta = ;
                dto_menuxreceta.R_idReceta = R_id;
                dto_menuxreceta.MXR_numeroPorcion = int.Parse(((TextBox)item.FindControl("txtNumRaciones")).Text);
                ctr_menuxreceta.DAO_ActualizarUnMenuXReceta(dto_menuxreceta);
                //receta = ctr_receta.CTR_Consultar_Receta(R_id);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CalendarioMenu");
        }
    }

}