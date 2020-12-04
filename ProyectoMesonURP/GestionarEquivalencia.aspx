<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarEquivalencia.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.GestionarEquivalencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="women_main">
     <div class="grids">
         <div class="progressbar-heading grids-heading tittle-flex">
             <h2 class="tittle-margin5">Gestionar Equivalencia</h2>
         </div>
     </div>

     <div class="forms">
         <asp:UpdatePanel ID="panel1" runat="server">
                <ContentTemplate>
                    <div class="widget-shadow" style="width: 36%; margin-top: 14px;">
                        <div class="table-wrapper-scroll-y my-custom-scrollbar" runat="server">
                            <asp:GridView ID="gvEquivalencia" runat="server" DataKeyNames="E_cantidad,I_nombreInsumo,M_nombreMedida,FCO_nombreFormatoCocina" OnRowCommand="GVEquivalencia_RowCommand" AutoGenerateColumns="False" Style="text-align: center" CellPadding="4" GridLines="None" CssClass="table table-bordered table-striped mb-0">
                                <Columns>
                                    <asp:BoundField HeaderText="Insumo" DataField="I_nombreInsumo" />
                                    <asp:TemplateField HeaderText="Medida">
                                        <ItemTemplate>
                                              <%# "1" + " " + Eval("M_nombreMedida")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Equivalencia">
                                        <ItemTemplate>
                                              <%# Eval("E_cantidad") + " " + Eval("FCO_nombreFormatoCocina")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <asp:Button  ID="btnEditarEquivalencia" runat="server"  CommandName="EditarEquivalencia" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Editar" />
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
         <asp:UpdatePanel ID="panelAgregarEqui" runat="server">
             <ContentTemplate>
                 <p class="center-button">
                     <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir Equivalencia" OnClick="btnAnadirEquivalencia_Click"></asp:Button>
                 </p>
             </ContentTemplate>
         </asp:UpdatePanel>
     </div>
 </div>
</asp:Content>
