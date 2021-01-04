using System;
using CTR;
using CTR2;
using DAO;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class GestionarProveedor : System.Web.UI.Page
    {
        CTR_Proveedor ctr_pro = new CTR_Proveedor();
        DTO_Proveedor dto_pro;
        DAO_Proveedor dao_pro = new DAO_Proveedor();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }
        public void CargarProveedores()
        {
            gvPro.DataSource = ctr_pro.ListarProveedores();
            gvPro.DataBind();

        }
        protected void gvPro_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvPro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvPro_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        [System.Web.Services.WebMethod]              // Marcamos el método como uno web   
        public static string eliminarProveedor(int id, int estado)    // el método debe ser de static
        {
            CTR_Proveedor app = new CTR_Proveedor();
            String a;
            try
            {
                app.CambiarEstadoProveedor(id, estado);
                a = "todobien";
            }
            catch (Exception e)
            {
                a = "todomal  " + e.Message;
            }

            return a;
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {

        }
        protected void gvPro_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int estado = Convert.ToInt16(DataBinder.Eval(e.Row.DataItem, "EP_idEstadoProveedor").ToString());

                if (estado == 1)
                {
                    e.Row.Cells[7].Text = "<span class='badge badge-secondary'>" + "Activo" + "</span>";
                }
                else if (estado == 2)
                {
                    e.Row.Cells[7].Text = "<span class='badge badge-success'>" + "Inactivo" + "</span>";
                }
            }
        }
    }
}