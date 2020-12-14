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
    public partial class AgregarEquivalencia : System.Web.UI.Page
    {
        
        CTR_CategoriaInsumo objCatInsumo;
        DataSet dsCatInsumo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategoriaI();
            }
            
        }

        public void LoadCategoriaI()
        {
            objCatInsumo = new CTR_CategoriaInsumo();
            dsCatInsumo = new DataSet();
            dsCatInsumo= objCatInsumo.CTR_SelectCategoriaI();
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
            ddlInsumo.Items.Insert(0, "-- Seleccione --");
        }

        public DTO_Medida ObtenerMedidaI(int idInsumo)
        {
            DataTable dtInsumo = new DataTable();
            CTR_Insumo objInsumo = new CTR_Insumo();
            dtInsumo = objInsumo.BuscarInsumo(idInsumo);
            DTO_Medida objMedida = new DTO_Medida();
            foreach(DataRow row in dtInsumo.Rows)
            {
                objMedida.M_idMedida = Convert.ToInt32(row["M_idMedida"]);
                objMedida.M_nombreMedida = row["M_nombreMedida"].ToString();
            }
            return objMedida;
        }

        protected void ddlInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInsumo.SelectedValue != "")
            {
                int id = int.Parse(ddlInsumo.SelectedValue);
                txtMedida.Text=ObtenerMedidaI(id).M_nombreMedida;
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoria.SelectedValue != "")
            {
                DTO_CategoriaInsumo objCatInsumo = new DTO_CategoriaInsumo();
                objCatInsumo.CI_idCategoriaInsumo = int.Parse(ddlCategoria.SelectedValue);

                if (objCatInsumo.CI_idCategoriaInsumo!=0)
                {
                    LoadInsumo(objCatInsumo);
                }
            }
        }

        protected void btnAñadirEquivalencia_Click(object sender, EventArgs e)
        {

        }
    }
   
}   
