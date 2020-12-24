<%@ Page Title="Mesón URP | Dashboard" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ProyectoMesonURP.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
#chartdiv {
  width: 100%;
  height: 500px;
}
#chartdiv1 {
  width: 100%;
  height: 500px;
}
</style>
    <!-- Resources Pie -->
<script src="https://cdn.amcharts.com/lib/4/core.js"></script>
<script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>

    <!-- Resources Bar-->
<script src="https://cdn.amcharts.com/lib/4/core.js"></script>
<script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/moonrisekingdom.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="chartPie"></div>  
    <div id="chartBar"></div> 

    <!-- Chart code Pie -->
    <script>
        am4core.ready(function () {

            // Themes begin
            am4core.useTheme(am4themes_animated);
            // Themes end

            var chart = am4core.create("chartPie", am4charts.PieChart3D);
            chart.hiddenState.properties.opacity = 0; // this creates initial fade-in

            chart.legend = new am4charts.Legend();

            chart.data = <%=CargarEstadoOc()%>;

        var series = chart.series.push(new am4charts.PieSeries3D());
        series.dataFields.value = "Total";
        series.dataFields.category = "Estado";
        series.colors.list = [
            am4core.color("#D2B17B"),
            am4core.color("#D07C4E"),
            am4core.color("#FF6F91"),
            am4core.color("#FF9671"),
            am4core.color("#FFC75F"),
            am4core.color("#F9F871"),
        ];

    }); // end am4core.ready()
    </script>

     <!-- Chart code Bar -->
    <script>
        am4core.ready(function () {

            // Themes begin
            am4core.useTheme(am4themes_moonrisekingdom);
            am4core.useTheme(am4themes_animated);
            // Themes end

            // Create chart instance
            var chart = am4core.create("chartBar", am4charts.XYChart);
            chart.scrollbarX = new am4core.Scrollbar();

            // Add data
            chart.data = <%=CargarInsumoD()%>;

            // Create axes
            var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
            categoryAxis.dataFields.category = "Insumo";
            categoryAxis.renderer.grid.template.location = 0;
            categoryAxis.renderer.minGridDistance = 30;
            categoryAxis.renderer.labels.template.horizontalCenter = "right";
            categoryAxis.renderer.labels.template.verticalCenter = "middle";
            categoryAxis.renderer.labels.template.rotation = 270;
            categoryAxis.tooltip.disabled = true;
            categoryAxis.renderer.minHeight = 110;

            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
            valueAxis.renderer.minWidth = 50;

            // Create series
            var series = chart.series.push(new am4charts.ColumnSeries());
            series.sequencedInterpolation = true;
            series.dataFields.valueY = "Total";
            series.dataFields.categoryX = "Insumo";
            series.tooltipText = "[{categoryX}: bold]{valueY}[/] {Medida}";
            series.columns.template.strokeWidth = 0;

            series.tooltip.pointerOrientation = "vertical";

            series.columns.template.column.cornerRadiusTopLeft = 10;
            series.columns.template.column.cornerRadiusTopRight = 10;
            series.columns.template.column.fillOpacity = 0.8;

            // on hover, make corner radiuses bigger
            var hoverState = series.columns.template.column.states.create("hover");
            hoverState.properties.cornerRadiusTopLeft = 0;
            hoverState.properties.cornerRadiusTopRight = 0;
            hoverState.properties.fillOpacity = 1;

            series.columns.template.adapter.add("fill", function (fill, target) {
                return chart.colors.getIndex(target.dataItem.index);
            });

            // Cursor
            chart.cursor = new am4charts.XYCursor();

        }); // end am4core.ready()
    </script>
</asp:Content>
