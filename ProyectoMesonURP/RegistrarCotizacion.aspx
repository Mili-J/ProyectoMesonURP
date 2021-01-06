<%@ Page Title="Gestionar Cotización | Registrar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistrarCotizacion.aspx.cs" Inherits="ProyectoMesonURP.RegistrarCotizacion" %>
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
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtFecha" runat="server"  CssClass="form-control1" ReadOnly="true"/>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNumeroComprobante" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
<%--                            <asp:RegularExpressionValidator ID="rev" runat="server" ErrorMessage="" ForeColor="#CC0000" SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                        </div>
                    </div>
                    <%-- ----- --%>


                    <div class="form-group">
                           <label for="selector1" class="col-sm-2 control-label">Tiempo plazo</label>
                           <div class="col-sm-8">
                           <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlTiempoPlazo" CausesValidation="True">
                                <asp:ListItem  Value="">--seleccione--</asp:ListItem>
                                <asp:ListItem Text="5 días" Value="5 días"></asp:ListItem>
                                <asp:ListItem Text="10 días" Value="10 días"></asp:ListItem>
                                <asp:ListItem Text="20 días" Value="20 días"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DdlTiempoPlazo" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirCot" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                     <%-- ----- --%>

                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Menú</label>
                        <div class="col-sm-8">
                            <asp:Button ID="btnCal" runat="server" Text="Calendario" OnClick="btnCal_Click" CausesValidation="false"/>
                            <asp:Calendar ID="CldFecha" runat="server" Visible="false" SelectionMode="DayWeekMonth" OnSelectionChanged="CldFecha_SelectionChanged"></asp:Calendar>
                        </div>
                    </div>
                    <%-- ----- --%>
                      <div class="input-info">
						<h3>Detalles de Insumo</h3>
					</div>
                    <%-- ----- --%>
                 <%--   <div class="form-group">
                           <label for="selector1" class="col-sm-2 control-label">Documento</label>
                           <div class="col-sm-8">
                               <asp:TextBox ID="txtDoc" runat="server"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDoc" ErrorMessage="Campo Obligatorio" ValidationGroup="añadirOC" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>--%>
                    <%-- ----- --%>
                    <div class="form-group">

                        <label for="selector1" class="col-sm-2 control-label">Categorías:</label>
                        <div class="col-sm-8">
                            <asp:DropDownList runat="server" CssClass="form-control1" ID="DdlInsumo"  AutoPostBack="true" CausesValidation="True" OnSelectedIndexChanged="DdlInsumo_SelectedIndexChanged">                        

                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DdlInsumo" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red" ValidationGroup="añadirCot"></asp:RequiredFieldValidator>
                        </div>

                    </div>
                   
                    <%-- ----- --%>


                 <%-- ----- --%>
                    <div class="panel panel-widget forms-panel">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms">
                            <div class="form-title color-white">
                                <h4>
                                    <asp:Label ID="lblCat" runat="server" Text=""></asp:Label>

                                </h4>
                            </div>
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
                        <label for="selector1" class="col-sm-2 control-label">Menú</label>
                        <div class="col-sm-8">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CausesValidation="True" ValidationGroup="añadirCot"/>
                           
                        </div>
                    </div>

                            <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                <asp:GridView ID="GVVerdura"  runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false" 
                                   DataKeyNames="I_idInsumo" CssClass="table table-bordered table-striped mb-0" Style="text-align: center" GridLines="None">
                                    <Columns>

                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="I_idInsumo" runat="server" Text="Label"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:BoundField HeaderText="Insumo" DataField="I_nombreInsumo"  />

<%--                                        <asp:BoundField HeaderText="Cantidad" Datafield="IR_cantidad"/>                        
                                        <asp:BoundField HeaderText="Número de porciones Menú" DataField="numPorcion" />
                                        <asp:BoundField HeaderText="E_cantidad" DataField="E_cantidad" />
                                        <asp:BoundField HeaderText="MXF_cantidadContenida" DataField="MXF_cantidadContenida" />--%>

                                        <asp:BoundField HeaderText="Número total" Datafield="numTotal"/>
                                        <asp:BoundField HeaderText="Formato compra" Datafield="FC_nombreFormatoCompra"/>
                                        <asp:BoundField HeaderText="Cantidad" Datafield="Cantidad"/>
                                        <asp:BoundField HeaderText="Unidad" Datafield="Medida"/>
                                    </Columns>   
                                    
                                    <SelectedRowStyle BackColor="LightGreen"/>
          
                                </asp:GridView>
                            </div>


                        </div>
                        <%--  --%>
                    <div class="panel panel-widget forms-panel">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms">
                            <div class="form-title color-white">
                                <h4>Cotizaciones:</h4>
                            </div>

                            <div class="table-wrapper-scroll-y my-custom-scrollbar">

                                <asp:GridView ID="GVCot"  runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false" 
                                    CssClass="table table-bordered table-striped mb-0" Style="text-align: center" GridLines="None">
                                    <Columns>
                                        <%--<asp:BoundField HeaderText="Insumo" DataField="I_NombreInsumo"  />--%>
                                        <asp:BoundField HeaderText="N° de Cotizacion" DataField="C_numeroCotizacion"  />
                                        <asp:BoundField HeaderText="Tiempo plazo" Datafield="C_tiempoPlazo"/>
                                        <asp:BoundField HeaderText="Documento" Datafield="C_documento" Visible="false"/>
                                        <%--<asp:BoundField HeaderText="Proveedor id" DataField="PR_idProveedor" />--%>
                                        <asp:BoundField HeaderText="Proveedor nombre" DataField="PR_razonSocial" />
                                    </Columns>   
                                    
                                    <SelectedRowStyle BackColor="LightGreen"/>
          
                                </asp:GridView>
                            </div>


                        </div>
                        <%--  --%>
                        <hr />
                        <p class="center-button">
                            <asp:Button ID="btnCrearCotizacion" CssClass="btn btn-primary" runat="server" OnClick="btnCrearCotizacion_Click" Text="Agregar"/>
                            <%--<input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarCotizacion.aspx';" class="btn btn-primary" />--%>
                            <asp:Button ID="btnRegresar" CssClass="btn btn-primary" runat="server" OnClick="btnRegresar_Click" Text="Regresar"/>
                            <%--<asp:Button ID="btnLimpiarOC" CssClass="btn btn-primary" runat="server" OnClick="btnAñadirOC_Click" Text="Limpiar" />--%>
                            <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger" />
                        </p>
                    </div>
                </div>
            </div>
        </div>


               
               

<!-- Modal -->
<div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLongTitle">Detalle de la Cotización</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
          <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
           <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <asp:GridView ID="GVDetCot"  runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false" 
               DataKeyNames="I_idInsumo,I_idIngrediente" CssClass="table table-bordered table-striped mb-0" Style="text-align: center" GridLines="None">
                <Columns>

                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="I_idInsumo" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Insumo" DataField="I_nombreInsumo"  />
                    <asp:BoundField HeaderText="Cantidad" Datafield="IR_cantidad"/>                        
                    <asp:BoundField HeaderText="Cantidad Mínima" DataField="I_cantidadMinima" />
                    <asp:BoundField HeaderText="Peso total" Datafield="I_pesoTotal"/>
                    <asp:BoundField HeaderText="Medida Formato compra" Datafield="IR_formatoMedida"/>
                </Columns>   
                
                <SelectedRowStyle BackColor="LightGreen"/>

            </asp:GridView>

      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        
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
                text: 'Se ha logrado registrar la cotización correctamente',
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
