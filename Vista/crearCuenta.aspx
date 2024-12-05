<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crearCuenta.aspx.cs" Inherits="HIRE.Vista.crearCuenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <title></title>
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="/Content/alertifyjs/alertify.css" />
    <link rel="stylesheet" href="/Content/alertifyjs/themes/default.css" />
    <script src="/Scripts/alertify.js"></script>
    <script>

        function obtenerUbicacion() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(
                    (pos) => {
                        const latitud = pos.coords.latitude;
                        const longitud = pos.coords.longitude;

                        // Opcional: Enviar al servidor usando AJAX o asignar a HiddenFields
                        document.getElementById("hfLatitud").value = latitud;
                        document.getElementById("hfLongitud").value = longitud;

                        alert(`Tu ubicación: Latitud: ${latitud}, Longitud: ${longitud}`);
                    },
                    (error) => {
                        alert("Error al obtener la ubicación: " + error.message);
                    }
                );
            } else {
                alert("Geolocalización no soportada por tu navegador.");
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>

            <br />
            <div class="row">
                <h2 style="text-align: center"><b>Crear cuenta</b></h2>

            </div>

            <div class="row" style="margin-top: 3%">
                <div class="col-md-3"></div>
                <div class="col-md-6">


                    <div class="row">

                        <div class=" col-md-6">
                            <b>
                                <label for="txtNombre">Nombres</label></b>
                            <asp:TextBox ID="txtNombre" TextMode="SingleLine" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>

                        <div class=" col-md-6">
                            <b>
                                <label for="txtApellidos">Apellidos</label></b>
                            <asp:TextBox ID="txtApellidos" TextMode="SingleLine" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>

                    </div>


                    <br />
                    <br />


                    <div class="row">

                        <div class=" col-md-4">

                            <b>
                                <label for="txtDocumento">N° de documento</label></b>
                            <asp:TextBox ID="txtDocumento" TextMode="SingleLine" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>
                        <div class=" col-md-4">

                            <b>
                                <label for="dFechaNacimiento">Fecha de Nacimiento</label></b>
                            <asp:TextBox ID="dFechaNacimiento" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>
                        <div class=" col-md-4">

                            <b>
                                <label for="dpEstadoCivil">Estado civil</label></b>
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
                                <label for="txtCorreo">Correo</label></b>
                            <asp:TextBox ID="txtCorreo" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <b>
                                <label for="txtTelefono">Telefono</label></b>
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
                                <label for="dpMunicipios">Municipio</label></b>
                            <asp:DropDownList ID="dpMunicipios" CssClass="form-control" runat="server"></asp:DropDownList>

                        </div>

                    </div>

                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <b>
                                <label for="fotoPerfil">Foto de Perfil</label></b>
                            <asp:FileUpload ID="fotoPerfil" class="form-control" required="" runat="server" />
                        </div>
                    </div>


                    <br />


                    <div class="row">
                        <div class="col-md-12">
                            <b>
                                <label for="txtContrasena">Contraseña</label></b>
                            <asp:TextBox ID="txtContrasena" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
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

                            <h5 style="text-align: center;" id="txtMensaje" runat="server">Selecciona tu cargo actual</h5>
                            <asp:DropDownList ID="dpCargo" CssClass="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>

                        </div>

                    </div>


                    <br />
                    <br />

                    <div class="row">

                                <div class="col-md-12">
                                    <div style="text-align: right">
                                        <button type="button" id="btnRegistrarse" onserverclick="btnRegistrarse_ServerClick" class="btn btn-success" runat="server">Registrarse</button>
                                    </div>
                                </div>


                    </div>


                    <asp:HiddenField ID="hfLatitud" runat="server" />
                    <asp:HiddenField ID="hfLongitud" runat="server" />



                    <br />
                    <br />
                    <br />
                    <br />



                </div>
                <div class="col-md-3"></div>
            </div>

        </div>
    </form>



    <script src="recursos/js/main3.js"></script>

</body>
</html>
