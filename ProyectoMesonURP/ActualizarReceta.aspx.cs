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
        public bool existe = false;
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
                CargargvIngredientes();
            }
        }
        public void ListarRecetaxID()
        {
            _Dr.R_idReceta = Convert.ToInt32(Session["IdReceta"]);
            txtnombre.Text = Convert.ToString(Session["nombreReceta"]);
            txtPorciones.Text = Convert.ToString(Session["porciones"]);
            txtCategoriaReceta.Text = Convert.ToString(Session["categoria"]);
            txtDescripcion.Text = Convert.ToString(Session["descripcion"]);
            
            ImagenPreview.ImageUrl = "data:image / jpg; base64";
            //_Cixr = new CTR_IngredienteXReceta();
            //dt = _Cixr.ListarIngredientesXReceta(_Dr.R_idReceta);
            //gvIngredientes.DataSource = dt;
            //gvIngredientes.DataBind();
        }
        public void CargargvIngredientes()
        {
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
            
                //id = Convert.ToInt32(gvIngredientes.SelectedRow.RowIndex);
                //lblIndex.Text = id.ToString();
             
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
            _Dixr.R_idReceta = Convert.ToInt32(Session["IdReceta"]);
            //string nombreIngrediente = Convert.ToString(_Ci.ListarNombreIngrediente(Convert.ToInt32(ddlIngredientes.SelectedValue)));
            _Cixr.ListarIngredientesXReceta(_Dixr.R_idReceta);
            _Dixr.IR_cantidad = Convert.ToDecimal(txtCantidad.Text);
            _Dixr.IR_formatoMedida = txtMedidaFormato.Text;

            _Dixr = new DTO_IngredienteXReceta();

            for (int i = 0; i < tin.Rows.Count; i++)
            {
                if (Convert.ToString(gvIngredientes.Rows[i].Cells[0].Text) == Convert.ToString(_Di.I_nombreIngrediente))
                {
                    existe = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertaError()", true);
                }
            }
             if (ddlIngredientes.SelectedValue == "" || txtCantidad.Text == "")
             {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertaError()", true); 
             }
            else
            {
                _Dixr.IR_cantidad = Convert.ToDecimal(txtCantidad.Text);
                _Dixr.IR_formatoMedida = txtMedidaFormato.Text;
                _Dixr.R_idReceta = Convert.ToInt32(Session["IdReceta"]);
                _Dixr.I_idIngrediente = Convert.ToInt32(ddlIngredientes.SelectedValue);
                _Dixr.IR_cantidad = Convert.ToInt32(txtCantidad.Text);

                _Cixr.RegistrarIngredienteXReceta(_Dixr);
                CargargvIngredientes();
            }
        }
        protected void btnGuardar_ServerClick(object sender, EventArgs e)
        {
            _Dr.R_idReceta = Convert.ToInt32(Session["IdReceta"]);
            _Dr.R_nombreReceta = txtnombre.Text;
            _Dr.R_numeroPorcion = Convert.ToInt32(txtPorciones.Text);
            _Dr.R_descripcion = txtDescripcion.Text;
            _Dr.R_imagenReceta = imagen_bytes(ImagenPreview);
            try {
                _Dr.CR_idCategoriaReceta = Convert.ToInt32(ddlCategoriaReceta.SelectedValue);
            }
            catch (System.FormatException) {
                _Dr.CR_idCategoriaReceta = Convert.ToInt32(_Ccr.CargarCategoriaRecetaxNombre(txtCategoriaReceta.Text));
            }
            _Cr.ActualizarReceta(_Dr);
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alertaExito()", true);
            return;
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
        }
        public System.Drawing.Image RedimensionarImagen(System.Drawing.Image ImagenRecetaOriginal, int alto)
        {
            var radio = Convert.ToDouble(alto) / ImagenRecetaOriginal.Height;
            var nuevoAncho = Convert.ToInt32(ImagenRecetaOriginal.Width * radio);
            var nuevoAlto = Convert.ToInt32(ImagenRecetaOriginal.Height * radio);
            var nuevaImagenRedimensionada = new Bitmap(nuevoAncho, nuevoAlto);
            var g = Graphics.FromImage(nuevaImagenRedimensionada);
            return nuevaImagenRedimensionada;
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
            try
            {
                GridViewRow row = gvIngredientes.SelectedRow;
                int idReceta = Convert.ToInt32(Session["IdReceta"]);
                int idIngrediente = _Ci.ListarIdIngredientexNombre(row.Cells[0].Text);
                _Cixr.EliminarIngredientexReceta(idReceta, idIngrediente);
                CargargvIngredientes();
            }
            catch (System.NullReferenceException)
            {
                throw;
            }
        }
    }
}