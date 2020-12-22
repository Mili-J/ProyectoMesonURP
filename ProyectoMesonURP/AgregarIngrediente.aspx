<%@ Page Title="Equivalencia | Registrar Ingrediente" Language="C#" AutoEventWireup="true" CodeBehind="AgregarIngrediente.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.AgregarIngrediente" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <div class="page-header">
            <div class="row">
                <div class="col-md-10 col-sm-12">
                    <div class="title">
                        <h4 class="tittle-margin5">Añadir Ingrediente</h4>
                    </div>
                </div>
            </div>
        </div>
        <div class="pd-20 card-box mb-30" data-select2-id="7">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h5>Detalles del Ingrediente</h5>
                </div>
            </div>
            <div class="padding-top-30">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group row justify-content-center h-100">
                            <label class="col-sm-12 col-md-2 col-form-label">Ingrediente:</label>
                            <div class="col-sm-12 col-md-4">
                                <asp:TextBox ID="txtIngrediente" CssClass="form-control form-color-letter" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row justify-content-center h-100">
                            <label for="selector1" class="col-sm-12 col-md-2 col-form-label">Peso Unitario:</label>
                            <div class="col-sm-12 col-md-4">
                                <asp:TextBox ID="txtPesoUnitario" CssClass="form-control form-color-letter" runat="server"></asp:TextBox>
                            </div>
                            <br />
                        </div>
                        <div class="form-group row justify-content-center h-100">
                            <label for="selector1" class="col-sm-2 control-label">Cantidad:</label>
                            <div class="col-sm-12 col-md-4">
                                <asp:TextBox ID="txtCantidad" CssClass="form-control form-color-letter" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row justify-content-center h-100">
                            <label for="focusedinput" class="col-sm-2 control-label">Categoria:</label>
                            <div class="col-sm-12 col-md-4">
                                <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="true" CssClass="form-control form-color-letter" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row justify-content-center h-100">
                            <label for="focusedinput" class="col-sm-2 control-label">Insumo:</label>
                            <div class="col-sm-12 col-md-4">
                                <asp:DropDownList ID="ddlInsumo" runat="server" AutoPostBack="true" CssClass="form-control form-color-letter" OnSelectedIndexChanged="ddlInsumo_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row justify-content-center h-100">
                            <label for="selector1" class="col-sm-2 control-label">Equivalencia:</label>
                            <div class="col-sm-12 col-md-4">
                                <asp:DropDownList ID="ddlEquivalencia" AutoPostBack="true" CssClass="form-control form-color-letter" runat="server" OnSelectedIndexChanged="ddlEquivalencia_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                        <p class="center-button">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ID="btnAñadirIngrediente" OnClick="btnAñadirIngrediente_Click" />
                            <asp:Button CssClass="btn btn-primary" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                        </p>
                          
            </div>
        </div>

    </div>
</asp:Content>
