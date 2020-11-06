<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SC_Prueba.aspx.cs" Inherits="ProyectoMesonURP.SC_Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvprueba" runat="server"  DataKeyNames="I_idInsumo,I_nombreInsumo,CI_nombreCategoria,I_cantidad,I_cantidadmin,I_pesoTotal,El_nombreEstado" AutoGenerateColumns="false" Width="359px">
                <Columns>
                   <asp:BoundField DataField="I_idInsumo" HeaderText="Id_Insumo" />
                   <asp:BoundField DataField="I_nombreInsumo" HeaderText="Insumo" />
                   <asp:BoundField DataField="CI_nombreCategoria" HeaderText="Categoria" />
                   <asp:BoundField DataField="I_cantidad" HeaderText="Cantidad" />
                   <asp:BoundField DataField="I_cantidadmin" HeaderText="Cantidad minima" />
                   <asp:BoundField DataField="I_pesoTotal" HeaderText="Peso Total" />
                   <asp:BoundField DataField="El_nombreEstado" HeaderText="Estado" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
