using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;


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

        protected void btnCargarFoto_Click(object sender, EventArgs e)
        {
            insertarFotoReceta();
        }
        private Byte[] imagen_bytes(System.Drawing.Image foto)
        {
            if (!(foto == null))
            {
                MemoryStream ms = new MemoryStream();
                foto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.GetBuffer();
            }
            else
                return null;
        }
        private System.Drawing.Image bytes_imagen(Byte[] foto)
        {
            if (!(foto == null))
            {
                MemoryStream ms = new MemoryStream(foto);
                System.Drawing.Image resultado = System.Drawing.Image.FromStream(ms);
                return resultado;
            }
            else
                return null;
        }
        public void insertarFotoReceta()
        {

            Boolean correcto = false;
            if (idFoto.HasFile)
            {
                String extencionArchivo = Path.GetExtension(idFoto.FileName).ToLower();
                String[] extencionesPermitidas = { ".png", ".jpg", ".jpeg" };
                for (int i = 0; i < extencionesPermitidas.Length; i++)
                {
                    if (extencionArchivo == extencionesPermitidas[i])
                    {
                        correcto = true;
                    }
                }
                if (correcto)
                {
                    ViewState["@R_imagenReceta"] = Path.GetFileName(idFoto.FileName);
                    idFoto.SaveAs(Server.MapPath("~/img/") + ViewState["@R_imagenReceta"].ToString());
                    Imagen.ImageUrl = "~/img/" + ViewState["@R_imagenReceta"];
                    Imagen.DataBind();
                }
            }
        }
        protected void btnAñadirIngrediente_Click(object sender, EventArgs e)
        {
            System.Drawing.Image rfoto = System.Drawing.Image.FromFile(Server.MapPath("~/img/") + ViewState["@Photo"]);
            _Dr.R_nombreReceta = txtnombre.Text;
            _Dr.R_imagenReceta = imagen_bytes(rfoto);
            _Dr.R_numeroPorcion = Convert.ToInt32(txtPorciones.Text);
            _Dr.CR_idCategoriaReceta = Convert.ToInt32(ddlCategoriaReceta.SelectedValue);

        }
    }
}