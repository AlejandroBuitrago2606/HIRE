<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/panelEmpresa.Master" AutoEventWireup="true" CodeBehind="verCV.aspx.cs" Inherits="HIRE.Vista.verCV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">

    <link rel="stylesheet" href="recursos/css/nicepage.css" media="screen">
    <link rel="stylesheet" href="recursos/css/index.css" media="screen">
    <script class="u-script" type="text/javascript" src="recursos/js/jquery.js" defer=""></script>
    <script class="u-script" type="text/javascript" src="recursos/js/nicepage.js" defer=""></script>
    <link id="u-theme-google-font" rel="stylesheet"
        href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i|Open+Sans:300,300i,400,400i,500,500i,600,600i,700,700i,800,800i">
    <link rel="stylesheet" href="/Content/alertifyjs/alertify.css" />
    <link rel="stylesheet" href="/Content/alertifyjs/themes/default.css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.10.377/pdf.min.js"></script>
    <script src="/Scripts/alertify.js"></script>
    <title>Perfil CV</title>
    <link rel="stylesheet" href="recursos/css/main2.css" />
    <title>Ver CV</title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">
    <div style="max-height: 100vh; overflow-y: auto">
        <section class="u-clearfix u-section-1" id="block-1">
            <div class="u-clearfix u-sheet u-valign-top-xs u-sheet-1">
                <div class="u-container-style u-custom-color-2 u-expanded-width u-group u-group-1">
                    <div class="u-container-layout u-container-layout-1 fondo d-flex flex-column align-items-center">
                        <div>
                            <h4 id="txtNombreUsuario" runat="server" class="u-align-center-xs u-text u-text-default u-text-1"></h4>
                            <h5 id="txtCargo" runat="server" class="u-text-2"></h5>
                        </div>
                    </div>
                </div>
                <img class="u-image u-image-circle u-image-1" id="imgFotoPerfil" runat="server" src="#" alt="" data-image-width="400"
                    data-image-height="265">
                <div class="custom-expanded data-layout-selected u-clearfix u-gutter-10 u-layout-wrap u-layout-wrap-1">
                    <div class="u-gutter-0 u-layout">
                        <div class="u-layout-col">
                            <div class="u-container-style u-layout-cell u-shape-rectangle u-size-30 u-layout-cell-1">
                                <div class="u-container-layout u-container-layout-2">

                                    <h6 class="d-flex justify-content-center"><b>Hoja de vida</b></h6>
                                    <img class="u-image u-image-default u-image-2" src="https://cdn-icons-png.flaticon.com/512/6588/6588161.png"
                                        alt="" data-image-width="1024" data-image-height="1024">

                                    <div class="input-group mt-3 m-0 d-flex justify-content-center">
                                        <button type="button" id="btnMostrarHojaVida" class="btn" style="background-color: #10317a;" runat="server" data-bs-toggle="modal" data-bs-target="#modal2" onclick="mostrarPDF2();">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                                <g fill="none" stroke="#fff" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
                                                    <path d="M10 12a2 2 0 1 0 4 0a2 2 0 0 0-4 0" />
                                                    <path d="M21 12q-3.6 6-9 6t-9-6q3.6-6 9-6t9 6" />
                                                </g></svg>
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <div class="u-container-style u-layout-cell u-size-30 u-layout-cell-2">
                                <div class="u-container-layout u-container-layout-3">
                                    <h4 class="u-text u-text-default u-text-3">Contacto</h4>

                                    <span class="u-file-icon u-icon u-icon-2">
                                        <img src="recursos/imagenes/3002249.png" alt=""></span>
                                    <h6 id="txtTelefono" runat="server" class="u-text u-text-default u-text-4"></h6>

                                    <span class="u-file-icon u-icon u-icon-3">
                                        <img src="recursos/imagenes/347803.png" alt=""></span>
                                    <h6 id="txtCorreo" runat="server" class="u-text u-text-default u-text-5"></h6>

                                    <span class="u-file-icon u-icon u-icon-5">
                                        <img src="recursos/imagenes/535188.png" alt=""></span>
                                    <h6 id="txtDireccion" runat="server" class="u-text u-text-default u-text-7"></h6>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>





                <div class="u-group-2">





                    <%-- aaaaa --%>


                    <%-- Layout container detalles CV --%>
                    <div>
                        <br />

                        <%-- Descripcion CV --%>
                        <div class="form-group" style="margin-bottom: 10%; margin-top: 0;">

                            <div class="u-container-style mt-0 u-custom-color-2 u-group u-radius u-shape-round u-group-3">
                                <div class="u-container-layout">
                                    <h4 class="u-hover-feature u-text u-text-default u-text-white u-text-8">PERFIL PROFESIONAL</h4>
                                </div>
                            </div>



                            <p class="mt-3" id="txtDescripcionCV" runat="server"></p>

                        </div>
                        <br />
                        <br />
                        <div id="domDetallesCV" runat="server">

                            <%-- EXPERIENCIA --%>
                            <div style="margin-top: 5%">
                                <div class="u-container-style u-custom-color-2 u-group u-radius u-shape-round u-group-4">
                                    <div class="u-container-layout u-container-layout-6">
                                        <h4 class="u-hover-feature u-text u-text-default u-text-white u-text-11">EXPERIENCIA</h4>
                                    </div>
                                </div>


                                <div class="mt-2 p-3 border rounded shadow-sm bg-light" style="overflow-y: auto; max-height: 40vh;">
                                    <asp:Repeater ID="rpExperiencia" runat="server" OnItemCommand="rpExperiencia_ItemCommand">
                                        <ItemTemplate>
                                            <hr class="my-4 w-100 mx-auto" style="background-color: #10317A; height: 2px; border: none;">
                                            <div class="mb-3">

                                                <p><b><%# Eval("titulo") %></b></p>
                                                <p><%# Eval("descripcion") %></p>
                                                <asp:HiddenField ID="hfIDExperiencia" Value='<%# Eval("idExperiencia") %>' runat="server" />
                                                <asp:Button ID="btnVerSoporte" CommandName="abrirSoporte" CssClass="btn btn-warning" runat="server" Text="Ver Soporte" />
                                                <asp:HiddenField ID="hfRutaSoporte" Value='<%# Eval("soporte") %>' runat="server" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>

                            </div>

                            <%-- PROYECTOS DE DESARROLLO --%>
                            <div style="margin-top: 5%">
                                <div class="u-container-style u-custom-color-2 u-expanded-width-xs u-group u-radius u-shape-round u-group-5">
                                    <div class="u-container-layout u-container-layout-7">
                                        <h4 class="u-text u-text-default u-text-12">PROYECTOS DE DESARROLLO</h4>
                                    </div>
                                </div>
                                <div class="mt-2 p-3 border rounded shadow-sm bg-light" style="overflow-y: auto; max-height: 40vh">

                                    <asp:Repeater ID="rpProyectoDesarrollo" runat="server">
                                        <ItemTemplate>
                                            <hr class="my-4 w-auto mx-auto" style="background-color: #10317A">
                                            <div class="mb-3">


                                                <p><b><%# Eval("titulo") %></b></p>
                                                <p><%# Eval("descripcion") %></p>
                                                <asp:HiddenField ID="hfIDProD" Value='<%# Eval("idProyectoDesarrollo") %>' runat="server" />
                                            </div>

                                        </ItemTemplate>
                                    </asp:Repeater>


                                </div>
                            </div>

                            <%-- LOGROS ACADEMICOS --%>
                            <div style="margin-top: 5%">
                                <div class="u-container-style u-custom-color-2 u-group u-radius u-shape-round u-group-6">
                                    <div class="u-container-layout u-container-layout-8">
                                        <h4 class="u-text u-text-14">LOGROS ACADEMICOS</h4>
                                    </div>
                                </div>
                                <div class="mt-2 p-3 border rounded shadow-sm bg-light" style="overflow-y: auto; max-height: 40vh">

                                    <asp:Repeater ID="rpLogroAcademico" runat="server">
                                        <ItemTemplate>
                                            <hr class="my-4 w-auto mx-auto" style="background-color: #10317A">
                                            <div style="margin-bottom: 12px">


                                                <p><b>Titulo:</b><%# " " + Eval("tituloLogroAcademico") %></p>
                                                <p><b>Institución:</b><%# " " + Eval("nombreInstitucion") %></p>
                                                <p><b>Periodo:</b><%# " " + Eval("periodoTiempo") %></p>
                                                <p><b>Ubicacion:</b><%# " " + Eval("ubicacion") %></p>
                                                <p><b>Fecha:</b> <%# " " + Convert.ToDateTime(Eval("fechaEntrega")).ToString("yyyy-MM-dd") %></p>
                                                <p><b>Nivel academico:</b><%# " " + Eval("nivel") %></p>
                                                <asp:HiddenField ID="hfIDlogroAcademico" Value='<%# Eval("idLogroAcademico") %>' runat="server" />

                                            </div>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>

                            <%-- CERTIFICACION --%>
                            <div style="margin-top: 5%">
                                <div class="u-container-style u-custom-color-2 u-group u-radius u-shape-round u-group-7">
                                    <div class="u-container-layout u-container-layout-10">
                                        <h4 class="u-text u-text-default u-text-18">CERTIFICADOS</h4>
                                    </div>
                                </div>
                                <div class="mt-2 p-3 border rounded shadow-sm bg-light" style="overflow-y: auto; max-height: 40vh">
                                    <asp:Repeater ID="rpCertificacion" runat="server">
                                        <ItemTemplate>
                                            <hr class="my-4 w-auto mx-auto" style="background-color: #10317A">
                                            <div class="mb-3">

                                                <p><b><%# Eval("descripcionCertificacion") %></b></p>
                                                <p><b>Instituto:</b><%# " " + Eval("nombreInstitucion") %></p>
                                                <p><b>Fecha:</b><%# " " + Convert.ToDateTime(Eval("fechaObtencion")).ToString("yyyy-MM-dd") %></p>
                                                <asp:HiddenField ID="hfIDCertificacion" Value='<%# Eval("idCertificacion") %>' runat="server" />
                                            </div>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>

                            <%-- COMPETENCIAS --%>
                            <div style="margin-top: 5%">
                                <div class="u-container-style u-custom-color-2 u-group u-radius u-shape-round u-group-8">
                                    <div class="u-container-layout u-container-layout-10">
                                        <h4 class="u-text u-text-default u-text-18">HABILIDADES</h4>
                                    </div>
                                </div>
                                <div class="mt-2 p-3 border rounded shadow-sm bg-light" style="overflow-y: auto; max-height: 40vh">
                                    <asp:Repeater ID="rpCompetencia" runat="server">
                                        <ItemTemplate>
                                            <hr class="my-4 w-auto mx-auto" style="background-color: #10317A">
                                            <div class="mb-3">


                                                <p><b><%# Eval("nombre") %></b></p>
                                                <p>(<%# Eval("nombreCategoria") %>)</p>
                                                <p>(<%# Eval("nombreCategoria") %>)</p>
                                                <p><%# Eval("descripcion") %></p>
                                                <asp:HiddenField ID="hfIDcvc" Value='<%# Eval("idCurriculumVitaeCompetencia") %>' runat="server" />
                                            </div>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>

                            <%-- REFERENCIAS --%>
                            <div style="margin-top: 5%">
                                <div class="u-container-style u-custom-color-2 u-group u-radius u-shape-round u-group-9">
                                    <div class="u-container-layout u-container-layout-11">
                                        <h4 class="u-text u-text-default u-text-20">REFERENCIAS </h4>
                                    </div>
                                </div>
                                <div class="mt-2 p-3 border rounded shadow-sm bg-light" style="overflow-y: auto; max-height: 40vh">
                                    <asp:Repeater ID="rpReferencia" runat="server">
                                        <ItemTemplate>
                                            <hr class="my-4 w-auto mx-auto" style="background-color: #10317A">
                                            <div class="mb-3">


                                                <p><b>Persona de referencia:</b><%# " " + Eval("nombreReferencia") %></p>

                                                <p><b>Cargo:</b><%# " " +  Eval("cargo") %></p>

                                                <p><b>Empresa:</b><%# " " +  Eval("nombreEmpresa") %></p>

                                                <p><b>Telefono de contacto:</b><%# " " +  Eval("telefono") %></p>

                                                <p><b>Correo electronico:</b><%# " " +  Eval("correo") %></p>

                                                <p><b>Tipo de referencia:</b><%# " " +  Eval("tipoReferencia") %></p>

                                                <p><b>Relacion profesional:</b><%# " " +  Eval("relacionProfesional") %></p>

                                                <asp:HiddenField ID="hfIDReferencia" Value='<%# Eval("idReferencia") %>' runat="server" />

                                            </div>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>

                            <%-- IDIOMA --%>
                            <div style="margin-top: 5%">
                                <div class="u-container-style u-custom-color-2 u-group u-radius u-shape-round u-group-10">
                                    <div class="u-container-layout u-container-layout-12">
                                        <h4 class="u-hover-feature u-text u-text-default u-text-white u-text-22">IDIOMAS</h4>
                                    </div>
                                </div>
                                <div class="mt-2 p-3 border rounded shadow-sm bg-light" style="overflow-y: auto; max-height: 40vh">
                                    <asp:Repeater ID="rpIdioma" runat="server">
                                        <ItemTemplate>
                                            <hr class="my-4 w-auto mx-auto" style="background-color: #10317A">
                                            <div class="mb-3">

                                                <p><b>Idioma:</b><%# " " + Eval("nombre") %><b>(<%# Eval("nivel") %>)</b></p>

                                                <asp:HiddenField ID="hfIDidioma" Value='<%# Eval("idIdioma") %>' runat="server" />
                                            </div>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>


                        </div>

                    </div>



                    <%-- aaaaa --%>
                </div>

            </div>



        </section>


        <!-- Modal visualizar PDF Hoja de Vida-->
        <div class="modal fade" id="modal2" tabindex="-1" aria-labelledby="TituloModal2" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header h-auto">

                        <h4 class="modal-title fs-5" runat="server" style="text-align: center;"><b>Hoja de vida</b></h4>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>

                    </div>
                    <div class="modal-body modal-bodyO d-flex justify-content-center">
                        <h6 runat="server" id="txtMensaje" visible="false"></h6>

                        <div class="col-12 d-flex justify-content-center align-items-center">

                            <div class="col-2 d-flex justify-content-center">
                                <button type="button" id="prev-page" class="btn btn-circle" style="background-color: #10317a; border-radius: 50%;" >
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                        <path fill="#fff" d="M19 11H7.14l3.63-4.36a1 1 0 1 0-1.54-1.28l-5 6a1 1 0 0 0-.09.15c0 .05 0 .08-.07.13A1 1 0 0 0 4 12a1 1 0 0 0 .07.36c0 .05 0 .08.07.13a1 1 0 0 0 .09.15l5 6A1 1 0 0 0 10 19a1 1 0 0 0 .64-.23a1 1 0 0 0 .13-1.41L7.14 13H19a1 1 0 0 0 0-2" />
                                    </svg>
                                </button>
                            </div>

                            <div class="col-8 pdf-containerO">
                                <canvas id="pdf-canvasO"></canvas>
                            </div>

                            <div class="col-2 d-flex justify-content-center">
                                <button type="button" id="next-page" class="btn btn-circle" style="background-color: #10317a; border-radius: 50%;" >
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                        <path fill="#fff" d="M13.47 8.53a.75.75 0 0 1 1.06-1.06l4 4a.75.75 0 0 1 0 1.06l-4 4a.75.75 0 1 1-1.06-1.06l2.72-2.72H6.5a.75.75 0 0 1 0-1.5h9.69z" />
                                    </svg>
                                </button>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>


        <!-- Modal visualizar Soporte-->
        <div class="modal fade" id="modal3" tabindex="-1" aria-labelledby="TituloModal3" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title fs-5"><b>Certificado de experiencia laboral</b></h4>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body modal-bodyO d-flex justify-content-center">

                        <div class="col-12 d-flex justify-content-center align-items-center">
                            <div class="col-2 d-flex justify-content-center">
                                <button type="button" id="prev-page2" class="btn btn-circle" style="background-color: #10317a; border-radius: 50%;" >
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                        <path fill="#fff" d="M19 11H7.14l3.63-4.36a1 1 0 1 0-1.54-1.28l-5 6a1 1 0 0 0-.09.15c0 .05 0 .08-.07.13A1 1 0 0 0 4 12a1 1 0 0 0 .07.36c0 .05 0 .08.07.13a1 1 0 0 0 .09.15l5 6A1 1 0 0 0 10 19a1 1 0 0 0 .64-.23a1 1 0 0 0 .13-1.41L7.14 13H19a1 1 0 0 0 0-2" />
                                    </svg>
                                </button>
                            </div>
                            <div class="col-8 pdf-containerO">
                                <canvas id="pdf-canvas2"></canvas>

                            </div>
                            <div class="col-2 d-flex justify-content-center">
                                <button type="button" id="next-page2" class="btn btn-circle" style="background-color: #10317a; border-radius: 50%;" >
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                        <path fill="#fff" d="M13.47 8.53a.75.75 0 0 1 1.06-1.06l4 4a.75.75 0 0 1 0 1.06l-4 4a.75.75 0 1 1-1.06-1.06l2.72-2.72H6.5a.75.75 0 0 1 0-1.5h9.69z" />
                                    </svg>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <asp:HiddenField ID="hfHojaVida" runat="server" />
        <asp:HiddenField ID="hfSoporte" runat="server" />
        <script src="recursos/js/main7.js"></script>
    </div>
</asp:Content>
