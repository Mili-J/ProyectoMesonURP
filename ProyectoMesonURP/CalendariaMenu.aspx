<%@ Page Title="Mesón URP | Planificar Menú" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CalendariaMenu.aspx.cs" Inherits="ProyectoMesonURP.CalendariaMenu" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .calendarWrapper
        {
            background-color: #dee2e6;
            padding: 10px;
            display: inline-block;
            width: 100%;    
        }
        .calendarWrapper .myCalendar{
            width: 100%;
        }

        .myCalendar
        {
            background-color: #f2f2f2;
            border: none !important;
        }

        .myCalendar a
        {
            text-decoration: none;
        }

        .myCalendar .myCalendarTitle
        {
            text-transform:uppercase;
            letter-spacing: 2px;
            font-weight: bold;
            height: 70px;
            line-height: 70px;
            background-color: #dee2e6;
            color: #202342;
            border: none !important;
        }

        .myCalendar th.myCalendarDayHeader
        {
            text-transform: lowercase;
            height: 50px;
            text-align: center;
        }

        .myCalendar .myCalendarDayHeader:first-letter
        {
            text-transform: uppercase;
        }

        .myCalendar tr
        {
            border-bottom: solid 1px #ddd;
            height: 100px;
        }

        .myCalendar table tr
        {
            border-bottom: none !important;
        }

        .myCalendar tr:last-child td
        {
            border-bottom: none;
        }

        .myCalendar tr td.myCalendarDay, .myCalendar tr th.myCalendarDayHeader
        {
            border-right: solid 1px #ddd;
        }

        .myCalendar tr td:last-child.myCalendarDay, .myCalendar tr th:last-child.myCalendarDayHeader
        {
            border-right: none;
        }

        /*.myCalendar tr td.myCalendarDay
        {*/
            /*height: 100px;*/
        /*}*/

        .myCalendar td.myCalendarDay:nth-child(7) a
        {
            color: #c52e2e !important;
            font-weight: bold;
        }

        .myCalendar .myCalendarNextPrev
        {
            text-align: center;
        }

        .myCalendar .myCalendarNextPrev a
        {
            font-size: 1px;
            height: 30px;
        }

        .myCalendar .myCalendarNextPrev:nth-child(1) a
        {
            color: #dee2e6 !important;
            background: url("vendor/fontawesome-free/svgs/solid/chevron-left.svg") no-repeat center center;
        }

            .myCalendar .myCalendarNextPrev:nth-child(1) a:hover 
            {
                background: url("vendor/fontawesome-free/svgs/solid/chevron-circle-left.svg") no-repeat center center;
            }

        .myCalendar .myCalendarNextPrev:nth-child(3) a
        {
            color: #dee2e6 !important;
            background: url("vendor/fontawesome-free/svgs/solid/chevron-right.svg") no-repeat center center;
        }

            .myCalendar .myCalendarNextPrev:nth-child(3) a:hover
            {
                background: url("vendor/fontawesome-free/svgs/solid/chevron-circle-right.svg") no-repeat center center;
            }

        .myCalendar td.myCalendarSelector a
        {
            background-color: #ffffff;
        }

        .myCalendar .myCalendarDayHeader a,
        .myCalendar .myCalendarDay a,
        .myCalendar .myCalendarSelector a,
        .myCalendar .myCalendarNextPrev a
        {
            display: block;
            line-height: 20px;
        }

        .myCalendar .myCalendarToday
        {
            background-color: #595757;
            -webkit-box-shadow: 1px 1px 8px 1px #8f8f8f;
            box-shadow: 1px 1px 8px 1px #8f8f8f;
            border: 2px solid #595757;
            margin-left: -1px;
            margin-top: -1px;
            position: relative;
        }

            .myCalendar .myCalendarToday a
            {
                color: #ffffff !important;
                font-weight: bold;
            }

             .myCalendar .myCalendarToday a:after
                {
                    content: "HOY";
                    color: #000;
                    font-size: 0.5em;
                    display: inline-block;
                    pointer-events: none;
                    width: 100%;
                    float: left;
                }
                     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="women_main">
          <div class="page-header">
			<div class="row">
				<div class="col-md-6 col-sm-12">
					<div class="title">
						<h4>Planificar Menú</h4>
					</div>
				</div>
			</div>
		</div>
        <div class="pd-20 card-box mb-30">
            <div class="form-group">
                <div class="calendarWrapper">
                    <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Calendar ID="CalendarioMenu" runat="server" OnSelectionChanged="CalendarioMenu_SelectionChanged" CssClass="myCalendar"
                            OnDayRender="CalendarioMenu_DayRender" FirstDayOfWeek="Monday" DayNameFormat="Full" NextPrevFormat="FullMonth"
                            SelectionMode="Day" DayStyle-BorderWidth="2px"  TodayDayStyle-BackColor="LightGray" BorderColor="#214E3F" BorderStyle="Solid" DayStyle-BorderColor="LightGray" DayStyle-BorderStyle="Solid">
                            <OtherMonthDayStyle ForeColor="#b0b0b0" />
                            <DayStyle CssClass="myCalendarDay" />
                            <DayHeaderStyle CssClass="myCalendarDayHeader"/>
                            <SelectedDayStyle CssClass="myCalendarSelector" />
                            <TodayDayStyle CssClass="myCalendarToday" />
                            <SelectorStyle CssClass="myCalendarSelector" />
                            <NextPrevStyle CssClass="myCalendarNextPrev" />
                            <TitleStyle CssClass="myCalendarTitle" />
                        </asp:Calendar>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
               
        </div>
    </div>

    <script>
        function alertaError() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'No hay menú los días domingo.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
    </script>
</asp:Content>
