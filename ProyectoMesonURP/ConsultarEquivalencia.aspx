<%@ Page Title="Equivalencia | Consultar" Language="C#" AutoEventWireup="true" CodeBehind="ConsultarEquivalencia.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.ConsultarEquivalencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="women_main">
        <div class="page-header">
			<div class="row">
				<div class="col-md-6 col-sm-12">
					<div class="title">
						<h4>Consultar Equivalencia</h4>
					</div>
				</div>
			</div>
		</div>
    <div class="pd-20 card-box">
        <asp:UpdatePanel ID="panelInsumo" runat="server">
            <ContentTemplate>
                <div class="form-group row justify-content-center">
                        <label class="col-sm-12 col-md-5 col-form-label">Ingrediente</label>
                        <div class="col-sm-12 col-md-6">
                        <asp:TextBox ID="txtIngrediente" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            <div class="panel panel-widget forms-panel">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h5>Detalle de Equivalencia de Ingrediente</h5>
                    </div>
                    <div class="w3-row-padding">
                        <div class="table-wrapper-scroll-y my-custom-scrollbar" runat="server">
                            <asp:GridView ID="gvEquivalencia" allowpaging="True" runat="server" DataKeyNames="I_idIngrediente,I_nombreIngrediente,E_cantidad,MXFC_idMedidaFCocina, M_nombreMedida, FCO_nombreFormatoCocina"
                                EmptyDataText="No hay información disponible." AutoGenerateColumns="False" Style="text-align: center" CellPadding="4" PageSize="5" GridLines="None" CssClass="table table-bordered table-striped mb-0" OnPageIndexChanging="gvEquivalencia_PageIndexChanging">
                               <PagerStyle HorizontalAlign="Right" BackColor="#dee2e6"> </PagerStyle> 
                                <Columns>
                                    <asp:BoundField DataField="I_idIngrediente" HeaderText="I_idIngrediente" Visible="false" />
                                    <asp:BoundField HeaderText="I_nombreIngrediente" DataField="I_nombreIngrediente" Visible="false"/>
                                    <asp:BoundField DataField="FCO_nombreFormatoCocina" HeaderText="Formato Cocina"/>
                                    <asp:BoundField DataField="E_cantidad" HeaderText="Cantidad"/>
                                    <asp:BoundField DataField="MXFC_idMedidaFCocina" HeaderText="MXFC_idMedidaFCocina" Visible="false" />
                                    <asp:BoundField DataField="M_nombreMedida" HeaderText="Medida" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="form-group center-button">
                    <asp:Button CssClass="btn btn-danger" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
</asp:Content>
