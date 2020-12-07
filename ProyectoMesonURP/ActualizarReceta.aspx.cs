using CTR;
using DTO;
using System;
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
        CTR2.CTR_EstadoReceta _Cer = new CTR2.CTR_EstadoReceta();
        CTR_Ingrediente _Ci = new CTR_Ingrediente();
        CTR_IngredienteXReceta _Cixr = new CTR_IngredienteXReceta();
        static DataTable tin = new DataTable();
        DataTable dt = new DataTable();
        public int a = 0;
        static int id { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListarRecetaxID();
                lblIndex.Text = id.ToString();
                ddlCategoriaReceta.Visible = false;
                ddlEstadoReceta.Visible = false;
                ddlSubCategoria.Visible = false;
                ListarCategoriaReceta();
                ListarIngredientes();
                ListarEstadoReceta();

                CargargvIngredientes();
            }
        }
        public void ListarRecetaxID()
        {
            _Dr.R_idReceta = Convert.ToInt32(Session["IdReceta"]);
            txtnombre.Text = Convert.ToString(Session["nombreReceta"]);
            txtPorciones.Text = Convert.ToString(Session["porciones"]);
            txtCategoriaReceta.Text = Convert.ToString(Session["categoria"]);
            txtCategoriaReceta.Enabled = false;
            txtDescripcion.Text = Convert.ToString(Session["descripcion"]);
            txtEstadoReceta.Text = Convert.ToString(_Cer.CargarEstadoxIdReceta(Convert.ToInt32(Session["IdReceta"])));
            txtEstadoReceta.Enabled = false;
            txtSubcategoria.Text = _Cr.CargarSubcategoriaxIdReceta(Convert.ToInt32(Session["IdReceta"]));
            txtSubcategoria.Enabled = false;
        }
        public void CargargvIngredientes()
        {
            _Cixr = new CTR_IngredienteXReceta();
            dt = _Cixr.ListarIngredientesXReceta(Convert.ToInt32(Session["IdReceta"]));
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
            ddlCategoriaReceta.DataTextField = "CP_nombreCategoriaR";
            ddlCategoriaReceta.DataValueField = "CP_idCategoriaReceta";
            ddlCategoriaReceta.DataBind();
            ddlCategoriaReceta.Items.Insert(0, "--seleccionar--");
        }
        public void ListarEstadoReceta()
        {
            ddlEstadoReceta.DataSource = _Cer.CargarEstadoReceta();
            ddlEstadoReceta.DataTextField = "EP_nombreEstadoR";
            ddlEstadoReceta.DataValueField = "EP_idEstadoReceta";
            ddlEstadoReceta.DataBind();
            ddlEstadoReceta.Items.Insert(0, "--seleccionar--");
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
            int R_idReceta = Convert.ToInt32(Session["IdReceta"]);
            int idIngrediente = Convert.ToInt32(ddlIngredientes.SelectedValue);
            _Dixr.IR_cantidad = Convert.ToDecimal(txtCantidad.Text);
            _Dixr.IR_formatoMedida = txtMedidaFormato.Text;

            _Dixr = new DTO_IngredienteXReceta();

            bool Emxr = _Cixr.ExistenciaIngredientexReceta(R_idReceta, idIngrediente);
            if (Emxr)
            {
                a = 1;
                ScriptManager.RegisterStartupScript(this, GetType(), "randomtext", "alertaDuplicado()", true);
                return;

            }
            else if (ddlIngredientes.SelectedValue == "" || txtCantidad.Text == "" || txtMedidaFormato.Text == "")
            {
                a = 1;
                ScriptManager.RegisterStartupScript(this, GetType(), "randomtext", "alertaError()", true);
                return;
            }
            else
            {
                try
                {
                    _Dixr.IR_cantidad = Convert.ToDecimal(txtCantidad.Text);
                    _Dixr.IR_formatoMedida = txtMedidaFormato.Text;
                    _Dixr.R_idReceta = Convert.ToInt32(Session["IdReceta"]);
                    _Dixr.I_idIngrediente = Convert.ToInt32(ddlIngredientes.SelectedValue);
                    _Dixr.IR_cantidad = Convert.ToInt32(txtCantidad.Text);

                    _Cixr.RegistrarIngredienteXReceta(_Dixr);
                    CargargvIngredientes();
                }
                catch (System.FormatException)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "randomtext", "alertaError()", true);
                    return;
                }
            }
        }
        protected void btnGuardar_ServerClick(object sender, EventArgs e)
        {
            _Dr.R_idReceta = Convert.ToInt32(Session["IdReceta"]);
            _Dr.R_nombreReceta = txtnombre.Text;
            _Dr.R_numeroPorcion = Convert.ToInt32(txtPorciones.Text);
            _Dr.R_descripcion = txtDescripcion.Text;
            _Dr.EP_idEstadoReceta = Convert.ToInt32(Session["idEstadoReceta"]);
            

            try
            {
                _Dr.CR_idCategoriaReceta = Convert.ToInt32(ddlCategoriaReceta.SelectedValue);
                _Dr.R_subcategoria = ddlSubCategoria.SelectedValue;
                _Dr.EP_idEstadoReceta = Convert.ToInt32(ddlEstadoReceta.SelectedValue);
            }
            catch (System.FormatException)
            {
                _Dr.CR_idCategoriaReceta = Convert.ToInt32(_Ccr.CargarCategoriaRecetaxNombre(txtCategoriaReceta.Text));
                _Dr.R_subcategoria = txtSubcategoria.Text;
                _Dr.EP_idEstadoReceta = _Cer.CargarIdEstadoxIdReceta(Convert.ToInt32(Session["IdReceta"]));
            }
            bool Eir = _Cr.ExistenciaImagen(Convert.ToInt32(Session["IdReceta"]));
            if (Eir == true)
            {
                _Dr.R_imagenReceta = _Cr.Consultar_ImagenReceta(Convert.ToInt32(Session["IdReceta"]));
                
            }
            else if (Eir == false || imagen_bytes(ImagenPreview) == new byte[0])
            {
                _Dr.R_imagenReceta = imagen_bytes(ImagenPreview);
            }
            _Cr.ActualizarReceta(_Dr);
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alertaExito()", true);
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
        protected void btnEditarEstadoReceta_Click(object sender, ImageClickEventArgs e)
        {
            ddlEstadoReceta.Visible = true;
            txtEstadoReceta.Visible = false;
        }
        protected void btnEditarSubCategoria_Click(object sender, ImageClickEventArgs e)
        {
            ddlSubCategoria.Visible = true;
            txtSubcategoria.Visible = false;
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