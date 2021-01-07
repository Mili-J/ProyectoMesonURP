<%@ Page Title="Consultar Insumo" Language="C#" AutoEventWireup="true" CodeBehind="ConsultarInsumo.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.ConsultarInsumo"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="women_main">
        <!-- start content -->
        <div class="pd-ltr-20 xs-pd-20-10">
            <div class="page-header">
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <h4 class="tittle-margin5">Consultar Insumo</h4>
                    </div>
                </div>
            </div>

            <div class="pd-20 card-box mb-30">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h5>Detalles de Insumo</h5>
                    </div>
                </div>
                <div class="padding-top-30">
                    <div class="form-group row col-md-8">
                        <label class="col-sm-12 col-md-2 col-form-label">Insumo:</label>
                        <div class="col-sm-12 col-md-6">
                            <asp:TextBox ID="txtInsumo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row col-md-8">
                        <label class="col-sm-12 col-md-2 col-form-label">Categoria:</label>
                        <div class="col-sm-12 col-md-6">
                            <asp:DropDownList ID="DDLCategoria" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row col-md-8">
                        <label class="col-sm-12 col-md-2 col-form-label">Formato de Compra:</label>
                        <div class="col-sm-12 col-md-6">
                            <asp:DropDownList ID="DDLFC" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="FC_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row col-md-8" runat="server" id="PanelMedida1" visible="false">
                        <label class="col-sm-12 col-md-2 col-form-label">Unidad de Medida:</label>
                        <div class="col-sm-12 col-md-6">
                            <asp:DropDownList ID="DDLMedida" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row col-md-8" runat="server" id="PanelMedida2" visible="false">
                        <label class="col-sm-12 col-md-2 col-form-label" ID="Label1" runat="server"> -------- </label>
                        <div class="col-sm-4 col-md-2">
                            <asp:TextBox ID="txtCantidadCo" runat="server" CssClass="form-control" Text="1"/>
                        </div>
                        <div class="col-sm-12 col-md-6">
                            <asp:DropDownList ID="DDLMedida2" runat="server" CssClass="form-control" Width="290px">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row col-md-8" runat="server" id="PanelMedida3" visible="false">
                        <div class="col-sm-12 col-md-6">
                            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ChckedChanged" AutoPostBack="True" />
                        </div>
                        <label class="col-sm-12 col-md-2 col-form-label" ID="Label2" runat="server">Pack  </label>
                        <div class="col-sm-4 col-md-2">
                            <asp:TextBox ID="TxtCantUn" runat="server" CssClass="form-control" Text="1" Visible="false"/>
                        </div>
                        <label class="col-sm-12 col-md-2 col-form-label" ID="Label3" runat="server"></label>
                    </div>
                    <div class="form-group row col-md-8" runat="server" id="Cantmin" visible="false">
                        <label class="col-sm-12 col-md-2 col-form-label">Cantidad Minima: </label>
                        <div class="col-sm-4 col-md-2">
                            <asp:TextBox ID="TxtCantmin" runat="server" CssClass="form-control" Text="0"/>
                        </div>
                        <label class="col-sm-12 col-md-2 col-form-label" ID="Label5" runat="server"></label>
                    </div>
                       <%-- <p class="center-button pt-3">
                         
                           <asp:Button CssClass="btn btn-primary" runat="server" Text="Registrar" ID="btnRegistrar" OnClick="btnRegistrar_Click" UseSubmitBehavior="false" />
                        </p>--%>
                 

                </div>
            </div>
           
            <hr />
            <p class="center-button" style="margin-top: 49px; margin-bottom: 44px;">
                <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarInsumo.aspx';" class="btn btn-primary" />
            </p>
        </div>
    </div>
</asp:Content>

