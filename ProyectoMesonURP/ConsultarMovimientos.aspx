<%@ Page Title="Mesón URP | Consultar Movimiento" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarMovimientos.aspx.cs" Inherits="ProyectoMesonURP.ConsultarMovimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="women_main">
      <!-- start content -->
       <div class="page-header">
			<div class="row">
				<div class="col-md-6 col-sm-12">
					<div class="title">
						<h4>Consultar Movimientos</h4>
					</div>
				</div>
                <div class="header-right pt-2 pr-4">
                  <button type="button" class="btn btn-primary btn-flex" runat="server" onserverclick="btnDescargarExcel_ServerClick">    
                     <span class="material-icons marginR-15">cloud_download</span>
                       <h>Descargar en Excel</h>
                  </button>
               </div>
			</div>
		</div>
        <div class="pd-20 card-box"  runat="server">
            <h5 class="pr-3">Seleccione entre fechas a filtrar o por tipo de movimiento</h5>
                <div class="row justify-content-center" style="margin-top: 20px; margin-bottom:20px">
                    <label class="col-md-2">Fecha: </label>
                    <div class="col-md-2">
                    <asp:TextBox  id="txtFechaInicial" runat="server" CssClass="form-control1" TextMode="Date">
                    </asp:TextBox> 
                        </div>
                     <div class="col-md-2">
                    <asp:TextBox  id="txtFechaFinal" runat="server" CssClass="form-control1" TextMode="Date">
                    </asp:TextBox>
                          </div>
                    <div class="col-md-2">
                         <button type="button" id="btnQuitar" class="btn btn-primary btn-flex" runat="server" onserverclick="btnQuitarFiltro_ServerClick"  style="display: flex; margin-left: 6px;"> 
                                <span class="material-icons marginR-15">highlight_off</span>
                        Quitar
                        </button>

                        <button type="button" id="btnFiltrar" class="btn btn-primary btn-flex" runat="server" onserverclick="btnFiltrar_ServerClick"  style="display: flex; margin-left: 6px;">     
                                <span class="material-icons marginR-15">search</span>
                        Filtrar
                        </button>
                    </div>
                </div>
            <div class="panel panel-widget forms-panel">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h5>Ingresos y Egresos</h5>
                    </div>
                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                        <asp:GridView ID="gvMovimientos" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."  
                            CssClass="table table-bordered table-striped mb-0" Style="text-align: center" DataKeyNames="I_nombreInsumo,M_cantidad,MT_nombreMovimiento,M_fechaMovimiento">
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
