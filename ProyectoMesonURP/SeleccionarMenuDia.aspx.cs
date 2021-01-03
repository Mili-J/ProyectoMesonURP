using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Data.Sql;
using Label = System.Web.UI.WebControls.Label;

namespace ProyectoMesonURP
{
    public partial class SeleccionarMenuDia : System.Web.UI.Page
    {
        CTR_Receta ctr_receta;
        CTR_Menu ctr_menu;
        DTO_Menu dto_menu;
        CTR_MenuXReceta ctr_menuxreceta;
        DTO_MenuXReceta dto_menuxreceta;
        CTR_CategoriaReceta ctr_cat_receta;
        static bool sEntrada, sSegundo;
        static bool hay;
        static DateTime fecha;
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
            //if (Session["Usuario"] == null)
            //{
            //    Response.Redirect("Home.aspx?x=1");
            //}
            if (!IsPostBack)
            {

                fecha = Convert.ToDateTime(Session["fecha"].ToString());
                //txtFecha.Text = fecha.ToString("MM/dd/yyyy");
                txtFecha.Text = fecha.ToString("dd/MM/yyyy");
                hay = (bool)Session["hay"];
                btnAceptar.Visible = !hay;
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
                //Ocultar comentarios
                if (true)
                {
                    //if (hay)
                    //{
                    //    objMenu = ctr_menu.CTR_ConsultarMenu(Convert.ToDateTime(fecha));
                    //    txtNumRaciones.Text = objMenu.ME_numRaciones.ToString();
                    //    DataTable dtmenu = ctr_menuxreceta.CTR_ConsultarRecetasXMenu(objMenu.ME_idMenu);
                    //    if (dtmenu.Rows.Count == 0)
                    //    {
                    //        OcultarEntrada();
                    //        OcultarFondo();
                    //    }
                    //    else
                    //    {
                    //        int i = 0;
                    //        object[] recetas;
                    //        DTO_Receta receta;

                    //        while (i < dtmenu.Rows.Count)
                    //        {
                    //            recetas = dtmenu.Rows[i].ItemArray;
                    //            receta = ctr_receta.CTR_Consultar_Receta(Convert.ToInt32(recetas[1]));
                    //            if (receta.CR_idCategoriaReceta == 2)
                    //            {

                    //                try
                    //                {
                    //                    imgFondo.ImageUrl = "data:image;base64," + Convert.ToBase64String(receta.R_imagenReceta);
                    //                }
                    //                catch (Exception)
                    //                {

                    //                    imgFondo.AlternateText = "No se ha podido cargar la imagen";
                    //                }

                    //                lblIdFondo.Visible = false; lblIdFondo.Text = receta.R_idReceta.ToString();
                    //                lblNombreFondo.Text = receta.R_nombreReceta;
                    //                lblPorcionFondo.Text = receta.R_numeroPorcion.ToString();
                    //                lblCatFondo.Text = new CTR_CategoriaReceta().CTR_Consultar_CategoriaXReceta(receta.CR_idCategoriaReceta).CR_nombreCategoria;
                    //            }
                    //            else
                    //            {
                    //                try
                    //                {
                    //                    imgEntrada.ImageUrl = "data:image;base64," + Convert.ToBase64String(receta.R_imagenReceta);
                    //                }
                    //                catch (Exception)
                    //                {

                    //                    imgEntrada.AlternateText = "No se ha podido cargar la imagen";
                    //                }

                    //                lblIdEntrada.Visible = false; lblIdEntrada.Text = receta.R_idReceta.ToString();
                    //                lblNombreEntrada.Text = receta.R_nombreReceta;
                    //                lblPorcionEntrada.Text = receta.R_numeroPorcion.ToString();
                    //                lblCatEntrada.Text = new CTR_CategoriaReceta().CTR_Consultar_CategoriaXReceta(receta.CR_idCategoriaReceta).CR_nombreCategoria;
                    //            }
                    //            i++;
                    //        }


                    //        sEntrada = false;
                    //        sSegundo = false;
                    //        //---------------------}
                    //        //---------------------
                    //    }
                    //}
                    //else
                    //{
                    //OcultarEntrada();
                    //    OcultarFondo();
                    //}
                }
            }
        }
        //public void OcultarEntrada()
        //{
        //    imgEntrada.Visible = false;
        //    lblIdEntrada.Visible = false;
        //    lblNombreEntrada.Visible = false;
        //    lblPorcionEntrada.Visible = false;
        //    lblCatEntrada.Visible = false;
        //    btnQuitarEntrada.Visible = false;
        //    sEntrada = true;
        //}
        //public void MostrarEntrada()
        //{
        //    imgEntrada.Visible = true;
        //    lblIdEntrada.Visible = true;
        //    lblNombreEntrada.Visible = true;
        //    lblPorcionEntrada.Visible = true;
        //    lblCatEntrada.Visible = true;
        //    btnQuitarEntrada.Visible = true;
        //    sEntrada = false;
        //}
        //public void OcultarFondo()
        //{
        //    imgFondo.Visible = false;
        //    lblIdFondo.Visible = false;
        //    lblNombreFondo.Visible = false;
        //    lblPorcionFondo.Visible = false;
        //    lblCatFondo.Visible = false;
        //    btnQuitarFondo.Visible = false;
        //    sSegundo = true;
        //}
        //public void MostrarFondo()
        //{
        //    imgFondo.Visible = true;
        //    lblIdFondo.Visible = true;
        //    lblNombreFondo.Visible = true;
        //    lblPorcionFondo.Visible = true;
        //    lblCatFondo.Visible = true;
        //    btnQuitarFondo.Visible = true;
        //    sSegundo = false;
        //}


