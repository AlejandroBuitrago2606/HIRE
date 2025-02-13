<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/panelEmpresa.Master" EnableEventValidation="true" AutoEventWireup="true" CodeBehind="verUsuario.aspx.cs" Inherits="HIRE.Vista.verUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">

    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.9.4/dist/leaflet.css" integrity="sha256-p4NxAoJBhIIN+hmNHrzRCf9tD/miZyoHS5obTRR9BMY=" crossorigin="" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="/Content/alertifyjs/alertify.css" />
    <link rel="stylesheet" href="/Content/alertifyjs/themes/default.css" />

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <div class="container">

        <h3 style="text-align: center">Perfil del candidato</h3>

        <div class="row container-fluid" style="margin-top: 30px;">
            <br />
            <div class="col-4">

                <div class="d-flex justify-content-center">
                    <img id="imgFotoUsuario" src="#" width="180" height="180" alt="error" runat="server" class="img-profile rounded-circle mb-3">
                </div>

                <h6 id="lblNombreFoto" runat="server" class="d-flex justify-content-center mb-3"></h6>                

            </div>
            <div class="col-8 content-body-scrollable">

                <%-- Nombres y Apellidos --%>
                <div class="mt-3">
                    <h6 id="lblNombreApellido" class="mb-3" runat="server"></h6>
                </div>




                <%-- Numero de documento --%>
                <div class="mt-3">

                    <h6 id="lblDocumento" class="mb-3" runat="server"></h6>
                </div>




                <%-- Fecha de nacimiento --%>
                <div class="mt-3">

                    <h6 id="lblFechaNacimiento" class="mb-3" runat="server"></h6>
                </div>




                <%-- Estado Civil --%>
                <div class="mt-3">

                    <h6 id="lblEstadoCivil" class="mb-3" runat="server"></h6>
                </div>




                <%-- Numero de Hijos --%>
                <div class="mt-3">

                    <h6 id="lblNumeroHijos" class="mb-3" runat="server"></h6>

                </div>



                <%-- cargo --%>
                <div class="mt-3">

                    <h6 id="lblCargoActual" class="mb-3" runat="server"></h6>

                </div>




                <%-- Correo --%>
                <div class="mt-3">
                    <h6 id="lblCorreo" class="mb-3" runat="server"></h6>

                </div>




                <%-- Telefono --%>
                <div class="mt-3">

                    <h6 id="lblTelefono" class="mb-3" runat="server"></h6>
                </div>





                <%-- Direccion --%>
                <div class="mt-3">

                    <h6 id="lblDireccion" class="mb-3" runat="server"></h6>
                </div>





                <%-- Municipio --%>
                <div class="mt-3">

                    <label id="lblMunicipio" class="mb-3" runat="server"></label>

                </div>



                <%-- Ubicación --%>
                <div class="mt-2">

                    <div id="lblUbicacion" runat="server" class="mb-3">
                        <h6><b>Ubicación:</b></h6>
                        <div id="map" runat="server" style="width: 50vh; height: 200px;"></div>
                    </div>

                </div>

                        <input type="hidden" runat="server" id="hfFtUsuario" />

                        <input type="hidden" runat="server" id="hfCoordenadas" />
               

                <input type="hidden" runat="server" id="hfFotoUsuarioDefault" />
                <input type="hidden" runat="server" id="hfClaveUsuario" />

            </div>
        </div>
    </div>

    <script src="https://unpkg.com/leaflet@1.9.4/dist/leaflet.js" integrity="sha256-20nQCchB9co0qIjJZRGuk2/Z9VM+kNiyxNV1lvTlZBo=" crossorigin=""></script>
    <script src="recursos/js/main4.js"></script>
</asp:Content>
