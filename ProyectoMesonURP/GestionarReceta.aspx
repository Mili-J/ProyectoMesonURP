<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarReceta.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.GestionarReceta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="women_main">
        <!-- start content --><div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Gestionar Receta</h2>
            </div>
            <div class="page-options" style="display: flex;justify-content: space-between;">               
                <div class="search-buttons" style="width: 100%;">
                    <div class="search" >
                        <asp:TextBox ID="txtBuscarReceta" runat="server" AutoPostBack="True" CssClass="form-control1" OnTextChanged="fNombreReceta_TextChanged" onkeypress="return soloLetras(event);" placeholder="Buscar Receta ..." />           
                    </div>
                </div>
                <div class="stock-options">
                         <div class="width-auto margin-5">
                            <button type="button" class="btn btn-primary btn-flex" style="display: flex; margin-left: 6px;"
                                OnClick="btnRegistrarReceta_Click">     
                                <span class="material-icons margin-5" style="margin-right: 6px;">add_circle_outline</span>
                                <h>Registrar Receta</h>
                            </button>
                        </div>
                </div>
            </div>
                
            <!-- SECTION -->
            <div class="section">
                <!-- container -->
                <div class="navtabs-receta">
                    <ul class="nav nav-tabs">
                        <li class="nav-item">
                            <a class="nav-link active" href="container-all">Todos</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Platos de Fondo</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Entradas</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Sopas</a>
                        </li>
                    </ul>
                </div>
                <div id="container-all" style="display: flex;justify-content: space-between;margin-top: 30px;">
                        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" OnItemCreated="Repeater1_ItemCreated" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <div class="card" style="width: 18rem">
                                    <img class="card-img-top" alt="Imagen de Referencia" 
                                        src="data:image/png;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                    
                                        
                                    
                                    <div class="card-body">
                                            <asp:Label ID="lblIdReceta" runat="server"  Text='<%#DataBinder.Eval(Container.DataItem,"R_idReceta") %>'></asp:Label>

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
                                            <asp:Button ID="btnActualizarReceta" CssClass="btn btn-primary" runat="server" Text="Actualizar" CommandName="ActualizarReceta" />
                                            <asp:Button ID="btnEliminarReceta" CssClass="btn btn-primary" runat="server" Text="Eliminar" CommandName="EliminarReceta" />

                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                </div>
            </div>
            <div class="clearfix"></div>
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
