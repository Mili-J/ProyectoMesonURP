using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace ProyectoMesonURP
{
    public partial class ActualizarEquivalencia : System.Web.UI.Page
    {
        CTR_CategoriaInsumo objCatInsumo;
        CTR_Ingrediente objIngrediente;
        DataSet dsCatInsumo;
        int idMFCO = 0;
        int idM = 0;
        int idI = 0;
        int idE = 0;
        int idMedida = 0;
        int idFCocina = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LoadCategoriaI();
                llenarDDLFormatoC();
                LLenarDatosE();
            }

        }

        public void LoadCategoriaI()
        {
            objCatInsumo = new CTR_CategoriaInsumo();
            dsCatInsumo = new DataSet();
            dsCatInsumo = objCatInsumo.CTR_SelectCategoriaI();
            ddlCategoria.DataTextField = "CI_nombreCategoria";
            ddlCategoria.DataValueField = "CI_idCategoriaInsumo";
            ddlCategoria.DataSource = dsCatInsumo;
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, "-- Seleccione --");
        }
        public void LoadInsumo(DTO_CategoriaInsumo objCInsumo)
        {
            DataSet dsInsumo = new DataSet();
            CTR_CategoriaInsumo objCatInsumo = new CTR_CategoriaInsumo();
            dsInsumo = objCatInsumo.CTR_SelectInsumoXCategoria(objCInsumo);
            ddlInsumo.DataTextField = "I_nombreInsumo";
            ddlInsumo.DataValueField = "I_idInsumo";
            ddlInsumo.DataSource = dsInsumo;
            ddlInsumo.DataBind();
            ddlInsumo.Items.Insert(0, "Seleccione");
        }
        public void llenarDDLFormatoC()
        {
            DataSet dsFormatoC = new DataSet();
            CTR_Ingrediente objIngrediente = new CTR_Ingrediente();
            dsFormatoC = objIngrediente.ListarFCocina();
            ddlFormatoCocina.DataTextField = "FCO_nombreFormatoCocina";
            ddlFormatoCocina.DataValueField = "FCO_idFCocina";
            ddlFormatoCocina.DataSource = dsFormatoC;
            ddlFormatoCocina.DataBind();
            ddlFormatoCocina.Items.Insert(0, "Seleccione");
        }
        public void LLenarDatosE()
        {
            string[] E = new string[4];
            E= (string[])Session["Equivalencia"];
            txtInsumo.Text = E[0];
            txtMedida.Text = E[1];       
            txtCantidad.Text = E[2];
            lblFormatoC.Text = E[3];           
        }

        public DTO_Medida ObtenerMedidaI(int idInsumo)
        {
            DataTable dtInsumo = new DataTable();
            CTR_Insumo objInsumo = new CTR_Insumo();
            dtInsumo = objInsumo.BuscarInsumo(idInsumo);
            DTO_Medida objMedida = new DTO_Medida();
            foreach (DataRow row in dtInsumo.Rows)
            {
                objMedida.M_idMedida = Convert.ToInt32(row["M_idMedida"]);
                objMedida.M_nombreMedida = row["M_nombreMedida"].ToString();
            }
            return objMedida;
        }
        public int ObtenerIDMedidaXFCocina(int idMedida, int idFCocina)
        {
            DataTable dtFCocina = new DataTable();
            CTR_MedidaXFormatoCocina objMedidaFC = new CTR_MedidaXFormatoCocina();
            //dtFCocina = objMedidaFC.ListarIDMedidaXFCocina();

            foreach (DataRow row in dtFCocina.Rows)
            {
                int idM = Convert.ToInt32(row["M_idMedida"]);
                int idFC = Convert.ToInt32(row["FCO_idFCocina"]);
                if (idM == idMedida && idFC == idFCocina) idMFCO = Convert.ToInt32(row["MXFC_idMedidaFCocina"]);
            }
            return idMFCO;
        }
        protected void ddlFormatoC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoria.SelectedValue != "")
            {
                DTO_CategoriaInsumo objCatInsumo = new DTO_CategoriaInsumo();
                objCatInsumo.CI_idCategoriaInsumo = int.Parse(ddlCategoria.SelectedValue);

                if (objCatInsumo.CI_idCategoriaInsumo != 0)
                {
                    LoadInsumo(objCatInsumo);
                }
            }
        }

        protected void ddlInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInsumo.SelectedValue != "")
            {
                int id = int.Parse(ddlInsumo.SelectedValue);
                txtMedida.Text = ObtenerMedidaI(id).M_nombreMedida;
            }
        }

        protected void btnEditarEquivalencia_Click(object sender, EventArgs e)
        {
            CTR_Equivalencia CTREqui = new CTR_Equivalencia();
            DTO_Equivalencia DTOEqui = new DTO_Equivalencia();
            idM = (int)Session["idMedida"];
            idI = (int)Session["idInsumo"];
            idE = (int)Session["idEquivalencia"];
            if (ddlInsumo.SelectedValue == "" || ddlInsumo.SelectedValue == "Seleccione")
            {
                DTOEqui.I_idInsumo = idI;
                idMedida = ObtenerMedidaI(idI).M_idMedida;
            }
            else
            {
                DTOEqui.I_idInsumo = Convert.ToInt32(ddlInsumo.SelectedValue);
                idMedida = ObtenerMedidaI(DTOEqui.I_idInsumo).M_idMedida;
            }

            DTOEqui.E_cantidad = Convert.ToDecimal(txtCantidad.Text);
            idFCocina = int.Parse(ddlFormatoCocina.SelectedValue);
            DTOEqui.MXFC_idMedidaFCocina = ObtenerIDMedidaXFCocina(idMedida, idFCocina);
            DTOEqui.E_idEquivalencia = idE;
            CTREqui.ActualizarEquivalencia(DTOEqui);
        }
    }
}