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
         <h3 class="title1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Detalle Insumo</h3>
        <asp:UpdatePanel ID="panel1" runat="server">
            <ContentTemplate>
                <div class="form-three widget-shadow">
                    <div class="form-horizontal" runat="server">
                        <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Nombre del Insumo</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtInsumo" runat="server" CssClass="form-control1" />
                            <asp:RequiredFieldValidator ID="validationFecha" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        </div>

                        <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control1" />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </div>
                        </div>

                        <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Peso Total</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtPesoTotal" runat="server" CssClass="form-control1" />
<%--                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </div>
                        </div>

                        <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Medida</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtMedida" runat="server" CssClass="form-control1" />
<%--                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </div>
                        </div> 

                        <h3 class="title1">Detalle Ingrediente</h3>

                        <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Ingrediente</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtIngrediente" runat="server" CssClass="form-control1" />
<%--                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </div>
                        </div>

                        <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Formato Cocina</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlFormatoCocina" runat="server" CssClass="form-control1" AutoPostBack="true" OnSelectedIndexChanged="Selection_Change">
                                <asp:ListItem Text="" Value="">Seleccione un formato</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="validationInsumos" runat="server" ControlToValidate="ddlInsumos" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        </div>

                        <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCantidadI" runat="server" CssClass="form-control1" />
<%--                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </div>
                        </div>

                         <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Peso Unitario</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtPesoUnitario" runat="server" CssClass="form-control1" />
<%--                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarEgreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                        </div>
                        </div>

                        <asp:UpdatePanel ID="PanelAñadir" runat="server">
                      <ContentTemplate>
                         <p class="center-button">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ID="btnAñadirIngrediente" OnClick="btnAñadirIngrediente_Click"/>
<%--                            <input type="reset" name="res-1"  value="Limpiar" runat="server" onserverclick="btnLimpiar_ServerClick" class="btn btn-danger" />--%>
                        </p>
                      </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                    <div class="panel panel-widget forms-panel">

                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel> 
       
   
    </div>
</div>
</asp:Content>


