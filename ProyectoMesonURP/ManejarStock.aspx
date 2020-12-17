<%@ Page Title="Mesón URP | Manejar Stock" Language="C#" AutoEventWireup="true" CodeBehind="ManejarStock.aspx.cs"  MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.ManejarStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .mb-0 {}
    </style>
        <link rel="stylesheet" type="text/css" href="vendors/styles/core.css">
    	<link rel="stylesheet" type="text/css" href="vendors/styles/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="women_main">
        <!-- start content -->
    <div class="page-header">
	    <div class="row">
		    <div class="col-md-6 col-sm-12">
			    <div class="title">
				    <h4>Manejar Stock</h4>
			    </div>
		    </div>
	    </div>
    </div>
    <div class="pd-20 card-box"  runat="server" id="PanelInsumos">
        <div class="row pt-1">    
            <div class="col-sm-12 col-md-6">            
                <label class="control-label col-md-2">Paginación:</label>
                        <asp:DropDownList ID="ddlp" class="custom-select custom-select-sm form-control form-control-sm" style="width: auto; height: 38px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlp_SelectedIndexChanged">
                        </asp:DropDownList>
            </div>
             <div class="col-sm-12 col-md-3 pl-30"></div>
             <div class="col-sm-12 col-md-3 pl-30">
                 <div class="search-icon-box bg-white box-shadow border-radius-10 mb-30">
                      <asp:TextBox ID="txtBuscarInsumo" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="fNombreInsumo_TextChanged" onkeypress="return lettersOnly(event);" placeholder="Buscar Insumo ..."/>
					<i class="search_icon dw dw-search"></i>
				</div>
             </div>
         </div>
       <div class="panel panel-widget forms-panel" >
        <div class="form-grids widget-shadow" data-example-id="basic-forms">
            <div class="form-title color-white">
                <h5>Stock Actual</h5>
            </div>
                <div class="w3-row-padding">
                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                        <asp:GridView ID="gvInsumos" allowpaging="True"  OnRowDataBound="gvInsumos_RowDataBound" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."  
                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_idInsumo,I_NombreInsumo,CI_nombreCategoria,Cantidad,Representacion de compra,El_nombreEstado"  
                            Style="text-align: center" OnPageIndexChanging="gvInsumos_PageIndexChanging" OnRowCommand="gvInsumos_RowCommand" CellPadding="4" PageSize="5" GridLines="None">
                            <PagerStyle HorizontalAlign="Right" BackColor="#dee2e6"> </PagerStyle> 
                            <Columns>
                                <asp:BoundField DataField="I_idInsumo" HeaderText="Id_Insumo" Visible="False" />
                                <asp:BoundField DataField="I_NombreInsumo" HeaderText="Insumo" />
                                <asp:BoundField DataField="CI_nombreCategoria" HeaderText="Categoría" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="Representacion de compra" HeaderText="Representación de compra" />
                                <asp:BoundField DataField="El_nombreEstado" HeaderText="Estado"/>                                            

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="padding-top-30" runat="server" id="PanelInsumos2">  
    <div class="pd-20 card-box">
        <div class="panel panel-widget forms-panel">
                <div class="form-grids widget-shadow" data-example-id="basic-forms" >
                <div class="form-title color-white">
                    <h5>Insumos que requieren abastecimiento</h5>
                </div>
                <div class="table-wrapper-scroll-y my-custom-scrollbar">
                    <asp:GridView ID="gvInsumos2" OnRowDataBound="gvInsumos2_RowDataBound" allowpaging="True" runat="server" AutoGenerateColumns="False" emptydataText="No hay información disponible."  
                    CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_idInsumo,I_NombreInsumo,I_cantidadMinima,I_cantidad,El_nombreEstado" 
                    Style="text-align: center" OnPageIndexChanging="gvInsumos2_PageIndexChanging" CellPadding="4" PageSize="5" GridLines="None" EnablePersistedSelection="True">
                     <PagerStyle HorizontalAlign="Right" BackColor="#dee2e6"> </PagerStyle> 
                        <Columns>
                        <asp:BoundField DataField="I_idInsumo" HeaderText="Id_Insumo" Visible="False" />
                        <asp:BoundField Datafield="I_NombreInsumo" HeaderText="Nombre insumo" />
                        <asp:BoundField Datafield="I_cantidadMinima" HeaderText="Stock mínimo" />
                        <asp:BoundField Datafield="I_cantidad" HeaderText="Stock actual" />
                        <asp:BoundField Datafield="El_nombreEstado" HeaderText="Estado" />
                        <%--<asp:TemplateField HeaderText="Solicitar">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnSolicitar" ImageUrl="img/enviar_1.png" onmouseover="this.src='img/enviar-b.png'" onmouseout="this.src='img/enviar_1.png'" runat="server" CommandName="SolicitarCo" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                        </ItemTemplate>
                            </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Solicitar">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkBox" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div>
                </div>
            </div>
        <hr /> 
        <div class="form-group2">
        <asp:UpdatePanel ID="PanelSolicitar" runat="server">
            <ContentTemplate>
                    <p class="center-button">
                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Solicitar" ID="btnSolicitar" OnClick="btnSolicitar_Click"/>
                       
                    </p>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        </div>
    </div>
</div>
    <script>
             function soloLetras(e) {
                 key = e.keyCode || e.which;
                 tecla = String.fromCharCode(key).toLowerCase();
                 letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
                 especiales = [8, 37, 39, 46];

                 tecla_especial = false
                 for (var i in especiales) {
                     if (key == especiales[i]) {
                         tecla_especial = true;
                         break;
                     }
                 }

                 if (letras.indexOf(tecla) == -1 && !tecla_especial)
                     return false;
             }
             function alertIns() {
                 Swal.fire({
                     title: 'Oh, no!',
                     text: 'Ingrese un insumo para la busqueda',
                     icon: 'error',
                     confirmButtonText: 'Aceptar'
                 })
             }
    </script>
</asp:Content>
