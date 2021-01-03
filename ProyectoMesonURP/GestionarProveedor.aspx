<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarProveedor.aspx.cs" Inherits="ProyectoMesonURP.GestionarProveedor" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Gestionar Proveedor</h2>
            </div>
            <div class="search-buttons">
                <div class="search">
                    <asp:TextBox ID="txtBuscarInsumo" runat="server" CssClass="form-control1" onkeypress="return lettersOnly(event);" placeholder="Buscar Proveedor" />
                    <button type="button" id="btnBuscar" runat="server">
                        <span class="material-icons">search
                        </span>
                    </button>
                </div>
            </div>
            <button type="button" onclick="registrar()" class="btn btn-warning">Registrar</button>
            <div class="panel panel-widget forms-panel">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h4>Proveedores</h4>
                    </div>
                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                        <asp:GridView ID="gvPro" AllowPaging="True" AutoGenerateColumns="False" runat="server" EmptyDataText="No hay información disponible." OnRowCommand="gvPro_RowCommand"
                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="PR_idProveedor,PR_razonSocial,PR_numeroDocumento,PR_direccion,PR_nombreContacto,PR_telefonoContacto,PR_correoContacto,EP_idEstadoProveedor"
                            Style="text-align: center" OnPageIndexChanging="gvPro_PageIndexChanging" CellPadding="4" PageSize="6" OnSelectedIndexChanged="gvPro_SelectedIndexChanged" GridLines="None">
                            <columns>
                                <asp:BoundField DataField="PR_idProveedor" HeaderText="PR_idProveedor" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                <asp:BoundField DataField="PR_razonSocial" HeaderText="Razon Social" />
                                <asp:BoundField DataField="PR_numeroDocumento" HeaderText="Numero de Documento" />
                                <asp:BoundField DataField="PR_direccion" HeaderText="Direccion" />
                                <asp:BoundField DataField="PR_nombreContacto" HeaderText="Nombre Contacto" />
                                <asp:BoundField DataField="PR_telefonoContacto" HeaderText="Telefono Contacto" />
                                <asp:BoundField DataField="PR_correoContacto" HeaderText="Correo Contacto" />
                                <asp:BoundField DataField="EP_idEstadoProveedor" HeaderText="Estado del Proveedor"/>
                                <asp:TemplateField HeaderText="Actualizar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnActualizar" ImageUrl="img/editar-b.png" onmouseover="this.src='img/editar-b.png'" onmouseout="this.src='img/editar-b.png'" OnClientClick="javascript:return actualizar(this)"  runat="server" CommandName="Actualizar" CommandArgument="<%#((GridViewRow) Container).RowIndex %>" /><!--OnClientClick="javascript:createPDF()  OnClientClick="javascript:return getDatos(this)" "-->
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opciones">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnRecepcionar" ImageUrl="img/recepcionar.png" onmouseover="this.src='img/recepcionar-b.png'" onmouseout="this.src='img/recepcionar.png'" runat="server" CommandName="Ver detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                     
                                    <button type="button" OnClick="return asignar(this)" class="btn btn-info btn-sm" data-toggle="modal" data-target="#myModal">Cambiar estado</button>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <div id="myModal" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" style="text-align: center;" class="close" data-dismiss="modal">CAMBIAR ESTADO DEL PROVEEDOR     &times;</button>
                        </div>
                        <div class="modal-body">
                            <div id="txt">
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                            <button type="button" onclick="ayuda()" class="btn btn-warning" data-dismiss="modal">Cambiar Estado</button>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script>
        window.onload = load();
        function load() {


            var myGrid = document.getElementById("<%=gvPro.ClientID%>");
            var oRows = myGrid.rows;
            var k;
            for (k = 1; k < oRows.length; k++) {
                var currentRow = myGrid.rows[k];
                //now you can see the 1st,2nd and 3trd column value
                if (currentRow.cells[7].innerHTML == 1) {
                    currentRow.cells[7].innerHTML = 'activo';
                }
                if (currentRow.cells[7].innerHTML == 2) {
                    currentRow.cells[7].innerHTML = 'inactivo';
                }
            }
        }


        var eliminarID = 0;
        var proveedorBorrar = "";
        var estado = "";
        var texto = "";
        function asignar(UserLink) {

            var row = UserLink.parentNode.parentNode;
            var rowIndex = row.rowIndex - 1;
            var Userid = row.cells[0].innerHTML;
            var Esta = row.cells[7].innerHTML;
            estado = Esta;
            eliminarID = Userid;

            if (estado == "activo") {
                texto = "desactivar";
            }
            if (estado == "inactivo") {
                texto = "activar";
            }
            document.getElementById('txt').innerHTML = '<b>¿Seguro que desea ' + texto + ' el estado de ' + row.cells[4].innerHTML + "?<br>DATOS:<br></b>Razon Social: " + row.cells[1].innerHTML + "<br>Direccion: " + row.cells[3].innerHTML + "<br>Correo: " + row.cells[6].innerHTML + "<br>Telefono: " + row.cells[5].innerHTML;
            // alert("el estado es:" + estado);
            return false;
        }
        function registrar() {
            location.href = "RegistrarProveedor.aspx"
        }

        function actualizar(UserLink) {
            var row = UserLink.parentNode.parentNode;
            var Userid = row.cells[0].innerHTML;

            sessionStorage.setItem('Userid', Userid);
            location.href = "ActualizarProveedor.aspx"
            return false;
        }

        function ayuda() {
            var estadofinal = 0;
            if (estado == "activo") {
                estadofinal = 2; //para desactivar
            }
            if (estado == "inactivo") {
                estadofinal = 1; //para activar
            }
            //alert(eliminarID);
            $.ajax({
                type: "POST",
                url: 'GestionarProveedor.aspx/eliminarProveedor',
                data: "{ id: " + eliminarID + ",estado:" + estadofinal + " }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",                                          // formato de transmición de datos
                async: true,                                                // si es asincrónico o no
                success: function (resultado) {                            // función que va a ejecutar si el pedido fue exitoso
                    // alert(JSON.stringify(resultado));
                    location.href = "GestionarProveedor.aspx"
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(error.Message);
                }
            });

        }
    </script>

</asp:Content>
