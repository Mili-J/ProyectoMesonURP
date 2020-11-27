<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transformar_Insumo.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.Transformar_Insumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Transformar Insumo</h2>
            </div>
        </div>
        <div class="forms">
            <div class="panel panel-widget forms-panel" style="width: 36%">
                <div class="form-title color-white" >
                         <asp:Label ID="lblPlato" runat="server"></asp:Label>
                    </div>
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h4>Plato a Transformar</h4>
                    </div> 
                    <div>
                        <asp:Image ID="Imagen_Receta" runat="server" />
                    </div> 
                </div>
            </div>
            <asp:UpdatePanel ID="panel1" runat="server">
                <ContentTemplate>
                    <div class="widget-shadow" style="width: 36%; margin-top: 14px;">
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
                    <div class="form-horizontal" runat="server" style="background-color:#f5f6f7; border-radius:1%">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms" style="margin-top: 34px;">
                            <div class="form-title color-white">
                                <h4>Transformación</h4>
                            </div>
                        </div>

                         <h4 class="tittle-margin5 input-info" style="color:#A77F5D; margin-top: 18px; margin-left: 34px;">Ingrediente Destino</h4>

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">Ingrediente</label>
                            <div class="col-sm-8">
                               
                                <asp:DropDownList ID="ddlIngrediente" runat="server" AutoPostBack="true" CssClass="form-control form-color-letter" Style="width:25%" OnSelectedIndexChanged="ddlIngrediente_SelectedIndexChanged"></asp:DropDownList>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="selector1" class="col-sm-2 control-label">Formato Cocina</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtFormatoC" CssClass="form-control form-color-letter" ReadOnly="true" Style="width:25%" runat="server"></asp:TextBox>
                            </div>
                        </div>


                        <h4 class="tittle-margin5 input-info" style="color:#A77F5D; margin-top: 18px; margin-left: 34px;">Insumo Origen</h4>
                        <div class="form-group">
                            <label for="selector1" class="col-sm-2 control-label">Insumo</label>
                            <asp:TextBox ID="txtInsumo" runat="server" CssClass="form-control form-color-letter" ReadOnly="true" Style="width:25%" ></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control form-color-letter" ReadOnly="true" Style="width:25%" />
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">Medida</label>
                            <div class="col-sm-8">
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                <asp:TextBox ID="txtMedida" runat="server" CssClass="form-control form-color-letter" ReadOnly="true" Style="width:25%"></asp:TextBox>

                            </div>
                        </div>

                        <asp:UpdatePanel ID="PanelAñadir" runat="server">
                            <ContentTemplate>
                                <p class="center-button">
                                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ID="btnAñadirIngrediente" OnClick="btnAñadirIngrediente_Click" />
                                    <%--                            <input type="reset" name="res-1"  value="Limpiar" runat="server" onserverclick="btnLimpiar_ServerClick" class="btn btn-danger" />--%>
                                </p>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        
                        <asp:GridView ID="GridViewTransformacion" runat="server" AutoGenerateColumns="true" Style="text-align: center" CellPadding="4" GridLines="None" CssClass="table table-bordered table-striped mb-0"></asp:GridView>
                    </div>

                    </div>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
   </div>
</asp:Content>


