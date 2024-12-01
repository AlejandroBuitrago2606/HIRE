<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HIRE.Vista.login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Autenticación</title>
    <link rel="stylesheet" href="css/style.css" />
    <!-- Bootstrap 5.3.3 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- MDBootstrap 5.3.3 CSS -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/6.4.0/mdb.min.css" rel="stylesheet">
    <link rel="stylesheet" href="/Content/alertifyjs/alertify.css" />
    <link rel="stylesheet" href="/Content/alertifyjs/themes/default.css" />
    <script src="/Scripts/alertify.js"></script>

</head>
<body>
    <section class="h-100 gradient-form" style="background-color: #eee;">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-xl-10">
                    <div class="card rounded-3 text-black">
                        <div class="row g-0">
                            <div class="col-lg-6">
                                <div class="card-body p-md-5 mx-md-4">

                                    <div class="text-center">
                                        <img src="recursos/imagenes/logo-ProyectoHIRE-Login.png"
                                            style="width: 185px;" alt="logo">
                                        <h4 class="mt-1 mb-5 pb-1">Conecta tu talento con nuevas oportunidades.</h4>
                                    </div>

                                    <form id="form1" runat="server">
                                        <h3 style="text-align: center">Inicia sesion</h3>

                                        <div class="form-outline mb-4">
                                            <asp:TextBox ID="txtCorreo" CssClass="form-control" TextMode="Email" placeholder="Direccion de correo electronico" runat="server"></asp:TextBox>
                                            <label class="form-label" for="txtCorreo">Usuario</label>
                                        </div>

                                        <div class="form-outline mb-4">
                                            <asp:TextBox ID="txtContrasena" TextMode="Password" CssClass="form-control" runat="server" placeholder="Contraseña de no mas de 8 digitos"></asp:TextBox>
                                            <label class="form-label" for="txtContrasena">Contraseña</label>
                                        </div>

                                        <div class="text-center pt-1 mb-5 pb-1">
                                            <asp:Button ID="btnIniciarSesion" OnClick="btnIniciarSesion_Click" CssClass="btn btn-primary btn-block colorBase" runat="server" Text="Iniciar Sesion" />
                                            <a class="text-muted" href="recuperarContrasena.aspx">Olvidaste tu contraseña?</a>
                                        </div>

                                        <div class="d-flex align-items-center justify-content-center pb-4">
                                            <p class="mb-0 me-2">No tienes una cuenta?</p>
                                            <a class="btn btn-outline-primary" href="crearCuenta.aspx">Crea una aqui</a>
                                            
                                            
                                        </div>

                                    </form>

                                </div>
                            </div>
                            <div class="col-lg-6 d-flex align-items-center gradient-custom-2" style="background-image: url(../Vista/recursos/imagenes/Banner_Login2.jpg)">
                                <div class="text-white px-3 py-4 p-md-5 mx-md-4">
                                    <%--  <h4 class="mb-4">We are more than just a company</h4>
                            <p class="small mb-0">Lorem ipsum dolor sit amet, consectetur adi                      
                                pisicing elit, sed do eiusmod
                                tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
                                exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                            </p> --%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- Bootstrap 5.3.3 JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <!-- MDBootstrap 5.3.3 JS -->
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/6.4.0/mdb.min.js"></script>
</body>
</html>

