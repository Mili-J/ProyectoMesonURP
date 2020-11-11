<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SeleccionarMenuTransformar.aspx.cs" Inherits="ProyectoMesonURP.SeleccionarMenuTransformar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Seleccionar Plato a Transformar</h2>
            </div>
        </div>
        <div class="form-group" style="margin-bottom: 75px;">
            <div class="col-sm-8">
                <label for="focusedinput" class="col-sm-2 control-label">Ingrese la porción: </label>
                <asp:TextBox ID="txtPorciones" CssClass="form-control1" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="panel panel-widget forms-panel">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h4>Platos de Menú</h4>
                </div>

                <div class="table-wrapper-scroll-y my-custom-scrollbar">
                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="R_idReceta,R_nombreReceta,R_numeroPorcion,R_descripcion" OnRowCommand="GridView_RowCommand" AutoGenerateColumns="false"
                        CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">
                        <Columns>

                            <asp:BoundField HeaderText="Nombre" DataField="R_nombreReceta" />
                            <asp:BoundField HeaderText="Porcion" DataField="R_numeroPorcion" />
                            <asp:BoundField HeaderText="Descripcion" DataField="R_descripcion" />
                            <asp:TemplateField HeaderText="Transformar">
                                <ItemTemplate>
                                    <asp:Button ID="btnTransformar" class="btn btn-primary" runat="server" CommandName="TransformarI" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClick="btnTransformar_Click" Text="Transformar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <br />
        </div>
    </div>
</asp:Content>
