<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarReceta.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.ActualizarReceta" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Actualizar Receta</h2>
            </div>
        </div>
        <div class="forms">
            <h3 class="title1"></h3>

                    <div class="row">
                        <div class="form-group">
                            <asp:Image ID="ImagenPreview" ImageUrl="https://img.icons8.com/fluent/48/000000/image.png" runat="server" />
                            <br />
                            <br />
                            <label class="col-sm-2 control-label">Selecciona la imagen</label>
                            <asp:FileUpload ID="fuImagen" accept=".jpg" runat="server" CssClass="form-control1 " />
                            <br />
                            <p class="center-button">
                                <asp:Button ID="btnCargar" runat="server" Text="Cargar" class="btn btn-danger" /><%--OnClick="btnCargar_Click" --%>
                            </p>
                        </div>
                    </div>
                            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                            <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">Nombre del plato</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtnombre" runat="server" CssClass="form-control1" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">N° porciones</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtPorciones" runat="server" placeholder="Seleccione la cantidad" CssClass="form-control1" onkeypress="return SoloNumeroIntDouble(event);" MaxLength="5" />
                                </div>
                            </div>
                            <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Categoría</label>
                                <div class="col-sm-8">
                             <asp:TextBox ID="txtCategoriaReceta" runat="server" Enabled ="true" 
                                 CssClass="form-control1"  />
                            </div> 
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlCategoriaReceta" runat="server" CssClass="form-control1" OnSelectedIndexChanged="ddlCategoriaReceta_Change">
                                <asp:ListItem Text="" Value="">Seleccione una categoría</asp:ListItem>
                            </asp:DropDownList>

                            <asp:ImageButton ID="btnEditar" ImageUrl="img/editar.png" onmouseover="this.src='img/editar-b.png'" onmouseout="this.src='img/editar.png'" runat="server" OnClick="btnEditarCategoria_Click" Height="31px" />
                                       
                        </div>
                    </div>
                            <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">Descripción</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Descripcion" CssClass="form-control1" />
                                </div>
                            </div>
                                    <div class="form-group">
                                        <label for="focusedinput" class="col-sm-2 control-label">Ingredientes</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="ddlIngredientes" runat="server" CssClass="form-control1"
                                         OnSelectedIndexChanged="ddlIngredientes_Change">
                                        <asp:ListItem Text="" Value="">Seleccione una Ingrediente</asp:ListItem>
                                    </asp:DropDownList>
                                     </div>
                            </div>
                                    <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control1" />
                                </div>
                            </div>
                                    <div class="form-group">
                                <label for="focusedinput" class="col-sm-2 control-label">Medida</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="txtMedidaFormato" runat="server" CssClass="form-control1" />
                                </div>
                            </div> 
                    <%--<asp:UpdatePanel ID="PanelAñadir" runat="server">
                      <ContentTemplate>--%>
                         <p class="center-button">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ID="btnAñadirIngredientes" OnClick="btnAñadirIngredientes_Click"/>
                            <asp:Button CssClass="btn btn-danger" runat="server" Text="Quitar" ID="btnQuitarIngredientes" OnClick="btnQuitarIngredientes_Click"/>
                        </p>
                     <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                          </div>
              <div class="panel panel-widget forms-panel">
                  <div class="form-grids widget-shadow" data-example-id="basic-forms">
                      <div class="form-title color-white">
                          <h4>Ingredientes</h4>
                    </div>
                      <div class="table-wrapper-scroll-y my-custom-scrollbar">
                          <asp:GridView ID="gvIngredientes" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="False" OnRowDataBound="gvIngredientes_OnRowDataBound"
                              DataKeyNames="I_nombreIngrediente, IR_cantidad, IR_formatoMedida"
                              CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" OnSelectedIndexChanged="gvIngredientes_SelectedIndexChanged">

                              <Columns>
                                  <asp:BoundField HeaderText="Nombre Ingrediente" DataField="I_nombreIngrediente" />
                                  <asp:BoundField HeaderText="Cantidad" DataField="IR_cantidad" />
                                  <asp:BoundField HeaderText="Medida" DataField="IR_formatoMedida" />

                              </Columns>
                              <SelectedRowStyle BackColor="LightGreen" />
                          </asp:GridView>
                      </div>
                      <asp:Label ID="lblIndex" runat="server" Visible="false"></asp:Label>
                      <hr />
                      <p class="center-button">
                          <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnGuardar" onserverclick="btnGuardar_ServerClick">Guardar</button>
                          <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarReceta';" onserverclick="btnRegresar_ServerClick" class="btn btn-primary" />
                          <input type="reset" name="res-1" value="Limpiar" runat="server"  class="btn btn-danger" /> <%--onserverclick="btnLimpiar_ServerClick"--%>
                      </p>
                  </div>
                      </div>
                       
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

            function alertaCantidad() {
                Swal.fire({
                    title: 'Oh, no!',
                    text: 'La cantidad de insumos no es permitida',
                    icon: 'error',
                    confirmButtonText: 'Aceptar'
                })
            }
            function alertaDuplicado() {
                Swal.fire({
                    title: 'Oh, no!',
                    text: 'No puedes añadir el mismo Insumo',
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
                    text: 'No has añadido ningún Insumo',
                    icon: 'error',
                    confirmButtonText: 'Aceptar'
                })
            }
            function alertaExito() {
                Swal.fire({
                    title: 'Enhorabuena!',
                    text: 'Se ha logrado egresar correctamente',
                    icon: 'success',
                    confirmButtonText: 'Aceptar'
                }).then((result) => {
                    if (result.value) {
                        window.location.href = "ManejarStock";
                    }
                })
            }
        </script>
</asp:Content>
