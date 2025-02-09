<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crearCuenta.aspx.cs" Inherits="HIRE.Vista.crearCuenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet" />
    <title></title>
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="/Content/alertifyjs/alertify.css" />
    <link rel="stylesheet" href="/Content/alertifyjs/themes/default.css" />
    <script src="/Scripts/alertify.js"></script>
    <script src="recursos/js/main3.js"></script>


</head>
<body>
    <script>
        function obtenerUbicacion() {

            if (!navigator.geolocation) {
                console.error("La geolocalización no está soportada por este navegador.");
                return;
            }

            const opciones = {
                enableHighAccuracy: true,
                timeout: 10000,
                maximumAge: 0
            };

            navigator.geolocation.getCurrentPosition(
                (position) => {

                    const latitud = position.coords.latitude;
                    const longitud = position.coords.longitude;

                    // Crear el objeto coordenadas
                    const coordenadas = { lat: latitud, lng: longitud };
                    document.getElementById("hfCoordenadas").value = JSON.stringify(coordenadas); // Guarda como string

                },
                (error) => {
                    alert("Error al obtener la ubicación: " + error.message);
                },
                opciones
            );
        }
    </script>

    <form id="form1" style="background-image: url('../Vista/recursos/imagenes/fondoModerno.png'); background-size: cover; background-repeat: no-repeat;" runat="server">
        <div class="container">

            <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>

            <br />

            <div class="row">
                <div class="col-2">
                </div>
                <div class="col-8 d-flex justify-content-center">

                    <h2>

                        <a href="../Default.aspx" class="btn">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 1024 1024">
                                <path fill="#000" d="M724 218.3V141c0-6.7-7.7-10.4-12.9-6.3L260.3 486.8a31.86 31.86 0 0 0 0 50.3l450.8 352.1c5.3 4.1 12.9.4 12.9-6.3v-77.3c0-4.9-2.3-9.6-6.1-12.6l-360-281l360-281.1c3.8-3 6.1-7.7 6.1-12.6" />
                            </svg>
                        </a><b>Crear cuenta</b></h2>
                </div>
                <div class="col-2"></div>

            </div>

            <div class="row" style="margin-top: 3%">
                <div class="col-md-3"></div>
                <div class="col-md-6">

                    <p>Los campos con <span class="text-danger">*</span> son requeridos.</p>

                    <div class="row">


                        <br />
                        <br />

                        <div class=" col-md-6">

                            <b>
                                <label for="txtNombre">Nombres<span class="text-danger">*</span></label></b>
                            <asp:TextBox ID="txtNombre" TextMode="SingleLine" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>


                        <div class=" col-md-6">
                            <b>
                                <label for="txtApellidos">Apellidos<span class="text-danger">*</span></label></b>
                            <asp:TextBox ID="txtApellidos" TextMode="SingleLine" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>

                    </div>

                    <br />

                    <div class="row">

                        <div class=" col-md-4">

                            <b>
                                <label for="txtDocumento">N° de documento<span class="text-danger">*</span></label></b>
                            <asp:TextBox ID="txtDocumento" TextMode="SingleLine" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>
                        <div class=" col-md-4">

                            <b>
                                <label for="dFechaNacimiento">Fecha de Nacimiento<span class="text-danger">*</span></label></b>
                            <asp:TextBox ID="dFechaNacimiento" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>
                        <div class=" col-md-4">

                            <b>
                                <label for="dpEstadoCivil">Estado civil<span class="text-danger">*</span></label></b>
                            <asp:DropDownList ID="dpEstadoCivil" CssClass="form-control" runat="server"></asp:DropDownList>

                        </div>

                    </div>

                    <br />



                    <div class="row">

                        <b>
                            <label runat="server" id="msgHijos">Tiene Hijos?</label></b>

                        <asp:UpdatePanel ID="upanel1" runat="server">

                            <ContentTemplate>
                                <div class="input-group">
                                    <asp:RadioButton ID="rbSi" Text="Si" GroupName="hijos" OnCheckedChanged="rbSi_CheckedChanged" CommandName="SeleccionarHijos" CommandArgument="Si" AutoPostBack="true" runat="server" />
                                    <asp:RadioButton Style="margin-left: 2%" ID="rbNo" Text="No" GroupName="hijos" OnCheckedChanged="rbSi_CheckedChanged" CommandName="SeleccionarHijos" CommandArgument="No" AutoPostBack="true" runat="server" />
                                    <label runat="server" style="margin-left: 6%" visible="false" id="lblMsgNumeroH" for="txtNumeroHijos">N° de hijos: </label>
                                    <asp:TextBox ID="txtNumeroHijos" TextMode="SingleLine" Style="width: auto; margin-left: 1%" CssClass="form-control" Visible="false" runat="server"></asp:TextBox>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>



                    <br />


                    <div class="row">
                        <div class="col-md-7">
                            <b>
                                <label for="txtCorreo">Correo<span class="text-danger">*</span></label></b>
                            <asp:TextBox ID="txtCorreo" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <b>
                                <label for="txtTelefono">Telefono<span class="text-danger">*</span></label></b>
                            <asp:TextBox ID="txtTelefono" TextMode="SingleLine" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                    </div>



                    <br />



                    <div class="row">
                        <div class="col-md-6">

                            <b>
                                <label for="txtDireccion">Direccion de residencia</label></b>
                            <asp:TextBox ID="txtDireccion" TextMode="SingleLine" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>
                        <div class="col-md-6">
                            <b>
                                <label for="dpMunicipios">Municipio<span class="text-danger">*</span></label></b>
                            <asp:DropDownList ID="dpMunicipios" CssClass="form-control" runat="server"></asp:DropDownList>

                        </div>

                    </div>

                    <br />

                    <div class="row">
                        <div class="col-md-12">

                            <b>
                                <label for="fotoPerfil">Foto de Perfil</label></b>
                            <asp:FileUpload ID="fotoPerfil" class="form-control" runat="server" />
                            <em runat="server" id="txtImg"></em>
                        </div>
                    </div>


                    <br />


                    <div class="row">
                        <div class="col-md-12">

                            <b>
                                <label for="txtContrasena">Contraseña<span class="text-danger">*</span></label></b>

                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtContrasena" placeholder="Contraseña de no mas de 8 digitos" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                                <span id="btnVer" class="input-group-text" onclick="verContrasena()" runat="server"><i class="bi bi-eye"></i></span>

                            </div>
                        </div>
                    </div>

                    <br />

                    <div class="row">

                        <div class="col-md-12">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <b>
                                        <label runat="server">Acepta compartir su ubicacion para ofrecerle una mejor experiencia en la busqueda de vacantes?</label></b>
                                    <asp:RadioButton ID="rbSiUbicacion" Text="Si" GroupName="ubicacion" OnCheckedChanged="rbSiUbicacion_CheckedChanged" AutoPostBack="true" CommandName="PermitirUbicacion" CommandArgument="Si" runat="server" />
                                    <asp:RadioButton Style="margin-left: 2%" ID="rbNoUbicacion" Text="No" GroupName="ubicacion" AutoPostBack="true" OnCheckedChanged="rbSiUbicacion_CheckedChanged" CommandName="PermitirUbicacion" CommandArgument="No" runat="server" />
                                    <h6 id="txtMsgUbicacion" runat="server"></h6>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>


                    <div class="row">

                        <div class="col-md-12">

                            <h5 style="text-align: center;" id="txtMensaje" runat="server">Selecciona tu cargo actual<span class="text-danger">*</span></h5>
                            <asp:DropDownList ID="dpCargo" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>

                        </div>

                    </div>


                    <br />
                    <br />

                    <div class="row">
                        <div class="d-flex justify-content-center">

                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <button type="button" id="btnRegistrarse" onserverclick="btnRegistrarse_ServerClick" class="btn btn-success" style="width: 200px;" runat="server">Registrarse</button>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <br />
                            <br />

                        </div>

                    </div>
                </div>
            </div>




            <asp:HiddenField ID="hfCoordenadas" runat="server" />
            <asp:HiddenField ID="hfCodigo4D" runat="server" />


            <br />
            <br />

            <div class="col-md-3"></div>

        </div>


        <!-- Modal -->
        <div class="modal fade" id="modalRegistro" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="staticBackdropLabel">Validación</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">

                        <div class="container">
                            <div class="row">
                                <p>Por favor ingresa el codigo de 4 digitos enviado a tu correo electronico para completar el registro.</p>
                                <asp:TextBox ID="txtCodigo4D" Style="text-align: center" TextMode="Number" CssClass="form-control" placeholder="Numero de 4 digitos" runat="server"></asp:TextBox>
                            </div>


                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div class="row" style="margin-top: 10%; text-align: center">
                                        <a id="txtMostrarAyuda" onserverclick="txtMostrarAyuda_ServerClick" runat="server" href="#">¿No recibi ningún codigo?</a>
                                    </div>

                                    <div class="row" style="margin-top: 5%">
                                        <p id="txtAyuda1" style="font-size: 13px; margin-bottom: 1%; color: crimson" visible="false" runat="server">● Revisa tu dirección de correo electrónico.</p>
                                        <p id="txtAyuda2" style="font-size: 13px; margin-bottom: 1%; color: crimson" visible="false" runat="server">● Comprueba si la dirección de correo electrónico que ingresaste es válida.</p>
                                        <p id="txtAyuda3" style="font-size: 13px; margin-bottom: 1%; color: crimson" visible="false" runat="server">● Verifica que tienes conexión a internet para revisar tu correo.</p>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>




                    </div>
                    <div class="modal-footer">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>

                                <button type="button" id="IdVerificarCodigo" onserverclick="btnVerificarCodigo_Click" class="btn btn-success" runat="server">Verificar</button>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>


    </form>

</body>
</html>
