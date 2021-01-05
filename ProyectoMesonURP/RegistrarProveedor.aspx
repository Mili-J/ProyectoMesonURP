<%@ Page Title="Gestionar Proveedor | Agregar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistrarProveedor.aspx.cs" Inherits="ProyectoMesonURP.RegistrarProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .checkbox {
            margin: 10px;
            transform: scale(1.5);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
      <div class="pd-ltr-20 xs-pd-20-10">
            <div class="page-header">
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <h4 class="tittle-margin5">Registrar Proveedor</h4>
                    </div>
                </div>
            </div>
           <div class="pd-20 card-box mb-30">
               <div class="row clearfix">
                 <div class="col-md-6 col-sm-12 mb-30">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h5>Datos del Proveedor</h5>
                        </div>
                    </div>
                  <div class="pd-20 card-box height-100-p">
                       <div class="row">
                           <div class="col-md-6">
                                <div class="form-group">
                                    <label>Nombre del Proveedor</label>
                                    <asp:TextBox ID="PR_nombreContacto" runat="server" class="form-control" onkeypress="return soloLetras(event);" placeholder="Ingrese un nombre"/>
                                    <asp:RequiredFieldValidator ID="rfvnombre" runat="server" ControlToValidate="PR_nombreContacto" ErrorMessage="Campo Obligatorio" SetFocusOnError="True" Display="Dynamic" ForeColor="DarkRed" ValidationGroup="prov"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Nro de Documento</label>
                                    <asp:TextBox ID="PR_numeroDocumento" runat="server" class="form-control" onkeypress="return SoloNumeroInt(event);" placeholder="Ingrese un N° de documento"/>
                                    <asp:RequiredFieldValidator ID="rfvnumD" runat="server" ControlToValidate="PR_numeroDocumento" ErrorMessage="Campo Obligatorio" SetFocusOnError="True" Display="Dynamic" ForeColor="DarkRed" ValidationGroup="prov"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                           <div class="col-md-6">
                                <div class="form-group">
                                    <label>Razón Social</label>
                                    <asp:TextBox ID="PR_razonSocial" runat="server" class="form-control" onkeypress="return soloLetras(event);" placeholder="Ingrese una razón social"/>
                                    <asp:RequiredFieldValidator ID="rfvrazonS" runat="server" ControlToValidate="PR_razonSocial" ErrorMessage="Campo Obligatorio" SetFocusOnError="True" Display="Dynamic" ForeColor="DarkRed" ValidationGroup="prov"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                           <div class="col-md-6">
                                <div class="form-group">
                                    <label>Dirección</label>
                                    <asp:TextBox ID="PR_direccion" runat="server" class="form-control" placeholder="Ingrese una dirección"/>
                                    <asp:RequiredFieldValidator ID="rfvdireccion" runat="server" ControlToValidate="PR_direccion" ErrorMessage="Campo Obligatorio" SetFocusOnError="True" Display="Dynamic" ForeColor="DarkRed" ValidationGroup="prov"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Teléfono del Contacto</label>
                                    <asp:TextBox ID="PR_telefonoContacto" runat="server" class="form-control" onkeypress="return SoloNumeroInt(event);" placeholder="Ingrese un número "/>
                                    <asp:RequiredFieldValidator ID="rfvtelfC" runat="server" ControlToValidate="PR_telefonoContacto" ErrorMessage="Campo Obligatorio" SetFocusOnError="True" Display="Dynamic" ForeColor="DarkRed" ValidationGroup="prov"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revTelefono" runat="server" ErrorMessage="Teléfono Inválido" ControlToValidate="PR_telefonoContacto" ForeColor="DarkRed" ValidationExpression="\d{9}" SetFocusOnError="True" Display="Dynamic" ValidationGroup="añadirProveedor"></asp:RegularExpressionValidator>
                               </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Correo</label>
                                    <asp:TextBox ID="PR_correoContacto" runat="server" class="form-control" placeholder="Ingrese un correo electónico"/>
                                    <asp:RequiredFieldValidator ID="rfvcorreoC" runat="server" ControlToValidate="PR_correoContacto" ErrorMessage="Campo Obligatorio" SetFocusOnError="True" Display="Dynamic" ForeColor="DarkRed" ValidationGroup="prov"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RevCorreo" runat="server" ErrorMessage="Por favor ingrese su correo" ControlToValidate="PR_correoContacto" ForeColor="DarkRed" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                  </div>
                </div>
                 <div class="col-md-6 col-sm-12 mb-30">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h5>Selección de categorías asignadas al proveedor</h5>
                        </div>
                    </div>
                    <div class="pd-20 card-box height-100-p">
                         <div id="txt" class="row p-5 justify-content-center h-100"></div>
                    </div>
                </div>
               </div>
                <hr />
                <p class="center-button pt-3">
                     <button type="button" id="demo" onclick="pruebaRegistro()" class="btn btn-primary" ValidationGroup="prov">Registrar</button>
                </p>
             </div>
      </div>
  </div>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script>
        window.onload = load();
        function load() {
            $.ajax({
                type: "POST",
                url: 'RegistrarProveedor.aspx/listarCategorias',
                data: "{'id':" + 2 + " }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",                                          // formato de transmición de datos
                async: true,                                                // si es asincrónico o no
                success: function (resultado) {
                    //alert(JSON.stringify(resultado));

                    //document.getElementById('txt').innerHTML = JSON.stringify(resultado);

                    for (var p in resultado) {
                        for (var s in resultado[p]) {

                            var myDiv = document.getElementById("txt");

                            // creating checkbox element 
                            var nodocontainer = document.createElement("div");
                            var nodorow = document.createElement("div");
                            var nodogroup = document.createElement("div");
                            nodocontainer.setAttribute('name', resultado[p][s].CI_nombreCategoria);
                            nodocontainer.setAttribute('class', 'col-md-6'); 
                            nodorow.setAttribute('class', 'row');
                            nodogroup.setAttribute('class', 'form-group two-fields');


                            // Assigning the attributes 
                            // to created checkbox 

                            var checkbox = document.createElement('input');
                            checkbox.type = "checkbox";
                            checkbox.setAttribute('class', 'checkbox');
                            checkbox.name = "checks";
                            checkbox.value = resultado[p][s].CI_nombreCategoria;
                            checkbox.id = resultado[p][s].CI_idCategoriaInsumo;

                            // creating label for checkbox 
                            var label = document.createElement('label');

                            // assigning attributes for  
                            // the created label tag  
                            label.htmlFor = "id";
                            label.setAttribute('class', 'label');
                            // appending the created text to  
                            // the created label tag  
                            label.appendChild(document.createTextNode(resultado[p][s].CI_nombreCategoria));

                            //             // and label to div appending the checkbox 
                
                            nodorow.appendChild(checkbox);
                            nodorow.appendChild(label);
                            nodogroup.appendChild(nodorow);
                            nodocontainer.appendChild(nodogroup);
                            myDiv.appendChild(nodocontainer);
                        }
                    }

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(error.Message);
                }
            });
        }
        var validacion;
        var mensaje = "";
        var cont = 0;
        function numericValidation() {
            validacion = true;
            mensaje = "";
            //var numbers = /^[0-9]+$/; //only for numbers
            cont = 0;
            var letters = /^[A-Za-z]+$/;

            //[0-9]+ matches 1 or more digits [,-] matches a , or a -
            /// /^[A-Za-z]+$/  para las letras
            //(...)? is an optional match
            /// /^[0-9]+([,-][0-9]+)?$/

            //^ anchors the start and $ anchors the end of the string
            var PR_razonSocial = document.getElementById('<%=PR_razonSocial.ClientID%>').value;
            var PR_numeroDocumento = document.getElementById('<%=PR_numeroDocumento.ClientID%>').value;
            var PR_direccion = document.getElementById('<%=PR_direccion.ClientID%>').value;
            var PR_nombreContacto = document.getElementById('<%=PR_nombreContacto.ClientID%>').value;
            var PR_telefonoContacto = document.getElementById('<%=PR_telefonoContacto.ClientID%>').value;
            var PR_correoContacto = document.getElementById('<%=PR_correoContacto.ClientID%>').value;


            /*if (vacio(PR_nombreContacto, "Nombre del Proveedor") || vacio(PR_numeroDocumento, "Nro de Documento") ||vacio(PR_razonSocial, "Razon Social") || vacio(PR_direccion, "Direccion") || vacio(PR_telefonoContacto, "Telefono Contacto") || vacio(PR_correoContacto, "Correo") ) {
                cont++;
            }
            else if (numeros(PR_numeroDocumento, "Nro de Documento")) {
                cont++;
            }
            if (cont > 0) {
                alert(cont);
                swal("Valor del campo Incorrecto!", mensaje, "error");
                validacion = false;
             }*/

            vacio(PR_nombreContacto, "Nombre del Proveedor");
            //vacio(PR_numeroDocumento, "Nro de Documento");
            documento(PR_numeroDocumento, "Nro de Documento");
            vacio(PR_razonSocial, "Razon Social");
            vacio(PR_direccion, "Direccion");
            telefonos(PR_telefonoContacto, "Telefono ");
            correos(PR_correoContacto, "Correo");
            validarChecks();
            if (cont > 0) {
                swal("Valor(es) de campo(s) Incorrecto(s)!", mensaje, "error");
                validacion = false;
            }
            // alert(cont);
            return validacion;
        }

        function vacio(valor, nombreCampo) {
            if (valor == null || valor.length == 0 || /^\s+$/.test(valor)) {
                cont++;
                mensaje += "Ingrese un valor en el campo " + nombreCampo + "\n\n";
                return true;
            }
            else {
                return false;
            }
        }

        function numeros(valor, nombreCampo) {
            if (isNaN(valor)) {
                cont++;
                mensaje += "Ingrese solo numeros en el campo " + nombreCampo + "\n\n";
                return true;
            }
            else {
                return false;
            }
        }
        function correos(valor, nombreCampo) {
            if (!(/^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/.test(valor))) {
                cont++;
                mensaje += "Ingrese un correo valido en el campo " + nombreCampo + "\n\n";
                return true;
            }
            else {
                return false;
            }
        }
        function documento(valor, nombreCampo) {
            if (!(/^\d{8}(?:[-\s]\d{4})?$/.test(valor))) {
                cont++;
                mensaje += "Ingrese un numero de documento valido en el campo " + nombreCampo + "\n\n";
                return true;
            }
            else {
                return false;
            }
        }
        function telefonos(valor, nombreCampo) {
            if (!(/^\d{9}$/.test(valor))) {
                cont++;
                mensaje += "Ingrese el un telefono que contenga 9 caracteres numericos en el campo " + nombreCampo + "\n\n";

                return true;
            }
            else {
                return false;
            }
        }

        function validarChecks() {
            var checkbox = document.getElementsByName('checks');
            var contador = 0;
            for (var i = 0; i < checkbox.length; i++) {
                if (checkbox[i].checked)
                    contador++

            }

            //Con JQuery contador=$('[name="groupCheckbox[]"]:checked').length
            if (contador == 0) {
                mensaje += "Seleccione por lo menos una categoria para el proveedor \n\n";
                cont++;
                return true;
            }
            else {
                return false;
            }
        }


        function pedirChecks(idProveedor) {

            $("input:checkbox[name=checks]:checked").each(function () {
                console.log("Id: " + $(this).attr("id") + " Value: " + $(this).val());
                registrarCategoria(idProveedor, $(this).attr("id"));
            });

            swal({
                title: "Se Registro",
                text: "correctamente",
                type: "success"
            }).then(function () {
                location.href = "GestionarProveedor.aspx"
            });


        }

        function pruebaRegistro() {
            var PR_razonSocial = document.getElementById('<%=PR_razonSocial.ClientID%>').value;
            var PR_numeroDocumento = document.getElementById('<%=PR_numeroDocumento.ClientID%>').value;
            var PR_direccion = document.getElementById('<%=PR_direccion.ClientID%>').value;
            var PR_nombreContacto = document.getElementById('<%=PR_nombreContacto.ClientID%>').value;
            var PR_telefonoContacto = document.getElementById('<%=PR_telefonoContacto.ClientID%>').value;
            var PR_correoContacto = document.getElementById('<%=PR_correoContacto.ClientID%>').value;

            if (numericValidation()) {
                $.ajax({
                    type: "POST",
                    url: 'RegistrarProveedor.aspx/registrarProveedor',
                    data: "{ PR_razonSocial : '" + PR_razonSocial + "',PR_numeroDocumento:'" + PR_numeroDocumento + "',PR_direccion:'" + PR_direccion + "', PR_nombreContacto: '" + PR_nombreContacto + "',PR_telefonoContacto:'" + PR_telefonoContacto + "', PR_correoContacto:'" + PR_correoContacto + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",                                          // formato de transmición de datos
                    async: true,                                                // si es asincrónico o no
                    success: function (resultado) {
                        //alert(JSON.stringify(resultado));
                        //alert("asdfsdf" + Object.values(resultado));
                        pedirChecks(Object.values(Object.values(resultado)));
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                        var error = eval("(" + XMLHttpRequest.responseText + ")");
                    }
                });
            }


            return false;
        }

        function registrarCategoria(idProveedor, idCategoria) {
            // alert("entre los datos que entran son:" + idProveedor + " y " + idCategoria);
            $.ajax({
                type: "POST",
                url: 'RegistrarProveedor.aspx/registrarCategoria',
                data: "{idProveedor: " + idProveedor + ", idCategoria  : " + idCategoria + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",                                          // formato de transmición de datos
                async: true,                                                // si es asincrónico o no
                success: function (resultado) {
                    //alert(JSON.stringify(resultado));
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(error.Message);
                }
            });
            return false;
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
        function SoloNumeroInt(ev) {
            var tecla = (document.all) ? ev.keyCode : ev.which;
            if (tecla == 8 || tecla == 13 || tecla == 0) return true;
            if (tecla >= 8226 && tecla <= 10175) { return false; }
            var regEx = /^[0-9]+$/i;
            return regEx.test(String.fromCharCode(tecla));
        }
    </script>
</asp:Content>
