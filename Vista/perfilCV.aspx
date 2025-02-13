<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/menu.Master" AutoEventWireup="true" CodeBehind="perfilCV.aspx.cs" Inherits="HIRE.Vista.perfilCV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">


    <title>Página 1</title>
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_Body" runat="server">
    <div style="max-height: 100vh; overflow-y: auto">

        <h4 class="fs-3" style="text-align: center">Mi CV</h4>
        <hr class="my-4 w-100 mx-auto" style="background-color: #10317A; text-align: center">

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
                                        <button type="button" id="btnMostrarHojaVida" class="btn" style="background-color: #10317a;" runat="server" data-bs-toggle="modal" data-bs-target="#modal2" onclick="mostrarPDF();">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                                <g fill="none" stroke="#fff" stroke-linecap="round" stroke-linejoin="round" stroke-width="2">
                                                    <path d="M10 12a2 2 0 1 0 4 0a2 2 0 0 0-4 0" />
                                                    <path d="M21 12q-3.6 6-9 6t-9-6q3.6-6 9-6t9 6" />
                                                </g></svg>
                                        </button>
                                        <asp:Button ID="a9" OnClick="btnAbrirModalActualizarCV_ServerClick" Style="border: 1px solid;" CssClass="btn" Text="✏️" runat="server" />

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

                                    <br />
                                    <br />
                                    <br />

                                    <div class="d-flex justify-content-center">
                                        <button id="btnAgregarDetalles" type="button" class="btn btn-warning w-auto" data-bs-toggle="modal" data-bs-target="#modalDetalles">Agregar Detalles</button>
                                    </div>
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
                            <asp:Button ID="a1" OnClick="btnAbrirModalActualizarCV_ServerClick" CssClass="btn btn-circle mt-0" runat="server" Text="✏️" />


                            <button type="button" runat="server" visible="false" id="btnAgregarCV" class="btn ml-1" data-bs-toggle="modal" data-bs-target="#staticBackdrop" style="border: 1px solid; border-radius: 50px; width: 50px; height: 50px;">
                                <span>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                        <g fill="none">
                                            <path d="m12.593 23.258l-.011.002l-.071.035l-.02.004l-.014-.004l-.071-.035q-.016-.005-.024.005l-.004.01l-.017.428l.005.02l.01.013l.104.074l.015.004l.012-.004l.104-.074l.012-.016l.004-.017l-.017-.427q-.004-.016-.017-.018m.265-.113l-.013.002l-.185.093l-.01.01l-.003.011l.018.43l.005.012l.008.007l.201.093q.019.005.029-.008l.004-.014l-.034-.614q-.005-.018-.02-.022m-.715.002a.02.02 0 0 0-.027.006l-.006.014l-.034.614q.001.018.017.024l.015-.002l.201-.093l.01-.008l.004-.011l.017-.43l-.003-.012l-.01-.01z" />
                                            <path fill="#10317A" d="M10.5 20a1.5 1.5 0 0 0 3 0v-6.5H20a1.5 1.5 0 0 0 0-3h-6.5V4a1.5 1.5 0 0 0-3 0v6.5H4a1.5 1.5 0 0 0 0 3h6.5z" />
                                        </g></svg></span></button>

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
                                                <div class="input-group" style="height: 50px;">
                                                    <p><b><%# Eval("titulo") %></b></p>
                                                    <asp:Button ID="a7" OnClick="btnAbrirModalActualizarCV_ServerClick" CssClass="btn" runat="server" Text="✏️" />
                                                </div>
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
                                        <h4 class="u-text u-text-default u-text-12">PROYECTOS DE DESARROLLO </h4>
                                    </div>
                                </div>
                                <div class="mt-2 p-3 border rounded shadow-sm bg-light" style="overflow-y: auto; max-height: 40vh">
                                    <asp:Repeater ID="rpProyectoDesarrollo" runat="server">
                                        <ItemTemplate>
                                            <hr class="my-4 w-auto mx-auto" style="background-color: #10317A">
                                            <div class="mb-3">

                                                <div class="input-group" style="height: 50px;">
                                                    <p><b><%# Eval("titulo") %></b></p>
                                                    <asp:Button ID="a4" OnClick="btnAbrirModalActualizarCV_ServerClick" CssClass="btn" runat="server" Text="✏️" />
                                                </div>
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

                                                <div class="input-group" style="height: 50px;">
                                                    <p><b>Titulo:</b><%# " " + Eval("tituloLogroAcademico") %></p>
                                                    <asp:Button ID="a8" OnClick="btnAbrirModalActualizarCV_ServerClick" CssClass="btn" runat="server" Text="✏️" />
                                                </div>
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
                                                <div class="input-group" style="height: 50px;">
                                                    <p><b><%# Eval("descripcionCertificacion") %></b></p>
                                                    <asp:Button ID="a3" OnClick="btnAbrirModalActualizarCV_ServerClick" CssClass="btn" runat="server" Text="✏️" />
                                                </div>
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

                                                <div class="input-group" style="height: 50px;">
                                                    <p><b><%# Eval("nombre") %></b></p>
                                                    <asp:Button ID="a2" OnClick="btnAbrirModalActualizarCV_ServerClick" CssClass="btn" runat="server" Text="✏️" />
                                                </div>
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

                                                <div class="input-group" style="height: 50px;">
                                                    <p><b>Persona de referencia:</b><%# " " + Eval("nombreReferencia") %></p>
                                                    <asp:Button ID="a5" OnClick="btnAbrirModalActualizarCV_ServerClick" CssClass="btn" runat="server" Text="✏️" />
                                                </div>



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
                                                <div class="input-group" style="height: 50px;">
                                                    <p><b>Idioma:</b><%# " " + Eval("nombre") %><b>(<%# Eval("nivel") %>)</b></p>
                                                    <asp:Button ID="a6" OnClick="btnAbrirModalActualizarCV_ServerClick" CssClass="btn" runat="server" Text="✏️" />
                                                </div>
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


        <%-- Modal registro CV --%>
        <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="staticBackdropLabel">Agregar información a tu perfil Profesional</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">

                        <h6><b>Describe brevemente tu perfil profesional</b></h6>
                        <h6 class="mb-0">Resalta tu experiencia, habilidades y logros en pocas palabras.</h6>
                        <asp:TextBox ID="txtNuevaDescripcion" CssClass="form-control" TextMode="SingleLine" MaxLength="3000" runat="server"></asp:TextBox>

                        <br />
                        <br />
                        <h6><b>• 📄 Adjunta tu hoja de vida (opcional)</b></h6>
                        <h6><b>• Formato permitido: PDF</b></h6>


                        <asp:FileUpload ID="cargarDocPDF" CssClass="form-control" runat="server" />



                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnAnadirCV" CausesValidation="true" OnClick="btnAgregarCV_ServerClick" OnClientClick="validarFormulario()" CssClass="btn btn-success" runat="server" Text="Agregar" />
                    </div>
                </div>
            </div>
        </div>


        <%-- Modal registro Detalles Usuario --%>
        <div class="modal fade" id="modalDetalles" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="modalDetallesLabel" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="modalDetallesLabel">Completa tu CV.</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">

                        <ul class="nav nav-tabs" id="tabDetalles" role="tablist">
                            <li class="nav-item" role="presentation">
                                <button class="nav-link active" id="experiencia-tab" data-bs-toggle="tab" data-bs-target="#exp-tab-pane" type="button" role="tab" aria-controls="exp-tab-pane" aria-selected="true">Experiencia</button>
                            </li>
                            <li class="nav-item" role="presentation">
                                <button class="nav-link" id="proyectosD-tab" data-bs-toggle="tab" data-bs-target="#proD-tab-pane" type="button" role="tab" aria-controls="proD-tab-pane" aria-selected="false">Proyectos de Desarrollo</button>
                            </li>
                            <li class="nav-item" role="presentation">
                                <button class="nav-link" id="logrosA-tab" data-bs-toggle="tab" data-bs-target="#logrosA-tab-pane" type="button" role="tab" aria-controls="logrosA-tab-pane" aria-selected="false">Logros academicos</button>
                            </li>
                            <li class="nav-item" role="presentation">
                                <button class="nav-link" id="certificacion-tab" data-bs-toggle="tab" data-bs-target="#certf-tab-pane" type="button" role="tab" aria-controls="certf-tab-pane" aria-selected="false">Certificaciones</button>
                            </li>
                            <li class="nav-item" role="presentation">
                                <button class="nav-link" id="competencia-tab" data-bs-toggle="tab" data-bs-target="#compt-tab-pane" type="button" role="tab" aria-controls="compt-tab-pane" aria-selected="false">Competencias</button>
                            </li>
                            <li class="nav-item" role="presentation">
                                <button class="nav-link" id="referencia-tab" data-bs-toggle="tab" data-bs-target="#ref-tab-pane" type="button" role="tab" aria-controls="ref-tab-pane" aria-selected="false">Referencias</button>
                            </li>
                            <li class="nav-item" role="presentation">
                                <button class="nav-link" id="idioma-tab" data-bs-toggle="tab" data-bs-target="#idioma-tab-pane" type="button" role="tab" aria-controls="idioma-tab-pane" aria-selected="false">Idioma</button>
                            </li>
                        </ul>
                        <div class="tab-content" id="groupTapContent">

                            <div class="tab-pane fade show active" id="exp-tab-pane" role="tabpanel" aria-labelledby="experiencia-tab" tabindex="0">
                                <div class="mb-3 d-flex justify-content-center">
                                    <h3 class="fs-3">Experiencia laboral</h3>
                                </div>
                                <div class="row col-12">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <h5 class="mb-0">Titulo</h5>
                                        <asp:TextBox ID="txtTituloExp" CssClass="form-control" MaxLength="80" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Descripción</h5>
                                        <asp:TextBox ID="txtDescripExp" CssClass="form-control" MaxLength="400" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Soporte<b>(Unicamente PDF)</b></h5>
                                        <asp:FileUpload ID="fuSoporteExp" CssClass="form-control" runat="server" accept=".pdf" />
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                <div class="mb-5 mt-5 d-flex justify-content-center">
                                    <asp:Button ID="btnAgregarExp" runat="server" OnClick="btnAgregarDetalles_ServerClick" CssClass="btn btn-success" Text="Agregar" />
                                </div>

                            </div>
                            <div class="tab-pane fade" id="proD-tab-pane" role="tabpanel" aria-labelledby="proyectosD-tab" tabindex="0">
                                <div class="mb-3 d-flex justify-content-center">
                                    <h3 class="fs-3">Proyecto desarrollado</h3>
                                </div>
                                <div class="row col-12">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <h5 class="mb-0">Titulo</h5>
                                        <asp:TextBox ID="txtTituloProD" CssClass="form-control" MaxLength="80" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Descripción</h5>
                                        <asp:TextBox ID="txtDescripcionProD" CssClass="form-control" MaxLength="400" TextMode="SingleLine" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                <div class="mb-5 mt-5 d-flex justify-content-center">
                                    <asp:Button ID="btnAgregarProD" runat="server" OnClick="btnAgregarDetalles_ServerClick" CssClass="btn btn-success" Text="Agregar" />
                                </div>


                            </div>
                            <div class="tab-pane fade" id="logrosA-tab-pane" role="tabpanel" aria-labelledby="logrosA-tab" tabindex="0">
                                <div class="mb-3 d-flex justify-content-center">
                                    <h3 class="fs-3">Logro Academico</h3>
                                </div>


                                <div class="row col-12">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <h5 class="mb-0">Logro academico obtenido</h5>
                                        <asp:TextBox ID="txtTituloLogro" CssClass="form-control" MaxLength="50" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Nombre del instituto</h5>
                                        <asp:TextBox ID="txtInstitucion" CssClass="form-control" MaxLength="50" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Periodo</h5>
                                        <asp:TextBox ID="txtPeriodoLogro" placeholder="Ej: 2004 - 2022" CssClass="form-control" MaxLength="20" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Municipio de entrega</h5>
                                        <asp:TextBox ID="txtUbicacionlogro" CssClass="form-control" MaxLength="50" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Fecha de entrega</h5>
                                        <asp:TextBox ID="txtFechaEntregaLogro" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Nivel academico alcanzado</h5>
                                        <asp:DropDownList ID="dpNivelAcademico" CssClass="form-control" runat="server">
                                            <asp:ListItem Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                <div class="mb-5 mt-5 d-flex justify-content-center">
                                    <asp:Button ID="btnAgregarLogroA" runat="server" OnClick="btnAgregarDetalles_ServerClick" CssClass="btn btn-success" Text="Agregar" />
                                </div>
                            </div>
                            <div class="tab-pane fade" id="certf-tab-pane" role="tabpanel" aria-labelledby="certificacion-tab" tabindex="0">
                                <div class="mb-3 d-flex justify-content-center">
                                    <h3 class="fs-3">Certificación</h3>
                                </div>
                                <div class="row col-12">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <h5 class="mb-0">Titulo de la certificación</h5>
                                        <asp:TextBox ID="txtTituloCertf" CssClass="form-control" MaxLength="80" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Nombre del instituto que lo certifico.</h5>
                                        <asp:TextBox ID="txtInstitutoCertf" CssClass="form-control" MaxLength="400" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Fecha de obtencion</h5>
                                        <asp:TextBox ID="txtFechaObtencion" CssClass="form-control" MaxLength="400" TextMode="Date" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                <div class="mb-5 mt-5 d-flex justify-content-center">
                                    <asp:Button ID="btnAgregarCertf" runat="server" OnClick="btnAgregarDetalles_ServerClick" CssClass="btn btn-success" Text="Agregar" />
                                </div>
                            </div>
                            <div class="tab-pane fade" id="compt-tab-pane" role="tabpanel" aria-labelledby="competencia-tab" tabindex="0">
                                <div class="mb-3 d-flex justify-content-center">
                                    <h3 class="fs-3">Habilidades</h3>
                                </div>
                                <div class="row col-12">
                                    <div class="col-3"></div>
                                    <div class="col-6 h-auto">
                                        <h5 class="mb-0">Elige una habilidad</h5>
                                        <asp:DropDownList ID="dpCompetencia" CssClass="form-control" runat="server">
                                            <asp:ListItem Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                <br />
                                <div class="mb-5 mt-5 d-flex justify-content-center">
                                    <asp:Button ID="btnAgregarCompt" runat="server" OnClick="btnAgregarDetalles_ServerClick" CssClass="btn btn-success" Text="Agregar" />
                                </div>
                            </div>
                            <div class="tab-pane fade" id="ref-tab-pane" role="tabpanel" aria-labelledby="referencia-tab" tabindex="0">
                                <div class="mb-3 d-flex justify-content-center">
                                    <h3 class="fs-3">Referencia laboral</h3>
                                </div>
                                <div class="row col-12">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <h5 class="mb-0">Nombre del referente</h5>
                                        <asp:TextBox ID="txtNombreRef" CssClass="form-control" MaxLength="80" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Cargo</h5>
                                        <asp:TextBox ID="txtCargoRef" CssClass="form-control" MaxLength="400" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Nombre de la empresa o negocio</h5>
                                        <asp:TextBox ID="txtNombreEmpresaRef" CssClass="form-control" MaxLength="400" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Telefono de contacto</h5>
                                        <asp:TextBox ID="txtTelefonoRef" CssClass="form-control" MaxLength="400" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Correo electronico</h5>
                                        <asp:TextBox ID="txtCorreoRef" CssClass="form-control" MaxLength="400" TextMode="Email" runat="server"></asp:TextBox>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Tipo de referencia</h5>
                                        <asp:DropDownList ID="dpTipoRef" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Selecciona el tipo de referencia" Value="" />
                                            <asp:ListItem Text="Referencia Laboral" Value="Referencia Laboral" />
                                            <asp:ListItem Text="Referencia Académica" Value="Referencia Académica" />
                                            <asp:ListItem Text="Referencia Personal" Value="Referencia Personal" />
                                        </asp:DropDownList>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Relacion profesional</h5>
                                        <asp:DropDownList ID="dpRelacionProRef" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Selecciona la relación con el referente" Value="" />
                                            <asp:ListItem Text="Supervisor Directo" Value="Supervisor" />
                                            <asp:ListItem Text="Compañero de Trabajo" Value="Compañero" />
                                            <asp:ListItem Text="Subordinado" Value="Subordinado" />
                                            <asp:ListItem Text="Cliente o Socio" Value="Cliente" />
                                            <asp:ListItem Text="Profesor o Mentor" Value="Profesor" />
                                            <asp:ListItem Text="Amigo o Conocido" Value="Amigo" />
                                        </asp:DropDownList>

                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                <div class="mb-5 mt-5 d-flex justify-content-center">
                                    <asp:Button ID="btnAgregarRef" runat="server" OnClick="btnAgregarDetalles_ServerClick" CssClass="btn btn-success" Text="Agregar" />
                                </div>
                            </div>
                            <div class="tab-pane fade" id="idioma-tab-pane" role="tabpanel" aria-labelledby="idioma-tab" tabindex="0">
                                <div class="mb-3 d-flex justify-content-center">
                                    <h3 class="fs-3">Idioma</h3>
                                </div>
                                <div class="row col-12">
                                    <div class="col-3"></div>
                                    <div class="col-6">
                                        <h5 class="mb-0">Selecciona el idioma</h5>
                                        <asp:DropDownList ID="dpIdiomas" CssClass="form-control" runat="server">
                                            <asp:ListItem Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <br />
                                        <h5 class="mb-0">Nivel</h5>
                                        <asp:TextBox ID="txtNivelIdi" CssClass="form-control" MaxLength="400" TextMode="SingleLine" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-3"></div>
                                </div>
                                <div class="mb-5 mt-5 d-flex justify-content-center">
                                    <asp:Button ID="btnAgregarIdi" runat="server" OnClick="btnAgregarDetalles_ServerClick" CssClass="btn btn-success" Text="Agregar" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>


        <!-- Modal visualizar PDF Hoja de Vida-->
        <div class="modal fade" id="modal2" tabindex="-1" aria-labelledby="TituloModal2" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header h-auto">

                        <h4 class="modal-title fs-5" runat="server" style="text-align: center;"><b>Hoja de vida</b></h4>
                        <button type="button" class="btn btn-close" data-bs-dismiss="modal" aria-label="Close"></button>

                    </div>
                    <div class="modal-body modal-bodyO d-flex justify-content-center">
                        <h6 runat="server" id="txtMensaje" visible="false"></h6>

                        <div class="col-12 d-flex justify-center-between align-items-center">
                            <div class="col-2 d-flex justify-content-center">
                                <button type="button" id="prev-page" class="btn btn-circle" style="background-color: #10317a; border-radius: 50%;">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                        <path fill="none" stroke="#fff" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m5 12l6-6m-6 6l6 6m-6-6h14" />
                                    </svg>
                                </button>
                            </div>

                            <div class="col-8 pdf-containerO">
                                <canvas id="pdf-canvasO"></canvas>
                            </div>

                            <div class="col-2 d-flex justify-content-center">
                                <button type="button" id="next-page" class="btn btn-circle" style="background-color: #10317a; border-radius: 50%;">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                        <path fill="none" stroke="#fff" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 12h16m-7-7l7 7l-7 7" />
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
                        <h4 class="modal-title fs-5"><b>Soporte</b></h4>
                        <button runat="server" class="btn" data-bs-dismiss="modal" aria-label="Close">X</button>
                    </div>
                    <div class="modal-body modal-bodyO d-flex justify-content-center">

                        <div class="col-12 d-flex justify-content-center align-items-center">
                            <div class="col-2 d-flex justify-content-center">
                                <button type="button" id="prev-page2" class="btn btn-circle" style="background-color: #10317a; border-radius: 50%;">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                        <path fill="none" stroke="#fff" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m5 12l6-6m-6 6l6 6m-6-6h14" />
                                    </svg>
                                </button>
                            </div>
                            <div class="col-8 pdf-containerO">
                                <canvas id="pdf-canvas2"></canvas>

                            </div>
                            <div class="col-2 d-flex justify-content-center">
                                <button type="button" id="next-page2" class="btn btn-circle" style="background-color: #10317a; border-radius: 50%;">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                        <path fill="none" stroke="#fff" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 12h16m-7-7l7 7l-7 7" />
                                    </svg>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <%-- Modal Actualizar Detalles CV --%>
        <div class="modal fade" id="modalActualizarDetalles" tabindex="-1" aria-labelledby="modalProDTitle" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title fs-5" runat="server" id="modalTitleDynamic"></h2>
                        <button runat="server" class="btn" data-bs-dismiss="modal" aria-label="Close">X</button>
                    </div>
                    <div class="modal-body">

                        <!-- Perfil Profesional -->
                        <div id="divPerfilProfesional" class="mt-3" runat="server" visible="false">
                            <textarea id="txtActualizarDescripcion" class="form-control" runat="server" cols="20" rows="2"></textarea>
                        </div>

                        <!-- Hoja de Vida -->
                        <div id="divHojadeVida" class="mt-3" runat="server" visible="false">
                            <h5 class="mb-0" id="h5UrlArchivo" runat="server">Sube tu hoja de vida <b>(Unicamente PDF)</b></h5>
                            <asp:FileUpload ID="fuUrlArchivo" CssClass="form-control" runat="server" accept=".pdf" />
                        </div>

                        <!-- Actualizar Competencia -->
                        <div id="divRegistroCompetencia" class="mt-3" runat="server" visible="false">
                            <asp:DropDownList ID="dpActualizarCompetencia" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>

                        <!-- Certificación -->
                        <div id="divCertificacion" class="mt-3" runat="server" visible="false">
                            <h5 class="mb-0" id="h5DescripcionCertificacion" runat="server">Titulo de la certificación</h5>
                            <textarea id="txtActualizarDescripcionCertificacion" class="form-control" runat="server" cols="20" rows="2"></textarea>
                            <br />
                            <h5 class="mb-0" id="h5Entidad" runat="server">Nombre del instituto que lo certifico.</h5>
                            <asp:TextBox ID="txtActualizarEntidad" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                            <br />
                            <h5 class="mb-0" id="h5FechaCertificacion" runat="server">Fecha de obtención.</h5>
                            <asp:TextBox ID="txtActualizarFecha" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                        </div>

                        <!-- Proyecto de Desarrollo -->
                        <div id="divProyectoDesarrollo" class="mt-3" runat="server" visible="false">
                            <h5 class="mb-0" id="h5TituloProyecto" runat="server">Título</h5>
                            <asp:TextBox ID="txtActualizarTitulo" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                            <br />
                            <h5 class="mb-0" id="h5DescripcionProyecto" runat="server">Descripción</h5>
                            <textarea id="txtActualizarDescripcionProyecto" class="form-control" runat="server" cols="20" rows="2"></textarea>
                        </div>

                        <!-- Referencia -->
                        <div id="divReferencia" runat="server" class="mt-3" style="overflow-y: auto" visible="false">
                            <h5 class="mb-0" id="h5Nombre" runat="server">Nombre del referente</h5>
                            <asp:TextBox ID="txtActualizarNombre" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                            <br />
                            <h5 class="mb-0" id="h5Cargo" runat="server">Cargo</h5>
                            <asp:TextBox ID="txtActualizarCargo" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                            <br />
                            <h5 class="mb-0" id="h1" runat="server">Nombre de la empresa o negocio</h5>
                            <asp:TextBox ID="txtActualizarEmpresaRef" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                            <br />
                            <h5 class="mb-0" id="h5Telefono" runat="server">Teléfono de contacto</h5>
                            <asp:TextBox ID="txtActualizarTelefono" CssClass="form-control" TextMode="Phone" runat="server"></asp:TextBox>
                            <br />
                            <h5 class="mb-0" id="h5Correo" runat="server">Correo Electrónico</h5>
                            <asp:TextBox ID="txtActualizarCorreo" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
                            <br />
                            <h5 class="mb-0" id="h5TipoRef" runat="server">Tipo de Referencia</h5>
                            <asp:DropDownList ID="dpActualizarTipoRef" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Selecciona el tipo de referencia" Value="" />
                                <asp:ListItem Text="Referencia Laboral" Value="Referencia Laboral" />
                                <asp:ListItem Text="Referencia Académica" Value="Referencia Académica" />
                                <asp:ListItem Text="Referencia Personal" Value="Referencia Personal" />
                            </asp:DropDownList>
                            <br />
                            <h5 class="mb-0" id="h5RelacionPro" runat="server">Relación Profesional</h5>
                            <asp:DropDownList ID="dpActualizarRelacionPro" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Selecciona la relación con el referente" Value="" />
                                <asp:ListItem Text="Supervisor Directo" Value="Supervisor" />
                                <asp:ListItem Text="Compañero de Trabajo" Value="Compañero" />
                                <asp:ListItem Text="Subordinado" Value="Subordinado" />
                                <asp:ListItem Text="Cliente o Socio" Value="Cliente" />
                                <asp:ListItem Text="Profesor o Mentor" Value="Profesor" />
                                <asp:ListItem Text="Amigo o Conocido" Value="Amigo" />
                            </asp:DropDownList>
                        </div>

                        <!-- Idioma -->
                        <div id="divIdioma" runat="server" class="mt-3" visible="false">
                            <h5 class="mb-0" id="h5Idioma" runat="server">Selecciona el idioma</h5>
                            <asp:DropDownList ID="dpActualizarIdioma" CssClass="form-control" runat="server"></asp:DropDownList>
                            <br />
                            <h5 class="mb-0" id="h5NivelIdioma" runat="server">Nivel</h5>
                            <asp:TextBox ID="txtActualizarNivel" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>

                        <!-- Experiencia -->
                        <div id="divExperiencia" runat="server" class="mt-3" visible="false">
                            <h5 class="mb-0" id="h5TituloExperiencia" runat="server">Título</h5>
                            <asp:TextBox ID="txtActualizarTituloExperiencia" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                            <br />
                            <h5 class="mb-0" id="h5DescripcionExperiencia" runat="server">Descripción</h5>
                            <textarea id="txtActualizarDescripcionExperiencia" class="form-control" runat="server" cols="20" rows="2"></textarea>
                            <br />
                            <h5 class="mb-0" id="h5UrlArchivoExperiencia" runat="server">Soporte<b>(Unicamente PDF)</b></h5>
                            <asp:FileUpload ID="fuUrlArchivoExperiencia" CssClass="form-control" runat="server" accept=".pdf" />
                        </div>

                        <!-- Logro Académico -->
                        <div id="divLogroAcademico" class="mt-3" runat="server" visible="false">
                            <h5 class="mb-0" id="h5TituloLogro" runat="server">Logro academico obtenido</h5>
                            <asp:TextBox ID="txtActualizarTituloLogro" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                            <br />
                            <h5 class="mb-0" id="h5EntidadLogro" runat="server">Nombre del instituto</h5>
                            <asp:TextBox ID="txtActualizarEntidadLogro" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                            <br />
                            <h5 class="mb-0" id="h5PeriodoLogro" runat="server">Período</h5>
                            <asp:TextBox ID="txtActualizarPeriodoLogro" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                            <br />
                            <h5 class="mb-0" id="h5UbicacionLogro" runat="server">Municipio de entrega</h5>
                            <asp:TextBox ID="txtActualizarUbicacionLogro" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                            <br />
                            <h5 class="mb-0" id="h5FechaLogro" runat="server">Fecha de entrega</h5>
                            <asp:TextBox ID="txtActualizarFechaLogro" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                            <br />
                            <h5 class="mb-0" id="h5NivelAcademico" runat="server">Nivel academico alcanzado</h5>
                            <asp:DropDownList ID="dpActualizarNivelAcademico" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <asp:HiddenField ID="hfIdDetalle" runat="server" />

                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="d11" CssClass="btn btn-warning" OnClick="btnActualizarDetalles_ServerClick" Visible="false" runat="server" Text="Guardar Cambios" />
                        <asp:Button ID="d12" CssClass="btn btn-warning" OnClick="btnActualizarDetalles_ServerClick" Visible="false" runat="server" Text="Guardar Cambios" />
                        <asp:Button ID="d2" CssClass="btn btn-warning" OnClick="btnActualizarDetalles_ServerClick" Visible="false" runat="server" Text="Guardar Cambios" />
                        <asp:Button ID="d3" CssClass="btn btn-warning" OnClick="btnActualizarDetalles_ServerClick" Visible="false" runat="server" Text="Guardar Cambios" />
                        <asp:Button ID="d4" CssClass="btn btn-warning" OnClick="btnActualizarDetalles_ServerClick" Visible="false" runat="server" Text="Guardar Cambios" />
                        <asp:Button ID="d5" CssClass="btn btn-warning" OnClick="btnActualizarDetalles_ServerClick" Visible="false" runat="server" Text="Guardar Cambios" />
                        <asp:Button ID="d6" CssClass="btn btn-warning" OnClick="btnActualizarDetalles_ServerClick" Visible="false" runat="server" Text="Guardar Cambios" />
                        <asp:Button ID="d7" CssClass="btn btn-warning" OnClick="btnActualizarDetalles_ServerClick" Visible="false" runat="server" Text="Guardar Cambios" />
                        <asp:Button ID="d8" CssClass="btn btn-warning" OnClick="btnActualizarDetalles_ServerClick" Visible="false" runat="server" Text="Guardar Cambios" />
                    </div>
                </div>
            </div>
        </div>


        <asp:HiddenField ID="hfHojaVida" runat="server" />
        <asp:HiddenField ID="hfSoporte" runat="server" />
        <script src="recursos/js/main5.js"></script>

    </div>
</asp:Content>
