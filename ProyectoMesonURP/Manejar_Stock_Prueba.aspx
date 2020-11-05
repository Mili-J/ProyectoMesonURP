<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Manejar_Stock_Prueba.aspx.cs" Inherits="ProyectoMesonURP.Manejar_Stock_Prueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="women_main">
         <div>
             <asp:TextBox ID="txtNumRaciones" runat="server" TextMode="Number" OnTextChanged="txtNumRaciones_TextChanged" AutoPostBack="true"></asp:TextBox>
         </div>
        
        <div>
         <div>Plato de fondo</div>
            <div>
            <asp:GridView ID="gvPlatoFondo" runat="server"  DataKeyNames="R_idReceta,R_nombreReceta,R_numeroPorcion,R_descripcion" OnRowCommand="gvPlatoFondo_RowCommand" AutoGenerateColumns="false">
                <Columns>
                  
                    <asp:BoundField HeaderText="Nombre" DataField="R_nombreReceta" />
                    <asp:BoundField HeaderText="Porcion" DataField="R_numeroPorcion" />
                    <asp:BoundField HeaderText="Descripcion" DataField="R_descripcion"/>
                    <asp:TemplateField HeaderText="Transformar">
                        <ItemTemplate>
                            <asp:Button ID="btnTransformar" runat="server" CommandName="TransformarI" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  Text="Transformar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Seleccionar">
                        <ItemTemplate>
                            <asp:Button ID="btnSeleccionarPlato" runat="server" CommandName="SeleccionarPlato" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"   Text="Seleccionar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
        </div>
        <%-- ---------------------- --%>
        <div>
         <div>Entrada</div>
            <div>
            <asp:GridView ID="gvEntrada" runat="server"  DataKeyNames="R_idReceta,R_nombreReceta,R_numeroPorcion,R_descripcion" OnRowCommand="gvEntrada_RowCommand" AutoGenerateColumns="false">
                <Columns>
                  
                    <asp:BoundField HeaderText="Nombre" DataField="R_nombreReceta" />
                    <asp:BoundField HeaderText="Porcion" DataField="R_numeroPorcion" />
                    <asp:BoundField HeaderText="Descripcion" DataField="R_descripcion"/>
                    <asp:TemplateField HeaderText="Transformar">
                        <ItemTemplate>
                            <asp:Button ID="btnTransformar" runat="server" CommandName="TransformarI" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"   Text="Transformar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Seleccionar">
                        <ItemTemplate>
                            <asp:Button ID="btnSeleccionarEntrada" runat="server" CommandName="SeleccionarEntrada" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"   Text="Seleccionar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
        </div>
                <%-- ------------------------- --%>
        <div>
         <div>Menú del día</div>
            <div>
            <asp:GridView ID="gvMenu" runat="server"  DataKeyNames="R_nombreReceta" OnRowCommand="gvMenu_RowCommand" AutoGenerateColumns="false">
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
            </div>
        </div>
         </div>
         </asp:Content>
