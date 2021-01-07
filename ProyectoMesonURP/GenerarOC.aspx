<%@ Page Title="Gestionar Cotización | Generar Orden de Compra" Language="C#" AutoEventWireup="true" CodeBehind="GenerarOC.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.GenerarOC" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="women_main">
        <!-- start content -->
        <div class="pd-ltr-20 xs-pd-20-10">
            <div class="page-header">
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <h4 class="tittle-margin5">Generar Orden de Compra</h4>
                    </div>
                </div>
            </div>
            <div class="row clearfix">
                <div class="col-md-4 col-sm-12 mb-30">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h5>Detalle de la Orden de Compra</h5>
                        </div>
                    </div>
                    <div class="pd-20 card-box height-100-p pt-5">
                        <div class="form-group row justify-content-center">
                            <label class="col-sm-12 col-md-5 col-form-label">N° Compra</label>
                            <div class="col-sm-12 col-md-6">
                                <asp:TextBox ID="txtNdeCompra" runat="server" class="form-control" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group row justify-content-center">
                            <label class="col-sm-12 col-md-5 col-form-label">Proveedor</label>
                            <div class="col-sm-12 col-md-6">
                                <asp:TextBox ID="txtProveedor" runat="server" class="form-control" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group row justify-content-center">
                            <label class="col-sm-12 col-md-5 col-form-label">Fecha Emisión</label>
                            <div class="col-sm-12 col-md-6">
                                <asp:TextBox ID="txtFechaEmision" runat="server" class="form-control" ReadOnly="true" />
                            </div>
                        </div>
                        <div class="form-group row justify-content-center">
                            <label class="col-sm-12 col-md-5 col-form-label">Fecha de Entrega</label>
                            <div class="col-sm-12 col-md-6">
                                <asp:TextBox ID="txtFechaEntrega" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row justify-content-center">
                            <label class="col-sm-12 col-md-5 col-form-label">Forma de pago</label>
                            <div class="col-sm-12 col-md-6">
                                 <asp:TextBox ID="txtFormaPago" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                            
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-8 col-sm-12 mb-30">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h5>Detalle de los Insumos</h5>
                        </div>
                    </div>
                    <div class="pd-20 card-box height-100-p pt-5">
                        <asp:UpdatePanel ID="PanelAñadir" runat="server">
                            <ContentTemplate>
                                <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                                <div class="panel panel-widget forms-panel">
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                        <asp:GridView ID="gvInsumos" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="False"
                                            DataKeyNames="I_nombreInsumo,DC_cantidadCotizacion, Representacion de compra,DOC_precioUnitario,DOC_totalPrecio" ShowFooter="True"
                                            CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">
                                            <Columns>
                                                <asp:BoundField HeaderText="Nombre" DataField="I_nombreInsumo" />
                                                <asp:TemplateField HeaderText="Cantidad">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCantidad" runat="server" Text='<%# Bind("DC_cantidadCotizacion")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="Representación" DataField="Representacion de compra" />
                                                <asp:TemplateField HeaderText="Precio Unitario">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPrecioUnitario" runat="server" Text='<%# Bind("DOC_precioUnitario")%>'></asp:Label>
                                                 </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label runat="server">TOTAL:</asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Precio Total">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalPrecio" runat="server" Text='<%# Bind("DOC_totalPrecio")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Label runat="server" ID="lblTotal" Text="0.00"></asp:Label>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnEnviar" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <hr />
            <p class="center-button" style="margin-top: 49px; margin-bottom: 44px;">
                <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnEnviar" onserverclick="btnEnviar_ServerClick">Enviar</button>
                <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarCotizacion';" class="btn btn-primary" />
            </p>
        </div>
    </div>
    <link href="../css/jquery-ui.css" rel="stylesheet" />
    <script src="../js/jquery-1.11.3.min.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js"></script>
    <script src="http://code.jquery.com/jquery-latest.js"></script>

    <script>
        function alertaExito() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha logrado enviar el correo correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "DetallesCotizacion";
                }
            })
        }
    </script>
    <script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>

    
</asp:Content>


