<%@ Page Title="Mesón URP | Gestionar Receta" Language="C#" AutoEventWireup="true" CodeBehind="GestionarReceta.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.GestionarReceta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="vendors/styles/core.css" rel="stylesheet" />
    <link href="vendors/styles/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <div class="page-header">
			<div class="row">
				<div class="col-md-6 col-sm-12">
					<div class="title">
						<h4>Gestionar Receta</h4>
					</div>
				</div>
			</div>
		</div>

        <div class="pd-20 card-box">
            <div class="row p-3">
                <div class="header-left pt-1">
			        <div class="search-toggle-icon dw dw-search2" data-toggle="header_search"></div>
			        <div class="header-search">
					    <div class="form-group mb-0">
						    <i class="dw dw-search2 search-icon"></i>
						    <asp:TextBox ID="txtBuscarReceta" runat="server" AutoPostBack="True" class="form-control search-input" OnTextChanged="fNombreReceta_TextChanged" onkeypress="return soloLetras(event);" placeholder="Buscar Receta..."/>
					    </div>
			        </div> 
		        </div>

                <div class="header-right pr-4">
                    <button type="button" class="btn btn-primary btn-flex" runat="server" style="display: flex; margin-left: 6px;" onserverclick="btnRegistrarReceta_Click">     
                        <span class="material-icons margin-5">add_circle_outline</span>
                        Registrar Receta
                    </button>
                </div>
            </div>
            <!-- container -->
            <div class="tab">
			    <ul class="nav nav-tabs" role="tablist">
				    <li class="nav-item">
					    <a class="nav-link active text-blue" data-toggle="tab" href="#tabTotal" role="tab" aria-selected="true">Todos</a>
				    </li>
				    <li class="nav-item">
					    <a class="nav-link text-blue" data-toggle="tab" href="#tabSegundosM" role="tab" aria-selected="false">Segundos de Menú</a>
				    </li>
				    <li class="nav-item">
					    <a class="nav-link text-blue" data-toggle="tab" href="#" role="tab" aria-selected="false">Contact</a>
				    </li>
			    </ul>
                <div class="tab-content pt-3">
                    <div class="tab-pane fade show active" id="tabTotal" role="tabpanel">
                            <div class="product-wrap">
                                <div class="product-list">
                                    <ul class="row">
                                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                    <ItemTemplate>
                                                        <li class="col-lg-3 col-md-2 col-sm-12">
                                                            <div class="product-box">
                                                                <div class="producct-img">
                                                            <img ID="ImagenReceta" class="card-img-top" alt="Imagen de Referencia" 
                                                                src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                                                </div>
                                                            <div class="card-body">
                                                                    <asp:Label ID="lblIdReceta" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"R_idReceta") %>'></asp:Label>

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
                                                                    Descripción:
                                                                    <asp:Label Visible="true" ID="lblDescripcion" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_descripcion") %>' />
                                                                </p>
                                                                <div>
                                                                    <asp:Button ID="btnActualizarReceta" class="btn btn-outline-warning" Text="Editar" runat="server" CommandName="ActualizarReceta" />
                                                                    <%-- <asp:Button ID="btnEliminarReceta" CssClass="btn btn-primary" runat="server" Text="Eliminar" CommandName="EliminarReceta" OnClientClick="return confirm('¿Estás seguro que queres borrar el registro ?');"/>--%>
                                           
                                                                </div>
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
                                        <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                            <ItemTemplate>
                                                    <li class="col-lg-3 col-md-2 col-sm-12">
                                                        <div class="product-box">
                                                            <div class="producct-img">
                                                                    <img ID="ImagenReceta" class="card-img-top" alt="Imagen de Referencia" 
                                                                    src="data:image/jpg;base64,<%#DataBinder.Eval(Container.DataItem,"R_imagenReceta") is System.DBNull ? string.Empty : Convert.ToBase64String((byte[]) DataBinder.Eval(Container.DataItem,"R_imagenReceta")) %>">
                                                                </div>
                                                        <div class="card-body">
                                                                <asp:Label ID="lblIdReceta" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"R_idReceta") %>'></asp:Label>

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
                                                                Descripción:
                                                                <asp:Label Visible="true" ID="lblDescripcion" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"R_descripcion") %>' />
                                                            </p>
                                                            <div>
                                                                <asp:Button ID="btnActualizarReceta" class="btn btn-outline-warning" Text="Editar" runat="server" CommandName="ActualizarReceta" />
                                                                <%-- <asp:Button ID="btnEliminarReceta" CssClass="btn btn-primary" runat="server" Text="Eliminar" CommandName="EliminarReceta" OnClientClick="return confirm('¿Estás seguro que queres borrar el registro ?');"/>--%>
                                                                   
                                                            </div>
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
       </div>
    </div>
            <div class="clearfix"></div>

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
    <%--<script src="vendors/scripts/core.js"></script>--%>
</asp:Content>