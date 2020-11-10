﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;

namespace ProyectoMesonURP
{
	public partial class SeleccionarMenuTransformar : System.Web.UI.Page
	{
		CTR_Receta ctr_receta;
		DataTable dt;
		int porciones = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			ctr_receta = new CTR_Receta();
			dt = new DataTable();
			dt = ctr_receta.CTR_Consultar_Receta2();
			if (!Page.IsPostBack)
			{
				GridView1.DataSource = dt;
				GridView1.DataBind();
			}
		}
		protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
		{

			if (e.CommandName == "TransformarI")
			{
				int idReceta = Convert.ToInt32(GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["R_idReceta"].ToString());
				Session.Add("idReceta", idReceta);
				porciones = int.Parse(txtPorciones.Text);
				Session.Add("Porciones", porciones);
				Response.Redirect("TransformarInsumo");

			}
		}
	}
}