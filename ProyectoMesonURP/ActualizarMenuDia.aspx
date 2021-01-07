<%@ Page Title="Planificar Menú | Actualizar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarMenuDia.aspx.cs" Inherits="ProyectoMesonURP.ActualizarMenuDia" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-control {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <div class="page-header">
            <div class="row">
                <div class="col-md-6 col-sm-12">
                    <div class="title">
                        <h4>Planificación del Día</h4>
                    </div>                   
                </div>
            </div>
        </div>
        <div class="pd-20 card-box">
            <div class="row pl-5 p-4">
                <div class="col-md-2 pt-1">
                    <label>Fecha de planificación:</label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtFecha" runat="server" class="form-control" ReadOnly="true" />
                </div>
            </div>
            <div class="row clearfix pt-30">
            <div class="col-md-6 col-sm-12 mb-30">
                <div class="panel panel-widget forms-panel">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h5>Menú del día</h5>
                        </div>
                        <div class="pd-20 card-box height-100-p">
                            <div class="row">
                                <div class="col-md-4">
                                    <label>N° total de raciones: </label>
                                </div>
                                <div class="col-md-2 pl-3">
                                    <asp:TextBox ID="txtNumRacMenu" runat="server" class="form-control" TextMode="Number" />
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="product-wrap">
                                        <div class="product-list">
                                            <ul class="row">
                                                <asp:Repeater ID="repeaterMenu" runat="server" OnItemCommand="repeaterMenu_ItemCommand">
                                                    <ItemTemplate>
                                                        <li class="col-lg-6 col-md-2 col-sm-12">
                                                            <div class="product-box">
                                                                <div class="producct-img">
                                                                    <img class="card-img-top" alt="Imagen de Referencia" src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                                                </div>
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
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>Raciones: </label>
                                                                        </div>
                                                                        <div class="col-md-5 pl-4">
                                                                            <asp:TextBox ID="txtNumRaciones" runat="server" class="form-control" TextMode="Number" Text='<%#Eval("MXR_numeroPorcion") %>'/>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-12 col-sm-12 pt-2 text-right">
                                                                        <asp:LinkButton ID="btnQuitarMenu" runat="server" CommandName="QuitarMenu" class="btn btn-outline-danger"><i class="fa fa-times-circle-o"></i>&nbsp;Quitar</asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>

            <%-- Carta--------------------------------------------------- --%>

            <div class="col-md-6 col-sm-12 mb-30">
                <div class="panel panel-widget forms-panel">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h5>Platos seleccionados a la Carta</h5>
                        </div>
                        <div class="pd-20 card-box height-100-p">
                            <div class="row">
                                <div class="col-md-4">
                                    <label>N° total de raciones: </label>
                                </div>
                                <div class="col-md-2 pl-3">
                                    <asp:TextBox ID="txtNumRacCarta" runat="server" class="form-control" TextMode="Number"/>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div class="product-wrap">
                                        <div class="product-list">
                                            <ul class="row">
                                                <asp:Repeater ID="repeaterCartaSeleccionada" runat="server" OnItemCommand="repeaterCartaSeleccionada_ItemCommand">
                                                    <ItemTemplate>
                                                        <li class="col-lg-6 col-md-2 col-sm-12">
                                                            <div class="product-box">
                                                                <div class="producct-img">
                                                                    <img class="card-img-top" alt="Imagen de Referencia" src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                                                </div>
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
                                                                    <div class="row">
                                                                        <div class="col-md-3">
                                                                            <label>Raciones: </label>
                                                                        </div>
                                                                        <div class="col-md-5 pl-4">
                                                                            <asp:TextBox ID="txtNumRaciones" runat="server" class="form-control" TextMode="Number" Text='<%#DataBinder.Eval(Container.DataItem, "MXR_numeroPorcion")%>'/>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-12 col-sm-12 pt-2 text-right">
                                                                        <%--<asp:Button ID="btnQuitarCarta"  class="btn btn-outline-danger" runat="server" Text="Quitar" CommandName="QuitarCarta" />--%>
                                                                        <asp:LinkButton ID="btnQuitarCarta" runat="server" CommandName="QuitarCarta" class="btn btn-outline-danger"><i class="fa fa-times-circle-o"></i>&nbsp;Quitar</asp:LinkButton>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            <!-- container -->
            <div class="tab">
                <ul class="nav nav-tabs" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active text-blue" data-toggle="tab" href="#tabEnt" role="tab" aria-selected="true">Entradas</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link text-blue" data-toggle="tab" href="#tabSegundosM" role="tab" aria-selected="false">Platos de Fondo</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link text-blue" data-toggle="tab" href="#tabBebidas" role="tab" aria-selected="false">Bebidas</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link text-blue" data-toggle="tab" href="#tabPlat" role="tab" aria-selected="false">Platos a la Carta</a>
                    </li>
                </ul>
                <div class="tab-content pt-3">
                    <div class="tab-pane fade show active" id="tabEnt" role="tabpanel">
                        <div class="product-wrap">
                            <div class="product-list">
                                <ul class="row">
                                    <asp:Repeater ID="reapeterEntradas" runat="server" OnItemCommand="reapeterEntradas_ItemCommand">
                                        <ItemTemplate>
                                            <li class="col-lg-3 col-md-2 col-sm-12">
                                                <div class="product-box">
                                                    <div class="producct-img">
                                                        <img class="card-img-top" alt="Imagen de Referencia" src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                                    </div>
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
                                                        <asp:UpdatePanel ID="UpdateButton" runat="server">
                                                            <ContentTemplate>
                                                                <div>
                                                                    <asp:Button ID="btnVerEntrada" CssClass="btn btn-primary" runat="server" Text="Ver Receta" CommandName="VerEntrada" />
                                                                    <%--  <asp:Button ID="btnAgregarEntrada" class="btn btn-outline-success" runat="server" Text="Agregar" CommandName="AgregarEntrada" />--%>
                                                                    <asp:LinkButton ID="btnAgregarEntrada" runat="server" CommandName="AgregarEntrada" class="btn btn-outline-success"><i class="fa fa-check-circle-o"></i>&nbsp;Agregar</asp:LinkButton>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="tabSegundosM" role="tabpanel">
                        <div class="product-wrap">
                            <div class="product-list">
                                <ul class="row">
                                    <asp:Repeater ID="repeaterFondo" runat="server" OnItemCommand="repeaterFondo_ItemCommand">
                                        <ItemTemplate>
                                            <li class="col-lg-3 col-md-2 col-sm-12">
                                                <div class="product-box">
                                                    <div class="producct-img">
                                                        <img class="card-img-top" alt="Imagen de Referencia" src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                                    </div>
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
                                                        <asp:UpdatePanel ID="UpdateButton" runat="server">
                                                            <ContentTemplate>
                                                                <div>
                                                                    <asp:Button ID="btnVerFondo" CssClass="btn btn-primary" runat="server" Text="Ver Receta" CommandName="VerFondo" />
                                                                    <asp:LinkButton ID="btnAgregarFondo" runat="server" CommandName="AgregarFondo" class="btn btn-outline-success"><i class="fa fa-check-circle-o"></i>&nbsp;Agregar</asp:LinkButton>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="tabBebidas" role="tabpanel">
                        <div class="product-wrap">
                            <div class="product-list">
                                <ul class="row">
                                    <asp:Repeater ID="repeaterBebida" runat="server" OnItemCommand="repeaterBebida_ItemCommand">
                                        <ItemTemplate>
                                            <li class="col-lg-3 col-md-2 col-sm-12">
                                                <div class="product-box">
                                                    <div class="producct-img">
                                                        <img class="card-img-top" alt="Imagen de Referencia" src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                                    </div>
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
                                                        <asp:UpdatePanel ID="UpdateButton" runat="server">
                                                            <ContentTemplate>
                                                                <div>
                                                                    <asp:Button ID="btnVerBebida" CssClass="btn btn-primary" runat="server" Text="Ver Receta" CommandName="VerBebida" />
                                                                    <asp:LinkButton ID="btnAgregarBebida" runat="server" CommandName="AgregarBebida" class="btn btn-outline-success"><i class="fa fa-check-circle-o"></i>&nbsp;Agregar</asp:LinkButton>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane fade" id="tabPlat" role="tabpanel">
                        <div class="product-wrap">
                            <div class="product-list">
                                <ul class="row">
                                    <asp:Repeater ID="repeaterCarta" runat="server" OnItemCommand="repeaterCarta_ItemCommand">
                                        <ItemTemplate>
                                            <li class="col-lg-3 col-md-2 col-sm-12">
                                                <div class="product-box">
                                                    <div class="producct-img">
                                                        <img class="card-img-top" alt="Imagen de Referencia" src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                                    </div>
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
                                                        <asp:UpdatePanel ID="UpdateButton" runat="server">
                                                            <ContentTemplate>
                                                                <div>
                                                                    <asp:Button ID="btnVerCarta" CssClass="btn btn-primary" runat="server" Text="Ver Receta" CommandName="VerCarta" />
                                                                    <asp:LinkButton ID="btnAgregarCarta" runat="server" CommandName="AgregarCarta" class="btn btn-outline-success"><i class="fa fa-check-circle-o"></i>&nbsp;Agregar</asp:LinkButton>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end container -->
        </div>
        
        <%-- --------------------------------------------------- --%>
        <p class="center-button" style="margin-top: 49px; margin-bottom: 44px;">
            <asp:Button ID="btnAceptar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnAceptar_Click" />
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
        function alertaEntradas() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'La cantidad de Entradas permitidas son 2.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaSegundos() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'La cantidad de Segundos permitidos son 3.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaBebidas() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'La cantidad de Bebidas permitidas es 1.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaEntradasMax() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'La cantidad de Entradas es mayor al número de raciones.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaSegundosMax() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'La cantidad de Segundos es mayor al número de raciones.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaBebidasMax() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'La cantidad de Bebidas es mayor al número de raciones.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaEmpty() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'El campo se encuentra vacío.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaCero() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'El valor debe ser mayor a cero.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaSimbolo() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Revise nuevamente el número de raciones.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaExito() {
            Swal.fire({
                title: 'Actualizado',
                text: 'El menú ha sido actualizado satisfactoriamente.',
                icon: 'success',
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
