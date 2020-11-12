<%@ Page Title="Mesón URP | Transformación" Language="C#" AutoEventWireup="true" CodeBehind="Transformar_Insumo.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.Transformar_Insumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Transformar Insumo</h2>
            </div>
        </div>
        <div class="forms" style="display: flex; flex-direction: row;">
            <asp:UpdatePanel ID="panel1" runat="server">
                <ContentTemplate>
                    <div class="panel panel-widget forms-panel" style="display: flex; flex-direction: row;">
                        <%--<div class="form-title color-white">
                    <asp:Label ID="lblPlato" runat="server"></asp:Label>
                </div>--%>
                        <div class="form-grids widget-shadow" data-example-id="basic-forms">
                            <div class="form-title color-white">
                                <h4>Plato a Transformar</h4>
                            </div>
                            <div>
                                <asp:Image ID="Image1" runat="server" />
                            </div>

                            <div class="widget-shadow">
                                <div class="table-wrapper-scroll-y my-custom-scrollbar" runat="server">
                                    <asp:GridView ID="gvIngredienteReceta" runat="server" DataKeyNames="I_nombreIngrediente,I_nombreInsumo,IR_cantidad,IR_formatoMedida,I_idIngrediente" AutoGenerateColumns="False" Style="text-align: center" CellPadding="4" GridLines="None" CssClass="table table-bordered table-striped mb-0">
                                        <Columns>
                                            <asp:BoundField HeaderText="Ingrediente" DataField="I_nombreIngrediente" />
                                            <asp:BoundField HeaderText="Insumo" DataField="I_nombreInsumo" />
                                            <asp:BoundField HeaderText="Cantidad" DataField="IR_cantidad" />
                                            <asp:BoundField HeaderText="Formato Medida" DataField="IR_formatoMedida" />

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="form-horizontal" runat="server" style="background-color: #f5f6f7; border-radius: 1%;width: 800px; margin-left:50px;">
                            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                <div class="form-title color-white">
                                    <h4>Transformación</h4>
                                </div>
                            </div>
                           <div class="container-sw">
                            <div>
                                <h4 class="tittle-margin5 input-info" style="color: #A77F5D; margin-top: 18px; margin-left: 34px;">Insumo Origen</h4>
                                <div class="form-group">
                                    <label for="selector1" class="col-sm-2 control-label">Insumo</label>
                                    <div class="col-sm-8">
                                        <asp:DropDownList ID="ddlInsumo" runat="server" AutoPostBack="true" CssClass="form-control form-color-letter" Style="width: 25%" OnSelectedIndexChanged="ddlInsumo_SelectedIndexChanged1">
                                            <asp:ListItem Text="" Value="">Seleccione un insumo</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control form-color-letter" ReadOnly="true" Style="width: 25%" />
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="focusedinput" class="col-sm-2 control-label">Medida</label>
                                    <div class="col-sm-8">
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                        <asp:TextBox ID="txtMedida" runat="server" CssClass="form-control form-color-letter" ReadOnly="true" Style="width: 25%"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div>
                                <h4 class="tittle-margin5 input-info" style="color: #A77F5D; margin-top: 18px; margin-left: 34px;">Ingrediente Destino</h4>

                                <div class="form-group">
                                    <label for="focusedinput" class="col-sm-2 control-label">Ingrediente</label>
                                    <div class="col-sm-8">

                                        <asp:DropDownList ID="ddlIngrediente" runat="server" AutoPostBack="true" CssClass="form-control form-color-letter" Style="width: 25%" OnSelectedIndexChanged="ddlIngrediente_SelectedIndexChanged"></asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label for="selector1" class="col-sm-2 control-label">Formato Cocina</label>
                                    <div class="col-sm-8">
                                        <asp:TextBox ID="txtFormatoC" CssClass="form-control form-color-letter" ReadOnly="true" Style="width: 25%" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <%--   <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtCantidadI" runat="server" CssClass="form-control form-color-letter" ReadOnly="true" AutoPostBack="true"  Style="width:25%" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>--%>
                                </div>
                              </div>
                            </div>

                            <asp:UpdatePanel ID="PanelAñadir" runat="server">
                                <ContentTemplate>
                                    <p class="center-button">
                                        <asp:Button CssClass="btn btn-primary" runat="server" Text="Transformar" ID="btnAñadirIngrediente" OnClick="btnAñadirIngrediente_Click" />
                                        <%--<input type="reset" name="res-1"  value="Limpiar" runat="server" onserverclick="btnLimpiar_ServerClick" class="btn btn-danger" />--%>
                                    </p>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
       <!-- Alertas -->
    <script src="js/sweetalert.js">
    </script>
    <script>
        function alertaExito() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha logrado transformar insumo',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "TransformarInsumo";
                }
            })
        }
    </script>
</asp:Content>


