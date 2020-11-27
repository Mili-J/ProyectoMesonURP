<%@ Page Title="Mesón URP | Manejar Stock" Language="C#" AutoEventWireup="true" CodeBehind="ManejarStock.aspx.cs"  MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.ManejarStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .mb-0 {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="women_main">
                    <!-- start content -->
                    <div class="grids">
                        <div class="progressbar-heading grids-heading title-flex">
                            <h2 class="tittle-margin5">Manejar Stock</h2>
                        </div>
                        <div class="search-buttons">
                            <div class="search">                                
                                    <asp:TextBox  id="txtBuscarInsumo" runat="server"  CssClass="form-control1"  onkeypress="return lettersOnly(event);"  placeholder="Buscar Insumo ..."/>
                                    <button type="button" id="btnBuscar" runat="server" onserverclick="btnBuscar_ServerClick">
                                       <span class="material-icons">search
                                        </span>
                                    </button>
                            </div>
                           </div>
                               <div class="panel panel-widget forms-panel">
                                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                    <div class="form-title color-white">
                                        <h4>Stock Actual</h4>
                                    </div>
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                       <asp:GridView ID="gvInsumos" allowpaging="True" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."  
                                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_idInsumo,I_NombreInsumo,CI_nombreCategoria,I_cantidad,Representacion de compra,El_nombreEstado"  
                                            Style="text-align: center" OnPageIndexChanging="gvInsumos_PageIndexChanging" CellPadding="4" PageSize="5" OnSelectedIndexChanged="gvInsumos_SelectedIndexChanged" GridLines="None">
                                            <Columns>
                                                <asp:BoundField DataField="I_idInsumo" HeaderText="Id_Insumo" Visible="False" />
                                                <asp:BoundField DataField="I_NombreInsumo" HeaderText="Insumo" />
                                                <asp:BoundField DataField="CI_nombreCategoria" HeaderText="Categoria" />
                                                <asp:BoundField DataField="I_cantidad" HeaderText="Cantidad" />
                                                <asp:BoundField DataField="Representacion de compra" HeaderText="Representacion de compra" />
                                                <asp:BoundField DataField="El_nombreEstado" HeaderText="Estado" />
                                                <%--<asp:TemplateField HeaderText="Transformar">
                                                    <ItemTemplate>
                                                <asp:ImageButton ID="btnTransformar" ImageUrl="img/enviar_1.png" onmouseover="this.src='img/enviar-b.png'" onmouseout="this.src='img/enviar_1.png'" runat="server" CommandName="TransformarIn" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                             <hr /> 

                            <div class="panel panel-widget forms-panel">
                                 <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                    <div class="form-title color-white">
                                     <h4>Insumos que requieren abastecimiento</h4>
                                    </div>
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                     <asp:GridView ID="gvInsumos2" allowpaging="True" runat="server" AutoGenerateColumns="False" emptydataText="No hay información disponible."  
                                        CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_idInsumo,I_NombreInsumo,I_cantidadMinima,I_cantidad,El_nombreEstado" 
                                        Style="text-align: center" OnPageIndexChanging="gvInsumos2_PageIndexChanging" CellPadding="4" PageSize="5" GridLines="None" OnSelectedIndexChanged="gvInsumos2_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="I_idInsumo" HeaderText="Id_Insumo" Visible="False" />
                                            <asp:BoundField Datafield="I_NombreInsumo" HeaderText="Nombre insumo" />
                                            <asp:BoundField Datafield="I_cantidadMinima" HeaderText="Stock minimo" />
                                            <asp:BoundField Datafield="I_cantidad" HeaderText="Stock actual" />
                                            <asp:BoundField Datafield="El_nombreEstado" HeaderText="Estado" />
                                            <%--<asp:TemplateField HeaderText="Solicitar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnSolicitar" ImageUrl="img/enviar_1.png" onmouseover="this.src='img/enviar-b.png'" onmouseout="this.src='img/enviar_1.png'" runat="server" CommandName="SolicitarCo" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                            </ItemTemplate>
                                                </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Solicitar">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkBox" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                                  </div>
                               </div>
                            <hr /> 
                            <div class="form-group2">
                            <asp:UpdatePanel ID="PanelSolicitar" runat="server">
                                <ContentTemplate>
                                     <p class="center-button">
                                        <asp:Button CssClass="btn btn-primary" runat="server" Text="Solicitar" ID="btnSolicitar" OnClick="btnSolicitar_Click"/>
                       
                                      </p>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                     </div>
                  </div>
    <script>
             function soloLetras(e) {
                 key = e.keyCode || e.which;
                 tecla = String.fromCharCode(key).toLowerCase();
                 letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
                 especiales = [8, 37, 39, 46];

                 tecla_especial = false
                 for (var i in especiales) {
                     if (key == especiales[i]) {
                         tecla_especial = true;
                         break;
                     }
                 }

                 if (letras.indexOf(tecla) == -1 && !tecla_especial)
                     return false;
             }
             function alertaError() {
                 Swal.fire({
                     title: 'Oh, no!',
                     text: 'Ingrese un insumo para la busqueda',
                     icon: 'error',
                     confirmButtonText: 'Aceptar'
                 })
             }
    </script>
</asp:Content>
