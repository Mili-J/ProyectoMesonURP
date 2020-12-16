<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarMenuDia.aspx.cs" Inherits="ProyectoMesonURP.ActualizarMenuDia" %>
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
        <%-- -------------------------------------------------------- --%>
<%--    <div class="grids">
        <div class="progressbar-heading grids-heading title-flex">
            <h2 class="tittle-margin5">Seleccionar los Platos del día</h2>
        </div>
    </div>--%>

        <%-- ------------------------------------------------------- --%>
        <div class="panel panel-widget forms-panel">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h4>Platos seleccionados a la Carta</h4>
                </div>



        <div class="form-group">
            <div class="col-sm-8">
                <label for="focusedinput" class="col-sm-2 control-label">N° total de raciones</label>
                <asp:TextBox ID="txtNumRacCarta" runat="server" placeholder="Ingrese el número de raciones" CssClass="form-control1" TextMode="Number" />
<%--                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Número inválido" ControlToValidate="txtNumRaciones" ForeColor="#CC0000" SetFocusOnError="True" Display="Dynamic" ValidationGroup="SeleccionarMenu" ValidationExpression="[^0\-]\d{0,}"></asp:RegularExpressionValidator>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumRacCarta" ErrorMessage="Campo Obligatorio" ValidationGroup="SeleccionarMenu" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>
        </div>



                <div id="container-all" style="display: flex; margin-top: 30px; flex-wrap: wrap;">
                    <asp:Repeater ID="repeaterCartaSeleccionada" runat="server" OnItemCommand="repeaterCartaSeleccionada_ItemCommand">
                        <ItemTemplate>
                            <div class="card" style="width: 18rem">
                                <img class="card-img-top" alt="Imagen de Referencia"
                                    src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                <div class="card-body">
                                    <asp:Label ID="lblIdReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_idReceta") %>' Visible="false"></asp:Label>
                                    <h5 class="card-title">
                                        <asp:Label ID="lblNombreReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_nombreReceta") %>'></asp:Label>
                                    </h5>
                                    <p class="card-text">
                                        Porción:
                                                        <asp:Label ID="lblPorciones" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_numeroPorcion") %>'></asp:Label>
                                    </p>
                                    <p class="card-text">
                                        Categoría: 
                                                         <asp:Label ID="lblCategoria" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CP_nombreCategoriaR") %>' />
                                    </p>
                                    <p class="card-text">
                                        Categoría de Receta: 
                                                         <asp:Label ID="lblCatRec" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_subcategoria") %>' />
                                    </p>
                                    <p class="card-text">
                                        Raciones: 
                                                         <asp:TextBox ID="txtNumRaciones" runat="server" placeholder="Ingrese el número de raciones" CssClass="form-control1" TextMode="Number" Text='<%#DataBinder.Eval(Container.DataItem,"MXR_numeroPorcion") %>' />
                                    </p>
                                    <div>
                                        <asp:Button ID="btnQuitarCarta" CssClass="btn btn-primary" runat="server" Text="Quitar" CommandName="QuitarCarta" />
                                       

                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <%-- ------------------------------------------------------- --%>
        <div class="panel panel-widget forms-panel">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h4>Menú del día</h4>
                </div>

        <div class="form-group">
            <div class="col-sm-8">
                <label for="focusedinput" class="col-sm-2 control-label">N° total de raciones</label>
                <asp:TextBox ID="txtNumRacMenu" runat="server" placeholder="Ingrese el número de raciones" CssClass="form-control1" TextMode="Number" />
<%--                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Número inválido" ControlToValidate="txtNumRaciones" ForeColor="#CC0000" SetFocusOnError="True" Display="Dynamic" ValidationGroup="SeleccionarMenu" ValidationExpression="[^0\-]\d{0,}"></asp:RegularExpressionValidator>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNumRacMenu" ErrorMessage="Campo Obligatorio" ValidationGroup="SeleccionarMenu" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>
        </div>

                <div id="container-all" style="display: flex; margin-top: 30px; flex-wrap: wrap;">
                    <asp:Repeater ID="repeaterMenu" runat="server" OnItemCommand="repeaterMenu_ItemCommand">
                        <ItemTemplate>
                            <div class="card" style="width: 18rem">
                                <img class="card-img-top" alt="Imagen de Referencia"
                                    src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                <div class="card-body">
                                    <asp:Label ID="lblIdReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_idReceta") %>' Visible="false"></asp:Label>
                                    <h5 class="card-title">
                                        <asp:Label ID="lblNombreReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_nombreReceta") %>'></asp:Label>
                                    </h5>
                                    <p class="card-text">
                                        Porción:
                                                        <asp:Label ID="lblPorciones" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_numeroPorcion") %>'></asp:Label>
                                    </p>
                                    <p class="card-text">
                                        Categoría: 
                                                         <asp:Label ID="lblCategoria" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CP_nombreCategoriaR") %>' />
                                    </p>
                                    <p class="card-text">
                                        Categoría de Receta: 
                                                         <asp:Label ID="lblCatRec" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_subcategoria") %>' />
                                    </p>
                                    <p class="card-text">
                                        Raciones: 
                                                         <asp:TextBox ID="txtNumRaciones" runat="server" placeholder="Ingrese el número de raciones" CssClass="form-control1" TextMode="Number" Text='<%#DataBinder.Eval(Container.DataItem,"MXR_numeroPorcion") %>'/>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNumRaciones" ErrorMessage="Campo Obligatorio" ValidationGroup="SeleccionarMenu" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </p>
                                    <div>
                                        <asp:Button ID="btnQuitarMenu" CssClass="btn btn-primary" runat="server" Text="Quitar" CommandName="QuitarMenu" />
                                       

                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <%-- ------------------------------------------------------- --%
        <%-- Carta--------------------------------------------------- --%>
        <div class="panel panel-widget forms-panel">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h4>A la Carta</h4>
                </div>
                <div id="container-all" style="display: flex; margin-top: 30px; flex-wrap: wrap;">
                    <asp:Repeater ID="repeaterCarta" runat="server" OnItemCommand="repeaterCarta_ItemCommand">
                        <ItemTemplate>
                            <div class="card" style="width: 18rem">
                                <img class="card-img-top" alt="Imagen de Referencia"
                                    src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                <div class="card-body">
                                    <asp:Label ID="lblIdReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_idReceta") %>' Visible="false"></asp:Label>
                                    <h5 class="card-title">
                                        <asp:Label ID="lblNombreReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_nombreReceta") %>'></asp:Label>
                                    </h5>
                                    <p class="card-text">
                                        Porción:
                                                        <asp:Label ID="lblPorciones" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_numeroPorcion") %>'></asp:Label>
                                    </p>
                                    <p class="card-text">
                                        Categoría: 
                                                         <asp:Label ID="lblCategoria" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CP_nombreCategoriaR") %>' />
                                    </p>

                                    <div>
                                        <asp:Button ID="btnVerCarta" CssClass="btn btn-primary" runat="server" Text="Ver Receta" CommandName="VerCarta" />
                                        <asp:Button ID="btnAgregarCarta" CssClass="btn btn-primary" runat="server" Text="Agregar" CommandName="AgregarCarta" />

                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

        <%-- --------------------------------------------------- --%>