        public void RegistrarMenuXReceta(int id)
        {
            //dto_menuxrecetaEntrada = new DTO_MenuXReceta();
            //dto_menuxrecetaEntrada.ME_idMenu = id;
            //dto_menuxrecetaEntrada.R_idReceta = int.Parse(lblIdEntrada.Text);
            //ctr_menuxreceta.CTR_RegistrarMenuXReceta(dto_menuxrecetaEntrada);
            ////--------------------------------------
            //dto_menuxrecetaFondo = new DTO_MenuXReceta();
            //dto_menuxrecetaFondo.ME_idMenu = id;
            //dto_menuxrecetaFondo.R_idReceta = int.Parse(lblIdFondo.Text);
            //ctr_menuxreceta.CTR_RegistrarMenuXReceta(dto_menuxrecetaFondo);
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

        protected void repeaterMenu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "QuitarMenu")
            {
                dtMenu.Rows[e.Item.ItemIndex].Delete();
                repeaterMenu.DataSource = dtMenu;
                repeaterMenu.DataBind();
            }
        }
        //protected void btnQuitarFondo_Click(object sender, EventArgs e)
        //{
        //    //OcultarFondo();

        //}

        //protected void btnQuitarEntrada_Click(object sender, EventArgs e)
        //{
        //    //OcultarEntrada();
        //}
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

        protected void repeaterCartaSeleccionada_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "QuitarCarta")
            {
                dtCarta.Rows[e.Item.ItemIndex].Delete();
                repeaterCartaSeleccionada.DataSource = dtCarta;
                repeaterCartaSeleccionada.DataBind();
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

            try
            {
                dr[0] = receta.R_imagenReceta;
            }
            catch (Exception)
            {

                dr[0] = null;
            }
            dr[1] = receta.R_idReceta;
            dr[2] = receta.R_nombreReceta;
            dr[3] = receta.R_numeroPorcion;
            dr[4] = cat_receta.CR_nombreCategoria;
            dr[5] = receta.R_subcategoria;

            if (dt.Rows.Contains(dr["R_idReceta"]))//Si ya se seleccionó
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaRechazado('Se ha logrado ingresar correctamente');", true);
            }
            else
            {
                dt.Rows.Add(dr);
                rpFinal.DataSource = dt;
                rpFinal.DataBind();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //Para esconder comentarios
            if (txtNumRacMenu.Text == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaEmpty()", true);
                return;
            }
            if (Convert.ToInt32(txtNumRacMenu.Text) == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaCero()", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaSimbolo()", true);
            }
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
            if (hay == false)
            {
                if (sSegundo == false && sEntrada == false)
                {
                    dto_menu.ME_fechaMenu = txtFecha.Text;
                    dto_menu.EM_idEstadoMenu = 1;
                    dto_menu.ME_totalPorcion = Convert.ToInt32(txtNumRacMenu.Text);
                    ctr_menu.CTR_RegistrarMenu(dto_menu);
                    int id = ctr_menu.CTR_IdMenuMayor();
                    //--------------------------------------
                    RegistrarMenuXReceta(id);
                    //--------------------------------------
                    //Response.Redirect("CalendariaMenu.aspx");
                }
            }
            else if (hay == true)
            {
                //if (sSegundo == false && sEntrada == false)
                //{
                //    DTO_Menu objmenu = ctr_menu.CTR_ConsultarMenu(Convert.ToDateTime(fecha));
                //    objmenu.ME_totalPorcion = Convert.ToInt32(txtNumRacMenu.Text);
                //    DataTable dtMenuReceta = ctr_menuxreceta.CTR_ConsultarRecetasXMenu(objmenu.ME_idMenu);
                //    ctr_menu.CTR_ActualizarMenu(objmenu)*+;
                //    if (dtMenuReceta.Rows.Count == 2)
                //    {
                //        dtMenuReceta.Rows[0][1] = Convert.ToInt32(lblIdEntrada.Text);
                //        dtMenuReceta.Rows[1][1] = Convert.ToInt32(lblIdFondo.Text);
                //        ctr_menuxreceta.CTR_ActualizarMenuXReceta(dtMenuReceta);
                //    }
                //    else if (dtMenuReceta.Rows.Count == 0)
                //    {
                //        RegistrarMenuXReceta(objmenu.ME_idMenu);
                //    }
                //    Response.Redirect("CalendariaMenu.aspx
                //}
            }


            int sumaCarta = SumarPorciones(repeaterCartaSeleccionada);
            //int sumaMenu = SumarPorciones(repeaterMenu);
            int sumaMenu = int.Parse(txtNumRacMenu.Text);
            if (int.Parse(txtNumRacCarta.Text == string.Empty ? "0" : txtNumRacCarta.Text) == sumaCarta && int.Parse(txtNumRacMenu.Text) == sumaMenu)
            {
                //dto_menu.ME_fechaMenu = txtFecha.Text;
                //dto_menu.ME_totalPorcion = sumaCarta + sumaMenu;
                //dto_menu.EM_idEstadoMenu = 1;
                //ctr_menu.CTR_RegistrarMenu(dto_menu);
                RegistrarMenuXReceta(repeaterCartaSeleccionada);
                RegistrarMenuXReceta(repeaterMenu);
                ScriptManager.RegisterStartupScript(this, GetType(), "mensaje", "alertaAceptado();", true);
                Response.Redirect("CalendarioMenu");

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
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CalendarioMenu");
        }
    }
}