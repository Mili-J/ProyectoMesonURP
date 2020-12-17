<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarCotizacion.aspx.cs" Inherits="ProyectoMesonURP.ConsultarCotizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Solicitud de Cotización</h2>
            </div>
        </div>
        <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    <div class="input-info">
                        <h3>Detalles de Cotización</h3>
                    </div>  
                    <%-- ----- --%>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Número de Cotización:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtNumCot" runat="server"  CssClass="form-control1" ReadOnly="true"/>
                        </div>
                    </div>                    
                    <%-- ----- --%>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha de emisión:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtFechaEmision" runat="server"  CssClass="form-control1" ReadOnly="true"/>
                        </div>
                    </div>
                    <%-- ----- --%>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Tiempo Plazo:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtTiempoPlazo" runat="server"  CssClass="form-control1" ReadOnly="true"/>
                        </div>
                    </div>
                    <%-- ----- --%>
<%--                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Documento:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDoc" runat="server"  CssClass="form-control1" ReadOnly="true"/>
                        </div>
                    </div>--%>
                    <%-- ----- --%>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Proveedor:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtProveedor" runat="server"  CssClass="form-control1" ReadOnly="true"/>
                        </div>
                    </div>
                    <%-- ----- --%>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Estado:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtEstado" runat="server"  CssClass="form-control1" ReadOnly="true"/>
                        </div>
                    </div>
                    <%-- ----- --%>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Usuario:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtUsuario" runat="server"  CssClass="form-control1" ReadOnly="true"/>
                        </div>
                    </div>
                    <%-- ----- --%>
                      <div class="input-info">
						<h3>Detalles de Insumo</h3>
					</div>

                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Menú</label>
                        <div class="col-sm-8">
                            <asp:Button ID="btnCal" runat="server" Text="Calendario" OnClick="btnCal_Click" CausesValidation="false"/>
                            <asp:Calendar ID="CldFecha" runat="server" Visible="true" SelectionMode="None" OnDayRender="CldFecha_DayRender" Enabled="false"></asp:Calendar>
                        </div>
                    </div>
                    <%-- ----- --%>

                            <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                <asp:GridView ID="GVDetalleCot"  runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false" 
                                   DataKeyNames="DC_idDetalleCotizacion" CssClass="table table-bordered table-striped mb-0" Style="text-align: center" GridLines="None">
                                    <Columns>

                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="I_idInsumo" runat="server" Text="Label"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Insumo" DataField="I_nombreInsumo"  />
                                        <asp:BoundField HeaderText="Cantidad" Datafield="DC_cantidadCotizacion"/>
                                        
                                        <asp:BoundField HeaderText="Formato compra" Datafield="FC_nombreFormatoCompra"/>
                                        
                                    </Columns>   
                                    <SelectedRowStyle BackColor="LightGreen"/>
                                </asp:GridView>
                            </div>


                        </div>
                        <%--  --%>
                    <div class="panel panel-widget forms-panel">

                        <hr />
                        <p class="center-button">
                            <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarCotizacion.aspx';" class="btn btn-primary" />
                        </p>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
