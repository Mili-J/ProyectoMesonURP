<%@ Page Title="Agregar Equivalencia" Language="C#" AutoEventWireup="true" CodeBehind="AgregarEquivalencia.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.AgregarEquivalencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <div class="page-header">
            <div class="row">
                <div class="col-md-6 col-sm-12">
                    <div class="title">
                        <h4>Añadir Equivalencia</h4>
                    </div>
                </div>
            </div>
        </div>
        <div class="pd-20 card-box mb-30">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h5>Equivalencia de un Insumo</h5>
                </div>
            </div>
            <div class="padding-top-30">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group row justify-content-center h-100">
                            <label class="col-sm-12 col-md-2 col-form-label">Categoria</label>
                            <div class="col-sm-12 col-md-4">
                                <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <div class="form-group row justify-content-center h-100">
                    <label class="col-sm-12 col-md-2 col-form-label">Insumo</label>
                    <div class="col-sm-12 col-md-4">
                        <asp:DropDownList ID="ddlInsumo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlInsumo_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                        </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="form-group row justify-content-center h-100">
                            <label class="col-sm-12 col-md-2 col-form-label">Medida</label>
                            <div class="col-sm-12 col-md-4">
                                <asp:TextBox ID="txtMedida" CssClass="form-control" ReadOnly="true" runat="server" ></asp:TextBox>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                <div class="form-group row justify-content-center h-100">
                    <label class="col-sm-12 col-md-2 col-form-label">Cantidad</label>
                    <div class="col-sm-12 col-md-4">
                        <asp:TextBox ID="txtCantidad" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                </div>
                         </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div class="form-group row justify-content-center h-100">
                            <label class="col-sm-12 col-md-2 col-form-label">Formato Cocina</label>
                            <div class="col-sm-12 col-md-4">
                                <asp:DropDownList ID="ddlFormatoCocina" AutoPostBack="true" class="custom-select2 form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
              
                        <p class="center-button pt-3">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Guardar" ID="btnAñadirEquivalencia" OnClick="btnAñadirEquivalencia_Click" />
                            <asp:Button CssClass="btn btn-danger" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                        </p>
                 

            </div>
        </div>
    </div>
</asp:Content>
