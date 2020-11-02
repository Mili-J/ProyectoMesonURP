<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manejar_Stock_Prueba.aspx.cs" Inherits="ProyectoMesonURP.Manejar_Stock_Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server"  DataKeyNames="R_idReceta,R_nombreReceta,R_numeroPorcion,R_descripcion" OnRowCommand="GridView_RowCommand" AutoGenerateColumns="false" Width="359px">
                <Columns>
                  
                    <asp:BoundField HeaderText="Nombre" DataField="R_nombreReceta" />
                    <asp:BoundField HeaderText="Porcion" DataField="R_numeroPorcion" />
                    <asp:BoundField HeaderText="Descripcion" DataField="R_descripcion"/>
                    <asp:TemplateField HeaderText="Transformar">
                        <ItemTemplate>
                            <asp:Button ID="btnTransformar" runat="server" CommandName="TransformarI" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  OnClick="btnTransformar_Click" Text="Transformar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
