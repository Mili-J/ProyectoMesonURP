<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CalendariaMenu.aspx.cs" Inherits="ProyectoMesonURP.CalendariaMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Calendar ID="CalendarioMenu" runat="server" OnSelectionChanged="CalendarioMenu_SelectionChanged" OnDayRender="CalendarioMenu_DayRender"></asp:Calendar>

</asp:Content>

