<%@ Page Title="" Language="C#" EnableViewState="true" MasterPageFile="~/Vista/menu.Master" AutoEventWireup="true" CodeBehind="registroEmpresa.aspx.cs" Inherits="HIRE.Vista.registroEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>
    <style>
        .shake {
            animation: shake 2s ease;
        }

        @keyframes shake {
            0%, 100% {
                transform: translateX(0);
            }

            10%, 30%, 50%, 70%, 90% {
                transform: translateX(-20px);
            }

            20%, 40%, 60%, 80% {
                transform: translateX(20px);
            }
        }
    </style>
    <link rel="stylesheet" href="/Content/alertifyjs/alertify.css" />
    <link rel="stylesheet" href="/Content/alertifyjs/themes/default.css" />
    <script src="/Scripts/alertify.js"></script>

</asp:Content>
<asp:Content ID="Content2" style="" ContentPlaceHolderID="Content_Body" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>    
        <div class="container">

            <div class="row">

                <div class="row" style="text-align: center;">
                    <h3>Registrar empresa</h3>
                </div>

                <div class="col-md-1"></div>
                <div class="col-md-5">
                    <br />
                    <div class="row">
                        <h6 class="mb-1"><b>¡Bienvenido al Registro de Empresas!</b></h6>
                        <h6>Publica tus vacantes y encuentra al mejor talento para tu empresa en Boyacá.</h6>
                        <br />
                        <h6><b>¡Facilitamos el camino hacia el empleo ideal!</b></h6>

                    </div>

                    <img class="d-flex justify-content-center align-items-center" src="../Vista/recursos/img/registrarEmpresa.png" alt="registrarEmpresa"
                        style="width: 80%; height: auto; object-fit: cover; margin-top: 5%" />
                </div>
                <div class="col-md-5">


                    <br />
                    <p class="text-black">Los campos con <span class="text-danger">*</span> son obligatorios.</p>

                    <br />

                    <div style="max-height: calc(100vh - 150px); overflow-y: auto">

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="txtNombreEmpresa"><b>Razon Social</b><span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtNombreEmpresa" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="txtNit"><b>NIT</b><span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtNit" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>

                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <h6 id="msgNit" runat="server" visible="false" style="color: crimson">Este nit ya se encuentra registrado</h6>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="txtDireccion"><b>Dirección</b><span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtDireccion" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="txtTelefono1"><b>Telefono de contacto 1</b><span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtTelefono1" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="txtCorreo"><b>Correo electronico de la empresa</b><span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtCorreo" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>

                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <h6 id="msgCorreo" runat="server" visible="false" style="color: crimson">El correo ingresado ya está asociado a una empresa registrada.</h6>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="dpTiposNegocio"><b>Tipo de empresa</b><span class="text-danger">*</span></label>
                            <asp:DropDownList ID="dpTiposNegocio" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="dpMunicipios"><b>Municipio donde se ubica</b><span class="text-danger">*</span></label>
                            <asp:DropDownList ID="dpMunicipios" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="dpMunicipios"><b>*¿Desea compartir la ubicación exacta de su empresa si está allí al registrarse?*<span style="margin-left: 5px">(Opcional)</span></b></label>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:RadioButton ID="rbSiUbicacion" Text="Si" GroupName="ubicacion" OnCheckedChanged="rbSiUbicacion_CheckedChanged" AutoPostBack="true" CommandName="PermitirUbicacion" CommandArgument="Si" runat="server" />
                                    <asp:RadioButton ID="rb" Text="No" GroupName="ubicacion" OnCheckedChanged="rbSiUbicacion_CheckedChanged" AutoPostBack="true" CommandName="PermitirUbicacion" CommandArgument="No" runat="server" />
                                    <h6 runat="server" class="text-black" id="txtMensajeUbicacion" visible="false"><em>Puedes permitirla tambien al modificar informacion de tu empresa</em></h6>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="dpSector"><b>Sector Economico</b><span class="text-danger">*</span></label>
                            <asp:DropDownList ID="dpSector" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="txtDescripcion"><b>Descripción</b><span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtDescripcion" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="cFechaConstitucion"><b>Fecha de constitución</b><span class="text-danger">*</span></label>
                            <asp:TextBox ID="cFechaConstitucion" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="txtTelefono2"><b>Telefono de contacto 2<span style="margin-left: 5px">(Opcional)</span></b></label>
                            <asp:TextBox ID="txtTelefono2" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="txtUrl"><b>Pagina web de la empresa<span style="margin-left: 5px">(Opcional)</span></b></label>
                            <asp:TextBox ID="txtUrl" placeholder="URL de la web..." CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="ftEmpresa"><b>Logo de la empresa<span style="margin-left: 5px">(Opcional)</span></b></label>
                            <asp:FileUpload ID="ftEmpresa" accept="image/jpg, image/jpeg" EnableViewState="true" runat="server" class="form-control" />
                        </div>

                        <div class="form-group mb-4 mt-1">
                            <label class="form-label mb-0" for="#"><b>¿Tienes empleados?</b><span class="text-danger">*</span></label>
                            <asp:UpdatePanel ID="upanel1" runat="server">
                                <ContentTemplate>
                                    <div class="input-group">
                                        <asp:RadioButton ID="rbSi" Text="Si" GroupName="nEmpleados" OnCheckedChanged="rbSi_CheckedChanged" CommandName="numeroEmpleados" CommandArgument="Si" AutoPostBack="true" runat="server" />
                                        <asp:RadioButton Style="margin-left: 2%" ID="rbNo" Text="No" GroupName="nEmpleados" OnCheckedChanged="rbSi_CheckedChanged" CommandName="numeroEmpleados" CommandArgument="No" AutoPostBack="true" runat="server" />
                                    </div>

                                    <div class="input-group">
                                        <label runat="server" visible="false" id="lblMsgNumeroE" for="txtNumeroEmpleados">N° de Empleados: </label>
                                        <asp:TextBox ID="txtNumeroEmpleados" TextMode="Number" Style="width: auto; margin-left: 5px" CssClass="form-control" Visible="false" runat="server"></asp:TextBox>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>




                        <div class="form-group mb-4 mt-1">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="mssgRE" CssClass="form-label mb-0" runat="server" Text="Label"><b>Completa el reCAPTCHA</b><span class="text-danger">*</span></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div id="recaptcha-container" class="recaptcha-container">
                                <div class="g-recaptcha" data-sitekey="6LebF7wqAAAAADdNozk7fgGL-uZyRBXOkU5mRrzC" data-action="registrarEmpresa"></div>
                            </div>
                        </div>



                        <div class="d-flex justify-content-center mb-5">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnRegistrarEmpresa" Style="color: white" OnClick="btnRegistrarEmpresa_Click" CssClass="color2 btn" runat="server" Text="Registrar" />
                                </ContentTemplate>
                            </asp:UpdatePanel>



                        </div>
                    </div>
                </div>
                <div class="col-md-1"></div>

                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <input type="hidden" runat="server" id="hfCoordenadas" />
                    </ContentTemplate>
                </asp:UpdatePanel>


                <input type="hidden" runat="server" id="hfFotoEmpresa" />

            </div>
        </div>
    


    <script src="recursos/js/main3.js"></script>
    <br />
</asp:Content>
