<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoMesonURP.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>MesónURP | Login</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="fonts/font-awesome-4.7.0/css/font-awesome.css" rel="stylesheet" />
    <link href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css" rel="stylesheet" />
    <link href="css/pages/Login/animate.css" rel="stylesheet" />
    <link href="css/pages/Login/hamburgers.min.css" rel="stylesheet" />
    <link href="css/pages/Login/animsition.min.css" rel="stylesheet" />
    <link href="css/pages/Login/select2.min.css" rel="stylesheet" />
    <link href="css/pages/Login/daterangepicker.css" rel="stylesheet" />
    <link href="css/pages/Login/util.css" rel="stylesheet" />
    <link href="css/pages/Login/main.css" rel="stylesheet" />
</head>
<body style="background-color: #666666;">
   <div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<form id="formLogin" class="login100-form validate-form" runat="server">
					<span class="login100-form-title p-b-43">
						Inicia sesión para continuar
					</span>				
					
					<div class="wrap-input100 validate-input" data-validate = "Se requiere email válido: ex@abc.xyz">
						<input id="usuario" class="input100" type="text" name="email" runat="server">
					<%--	<asp:RegularExpressionValidator ID="RevCorreo" runat="server" ErrorMessage="Por favor ingrese su correo" ControlToValidate="email" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="email" ErrorMessage="Campo Obligatorio" ValidationGroup="iniciarSesionV" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
						<span class="focus-input100"></span>
						<span class="label-input100">Email</span>
					</div>
					
					
					<div class="wrap-input100 validate-input" data-validate="Se requiere la contraseña">
						<input id="password" class="input100" type="password" name="pass" runat="server"/>
						<%--<asp:RegularExpressionValidator ID="revContraseña" runat="server" ErrorMessage="Por favor ingrese solo letras o números" ControlToValidate="password" ForeColor="#CC0000" ValidationExpression="([a-zA-Z0-9]{1,})" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password" ErrorMessage="Campo Obligatorio" ValidationGroup="iniciarSesionV" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
						<span class="focus-input100"></span>
						<span class="label-input100">Contraseña</span>
					</div>

					<div class="flex-sb-m w-full p-t-3 p-b-32">
						<div class="contact100-form-checkbox">
							<input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me"/>
							<label class="label-checkbox100" for="ckb1">
								Recuérdame
							</label>
						</div>

						<div>
							<a href="#" class="txt1">
								Olvidaste tu contraseña?
							</a>
						</div>
					</div>
			

					<div class="container-login100-form-btn">
						<asp:Button id="btnLogin" runat="server" class="login100-form-btn" ValidationGroup="iniciarSesionV" Text="Ingresar" OnClick="btnLogin_Click"/>
					</div>
					
					<div class="text-center p-t-46 p-b-20">
						<span class="txt2">
							o regístrate usando
						</span>
					</div>

					<div class="login100-form-social flex-c-m">
						<a href="#" class="login100-form-social-item flex-c-m bg1 m-r-5">
							<i class="fa fa-facebook-f" aria-hidden="true"></i>
						</a>

						<a href="#" class="login100-form-social-item flex-c-m bg2 m-r-5">
							<i class="fa fa-twitter" aria-hidden="true"></i>
						</a>
					</div>
				</form>

				<div class="login100-more" style="background-image: linear-gradient(331deg, rgba(34,195,77,0.5578606442577031) 10%, rgba(33,78,63,0.5018382352941176) 100%),url('../img/UNIVERSIDAD-RICARDO-PALMA-18.jpg')">
				</div>
			</div>
		</div>
	</div>
    <script src="js/Login%20js/jquery-3.2.1.min.js"></script>
    <script src="js/Login%20js/animsition.min.js"></script>
    <script src="js/Login%20js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/Login%20js/select2.min.js"></script>
    <script src="js/Login%20js/moment.min.js"></script>
    <script src="js/Login%20js/daterangepicker.js"></script>
    <script src="js/Login%20js/countdowntime.js"></script>
    <script src="js/Login%20js/main.js"></script>
</body>
</html>
