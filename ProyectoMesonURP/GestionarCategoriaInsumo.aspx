﻿<%@ Page Title="MesónURP | Gestionar Categoría de Insumos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarCategoriaInsumo.aspx.cs" Inherits="ProyectoMesonURP.GestionarCategoriaInsumo" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="vendors/styles/core.css">
     <link rel="stylesheet" type="text/css" href="vendors/styles/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <div class="page-header">
            <div class="row">
                <div class="col-md-10 col-sm-12">
                    <div class="title">
                        <h4>Gestionar Categoría de Insumo</h4>
                    </div>
                </div>
            </div>
        </div>
        <div class="pd-20 card-box" runat="server" id="PanelInsumos">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row pt-1">
                        <div class="col-sm-12 col-md-6">
                            <label>Nombre de Categoría :</label>
                            <div class="width-auto margin-5" style="display: flex">
                                 <asp:TextBox runat="server" ID="txtRegistrarC" placeholder="Ingrese un nombre" onkeypress="return lettersOnly(event);" CssClass="form-control" Width="44%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvnombre" runat="server" ControlToValidate="txtRegistrarC" ErrorMessage="Campo Obligatorio" SetFocusOnError="True" Display="Dynamic" ForeColor="DarkRed" ValidationGroup="categoria"></asp:RequiredFieldValidator>
                                    
                                <asp:LinkButton runat="server" class="btn btn-primary" ID="btnAgregarCInsumo" OnClick="btnAgregarCInsumo_Click" ValidationGroup="categoria"><i class="fa fa-plus-circle"></i>&nbsp; Añadir Categoría</asp:LinkButton>  
                            </div>
                        </div>
                        <div class="col-sm-12 col-md-3 pl-30"></div>
                        <div class="col-sm-12 col-md-3 pl-30">
                            <div class="search-icon-box bg-white box-shadow border-radius-10 mb-30">
                                <asp:TextBox ID="txtBuscarCat" runat="server" class="form-control" AutoPostBack="True" placeholder="Buscar Categoría ..." />
                                <i class="search_icon dw dw-search"></i>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-widget forms-panel" style="margin-top: 10px">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms">
                            <div class="form-title color-white">
                                <h5>Categoría de Insumos</h5>
                            </div>
                            <div class="w3-row-padding">
                                <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                    <asp:GridView ID="GridViewCategoria" AllowPaging="False" runat="server" EmptyDataText="No hay información disponible."
                                        AutoGenerateColumns="False" OnRowCommand="GridViewCategoria_RowCommand"
                                        CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" PageSize="5" GridLines="None">
                                        <PagerStyle HorizontalAlign="Right" BackColor="#dee2e6"></PagerStyle>
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblIdCategoria" Text='<%# Eval("CI_idCategoriaInsumo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Categoría" DataField="CI_nombreCategoria" />
                                               <asp:TemplateField HeaderText="Editar">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnEditarCat"  class="btn btn-warning btn-sm" runat="server" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-pencil-square-o"></i>&nbsp; Editar</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ver Detalle">
                                                <ItemTemplate>
                                                     <asp:LinkButton class="btn btn-info btn-sm" ID="btnDetallesCat" runat="server" CommandName="Consultar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-eye"></i>&nbsp; Ver</asp:LinkButton>       
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:HiddenField ID="hidden" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="modal fade" id="modalActualizar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Actualizar Categoría</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <label for="recipient-name" class="col-form-label">Ingrese nueva categoría:</label>
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="txtActualizar" onkeypress="return lettersOnly(event);"/>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                    <asp:Button runat="server" class="btn btn-primary" ID="btnActualizar" Text="Aceptar" OnClick="btnActualizar_Click" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnActualizar" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="modalConsultar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="ModalLabelConsu">Consultar Insumos</h5>
                            
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GridViewConsulta" AllowPaging="False" runat="server" EmptyDataText="No hay información disponible."
                                            AutoGenerateColumns="False" OnRowCommand="GridViewCategoria_RowCommand"
                                            CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" PageSize="5" GridLines="None">
                                            <PagerStyle HorizontalAlign="Right" BackColor="#dee2e6"></PagerStyle>
                                            <Columns>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblIDInsumo" Text='<%# Eval("I_idInsumo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Nombre Insumo" DataField="I_nombreInsumo" />
                                                <asp:BoundField HeaderText="Cantidad" DataField="I_cantidad" />
                                                <asp:BoundField HeaderText="Estado" DataField="EI_idEstadoInsumo" />
                                            </Columns>
                                        </asp:GridView>
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
     <script>
         function lettersOnly(evt) {
             evt = (evt) ? evt : event;
             var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                 ((evt.which) ? evt.which : 0));
             if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                 (charCode < 97 || charCode > 122)) {
                 alert("Por favor, ingrese solo letras.");
                 return false;
             }
             return true;
         }
        function alertaInsertado() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'El insumo ha sido agregado satisfactoriamente.',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaExistente() {
            Swal.fire({
                title: 'Oh no!',
                text: 'El insumo agregado ya existe.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaInsumo() {
            Swal.fire({
                title: 'Oh no!',
                text: 'La categoría contiene insumos.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaActualizar() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'El insumo ha sido actualizado satisfactoriamente.',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            })
        }

     </script>
</asp:Content>
