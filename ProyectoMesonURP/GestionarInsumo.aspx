<%@ Page Title="Gestionar Insumo" Language="C#" AutoEventWireup="true" CodeBehind="GestionarInsumo.aspx.cs"  MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.GestionarInsumo" %>
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
				    <h4>Gestionar Insumo</h4>
			    </div>
		    </div>
	     <div class="header-right pt-2 pr-4">
            <button type="button" class="btn btn-primary btn-flex" runat="server" style="display: flex; margin-left: 6px;" onclick="location.href = 'AgregarInsumo.aspx';">     
                <span class="material-icons margin-5">add_circle_outline</span>
                Añadir Insumo
            </button>
        </div>
        </div>
    </div>
    <div class="pd-20 card-box"  runat="server">
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
                <h5>Insumos</h5>
            </div>
                <div class="w3-row-padding">
                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                        <asp:GridView ID="gvInsumos" allowpaging="True"  OnRowDataBound="gvInsumos_RowDataBound" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."  
                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_idInsumo,I_NombreInsumo,CI_nombreCategoria,Representacion de compra"  
                            Style="text-align: center" OnPageIndexChanging="gvInsumos_PageIndexChanging" OnRowCommand="gvInsumos_RowCommand" CellPadding="4" PageSize="5" GridLines="None">
                            <PagerStyle HorizontalAlign="Right" BackColor="#dee2e6"> </PagerStyle> 
                            <Columns>
                                <asp:BoundField DataField="I_idInsumo" HeaderText="Id" Visible="false"/>
                                <asp:BoundField DataField="I_NombreInsumo" HeaderText="Insumo" />
                                <asp:BoundField DataField="CI_nombreCategoria" HeaderText="Categoría" />
                                <asp:BoundField DataField="Representacion de compra" HeaderText="Representación de compra" />
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEditar" class="btn btn-warning btn-sm" runat="server" CommandName="Editar" CommandArgument="<%#((GridViewRow) Container).RowIndex %>"><i class="fa fa-pencil-square-o"></i>&nbsp; Editar</asp:LinkButton>       
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
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