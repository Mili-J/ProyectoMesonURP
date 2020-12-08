using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoMesonURP
{
    public partial class Recepción_Insumos : System.Web.UI.Page
    {
        CTR_OC _OC = new CTR_OC();
        CTR_Movimiento _MO = new CTR_Movimiento();
        CTR_DetalleOC _DO = new CTR_DetalleOC();
        CTR_Insumo _I = new CTR_Insumo();
        DTO_OC dto_oc;
        DTO_Movimiento dto_mov;
        DTO_Usuario dto_us;
        DTO_Insumo dto_i;
        int oc;
        static DataTable dt = new DataTable();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login?x=1");
            }
            if (!Page.IsPostBack)
            {
                dto_oc = new DTO_OC();
                oc = (int)Session["OCSeleccionada"];
                CargarInsumosOC(oc);
                CargarIngresosOC(dt);
            }

        }
        public void CargarInsumosOC(int oc)
        {
            gvInsumos.DataSource = _OC.ListarOC2(oc);
            gvInsumos.DataBind();

        }
        public void CargarIngresosOC(DataTable dt)
        {
            gvIngresos.DataSource = dt;
            gvIngresos.DataBind();

        }
        protected void gvInsumos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            oc = (int)Session["OCSeleccionada"];
            gvInsumos.PageIndex = e.NewPageIndex;
            CargarInsumosOC(oc);
        }
        protected void gvIngresos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvIngresos.PageIndex = e.NewPageIndex;
            CargarIngresosOC(dt);
        }


        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow r in gvInsumos.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    r.ToolTip = "Click to select row";
                    r.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.gvInsumos, "Select$" + r.RowIndex, true);

                }
            }

            base.Render(writer);
        }

        protected void gvInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in gvInsumos.Rows)
                {
                    if (row.RowIndex == gvInsumos.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        row.ToolTip = string.Empty;
                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = "Click to select this row.";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void gvIngresos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(gvInsumos.DataKeys[gvInsumos.SelectedIndex].Values["I_idInsumo"]);
            string nom = (gvInsumos.DataKeys[gvInsumos.SelectedIndex].Values["I_nombreInsumo"].ToString());
            string Hoy = DateTime.Now.ToString("MM/dd/yyyy");
            string Ahora = DateTime.Now.ToString("HH:mm:ss");
            decimal cantidad = Convert.ToDecimal(txtCantidad.Text);
            int idDCO = Convert.ToInt32(gvInsumos.DataKeys[gvInsumos.SelectedIndex].Values["DC_idDetalleCotizacion"].ToString()); 

            DataRow row = dt.NewRow();
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("I_idInsumo");
                dt.Columns.Add("I_nombreInsumo");
                dt.Columns.Add("M_fechaMovimiento");
                dt.Columns.Add("Hora");
                dt.Columns.Add("M_cantidad");
                dt.Columns.Add("DC_idDetalleCotizacion");
            }
                           
                
                    row[0] = id;
                    row[1] = nom;
                    row[2] = Hoy;
                    row[3] = Ahora;
                    row[4] = cantidad;
                    row[5] = idDCO;
                    dt.Rows.Add(row);
                    CargarIngresosOC(dt);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            dto_us = (DTO_Usuario)Session["Usuario"];
            foreach (GridViewRow grvRow in gvIngresos.Rows)
            {
                dto_mov = new DTO_Movimiento();
                dto_mov.U_idUsuario = dto_us.U_idUsuario;
                dto_mov.I_idInsumo = Convert.ToInt32(gvIngresos.DataKeys[grvRow.RowIndex].Values["I_idInsumo"]);
                string fecha = (gvIngresos.DataKeys[grvRow.RowIndex].Values["M_fechaMovimiento"].ToString()) + " " + (gvIngresos.DataKeys[grvRow.RowIndex].Values["Hora"].ToString());
                dto_mov.M_fechaMovimiento = DateTime.ParseExact(fecha, "MM/dd/yyyy HH:mm:ss", null);
                dto_mov.M_cantidad = Convert.ToDecimal(gvIngresos.DataKeys[grvRow.RowIndex].Values["M_cantidad"].ToString());
                int idOC = Convert.ToInt32(gvIngresos.DataKeys[grvRow.RowIndex].Values["DC_idDetalleCotizacion"]);
                _DO.UPDATE_cantidadEntregada(dto_mov.M_cantidad, idOC);
                _I.UPDATE_cantidadInsumoOC(dto_mov.M_cantidad, dto_mov.I_idInsumo);
                _MO.InsertMovGO(dto_mov);
            }
            dt.Clear();
            oc = (int)Session["OCSeleccionada"];
            CargarInsumosOC(oc);
            CargarIngresosOC(dt);
        }
    }
}