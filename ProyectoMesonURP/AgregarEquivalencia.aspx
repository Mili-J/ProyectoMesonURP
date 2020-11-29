<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarEquivalencia.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.AgregarEquivalencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="women_main">
        <div class="grids">
      <div class="form-horizontal" runat="server" style="background-color:#f5f6f7; border-radius:1%">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms" style="margin-top: 34px;">
                            <div class="form-title color-white">
                                <h4>Añadir Equivalencia</h4>
                            </div>
                        </div>
          </div>
        </div>
        <div class="forms">
            <br />
                        <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">Categoria</label>
                            <div class="col-sm-8">                               
                              <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="true" CssClass="form-control form-color-letter" Style="width:25%" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>                              
                            </div>
                        </div>
                       <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">Insumo</label>
                            <div class="col-sm-8">                               
                              <asp:DropDownList ID="ddlInsumo" runat="server" AutoPostBack="true" CssClass="form-control form-color-letter" Style="width:25%" OnSelectedIndexChanged="ddlInsumo_SelectedIndexChanged"></asp:DropDownList>                              
                            </div>
                        </div>

                      <%-- <div class="form-group">
                            <label for="selector1" class="col-sm-2 control-label" style="left: 103px; top: 8px">Medida</label>
                                                           
                                <asp:Label ID="lblUnidad" runat="server" Text="1"></asp:Label>                                                           
                       </div>--%>

                       <div class="form-group">
                            <label for="selector1" class="col-sm-2 control-label">Medida</label>
                                    <div class="col-sm-8">                                            
                                <asp:TextBox ID="txtMedida" CssClass="form-control form-color-letter" ReadOnly="true" Style="width:25%" runat="server"></asp:TextBox>                        
                                        </div> 
                           <br />
                       </div>

                        <div class="form-group">
                            <label for="selector1" class="col-sm-2 control-label">Cantidad</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtCantidad" CssClass="form-control form-color-letter" Style="width:25%" runat="server"></asp:TextBox>
                            </div>
                       </div>

                       

                       <div class="form-group">
                            <label for="selector1" class="col-sm-2 control-label" style="left: 101px; top: 3px">Formato Cocina</label>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlFormatoCocina" CssClass="form-control form-color-letter"  Style="width:25%" runat="server"></asp:DropDownList>
                            </div>
                       </div>
            <asp:UpdatePanel ID="PanelAñadir" runat="server">
                            <ContentTemplate>
                                <p class="center-button">
                                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ID="btnAñadirEquivalencia" OnClick="btnAñadirEquivalencia_Click" />
                                    
                                </p>
                            </ContentTemplate>
                        </asp:UpdatePanel>
        </div>
     </div>
</asp:Content>
