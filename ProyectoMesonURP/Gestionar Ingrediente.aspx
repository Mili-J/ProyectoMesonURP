<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gestionar Ingrediente.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.Gestionar_Ingrediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="women_main">
     <div class="grids">
         <div class="progressbar-heading grids-heading tittle-flex">
             <h2 class="tittle-margin5">Gestionar Ingrediente</h2>
         </div>
     </div>

     <div class="forms">
         <asp:UpdatePanel ID="panel1" runat="server">
                <ContentTemplate>
                    <div class="widget-shadow" style="width: 36%; margin-top: 14px;">
                        <div class="table-wrapper-scroll-y my-custom-scrollbar" runat="server">
                            <asp:GridView ID="gvIngrediente" runat="server" DataKeyNames="I_nombreIngrediente,I_pesoUnitario,I_Cantidad,I_nombreInsumo,E_cantidad,M_nombreMedida,FCO_nombreFormatoCocina" OnRowCommand="GVIngrediente_RowCommand" AutoGenerateColumns="False" Style="text-align: center" CellPadding="4" GridLines="None" CssClass="table table-bordered table-striped mb-0" Width="381px"OnRowDataBound="gvIngrediente_RowDataBound" >
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
                                            <asp:Button  ID="btnEditarIngrediente" CssClass="btn btn-primary" runat="server"  CommandName="EditarIngrediente" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Editar" />
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
                    
                    </div>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
         <asp:UpdatePanel ID="panelAgregarIngrediente" runat="server">
             <ContentTemplate>
                 <p class="center-button">
                     <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir Ingrediente" OnClick="btnAnadirIngrediente_Click"></asp:Button>
                 </p>
             </ContentTemplate>
         </asp:UpdatePanel>
         <asp:UpdatePanel ID="panelVolver" runat="server">
             <ContentTemplate>
                 <p class="center-button">
                     <asp:Button CssClass="btn btn-primary" runat="server" Text="Volver" OnClick="btnVolver_Click"></asp:Button>
                 </p>
             </ContentTemplate>
         </asp:UpdatePanel>
     </div>
 </div>
</asp:Content>
