<%@ Page Title="Gestionar Receta | Registrar Receta" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistrarReceta.aspx.cs" Inherits="ProyectoMesonURP.RegistrarReceta" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%-- <style type="text/css">
        .rfv {
            float: left;
            color: #FFF;
            border-radius: 3px 4px 4px 3px;
            margin: -2px 0 0 20px;
            padding: 3px 10px;
            background-color: #CE5454;
            z-index: 1;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="pd-ltr-20 xs-pd-20-10">
            <div class="min-height-200px">
                <div class="page-header">
                    <div class="row">
                        <div class="col-md-12 col-sm-12">
                            <h4 class="tittle-margin5">Registrar Receta</h4>
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
                            <div class="row">
                                <%--<div class="row">--%>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Nombre del plato</label>
                                        <asp:TextBox ID="txtnombre" runat="server" class="form-control" onkeypress="return soloLetras(event);" placeholder="Ingrese un nombre"/>
                                        <asp:RequiredFieldValidator ID="rfvnombre" runat="server" ControlToValidate="txtnombre" ErrorMessage="Campo Obligatorio" Display="Static" ForeColor="DarkRed" ValidationGroup="receta1"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>N° porciones</label>
                                        <asp:TextBox ID="txtPorciones" runat="server" class="form-control" TextMode="Number" TexT="1" ReadOnly="true"  onkeypress="return SoloNumeroInt(event);" MaxLength="3"/>
                                    </div>
                                </div>
                                <%--  </div>--%>
                                <%-- <div class="row">--%>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Categoría</label>
                                        <asp:DropDownList ID="ddlCategoriaReceta" runat="server" class="custom-select2 form-control" required="required">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvcategoriaR" runat="server" ControlToValidate="ddlCategoriaReceta" Display="Static" ForeColor="DarkRed" InitialValue="--seleccionar--" ValidationGroup="receta1"><span id="sampleRFV">Seleccione una opción</span></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Sub categoría</label>
                                        <asp:DropDownList ID="ddlSubCategoriaReceta" runat="server" class="custom-select2 form-control" required="required" >
                                            <asp:ListItem Value="0">--seleccionar sub-categoría--</asp:ListItem>
                                            <asp:ListItem Value="Entradas">Entradas</asp:ListItem>
                                            <asp:ListItem Value="Platos de fondo">Platos de fondo</asp:ListItem>
                                            <asp:ListItem Value="Sopas">Bebidas</asp:ListItem>
                                            <asp:ListItem Value="Postres">Postres</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvsubCategoriaR" runat="server" ControlToValidate="ddlSubCategoriaReceta" Display="Static" ForeColor="DarkRed" InitialValue="0" ValidationGroup="receta1"><span id="subcatRFV">Seleccione una opción</span></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <%-- </div>--%>
                                <%--<div class="row">--%>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Descripción</label>
                                        <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Descripcion" TextMode="MultiLine" class="form-control" onkeypress="return soloLetras(event);" />
                                    </div>
                                </div>
                                <%-- </div>--%>
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
                                                <asp:DropDownList ID="ddlIngredientes" runat="server" class="custom-select2 form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlIngredientes_SelectionChange">
                                                    <asp:ListItem Text="" Value="">--seleccionar--</asp:ListItem>
                                                </asp:DropDownList>
                                               <asp:RequiredFieldValidator ID="rfvddlIngrediente" runat="server" ControlToValidate="ddlIngredientes" Display="Static" ForeColor="DarkRed" InitialValue="--seleccionar--" ValidationGroup="receta2"><span id="IngredRFV">Seleccione una opción</span></asp:RequiredFieldValidator>
                                            </div>
                                         </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="form-group pt-3 pl-5">
                                    <label>Cantidad</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtCantidad" runat="server" class="form-control" TextMode="Number" onkeypress="return SoloNumeroIntDouble(event);" min="1" MaxLength="5" />
                                         <asp:RequiredFieldValidator ID="rfvtxtCantidad" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Campo Obligatorio" Display="Static" ForeColor="DarkRed" ValidationGroup="receta2"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group pt-3 pl-5">
                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                         <ContentTemplate>
                                            <label>Medida</label>
                                            <div class="col-sm-6">
                                                <asp:DropDownList ID="ddlMedida" runat="server" class="custom-select2 form-control">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlMedida" runat="server" ControlToValidate="ddlMedida" Display="Static" ForeColor="DarkRed" InitialValue="--seleccionar--" ValidationGroup="receta2"><span id="MedidaRFV">Seleccione una opción</span></asp:RequiredFieldValidator>
                                            </div>
                                         </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <asp:UpdatePanel ID="UpdateButton" runat="server">
                                    <ContentTemplate>
                                    <p class="center-button">
                                        <asp:Button CssClass="btn btn-outline-success" runat="server" Text="Añadir" ID="btnAñadirIngredientes" OnClick="btnAñadirIngredientes_Click" UseSubmitBehavior="false" ValidationGroup="receta2"/>
                                        <asp:LinkButton runat="server" OnClick="btnQuitarIngrediente_Click" class="btn btn-outline-danger"><i class="fa fa-times-circle-o"></i>&nbsp;Quitar</asp:LinkButton>
                                    </p>
                                     </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                
                            <div class="col-md-6 col-sm-12 mb-30">
                                <asp:UpdatePanel ID="PanelAñadir" runat="server">
                                    <ContentTemplate>
                                        <div class="panel panel-widget forms-panel" style="width: 60vh; margin-top: 27px;">
                                            <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                                <asp:GridView ID="gvIngredientes" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="False" OnRowDataBound="gvIngredientes_OnRowDataBound"
                                                    DataKeyNames="Nombre Ingrediente,Medida"
                                                    CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" OnSelectedIndexChanged="gvIngredientes_SelectedIndexChanged">
                                                   
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Nombre Ingrediente" DataField="Nombre Ingrediente" />
                                                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                                                        <asp:BoundField HeaderText="Medida" DataField="Medida" />

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
                        </div>
            <asp:Label ID="lblIndex" runat="server" Visible="false"></asp:Label>
</div>
                </div>
            <hr />
                    <p class="center-button" style="margin-top: 49px; margin-bottom: 44px;">
                        <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnGuardar" onserverclick="btnGuardar_ServerClick" ValidationGroup="receta1">Guardar</button>
                        <input type="button" name="sub-1" value="Regresar" runat="server" onserverclick="btnRegresar_ServerClick" class="btn btn-primary" />
                        <input type="reset" name="res-1" value="Limpiar" runat="server" onserverclick="btnLimpiar_ServerClick" class="btn btn-danger" />
                    </p>
                
            </div>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js"></script>
    <script>
        //function ValidateSelection() {
        //    var valor = document.getElementById("txtnombre").value;
        //    var porciones = document.getElementById("txtPorciones").value;

        //   // alert(gettext);

        //    if (valor == null || valor.length == 0 || porciones == null || porciones.length == 0) {

        //        return false;
        //     }

        //}

       <%-- function GetMaster1Details() {
            var value = document.getElementById("<%=ddlCategoriaReceta.ClientID%>");
            var getvalue = value.options[value.selectedIndex].value;
            var gettext = value.options[value.selectedIndex].text;

            var valor = $('#<%=txtnombre.ClientID %>');
            var porciones = $('#<%=txtPorciones.ClientID %>');

            if (gettext == "--seleccionar--") {
                alert("seleccione una categoria")
                return false;
            }
            else if (valor == null || valor.length == 0 || porciones == null || porciones.length == 0) {

                return false;
            }

            else {
                vat = true;
            }
            return vat;
        }--%>

        function SoloNumeroIntDouble(ev) {
            var tecla = (document.all) ? ev.keyCode : ev.which;
            if (tecla == 8 || tecla == 13 || tecla == 0) return true;
            if (tecla >= 8226 && tecla <= 10175) { return false; }
            var regEx = /^[0-9\.]+$/i;
            return regEx.test(String.fromCharCode(tecla));
        }

        function SoloNumeroInt(ev) {
            var tecla = (document.all) ? ev.keyCode : ev.which;
            if (tecla == 8 || tecla == 13 || tecla == 0) return true;
            if (tecla >= 8226 && tecla <= 10175) { return false; }
            var regEx = /^[0-9]+$/i;
            return regEx.test(String.fromCharCode(tecla));
        }

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
    </script>
    <!-- Alertas -->
    <script src="js/sweetalert.js">
    </script>
    <script>

        function alertaDuplicado() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'No puedes añadir la misma receta',
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
                text: 'No se ha podido registrar',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaExito() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha logrado registrar correctamente',
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