>
        <div class="panel panel-widget forms-panel">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h4>Entradas</h4>
                </div>
                <div id="container-all" style="display: flex; margin-top: 30px; flex-wrap: wrap;">
                    <asp:Repeater ID="reapeterEntradas" runat="server" OnItemCommand="reapeterEntradas_ItemCommand">
                        <ItemTemplate>
                            <div class="card" style="width: 18rem">
                                <img class="card-img-top" alt="Imagen de Referencia"
                                    src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                <div class="card-body">
                                    <asp:Label ID="lblIdReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_idReceta") %>' Visible="false"></asp:Label>
                                    <h5 class="card-title">
                                        <asp:Label ID="lblNombreReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_nombreReceta") %>'></asp:Label>
                                    </h5>
                                    <p class="card-text">
                                        Porción:
                                                        <asp:Label ID="lblPorciones" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_numeroPorcion") %>'></asp:Label>
                                    </p>
                                    <p class="card-text">
                                        Categoría: 
                                                         <asp:Label ID="lblCategoria" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CP_nombreCategoriaR") %>' />
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
                <div id="container-all" style="display: flex; margin-top: 30px; flex-wrap: wrap;">
                    <asp:Repeater ID="repeaterFondo" runat="server" OnItemCommand="repeaterFondo_ItemCommand">
                        <ItemTemplate>
                            <div class="card" style="width: 18rem">
                                <img class="card-img-top" alt="Imagen de Referencia"
                                    src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                <div class="card-body">
                                    <asp:Label ID="lblIdReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_idReceta") %>' Visible="false"></asp:Label>
                                    <h5 class="card-title">
                                        <asp:Label ID="lblNombreReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_nombreReceta") %>'></asp:Label>
                                    </h5>
                                    <p class="card-text">
                                        Porción:
                                                        <asp:Label ID="lblPorciones" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_numeroPorcion") %>'></asp:Label>
                                    </p>
                                    <p class="card-text">
                                        Categoría: 
                                                         <asp:Label ID="lblCategoria" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CP_nombreCategoriaR") %>' />
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
                    <h4>Bebidas</h4>
                </div>
                <div id="container-all" style="display: flex; margin-top: 30px; flex-wrap: wrap;">
                    <asp:Repeater ID="repeaterBebida" runat="server" OnItemCommand="repeaterBebida_ItemCommand">
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
                                                         <asp:Label ID="lblCategoria" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CP_nombreCategoriaR") %>' />
                                    </p>
                                    <div>
                                        <asp:Button ID="btnVerBebida" CssClass="btn btn-primary" runat="server" Text="Ver Receta" CommandName="VerBebida" />
                                        <asp:Button ID="btnAgregarBebida" CssClass="btn btn-primary" runat="server" Text="Agregar" CommandName="AgregarBebida" />

                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <%-- --------------------------------------------------- --%>


        <%-- --------------------------------------------------- --%>
             <p class="center-button"  style="margin-top: 49px; margin-bottom: 44px;">
                <asp:Button ID="btnAceptar" CssClass="btn btn-primary" runat="server" Text="Aceptar" OnClick="btnAceptar_Click"  ValidationGroup="SeleccionarMenu"/>
                <asp:Button ID="btnRegresar" CssClass="btn btn-danger" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
            </p>
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
        function alertaSeleccionado() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Ya alcanzó el número de recetas posible',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaPorcion() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Las porciones no coinciden',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaBebidayEntrada() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'La suma de las bebidas no coincide con la suma de las entradas',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaExito() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha logrado actualizar el menú correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "CalendariaMenu.aspx";
                }
            })
        }



    </script>
</asp:Content>
