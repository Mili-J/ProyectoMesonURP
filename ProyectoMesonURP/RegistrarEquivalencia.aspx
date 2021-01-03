<%@ Page Title="Equivalencia | Agregar Equivalencia" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistrarEquivalencia.aspx.cs" Inherits="ProyectoMesonURP.RegistrarEquivalencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="women_main">
        <!-- start content -->
        <div class="pd-ltr-20 xs-pd-20-10">
            <div class="page-header">
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <h4 class="tittle-margin5">Añadir Equivalencia</h4>
                    </div>
                </div>
            </div>
       <div class="row clearfix">
            <div class="col-md-5 col-sm-12 mb-30">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h5>Detalle de la Equivalencia</h5>
                    </div>
                </div>
            <div class="pd-20 card-box height-100-p pt-5">
                   <div class="form-group row justify-content-center">
                        <label class="col-sm-12 col-md-5 col-form-label">Insumo</label>
                        <div class="col-sm-12 col-md-6">
                        <asp:TextBox ID="txtInsumo" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                   <div class="form-group row justify-content-center">
                            <label class="col-sm-12 col-md-5 col-form-label">Ingrediente</label>
                            <div class="col-sm-12 col-md-6">
                            <asp:TextBox ID="txtIngrediente" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                  <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                         <div class="form-group row justify-content-center">
                            <label class="col-sm-12 col-md-5 col-form-label">Formato Cocina</label>
                            <div class="col-sm-12 col-md-6">
                                <asp:DropDownList ID="ddlFormatoCocina" AutoPostBack="true" class="custom-select2 form-control" runat="server" OnSelectedIndexChanged="ddlFormatoCocina_SelectedIndexChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlFormatoCocina" runat="server" ControlToValidate="ddlFormatoCocina" Display="Static" ForeColor="DarkRed" InitialValue="--seleccionar--" ValidationGroup="equivalencia1"><span id="formatoCRFV">Seleccione una opción</span></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                    <div class="form-group row justify-content-center">
                        <label class="col-sm-12 col-md-5 col-form-label">Cantidad</label>
                        <div class="col-sm-12 col-md-6">
                            <asp:TextBox ID="txtCantidad" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvtxtCantidad" runat="server" ControlToValidate="txtCantidad" ErrorMessage="Campo Obligatorio" Display="Static" ForeColor="DarkRed" ValidationGroup="equivalencia1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="form-group row justify-content-center">
                        <label class="col-sm-12 col-md-5 col-form-label">Medida</label>
                        <div class="col-sm-12 col-md-6">
                                <%--<asp:TextBox ID="txtMedida" BackColor="Transparent" BorderColor="White" BorderStyle="None" ReadOnly="true" runat="server" ></asp:TextBox>--%>
                            <asp:DropDownList ID="ddlMedida" runat="server" class="custom-select2 form-control"></asp:DropDownList>
                             <asp:RequiredFieldValidator ID="rfvddlMedida" runat="server" ControlToValidate="ddlMedida" Display="Static" ForeColor="DarkRed" InitialValue="--seleccionar--" ValidationGroup="equivalencia1"><span id="MedidaRFV">Seleccione una opción</span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <p class="center-button">
                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ID="btnAñadirEquivalencia" OnClick="btnAñadirEquivalencia_Click" UseSubmitBehavior="false" ValidationGroup="equivalencia1"/>
                </p>
            </div>
                
            </div>

            <div class="col-md-7 col-sm-12 mb-30">
                 <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h5>Detalle de las Equivalencias del Ingrediente</h5>
                        </div>
                    </div>
                 <div class="pd-20 card-box height-100-p pt-5">
                   <div class="panel panel-widget forms-panel">
                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
                               
                        <asp:GridView ID="gvEquivalencia" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false" OnRowDataBound="gvEquivalencia_OnRowDataBound"
                            DataKeyNames="E_cantidad, MXFC_idMedidaFCocina, M_nombreMedida, FCO_nombreFormatoCocina"
                            CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" OnSelectedIndexChanged="gvEquivalencia_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField HeaderText="Formato Cocina" DataField="FCO_nombreFormatoCocina" />
                                <asp:BoundField HeaderText="Cantidad" DataField="E_cantidad" />
                                <asp:BoundField HeaderText="IDFormatoCocinaXMedida" DataField="MXFC_idMedidaFCocina" Visible="false"/>
                                <asp:BoundField HeaderText="Medida" DataField="M_nombreMedida" />
                            </Columns>
                            <SelectedRowStyle BackColor="SteelBlue" />
                        </asp:GridView>
                       </div>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAñadirEquivalencia" />
                            <asp:PostBackTrigger ControlID="btnGuardar" />
                        </Triggers>
                    <asp:Label ID="lblIndex" runat="server" Visible="false"></asp:Label>
                    <hr />
                    <p class="center-button">
                        <asp:Button CssClass="btn btn-danger" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                    </p>
                    <%--   </ContentTemplate>
        </asp:UpdatePanel>--%>
                    </div>
                 </div>
               
              
              <%--  <p class="center-button pt-3">--%>
                    <%--  <asp:Button CssClass="btn btn-primary" runat="server" Text="Guardar" ID="btnAñadirEquivalencia" OnClick="btnAñadirEquivalencia_Click" />--%>
                    
               <%-- <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnGuardar" onserverclick="btnGuardar_ServerClick">Guardar</button>--%>
                <%--</p>--%>
            </div>
       </div>
       </div>
    </div>
    <script>
        function alertaExito() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha logrado registrar correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "GestionarEquivalencia";
                }
            })
        }
        function alertaDuplicado() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'No puedes añadir la misma equivalencia',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
    </script>
</asp:Content>
