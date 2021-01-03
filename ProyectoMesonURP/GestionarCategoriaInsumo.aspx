<%@ Page Title="MesónURP | Gestionar Categoría de Insumos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarCategoriaInsumo.aspx.cs" Inherits="ProyectoMesonURP.GestionarCategoriaInsumo" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                            <label>Agregar Nueva Categoría :</label>
                            <div class="width-auto margin-5" style="display: flex">
                                <asp:TextBox runat="server" ID="txtRegistrarC" CssClass="form-control" Width="44%"></asp:TextBox>
                                <asp:Button runat="server" class="btn btn-primary" Text="Agregar" ID="btnAgregarCInsumo" OnClick="btnAgregarCInsumo_Click" />
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
                                            <asp:TemplateField HeaderText="Acciones">
                                                <ItemTemplate>
                                                    <div class="dropdown">
                                                        <a class="btn btn-link font-24 p-0 line-height-1 no-arrow dropdown-toggle" href="#" role="button" data-toggle="dropdown">
                                                            <i class="dw dw-more"></i>
                                                        </a>
                                                        <div class="dropdown-menu dropdown-menu-right dropdown-menu-icon-list">
                                                            <asp:LinkButton ID="btnEditarCat" class="dropdown-item" runat="server" CommandName="Actualizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="dw dw-edit2" ></i>&nbsp;Editar</asp:LinkButton>
                                                            <asp:LinkButton ID="btnDetallesCat" class="dropdown-item" runat="server" CommandName="Consultar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="dw dw-eye"></i>&nbsp;Ver</asp:LinkButton>
                                                        </div>
                                                    </div>
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
                                        <asp:TextBox runat="server" type="text" class="form-control" ID="txtActualizar" />
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
                            <button type="button" class="btn btn-primary">Aceptar</button>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <script>
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
