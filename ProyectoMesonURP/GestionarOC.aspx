﻿<%@ Page Title="MesónURP | Gestionar Orden de Compra" Language="C#" AutoEventWireup="true" CodeBehind="GestionarOC.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.GestionarOC" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .mb-0 {
        }
    </style>
    <style type="text/css">
        .hiddencol {
            display: none;
        }

        table, td, tr {
            border: 1px solid black;
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
                        <h4>Gestionar Orden de Compra</h4>
                    </div>
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
                        <asp:TextBox ID="txtBuscarOC" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="fidOC_TextChanged" onkeypress="return SoloNumeroInt(event);" placeholder="Buscar OC..." />
                        <i class="search_icon dw dw-search"></i>
                    </div>
                </div>
            </div>
           <div class="panel panel-widget forms-panel">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h5>Órdenes de Compras</h5>
                    </div>
                    <div class="w3-row-padding">
                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                        <asp:GridView ID="gvOC" AllowPaging="True" AutoGenerateColumns="False" runat="server" EmptyDataText="No hay información disponible." OnRowCommand="gvOC_RowCommand"
                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="OC_idOC,OC_numeroOC,PR_nombreContacto,OC_fechaEmision,OC_fechaEntrega,EOC_nombreEstadoOC"
                            Style="text-align: center" OnPageIndexChanging="gvOC_PageIndexChanging" OnRowDataBound="gvOC_RowDataBound" CellPadding="4" PageSize="5" GridLines="None">
                           <PagerStyle HorizontalAlign="Right" BackColor="#dee2e6"> </PagerStyle> 
                            <Columns>
                                <asp:BoundField DataField="OC_idOC" HeaderText="Id_OC" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                <asp:BoundField DataField="OC_numeroOC" HeaderText="N° de Compra" />
                                <asp:BoundField DataField="PR_nombreContacto" HeaderText="Proveedor" />
                                <asp:BoundField DataField="OC_fechaEmision" HeaderText="Fecha de Emisión" />
                                <asp:BoundField DataField="OC_fechaEntrega" HeaderText="Fecha de Entrega" />
                                <asp:BoundField DataField="EOC_nombreEstadoOC" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Descargar">
                                    <ItemTemplate> 
                                        <asp:LinkButton ID="btnDescargar" class="btn btn-info btn-sm" runat="server" CommandName="Descargar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClientClick="javascript:return getDatos(this)"><i class="fa fa-download"></i>&nbsp; Descargar</asp:LinkButton>       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Recepcionar">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnRecepcionar" class="btn btn-primary btn-sm" runat="server" CommandName="Recepcionar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-share-square-o"></i>&nbsp; Recepcionar</asp:LinkButton>       
                                   </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <table id="my-table">
                </table>
                <contenttemplate>
                            
                                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                          
                                        <div id="hola" style="display: none" class="table-wrapper-scroll-y my-custom-scrollbar" ><!--style="display: none" depues del hola-->
                                          <div class="form-title color-white">
                                            <h4>Insumos</h4>
                                        </div>
                                            <asp:GridView ID="gvInsumos1"  allowpaging="True" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."
                                                CssClass="table table-bordered table-striped mb-0" DataKeyNames="OC_idOC,DOC_idDetalleOC,I_idInsumo,I_nombreInsumo,DC_cantidadCotizacion,Estado"   
                                                Style="text-align: center" OnPageIndexChanging="gvOC_PageIndexChanging" CellPadding="4" PageSize="5" AllowSorting="False" EnablePersistedSelection="True">
                                                <Columns>
                                                    <asp:BoundField DataField="OC_idOC" HeaderText="Id_OC" Visible="False" />
                                                    <asp:BoundField DataField="DOC_idDetalleOC" HeaderText="ID_DOC" Visible="False" />
                                                    <asp:BoundField DataField="I_idInsumo" HeaderText="N° Insumo" />
                                                    <asp:BoundField DataField="I_nombreInsumo" HeaderText="Nombre" />
                                                    <asp:BoundField DataField="DC_cantidadCotizacion" HeaderText="Cantidad" />
                                                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </contenttemplate>

            </div>
           </div>
        </div>
    </div>
    <script>
        function SoloNumeroInt(ev) {
            var tecla = (document.all) ? ev.keyCode : ev.which;
            if (tecla == 8 || tecla == 13 || tecla == 0) return true;
            if (tecla >= 8226 && tecla <= 10175) { return false; }
            var regEx = /^[0-9]+$/i;
            return regEx.test(String.fromCharCode(tecla));
        }
        function alertaError() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Ingrese un numero de OC para la busqueda',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
    </script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.22/pdfmake.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/2.2.0/jspdf.es.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf-autotable/3.2.11/jspdf.plugin.autotable.min.js"></script>
    <script type="text/javascript">



        function getDatos(UserLink) {

            var doc = new jsPDF();

            var row = UserLink.parentNode.parentNode;
            var rowIndex = row.rowIndex - 1;
            var Userid = row.cells[0].innerHTML;
            $.ajax({
                type: "POST",
                url: 'GestionarOC.aspx/ListaDatos',
                data: "{ numero: " + Userid + " }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",                                          // formato de transmición de datos
                async: true,                                               // si es asincrónico o no
                success: function (resultado) {                            // función que va a ejecutar si el pedido fue exitoso
                    //alert(JSON.stringify({ resultado }));

                    doc.autoTable({ html: '#my-table' })
                    var columns = ["Cantidad", "Nombre Insumo", "Estado", "Datos"];

                    /*  doc.autoTable({
                          head: [['Cantidad', 'Nombre Insumo', 'Estado', 'Datos']],
                         
                          styles: {
                              cellPadding: 0.5,
                              halign: 'center'
                          },
                          margin: {
                              top: 100
                          }		
                      })*/

                    doc.setFont('helvetica')
                    doc.setFontType('bold')

                    var w = "Orden de compra del proveedor: " + row.cells[2].innerHTML;
                    doc.text(w, 45, 15);
                    var rows = [];
                    for (var p in resultado) {


                        for (var s in resultado[p]) {
                            var a = '';
                            var q = '';
                            var d = '';
                            var t = '';
                            var o = '';
                            // a = resultado[p][s].I_idInsumo;
                            q = "      " + resultado[p][s].DC_cantidadCotizacion + "      ";
                            d = "      " + resultado[p][s].I_nombreInsumo + "      ";
                            t = "      " + resultado[p][s].Estado + "      ";
                            o = "      " + resultado[p][s].Datos + "      ";

                            var singleRow = [resultado[p][s].DC_cantidadCotizacion, resultado[p][s].I_nombreInsumo, resultado[p][s].Estado, resultado[p][s].Datos];
                            rows.push(singleRow);
                            /*doc.autoTable({
                                body: [[a,q,d,t,o],],
                               styles: {
                                   halign: 'center'
                               },
                               margin: {
                                   top: 100
                               }		
                           })*/
                        }

                    }
                    doc.autoTable(columns, rows, {
                        fontStyle: 'bold',
                        theme: 'grid',
                        styles: {
                            halign: 'center',

                        },
                        Color: [255, 255, 255],
                        margin: {
                            top: 100
                        }

                    });

                    doc.autoTable({
                        foot: [['Proveedor:', row.cells[2].innerHTML], ['Fecha de Emision:', row.cells[3].innerHTML], ['Fecha de Entrega:', row.cells[4].innerHTML]],
                    })


                    doc.save('document.pdf');
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido
                    var error = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(error.Message);
                }

            });

            return false;
        }
    </script>
</asp:Content>
