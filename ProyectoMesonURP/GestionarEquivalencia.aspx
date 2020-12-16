<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarEquivalencia.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.GestionarEquivalencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .mb-0 { }
    </style>
    <link rel="stylesheet" type="text/css" href="vendors/styles/core.css">
    <link rel="stylesheet" type="text/css" href="vendors/styles/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="women_main">
     <div class="page-header">
		<div class="row">
			<div class="col-md-10 col-sm-12">
				<div class="title">
					<h4>Gestionar Equivalencia</h4>
				</div>
			</div>
           <div>
               <asp:LinkButton class="btn btn-primary" runat="server" OnClick="btnAnadirEquivalencia_Click"><i class="fa fa-plus-circle"></i>&nbsp;Añadir Equivalencia</asp:LinkButton>              
           </div>
            <br />

             <div>
               <asp:LinkButton class="btn btn-primary" runat="server" OnClick="btnVerIngredientes_Click"><i class="fa fa-plus-circle"></i>&nbsp;Ver Ingredientes</asp:LinkButton>              
           </div>
		</div>
	 </div>
     <div class="pd-20 card-box">
        <div class="row pt-1">    
            <div class="col-sm-12 col-md-6">            
                <label class="control-label col-md-2">Paginación:</label>
                    <asp:DropDownList ID="ddlp" class="custom-select custom-select-sm form-control form-control-sm" style="width: auto; height: 38px" runat="server" AutoPostBack="true" >
                    </asp:DropDownList>
            </div>
            <div class="col-sm-12 col-md-3 pl-30"></div>
            <div class="col-sm-12 col-md-3 pl-30">
                <div class="search-icon-box bg-white box-shadow border-radius-10 mb-30">
                    <asp:TextBox ID="txtBuscarEquivalencia" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="fnombreEq1_TextChanged" placeholder="Buscar Equivalencia..."/>
				<i class="search_icon dw dw-search"></i>
				</div>
            </div>
        </div>
     <div class="panel panel-widget forms-panel" >
        <div class="form-grids widget-shadow" data-example-id="basic-forms">
            <div class="form-title color-white">
                <h5>Equivalencia de los Insumos</h5>
            </div>
       <div class="w3-row-padding">
         <asp:UpdatePanel ID="panel1" runat="server">
                <ContentTemplate>
                        <div class="table-wrapper-scroll-y my-custom-scrollbar" runat="server">
                            <asp:GridView ID="gvEquivalencia" runat="server" OnRowCommand="GVEquivalencia_RowCommand" DataKeyNames="E_idEquivalencia,E_cantidad,I_nombreInsumo,M_nombreMedida,FCO_nombreFormatoCocina" emptydatatext="No hay información disponible." AutoGenerateColumns="False" Style="text-align: center" CellPadding="4" GridLines="None" CssClass="table table-bordered table-striped mb-0" >
                                <Columns>
                                    <asp:BoundField DataField="E_idEquivalencia" HeaderText="E_idEquivalencia" Visible="false" />
                                    <asp:BoundField HeaderText="Insumo" DataField="I_nombreInsumo" />
                                    <asp:TemplateField HeaderText="Medida">
                                        <ItemTemplate>
                                              <%# "1" + " " + Eval("M_nombreMedida")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Equivalencia">
                                        <ItemTemplate>
                                              <%# Eval("E_cantidad") + " " + Eval("FCO_nombreFormatoCocina")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <asp:Button CssClass="btn btn-primary" ID="btnEditarEquivalencia" runat="server"  CommandName="EditarEquivalencia" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Editar" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                   
                                    <asp:TemplateField HeaderText="Ver">
                                        <ItemTemplate>
                                            <%--<asp:LinkButton ID="btnVerEquivalencia" class="btn btn-outline-warning" runat="server" CommandName="VerEquivalencia" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  ><i class="fa fa-pencil-square-o"></i>&nbsp;Editar</asp:LinkButton>--%>
                                                                   
                                            <asp:Button CssClass="btn btn-primary" ID="btnVer" runat="server"  CommandName="VerEquivalencia" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Ver" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                   
                                </Columns>
                            </asp:GridView>
                             
                        </div>
                    </div>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
       </div>
        </div>
     </div>
   </div>
 </div>
</asp:Content>
