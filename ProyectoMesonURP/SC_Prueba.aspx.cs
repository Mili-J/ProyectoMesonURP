using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DTO;
using CTR;
using System.Data;

namespace ProyectoMesonURP
{
    public partial class SC_Prueba : System.Web.UI.Page
    {
        CTR_Insumo _CI= new CTR_Insumo();
        DTO_Insumo dto_i;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            dto_i = new DTO_Insumo();
            dt = (DataTable)Session["InsumosSeleccionados"];
            CargarStockInsumo(dt);
        }
        public void CargarStockInsumo(DataTable t)
        {
            gvprueba.DataSource = dt;
            gvprueba.DataBind();

        }
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    dto_i = new DTO_Insumo();
        //    dto_i.I_idInsumo = (int)Session["InsumoSeleccionado"];
        //    CargarStockInsumo(dto_i.I_idInsumo);
        //}
        //public void CargarStockInsumo(int i)
        //{
        //    gvprueba.DataSource = _CI.BuscarInsumoP(i);
        //    gvprueba.DataBind();

        //}
    }
}