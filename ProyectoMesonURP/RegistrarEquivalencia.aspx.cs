using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using CTR2;
using DTO;
using DTO2;

namespace ProyectoMesonURP
{
    public partial class RegistrarEquivalencia : System.Web.UI.Page
    {
        CTR_MedidaXFormatoCocina objFormatoC = new CTR_MedidaXFormatoCocina();
        DTO_MedidaXFormatoCocina _Dmxfcoc = new DTO_MedidaXFormatoCocina();
        DTO_FormatoCocina _Dfcoc = new DTO_FormatoCocina();
        CTR_Formato_Cocina _Cfcoc = new CTR_Formato_Cocina();
        CTR_Ingrediente objIngrediente = new CTR_Ingrediente();
        DTO_Ingrediente _Di = new DTO_Ingrediente();
        DTO_Equivalencia _De = new DTO_Equivalencia();
        CTR_Equivalencia _Ce = new CTR_Equivalencia();
        CTR_Medida _Cm = new CTR_Medida();
        DTO_Medida _Dm = new DTO_Medida();
        DataTable dt = new DataTable();
        static int id { get; set; }
        int idMFCO = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFCocina();
                LoadIngrediente();
                CargargvEquivalencia();
                lblIndex.Text = id.ToString();
            }

        }
        public void LoadIngrediente()
        {
            _Di.I_idIngrediente = Convert.ToInt32(Session["idIngrediente"]);
            txtInsumo.Text = Convert.ToString(Session["insumo"]);
            txtIngrediente.Text = Convert.ToString(Session["ingrediente"]);
        }
        public void CargargvEquivalencia()
        {
            _Ce = new CTR_Equivalencia();
            dt = _Ce.CTRListarEquivalencia(Convert.ToInt32(Session["idIngrediente"]));
            gvEquivalencia.DataSource = dt;
            gvEquivalencia.DataBind();
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
            dtFCocina = objMedidaFC.ListarIDMedidaXFCocina2();

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
            _De.E_cantidad = Convert.ToDecimal(txtCantidad.Text);
            _De.I_idIngrediente = Convert.ToInt32(Session["idIngrediente"]);
            int I_idIngrediente = Convert.ToInt32(Session["idIngrediente"]);
            int idFCocina = Convert.ToInt32(ddlFormatoCocina.SelectedValue);
            _Dfcoc = _Cfcoc.CTR_ListarNombreFCocina(idFCocina);
            int idMedida = Convert.ToInt32(ddlMedida.SelectedValue);
            _Dm = _Cm.CTR_ListarNombreMedida(idMedida);
            _De.MXFC_idMedidaFCocina = ObtenerIDMedidaXFCocina(idMedida, idFCocina);
            int MXFC_idMedidaFCocina = Convert.ToInt32(_De.MXFC_idMedidaFCocina);

            _De = new DTO_Equivalencia();

            bool Eixmfc = _Ce.CTRExistenciaIngredientexMxfc(I_idIngrediente, MXFC_idMedidaFCocina);
            int a = 0;

            if (Eixmfc)
            {
                a = 1;
                ScriptManager.RegisterStartupScript(this, GetType(), "alertaDuplicado", "alertaDuplicado()", true);
                return;
            }
            else
            {
                try
                {
                    _De.E_cantidad = Convert.ToDecimal(txtCantidad.Text);
                    _De.I_idIngrediente = Convert.ToInt32(Session["idIngrediente"]);
                    _Dfcoc = _Cfcoc.CTR_ListarNombreFCocina(idFCocina);
                    _Dm = _Cm.CTR_ListarNombreMedida(idMedida);
                    _De.MXFC_idMedidaFCocina = ObtenerIDMedidaXFCocina(idMedida, idFCocina);

                    _Ce.AgregarEquivalencia(_De);
                    CargargvEquivalencia();
                }
                catch (System.FormatException)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "randomtext", "alertaError()", true);
                    return;
                }
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
        }
        protected void btnGuardar_ServerClick(object sender, EventArgs e)
        {
        }
    }
}