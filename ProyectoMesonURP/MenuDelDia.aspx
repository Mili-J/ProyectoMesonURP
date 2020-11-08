<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuDelDia.aspx.cs" Inherits="ProyectoMesonURP.MenuDelDia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Seleccionar Menú del Día</h2>
                <div class="stock-options">
                    <div class="width-auto margin-5">


                    </div>


                </div>

                    
            </div>

             <div class="form-group">
                        
                        
                        <label for="focusedinput" class="col-sm-2 control-label">Raciones</label>
                        <div class="col-sm-2">
                            <asp:TextBox runat="server" CssClass="form-control1" ID="txtNumRaciones" TextMode="Number" OnTextChanged="txtNumRaciones_TextChanged" AutoPostBack="true"/>
                            <%--<asp:RegularExpressionValidator ID="revNumRac" runat="server" ErrorMessage="No negativos" ControlToValidate="txtNumRaciones" ForeColor="#CC0000" SetFocusOnError="True" Display="Dynamic"  ValidationExpression="\d{1,}"></asp:RegularExpressionValidator>--%>
                        </div>
                                 
                   
                    </div>

            <div class="search-buttons">


                <%--< > --%>

                <div class="panel panel-widget forms-panel">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h4>Platos de Fondo</h4>
                        </div>

                        
                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
            <asp:GridView ID="gvPlatoFondo" runat="server"  DataKeyNames="R_idReceta,R_nombreReceta,R_numeroPorcion,R_descripcion" OnRowCommand="gvPlatoFondo_RowCommand" AutoGenerateColumns="false"
                CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">
                <Columns>
                  
                    <asp:BoundField HeaderText="Nombre" DataField="R_nombreReceta" />
                    <asp:BoundField HeaderText="Porcion" DataField="R_numeroPorcion" />
                    <asp:BoundField HeaderText="Descripcion" DataField="R_descripcion"/>

                    
                    <asp:TemplateField HeaderText="Seleccionar">
                        <ItemTemplate>
                            <asp:Button ID="btnSeleccionarPlato" runat="server" CommandName="SeleccionarPlato" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"   Text="Seleccionar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                        </div>
                        <%-- grid --%>
                    </div>
                </div>
                   

                <%--< -----------------------------------> --%>

                <div class="panel panel-widget forms-panel">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h4>Entradas</h4>
                        </div>


                        <%--  --%>
                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
            <asp:GridView ID="gvEntrada" runat="server"  DataKeyNames="R_idReceta,R_nombreReceta,R_numeroPorcion,R_descripcion" OnRowCommand="gvEntrada_RowCommand1" AutoGenerateColumns="false"
                CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None">
                <Columns>
                  
                    <asp:BoundField HeaderText="Nombre" DataField="R_nombreReceta" />
                    <asp:BoundField HeaderText="Porcion" DataField="R_numeroPorcion" />
                    <asp:BoundField HeaderText="Descripcion" DataField="R_descripcion"/>

                    
                    <asp:TemplateField HeaderText="Seleccionar">
                        <ItemTemplate>
                            <asp:Button ID="btnSeleccionarEntrada" runat="server" CommandName="SeleccionarEntrada" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"   Text="Seleccionar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                        </div>
                        <%-- grid --%>
                    </div>
                </div>

                    <%--< ----------------------------------------> --%>
                
                <div class="panel panel-widget forms-panel">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h4>Menú del día</h4>
                        </div>


                        
                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
            <asp:GridView ID="gvMenu" runat="server"  DataKeyNames="R_nombreReceta" OnRowCommand="gvMenu_RowCommand" AutoGenerateColumns="False"
                CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" OnRowDeleting="gvMenu_RowDeleting">
                <Columns>
                  
                    <asp:BoundField HeaderText="Nombre" DataField="R_nombreReceta" />
                   <asp:BoundField HeaderText="Raciones" DataField="NumRaciones" />
                    

                    
                    <asp:TemplateField HeaderText="Quitar">
                        <ItemTemplate>
                            <asp:Button ID="btnQuitar" runat="server" CommandName="QuitarReceta" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Quitar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" DeleteText="Quitar" ShowDeleteButton="True" HeaderText="Este" />
                </Columns>
            </asp:GridView>
                        </div>
                        <%-- grid --%>
                    </div>
                </div>
                    <%--< > --%>

            </div>

            <div class="clearfix"></div>
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
    </script>
    <script>
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
