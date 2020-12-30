<%@ Page Title="MesónURP | Gestionar Equivalencia" Language="C#" AutoEventWireup="true" CodeBehind="GestionarEquivalencia.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.GestionarEquivalencia" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .mb-0 {
        }
    </style>
    <link rel="stylesheet" type="text/css" href="vendors/styles/core.css">
    <link rel="stylesheet" type="text/css" href="vendors/styles/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <div class="page-header">
            <div class="row">
                <div class="col-md-6 col-sm-12">
                    <div class="title">
                        <h4>Gestionar Equivalencia</h4>
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
                        <asp:TextBox ID="txtBuscarIngrediente" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="fnombreIng_TextChanged" onkeypress="return soloLetras(event);" placeholder="Buscar Ingrediente..." />
                        <i class="search_icon dw dw-search"></i>
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div class="col-md-3">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                    <label>Categoria</label>
                    <asp:DropDownList ID="ddlCategoria" class="custom-select2 form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="rfvddlCategoria" runat="server" ControlToValidate="ddlCategoria" Display="Static" ForeColor="DarkRed" InitialValue="--seleccionar--" ValidationGroup="equivalencia1"><span id="CategoriaRFV">Seleccione una opción</span></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
           
                <div class="col-md-3">
                   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                      <ContentTemplate>
                    <label>Insumo</label>
                    <asp:DropDownList ID="ddlInsumo" runat="server" class="custom-select2 form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvddlInsumo" runat="server" ControlToValidate="ddlInsumo" Display="Static" ForeColor="DarkRed" InitialValue="--seleccionar--" ValidationGroup="equivalencia1"><span id="InsumoRFV">Seleccione una opción</span></asp:RequiredFieldValidator>
                     </ContentTemplate>
                  </asp:UpdatePanel>
                </div>
                
                <div class="col-md-3">
                    <label>Ingrediente</label>
                    <asp:TextBox ID="txtIngrediente" CssClass="form-control" runat="server"></asp:TextBox> 
                    <asp:RequiredFieldValidator ID="rfvtxtIngrediente" runat="server" ControlToValidate="txtIngrediente" ErrorMessage="Campo Obligatorio" Display="Static" ForeColor="DarkRed" ValidationGroup="equivalencia1"></asp:RequiredFieldValidator>          
                </div>
                <div class="col-md-3 pt-20">
                    <div style="margin: 0px auto; width:120px">
                          <asp:LinkButton runat="server" OnClick="btnAñadirIngrediente_Click" CssClass="btn btn-primary" ValidationGroup="equivalencia1"><i class="fa fa-plus-circle"></i>&nbsp;Añadir</asp:LinkButton>
                    </div>
                </div>
            </div>
            <asp:TextBox ID="txtPesoU" CssClass="form-control" runat="server" Text="0" Visible="false"></asp:TextBox>
            <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" Text="0" Visible="false"></asp:TextBox>
            <div class="padding-bottom-30"></div>
            <div class="panel panel-widget forms-panel">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h5>Equivalencia de los Ingredientes</h5>
                    </div>
                    <div class="w3-row-padding">
                        <div class="table-wrapper-scroll-y my-custom-scrollbar" runat="server">
                            <asp:GridView ID="gvEquivalencia" allowpaging="True" runat="server" OnRowCommand="GVEquivalencia_RowCommand" DataKeyNames="I_idInsumo,I_nombreInsumo,I_idIngrediente,I_nombreIngrediente"
                                EmptyDataText="No hay información disponible." AutoGenerateColumns="False" Style="text-align: center" CellPadding="4" PageSize="5" GridLines="None" CssClass="table table-bordered table-striped mb-0" OnPageIndexChanging="gvEquivalencia_PageIndexChanging">
                               <PagerStyle HorizontalAlign="Right" BackColor="#dee2e6"> </PagerStyle> 
                                <Columns>
                                    <asp:BoundField DataField="I_idInsumo" HeaderText="I_idInsumo" Visible="false" />
                                    <asp:BoundField HeaderText="Insumo" DataField="I_nombreInsumo" />
                                    <asp:BoundField DataField="I_idIngrediente" HeaderText="I_idIngrediente" Visible="false" />
                                    <asp:BoundField DataField="I_nombreIngrediente" HeaderText="Ingrediente" />
                                    <%-- <asp:TemplateField HeaderText="Medida">
                                        <ItemTemplate>
                                            <%# "1" + " " + Eval("M_nombreMedida")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Equivalencia">
                                        <ItemTemplate>
                                            <%# Eval("E_cantidad") + " " + Eval("FCO_nombreFormatoCocina")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="Agregar Equivalencia">
                                        <ItemTemplate>
                                            <asp:Button CssClass="btn btn-primary" ID="btnAgregarEquivalencia" runat="server" CommandName="AgregarEquivalencia" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Agregar Equivalencia" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ver">
                                        <ItemTemplate>
                                            <asp:Button CssClass="btn btn-primary" ID="btnVer" runat="server" CommandName="VerEquivalencia" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Ver" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>

            </div>
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

        function myalert() {
            var ingrediente = document.getElementById('<%= txtIngrediente.ClientID %>').value;
            Swal.fire({
                title: 'Oh, no!',
                text: 'Ya existe un ingrediente con el nombre ' + ingrediente,
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function myalertCorrecto() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'El ingrediente fue registrado correctamente.',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = 'GestionarEquivalencia';
                }
            })
        }
    </script>
</asp:Content>
