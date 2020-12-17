<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarCotizacion.aspx.cs" Inherits="ProyectoMesonURP.ActualizarCotizacion" %>
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
<%--                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Tiempo Plazo:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtTiempoPlazo" runat="server"  CssClass="form-control1" ReadOnly="true"/>
                        </div>
                    </div>--%>
                    <div class="form-group">
                           <label for="selector1" class="col-sm-2 control-label">Tiempo plazo</label>
                           <div class="col-sm-8">
                           <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlTiempoPlazo" >
                                <asp:ListItem  Value="">--seleccione--</asp:ListItem>
                                <asp:ListItem Text="5 días" Value="5 días"></asp:ListItem>
                                <asp:ListItem Text="10 días" Value="10 días"></asp:ListItem>
                                <asp:ListItem Text="20 días" Value="20 días"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlTiempoPlazo" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%-- ----- --%>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Documento:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDoc" runat="server"  CssClass="form-control1"/>
                        </div>
                    </div>
                    <%-- ----- --%>
<%--                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Proveedor:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtProveedor" runat="server"  CssClass="form-control1" ReadOnly="true"/>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Proveedor</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="DdlProveedor" runat="server" CssClass="form-control1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="validationProveedorOC" runat="server" ControlToValidate="DdlProveedor" ErrorMessage="Campo Obligatorio"  CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
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
                    <%-- ----- --%>
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Menú</label>
                        <div class="col-sm-8">
                            <asp:Button ID="btnCal" runat="server" Text="Calendario" OnClick="btnCal_Click" CausesValidation="false"/>
                            <asp:Calendar ID="CldFecha" runat="server" Visible="true" SelectionMode="DayWeekMonth" OnSelectionChanged="CldFecha_SelectionChanged" OnDayRender="CldFecha_DayRender"></asp:Calendar>
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
                                        <%--<asp:BoundField HeaderText="Medida Formato compra" Datafield="IR_formatoMedida"/>--%>
                                    </Columns>   
                                    <SelectedRowStyle BackColor="LightGreen"/>
                                </asp:GridView>
                            </div>


                        </div>
                        <%--  --%>
                    <div class="panel panel-widget forms-panel">

                        <hr />
                        <p class="center-button">
                            <asp:Button ID="btnActualizarCotizacion" CssClass="btn btn-primary" runat="server" OnClick="btnActualizarCotizacion_Click" Text="Actualizar"/>
                            <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarCotizacion.aspx';" class="btn btn-primary" />
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <script>
        function lettersOnly(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
                ((evt.which) ? evt.which : 0));
            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                (charCode < 97 || charCode > 122)) {
                alert("Por favor, ingrese solo letras.");
                return false;
            }
            return true;
        }


        function alertaRechazado() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Ya ha seleccionado una receta',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }


        function alertaExito() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha logrado actualizar la cotización correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "GestionarCotizacion.aspx";
                }
            })
        }


        </script> 
</asp:Content>
