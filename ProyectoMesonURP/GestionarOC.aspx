﻿<%@ Page Title="Mesón URP | Gestionar Orden de Compra" Language="C#" AutoEventWireup="true" CodeBehind="GestionarOC.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.GestionarOC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .mb-0 {
        }
    </style>
    <style type="text/css">
  .hiddencol
  {
    display: none;
  }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Gestionar Orden de Compra</h2>
            </div>
            <div class="search-buttons">
                <div class="search">
                    <asp:TextBox ID="txtBuscarInsumo" runat="server" CssClass="form-control1" onkeypress="return lettersOnly(event);" placeholder="Buscar Insumo ..." />
                    <button type="button" id="btnBuscar" runat="server" onserverclick="btnBuscar_ServerClick">
                        <span class="material-icons">search
                        </span>
                    </button>
                </div>
            </div>
            <div class="panel panel-widget forms-panel">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h4>Ordenes de Compra</h4>
                         
                    </div>
                    <div class="table-wrapper-scroll-y my-custom-scrollbar">
                        <asp:GridView ID="gvOC" AllowPaging="True" AutoGenerateColumns="False" runat="server" EmptyDataText="No hay información disponible." OnRowCommand="gvOC_RowCommand"
                            CssClass="table table-bordered table-striped mb-0" DataKeyNames="OC_idOC,OC_numeroOC,PR_nombreContacto,OC_fechaEmision,OC_fechaEntrega,EOC_nombreEstadoOC"
                            Style="text-align: center" OnPageIndexChanging="gvOC_PageIndexChanging" CellPadding="4" PageSize="5" OnSelectedIndexChanged="gvOC_SelectedIndexChanged" GridLines="None">
                            <Columns>
                                <asp:BoundField DataField="OC_idOC" HeaderText="Id_OC" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                <asp:BoundField DataField="OC_numeroOC" HeaderText="N° de Compra" />
                                <asp:BoundField DataField="PR_nombreContacto" HeaderText="Proveedor" />
                                <asp:BoundField DataField="OC_fechaEmision" HeaderText="Fecha de Emisión" />
                                <asp:BoundField DataField="OC_fechaEntrega" HeaderText="Fecha de Entrega" />
                                <asp:BoundField DataField="EOC_nombreEstadoOC" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Descargar">
                                    <ItemTemplate>
                                        <asp:ImageButton  ID="btnDescargar" ImageUrl="img/descargar.png" onmouseover="this.src='img/descargar-b.png'" onmouseout="this.src='img/descargar.png'" runat="server" CommandName="Descargar"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Recepcionar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnRecepcionar" ImageUrl="img/recepcionar.png" onmouseover="this.src='img/recepcionar-b.png'" onmouseout="this.src='img/recepcionar.png'" runat="server" CommandName="Recepcionar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                         <contenttemplate >
                                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                          
                                        <div id="hola" style="display: none" class="table-wrapper-scroll-y my-custom-scrollbar" >
                                          <div class="form-title color-white">
                                            <h4>Insumos</h4>
                                        </div>
                                            <asp:GridView ID="gvInsumos1"  allowpaging="True" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible."
                                                CssClass="table table-bordered table-striped mb-0" DataKeyNames="OC_idOC,DC_idDetalleCotizacion,I_idInsumo,I_nombreInsumo,DC_cantidadCotizacion,Estado"   
                                                Style="text-align: center" OnPageIndexChanging="gvOC_PageIndexChanging" CellPadding="4" PageSize="5" OnSelectedIndexChanged = "gvOC_SelectedIndexChanged" AllowSorting="False" EnablePersistedSelection="True">
                                                <Columns>
                                                    <asp:BoundField DataField="OC_idOC" HeaderText="Id_OC" Visible="False" />
                                                    <asp:BoundField DataField="DC_idDetalleCotizacion" HeaderText="ID_DetalleCotizacion" Visible="False" />
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
            <div>
            </div>
            <hr />

        </div>
    </div>
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
                text: 'Ingrese un numero de OC para la busqueda',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
    </script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.22/pdfmake.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.debug.js"></script>
<script type="text/javascript">

    function createPDF() {

        var sTable = document.getElementById('hola').innerHTML;
        var style = "<style>";
        style = style + "table {width: 100%;font: 17px Calibri;}";
        style = style + "table, th, td {border: solid 1px #DDD; border-collapse: collapse;";
        style = style + "padding: 2px 3px;text-align: center;}";
        style = style + "</style>";

        // CREATE A WINDOW OBJECT.
        var win = window.open('', '', 'height=700,width=700');

        win.document.write('<html><head>');
        win.document.write('<title>Orden de compra</title>');   // <title> FOR PDF HEADER.
        win.document.write(style);          // ADD STYLE INSIDE THE HEAD TAG.
        win.document.write('</head>');
        win.document.write('<body>');
        win.document.write(sTable);         // THE TABLE CONTENTS INSIDE THE BODY TAG.
        win.document.write('</body></html>');

        win.document.close(); 	// CLOSE THE CURRENT WINDOW.

        win.print();    // PRINT THE CONTENTS.
    }


    function OnSuccess(response) {
        createPDF();
    }






</script>
    
</asp:Content>
