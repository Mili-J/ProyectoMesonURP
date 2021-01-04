<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarProveedor.aspx.cs" Inherits="ProyectoMesonURP.ActualizarProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .p,label {
          font-size:23px;
        }
        .checkbox {
          margin: 10px;
         transform: scale(1.5);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Actualizar Proveedor</h2>
                <input type="text" style="display: none;" id="mivariable">
            </div>
        </div>
        <div class="infprincipal" style="display: flex;">
            <div class="infReceta" style="width: 50%;">
                <div class="form-grids widget-shadow" data-example-id="basic-forms" style="margin-top: 34px;">
                    <div class="form-title color-white">
                        <h4>Datos del Proveedor</h4>
                    </div>
                </div>
                <div class="p-5" runat="server">
                    <div class="form-group" style="width: 300px; margin-top: 23px;">
                        <label for="focusedinput" class="col-sm-12 control-label">Nombre del Proveedor</label>
                        <div class="col-sm-12">
                            <asp:TextBox ID="PR_nombreContacto" runat="server" CssClass="form-control1" />
                        </div>
                    </div>
                    <div class="form-group" style="width: 300px; margin-top: 23px;">
                        <label for="focusedinput" class="col-sm-12 control-label">Nro de Documento</label>
                        <div class="col-sm-12">
                            <asp:TextBox ID="PR_numeroDocumento" runat="server" CssClass="form-control1" />
                        </div>
                    </div>
                    <div class="form-group" style="width: 300px; margin-top: 23px;">
                        <label for="focusedinput" class="col-sm-12 control-label">Razon Social</label>
                        <div class="col-sm-12">
                            <asp:TextBox ID="PR_razonSocial" runat="server" CssClass="form-control1" />
                        </div>
                    </div>
                    <div class="form-group" style="width: 300px; margin-top: 23px;">
                        <label for="focusedinput" class="col-sm-12 control-label">Direccion </label>
                        <div class="col-sm-12">
                            <asp:TextBox ID="PR_direccion" runat="server" CssClass="form-control1" />
                        </div>
                    </div>
                    <div class="form-group" style="width: 300px; margin-top: 23px;">
                        <label for="focusedinput" class="col-sm-12 control-label">Telefono</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="PR_telefonoContacto" runat="server" CssClass="form-control1" />
                        </div>
                    </div>
                    <div class="form-group" style="width: 300px; margin-top: 23px;">
                        <label for="focusedinput" class="col-sm-12 control-label">Correo</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="PR_correoContacto" runat="server" CssClass="form-control1" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="imgDiv" style="width: 50%; margin-left: 50px">
                <div class="form-grids widget-shadow" data-example-id="basic-forms" style="margin-top: 34px;">
                    <div class="form-title color-white">
                        <h4>Seleccion de Categorias asignadas al proveedor</h4>
                    </div>
                </div>
                <div class="img-div">
                    <div class="form-group" style="display: flex; margin-top: 58px; justify-content: center;">
                        <div id="txt"></div>
                    </div>
                </div>
                <button type="button" id="demo" onclick="actualizar()" class="btn btn-warning">Actualizar</button>

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
                            myDiv.appendChild(checkbox);
                            myDiv.appendChild(label);
                            myDiv.appendChild(document.createElement("br"));
                            myDiv.appendChild(document.createElement("br"));



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
