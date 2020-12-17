<%@ Page Title="Equivalencia | Consultar" Language="C#" AutoEventWireup="true" CodeBehind="ConsultarEquivalencia.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.ConsultarEquivalencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <div class="pd-ltr-20 xs-pd-20-10">
            <div class="min-height-200px">
                <div class="page-header">
                    <div class="row">
                        <div class="col-md-12 col-sm-12">
                            <h4 class="tittle-margin5">Consultar Equivalencia
                            </h4>
                        </div>
                    </div>
                </div>
                <div class="row clearfix">
                    <div class="col-sm-12 mb-30">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms">
                            <div class="form-title color-white">
                                <h5>Detalle del Insumo</h5>
                            </div>
                        </div>
                        <div class="pd-20 card-box height-100-p">
                            <div class="forms">

                                <asp:UpdatePanel ID="panelInsumo" runat="server">
                                    <ContentTemplate>
                                        <div class="form-horizontal" runat="server">
                                            <div class="form-group">
                                                <div class="col-sm-6">
                                                    <label for="focusedinput" class="col-sm-2 control-label">Insumo</label>
                                                    <asp:TextBox ID="txtInsumo" CssClass="form-control form-color-letter" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-horizontal" runat="server">
                                            <div class="form-group">                                                
                                                <div class="col-sm-6">
                                                    <label for="focusedinput" class="col-sm-2 control-label">Medida</label>
                                                    <asp:TextBox ID="txtMedida" CssClass="form-control form-color-letter" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-horizontal" runat="server">
                                            <div class="form-group">                                                
                                                <div class="col-sm-6">
                                                    <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                                                    <asp:TextBox ID="txtCantidad" CssClass="form-control form-color-letter"  runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-horizontal" runat="server">
                                           <div class="form-group">
                                               <div class="col-sm-6">
                                                    <label for="focusedinput" class="control-label" style="padding-left: 17px;">Formato Cocina Actual:</label>
                                                    
                                                    <asp:TextBox ID="txtFormatoC" CssClass="form-control form-color-letter" runat="server"></asp:TextBox>
                                                </div>
                                           </div>                                               
                                        </div>
                                        <div class="form-group center-button">
                                            <asp:Button CssClass="btn btn-primary" ID="btnVolver" runat="server" Text="Regresar al Menú" OnClick="btnVolver_Click"/>
                                        </div>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
