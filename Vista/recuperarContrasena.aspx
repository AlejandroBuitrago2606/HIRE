<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recuperarContrasena.aspx.cs" Inherits="HIRE.Vista.recuperarContrasena" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Recuperar Contraseña</title>
    <link rel="stylesheet" href="css/style.css" />
    <!-- Bootstrap 5.3.3 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
    <!-- MDBootstrap 5.3.3 CSS -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/6.4.0/mdb.min.css" rel="stylesheet" />
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
                                            style="width: 185px;" alt="logo" />
                                        <h4 class="mt-1 mb-5 pb-1">Recupera tu contraseña</h4>
                                    </div>

                                    <form id="form1" runat="server">

                                        <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>


                                        <h6 runat="server" id="txtMensajePrincipal">Ingresa tu correo electronico:</h6>

                                        <div class="form-outline mb-4">

                                                    <asp:TextBox ID="txtParametros" CssClass="form-control" TextMode="SingleLine" placeholder="usuario@example.com" runat="server"></asp:TextBox>
                                              
                                        </div>

                                        <h6 style="font-size: 80%" runat="server" id="txtMensaje2"><em>Enviaremos a tu correo electronico un codigo de 4 digitos.</em></h6>
                                        <div class="text-center pt-1 mb-5 pb-1">
                                            <asp:Button ID="btnDinamico" CssClass="btn btn-primary btn-block colorBase" OnClick="btnDinamico_Click" runat="server" Text="Enviar codigo" />
                                            
                                            <br />

                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <button id="btnSugerencias" type="button" class="btn" style="width: auto" runat="server" visible="false" onclick="mtdMostrarSugerencias()"><a href="#">¿No recibi níngun codigo?</a></button>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </div>

                                        <!-- Modal -->
                                        <div class="modal fade" data-bs-backdrop="static" id="actualizarClave" runat="server" tabindex="-1" aria-labelledby="tituloModal" aria-hidden="true">
                                            <div class="modal-dialog">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h1 class="modal-title fs-5" runat="server" id="tituloModal">Actualizar contraseña</h1>
                                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                                    </div>
                                                    <div class="modal-body">

                                                        <h5 style="text-align: center;" id="txtMensaje3" runat="server">Ingresa tu nueva contraseña</h5>
                                                        <asp:TextBox ID="txtContrasena" CssClass="form-control" TextMode="Password" placeholder="no mas de 8 digitos" runat="server"></asp:TextBox>

                                                    </div>
                                                    <div class="modal-footer">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>
                                                                <asp:Button ID="btnActualizar" CssClass="btn btn-primary" OnClick="btnActualizarC_ServerClick" runat="server" Text="Verificar" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- End Modal --%>
                                    </form>

                                </div>
                            </div>

                            <div class="col-lg-6 d-flex align-items-center gradient-custom-2" style="background-image: url('../Vista/recursos/imagenes/fondoRecuperarC.jpg'); background-size: cover; background-repeat: no-repeat; background-position: center;">
                            </div>







                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <script src="recursos/js/main3.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <!-- MDBootstrap 5.3.3 JS -->
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/6.4.0/mdb.min.js"></script>
</body>

</html>
