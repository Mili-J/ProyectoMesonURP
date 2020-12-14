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
		</div>
	 </div>
     <div class="pd-20 card-box">
        <div class="row pt-1">    
            <div class="col-sm-12 col-md-6">            
                <label class="control-label col-md-2">Paginación:</label>
                    <asp:DropDownList ID="ddlp" class="custom-select custom-select-sm form-control form-control-sm" style="width: auto; height: 38px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlp_SelectedIndexChanged">
                    </asp:DropDownList>
            </div>
            <div class="col-sm-12 col-md-3 pl-30"></div>
            <div class="col-sm-12 col-md-3 pl-30">
                <div class="search-icon-box bg-white box-shadow border-radius-10 mb-30">
                    <asp:TextBox ID="txtBuscarEquivalencia" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="fnombreEq_TextChanged" placeholder="Buscar OC..."/>
				<i class="search_icon dw dw-search"></i>
				</div>
            </div>
        </div>
     <div class="forms">
         <asp:UpdatePanel ID="panel1" runat="server">
                <ContentTemplate>
                    <div class="widget-shadow" style="width: 36%; margin-top: 14px;">
                        <div class="table-wrapper-scroll-y my-custom-scrollbar" runat="server">
                            <asp:GridView ID="gvEquivalencia" runat="server" DataKeyNames="E_cantidad,I_idInsumo" emptydatatext="No hay información disponible." AutoGenerateColumns="False" Style="text-align: center" CellPadding="4" GridLines="None" CssClass="table table-bordered table-striped mb-0">
                                <Columns>
                                    <asp:BoundField HeaderText="Insumo" DataField="I_nombreIngrediente" />
                                    <asp:BoundField HeaderText="Medida" DataField="I_nombreInsumo" />
                                    <asp:BoundField HeaderText="Cantidad" DataField="IR_cantidad" />
                                    <asp:BoundField HeaderText="Formato Cocina" DataField="IR_formatoMedida" />
                                   

                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditarEquivalencia" class="btn btn-outline-warning" runat="server" OnClick="btnEditarEquivalencia_Click"><i class="fa fa-pencil-square-o"></i>&nbsp;Editar</asp:LinkButton>
                                                                   
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    
                    </div>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
     </div>
     </div>
 </div>
</asp:Content>
