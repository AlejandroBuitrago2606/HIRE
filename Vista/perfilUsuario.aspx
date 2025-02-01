<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/menu.Master" EnableEventValidation="true" EnableViewState="true" AutoEventWireup="true" CodeBehind="perfilUsuario.aspx.cs" Inherits="HIRE.Vista.perfilUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.9.4/dist/leaflet.css" integrity="sha256-p4NxAoJBhIIN+hmNHrzRCf9tD/miZyoHS5obTRR9BMY=" crossorigin="" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content_Body" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>


    <div class="container">

        <h5 style="text-align: center">Informacion de tu cuenta.</h5>

        <div class="row container-fluid" style="margin-top: 50px;">
            <br />
            <div class="col-4">

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="d-flex justify-content-center">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <img id="imgFotoUsuario" src="#" width="180" height="180" alt="error" runat="server" class="img-profile rounded-circle mb-3">
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="domAccionesFoto" runat="server" visible="false" class="input-group mb-5 d-flex justify-content-center">

                            <button id="btnEliminarFoto" onserverclick="accionesFoto_ServerClick" title="Eliminar foto" class="btn btn-danger" runat="server">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                    <path fill="#1a1a1a" d="M7.616 20q-.667 0-1.141-.475T6 18.386V6h-.5q-.213 0-.356-.144T5 5.499t.144-.356T5.5 5H9q0-.31.23-.54t.54-.23h4.46q.31 0 .54.23T15 5h3.5q.213 0 .356.144t.144.357t-.144.356T18.5 6H18v12.385q0 .666-.475 1.14t-1.14.475zM17 6H7v12.385q0 .269.173.442t.443.173h8.769q.269 0 .442-.173t.173-.442zm-6.692 11q.213 0 .357-.144t.143-.356v-8q0-.213-.144-.356T10.307 8t-.356.144t-.143.356v8q0 .213.144.356q.144.144.356.144m3.385 0q.213 0 .356-.144t.143-.356v-8q0-.213-.144-.356Q13.904 8 13.692 8q-.213 0-.357.144t-.143.356v8q0 .213.144.356t.357.144M7 6v13z" />
                                </svg></button>
                            <button id="btnRestaurarFoto" onserverclick="accionesFoto_ServerClick" title="Restaurar foto anterior" class="ml-2 btn btn-secondary" runat="server">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                    <path fill="none" stroke="#1a1a1a" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5" d="m18.364 8.05l-.707-.707a8 8 0 1 0 2.28 4.658m-1.573-3.95h-4.243m4.243 0V3.807" />
                                </svg></button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div id="domActualizarFoto" visible="false" runat="server">
                    <h6 class="mb-0" runat="server"><b>Foto de perfil</b></h6>
                    <asp:FileUpload runat="server" ID="imgCargarFoto" CssClass="form-control mb-3" />
                </div>
                <h6 id="lblNombreFoto" runat="server" class="d-flex justify-content-center mb-3"></h6>

                <div id="domBtnSolicitudA" runat="server" class="mt-5 d-flex justify-content-center">

                    <asp:Button ID="btnSolicitudA" OnClick="btnSolicitudA_Click" Text="Modificar Datos" CssClass="btn btn-success" runat="server" />
                </div>



            </div>
            <div class="col-8 content-body-scrollable">

                <%-- Nombres y Apellidos --%>
                <div class="mt-3">

                    <h6 id="lblNombreApellido" class="mb-3" runat="server"></h6>

                    <div id="domNombreApellido" visible="false" runat="server">
                        <h6 runat="server" class="mb-0"><b>Nombres</b></h6>
                        <asp:TextBox ID="txtNombre" MaxLength="40" Style="width: 50vh" TextMode="SingleLine" class="form-control mb-3" runat="server"></asp:TextBox>

                        <h6 runat="server" class="mb-0"><b>Apellidos</b></h6>
                        <asp:TextBox ID="txtApellido" MaxLength="40" TextMode="SingleLine" Style="width: 50vh" class="form-control" runat="server"></asp:TextBox>
                    </div>

                </div>




                <%-- Numero de documento --%>
                <div class="mt-3">

                    <h6 id="lblDocumento" class="mb-3" runat="server"></h6>

                    <div id="domDocumento" runat="server" visible="false">
                        <h6 runat="server" class="mb-0"><b>N° de documento</b></h6>
                        <asp:TextBox ID="txtDocumento" Max="30" Style="width: 50vh" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>




                <%-- Fecha de nacimiento --%>
                <div class="mt-3">

                    <h6 id="lblFechaNacimiento" class="mb-3" runat="server"></h6>

                    <div id="domFechaNacimiento" runat="server" visible="false">
                        <h6 runat="server" class="mb-0"><b>Fecha de nacimiento</b></h6>
                        <asp:TextBox ID="txtFechaNacimiento" Style="width: 50vh" TextMode="Date" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>




                <%-- Estado Civil --%>
                <div class="mt-3">

                    <h6 id="lblEstadoCivil" class="mb-3" runat="server"></h6>

                    <div id="domEstadoCivil" visible="false" runat="server">
                        <label class="mb-0" for="dpEstadoCivil"><b>Estado Civil</b></label>
                        <asp:DropDownList ID="dpEstadoCivil" CssClass="form-control" Style="width: 50vh; border-radius: 9px" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>




                <%-- Numero de Hijos --%>
                <div class="mt-3">

                    <h6 id="lblNumeroHijos" class="mb-3" runat="server"></h6>

                    <div id="domNumeroHijos" visible="false" runat="server">
                        <label class="mb-0"><b>¿Tiene Hijos?</b></label>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="input-group" style="width: 50vh;">
                                    <asp:RadioButton ID="rbSi" Text="Si" GroupName="hijos" OnCheckedChanged="rbSi_CheckedChanged" CommandName="SeleccionarHijos" CommandArgument="Si" AutoPostBack="true" runat="server" />
                                    <asp:RadioButton Style="margin-left: 2%" ID="rbNo" Text="No" GroupName="hijos" OnCheckedChanged="rbSi_CheckedChanged" CommandName="SeleccionarHijos" CommandArgument="No" AutoPostBack="true" runat="server" />
                                    <label runat="server" style="margin-bottom: 0; margin-left: 6%" visible="false" id="lblMsgNumeroH" for="txtNumeroHijos">N° de hijos: </label>
                                    <br />
                                    <asp:TextBox ID="txtNumeroHijos" TextMode="Number" CssClass="form-control ml-2" Visible="false" runat="server"></asp:TextBox>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>



                <%-- cargo --%>
                <div class="mt-3">

                    <h6 id="lblCargoActual" class="mb-3" runat="server"></h6>

                    <div id="domCargo" visible="false" runat="server">
                        <label class="mb-0" for="dpCargo"><b>Cargo</b></label>
                        <asp:DropDownList ID="dpCargo" CssClass="form-control" Style="width: 50vh; border-radius: 9px" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>




                <%-- Correo --%>
                <div class="mt-3">
                    <h6 id="lblCorreo" class="mb-3" runat="server"></h6>

                    <div id="domCorreo" visible="false" runat="server">
                        <h6 runat="server" class="mb-0"><b>Correo electronico</b></h6>
                        <asp:TextBox ID="txtCorreo" Style="width: 50vh" MaxLength="50" TextMode="Email" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>




                <%-- Telefono --%>
                <div class="mt-3">

                    <h6 id="lblTelefono" class="mb-3" runat="server"></h6>

                    <div id="domTelefono" visible="false" runat="server">
                        <h6 class="mb-0"><b>Telefono de contacto</b></h6>
                        <div class="input-group" style="width: 50vh">
                            <p class="mt-2">+57</p>
                            <asp:TextBox CssClass="ml-2 form-control" MaxLength="20" ID="txtTelefono" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>





                <%-- Direccion --%>
                <div class="mt-3">

                    <h6 id="lblDireccion" class="mb-3" runat="server"></h6>

                    <div id="domDireccion" visible="false" runat="server">
                        <h6 class="mb-0"><b>Direccion</b></h6>
                        <asp:TextBox ID="txtDireccion" Style="width: 50vh" MaxLength="50" TextMode="SingleLine" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>



                <label id="lblMunicipio" class="mb-3" runat="server"></label>

                <%-- Municipio --%>
                <div class="mt-3">

                    <div id="domMunicipio" visible="false" runat="server">
                        <label class="mb-0" for="dpMunicipios"><b>Municipio de residencia</b></label>
                        <div class="input-group" style="width: 50vh">
                            <br />
                            <asp:DropDownList ID="dpMunicipios" CssClass="form-control" Style="border-radius: 9px" runat="server">
                            </asp:DropDownList>

                            <div style="align-content: center">
                                <h6 class="ml-2 mt-2">, Boyaca</h6>
                            </div>
                        </div>
                    </div>

                </div>



                <%-- Ubicación --%>
                <div class="mt-3">

                    <div id="lblUbicacion" runat="server" class="mb-3">
                        <h6><b>Ubicación:</b></h6>
                        <div id="map" runat="server" style="width: 50vh; height: 200px;"></div>
                    </div>

                    <div id="domUbicacion" visible="false" runat="server">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <label runat="server"><b>Acepta compartir su ubicacion para ofrecerle una mejor experiencia en la busqueda de vacantes?</b></label>
                                <asp:RadioButton ID="rbSiUbicacion" Text="Si" GroupName="ubicacion" OnCheckedChanged="rbSiUbicacion_CheckedChanged" AutoPostBack="true" CommandName="PermitirUbicacion" CommandArgument="Si" runat="server" />
                                <asp:RadioButton Style="margin-left: 2%" ID="rbNoUbicacion" Text="No" GroupName="ubicacion" AutoPostBack="true" OnCheckedChanged="rbSiUbicacion_CheckedChanged" CommandName="PermitirUbicacion" CommandArgument="No" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </div>





                <%-- Contraseña --%>
                <div id="domClave" class="mt-4" style="width: 50vh" visible="false" runat="server">
                    <div class="form-group">
                        <h6 runat="server" class="mb-0"><b>Nueva contraseña</b></h6>
                        <asp:TextBox ID="txtNuevaClave" TextMode="Password" class="form-control" placeholder="Caracteres: maximo 8, minimo 5." runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <h6 runat="server" class="mb-0"><b>Confirmar contraseña</b></h6>
                        <asp:TextBox ID="txtConfirmarClave" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <input type="hidden" runat="server" id="hfClaveUsuario" />

                </div>

                <%-- Validar contraseñas --%>
                <asp:CompareValidator
                    runat="server"
                    ID="cvContrasena"
                    ControlToValidate="txtConfirmarClave"
                    ControlToCompare="txtNuevaClave"
                    Operator="Equal"
                    Type="String"
                    ErrorMessage="Las contraseñas no coinciden"
                    ForeColor="Red"
                    Display="Dynamic" />



                <%-- Botones de actualización --%>
                <div id="domBtnActualizar" visible="false" class="mt-5 mb-4" runat="server">

                    <div class="input-group d-flex justify-content-center">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <a class="btn btn-secondary" href="perfilUsuario.aspx">Cancelar</a>
                            </ContentTemplate>

                        </asp:UpdatePanel>

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnActualizar" Text="Actualizar" CssClass="btn btn-outline-warning" Style="margin-left: 30px;" CausesValidation="true" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>


                </div>



                <input type="hidden" runat="server" id="hfCoordenadas" />
                <input type="hidden" runat="server" id="hfFotoUsuario" />
                <input type="hidden" runat="server" id="hfFotoUsuarioDefault" />

            </div>
        </div>
    </div>

    <script src="https://unpkg.com/leaflet@1.9.4/dist/leaflet.js" integrity="sha256-20nQCchB9co0qIjJZRGuk2/Z9VM+kNiyxNV1lvTlZBo=" crossorigin=""></script>
    <script src="recursos/js/main4.js"></script>
</asp:Content>
