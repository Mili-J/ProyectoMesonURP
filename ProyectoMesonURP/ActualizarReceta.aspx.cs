using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class ActualizarReceta : System.Web.UI.Page
    {
        CTR_Receta _Cr = new CTR_Receta();
        DTO_Receta _Dr = new DTO_Receta();
        DTO_Ingrediente _Di = new DTO_Ingrediente();
        DTO_IngredienteXReceta _Dixr = new DTO_IngredienteXReceta();
        CTR_CategoriaReceta _Ccr = new CTR_CategoriaReceta();
        CTR_Ingrediente _Ci = new CTR_Ingrediente();
        CTR_IngredienteXReceta _Cixr = new CTR_IngredienteXReceta();
        static DataTable tin = new DataTable();
        DataTable dt = new DataTable();
        static List<DTO_IngredienteXReceta> pila = new List<DTO_IngredienteXReceta>();
        static int id { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarRecetaxID();
                lblIndex.Text = id.ToString();
                ddlCategoriaReceta.Visible = false;
                ListarCategoriaReceta();
                ListarIngredientes();
            }
        }
        public void ListarRecetaxID()
        {
            _Dr.R_idReceta = Convert.ToInt32(Session["IdReceta"]);
            txtnombre.Text = Convert.ToString(Session["nombreReceta"]);
            txtPorciones.Text = Convert.ToString(Session["porciones"]);
            txtCategoriaReceta.Text = Convert.ToString(Session["categoria"]);
            txtDescripcion.Text = Convert.ToString(Session["descripcion"]);

            //ctr_ocxinsumo = new CTR_OCxInsumo();
            _Cixr = new CTR_IngredienteXReceta();
            dt = _Cixr.ListarIngredientesXReceta(_Dr.R_idReceta);
            gvIngredientes.DataSource = dt;
            gvIngredientes.DataBind();
        }
        public void ListarIngredientes()
        {
            ddlIngredientes.DataSource = _Ci.CargarIngredientes();
            ddlIngredientes.DataTextField = "I_nombreIngrediente";
            ddlIngredientes.DataValueField = "I_idIngrediente";
            ddlIngredientes.DataBind();
            ddlIngredientes.Items.Insert(0, "--seleccionar--");
        }
        public void ListarCategoriaReceta()
        {
            ddlCategoriaReceta.DataSource = _Ccr.CargarCategoriaReceta();
            ddlCategoriaReceta.DataTextField = "CR_nombreCategoria";
            ddlCategoriaReceta.DataValueField = "CR_idCategoriaReceta";
            ddlCategoriaReceta.DataBind();
            ddlCategoriaReceta.Items.Insert(0, "--seleccionar--");
        }

        protected void ddlIngredientes_Change(object sender, EventArgs e)
        {

        }
        protected void ddlCategoriaReceta_Change(object sender, EventArgs e)
        {


        }
        protected void gvIngredientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = Convert.ToInt32(gvIngredientes.SelectedRow.RowIndex);
            lblIndex.Text = id.ToString();
        }
        protected void gvIngredientes_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvIngredientes, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Haga click para seleccionar la fila.";
                id = e.Row.RowIndex;
            }
        }
        protected void btnAñadirIngredientes_Click(object sender, EventArgs e)
        {
            _Di = _Ci.ListarNombreIngrediente(Convert.ToInt32(ddlIngredientes.SelectedValue));
            _Dixr.IR_cantidad = Convert.ToDecimal(txtCantidad.Text);
            _Dixr.IR_formatoMedida = txtMedidaFormato.Text;

            DataRow row = tin.NewRow();
            if (tin.Columns.Count == 0)
            {
                tin.Columns.Add("Nombre Ingrediente");
                tin.Columns.Add("Cantidad");
                tin.Columns.Add("Medida");
            }
            if (tin.Rows.Count > 0)
            {
                // Primero averigua si el registro existe:
                bool existe = false;
                for (int i = 0; i < tin.Rows.Count; i++)
                {
                    if (Convert.ToString(gvIngredientes.Rows[i].Cells[1].Text) == Convert.ToString(_Dr.R_nombreReceta))
                    {
                        existe = true;
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alertaDuplicado()", true);
                        break;
                    }
                }
                // Luego, ya fuera del ciclo, solo si no existe, realizas la insercion:
                if (existe == false)
                {
                    pila.Add(_Dixr);

                    row[0] = _Di.I_nombreIngrediente;
                    row[1] = _Dixr.IR_cantidad;
                    row[2] = _Dixr.IR_formatoMedida;
                    tin.Rows.Add(row);

                    gvIngredientes.DataSource = tin;
                    gvIngredientes.DataBind();
                }
            }
            else
            {
                pila.Add(_Dixr);

                row[0] = _Di.I_nombreIngrediente;
                row[1] = _Dixr.IR_cantidad;
                row[2] = _Dixr.IR_formatoMedida;
                tin.Rows.Add(row);

                gvIngredientes.DataSource = tin;
                gvIngredientes.DataBind();
            }
        }
        protected void btnGuardar_ServerClick(object sender, EventArgs e)
        {
                _Dr.R_nombreReceta = txtnombre.Text;
                _Dr.R_numeroPorcion = Convert.ToInt32(txtPorciones.Text);
                _Dr.R_descripcion = txtDescripcion.Text;
                _Dr.R_imagenReceta = imagen_bytes(ImagenPreview);
                _Dr.CR_idCategoriaReceta = Convert.ToInt32(ddlCategoriaReceta.SelectedValue);
                //_Dr.R_imagenReceta = imagen_bytes(ImagenPreview);
                _Cr.RegistrarReceta(_Dr);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alertaExito()", true);
                return;
            
            //if (pila.Count == 0)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.panelEgreso, this.panelEgreso.GetType(), "alert", "alertaError()", true);
            //    return;
            //}
            //while (pila.Count >= 1)
            //{
            //    _Cr.RegistrarReceta(_Dr);
            //    //_Cmxi.RegistrarMovimientoxInsumo(pila[pila.Count - 1]);
            //    //_Cmxi.UpdateStockEgreso(pila[pila.Count - 1]);
            //    pila.RemoveAt(pila.Count - 1);

            //    tin.Clear();
            //}
            //ScriptManager.RegisterClientScriptBlock(this.panelEgreso, this.panelEgreso.GetType(), "alert", "alertaExito()", true);
            //return;
        }
        protected void btnRegresar_ServerClick(object sender, EventArgs e)
        {
            tin.Clear();
            return;
        }
        protected void btnLimpiar_ServerClick(object sender, EventArgs e)
        {
            txtCantidad.Text = "";
            if (ddlIngredientes.SelectedIndex != 0)
            {
                ddlIngredientes.SelectedIndex = 0;
            }
            if (pila.Count != 0)
            {
                for (int i = 0; i < pila.Count;)
                {
                    if (i % 5 == 0)
                        tin.Rows[i].Delete();
                    pila.Remove(pila[i]);
                }
                gvIngredientes.DataSource = tin;
                gvIngredientes.DataBind();
            }
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                int tamaño = fuImagen.PostedFile.ContentLength;
                byte[] ImagenOriginal = new byte[tamaño];

                fuImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, tamaño);

                Bitmap ImagenOriginalBinaria = new Bitmap(fuImagen.PostedFile.InputStream);

                string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);

                ImagenPreview.ImageUrl = ImagenDataURL64;
            }
            catch (System.ArgumentException)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertaError()", true);
            }
        }
        private Byte[] imagen_bytes(System.Web.UI.WebControls.Image ImagenReceta)
        {

            if (!(ImagenReceta == null))
            {
                int tamaño = fuImagen.PostedFile.ContentLength;
                byte[] ImagenOriginal = new byte[tamaño];
                fuImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, tamaño);
                return ImagenOriginal;
            }
            else
                return null;

        }
        protected void btnEditarCategoria_Click(object sender, ImageClickEventArgs e)
        {
            ddlCategoriaReceta.Visible = true;
            txtCategoriaReceta.Visible = false;
        }
        protected void btnQuitarIngredientes_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(gvIngredientes.SelectedRow.RowIndex);
            tin.Rows[id].Delete();
            pila.RemoveAt(id);
            gvIngredientes.DataSource = tin;
            gvIngredientes.DataBind();
        }
    }
}