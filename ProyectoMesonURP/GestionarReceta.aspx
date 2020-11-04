<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarReceta.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.GestionarReceta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Gestionar Receta</h2>
            </div>

            <div class="search-buttons">
                <div class="search">
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
                    <%--<ContentTemplate>--%>
                    <asp:TextBox ID="txtBuscarReceta" runat="server" AutoPostBack="True" CssClass="form-control1" OnTextChanged="fNombreReceta_TextChanged" onkeypress="return soloLetras(event);" placeholder="Buscar Receta ..." />
                    </asp:TextBox>              
                </div>
            </div>
            <!-- SECTION -->
            <div class="section">
                <!-- container -->
                <div class="container">
                    <!-- row -->
                    <div class="row">
                        <!-- ASIDE -->
                        <div id="aside" class="col-md-3">
                            <!-- aside Widget -->
                            <div class="aside">
                                <h3 class="aside-title">CATEGORIAS</h3>
                                <div class="checkbox-filter">
                                    <div>
                                        <asp:RadioButtonList ID="rbCategorias" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbCategorias_SelectedIndexChanged">
                                            <asp:ListItem Selected="True">Todos</asp:ListItem>
                                            <asp:ListItem>Platos</asp:ListItem>

                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>
                            <!-- /aside Widget -->

                            <!-- /aside Widget -->
                        </div>
                        <!-- /ASIDE -->

                        <!-- STORE -->
                        <div id="store" class="col-md-9">
                            <!-- store top filter -->

                            <!-- /store top filter -->

                            <!-- store products -->

                            <div class="row">
                                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemCreated="Repeater1_ItemCreated" OnItemDataBound="Repeater1_ItemDataBound">
                                    <ItemTemplate>
                                        <!-- product -->
                                        <div class="col-md-4 col-xs-6">
                                            <div class="product">
                                                <div class="product-img">
                                                    <img src="data:image/png;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>" alt="" class="sg-img">
                                                </div>
                                                <%--<div class="product-body">--%>

                                                    <%--<asp:Label ID="lblNombre" CssClass="product-category" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_nombreReceta") %>'></asp:Label>--%>
                                                    <h3 class="product-name">
                                                        <asp:Label ID="lblNombreReceta" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_nombreReceta") %>'></asp:Label></h3>
                                                    <h4 class="product-price">
                                                        <asp:Label ID="lblPorciones" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_numeroPorcion") %>'></asp:Label></h4>
                                                    <p class="product-category">
                                                        <asp:Label ID="lblCategoria" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CR_nombreCategoria") %>' />
                                                    </p>
                                                    <div class="product-rating">
                                                        <i class="fa fa-star"></i>
                                                        <i class="fa fa-star"></i>
                                                        <i class="fa fa-star"></i>
                                                        <i class="fa fa-star"></i>
                                                        <i class="fa fa-star"></i>
                                                    </div>
                                                    <div class="product-btns">
                                                        <%--													<button class="add-to-wishlist"><i class="fa fa-heart-o"></i><span class="tooltipp">add to wishlist</span></button>
													<button class="add-to-compare"><i class="fa fa-exchange"></i><span class="tooltipp">add to compare</span></button>--%>
                                                        <button class="quick-view"><i class="fa fa-eye"></i><span class="tooltipp">quick view</span></button>
                                                        <asp:Button ID="btnActualizarReceta" CssClass="btn btn-primary" runat="server" Text="Actualizar" CommandName="Actualizar Receta" />
                                                    </div>
                                                </div>

                                            </div>

                                        </div>
                                        <!-- /product -->
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <!-- /store products -->

                            <!-- store bottom filter -->

                            <!-- /store bottom filter -->
                        </div>
                        <!-- /STORE -->
                    </div>
                    <!-- /row -->
                </div>
                <!-- /container -->
            </div>

            <!-- /SECTION -->
            <%--</ContentTemplate>--%>
            <%--</asp:UpdatePanel>--%>

            <div class="clearfix"></div>

        </div>
    </div>
    <!-- jQuery Plugins -->
    <script src="js/GestionarReceta/jquery.min.js"></script>
    <script src="js/GestionarReceta/bootstrap.min.js"></script>
    <script src="js/GestionarReceta/slick.min.js"></script>
    <script src="js/GestionarReceta/nouislider.min.js"></script>
    <script src="js/GestionarReceta/jquery.zoom.min.js"></script>
    <script src="js/GestionarReceta/main.js"></script>
    <script>

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
        function alertaError() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Ingrese el nombre de la receta para la busqueda',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
    </script>
</asp:Content>
