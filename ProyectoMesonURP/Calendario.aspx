<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendario.aspx.cs" Inherits="ProyectoMesonURP.Calendario" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" /> 
    
    <style>
        .isOtherMonth
        {
          background-color: transparent !important;         
        }
        .isOtherMonth table td span 
        {
            display:none;
        }
        table tr td
        {
           vertical-align:top;                           
        }
        table tr td a
        {            
            float:right;
            padding:10px;
            font-size:18px;
        }
        table tr td span
        {
            
        }
       .table-bordered
       {
           border: 1px solid #080000;
       }
    </style>
  
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:DropDownList runat="server" ID="DrpMonth" >
           <asp:ListItem Value="1">January</asp:ListItem>
           <asp:ListItem Value="2">February</asp:ListItem>
           <asp:ListItem Value="3">March</asp:ListItem>
           <asp:ListItem Value="4">April</asp:ListItem>
           <asp:ListItem Value="5">May</asp:ListItem>
           <asp:ListItem Value="6">June</asp:ListItem>
           <asp:ListItem Value="7">July</asp:ListItem>
           <asp:ListItem Value="8">August</asp:ListItem>
           <asp:ListItem Value="9">September</asp:ListItem>
           <asp:ListItem Value="10">October</asp:ListItem>
           <asp:ListItem Value="11">November</asp:ListItem>
           <asp:ListItem Value="12">Decemeber</asp:ListItem>
       </asp:DropDownList>
        
        <asp:Button  runat="server" ID="btnChange" Text="Submit" OnClick="btnChange_Click"/>
        <br /><br /><br />
        <asp:Calendar  runat="server" ID="Calendar1" FirstDayOfWeek="Monday" BorderWidth="0" OnDayRender="Calendar1_DayRender"    ShowGridLines="false" 
           ShowTitle="false" >
           <SelectedDayStyle Width="100px" CssClass="table table-responsive" Height="100px" />
            <DayHeaderStyle BorderWidth="0" Font-Size="X-Large" CssClass="text-center" ForeColor="Brown" Width="100px" />
            <DayStyle Width="100px" Height="100px" CssClass="table table-bordered table-responsive" />
             
        </asp:Calendar>
         
    </div>
    </form>

    
</body>
</html>