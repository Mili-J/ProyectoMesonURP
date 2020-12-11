<%@ Page Title="Mesón URP | Recepción de Insumos" Language="C#" AutoEventWireup="true" CodeBehind="Recepción_Insumos.aspx.cs"  MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.Recepción_Insumos" %>
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
                            <h2 class="tittle-margin5">Recepción de Insumos</h2>
                        </div>
                        <div class="forms" style="display: flex; flex-direction: row;">
                            <asp:UpdatePanel ID="PanelInsumos" runat="server">
                                <ContentTemplate>
                                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                        <div class="form-title color-white">
                                            <h4>Insumos</h4>
                                        </div>
                                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                            <asp:GridView ID="gvInsumos" allowpaging="True" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."
                                                CssClass="table table-bordered table-striped mb-0" DataKeyNames="OC_idOC,DC_idDetalleCotizacion,I_idInsumo,I_nombreInsumo,DC_cantidadCotizacion,Estado"   
                                                Style="text-align: center" OnPageIndexChanging="gvInsumos_PageIndexChanging" CellPadding="4" PageSize="5" OnSelectedIndexChanged = "gvInsumos_SelectedIndexChanged" AllowSorting="False" EnablePersistedSelection="True">
                                                <Columns>
                                                    <asp:BoundField DataField="OC_idOC" HeaderText="Id_OC" Visible="False" />
                                                    <asp:BoundField DataField="DC_idDetalleCotizacion" HeaderText="ID_DetalleCotizacion" Visible="False" />
                                                    <asp:BoundField DataField="I_idInsumo" HeaderText="N° Insumo" />
                                                    <asp:BoundField DataField="I_nombreInsumo" HeaderText="Nombre" />
                                                    <asp:BoundField DataField="DC_cantidadCotizacion" HeaderText="Cantidad" />
                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-horizontal" runat="server" style="margin: 10px; background-color: #FFFFFF; border-radius: 1%; width: auto; ">
                                <div class="container-sw">
                                    <div class="form-group">
                                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control form-color-letter" Style="width: 100%" />
                                        </div>
                                    </div>
                                    <asp:UpdatePanel ID="PanelAñadir" runat="server">
                                        <ContentTemplate>
                                            <p class="center-button">
                                                <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ID="btnAñadir" OnClick="btnAñadir_Click" />
                                            </p>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="PanelIngresos" runat="server">
                                <ContentTemplate>
                                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                        <div class="form-title color-white">
                                            <h4>Ingresos</h4>
                                        </div>
                                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                            <asp:GridView ID="gvIngresos" allowpaging="True" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."
                                                CssClass="table table-bordered table-striped mb-0" DataKeyNames="I_idInsumo,I_nombreInsumo,M_fechaMovimiento,Hora,M_cantidad,DC_idDetalleCotizacion"  
                                                Style="text-align: center" OnPageIndexChanging="gvIngresos_PageIndexChanging" CellPadding="4" PageSize="5" OnSelectedIndexChanged="gvIngresos_SelectedIndexChanged" GridLines="None">
                                                <Columns>
                                                    <asp:BoundField DataField="I_idInsumo" HeaderText="N° Insumo" />
                                                    <asp:BoundField DataField="I_nombreInsumo" HeaderText="Nombre" />
                                                    <asp:BoundField DataField="M_fechaMovimiento" HeaderText="Fecha de Entrega" />
                                                    <asp:BoundField DataField="Hora" HeaderText="Hora" />
                                                    <asp:BoundField DataField="M_cantidad" HeaderText="Cantidad Ingresada" />
                                                    <asp:BoundField DataField="DC_idDetalleCotizacion" HeaderText="ID_DetalleCotizacion" Visible="False" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <hr />
                                    <p class="center-button">
                                        <asp:Button CssClass="btn btn-primary" runat="server" Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" />
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