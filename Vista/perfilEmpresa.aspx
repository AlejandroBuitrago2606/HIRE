<%@ Page Title="" Language="C#" EnableEventValidation="true" MasterPageFile="~/Vista/panelEmpresa.Master" EnableViewState="true" AutoEventWireup="true" CodeBehind="perfilEmpresa.aspx.cs" Inherits="HIRE.Vista.perfilEmpresa1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.9.4/dist/leaflet.css" integrity="sha256-p4NxAoJBhIIN+hmNHrzRCf9tD/miZyoHS5obTRR9BMY=" crossorigin="" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="/Content/alertifyjs/alertify.css" />
    <link rel="stylesheet" href="/Content/alertifyjs/themes/default.css" />
    <script src="/Scripts/alertify.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <br />
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="container mt-3">
        <div class="d-flex justify-content-center">
            <h3 id="h3TituloActualizar" runat="server">Información de tu empresa</h3>
        </div>

        <div class="row container-fluid" style="margin-top: 30px;">
            <br />
            <div class="col-4">

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="d-flex justify-content-center">
                            <img id="imgFotoEmpresa" src="#" width="180" height="180" alt="error" runat="server" class="img-profile rounded-circle mb-3">
                        </div>
                        <div id="domAccionesFoto" runat="server" visible="false" class="input-group mb-5 d-flex justify-content-center">

                            <button id="btnEliminarFoto" onserverclick="accionesFoto_ServerClick" runat="server" title="Eliminar foto" class="btn btn-danger">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                    <path fill="#1a1a1a" d="M7.616 20q-.667 0-1.141-.475T6 18.386V6h-.5q-.213 0-.356-.144T5 5.499t.144-.356T5.5 5H9q0-.31.23-.54t.54-.23h4.46q.31 0 .54.23T15 5h3.5q.213 0 .356.144t.144.357t-.144.356T18.5 6H18v12.385q0 .666-.475 1.14t-1.14.475zM17 6H7v12.385q0 .269.173.442t.443.173h8.769q.269 0 .442-.173t.173-.442zm-6.692 11q.213 0 .357-.144t.143-.356v-8q0-.213-.144-.356T10.307 8t-.356.144t-.143.356v8q0 .213.144.356q.144.144.356.144m3.385 0q.213 0 .356-.144t.143-.356v-8q0-.213-.144-.356Q13.904 8 13.692 8q-.213 0-.357.144t-.143.356v8q0 .213.144.356t.357.144M7 6v13z" />
                                </svg>
                            </button>
                            <button id="btnRestaurarFoto" onserverclick="accionesFoto_ServerClick" title="Restaurar foto anterior" class="ml-2 btn btn-secondary">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                    <path fill="none" stroke="#1a1a1a" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5" d="m18.364 8.05l-.707-.707a8 8 0 1 0 2.28 4.658m-1.573-3.95h-4.243m4.243 0V3.807" />
                                </svg>
                            </button>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div id="domActualizarFoto" visible="false" runat="server">
                    <h6 class="mb-0" runat="server"><b>Logo de la empresa</b></h6>
                    <asp:FileUpload runat="server" ID="imgCargarFoto" CssClass="form-control mb-3" />

                </div>
                <h6 id="lblNombreFoto" runat="server" class="d-flex justify-content-center mb-3"></h6>

                <div id="domBtnSolicitudA" runat="server" class="mt-5 d-flex justify-content-center">
                    <asp:Button ID="btnSolicitudA" Text="Modificar Datos" OnClick="btnSolicitudA_Click" CssClass="btn btn-success" runat="server" />
                </div>

            </div>
            <div class="col-8 content-body-scrollable">

                <%-- Razon Social --%>
                <div class="mt-0">
                    <h6 id="lblDescripcion" style="margin-bottom: 6%;" class="mb-5" runat="server"></h6>

                    <div id="domDescripcion" visible="false" runat="server">
                        <label class="form-label mb-0" for="txtDescripcion"><b>Descripción</b><span class="text-danger">*</span></label>
                        <textarea rows="3" id="txtDescripcion" class="form-control" runat="server"></textarea>
                    </div>

                </div>

                <div class="mt-3">
                    <h6 id="lblNombre" class="mb-3" runat="server"></h6>

                    <div id="domNombre" visible="false" runat="server">
                        <h6 runat="server" class="mb-0"><b>Razon Social</b></h6>
                        <asp:TextBox ID="txtNombre" MaxLength="40" TextMode="SingleLine" class="form-control mb-3" runat="server"></asp:TextBox>

                    </div>
                </div>

                <div class="mt-3">
                    <h6 id="lblNit" class="mb-3" runat="server"></h6>

                    <div id="domNIT" visible="false" runat="server">
                        <label class="form-label mb-0" for="txtNit"><b>NIT</b></label>
                        <asp:TextBox ID="txtNit" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                    </div>

                </div>

                <div class="mt-3">
                    <h6 id="lblDireccion" class="mb-3" runat="server"></h6>

                    <div id="domDireccion" visible="false" runat="server">
                        <label class="form-label mb-0" for="txtDireccion"><b>Dirección</b></label>
                        <asp:TextBox ID="txtDireccion" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="mt-3">
                    <h6 id="lblTelefono1" class="mb-3" runat="server"></h6>

                    <div id="domTelefono1" visible="false" runat="server">
                        <label class="form-label mb-0" for="txtTelefono1"><b>Telefono de contacto 1</b></label>
                        <asp:TextBox ID="txtTelefono1" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="mt-3">
                    <h6 id="lblTelefono2" class="mb-3" runat="server"></h6>
                    <div id="domTelefono2" visible="false" runat="server">
                        <label class="form-label mb-0" for="txtTelefono2"><b>Teléfono de contacto 2<span style="margin-left: 5px">(Opcional)</span></b></label>
                        <asp:TextBox ID="txtTelefono2" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="mt-3">
                    <h6 id="lblCorreo" class="mb-3" runat="server"></h6>

                    <div id="domCorreo" visible="false" runat="server">
                        <label class="form-label mb-0" for="txtCorreo"><b>Correo electronico de la empresa</b><span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtCorreo" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="mt-3">
                    <h6 id="lblUrl" class="mb-3" runat="server"></h6>

                    <div id="domUrl" visible="false" runat="server">
                        <label class="form-label mb-0" for="txtDireccion"><b>Pagina Web</b></label>
                        <asp:TextBox ID="txtUrl" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="mt-3">
                    <h6 id="lblTipodeNegocio" class="mb-3" runat="server">a</h6>

                    <div id="domTNegocio" visible="false" runat="server">
                        <label class="form-label mb-0" for="dpTiposNegocio"><b>Tipo de empresa</b><span class="text-danger">*</span></label>
                        <asp:DropDownList ID="dpTiposNegocio" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="mt-3">
                    <h6 id="lblNombreMunicipio" class="mb-3" runat="server">a</h6>
                    <div id="domMunicipio" visible="false" runat="server">
                        <label class="form-label mb-0" for="dpMunicipios"><b>Municipio donde se ubica</b><span class="text-danger">*</span></label>
                        <asp:DropDownList ID="dpMunicipios" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="mt-3">
                    <h6 id="lblSector" class="mb-3" runat="server"></h6>
                    <div id="domSector" visible="false" runat="server">
                        <label class="form-label mb-0" for="dpSector"><b>Sector Económico</b><span class="text-danger">*</span></label>
                        <asp:DropDownList ID="dpSector" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="mt-3">
                    <h6 id="lblFechaConstitucion" class="mb-3" runat="server"></h6>

                    <div id="domFechaConstitucion" visible="false" runat="server">
                        <label class="form-label mb-0" for="cFechaConstitucion"><b>Fecha de constitución</b><span class="text-danger">*</span></label>
                        <asp:TextBox ID="cFechaConstitucion" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="mt-3">
                    <h6 id="lblCantidadEmpleados" class="mb-3" runat="server"></h6>

                    <div id="domEmpleados" visible="false" runat="server">
                        <label class="form-label mb-0" for="#"><b>¿Tienes empleados?</b><span class="text-danger">*</span></label>
                        <asp:UpdatePanel ID="upanel1" runat="server">
                            <ContentTemplate>
                                <div class="input-group">
                                    <asp:RadioButton ID="rbSi" Text="Sí" GroupName="nEmpleados" OnCheckedChanged="rbSi_CheckedChanged" CommandName="numeroEmpleados" CommandArgument="Si" AutoPostBack="true" runat="server" />
                                    <asp:RadioButton Style="margin-left: 2%" ID="rbNo" Text="No" GroupName="nEmpleados" OnCheckedChanged="rbSi_CheckedChanged" CommandName="numeroEmpleados" CommandArgument="No" AutoPostBack="true" runat="server" />
                                </div>
                                <div class="input-group">
                                    <label runat="server" visible="false" id="lblMsgNumeroE" for="txtNumeroEmpleados">N° de Empleados: </label>
                                    <asp:TextBox ID="txtNumeroEmpleados" TextMode="Number" Style="width: auto; margin-left: 5px" CssClass="form-control" Visible="false" runat="server"></asp:TextBox>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div class="mt-3">
                    <div id="lblUbicacion" runat="server" class="mb-3">
                        <h6><b>Ubicación:</b></h6>
                        <div id="map" runat="server" style="width: 50vh; height: 200px;"></div>
                    </div>

                    <div id="domUbicacion" visible="false" runat="server">
                        <label class="form-label mb-0" for="dpUbicacion"><b>*¿Desea compartir la ubicación exacta de su empresa si está allí al registrarse?*<span style="margin-left: 5px">(Opcional)</span></b></label>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:RadioButton ID="rbSiUbicacion" Text="Sí" GroupName="ubicacion" OnCheckedChanged="rbSiUbicacion_CheckedChanged" CommandName="PermitirUbicacion" CommandArgument="Si" AutoPostBack="true" runat="server" />
                                <asp:RadioButton ID="rbNoUbicacion" Text="No" GroupName="ubicacion" OnCheckedChanged="rbSiUbicacion_CheckedChanged" CommandName="PermitirUbicacion" CommandArgument="No" AutoPostBack="true" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>


                <%-- Botones de actualización --%>
                <div id="domBtnActualizar" visible="false" class="mt-5 mb-4" runat="server">
                    <div class="input-group d-flex justify-content-center">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <a class="btn btn-secondary" href="perfilEmpresa.aspx">Cerrar</a>
                                <asp:Button ID="btnActualizar" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="btn btn-outline-warning" Style="margin-left: 30px;" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <input type="hidden" runat="server" id="hfFotoEmpresa" />
                        <input type="hidden" runat="server" id="hfCoordenadas" />
                    </ContentTemplate>
                </asp:UpdatePanel>

                <input type="hidden" runat="server" id="hfFotoEmpresaDefault" />
            </div>
        </div>
        <script src="recursos/js/main6.js"></script>
        <script src="https://unpkg.com/leaflet@1.9.4/dist/leaflet.js" integrity="sha256-20nQCchB9co0qIjJZRGuk2/Z9VM+kNiyxNV1lvTlZBo=" crossorigin=""></script>
    </div>
</asp:Content>
