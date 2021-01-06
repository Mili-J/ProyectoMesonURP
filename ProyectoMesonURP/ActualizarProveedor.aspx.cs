using System;
using CTR;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class ActualizarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]              // Marcamos el método como uno web   
        public static List<int> TraerCategorias(int PR_idProveedor)    // el método debe ser de static
        {
            CTR_Proveedor app = new CTR_Proveedor();
            List<int> lista = new List<int>();
            String a;
            try
            {
                lista = app.TraerCategorias(PR_idProveedor);
                a = "todobien";
            }
            catch (Exception e)
            {
                a = "todomal  " + e.Message;
            }

            return lista;
        }

        [System.Web.Services.WebMethod]              // Marcamos el método como uno web   
        public static DTO_Proveedor traerProveedor(int PR_idProveedor)    // el método debe ser de static
        {
            CTR_Proveedor app = new CTR_Proveedor();
            DTO_Proveedor proveedor = new DTO_Proveedor();
            String a;
            try
            {
                proveedor = app.traerProveedor(PR_idProveedor);
                a = "todobien";
            }
            catch (Exception e)
            {
                a = "todomal  " + e.Message;
            }

            return proveedor;
        }

        [System.Web.Services.WebMethod]              // Marcamos el método como uno web   
        public static string actualizarProveedor(int PR_idProveedor, string PR_razonSocial, string PR_numeroDocumento, string PR_direccion, string PR_nombreContacto, string PR_telefonoContacto, string PR_correoContacto, string listaEliminar, string listaAgregar)    // el método debe ser de static
        {

            CTR_Proveedor app = new CTR_Proveedor();
            DTO_Proveedor proveedor = new DTO_Proveedor();
            String a = "";
            try
            {


                try
                {
                    if (listaAgregar.Length > 1)
                    {
                        String[] parts2 = listaAgregar.Split(',');
                        foreach (var sub2 in parts2)
                        {
                            app.RegistrarProveedorxCategoria(PR_idProveedor, int.Parse(sub2));
                        }
                    }
                    if (listaAgregar.Length == 1)
                    {
                        app.RegistrarProveedorxCategoria(PR_idProveedor, int.Parse(listaAgregar));
                    }
                }
                catch (Exception b)
                {
                    throw b;
                }

                try
                {

                    if (listaEliminar.Length > 1)
                    {
                        String[] parts2 = listaEliminar.Split(',');
                        foreach (var sub2 in parts2)
                        {
                            app.EliminarProveedorxCategoria(PR_idProveedor, int.Parse(sub2));
                        }
                    }
                    if (listaEliminar.Length == 1)
                    {
                        app.EliminarProveedorxCategoria(PR_idProveedor, int.Parse(listaEliminar));
                    }

                }
                catch (Exception c)
                {
                    throw c;
                }
                proveedor.PR_idProveedor = PR_idProveedor;
                proveedor.PR_razonSocial = PR_razonSocial;
                proveedor.PR_numeroDocumento = PR_numeroDocumento;
                proveedor.PR_direccion = PR_direccion;
                proveedor.PR_nombreContacto = PR_nombreContacto;
                proveedor.PR_telefonoContacto = PR_telefonoContacto;
                proveedor.PR_correoContacto = PR_correoContacto;
                app.actualizarProveedor(proveedor);
                a = "todobien" + " listaEliminar " + listaEliminar + " listaagregar" + listaAgregar;
            }
            catch (Exception e)
            {
                a = "todomal  " + e.Message + " listaEliminar " + listaEliminar + " listaagregar" + listaAgregar;
            }

            return a;
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarProveedor.aspx");
        }
    }
}