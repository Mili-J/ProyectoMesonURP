using System;
using DTO;
using DTO2;
using CTR;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class RegistrarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]              // Marcamos el método como uno web   
        public static List<DTO_CategoriaInsumo> listarCategorias(int id)    // el método debe ser de static
        {
            CTR_CategoriaInsumo app = new CTR_CategoriaInsumo();
            List<DTO_CategoriaInsumo> data = new List<DTO_CategoriaInsumo>();
            //String a;
            try
            {
                data = app.ListarCategorias();
                //     a = "todobien";
            }
            catch (Exception e)
            {
                //     a = "todomal  " + e.Message;
            }

            return data;
        }

        [System.Web.Services.WebMethod]              // Marcamos el método como uno web   
        public static int registrarProveedor(string PR_razonSocial, string PR_numeroDocumento, string PR_direccion, string PR_nombreContacto, string PR_telefonoContacto, string PR_correoContacto)    // el método debe ser de static
        {
            DTO_Proveedor obj = new DTO_Proveedor();
            CTR_Proveedor app = new CTR_Proveedor();
            int a;
            try
            {
                obj.PR_razonSocial = PR_razonSocial;
                obj.PR_numeroDocumento = PR_numeroDocumento;
                obj.PR_direccion = PR_direccion;
                obj.PR_nombreContacto = PR_nombreContacto;
                obj.PR_telefonoContacto = PR_telefonoContacto;
                obj.PR_correoContacto = PR_correoContacto;
                obj.EP_idEstadoProveedor = 1;
                a = app.RegistrarProveedor(obj);

            }
            catch (Exception e)
            {
                a = 0;
            }

            return a;
        }


        [System.Web.Services.WebMethod]              // Marcamos el método como uno web   
        public static void registrarCategoria(int idProveedor, int idCategoria)    // el método debe ser de static
        {
            DTO_ProveedorXCategoria obj = new DTO_ProveedorXCategoria();
            CTR_Proveedor app = new CTR_Proveedor();
            try
            {

                app.RegistrarProveedorxCategoria(idProveedor, idCategoria);

            }
            catch (Exception e)
            {
                //e.Message;
            }
        }
    }
}
