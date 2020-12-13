﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarCotizacion.aspx.cs" Inherits="ProyectoMesonURP.GestionarCotizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Solicitar Cotización</h2>
                <div class="stock-options">
                    <div class="width-auto margin-5">
                        <input type="button" class="btn btn-primary" value="Agregar" onclick="window.location.href = 'RegistrarCotizacion.aspx';">
                    </div>
                </div>
            </div>
            <div class="search-buttons">
                <div class="panel panel-widget forms-panel">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h4>Solicitudes de cotización</h4>
                        </div>

                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
                            <asp:GridView ID="GridViewCotizacion" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible."
                                DataKeyNames="C_idCotizacion" AutoGenerateColumns="False" OnRowCommand="gvCotizacion_RowCommand"
                                CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">
                                <Columns>

                                    <asp:BoundField HeaderText="ID Cotizacion" DataField="C_idCotizacion" Visible="false"/>
                                    <asp:BoundField HeaderText="N° de cotización" DataField="C_numeroCotizacion" />
                                    <asp:BoundField HeaderText="Fecha de emisión" DataField="C_fechaEmision" />
                                    <asp:BoundField HeaderText="Tiempo plazo" DataField="C_tiempoPlazo" />
                                    <asp:BoundField HeaderText="Documento" DataField="C_documento" />

                                    <asp:BoundField HeaderText="Proveedor nombre" DataField="PR_razonSocial" />
                                    
                                    <asp:BoundField HeaderText="Estado nombre" DataField="EC_nombreEstadoC" />

                                    <asp:BoundField HeaderText="Usuario nombre" DataField="P_nombres" />

                                    <asp:TemplateField HeaderText="Enviar">
                                        <ItemTemplate>
                                            <%--<asp:Button ID="btnEnviarEmailOC" class="btn btn-primary" runat="server" CommandName="EnviarEmailOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Enviar" OnClick="btnEnviarEmailOC_Click" />--%>
                                            <asp:ImageButton ID="btnEnviarEmailCotizacion" ImageUrl="img/enviar_1.png" onmouseover="this.src='img/enviar-b.png'" onmouseout="this.src='img/enviar_1.png'" runat="server" CommandName="EnviarEmailCotizacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GenerarOc">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnGenerarOC" ImageUrl="img/enviar_1.png" onmouseover="this.src='img/enviar-b.png'" onmouseout="this.src='img/enviar_1.png'" runat="server" CommandName="GenerarOc" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEditarCotizacion" ImageUrl="img/editar.png" onmouseover="this.src='img/editar-b.png'" onmouseout="this.src='img/editar.png'" runat="server" CommandName="ActualizarCotizacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                            <%-- opción para el hover--%> <%--<asp:ImageButton ID="ImageButton1" ImageUrl="img/lapiz.png" onmouseover="this.src='img/editar-w.png'"  onmouseout="this.src='img/lapiz.png'" runat="server" CommandName ="ActualizarOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ver Detalles">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnVerDetallesCotizacion" ImageUrl="img/ojo.png" onmouseover="this.src='img/ojo-b.png'" onmouseout="this.src='img/ojo.png'" runat="server" CommandName="ConsultarCotizacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEliminarCotizacion" ImageUrl="img/delete.png" onmouseover="this.src='img/basura-b.png'" onmouseout="this.src='img/delete.png'" runat="server" CommandName="EliminarCotizacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </div>
                        <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>

             <p class="center-button"  style="margin-top: 49px; margin-bottom: 44px;">
                <asp:Button ID="btnGenerar_OC" CssClass="btn btn-primary" runat="server" Text="Generar OC" />
                <asp:Button ID="btnAdjuntarRespuesta" CssClass="btn btn-primary" runat="server" Text="Adjuntar Respuesta" />
            </p>


            <div class="clearfix"></div>

        </div>

    </div>
</asp:Content>
