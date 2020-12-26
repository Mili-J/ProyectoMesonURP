using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using CTR2;
using DTO;
using DTO2;

namespace ProyectoMesonURP
{
    public partial class AgregarEquivalencia : System.Web.UI.Page
    {
        CTR_MedidaXFormatoCocina objFormatoC = new CTR_MedidaXFormatoCocina();
        DTO_MedidaXFormatoCocina _Dmxfcoc = new DTO_MedidaXFormatoCocina();
        DTO_FormatoCocina _Dfcoc = new DTO_FormatoCocina();
        CTR_Formato_Cocina _Cfcoc = new CTR_Formato_Cocina();
        CTR_Ingrediente objIngrediente = new CTR_Ingrediente();
        DTO_Equivalencia _De = new DTO_Equivalencia();
        CTR_Medida _Cm = new CTR_Medida();
        DTO_Medida _Dm = new DTO_Medida();
        static DataTable tin = new DataTable();
        static List<DTO_Equivalencia> pila = new List<DTO_Equivalencia>();
        static int id { get; set; }
        int idMFCO = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFCocina();
                LoadIngrediente();
            }
            
        }
        public void LoadIngrediente()
        {
            txtInsumo.Text = Convert.ToString(Session["insumo"]);
            txtIngrediente.Text = Convert.ToString(Session["ingrediente"]);
        }
        public void LoadFCocina()
        {
            ddlFormatoCocina.DataSource = objIngrediente.ListarFCocina();
            ddlFormatoCocina.DataTextField = "FCO_nombreFormatoCocina";
            ddlFormatoCocina.DataValueField = "FCO_idFCocina";
            ddlFormatoCocina.DataBind();
            ddlFormatoCocina.Items.Insert(0, "--seleccionar--");
        }
        public void ListarMedidaXFormatoCocina(DTO_MedidaXFormatoCocina objFCocina)
        {
            ddlMedida.DataSource = objFormatoC.ListarIDMedidaXFCocina(objFCocina);
            ddlMedida.DataTextField = "M_nombreMedida";
            ddlMedida.DataValueField = "M_idMedida";
            ddlMedida.DataBind();
            ddlMedida.Items.Insert(0, "--seleccionar--");
        }
        protected void ddlFormatoCocina_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (ddlFormatoCocina.SelectedValue != "")
            {
                DTO_MedidaXFormatoCocina objFCocina = new DTO_MedidaXFormatoCocina();
                objFCocina.FCO_idFCocina = int.Parse(ddlFormatoCocina.SelectedValue);

                if (objFCocina.FCO_idFCocina != 0)
                {
                    ListarMedidaXFormatoCocina(objFCocina);
                } 
            }
        }
        public int ObtenerIDMedidaXFCocina(int idMedida, int idFCocina)
        {
            DataTable dtFCocina = new DataTable();
            CTR_MedidaXFormatoCocina objMedidaFC = new CTR_MedidaXFormatoCocina();
            dtFCocina = objMedidaFC.ListarIDMedidaXFCocina();

            foreach (DataRow row in dtFCocina.Rows)
            {
                int idM = Convert.ToInt32(row["M_idMedida"]);
                int idFC = Convert.ToInt32(row["FCO_idFCocina"]);
                if (idM == idMedida && idFC == idFCocina) idMFCO = Convert.ToInt32(row["MXFC_idMedidaFCocina"]);
            }
            return idMFCO;
        }
        protected void btnAñadirEquivalencia_Click(object sender, EventArgs e)
        {
            _De.I_idIngrediente = objIngrediente.CTR_IdIngrediente() + 1;
            _De.E_cantidad = Convert.ToDecimal(txtCantidad.Text);
            _Dmxfcoc.FCO_idFCocina = Convert.ToInt32(ddlFormatoCocina.SelectedValue);
            _Dfcoc = _Cfcoc.CTR_ListarNombreFCocina(_Dmxfcoc.FCO_idFCocina);
            _Dmxfcoc.M_idMedida = Convert.ToInt32(ddlMedida.SelectedValue);
            _Dm = _Cm.CTR_ListarNombreMedida(_Dmxfcoc.M_idMedida);

            int id = int.Parse(ddlInsumo.SelectedValue);
            int idMedida = ObtenerMedidaI(id).M_idMedida;
            int idFCocina = int.Parse(ddlFormatoCocina.SelectedValue);
            DTOEqui.MXFC_idMedidaFCocina = ObtenerIDMedidaXFCocina(idMedida, idFCocina);
            CTREqui.AgregarEquivalencia(DTOEqui);

            DataRow row = tin.NewRow();
            if (tin.Columns.Count == 0)
            {
                tin.Columns.Add("Cantidad");
                tin.Columns.Add("Formato Cocina");
            }
            if (tin.Rows.Count > 0)
            {
                // Primero averigua si el registro existe:
                bool existe = false;
                for (int i = 0; i < tin.Rows.Count; i++)
                {
                    if (Convert.ToString(gvEquivalencia.Rows[i].Cells[1].Text) == Convert.ToString(_Dfcoc.FCO_nombreFormatoCocina) &&
                        Convert.ToString(gvEquivalencia.Rows[i].Cells[3].Text) == Convert.ToString(_Dm.M_nombreMedida))
                    {
                        existe = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alertaDuplicado()", true);
                        break;
                    }
                }
                // Luego, ya fuera del ciclo, solo si no existe, realizas la insercion:
                if (existe == false)
                {
                    pila.Add(_De);

                    row[0] = _De.E_cantidad;
                    row[1] = _De.MXFC_idMedidaFCocina;
                    tin.Rows.Add(row);

                    gvEquivalencia.DataSource = tin;
                    gvEquivalencia.DataBind();
                }
            }
            else
            {
                pila.Add(_De);

                row[0] = _De.E_cantidad;
                row[1] = _De.MXFC_idMedidaFCocina;
                tin.Rows.Add(row);

                gvEquivalencia.DataSource = tin;
                gvEquivalencia.DataBind();
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarEquivalencia.aspx");
        }
        protected void gvEquivalencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = Convert.ToInt32(gvEquivalencia.SelectedRow.RowIndex);
            lblIndex.Text = id.ToString();

        }
        protected void gvEquivalencia_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvEquivalencia, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Haga click para seleccionar la fila.";
                id = e.Row.RowIndex;
            }
        }

    }
   
}   
