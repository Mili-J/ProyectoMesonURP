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
                 <div class="form-group row col-md-8">
                        <label >Insumo</label>
                        <div class="col-sm-12 col-md-6">
                            <asp:TextBox ID="txtInsumo" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                 <div class="form-group row col-md-8">
                        <label >Ingrediente</label>
                        <div class="col-sm-12 col-md-6">
                            <asp:TextBox ID="txtIngrediente" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
               
<%--                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                         <div class="form-group row justify-content-center h-100">
                    <label class="col-sm-12 col-md-2 col-form-label">Insumo</label>
                    <div class="col-sm-12 col-md-4">
                        <asp:DropDownList ID="ddlInsumo" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                       </div>
                        </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group row justify-content-center h-100">
                            <label class="col-sm-12 col-md-2 col-form-label">Categoria</label>
                            <div class="col-sm-12 col-md-4">
                                <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
                
                 <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <div class="form-group row justify-content-center h-100">
                            <label class="col-sm-12 col-md-2 col-form-label">Ingrediente</label>
                            <div class="col-sm-12 col-md-4">
                                <asp:DropDownList ID="ddlIngrediente" AutoPostBack="true" class="custom-select2 form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div class="form-group row justify-content-center h-100">
                            <label class="col-sm-12 col-md-2 col-form-label">Formato Cocina</label>
                            <div class="col-sm-12 col-md-4">
                                <asp:DropDownList ID="ddlFormatoCocina" AutoPostBack="true" class="custom-select2 form-control" runat="server" OnSelectedIndexChanged="ddlFormatoCocina_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                
                 <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                     <div class="form-group row col-md-8">
                        <label >Cantidad</label>
                        <div class="col-sm-12 col-md-6">
                            <asp:TextBox ID="txtCantidad" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
               <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                            <div class="form-group row col-md-8">
                        <label >Medida</label>
                        <div class="col-sm-12 col-md-6">
                                <%--<asp:TextBox ID="txtMedida" BackColor="Transparent" BorderColor="White" BorderStyle="None" ReadOnly="true" runat="server" ></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlMedida" runat="server" CssClass="form-control"></asp:DropDownList>
                           </div>
                    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="panel panel-widget forms-panel">
                            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                <div class="form-title color-white">
                                    <h5>Ingredientes</h5>
                                </div>
                                <%--  <asp:UpdatePanel ID="panel" runat="server">
                        <ContentTemplate>--%>
                                <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                    <asp:GridView ID="gvEquivalencia" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false" OnRowDataBound="gvEquivalencia_OnRowDataBound"
                                        DataKeyNames="Ingrediente,Formato Cocina,Cantidad,Medida"
                                        CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" OnSelectedIndexChanged="gvEquivalencia_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField HeaderText="Ingrediente" DataField="Ingrediente" />
                                            <asp:BoundField HeaderText="Formato Cocina" DataField="Formato Cocina" />
                                            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                                            <asp:BoundField HeaderText="Medida" DataField="Medida" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="SteelBlue" />
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="lblIndex" runat="server" Visible="false"></asp:Label>
                                <hr />
                                <p class="center-button">
                                   <%-- <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnAgregar" onserverclick="btnEgresar_ServerClick">Egresar</button>
                                    --%>  <asp:Button CssClass="btn btn-danger" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                                 </p>
                                <%--   </ContentTemplate>
                    </asp:UpdatePanel>--%>
                            </div>
                        </div>
               
              
                        <p class="center-button pt-3">
                          <%--  <asp:Button CssClass="btn btn-primary" runat="server" Text="Guardar" ID="btnAñadirEquivalencia" OnClick="btnAñadirEquivalencia_Click" />--%>
                         
                        </p>
                 

            </div>
        </div>
    </div>
</asp:Content>
