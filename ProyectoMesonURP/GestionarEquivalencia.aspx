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
                            <asp:GridView ID="gvEquivalencia" runat="server" DataKeyNames="E_cantidad,I_idInsumo" AutoGenerateColumns="False" Style="text-align: center" CellPadding="4" GridLines="None" CssClass="table table-bordered table-striped mb-0">
                                <Columns>
                                    <asp:BoundField HeaderText="Insumo" DataField="I_nombreIngrediente" />
                                    <asp:BoundField HeaderText="Medida" DataField="I_nombreInsumo" />
                                    <asp:BoundField HeaderText="Cantidad" DataField="IR_cantidad" />
                                    <asp:BoundField HeaderText="Formato Cocina" DataField="IR_formatoMedida" />
                                   

                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <asp:Button ID="btnEditarEquivalencia" runat="server" OnClick="btnEditarEquivalencia_Click" Text="Editar" />
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
