<%@ Page Title="Mesón URP | Dashboard" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ProyectoMesonURP.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
#chartPie {
  width: 100%;
  height: 500px;
}
#chartBar {
  width: 100%;
  height: 500px;
}
#chartBarCompra {
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

    <!-- Resources Bar Compra -->
<script src="https://cdn.amcharts.com/lib/4/core.js"></script>
<script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/moonrisekingdom.js"></script>
<script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="pd-ltr-20 xs-pd-20-10">
            <div class="min-height-200px">
                <div class="page-header">
                    <div class="row">
                        <div class="col-md-12 col-sm-12">
                            <h4 class="tittle-margin5">Dashboard</h4>
                        </div>
                    </div>
               </div>
        <div class="pd-20 card-box mb-30">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                    <div class="form-title color-white">
                        <h5>Seguimiento de los insumos a recepcionar</h5>
                    </div>
                <div class="form-group row justify-content-center">
                    <label class="col-sm-12 col-md-5 col-form-label">Fecha a filtrar</label>
                    <div class="col-sm-12 col-md-6">
                        <asp:TextBox ID="txtFechaEmision" runat="server" class="form-control" TextMode="Date"  AutoPostBack="True"  OnTextChanged="fFecha_TextChanged"/>
                    </div>
                </div>
                </div>
            
            <div class="content"> <asp:Label ID="Label1" runat="server" Text=""></asp:Label> </div>
            <div id="chartBarCompra" class="pt-30"></div> 
            <div class="content"> <asp:Label ID="lblMensajeAyuda" runat="server" Text="No hay información disponible" ></asp:Label> </div>
        </div> 
    
    
     <div class="row clearfix">
        <div class="col-md-6 col-sm-12 mb-30">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h5>Estado de las Órdenes de Compra</h5>
                </div>
            </div>
            <div class="pd-20 card-box height-100-p">
                <div id="chartPie"></div> 
            </div>
        </div>
        <div class="col-md-6 col-sm-12 mb-30">
            <div class="form-grids widget-shadow" data-example-id="basic-forms">
                <div class="form-title color-white">
                    <h5>Insumos Disponibles</h5>
                </div>
            </div>
            <div class="pd-20 card-box height-100-p">
                <div id="chartBar"></div> 
            </div>
        </div>
    </div>
        </div>
     </div>
    </div>
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

    <!-- Chart code Bar Compra -->
    <script>
        am4core.ready(function () {

            // Themes begin
            am4core.useTheme(am4themes_moonrisekingdom);
            am4core.useTheme(am4themes_animated);
            // Themes end

            // Create chart instance
            var chart = am4core.create("chartBarCompra", am4charts.XYChart);

            // Add percent sign to all numbers
            chart.numberFormatter.numberFormat = "#.#";

            // Add data
            chart.data = <%=CargarInsumoComprar()%>;

            // Create axes
            var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
            categoryAxis.dataFields.category = "Insumo";
            categoryAxis.renderer.grid.template.location = 0;
            categoryAxis.renderer.minGridDistance = 30;

            var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
            valueAxis.title.text = "Cantidad";
            valueAxis.title.fontWeight = 800;

            chart.cursor = new am4charts.XYCursor();
            chart.cursor.lineX.disabled = true;
            chart.cursor.lineY.disabled = true;
            chart.colors.list = [
                am4core.color("#9C746B"),
                am4core.color("#DC7633"),
                am4core.color("#FF6F91"),
                am4core.color("#FF9671"),
                am4core.color("#FFC75F"),
                am4core.color("#F9F871"),
            ];

            // Create series
            var series = chart.series.push(new am4charts.ColumnSeries());
            series.dataFields.valueY = "Estado";
            series.dataFields.categoryX = "Insumo";
            series.clustered = false;
            series.tooltipText = "Cantidad Recibida : [bold]{valueY}[/]{Formato}";

            var series2 = chart.series.push(new am4charts.ColumnSeries());
            series2.dataFields.valueY = "CantidadCotizada";
            series2.dataFields.categoryX = "Insumo";
            series2.clustered = false;
            series2.columns.template.width = am4core.percent(50);
            series2.tooltipText = "Cantidad Comprada : [bold]{valueY}[/]{Formato}";
        }); // end am4core.ready()
    </script>
</asp:Content>
