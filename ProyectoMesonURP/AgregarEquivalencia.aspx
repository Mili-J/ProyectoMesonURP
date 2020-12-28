<%@ Page Title="Agregar Equivalencia" Language="C#" AutoEventWireup="true" CodeBehind="AgregarEquivalencia.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.AgregarEquivalencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <div class="page-header">
            <div class="row">
                <div class="col-md-6 col-sm-12">
                    <div class="title">
                        <h4>Añadir Equivalencia</h4>
                    </div>
                </div>
            </div>
        </div>
        <div class="pd-20 card-box mb-30">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h5>Equivalencia de un Insumo</h5>
                </div>
            </div>
            <div class="padding-top-30">
                 <div class="form-group row col-md-8">
                        <label >Insumo</label>
                        <div class="col-sm-12 col-md-6">
                            <asp:TextBox ID="txtInsumo" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                 <div class="form-group row col-md-8">
                        <label >Ingrediente</label>
                        <div class="col-sm-12 col-md-6">
                            <asp:TextBox ID="txtIngrediente" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <div class="form-group row justify-content-center h-100">
                            <label class="col-sm-12 col-md-2 col-form-label">Formato Cocina</label>
                            <div class="col-sm-12 col-md-4">
                                <asp:DropDownList ID="ddlFormatoCocina" AutoPostBack="true" class="custom-select2 form-control" runat="server" OnSelectedIndexChanged="ddlFormatoCocina_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                 <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                     <div class="form-group row col-md-8">
                        <label >Cantidad</label>
                        <div class="col-sm-12 col-md-6">
                            <asp:TextBox ID="txtCantidad" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
               <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                            <div class="form-group row col-md-8">
                        <label >Medida</label>
                        <div class="col-sm-12 col-md-6">
                                <%--<asp:TextBox ID="txtMedida" BackColor="Transparent" BorderColor="White" BorderStyle="None" ReadOnly="true" runat="server" ></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlMedida" runat="server" CssClass="form-control"></asp:DropDownList>
                           </div>
                    </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="panel panel-widget forms-panel">
                            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                                <div class="form-title color-white">
                                    <h5>Ingredientes</h5>
                                </div>
                                <%--  <asp:UpdatePanel ID="panel" runat="server">
                        <ContentTemplate>--%>
                                <div class="table-wrapper-scroll-y my-custom-scrollbar">
                                    <asp:GridView ID="gvEquivalencia" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false" OnRowDataBound="gvEquivalencia_OnRowDataBound"
                                        DataKeyNames="E_cantidad, MXFC_idMedidaFCocina, M_nombreMedida, FCO_nombreFormatoCocina"
                                        CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" OnSelectedIndexChanged="gvEquivalencia_SelectedIndexChanged">
                                        <Columns>
                                            
                                            <asp:BoundField HeaderText="Cantidad" DataField="E_cantidad" />
                                            <asp:BoundField HeaderText="IDFormatoCocinaXMedida" DataField="MXFC_idMedidaFCocina" />
                                            <asp:BoundField HeaderText="Medida" DataField="M_nombreMedida" />
                                            <asp:BoundField HeaderText="nombreFormatoCocina" DataField="FCO_nombreFormatoCocina" />
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
                                   <%-- <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnAgregar" onserverclick="btnEgresar_ServerClick">Egresar</button>
                                    --%>  <asp:Button CssClass="btn btn-danger" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                                 </p>
                                <%--   </ContentTemplate>
                    </asp:UpdatePanel>--%>
                            </div>
                        </div>
               
              
                        <p class="center-button pt-3">
                          <%--  <asp:Button CssClass="btn btn-primary" runat="server" Text="Guardar" ID="btnAñadirEquivalencia" OnClick="btnAñadirEquivalencia_Click" />--%>
                           <asp:Button CssClass="btn btn-outline-success" runat="server" Text="Añadir" ID="btnAñadirEquivalencia" OnClick="btnAñadirEquivalencia_Click" UseSubmitBehavior="false" />
                        <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnGuardar" onserverclick="btnGuardar_ServerClick">Guardar</button>
                            </p>
                 

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
