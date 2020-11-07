<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SeleccionarMenuDia.aspx.cs" Inherits="ProyectoMesonURP.SeleccionarMenuDia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Seleccionar el Menú del día</h2>
            </div>
        </div>
    <div class="form-horizontal" runat="server">  
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control1" ReadOnly="true"/>                            
                        </div>
                    </div>

                    <div class="form-group">
                       
                        <div class="col-sm-8">
                             <label for="focusedinput" class="col-sm-2 control-label">N° de raciones</label>
                            <asp:TextBox ID="txtNumRaciones" runat="server" placeholder="Ingrese el número de raciones" CssClass="form-control1"/>
                            

                        </div>
                    </div>

                    <div class="form-group">                      
                        
                        <div class="col-sm-8">
                            <label for="selector1" class="col-sm-2 control-label">Entradas</label>
                            <asp:DropDownList ID="DdlEntrada" runat="server" CssClass="form-control1" AutoPostBack="false">
                            </asp:DropDownList>
                        </div>
                    </div>
                     <div class="form-group">                      
                        
                        <div class="col-sm-8">
                            <label for="selector1" class="col-sm-2 control-label">Platos de fondo</label>
                            <asp:DropDownList ID="DdlFondo" runat="server" CssClass="form-control1" AutoPostBack="false">
                            </asp:DropDownList>
                        </div>
                    </div>



                      <div>
                        <asp:Button ID="btnAceptar" CssClass="btn btn-primary" runat="server" Text="Agregar Menu" OnClick="btnAceptar_Click"/>
                      </div>
                      <div>
                        <asp:Button ID="btnRegresar" CssClass="btn btn-primary" runat="server" Text="Regresar" OnClick="btnRegresar_Click"/>
                      </div>
        </div>

</asp:Content>
