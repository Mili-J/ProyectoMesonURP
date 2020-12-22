<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarIngrediente.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.ConsultarIngrediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="women_main">
        <div class="grids">
      <div class="form-horizontal" runat="server" style="background-color:#f5f6f7; border-radius:1%">
                        <div class="form-grids widget-shadow" data-example-id="basic-forms" style="margin-top: 34px;">
                            <div class="form-title color-white">
                                <h4>Editar Ingrediente</h4>
                            </div>
                        </div>
          </div>
        </div>
        <div class="forms">
            <br />
                      
                      
                       <div class="form-group">
                            <label for="selector1" class="col-sm-2 control-label" style="left: 103px; top: 8px">Ingrediente:</label>
                                                           
                          <asp:TextBox ID="txtIngrediente" CssClass="form-control form-color-letter"  Style="width:25%" runat="server"></asp:TextBox>  
                       </div>

                       <div class="form-group">
                            <label for="selector1" class="col-sm-2 control-label">Peso Unitario:</label>
                                    <div class="col-sm-8">                                            
                                <asp:TextBox ID="txtPesoUnitario" CssClass="form-control form-color-letter"  Style="width:25%" runat="server"></asp:TextBox>                        
                                        </div> 
                           <br />
                       </div>

                        <div class="form-group">
                            <label for="selector1" class="col-sm-2 control-label">Cantidad:</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtCantidad" CssClass="form-control form-color-letter" Style="width:25%" runat="server"></asp:TextBox>
                            </div>
                       </div>
          
             <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">Categoria:</label>
                            <div class="col-sm-8">                               
                              <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="true" CssClass="form-control form-color-letter" Style="width:25%" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>                              
                            </div>
                        </div>

                        <div class="form-group">

                            <label for="focusedinput" class="col-sm-2 control-label">Insumo:</label>
                            <div class="col-sm-8"> 
                                <asp:TextBox ID="txtInsumo" runat="server"></asp:TextBox>
                              <asp:DropDownList ID="ddlInsumo" runat="server" AutoPostBack="true" CssClass="form-control form-color-letter" Style="width:25%"></asp:DropDownList>                              
                            </div>
                        </div>
    
                       

                       <div class="form-group">
                            <label for="selector1" class="col-sm-2 control-label" style="left: 101px; top: 3px">Equivalencia</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtEquivalencia" runat="server"></asp:TextBox>
                                <asp:DropDownList ID="ddlEquivalencia" AutoPostBack="true" CssClass="form-control form-color-letter" runat="server"  Height="4588px" Width="234px"></asp:DropDownList>
                            </div>
                       </div>
                        <asp:UpdatePanel ID="PanelAñadir" runat="server">
                            <ContentTemplate>
                                <p class="center-button">
                                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Guardar" ID="btnAñadirIngrediente" OnClick="btnAñadirIngrediente_Click" />
                                    
                                </p>
                            </ContentTemplate>
                        </asp:UpdatePanel>
            <asp:UpdatePanel ID="PanelVolver" runat="server">
                <ContentTemplate>
                    <p>
                        <asp:Button CssClass="btn btn-primary" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                    </p>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Label ID="lblMsj" runat="server" Text="Label"></asp:Label>
        </div>
     </div>
</asp:Content>
