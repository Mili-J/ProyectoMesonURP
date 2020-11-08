<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Manejar_Stock_Prueba.aspx.cs" Inherits="ProyectoMesonURP.Manejar_Stock_Prueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="R_idReceta,R_nombreReceta,R_numeroPorcion,R_descripcion" OnRowCommand="GridView_RowCommand" AutoGenerateColumns="false" Width="359px">
            <Columns>

                <asp:BoundField HeaderText="Nombre" DataField="R_nombreReceta" />
                <asp:BoundField HeaderText="Porcion" DataField="R_numeroPorcion" />
                <asp:BoundField HeaderText="Descripcion" DataField="R_descripcion" />
                <asp:TemplateField HeaderText="Transformar">
                    <ItemTemplate>
                        <asp:Button ID="btnTransformar" runat="server" CommandName="TransformarI" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Transformar" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Seleccionar">
                    <ItemTemplate>
                        <asp:Button ID="btnSeleccionarEntrada" runat="server" CommandName="SeleccionarEntrada" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Seleccionar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
        Menú del día
            <div>
                <asp:GridView ID="gvMenu" runat="server" DataKeyNames="R_nombreReceta" OnRowCommand="gvMenu_RowCommand" AutoGenerateColumns="false">
                    <Columns>

                        <asp:BoundField HeaderText="Nombre" DataField="R_nombreReceta" />
                        <asp:BoundField HeaderText="Raciones" DataField="NumRaciones" />



                        <asp:TemplateField HeaderText="Quitar">
                            <ItemTemplate>
                                <asp:Button ID="btnQuitar" runat="server" CommandName="TransformarI" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Quitar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:TextBox ID="txtPorciones" runat="server"></asp:TextBox>
            </div>
</asp:Content>

