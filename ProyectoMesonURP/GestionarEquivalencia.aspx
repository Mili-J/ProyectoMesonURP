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
                        <asp:TextBox ID="txtBuscarIngrediente" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="fnombreIng_TextChanged" placeholder="Buscar Ingrediente..." />
                        <i class="search_icon dw dw-search"></i>
                    </div>
                </div>
            </div>
            <div class="panel panel-widget forms-panel">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h5>Equivalencia de los Ingredientes</h5>
                    </div>
                    <div class="w3-row-padding">
                        <div class="table-wrapper-scroll-y my-custom-scrollbar" runat="server">
                            <asp:GridView ID="gvEquivalencia" runat="server" OnRowCommand="GVEquivalencia_RowCommand" DataKeyNames="I_idInsumo,I_nombreInsumo,I_idIngrediente,I_nombreIngrediente" 
                                EmptyDataText="No hay información disponible." AutoGenerateColumns="False" Style="text-align: center" CellPadding="4" GridLines="None" CssClass="table table-bordered table-striped mb-0">
                                <Columns>
                                    <asp:BoundField DataField="I_idInsumo" HeaderText="I_idInsumo" Visible="false" />
                                    <asp:BoundField HeaderText="Insumo" DataField="I_nombreInsumo" />
                                    <asp:BoundField DataField="I_idIngrediente" HeaderText="I_idIngrediente" Visible="false" />
                                    <asp:BoundField DataField="I_nombreIngrediente" HeaderText="Ingrediente"/>
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

                                    <asp:TemplateField HeaderText="Agregar Equivalencia">
                                        <ItemTemplate>
                                            <asp:Button CssClass="btn btn-primary" ID="btnEditarEquivalencia" runat="server" CommandName="EditarEquivalencia" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Editar" />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Ver">
                                        <ItemTemplate>
                                            <%--<asp:LinkButton ID="btnVerEquivalencia" class="btn btn-outline-warning" runat="server" CommandName="VerEquivalencia" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  ><i class="fa fa-pencil-square-o"></i>&nbsp;Editar</asp:LinkButton>--%>

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
</asp:Content>
