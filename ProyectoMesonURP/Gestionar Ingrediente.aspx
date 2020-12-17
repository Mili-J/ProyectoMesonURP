<%@ Page Title="Gestionar Ingrediente" Language="C#" AutoEventWireup="true" CodeBehind="Gestionar Ingrediente.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.Gestionar_Ingrediente" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <div class="page-header">
            <div class="row">
                <div class="col-md-10 col-sm-12">
                    <div class="title">
                        <h4 class="tittle-margin5">Gestionar Ingrediente</h4>
                    </div>
                </div>
            </div>
        </div>
        <div class="pd-20 card-box">
            <div class="panel panel-widget forms-panel">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h5>Ingredientes</h5>
                    </div>
                    <div class="w3-row-padding">

                        <div class="widget-shadow">
                            <div class="table-wrapper-scroll-y my-custom-scrollbar" runat="server">
                                <asp:GridView ID="gvIngrediente" runat="server" DataKeyNames="I_nombreIngrediente,I_pesoUnitario,I_Cantidad,I_nombreInsumo,E_cantidad,M_nombreMedida,FCO_nombreFormatoCocina" OnRowCommand="GVIngrediente_RowCommand" AutoGenerateColumns="False" Style="text-align: center" CellPadding="4" GridLines="None" CssClass="table table-bordered table-striped mb-0" OnRowDataBound="gvIngrediente_RowDataBound">
                                    <Columns>
                                        <asp:BoundField HeaderText="Ingrediente" DataField="I_nombreIngrediente" />
                                        <asp:BoundField HeaderText="Peso Unitario" DataField="I_pesoUnitario" />
                                        <asp:BoundField HeaderText="Cantidad" DataField="I_cantidad" />
                                        <asp:BoundField HeaderText="Insumo Origen" DataField="I_nombreInsumo" />
                                        <asp:TemplateField HeaderText="Equivalencia">
                                            <ItemTemplate>
                                                <%# "1" + " " + Eval("M_nombreMedida")+ " " + "es" + " " +Eval("E_cantidad") + " " + Eval("FCO_nombreFormatoCocina")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Editar">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditarIngrediente" CssClass="btn btn-primary" runat="server" CommandName="EditarIngrediente" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ver" Visible="false">
                                            <ItemTemplate>
                                                <asp:Button ID="btnVer" runat="server" CssClass="btn btn-primary" CommandName="VerIngrediente" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Ver" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <p class="center-button">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir Ingrediente" OnClick="btnAnadirIngrediente_Click"></asp:Button>
                        </p>
                        <p class="center-button">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Volver" OnClick="btnVolver_Click"></asp:Button>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
