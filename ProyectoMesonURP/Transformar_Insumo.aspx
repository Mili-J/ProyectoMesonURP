<%@ Page Title="Mesón URP | Transformar Insumo" Language="C#" AutoEventWireup="true" CodeBehind="Transformar_Insumo.aspx.cs" MasterPageFile="~/Master.Master" Inherits="ProyectoMesonURP.Transformar_Insumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   
   
    <div class="women_main">
           <div class="page-header">
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <h4 class="tittle-margin5">Transformar Insumo</h4>
                    </div>
                </div>
            </div>
        <div class="pd-20 card-box">
            <div class="row clearfix">
            <div class="col-md-5 col-sm-12 mb-30 pt-20" >
                <div class="form-title color-white">
                     <div class="form-grids widget-shadow" data-example-id="basic-forms">
                     <h5>Menú del día: <asp:Label ID="lblFecha" runat="server" ></asp:Label></h5>
                </div>
            </div>               
                <asp:Calendar ID="cldMenu" runat="server" style="width:40%" OnSelectionChanged="cldMenu_SelectionChanged" ondayrender="clMenu_OnDayRender" ></asp:Calendar>                
            </div>
            <div class="col-md-5">
            <div class="widget-shadow" style="width: 36%; margin-top: 14px;">
               <div class="table-wrapper-scroll-y my-custom-scrollbar" runat="server">
                    <asp:GridView ID="gvRecetaMenu" runat="server" EmptyDataText="No hay informacion disponible." AutoGenerateColumns="False" DataKeyNames="R_nombreReceta,MxR_numeroPorcion,R_numeroPorcion" Style="text-align:center" CellPadding="4" GridLines="None" CssClass="table table-bordered table-striped mb-0" OnRowCommand="gvRecetaMenu_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Nombre" DataField="R_nombreReceta" />  
                            <asp:BoundField HeaderText="Raciones Solicitadas" DataField="MxR_numeroPorcion" />                             
                            <asp:BoundField HeaderText="Porcion" DataField="R_numeroPorcion" />   
                            <asp:TemplateField HeaderText="Seleccionar">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnSeleccionarReceta" ImageUrl="img/correcto.png" CommandName="SeleccionarReceta" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>                        
                    </asp:GridView>
               </div>
           </div>
            <div style="text-align:center">
                            <label class="col-sm-12 col-md-5 col-form-label">Total Porciones</label>
                            <div class="col-sm-12 col-md-5">
                                <asp:TextBox ID="txtTotalPorciones" runat="server" class="form-control" ></asp:TextBox>
                            </div>
        </div>
        </div>
            <div >
                <div class="form-title color-white">
                     <div class="form-grids widget-shadow" data-example-id="basic-forms">
                     <h5>Transformar: 
                     <asp:Label ID="lblMenu" runat="server" ></asp:Label></h5>
                </div>
            </div>
                <br />
           <div class="col-md-5 col-sm-12 mb-30 pt-20">
            <div class="widget-shadow" style="width: 36%; margin-top: 14px;">
               <div class="table-wrapper-scroll-y my-custom-scrollbar" runat="server">
                    <asp:GridView ID="gvIngrediente" runat="server" EmptyDataText="No hay informacion disponible." AutoGenerateColumns="false" DataKeyNames="I_nombreIngrediente,IR_cantidad,IR_formatoMedida,I_nombreInsumo" Style="text-align:center" CellPadding="4" GridLines="None" CssClass="table table-bordered table-striped mb-0">
                        <Columns>
                            <asp:BoundField HeaderText="Ingrediente" DataField="I_nombreIngrediente" />  
                            <asp:BoundField HeaderText="Cantidad" DataField="IR_cantidad" />    
                            <asp:BoundField HeaderText="Medida" DataField="IR_formatoMedida" />    
                            <asp:BoundField HeaderText="Insumo Origen" DataField="I_nombreInsumo" />                                  
                        </Columns>                        
                    </asp:GridView>
               </div>
           </div>
        </div>
       <div class="col-md-5 col-sm-12 mb-30 pt-20">
            <div class="widget-shadow" style="width: 36%; margin-top: 14px;">
               <div class="table-wrapper-scroll-y my-custom-scrollbar" runat="server">
                    <asp:GridView ID="gvInsumosTransformados" runat="server" EmptyDataText="No hay informacion disponible." AutoGenerateColumns="False" DataKeyNames="I_nombreInsumo,M_nombreMedida,E_cantidad" Style="text-align:center" CellPadding="4" GridLines="None" CssClass="table table-bordered table-striped mb-0" OnRowCommand="gvRecetaMenu_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Insumo" DataField="I_nombreInsumo" /> 
                            <asp:BoundField HeaderText="Cantidad" DataField="E_cantidad" />                             
                            <asp:BoundField HeaderText="Medida" DataField="M_nombreMedida" />                                                         
                        </Columns>                        
                    </asp:GridView>
               </div>
           </div>
       
        </div>
                <asp:TextBox ID="txtprueba" runat="server"></asp:TextBox>
        <div style="text-align:center">
                
                       <div class="col-sm-12 col-md-5">
                           <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                       </div>
        </div>
               
            </div>                   

        </div>                          
    </div>
       <!-- Alertas -->
        </div>
    <script src="js/sweetalert.js">
    </script>
    <script>
        function alertaExito() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha logrado transformar insumo',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "TransformarInsumo";
                }
            })
        }
    </script>
    

    
    </>
</asp:Content>


