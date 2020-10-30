using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTR;
using DTO;


namespace ProyectoMesonURP
{
    public partial class Transformar_Insumo : System.Web.UI.Page
    {
        CTR_Insumo ctr_insumo;
        DTO_Insumo dto_insumo;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            ctr_insumo = new CTR_Insumo();
            dto_insumo = new DTO_Insumo();
            dto_insumo.I_idInsumo = int.Parse(txtInsumo.Text);
            dt=ctr_insumo.CTR_CONSULTAR_EQUIVALENCIA_X_INSUMO(dto_insumo);
         
        }
        public void FormatoCocina()
        {
            ListItem i;
            foreach (DataRow r in dt.Rows)
            {
                i = new ListItem(r["FCO_nombreFormatoCocina"].ToString());
                ddlFormatoCocina.Items.Add(i);
            }
        }

    }
}