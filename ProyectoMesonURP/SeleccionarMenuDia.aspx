<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SeleccionarMenuDia.aspx.cs" Inherits="ProyectoMesonURP.SeleccionarMenuDia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grids">
        <div class="progressbar-heading grids-heading title-flex">
            <h2 class="tittle-margin5">Seleccionar el Menú del día</h2>
        </div>
    </div>
    <div class="form-horizontal" runat="server">
        <div class="form-group">
            <div class="col-sm-8">
                <label for="focusedinput" class="col-sm-2 control-label">Fecha:</label>
                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control1" ReadOnly="true" />
            </div>
        </div>
        <div class="form-group">

            <div class="col-sm-8">
                <label for="focusedinput" class="col-sm-2 control-label">N° de raciones</label>
                <asp:TextBox ID="txtNumRaciones" runat="server" placeholder="Ingrese el número de raciones" CssClass="form-control1" TextMode="Number" />
            </div>
        </div>
        <%--    <div>
        <asp:Image ID="Image1" runat="server" />
        <asp:TextBox ID="txtid" runat="server"></asp:TextBox>
        <asp:Button ID="btnprueba" runat="server" Text="Aqui" OnClick="btnprueba_Click"/>
    </div>--%>
        <%-- ------------------------------------------------------- --%>
        <div class="panel panel-widget forms-panel">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h4>Entradas</h4>
                </div>
                <div id="container-all" style="display: flex; justify-content: space-between; margin-top: 30px;">
                    <asp:Repeater ID="reapeterEntradas" runat="server" OnItemCommand="reapeterEntradas_ItemCommand">
                        <ItemTemplate>
                            <div class="card" style="width: 18rem">
                                <img class="card-img-top" alt="Imagen de Referencia"
                                    src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                <div class="card-body">
                                    <asp:Label ID="lblIdReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_idReceta") %>'></asp:Label>
                                    <h5 class="card-title">
                                        <asp:Label ID="lblNombreReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_nombreReceta") %>'></asp:Label>
                                    </h5>
                                    <p class="card-text">
                                        Porción:
                                                        <asp:Label ID="lblPorciones" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_numeroPorcion") %>'></asp:Label>
                                    </p>
                                    <p class="card-text">
                                        Categoría: 
                                                         <asp:Label ID="lblCategoria" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CR_nombreCategoria") %>' />
                                    </p>
                                    <div>
                                        <asp:Button ID="btnVerEntrada" CssClass="btn btn-primary" runat="server" Text="Ver Receta" CommandName="VerEntrada" />
                                        <asp:Button ID="btnAgregarEntrada" CssClass="btn btn-primary" runat="server" Text="Agregar" CommandName="AgregarEntrada" />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <%-- --------------------------------------------------- --%>
        <div class="panel panel-widget forms-panel">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h4>Platos de Fondo</h4>
                </div>
                <div id="container-all" style="display: flex; justify-content: space-between; margin-top: 30px;">
                    <asp:Repeater ID="repeaterFondo" runat="server" OnItemCommand="repeaterFondo_ItemCommand">
                        <ItemTemplate>
                            <div class="card" style="width: 18rem">
                                <img class="card-img-top" alt="Imagen de Referencia"
                                    src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                <div class="card-body">
                                    <asp:Label ID="lblIdReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_idReceta") %>'></asp:Label>
                                    <h5 class="card-title">
                                        <asp:Label ID="lblNombreReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_nombreReceta") %>'></asp:Label>
                                    </h5>
                                    <p class="card-text">
                                        Porción:
                                                        <asp:Label ID="lblPorciones" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_numeroPorcion") %>'></asp:Label>
                                    </p>
                                    <p class="card-text">
                                        Categoría: 
                                                         <asp:Label ID="lblCategoria" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CR_nombreCategoria") %>' />
                                    </p>
                                    <div>
                                        <asp:Button ID="btnVerFondo" CssClass="btn btn-primary" runat="server" Text="Ver Receta" CommandName="VerFondo" />
                                        <asp:Button ID="btnAgregarFondo" CssClass="btn btn-primary" runat="server" Text="Agregar" CommandName="AgregarFondo" />

                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <%-- --------------------------------------------------- --%>
        <div class="panel panel-widget forms-panel">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h4>Menú del Día</h4>
                </div>
                <div id="container-all" style="display: flex; justify-content: space-between; margin-top: 30px;">
                    <div class="form-title color-white">
                        <h5>Entrada</h5>
                    </div>
                    <div class="card" style="width: 18rem">
                        <asp:Image ID="imgEntrada" runat="server" CssClass="card-img-top" AlternateText="Imagen de Referencia" />
                        <asp:Label ID="lblIdEntrada" runat="server" Text="Label" Visible="false"></asp:Label>
                        <asp:Label ID="lblNombreEntrada" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="lblPorcionEntrada" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="lblCatEntrada" runat="server" Text="Label"></asp:Label>
                        <asp:Button ID="btnQuitarEntrada" CssClass="btn btn-primary" runat="server" Text="Quitar" OnClick="btnQuitarEntrada_Click" />
                    </div>
                </div>
                <div id="container-all" style="display: flex; justify-content: space-between; margin-top: 30px;">
                    <div class="form-title color-white">
                        <h5>Plato de fondo</h5>
                    </div>
                    <div class="card" style="width: 18rem">
                        <asp:Image ID="imgFondo" runat="server" CssClass="card-img-top" AlternateText="Imagen de Referencia" />
                        <asp:Label ID="lblIdFondo" runat="server" Text="Label" Visible="false"></asp:Label>
                        <asp:Label ID="lblNombreFondo" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="lblPorcionFondo" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="lblCatFondo" runat="server" Text="Label"></asp:Label>
                        <asp:Button ID="btnQuitarFondo" CssClass="btn btn-primary" runat="server" Text="Quitar" OnClick="btnQuitarFondo_Click" />
                    </div>
                </div>
            </div>
        </div>
        <%-- --------------------------------------------------- --%>
        <div>
            <asp:Button ID="btnAceptar" CssClass="btn btn-primary" runat="server" Text="Agregar Menu" OnClick="btnAceptar_Click" />
        </div>
        <div>
            <asp:Button ID="btnRegresar" CssClass="btn btn-primary" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
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

        function alertaAceptado() {
            Swal.fire({
                title: 'Aceptado',
                text: 'La Orden de Compra ha cambiado de estado satisfactoriamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            })
        }

        function alertaRechazado() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Ya ha seleccionado una receta',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }

        function alertaRecibido() {
            Swal.fire({
                title: 'Recibido',
                text: 'Los insumos ya se encuentran en stock',
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
    </script>
</asp:Content>
