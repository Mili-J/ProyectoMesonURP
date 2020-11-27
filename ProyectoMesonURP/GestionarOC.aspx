<%@ Page Title="Mesón URP | Gestionar Orden de Compra" Language="C#" AutoEventWireup="true" CodeBehind="GestionarOC.aspx.cs"  MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.GestionarOC" %>
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
                            <h2 class="tittle-margin5">Gestionar Orden de Compra</h2>
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
                                        <h4>Ordenes de Compra</h4>
                                    </div>
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                       <asp:GridView ID="gvOC" allowpaging="True" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."  
                                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="OC_idOC,OC_numeroOC,PR_nombreContacto,OC_fechaEmision,OC_fechaEntrega,EC_nombreEstadoC"  
                                            Style="text-align: center" OnPageIndexChanging="gvOC_PageIndexChanging" CellPadding="4" PageSize="5" OnSelectedIndexChanged="gvOC_SelectedIndexChanged" GridLines="None">
                                            <Columns>
                                                <asp:BoundField DataField="OC_idOC" HeaderText="Id_OC" Visible="False" />
                                                <asp:BoundField DataField="OC_numeroOC" HeaderText="N° de Compra" />
                                                <asp:BoundField DataField="PR_nombreContacto" HeaderText="Proveedor" />
                                                <asp:BoundField DataField="OC_fechaEmision" HeaderText="Fecha de Emisión" />
                                                <asp:BoundField DataField="OC_fechaEntrega" HeaderText="Fecha de Entrega" />
                                                <asp:BoundField DataField="EC_nombreEstadoC" HeaderText="Estado" />
                                                <asp:TemplateField HeaderText="Descargar">
                                                    <ItemTemplate>
                                                <asp:ImageButton ID="btnDescargar" ImageUrl="img/enviar_1.png" onmouseover="this.src='img/enviar-b.png'" onmouseout="this.src='img/enviar_1.png'" runat="server" CommandName="DescargarIn" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Recepcionar">
                                                    <ItemTemplate>
                                                <asp:ImageButton ID="btnRecepcionar" ImageUrl="img/enviar_1.png" onmouseover="this.src='img/enviar-b.png'" onmouseout="this.src='img/enviar_1.png'" runat="server" CommandName="RecepcionarIn" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                             <hr />
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
