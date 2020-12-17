<%@ Page Title="Mesón URP | Gestionar Orden de Compra" Language="C#" AutoEventWireup="true" CodeBehind="GestionarOC.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.GestionarOC" EnableEventValidation="false"%>

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
                    <asp:DropDownList ID="ddlp" class="custom-select custom-select-sm form-control form-control-sm" style="width: auto; height: 38px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlp_SelectedIndexChanged">
                    </asp:DropDownList>
            </div>
            <div class="col-sm-12 col-md-3 pl-30"></div>
            <div class="col-sm-12 col-md-3 pl-30">
                <div class="search-icon-box bg-white box-shadow border-radius-10 mb-30">
                    <asp:TextBox ID="txtBuscarOC" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="fidOC_TextChanged" placeholder="Buscar OC..."/>
				<i class="search_icon dw dw-search"></i>
				</div>
            </div>
        </div>
        <div class="panel panel-widget forms-panel">
        <div class="form-grids widget-shadow" data-example-id="basic-forms">
            <div class="form-title color-white">
                <h5>Ordenes de Compra</h5>
            </div>
            <div class="table-wrapper-scroll-y my-custom-scrollbar">
                <asp:GridView ID="gvOC" allowpaging="True" OnRowDataBound="gvOC_RowDataBound" AutoGenerateColumns="False" runat="server" emptydatatext="No hay información disponible." OnRowCommand="gvOC_RowCommand" 
                    CssClass="table table-bordered table-striped mb-0" DataKeyNames="OC_idOC,OC_numeroOC,PR_nombreContacto,OC_fechaEmision,OC_fechaEntrega,EOC_nombreEstadoOC"  
                    Style="text-align: center" OnPageIndexChanging="gvOC_PageIndexChanging" CellPadding="4" PageSize="5" GridLines="None">
                        <PagerStyle HorizontalAlign="Right" BackColor="#dee2e6"> </PagerStyle> 
                    <Columns>
                        <asp:BoundField DataField="OC_idOC" HeaderText="Id_OC" Visible="False" />
                        <asp:BoundField DataField="OC_numeroOC" HeaderText="N° de Compra" />
                        <asp:BoundField DataField="PR_nombreContacto" HeaderText="Proveedor" />
                        <asp:BoundField DataField="OC_fechaEmision" HeaderText="Fecha de Emisión" />
                        <asp:BoundField DataField="OC_fechaEntrega" HeaderText="Fecha de Entrega" />
                        <asp:BoundField DataField="EOC_nombreEstadoOC" HeaderText="Estado" />
                        <asp:TemplateField HeaderText="Descargar">
                            <ItemTemplate>
                                 <asp:LinkButton ID="btnDescargar" runat="server" class="btn btn-info" CommandName="Descargar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ><i class="fa fa-download"></i>&nbsp;Descargar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Recepcionar">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnRecepcionar" runat="server" class="btn btn-success" CommandName="Recepcionar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"><i class="fa fa-sign-in"></i>&nbsp;Recepcionar</asp:LinkButton>
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
                                                Style="text-align: center" OnPageIndexChanging="gvOC_PageIndexChanging" CellPadding="4" PageSize="5" AllowSorting="False" EnablePersistedSelection="True">
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
