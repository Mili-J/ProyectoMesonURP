<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarMovimientos.aspx.cs" Inherits="ProyectoMesonURP.ConsultarMovimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="women_main">
                    <!-- start content -->
                    <div class="grids">
                        <div class="progressbar-heading grids-heading title-flex">
                            <h2 class="tittle-margin5">Consultar Movimientos</h2>
                            <div class="stock-options">
                                    <div class="width-auto margin-5">
                                        <button type="button" class="btn btn-primary btn-flex" runat="server" onserverclick="btnDescargarExcel_ServerClick">     
                                            <span class="material-icons marginR-15">cloud_download</span>
                                            <h>Descargar en Excel</h>
                                        </button>
                                    </div>                                
                            </div>
                        </div>
                        <div class="search-buttons">
                                <div class="panel panel-widget forms-panel">
                                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                    <div class="form-title color-white">
                                        <h4>Ingresos y Egresos</h4>
                                    </div>
                                    
                                     <div class="div-movflex modal-header">
                                        <label>Fecha: </label>
                                        <asp:TextBox  id="txtFechaInicial" runat="server" CssClass="form-control1" TextMode="Date">
                                        </asp:TextBox> 
                                         <asp:TextBox  id="txtFechaFinal" runat="server" CssClass="form-control1" TextMode="Date">
                                        </asp:TextBox>
                                         <button type="button" id="btnQuitar" class="btn btn-primary btn-flex" runat="server" onserverclick="btnQuitarFiltro_ServerClick">     
                                             <p>Quitar</p>
                                        </button>

                                         <button type="button" id="btnFiltrar" class="btn btn-primary btn-flex" runat="server" onserverclick="btnFiltrar_ServerClick">     
                                             <p>Filtrar</p>
                                        </button>
                                    </div>
                                    <div class="clearfix"></div>
                                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                       <asp:GridView ID="gvMovimientos" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."  
                                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_nombreInsumo,M_cantidad,MT_nombreMovimiento,M_fechaMovimiento">
                                            <Columns>
                                                <asp:BoundField DataField="I_nombreInsumo" HeaderText="Insumo" />
                                                <asp:BoundField DataField="M_cantidad" HeaderText="Cantidad" />
                                                <asp:BoundField DataField="MT_nombreMovimiento" HeaderText="Tipo" />
                                                <asp:BoundField DataField="M_fechaMovimiento" HeaderText="Fecha" />       
                                            </Columns>
                                        </asp:GridView>
                                          </ContentTemplate>
                                     </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
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
                     text: 'Por favor, ingrese solo letras',
                     icon: 'error',
                     confirmButtonText: 'Aceptar'
                 })
             }
             function alertad() {
                 Swal.fire({
                     title: 'Oh, no!',
                     text: 'Por favor, ingrese solo letras',
                     icon: 'error',
                     confirmButtonText: 'Aceptar'
                 })
             }
         </script>
      
</asp:Content>
