<%@ Page Title="MesónURP | Gestionar Proveedor" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarProveedor.aspx.cs" Inherits="ProyectoMesonURP.GestionarProveedor" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .hiddencol {
            display: none;
        }

        /*table, td, tr {
            border: 1px solid black;
        }*/
        .mb-0 {
        }
    </style>
    <link rel="stylesheet" type="text/css" href="vendors/styles/core.css">
    <link rel="stylesheet" type="text/css" href="vendors/styles/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
         <div class="page-header">
             <div class="row">
                    <div class="col-md-6 col-sm-12">
                        <div class="title">
                            <h4>Gestionar Proveedor</h4>
                        </div>
                    </div>
                 <div class="header-right pt-2 pr-4">
                    <button type="button" class="btn btn-primary btn-flex" runat="server" style="display: flex; margin-left: 6px;" onclick="registrar()">     
                        <span class="material-icons margin-5">add_circle_outline</span>
                        Añadir Proveedor
                    </button>
                </div>
               </div>
           </div>
           <div class="pd-20 card-box">
             <div class="row pt-1">
                <div class="col-sm-12 col-md-6">
                    <label class="control-label col-md-2">Paginación:</label>
                    <asp:DropDownList ID="ddlp" class="custom-select custom-select-sm form-control form-control-sm" Style="width: auto; height: 38px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlp_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-12 col-md-3 pl-30"></div>
                <div class="col-sm-12 col-md-3 pl-30">
                    <div class="search-icon-box bg-white box-shadow border-radius-10 mb-30">
                        <asp:TextBox ID="txtBuscarProveedor" runat="server" class="form-control" AutoPostBack="True" onkeypress="return soloLetras(event);" OnTextChanged="fNombreProveedor_TextChanged" placeholder="Buscar Proveedor..." />
                        <i class="search_icon dw dw-search"></i>
                    </div>
                </div>
            </div>

            <div class="panel panel-widget forms-panel">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h5>Proveedores</h5>
                    </div>
                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                        <asp:GridView ID="gvPro" AllowPaging="True" AutoGenerateColumns="False" runat="server" EmptyDataText="No hay información disponible." OnRowCommand="gvPro_RowCommand" OnRowDataBound="gvPro_RowDataBound"
                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="PR_idProveedor,PR_razonSocial,PR_numeroDocumento,PR_direccion,PR_nombreContacto,PR_telefonoContacto,PR_correoContacto,EP_idEstadoProveedor"
                            Style="text-align: center" OnPageIndexChanging="gvPro_PageIndexChanging" CellPadding="4" PageSize="6" GridLines="None">
                            <PagerStyle HorizontalAlign="Right" BackColor="#dee2e6"> </PagerStyle>
                            <Columns>
                                <asp:BoundField DataField="PR_idProveedor" HeaderText="PR_idProveedor" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                <asp:BoundField DataField="PR_razonSocial" HeaderText="Razón Social" />
                                <asp:BoundField DataField="PR_numeroDocumento" HeaderText="N° de Documento" />
                                <asp:BoundField DataField="PR_direccion" HeaderText="Dirección" />
                                <asp:BoundField DataField="PR_nombreContacto" HeaderText="Nombre Contacto" />
                                <asp:BoundField DataField="PR_telefonoContacto" HeaderText="Teléfono" />
                                <asp:BoundField DataField="PR_correoContacto" HeaderText="Correo"/>
                                <asp:BoundField DataField="EP_idEstadoProveedor" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnActualizar" class="btn btn-warning btn-sm" OnClientClick="javascript:return actualizar(this)" runat="server" CommandName="Actualizar" CommandArgument="<%#((GridViewRow) Container).RowIndex %>"><i class="fa fa-pencil-square-o"></i>&nbsp; Editar</asp:LinkButton>       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cambiar Estado">
                                    <ItemTemplate>
                                         <asp:LinkButton onclick="return asignar(this)" class="btn btn-info btn-sm"><i class="fa fa-refresh"></i>&nbsp;Cambiar</asp:LinkButton>       
                                  
                                       <%-- <button type="button" onclick="return asignar(this)" class="btn btn-info btn-sm">Cambiar</button>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
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
        var textonotifica = "";
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
            textonotifica = '¿Seguro que desea ' + texto + ' el estado de ' + row.cells[4].innerHTML + "?\nDATOS:\nRazón Social: " + row.cells[1].innerHTML + "<br>Dirección: " + row.cells[3].innerHTML + "<br>Correo: " + row.cells[6].innerHTML + "<br>Teléfono: " + row.cells[5].innerHTML;
            // alert("el estado es:" + estado);
            ayuda();
            return false;

        }
        function registrar() {
            location.href = "RegistrarProveedor.aspx"
        }

        function actualizar(UserLink) {

            var row = UserLink.parentNode.parentNode;
            var Userid = row.cells[0].innerHTML;

            sessionStorage.setItem('Userid', Userid);
            location.href = "ActualizarProveedor.aspx";
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

            Swal.fire({
                title: textonotifica,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si, ' + texto + '!'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: "POST",
                        url: 'GestionarProveedor.aspx/eliminarProveedor',
                        data: "{ id: " + eliminarID + ",estado:" + estadofinal + " }",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: true,
                        success: function (resultado) {
                            swal({
                                title: "Se cambio el estado",
                                text: "correctamente",
                                type: "success"
                            }).then(function () {
                                location.href = "GestionarProveedor.aspx"
                            });
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            var error = eval("(" + XMLHttpRequest.responseText + ")");
                            //alert(error.Message);
                            swal("No se actualizo", error.Message, "error");
                            delay(2000);

                        }
                    });
                }
            })
        }
    </script>
</asp:Content>
