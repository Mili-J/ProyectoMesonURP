<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarEquivalencia.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.ActualizarEquivalencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
         <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Actualizar Equivalencia</h2>
            </div>
    </div>
    <div class="forms">
         <div class="panel panel-widget forms-panel" style="width: 36%">               
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h4>Detalle del Insumo</h4>
                    </div>                    
                </div>
            </div>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <div class="form-group row justify-content-center h-100">
                    <label class="col-sm-12 col-md-2 col-form-label">Categoria</label>
                    <div class="col-sm-12 col-md-4">                             
                        <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"  ></asp:DropDownList>                              
                    </div>
                </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
         <asp:UpdatePanel ID="panelInsumo" runat="server">
             <ContentTemplate>
                  <div class="form-horizontal" runat="server" style="background-color:#f5f6f7; border-radius:1%">
                       <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">Insumo</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtInsumo" CssClass="form-control form-color-letter" ReadOnly="true" Style="width:25%" runat="server"></asp:TextBox>                                                               
                            </div>
                        </div>
                        <div class="form-group row justify-content-center h-100">
                    <label class="col-sm-12 col-md-2 col-form-label">Insumo</label>
                    <div class="col-sm-12 col-md-4">                          
                        <asp:DropDownList ID="ddlInsumo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlInsumo_SelectedIndexChanged"  ></asp:DropDownList>                              
                    </div>
                </div>
                  </div>
                  <div class="form-horizontal" runat="server" style="background-color:#f5f6f7; border-radius:1%">
                       <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">Medida</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtMedida" CssClass="form-control form-color-letter" Style="width:25%" ReadOnly="true" runat="server"></asp:TextBox>                                                               
                            </div>
                        </div>
                  </div>
                  <div class="form-horizontal" runat="server" style="background-color:#f5f6f7; border-radius:1%">
                       <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtCantidad" CssClass="form-control form-color-letter" Style="width:25%" runat="server"></asp:TextBox>                                                               
                            </div>
                        </div>
                  </div>
                   <div class="form-group">
                            <label for="focusedinput" class="col-sm-2 control-label">Formato Cocina</label>
                            <div class="col-sm-8">
                                 <asp:Label ID="Label1" runat="server">Actual:</asp:Label>
                                <asp:Label ID="lblFormatoC" runat="server"></asp:Label>
                            </div>
                            <div class="col-sm-8">    
                                
                                <asp:DropDownList ID="ddlFormatoCocina" runat="server" AutoPostBack="true" CssClass="form-control form-color-letter" Style="width:25%" OnSelectedIndexChanged="ddlFormatoC_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>

             </ContentTemplate>
         </asp:UpdatePanel>
          
                        <p class="center-button pt-3">
                            <asp:Button CssClass="btn btn-primary" runat="server" Text="Guardar" ID="btEditarEquivalencia" OnClick="btnEditarEquivalencia_Click" />
                                    
                                </p>
                          
            <%--<asp:UpdatePanel ID="PanelVolver" runat="server">
                <ContentTemplate>
                    <p>
                        <asp:Button CssClass="btn btn-primary" ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                    </p>
                </ContentTemplate>
            </asp:UpdatePanel>--%>
    </div>

</asp:Content>
