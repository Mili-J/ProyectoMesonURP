<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CalendariaMenu.aspx.cs" Inherits="ProyectoMesonURP.CalendariaMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Calendar ID="CalendarioMenu" runat="server" OnSelectionChanged="CalendarioMenu_SelectionChanged" 
        OnDayRender="CalendarioMenu_DayRender" FirstDayOfWeek="Monday" DayNameFormat="Full" NextPrevFormat="FullMonth" 
        SelectionMode="Day" TodayDayStyle-BackColor="YellowGreen"></asp:Calendar>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
