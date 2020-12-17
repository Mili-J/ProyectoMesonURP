<%--<%@ Page Title="Gestionar Receta | Actualizar Receta" Language="C#" AutoEventWireup="true" CodeBehind="ActualizarReceta.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.ActualizarReceta" EnableEventValidation="false" %>--%>
<%@ Page Title="Gestionar Receta | Actualizar Receta" Language="C#" AutoEventWireup="true" CodeBehind="ActualizarReceta.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.ActualizarReceta" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
         <div class="pd-ltr-20 xs-pd-20-10">
                <div class="page-header">
                    <div class="row">
                        <div class="col-md-12 col-sm-12">
                            <h4 class="tittle-margin5">Actualizar Receta</h4>
                        </div>
                    </div>
               </div>
        <div class="row clearfix">
            <div class="col-md-6 col-sm-12 mb-30">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h5>Información del Plato</h5>
                    </div>
                </div>
                 <div class="pd-20 card-box height-100-p">
                   <div class="col-md-6">
                        <div class="form-group">
                            <label>Nombre del plato</label>
                            <asp:TextBox ID="txtnombre" runat="server" class="form-control" onkeypress="return soloLetras(event);" required="required" />
                        </div>
                    </div>
                     <div class="col-md-6">
                            <div class="form-group">
                                <label>N° porciones</label>
                                <asp:TextBox ID="txtPorciones" runat="server" placeholder="Ingrese una cantidad" class="form-control" onkeypress="return SoloNumeroInt(event);" MaxLength="3" required='required' />
                            </div>
                        </div>

                      <div class="form-group">
                           <div class="col-md-6">
                                <div class="form-group">
                                <label>Categoría</label>
                                 <asp:TextBox ID="txtCategoriaReceta" runat="server" class="form-control" Enabled="true" />
                                </div>
                           </div>
                          <div class="row">
                           <div class="col-md-6">
                            <asp:DropDownList ID="ddlCategoriaReceta" runat="server" class="custom-select2 form-control">
                                <asp:ListItem Text="" Value="">Seleccione una categoría</asp:ListItem>
                            </asp:DropDownList>
                               </div>
                               <div class="col-md-3">
                            <asp:ImageButton ID="btnEditar" ImageUrl="img/editar.png" onmouseover="this.src='img/editar-b.png'" onmouseout="this.src='img/editar.png'" runat="server" OnClick="btnEditarCategoria_Click"/>
                              </div>
                                   <%-- <asp:RequiredFieldValidator ID="rfvcategoriaR" runat="server" ControlToValidate="ddlCategoriaReceta" ErrorMessage="Campo Obligatorio"  CssClass="required-item" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>--%>
                            </div>
                       </div>

                     <div class="form-group">
                         <div class="col-md-6">
                                <div class="form-group">
                                  <label>Sub categoría</label>
                                 <asp:TextBox ID="txtSubcategoria" runat="server" class="custom-select2 form-control"  Enabled="true"/>
                             </div>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlSubCategoria" runat="server" class="custom-select2 form-control" >
                                <asp:ListItem Text="" Value="">Seleccione una sub categoría</asp:ListItem>
                                <asp:ListItem  Value="Entradas">Entradas</asp:ListItem>
                                <asp:ListItem  Value="Plato de fondo">Plato de fondo</asp:ListItem>
                                <asp:ListItem  Value="Sopas">Sopas</asp:ListItem>
                                <asp:ListItem  Value="Postres">Postres</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ImageButton ID="ImageButton1" ImageUrl="img/editar.png" onmouseover="this.src='img/editar-b.png'" onmouseout="this.src='img/editar.png'" runat="server" OnClick="btnEditarSubCategoria_Click"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSubCategoria" ErrorMessage="Campo Obligatorio"  CssClass="required-item" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                     <div class="col-md-6">
                         <div class="form-group">
                         <label>Estado</label>
                            <asp:TextBox ID="txtEstadoReceta" runat="server"  class="form-control" Enabled="true"/>
                         </div>
                            <asp:DropDownList ID="ddlEstadoReceta" runat="server" class="form-control">
                                <asp:ListItem Text="" Value="">Seleccione un estado</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ImageButton ID="ImageButton3" ImageUrl="img/editar.png" onmouseover="this.src='img/editar-b.png'" onmouseout="this.src='img/editar.png'" runat="server" OnClick="btnEditarEstadoReceta_Click"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlEstadoReceta" ErrorMessage="Campo Obligatorio"  CssClass="required-item" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                     </div>
                     <div class="col-md-6">
                        <div class="form-group">
                            <label>Descripción</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" class="form-control"  placeholder="Descripcion"/>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6 col-sm-12 mb-30">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h5>Imagen de Referencia</h5>
                    </div>
                </div>
                <div class="pd-20 card-box height-100-p">
                    <div class="img-div">
                        <div class="form-group" style="display: flex; margin-top: 58px; justify-content: center;">
                            <asp:Image ID="ImagenPreview" Style="height: 56px;" ImageUrl="https://img.icons8.com/fluent/48/000000/image.png" runat="server" />
                            <br />
                            <br />
                            <label style="height: 45px; width: 257px" class="col-sm-2 control-label">Selecciona la imagen</label>
                            <asp:FileUpload Style="height: 45px; z-index: 100;" ID="fuImagen" accept=".jpg" runat="server" CssClass="form-control1 " />
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="padding-top-30">
            <div class="pd-20 card-box mb-30">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h5>Ingredientes</h5>
                        </div>
                    </div>
                <div class="row clearfix">

             <div class="col-md-6 col-sm-12 mb-30">
                <div class="form-group pt-5 pl-5">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            <label>Ingredientes</label>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlIngredientes" runat="server" class="custom-select2 form-control" AutoPostBack="true">
                                    <asp:ListItem Text="" Value="">Seleccione una Ingrediente</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvingredientes" runat="server" ControlToValidate="ddlIngredientes" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                            </div>
                            </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="form-group pt-3 pl-5">
                    <label>Cantidad</label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtCantidad" runat="server" class="form-control" onkeypress="return SoloNumeroIntDouble(event);" MaxLength="5" />
                    </div>
                </div>
                 <div class="form-group pt-3 pl-5">
                      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                            <label>Medida</label>
                             <asp:TextBox ID="txtMedidaFormato" runat="server" class="form-control" />
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlMedida" runat="server" class="custom-select2 form-control">
                                </asp:DropDownList>
                            </div>
                            </ContentTemplate>
                       </asp:UpdatePanel>
                   </div>
                    <asp:UpdatePanel ID="UpdateButton" runat="server">
                        <ContentTemplate>
                        <p class="center-button">
                            <asp:Button CssClass="btn btn-outline-success" runat="server" Text="Añadir" ID="btnAñadirIngredientes" OnClick="btnAñadirIngredientes_Click" />
                            <asp:LinkButton ID="btnQuitarIngredientes" runat="server"  OnClick="btnQuitarIngredientes_Click" class="btn btn-outline-danger"><i class="fa fa-times-circle-o"></i>&nbsp;Quitar</asp:LinkButton>
                        </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                 </div>
             <div class="col-md-6 col-sm-12 mb-30">
                    <%--<asp:UpdatePanel ID="PanelAñadir" runat="server">
                        <ContentTemplate>--%>
                            <div class="panel panel-widget forms-panel" style="width: 60vh; margin-top: 27px;">
                                <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                    <asp:GridView ID="gvIngredientes" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="False" OnRowDataBound="gvIngredientes_OnRowDataBound"
                                        DataKeyNames="I_nombreIngrediente, IR_cantidad, IR_formatoMedida"
                                        CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">

                                        <Columns>
                                            <asp:BoundField HeaderText="Nombre Ingrediente" DataField="I_nombreIngrediente" />
                                            <asp:BoundField HeaderText="Cantidad" DataField="IR_cantidad" />
                                            <asp:BoundField HeaderText="Medida" DataField="IR_formatoMedida" />

                                        </Columns>
                                        <SelectedRowStyle BackColor="LightGreen" />
                                    </asp:GridView>
                                    </div>
                                </div>
                        <%--</ContentTemplate>--%>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAñadirIngredientes" />
                            <asp:PostBackTrigger ControlID="btnGuardar" />
                        </Triggers>
                    <%--</asp:UpdatePanel>--%>
              </div>
                    <asp:Label ID="lblIndex" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
                <hr />
                    <p class="center-button"  style="margin-top: 49px; margin-bottom: 44px;">
                        <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnGuardar" onserverclick="btnGuardar_ServerClick">Guardar</button>
                        <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarReceta';" onserverclick="btnRegresar_ServerClick" class="btn btn-primary" />
                        <input type="reset" name="res-1" value="Limpiar" runat="server" class="btn btn-danger" />
                        <%--onserverclick="btnLimpiar_ServerClick"--%>
                    </p>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js"></script>
    <script>

        function SoloNumeroIntDouble(ev) {
            var tecla = (document.all) ? ev.keyCode : ev.which;
            if (tecla == 8 || tecla == 13 || tecla == 0) return true;
            if (tecla >= 8226 && tecla <= 10175) { return false; }
            var regEx = /^[0-9\.]+$/i;
            return regEx.test(String.fromCharCode(tecla));
        }
    </script>
    <!-- Alertas -->
    <script src="js/sweetalert.js">
    </script>
    <script>

        function alertaDuplicado() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'No puedes añadir el mismo ingrediente',
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
        function alertaError() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'No se ha podido completar la operación',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaExito() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha logrado actualizar correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "GestionarReceta";
                }
            })
        }
    </script>
</asp:Content>
