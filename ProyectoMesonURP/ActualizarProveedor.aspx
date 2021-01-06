<%@ Page Title="Gestionar Proveedor | Editar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarProveedor.aspx.cs" Inherits="ProyectoMesonURP.ActualizarProveedor" %>

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
                        <h4 class="tittle-margin5">Actualizar Proveedor</h4>
                         <input type="text" style="display: none;" id="mivariable">
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
                <button type="button" id="demo" onclick="actualizar()" class="btn btn-primary" ValidationGroup="prov">Actualizar</button>
                <asp:Button CssClass="btn btn-danger" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                </p>
             </div>
        </div>
    </div>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script>

        var listatraigo = new Array();
        var listallevo = new Array();
        var listaregistro = new Array();
        var listaeliminacion = new Array();




        window.onload = load();

        function load() {

            var Userid = sessionStorage.getItem('Userid');
            $('#mivariable').val(Userid);
            document.getElementById("mivariable").innerHTML = Userid;


            $.ajax({
                type: "POST",
                url: 'RegistrarProveedor.aspx/listarCategorias',
                data: "{'id':" + 2 + " }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
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

                            var checkbox = document.createElement('input');
                            checkbox.type = "checkbox";
                            checkbox.setAttribute('class', 'checkbox');
                            checkbox.name = "checks";
                            checkbox.value = resultado[p][s].CI_nombreCategoria;
                            checkbox.id = resultado[p][s].CI_idCategoriaInsumo;

                            var label = document.createElement('label');

                            label.htmlFor = "id";
                            label.setAttribute('class', 'label');
                            label.appendChild(document.createTextNode(resultado[p][s].CI_nombreCategoria));
                            nodorow.appendChild(checkbox);
                            nodorow.appendChild(label);
                            nodogroup.appendChild(nodorow);
                            nodocontainer.appendChild(nodogroup);
                            myDiv.appendChild(nodocontainer);
                        }
                    }

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(error.Message);
                }
            });

            $.ajax({
                type: "POST",
                url: 'ActualizarProveedor.aspx/traerProveedor',
                data: "{ PR_idProveedor : " + Userid + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                success: function (resultado) {
                    //alert(JSON.stringify(resultado));
                    //alert((resultado.length));
                    for (var p in resultado) {
                        document.getElementById("<%= PR_nombreContacto.ClientID %>").value = resultado[p].PR_nombreContacto;
                        document.getElementById("<%= PR_numeroDocumento.ClientID %>").value = resultado[p].PR_numeroDocumento;
                        document.getElementById("<%= PR_razonSocial.ClientID %>").value = resultado[p].PR_razonSocial;
                        document.getElementById("<%= PR_direccion.ClientID %>").value = resultado[p].PR_direccion;
                        document.getElementById("<%= PR_telefonoContacto.ClientID %>").value = resultado[p].PR_telefonoContacto;
                        document.getElementById("<%= PR_correoContacto.ClientID %>").value = resultado[p].PR_correoContacto;
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    //alert(error.Message);
                }
            });



            $.ajax({
                type: "POST",
                url: 'ActualizarProveedor.aspx/TraerCategorias',
                data: "{ PR_idProveedor : " + Userid + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",                                          // formato de transmición de datos
                async: true,                                                // si es asincrónico o no
                success: function (resultado) {
                    //alert(JSON.stringify(resultado));
                    //alert((resultado.length));
                    for (var p in resultado) {
                        // alert("hola");
                        for (var a in resultado[p]) {

                            listatraigo.push(resultado[p][a]);

                            //alert(resultado[p][a]);
                            document.getElementById(resultado[p][a]).checked = true;

                        }

                        //alert(resultado[p]);
                    }

                    // alert(JSON.stringify(resultado));
                    //location.href = "GestionarProveedor.aspx"
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    //alert(error.Message);
                }
            });

        }

        function diff(arr1, arr2) {
            var arr3 = [];
            for (var i = 0; i < arr1.length; i++) {
                var unique = true;
                for (var j = 0; j < arr2.length; j++) {
                    if (arr1[i] == arr2[j]) {
                        unique = false;
                        break;
                    }

                }
                if (unique) {
                    arr3.push(arr1[i]);
                }
            }
            return arr3;
        }
        function igual(arr, elemento) {


            if ((arr.indexOf(elemento) >= 0)) {
                return true;
            }
            if (!(arr.indexOf(elemento) >= 0)) {
                return false;
            }


        }

        function agregar(listallevo, listatraigo) {
            var arr3 = [];
            var analizar;

            for (var i in listallevo) {
                analizar = listallevo[i];
                if (!(igual(listatraigo, parseInt(analizar, 10)))) {
                    arr3.push(analizar);
                }

            }
            return arr3;
        }



        function pedirChecks(idProveedor) {

            $("input:checkbox[name=checks]:checked").each(function () {
                console.log("Id: " + $(this).attr("id") + " Value: " + $(this).val());
                listallevo.push($(this).attr("id"));
                //  registrarCategoria(idProveedor,$(this).attr("id"));
            });
            var h = "listatraigo ";
            for (var i in listatraigo) {
                h += listatraigo[i] + ", "
                //alert("valores de la lista llevo:"+listallevo[i]);
            }
            h += "listallevo ";
            for (var i in listallevo) {
                h += listallevo[i] + ", "
                //alert("valores de la lista llevo:"+listallevo[i]);
            }
            //alert(h);


            listaeliminacion = diff(listatraigo, listallevo);
            listaregistro = agregar(listallevo, listatraigo);

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



            vacio(PR_nombreContacto, "Nombre del Proveedor");
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



        function actualizar() {

            var PR_idProveedor = $('#mivariable').val();
            var PR_razonSocial = document.getElementById('<%=PR_razonSocial.ClientID%>').value;
            var PR_numeroDocumento = document.getElementById('<%=PR_numeroDocumento.ClientID%>').value;
            var PR_direccion = document.getElementById('<%=PR_direccion.ClientID%>').value;
            var PR_nombreContacto = document.getElementById('<%=PR_nombreContacto.ClientID%>').value;
            var PR_telefonoContacto = document.getElementById('<%=PR_telefonoContacto.ClientID%>').value;
            var PR_correoContacto = document.getElementById('<%=PR_correoContacto.ClientID%>').value;

            /*  for (var i in listaregistro) {
                  alert(listaregistro[i])
              }
              for (var i in listaeliminacion) {
                  alert(listaeliminacion[i])
              }*/

            if (numericValidation()) {
                pedirChecks(PR_idProveedor);
                $.ajax({
                    type: "POST",
                    url: 'ActualizarProveedor.aspx/actualizarProveedor',
                    data: "{PR_idProveedor: " + PR_idProveedor + ", PR_razonSocial : '" + PR_razonSocial + "',PR_numeroDocumento:'" + PR_numeroDocumento + "',PR_direccion:'" + PR_direccion + "', PR_nombreContacto: '" + PR_nombreContacto + "',PR_telefonoContacto:'" + PR_telefonoContacto + "', PR_correoContacto:'" + PR_correoContacto + "',listaEliminar:'" + listaeliminacion + "',listaAgregar:'" + listaregistro + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",                                          // formato de transmición de datos
                    async: true,                                                // si es asincrónico o no
                    success: function (resultado) {
                        //alert(JSON.stringify(resultado));
                        // pedirChecks(Object.values(Object.values(resultado)));
                        swal({
                            title: "Se Actualizo",
                            text: "correctamente",
                            type: "success"
                        }).then(function () {
                            location.href = "GestionarProveedor.aspx"
                        });
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                        var error = eval("(" + XMLHttpRequest.responseText + ")");
                        alert(error.Message);
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
                    // alert(JSON.stringify(resultado));
                    //pedirChecks();
                    // función que va a ejecutar si el pedido fue exitoso
                    // alert(JSON.stringify(resultado));
                    //location.href = "GestionarProveedor.aspx"
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    //alert(error.Message);
                }
            });
            return false;
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
    </script>
</asp:Content>
