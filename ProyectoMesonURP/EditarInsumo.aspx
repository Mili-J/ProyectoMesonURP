<%@ Page Title="Gestionar Insumo | Editar" Language="C#" AutoEventWireup="true" CodeBehind="EditarInsumo.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.EditarInsumo"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="women_main">
        <!-- start content -->
        <div class="pd-ltr-20 xs-pd-20-10">
            <div class="page-header">
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <h4 class="tittle-margin5">Actualizar Insumo</h4>
                    </div>
                </div>
            </div>

            <div class="pd-20 card-box mb-30">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h5>Detalles de Insumo</h5>
                    </div>
                </div>
                <div class="padding-top-30">
                    <div class="form-group row justify-content-center h-100">
                        <label class="col-sm-12 col-md-2 col-form-label">Insumo:</label>
                        <div class="col-sm-12 col-md-4">
                            <asp:TextBox ID="txtInsumo" CssClass="form-control" runat="server" onkeypress="return soloLetras(event);" placeholder="Ingrese un nombre"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvnombre" runat="server" ControlToValidate="txtInsumo" ErrorMessage="Campo Obligatorio" SetFocusOnError="True" Display="Dynamic" ForeColor="DarkRed" ValidationGroup="insumo"></asp:RequiredFieldValidator>    
                        </div>
                    </div>
                    <div class="form-group row justify-content-center h-100">
                        <label class="col-sm-12 col-md-2 col-form-label">Categoría:</label>
                        <div class="col-sm-12 col-md-4">
                            <asp:DropDownList ID="DDLCategoria" runat="server" Class="custom-select2 form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvcategoriaR" runat="server" ControlToValidate="DDLCategoria" SetFocusOnError="True" Display="Dynamic" ForeColor="DarkRed" InitialValue="--seleccionar--" ValidationGroup="insumo"><span id="ddl1">Seleccione una opción</span></asp:RequiredFieldValidator>
                        </div>
                    </div>
                  
                    <div class="form-group row justify-content-center h-100">
                        <label class="col-sm-12 col-md-2 col-form-label">Formato de Compra:</label>
                        
                        <div class="col-sm-12 col-md-4">
                            <asp:DropDownList ID="DDLFC" runat="server" Class="custom-select2 form-control" AutoPostBack="true" OnSelectedIndexChanged="FC_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvformatoC" runat="server" ControlToValidate="DDLFC" SetFocusOnError="True" Display="Dynamic" ForeColor="DarkRed" InitialValue="--seleccionar--" ValidationGroup="insumo"><span id="ddl2">Seleccione una opción</span></asp:RequiredFieldValidator>
                        </div>
                                           
                    </div>
                    <div class="form-group row justify-content-center h-100" runat="server" id="PanelMedida1" visible="false">
                        <label class="col-sm-12 col-md-2 col-form-label">Unidad de Medida:</label>
                       
                        <div class="col-sm-12 col-md-4">
                            <asp:DropDownList ID="DDLMedida" runat="server" Class="custom-select2 form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvmedida" runat="server" ControlToValidate="DDLMedida" SetFocusOnError="True" Display="Dynamic" ForeColor="DarkRed" InitialValue="--seleccionar--" ValidationGroup="insumo"><span id="ddl3">Seleccione una opción</span></asp:RequiredFieldValidator>          
                        </div>
                                            
                    </div>
                    <div class="form-group row justify-content-center h-100" runat="server" id="PanelMedida2" visible="false">
                        <label class="col-sm-12 col-md-2 col-form-label" ID="Label1" runat="server"> -------- </label>
                        <div class="col-sm-4 col-md-2">
                            <asp:TextBox ID="txtCantidadCo" runat="server" class="form-control" Text="1" Width="70px" />
                        </div>
                        <div class="col-sm-12 col-md-6">
                            <asp:DropDownList ID="DDLMedida2" runat="server" Class="custom-select2 form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvmedida2" runat="server" ControlToValidate="DDLMedida2" SetFocusOnError="True" Display="Dynamic" ForeColor="DarkRed" InitialValue="--seleccionar--" ValidationGroup="insumo"><span id="ddl4">Seleccione una opción</span></asp:RequiredFieldValidator>          
                        </div>
                    </div>
                    <div class="form-group row col-md-8 justify-content-center h-100" runat="server" id="PanelMedida3" visible="false">
                        <div class="col-sm-12 col-md-6">
                            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="ChckedChanged" AutoPostBack="True" />
                        </div>
                        <label class="col-sm-12 col-md-2 col-form-label" ID="Label2" runat="server">Pack  </label>
                        <div class="col-sm-4 col-md-2">
                            <asp:TextBox ID="TxtCantUn" runat="server" class="form-control" Text="1" TextMode="Number" min="1" Width="70px" onkeypress="return SoloNumeroIntDouble(event);" Visible="false"/>
                            <asp:RequiredFieldValidator ID="rfvTxtCantUn" runat="server" ControlToValidate="TxtCantUn" ErrorMessage="Campo Obligatorio" SetFocusOnError="True" Display="Dynamic"  ForeColor="DarkRed" ValidationGroup="insumo"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-sm-12 col-md-2 col-form-label" ID="Label3" runat="server"></label>
                    </div>
                    <div class="form-group row justify-content-center h-100" runat="server" id="Cantmin" visible="false">
                        <label class="col-sm-12 col-md-2 col-form-label">Cantidad Mínima: </label>
                        <div class="col-sm-4 col-md-2">
                            <asp:TextBox ID="TxtCantmin" runat="server" class="form-control" Text="0" TextMode="Number" min="0" onkeypress="return SoloNumeroIntDouble(event);" Width="70px"/>
                            <asp:RequiredFieldValidator ID="rfvtxtCantidad" runat="server" ControlToValidate="TxtCantmin" ErrorMessage="Campo Obligatorio" SetFocusOnError="True" Display="Dynamic"  ForeColor="DarkRed" ValidationGroup="insumo"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-sm-12 col-md-2 col-form-label" ID="Label5" runat="server"></label>
                    </div>
                </div>
            </div>
            <hr />
            <p class="center-button" style="margin-top: 49px; margin-bottom: 44px;">
                <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnGuardar" onserverclick="btnGuardar_ServerClick">Guardar</button>
                <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarInsumo.aspx';" class="btn btn-primary" />
            </p>
        </div>
    </div>   
    <script>
        function SoloNumeroIntDouble(ev) {
            var tecla = (document.all) ? ev.keyCode : ev.which;
            if (tecla == 8 || tecla == 13 || tecla == 0) return true;
            if (tecla >= 8226 && tecla <= 10175) { return false; }
            var regEx = /^[0-9\.]+$/i;
            return regEx.test(String.fromCharCode(tecla));
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

        function alertaInsumoDup() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'El insumo ya existe',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaError() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'LLene todos los campos',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaExito() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha logrado actualizar el insumo correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "GestionarInsumo";
                }
            })
        }
    </script>
</asp:Content>
