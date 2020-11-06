using CTR;
using DTO;
using System;
using System.Drawing;
using System.IO;
using System.Web.UI;

namespace ProyectoMesonURP
{
    public partial class RegistrarReceta : System.Web.UI.Page
    {
        CTR_Receta _Cr = new CTR_Receta();
        DTO_Receta _Dr = new DTO_Receta();
        CTR_CategoriaReceta _Ccr = new CTR_CategoriaReceta();
        CTR_Ingrediente _Ci = new CTR_Ingrediente();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListarCategoriaReceta();
            ListarIngredientes();
        }
        public void ListarCategoriaReceta()
        {
            ddlCategoriaReceta.DataSource = _Ccr.CargarCategoriaReceta();
            ddlCategoriaReceta.DataTextField = "CR_nombreCategoria";
            ddlCategoriaReceta.DataValueField = "CR_idCategoriaReceta";
            ddlCategoriaReceta.DataBind();
            ddlCategoriaReceta.Items.Insert(0, "--seleccionar--");
        }
        public void ListarIngredientes()
        {
            ddlIngredientes.DataSource = _Ci.CargarIngredientes();
            ddlIngredientes.DataTextField = "I_nombreIngrediente";
            ddlIngredientes.DataValueField = "I_idIngrediente";
            ddlIngredientes.DataBind();
            ddlIngredientes.Items.Insert(0, "--seleccionar--");
        }
        protected void ddlCategoriaReceta_Change(object sender, EventArgs e)
        {

            //if (ddlCategoriaReceta.SelectedIndex != 0)
            //{
            //    txtUnidadMedida.Text = _Cm.BuscarMedida(Convert.ToInt32(ddlInsumos.SelectedValue));
            //    txtOculto.Text = _Cmxi.VerificarStockMin(Convert.ToInt32(ddlInsumos.SelectedValue));
            //}
            //else
            //{
                
            //    ScriptManager.RegisterClientScriptBlock(this.PanelAñadir, this.PanelAñadir.GetType(), "alertaSeleccionar", "alertaSeleccionar();", true);
            //    return;
            //}

        }
        protected void gvIngredientes_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            
        }
        protected void gvIngredientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnAñadirIngrediente_Click(object sender, EventArgs e)
        {
           

        }
        protected void btnGuardar_ServerClick(object sender, EventArgs e)
        {
            
                _Dr.R_nombreReceta = txtnombre.Text;
                _Dr.R_imagenReceta = imagen_bytes(ImagenPreview);
                _Dr.R_numeroPorcion = Convert.ToInt32(txtPorciones.Text);
                 _Dr.CR_idCategoriaReceta = 1;
                _Dr.R_descripcion = txtDescripcion.Text;
             
                _Cr.RegistrarReceta(_Dr);
            
        }
        protected void btnRegresar_ServerClick(object sender, EventArgs e)
        {
            
        }
        protected void btnLimpiar_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            int tamaño = fuImagen.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamaño];

            fuImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, tamaño);

            Bitmap ImagenOriginalBinaria = new Bitmap(fuImagen.PostedFile.InputStream);

            string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);

            ImagenPreview.ImageUrl = ImagenDataURL64;

        }
        private Byte[] imagen_bytes(System.Web.UI.WebControls.Image foto)
        {

            if (!(foto == null))
            {
                int tamaño = fuImagen.PostedFile.ContentLength;
                byte[] ImagenOriginal = new byte[tamaño];
                fuImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, tamaño);
                return ImagenOriginal;


            }
            else
                return null;

        }
    }
}