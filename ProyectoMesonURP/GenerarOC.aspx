<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerarOC.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.GenerarOC" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Generar Orden de Compra</h2>
            </div>
        </div>
        <div class="infprincipal" style="display: flex;">
            <div class="infReceta" style="width: 50%;">
                <div class="form-grids widget-shadow" data-example-id="basic-forms" style="margin-top: 34px;">
                    <div class="form-title color-white">
                        <h4>Detalles</h4>
                    </div>
                </div>
                <div class="p-5" runat="server">
                    <div class="form-group" style="width: 1889px; margin-top: 23px;">
                        <label for="focusedinput" class="col-sm-2 control-label">N° de Compra</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNdeCompra" runat="server" Style="width: 25%;" CssClass="form-control1"/>
                            <asp:RequiredFieldValidator ID="rfvNdeCompra" runat="server" ControlToValidate="txtNdeCompra" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                            </div>
                    </div>
                    <div class="form-group" style="width: 1889px;">
                        <label for="focusedinput" class="col-sm-2 control-label">Proveedor</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtProveedor" runat="server" Style="width: 25%;" CssClass="form-control1"/>
                             <asp:RequiredFieldValidator ID="rfvProveedor" runat="server" ControlToValidate="txtProveedor" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group" style="width: 1889px;">
                        <label for="selector1" class="col-sm-2 control-label">Fecha de Emisión</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtFechaEmision" runat="server" Style="width: 25%;"  CssClass="form-control1"/>
                             <asp:RequiredFieldValidator ID="rfvFechaEmision" runat="server" ControlToValidate="txtFechaEmision" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group" style="width: 1889px;">
                        <label for="selector1" class="col-sm-2 control-label">Fecha de Entrega</label>
                        <div class="col-sm-8">

                            <asp:TextBox ID="txtFechaEntrega" runat="server" CssClass="form-control1" TextMode="Date"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaEntrega" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                        
                        </div>
                    </div>
                    <div class="form-group" style="width: 1889px;">
                        <label for="selector1" class="col-sm-2 control-label">Comprobante</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlComprobante" runat="server" Style="width: 25%;" CssClass="form-control1">
                                <asp:ListItem Value="">Seleccione un comprobante</asp:ListItem>
                                <asp:ListItem Value="Factura">Factura</asp:ListItem>
                                <asp:ListItem Value="Boleta">Boleta</asp:ListItem>
                            </asp:DropDownList>
                            </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-horizontal" runat="server" style="background-color: #f5f6f7; border-radius: 1%; padding-bottom: 4px;">
            <div class="form-grids widget-shadow" data-example-id="basic-forms" style="margin-top: 34px;">
                <div class="form-title color-white">
                    <h4>Insumos</h4>
                </div>
            </div>
                <asp:UpdatePanel ID="PanelAñadir" runat="server">
                    <ContentTemplate>
                        <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                        <div class="panel panel-widget forms-panel" style="width: 60vh; margin-top: 27px;">
                            <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                <asp:GridView ID="gvInsumos" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="False" OnRowDataBound="gvInsumos_OnRowDataBound"
                                    DataKeyNames="I_nombreInsumo,FC_nombreFormatoCompra,DC_cantidadCotizacion" ShowFooter="True"
                                    CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" OnSelectedIndexChanged="gvInsumos_SelectedIndexChanged">

                                    <Columns>
                                        <asp:BoundField HeaderText="Nombre" DataField="I_nombreInsumo" />
                                        <asp:BoundField HeaderText="Representación" DataField="FC_nombreFormatoCompra" />
                                        <asp:BoundField HeaderText="Cantidad" DataField="DC_cantidadCotizacion"/>
                                        <asp:TemplateField HeaderText="Precio Unitario" >
                                            <Itemtemplate>
                                        <asp:TextBox id ="txtPrecioUnitario" runat="server" class="precio" CssClass="form-control1" OnTextChanged="txtPrecioUnitario_TextChanged"></asp:TextBox>
                                        </Itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Precio Total">
                                            <Itemtemplate>
                                        <asp:Label id ="lblPrecioTotal" runat="server"></asp:Label>
                                        </Itemtemplate>
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
            <hr />
            <p class="center-button" style="margin-top: 49px; margin-bottom: 44px;">
                <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnEnviar" onserverclick="btnEnviar_ServerClick">Enviar</button>
                <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarCotizacion';" onserverclick="btnRegresar_ServerClick" class="btn btn-primary" />
                <input type="reset" name="res-1" value="Limpiar" runat="server" onserverclick="btnLimpiar_ServerClick" class="btn btn-danger" />
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
           $(function() {
               $('#txtFechaEntrega').datepicker({
                   dateFormat: 'dd/mm/yy',
                   changeMonth: true,
                   changeYear: true,
                   yearRange: '2020:2021'
               });
           })
       </script>
     <script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
    
    <script language="javascript" type="text/javascript">

        $(document).ready(function() {

            $('#<%=gvInsumos.ClientID%>.precio').change(function() {
              
            var tr = $(this).parent().parent();
            var precio = $("td:eq(2)", tr).html();

                $("td:eq(5) span", tr).html($(this).val() * precio);
            });
        });
    </script>
    </asp:Content>


