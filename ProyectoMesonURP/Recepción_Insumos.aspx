<%@ Page Title="Gestionar OC | Recepción de Insumos" Language="C#" AutoEventWireup="true" CodeBehind="Recepción_Insumos.aspx.cs"  MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.Recepción_Insumos" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .mb-0 {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
           <div class="page-header">
                <div class="row">
	                <div class="col-md-6 col-sm-12">
		                <div class="title">
			                <h4>Recepción de Insumos</h4>
		                </div>
	                </div>
                </div>
           </div>
          <div class="pd-20 card-box">
               <div class="row clearfix">
                    <div class="col-md-5 col-sm-12 mb-30 pt-20">
                    <asp:UpdatePanel ID="PanelInsumos" runat="server">
                                <ContentTemplate>
                                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                        <div class="form-title color-white">
                                            <h5>Insumos de la Orden de Compra</h5>
                                        </div>
                                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                            <asp:GridView ID="gvInsumos" allowpaging="True" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."
                                                CssClass="table table-bordered table-striped mb-0" DataKeyNames="OC_idOC,DOC_idDetalleOC,I_idInsumo,I_nombreInsumo,DC_cantidadCotizacion,Estado,Datos"   
                                                Style="text-align: center" OnPageIndexChanging="gvInsumos_PageIndexChanging" CellPadding="4" PageSize="5" OnSelectedIndexChanged = "gvInsumos_SelectedIndexChanged" AllowSorting="False" EnablePersistedSelection="True">
                                                <Columns>
                                                    <asp:BoundField DataField="OC_idOC" HeaderText="Id_OC" Visible="False" />
                                                    <asp:BoundField DataField="DOC_idDetalleOC" HeaderText="ID_DOC" Visible="False" />
                                                    <asp:BoundField DataField="I_idInsumo" HeaderText="N° Insumo" />
                                                    <asp:BoundField DataField="I_nombreInsumo" HeaderText="Nombre" />
                                                    <asp:BoundField DataField="DC_cantidadCotizacion" HeaderText="Cantidad" />
                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                                    <asp:BoundField DataField="Datos" HeaderText="Datos" Visible="False" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                    </div>
                     <div class="col-md-2 col-sm-12 mb-30 pt-30">
                        <div class="row pt-5">
                                <div class="col-md-5 pt-2">
                                <label>Cantidad: </label>
                                </div> 
                            <div class="col-md-6">
                                <asp:TextBox ID="txtCantidad" runat="server" class="form-control" TextMode="Number" />
                            </div>
                        </div>
                        <div class="center-button pt-3">
                        <asp:UpdatePanel ID="PanelAñadir" runat="server">
                            <ContentTemplate>
                                <p class="center-button">
                                    <asp:Button class="btn btn-primary btn-lg fa" style="height:40px; font-weight:500" runat="server" Text="" ID="btnAñadir" OnClick="btnAñadir_Click" />
                                </p>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                     </div>
                     <div class="col-md-5 col-sm-12 mb-30 pt-20">
                    <asp:UpdatePanel ID="PanelIngresos" runat="server">
                                <ContentTemplate>
                                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                        <div class="form-title color-white">
                                            <h5>Insumos Ingresados</h5>
                                        </div>
                                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                            <asp:GridView ID="gvIngresos" allowpaging="True" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."
                                                CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_idInsumo,I_nombreInsumo,M_fechaMovimiento,Hora,Cantidad,M_cantidad,DO_cantidadE,DOC_idDetalleOC"  
                                                Style="text-align: center" OnPageIndexChanging="gvIngresos_PageIndexChanging" CellPadding="4" PageSize="5" OnSelectedIndexChanged="gvIngresos_SelectedIndexChanged" GridLines="None" OnRowCommand="gvIngresos_RowCommand" OnRowDeleting="gvIngresos_RowDeleting">
                                                <Columns>
                                                    <asp:BoundField DataField="I_idInsumo" HeaderText="N° Insumo" />
                                                    <asp:BoundField DataField="I_nombreInsumo" HeaderText="Nombre" />
                                                    <asp:BoundField DataField="M_fechaMovimiento" HeaderText="Fecha de Entrega" />
                                                    <asp:BoundField DataField="Hora" HeaderText="Hora" />
                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad Ingresada" />
                                                    <asp:BoundField DataField="M_cantidad" HeaderText="CantidadIN" Visible="False" />
                                                    <asp:BoundField DataField="DO_cantidadE" HeaderText="Cantidad" Visible="False" />
                                                    <asp:BoundField DataField="DOC_idDetalleOC" HeaderText="ID_DOC" Visible="False" />
                                                    <asp:TemplateField HeaderText="Quitar">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnQuitar" runat="server" class="btn btn-danger" CommandName="Quitar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ><i class="dw dw-delete-2"></i>&nbsp;</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <hr />
                                    <p class="center-button">
                                        <asp:Button CssClass="btn btn-primary" runat="server" Text="Registrar" ID="btnAceptar" OnClick="btnAceptar_Click" />
                                    </p>
                                </ContentTemplate>
                            </asp:UpdatePanel>
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

             function alertaCantMax() {
                 Swal.fire({
                     title: 'Oh, no!',
                     text: 'Cantidad máxima excedida',
                     icon: 'error',
                     confirmButtonText: 'Aceptar'
                 })
             }

            function alertaSeleccionar() {
                Swal.fire({
                    title: 'Oh, no!',
                    text: 'Selecciona un insumo, por favor',
                    icon: 'error',
                    confirmButtonText: 'Aceptar'
                })
            }

    </script>
</asp:Content>