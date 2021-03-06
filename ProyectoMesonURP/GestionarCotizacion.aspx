﻿<%@ Page Title="MesónURP | Gestionar Cotización" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarCotizacion.aspx.cs" Inherits="ProyectoMesonURP.GestionarCotizacion" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .mb-0 {}
    </style>
        <link rel="stylesheet" type="text/css" href="vendors/styles/core.css">
    	<link rel="stylesheet" type="text/css" href="vendors/styles/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
    <!-- start content -->
     <div class="page-header">
	    <div class="row">
		    <div class="col-md-6 col-sm-12">
			    <div class="title">
					<h4>Gestionar Cotización</h4>
				</div>
			</div>
             <div class="header-right pt-2 pr-4">
                <button type="button" class="btn btn-primary btn-flex" runat="server" style="display: flex; margin-left: 6px;"  onclick="window.location.href = 'RegistrarCotizacion.aspx';">    
                    <span class="material-icons margin-5">add_circle_outline</span>
                    Añadir Cotización
                </button>
            </div>
		</div>
	 </div>
    <div class="pd-20 card-box"  runat="server" id="PanelInsumos">
        <div class="row pt-1">    
            <div class="col-sm-12 col-md-6">            
                <label class="control-label col-md-2">Paginación:</label>
                    <asp:DropDownList ID="ddlp" class="custom-select custom-select-sm form-control form-control-sm" style="width: auto; height: 38px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlp_SelectedIndexChanged">
                    </asp:DropDownList>
            </div>
             <div class="col-sm-12 col-md-3 pl-30"></div>
             <div class="col-sm-12 col-md-3 pl-30">
                 <div class="search-icon-box bg-white box-shadow border-radius-10 mb-30">
                      <asp:TextBox ID="txtBuscarInsumo" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="fNombreCotizacion_TextChanged" onkeypress="return lettersOnly(event);" placeholder="Buscar N° de Cotización ..."/>
					<i class="search_icon dw dw-search"></i>
				</div>
             </div>
         </div>
       <div class="panel panel-widget forms-panel" >
        <div class="form-grids widget-shadow" data-example-id="basic-forms">
            <div class="form-title color-white">
                <h5>Solicitudes de Cotización</h5>
            </div>
                <div class="w3-row-padding">
                    <div class="table-wrapper-scroll-y my-custom-scrollbar">    
                        <asp:GridView ID="GridViewCotizacion" allowPaging="False" runat="server" EmptyDataText="No hay información disponible."
                            DataKeyNames="C_idCotizacion" AutoGenerateColumns="False" OnRowDataBound="GridViewCotizacion_RowDataBound" 
                            CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" PageSize="5" GridLines="None" OnRowCommand="GridViewCotizacion_RowCommand">
                            <PagerStyle HorizontalAlign="Right" BackColor="#dee2e6"> </PagerStyle> 
                            <Columns>
                                <asp:BoundField HeaderText="ID Cotizacion" DataField="C_idCotizacion" Visible="false"/>
                                <asp:BoundField HeaderText="N°" DataField="C_numeroCotizacion" />
                                <asp:BoundField HeaderText="Fecha de emisión" DataField="C_fechaEmision" />
                                <asp:BoundField HeaderText="Tiempo plazo" DataField="C_tiempoPlazo" />
                                <asp:BoundField HeaderText="Documento" DataField="C_documento" Visible="false" />

                                <asp:BoundField HeaderText="Proveedor" DataField="PR_razonSocial" />
                                    
                                <asp:BoundField HeaderText="Estado" DataField="EC_nombreEstadoC" />

                                <asp:BoundField HeaderText="Usuario" DataField="P_nombres" />

                                 <asp:TemplateField HeaderText="Enviar">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEnviarEmailCotizacion" class="btn btn-info btn-sm" runat="server" CommandName="EnviarEmailCotizacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ><i class="fa fa-paper-plane-o"></i>&nbsp;Enviar</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Detalle">
                                    <ItemTemplate>
                                         <asp:LinkButton ID="btnVerDetallesCotizacion" runat="server" CommandName="DetallesCotizacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  class="btn btn-info btn-sm"><i class="fa fa-eye"></i>&nbsp; Ver</asp:LinkButton>
								    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Editar" Visible="false">
                                    <ItemTemplate>
                                               <asp:LinkButton ID="btnEditarCotizacion" runat="server" CommandName="ActualizarCotizacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" class="dropdown-item"><i class="dw dw-edit2"></i>&nbsp;Editar</asp:LinkButton>
										</ItemTemplate>
                                </asp:TemplateField>      
                                 <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <div style="text-align: center">
                                                <asp:ImageButton ID="btnAceptada" ImageUrl="img/correcto.png" onmouseover="this.src='img/correcto-b.png'" onmouseout="this.src='img/correcto.png'" runat="server" CommandName="AceptarCotizacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" TabIndex="1" />

                                                <asp:ImageButton ID="btnRechazada" ImageUrl="img/eliminar.png" onmouseover="this.src='img/eliminar-b.png'" onmouseout="this.src='img/eliminar.png'" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="RechazarCotizacion" TabIndex="2" />
                                            </div>
                                            <asp:ImageButton ID="btnRecibida" runat="server" ImageUrl="img/recibido.png" onmouseover="this.src='img/recibido-b.png'" onmouseout="this.src='img/recibido.png'" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="RecibirCotizacion" TabIndex="3" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <div class="clearfix"></div>

        </div>

    </div>
        <script>
        function alertaAceptado() {
            Swal.fire({
                title: 'Aceptado',
                text: 'La solicitud de cotización ha sido aceptada satisfactoriamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaRechazado() {
            Swal.fire({
                title: 'Rechazado',
                text: 'La solicitud de cotización ha sido rechazada satisfactoriamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaRecibido() {
            Swal.fire({
                title: 'Recibida',
                text: 'La solicitud de cotización ha sido recibida',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaEliminar() {
            Swal.fire({
                title: 'Eliminado',
                text: 'La Orden de Compra ha sido eliminada',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaCorreo() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha enviado el correo satisfactoriamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            })
            }
            function alertaCorreoNo() {
                Swal.fire({
                    title: 'Oh, no!',
                    text: 'No se ha podido enviar el correo',
                    icon: 'error',
                    confirmButtonText: 'Aceptar'
                })
            }
        </script>
</asp:Content>
