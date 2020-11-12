<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Empty.aspx.cs" Inherits="ProyectoMesonURP.Empty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/Empty%20js/scripts.js"></script>
    <script src="js/Empty%20js/jquery.mb.YTPlayer.js"></script>
    <script src="js/Empty%20js/jquery.cycle.min.js"></script>
    <script src="js/Empty%20js/jquery.countdown.min.js"></script>
    <script src="js/Empty%20js/supersized.min.js"></script>
    <script src="js/Empty%20js/jquery.plugin.js"></script>
    <link href="css/pages/Empty/YTPlayer.css" rel="stylesheet" />
    <link href="css/pages/Empty/styles.css" rel="stylesheet" />
    <link href="css/pages/Empty/supersized.css" rel="stylesheet" />
    <link href="css/pages/Empty/animate.css" rel="stylesheet" />
    <div class="container">
        <div class="row">
            <div class="col-md-12">

                <div class="section clearfix">
                    <div id="text_slider">
                        <div class="slide clearfix">
                            <h1 style="color: #214E3F">Página en construcción</h1>
                        </div>

                        <div class="slide clearfix">
                            <h1 style="color: #214E3F">Próximamente!</h1>
                        </div>
                    </div>



                    <!-- COUNTDOWN -->
                    <div class="section clearfix animated fadeIn" id="countdown">
                        <div class="slide clearfix" style="display: flex; flex-wrap:wrap;">
                            <figure class="gallery__item gallery__item--1">
                                <img src="../img/meson-2.PNG"  style="height: 290px" alt="Gallery image 1" class="gallery__img" />
                            </figure>
                            <figure class="gallery__item gallery__item--2">
                                <img src="../img/meson-10.png" style="height: 290px" alt="Gallery image 2" class="gallery__img" />
                            </figure>
                            <figure class="gallery__item gallery__item--3">
                                <img src="../img/meson-6.png" style="height: 290px" alt="Gallery image 3" class="gallery__img" />
                            </figure>
                            <figure class="gallery__item gallery__item--4">
                                <img src="../img/meson-16.png"  style="height: 290px" alt="Gallery image 4" class="gallery__img" />
                            </figure>
                            <figure class="gallery__item gallery__item--5">
                                <img src="../img/meson-12.png"  style="height: 290px" alt="Gallery image 5" class="gallery__img" />
                            </figure>
                            <figure class="gallery__item gallery__item--6">
                                <img src="../img/meson-7.png"  style="height: 290px" alt="Gallery image 6" class="gallery__img" />
                            </figure>
                            <figure class="gallery__item gallery__item--7">
                                <img src="../img/meson-13.png"  style="height: 290px" alt="Gallery image 7" class="gallery__img" />
                            </figure>
                            <figure class="gallery__item gallery__item--8">
                                <img src="../img/meson-9.png"  style="height: 290px" alt="Gallery image 8" class="gallery__img" />
                            </figure>

                        </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
