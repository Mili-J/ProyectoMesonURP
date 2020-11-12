<%@ Page Title="Gestionar Receta | Actualizar Receta" Language="C#" AutoEventWireup="true" CodeBehind="ActualizarReceta.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.ActualizarReceta" EnableEventValidation="false" %>

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
        <div class="infprincipal" style="display: flex;">
            <div class="infReceta" style="width: 50%;">
                <div class="form-grids widget-shadow" data-example-id="basic-forms" style="margin-top: 34px;">
                    <div class="form-title color-white">
                        <h4>Información del Plato</h4>
                    </div>
                </div>
                <div class="form-horizontal" runat="server">
                    <div class="form-group" style="width: 1889px; margin-top: 23px;">
                        <label for="focusedinput" class="col-sm-2 control-label">Nombre del plato</label>
                        <div class="col-sm-8">
                             <asp:TextBox ID="txtnombre" runat="server" Style="width: 25%;" CssClass="form-control1" onkeypress="return soloLetras(event);"/>
                            <asp:RequiredFieldValidator ID="rfvnombre" runat="server" ControlToValidate="txtnombre" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                            </div>
                    </div>
                    <div class="form-group" style="width: 1889px;">
                        <label for="focusedinput" class="col-sm-2 control-label">N° porciones</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtPorciones" runat="server" Style="width: 25%;" placeholder="Ingrese una cantidad" CssClass="form-control1" onkeypress="return SoloNumeroIntDouble(event);" MaxLength="5" />
                            <asp:RequiredFieldValidator ID="rfvporciones" runat="server" ControlToValidate="txtPorciones" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group" style="width: 1889px;">
                        <label for="selector1" class="col-sm-2 control-label">Categoría</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCategoriaReceta" runat="server" Style="width: 25%;" Enabled="true"
                                CssClass="form-control1" />
                        </div>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlCategoriaReceta" runat="server" Style="width: 25%;" CssClass="form-control1" OnSelectedIndexChanged="ddlCategoriaReceta_Change">
                                <asp:ListItem Text="" Value="">Seleccione una categoría</asp:ListItem>
                            </asp:DropDownList>
                            <asp:ImageButton style="margin-left: 233px;" ID="btnEditar" ImageUrl="img/editar.png" onmouseover="this.src='img/editar-b.png'" onmouseout="this.src='img/editar.png'" runat="server" OnClick="btnEditarCategoria_Click" Height="31px" />
                            <asp:RequiredFieldValidator ID="rfvcategoriaR" runat="server" ControlToValidate="ddlCategoriaReceta" ErrorMessage="Campo Obligatorio"  CssClass="required-item" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group" style="width: 1889px;">
                        <label for="focusedinput" class="col-sm-2 control-label">Descripción</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtDescripcion" runat="server" Style="width: 25%;" placeholder="Descripcion" CssClass="form-control1" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="imgDiv" style="width: 50%; margin-left: 50px">
                <div class="form-grids widget-shadow" data-example-id="basic-forms" style="margin-top: 34px;">
                    <div class="form-title color-white">
                        <h4>Imagen de Referencia</h4>
                    </div>
                </div>
                <div class="img-div">
                    <div class="form-group" style="display: flex; margin-top: 58px; justify-content: center;">
                        <asp:Image ID="ImagenPreview" Style="height: 56px;" ImageUrl="https://img.icons8.com/fluent/48/000000/image.png" runat="server" />
                        <br />
                        <br />
                        <label style="height: 45px; width: 257px" class="col-sm-2 control-label">Selecciona la imagen</label>
                        <asp:FileUpload Style="height:45px; z-index: 100;" ID="fuImagen" accept=".jpg" runat="server" CssClass="form-control1 " />
                        <br />
                        <%--         <p class="center-button">
                                <asp:Button ID="btnCargar" runat="server" Text="Cargar" class="btn btn-danger" /><%--OnClick="btnCargar_Click" ---%>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-horizontal" runat="server" style="background-color: #f5f6f7; border-radius: 1%; padding-bottom: 4px;">

            <div class="form-grids widget-shadow" data-example-id="basic-forms" style="margin-top: 34px;">
                <div class="form-title color-white">
                    <h4>Ingredientes</h4>
                </div>
            </div>
            <div style="display: flex;">
                <div id="ingredientes" style="width: 80vh;">

                    <div class="form-group" style="width: 1887px; margin-top: 30px;">
                        <label for="focusedinput" class="col-sm-2 control-label">Ingredientes</label>
                        <div class="col-sm-8">
                            <asp:DropDownList Style="width: 25%;" ID="ddlIngredientes" runat="server" CssClass="form-control1"
                                OnSelectedIndexChanged="ddlIngredientes_Change">
                                <asp:ListItem Text="" Value="">Seleccione una Ingrediente</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group" style="width: 1887px;">
                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCantidad" Style="width: 25%;" runat="server" CssClass="form-control1" onkeypress="return SoloNumeroIntDouble(event);" MaxLength="5"/>
                        </div>
                    </div>
                    <div class="form-group" style="width: 1887px;">
                        <label for="focusedinput" class="col-sm-2 control-label">Medida</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtMedidaFormato" Style="width: 25%;" runat="server" CssClass="form-control1" onkeypress="return soloLetras(event);" />
                        </div>
                    </div>
                    <p class="center-button">
                        <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ID="btnAñadirIngredientes" OnClick="btnAñadirIngredientes_Click" />
                        <asp:Button CssClass="btn btn-danger" runat="server" Text="Quitar" ID="btnQuitarIngredientes" OnClick="btnQuitarIngredientes_Click" />
                    </p>
                    </div>
                    <asp:UpdatePanel ID="PanelAñadir" runat="server">
                        <ContentTemplate>
                            <div class="panel panel-widget forms-panel" style="width: 60vh; margin-top: 27px;">
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
                                </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAñadirIngredientes" />
                            <asp:PostBackTrigger ControlID="btnGuardar" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                    <asp:Label ID="lblIndex" runat="server" Visible="false"></asp:Label>
                    <hr />
                    <p class="center-button"  style="margin-top: 49px; margin-bottom: 44px;">
                        <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnGuardar" onserverclick="btnGuardar_ServerClick">Guardar</button>
                        <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarReceta';" onserverclick="btnRegresar_ServerClick" class="btn btn-primary" />
                        <input type="reset" name="res-1" value="Limpiar" runat="server" class="btn btn-danger" />
                        <%--onserverclick="btnLimpiar_ServerClick"--%>
                    </p>
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
                text: 'La cantidad de ingredientes no es permitida',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
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
