<%@ Page Title="Mesón URP | Calendario" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CalendariaMenu.aspx.cs" Inherits="ProyectoMesonURP.CalendariaMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="women_main">
          <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Planificar Menú</h2>
           </div>
           <div class="panel panel-widget forms-panel">
                <div class="form-grids widget-shadow" data-example-id="basic-forms">
                     <div class="form-title color-white">
                          <h4>Calendario del Mes</h4>
                     </div>
                <div>
                    <div class="table-wrapper-scroll-y">
                        <div>
                             <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Calendar ID="CalendarioMenu" runat="server" OnSelectionChanged="CalendarioMenu_SelectionChanged" 
                                        OnDayRender="CalendarioMenu_DayRender" FirstDayOfWeek="Monday" DayNameFormat="Full" NextPrevFormat="FullMonth" 
                                        SelectionMode="Day" DayStyle-BorderWidth="2px"  TodayDayStyle-BackColor="LightGray" BorderColor="#214E3F" BorderStyle="Solid" DayStyle-BorderColor="LightGray" DayStyle-BorderStyle="Solid">
                                    </asp:Calendar>
                                </ContentTemplate>
                             </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

                </div>
         </div>
    </div>
</asp:Content>
