<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProyectoMesonURP.Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Meson del Estudiante</title>
    <link href="../css/style1.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/style.prefix.css" rel="stylesheet" />
    <link href="css/sweetalert2.min.css" rel="stylesheet" />
    <script src="js/sweetalert2.all.min.js"></script>
    <script type="text/javascript">
        window.history.forward();
    </script>
</head>
<body class="container">
    <div class="sidebar"></div>
    <header class="header">
        <img src="/img/MesonURP_logofinal.png" alt="MesónURP logo" class="header__logo" />
        <div class="right-header">
            <h3 class="heading-3 header-13px">Haz tu reserva:</h3>
            <h1 class="heading-1 header-13px">Mesón del Estudiante</h1>
            <button class="btn header__btn">Reservar</button>
        </div>
    </header>
    <div class="realtors">
        <h3 class="heading-3">Organización</h3>
        <div class="realtors__list">
            <img src="img/rector.PNG" alt="Realtor 1" class="realtors__img" />
            <div class="realtors__details">
                <h4 class="heading-4 heading-4--light">Dr. Iván Rodriguez Chávez</h4>
                <p class="realtors__sold">Rector de la Universidad Ricardo Palma</p>
            </div>
            <img src="img/decano.PNG" alt="Realtor 2" class="realtors__img" />
            <div class="realtors__details">
                <h4 class="heading-4 heading-4--light">Msc. Ing. Carlos Sebastián Calvo</h4>
                <p class="realtors__sold">Decano Facultad de Ingeniería</p>
            </div>
            <img src="img/director.PNG" alt="Realtor 3" class="realtors__img" />
            <div class="realtors__details">
                <h4 class="heading-4 heading-4--light">Mag. Ing. Miguel Arrunátegui Angulo</h4>
                <p class="realtors__sold">Director de la Escuela de Ingeniería Informática</p>
            </div>
        </div>
    </div>
    <div class="navigation">
        <input type="checkbox" class="navigation__checkbox" id="navi-toggle" />
        <label for="navi-toggle" class="navigation__button">
            <span class="navigation__icon">&nbsp;</span>
        </label>
        <div class="navigation__background">&nbsp;</div>
        <form id="form1" class="navigation__nav form-login-style" runat="server">
            <h1>Bienvenido</h1>
            <div class="login-fields">
                <p class="title-login">
                    <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="#CC0000"></asp:Label></p>
                <p>
                    <asp:Label ID="lblMensajeAyuda" runat="server" Text=""></asp:Label></p>
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                    <input class="mdl-textfield__input input-login-style" type="text" id="correo" placeholder="Nombre" name="correo" value="" runat="server" />
                    <asp:RegularExpressionValidator ID="RevCorreo" runat="server" ErrorMessage="Por favor ingrese su correo" ControlToValidate="correo" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="correo" ErrorMessage="Campo Obligatorio" ValidationGroup="iniciarSesionV" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                    <input class="mdl-textfield__input  input-login-style" type="password" id="contraseña" placeholder="Contraseña" name="contraseña" value="" runat="server" />
                    <asp:RegularExpressionValidator ID="revContraseña" runat="server" ErrorMessage="Por favor ingrese solo letras o números" ControlToValidate="contraseña" ForeColor="#CC0000" ValidationExpression="([a-zA-Z0-9]{1,})" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="contraseña" ErrorMessage="Campo Obligatorio" ValidationGroup="iniciarSesionV" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <!-- /login-fields -->
           <%-- <div class="col-xs-12 p-0 text-right">
                <asp:Button ID="btnLogin" ValidationGroup="iniciarSesionV" class="btn-login-style" runat="server" Text="Ingresar" OnClick="goToIndex" />
            </div>--%>
            <p class="form-message">No estás registrado? <a href="#">Crea una cuenta</a></p>
            <!-- .actions -->
        </form>
    </div>
    <section class="features">
        <div class="feature">
            <svg class="feature__icon">
                <use xlink:href="img/sprite.svg#icon-global"></use>
            </svg>
            <h4 class="heading-4 heading-4--dark">¿Qué es el Mesón del Estudiante?</h4>
            <p class="feature__text">Es el área en el que los estudiantes, administrativos y profesor de la URP consumen sus alimentos.</p>
        </div>

        <div class="feature">
            <svg class="feature__icon">
                <use xlink:href="img/sprite.svg#icon-map-pin"></use>
            </svg>
            <h4 class="heading-4 heading-4--dark">¿Dónde se encuentra ubicado?</h4>
            <p class="feature__text">El Mesón del Estudiante de encuentra ubicado en la facultad de Hotelería, Turismo y Gastronomía de la URP.</p>
        </div>

        <div class="feature">
            <svg class="feature__icon">
                <use xlink:href="img/sprite.svg#icon-key"></use>
            </svg>
            <h4 class="heading-4 heading-4--dark">¿Qué días hay menú?</h4>
            <p class="feature__text">El servicio de menú es realizado los lunes de 10am a 7pm y sábado de 10am a 12pm.</p>
        </div>
    </section>
     <section class="gallery">
        <figure class="gallery__item gallery__item--1">
            <img src="../img/meson-2.PNG" alt="Gallery image 1" class="gallery__img" />
        </figure>
        <figure class="gallery__item gallery__item--2">
            <img src="../img/meson-10.png" alt="Gallery image 2" class="gallery__img" />
        </figure>
        <figure class="gallery__item gallery__item--3">
            <img src="../img/meson-6.png" alt="Gallery image 3" class="gallery__img" />
        </figure>
        <figure class="gallery__item gallery__item--4">
            <img src="../img/meson-16.png" alt="Gallery image 4" class="gallery__img" />
        </figure>
        <figure class="gallery__item gallery__item--5">
            <img src="../img/meson-12.png" alt="Gallery image 5" class="gallery__img" />
        </figure>
        <figure class="gallery__item gallery__item--6">
            <img src="../img/meson-7.png" alt="Gallery image 6" class="gallery__img" />
        </figure>
        <figure class="gallery__item gallery__item--7">
            <img src="../img/meson-13.png" alt="Gallery image 7" class="gallery__img" />
        </figure>
        <figure class="gallery__item gallery__item--8">
            <img src="../img/meson-9.png" alt="Gallery image 8" class="gallery__img" />
        </figure>
        <figure class="gallery__item gallery__item--9">
            <img src="../img/meson-1.PNG" alt="Gallery image 9" class="gallery__img" />
        </figure>
        <figure class="gallery__item gallery__item--10">
            <img src="../img/meson-4.PNG" alt="Gallery image 10" class="gallery__img" />
        </figure>
        <figure class="gallery__item gallery__item--11">
            <img src="../img/meson-8.png" alt="Gallery image 11" class="gallery__img" />
        </figure>
        <figure class="gallery__item gallery__item--12">
            <img src="../img/meson-15.png" alt="Gallery image 12" class="gallery__img" />
        </figure>
        <figure class="gallery__item gallery__item--13">
            <img src="../img/meson-5.png" alt="Gallery image 13" class="gallery__img" />
        </figure>
        <figure class="gallery__item gallery__item--14">
            <img src="../img/meson-11.png" alt="Gallery image 14" class="gallery__img" />
        </figure>
    </section>
    <footer class="footer">
        <ul class="nav">
            <li class="nav__item"><a href="#" class="nav__link">Reserva tu menú</a></li>
            <li class="nav__item"><a href="#" class="nav__link">Inicia Sesión</a></li>
            <li class="nav__item"><a href="#" class="nav__link">Registrate</a></li>
            <li class="nav__item"><a href="#" class="nav__link">Contáctanos</a></li>
        </ul>
        <p class="copyright">
            &copy; Copyright 2020 by Fiorella Loayza and Milagros Cueche.
        </p>
    </footer>
</body>
</html>
