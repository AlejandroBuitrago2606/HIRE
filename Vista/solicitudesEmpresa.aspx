<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/panelEmpresa.Master" EnableEventValidation="true" AutoEventWireup="true" CodeBehind="solicitudesEmpresa.aspx.cs" Inherits="HIRE.Vista.solicitudesEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="/Content/alertifyjs/alertify.css" />
    <link rel="stylesheet" href="/Content/alertifyjs/themes/default.css" />
    <script src="/Scripts/alertify.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">

    <div class="content-body-scrollable">
        <div class="container">
            <br />
            <div class=" d-flex justify-content-center">
                <h3>Solicitudes de empleo recibidas</h3>
                <br />
            </div>

            <br />

            <div class="d-flex justify-content-center">
                <div class="input-group mb-3" style="width: 50%;">
                    <asp:TextBox ID="txtBuscar" CssClass="form-control" placeholder="Buscar postulaciones..." runat="server"></asp:TextBox>
                    <button class="btn btn-outline-warning" runat="server" id="btnBuscarSolicitud">Buscar</button>
                </div>
            </div>
            <br />

            <div runat="server" id="domMsg" class="mt-4" visible="false">
                <div class="d-flex justify-content-center">
                    <h4 runat="server" id="tituloMsg">No tienes ninguna solicitud de empleo pendiente</h4>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <%-- contenido de la pagina aqui --%>
                    <asp:Repeater runat="server" ID="rpSolicitudes">
                        <ItemTemplate>
                            <div class="card sombra1 mb-4 shadow-sm">
                                <div class="card-body" style="margin-top: 0">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="row">
                                                <h3 runat="server" style="font-size: 100%;" id="txtTitulo"><b>Vacante:</b><%# " " + Eval("titulo") %></h3>
                                            </div>
                                            <div class="row">
                                                <h4 runat="server" style="font-size: 80%; color: gray;" id="H1"><b>Fecha de postulación:</b><%# " " + Convert.ToDateTime(Eval("fechaEnvio")).ToString("yyyy-MM-dd") %></h4>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnPanelEmpresa" CssClass="btn btn-warning" OnCommand="btnVerVacante_Click" data-bs-toggle="modal" data-bs-target="#datosVacante"
                                                CommandName="enviarIDVacante" CommandArgument='<%# Eval("idVacante") %>' runat="server" Text="Vacante" />

                                        </div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="col-6">
                                                    <div class="row">
                                                        <asp:Button ID="btnVerCV" OnCommand="btnVerDatos_Command" CommandName="verDatos" CssClass="btn colorBase" CommandArgument='<%# Eval("idUsuario") %>' runat="server" Text="Ver CV del candidato" />
                                                    </div>
                                                    <div class="row">
                                                        <asp:Button ID="btnVerUsuario" OnCommand="btnVerDatos_Command" CommandName="verDatos" CssClass="btn btn-warning" CommandArgument='<%# Eval("idUsuario") %>' runat="server" Text="Ver Perfil del candidato" />
                                                    </div>
                                                </div>
                                                <div class="col-6">

                                                    <div class="row">
                                                        <asp:Button ID="btnSi" OnClick="btnEvaluarSolicitud_Click" CommandName="evaluarSolicitud" CommandArgument='<%# Eval("idSolicitud") %>' CssClass="btn btn-success" runat="server" Text="Si aplica" />
                                                    </div>
                                                    <div class="row">
                                                        <asp:Button ID="btnNo" OnClick="btnEvaluarSolicitud_Click" CommandArgument='<%# Eval("idSolicitud") %>' CssClass="btn btn-danger" runat="server" Text="No aplica" />
                                                    </div>

                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-md-2"></div>
            </div>
        </div>

    </div>




    <div class="modal fade" id="datosVacante" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable">
            <div class="modal-content">
                <div class="modal-header">
                    <div class="d-flex justify-content-center">
                        <h1 class="modal-title fs-4" style="text-align: center" id="exampleModalLabel">Informacion de la vacante</h1>
                    </div>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">

                    <div class="d-flex justify-content-center">
                        <h5 runat="server" id="txtTitulo" style="font-weight: bold;"></h5>
                    </div>

                    <br />
                    <h6 runat="server" id="txtDescripcion"></h6>
                    <br />

                    <div class="input-group">
                        <h6><b>Empleo </b></h6>
                        <h6 runat="server" id="txtTipoEmpleo"></h6>
                    </div>

                    <div class="input-group">
                        <h6><b>Contrato </b></h6>
                        <h6 runat="server" id="txtTipoContrato"></h6>
                    </div>

                    <div class="input-group">
                        <h6><b>Jornada </b></h6>
                        <h6 runat="server" id="txtJornada"></h6>
                    </div>

                    <div class="input-group">
                        <h6><b>Horario </b></h6>
                        <h6 runat="server" id="txtHorario"></h6>
                    </div>

                    <br />

                    <div class="input-group">
                        <h6><b>Salario </b></h6>
                        <h6 runat="server" id="txtSalario"></h6>
                    </div>

                    <div class="input-group">
                        <h6><b>Idiomas requeridos </b></h6>
                        <h6 runat="server" id="txtIdiomaRequerido"></h6>
                    </div>

                    <br />

                    <div class="input-group">
                        <h6><b>Fecha de inicio </b></h6>
                        <h6 runat="server" id="txtFechaInicio"></h6>
                    </div>

                    <div class="input-group">
                        <h6><b>Fecha límite de la vacante </b></h6>
                        <h6 runat="server" id="txtFechaLimite"></h6>
                    </div>

                    <div class="input-group">
                        <h6><b>Publicado el </b></h6>
                        <h6 runat="server" id="txtFechaPublicacion"></h6>
                    </div>

                    <br />

                    <div class="input-group">
                        <h6><b>Lugar </b></h6>
                        <h6 runat="server" id="txtMunicipio"></h6>
                    </div>

                    <br />

                    <div class="form-group">
                        <h6><b>Nivel academico: </b></h6>
                        <asp:Repeater ID="rpNivelAcademico" runat="server">

                            <ItemTemplate>
                                <div class="row mb-3" style="margin-left: 5%">
                                    <h6>●<%# Eval("nivelAcademico") %></h6>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>



                    </div>

                    <br />
                    <div class="form-group">
                        <h6><b>Requisitos: </b></h6>
                        <asp:Repeater ID="rpRequisitos" runat="server">

                            <ItemTemplate>
                                <div class="row mb-3" style="margin-left: 5%">
                                    <h6>●<%# Eval("descripcionRequisito") %></h6>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>



                    </div>

                    <br />

                    <div class="form-group">
                        <h6><b>Habilidades: </b></h6>
                        <asp:Repeater ID="rpHabilidades" runat="server">

                            <ItemTemplate>

                                <div class="row mb-3" style="margin-left: 5%">
                                    <h6><b>●<%# Eval("nombreCompetencia") %></b></h6>
                                    <h6><%# Eval("descripcion") %></h6>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>



                    </div>

                    <br />

                    <div class="form-group">

                        <h6><b>Funciones: </b></h6>


                        <asp:Repeater ID="rpFunciones" runat="server">

                            <ItemTemplate>
                                <div class="row mb-3" style="margin-left: 5%">

                                    <h6>●<%# Eval("descripcionFuncion") %></h6>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>

                        <br />
                    </div>

                    <div class="input-group">
                        <h6><b>Experiencia mínima </b></h6>
                        <h6 runat="server" id="txtExperienciaMinima"></h6>
                    </div>


                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>

                </div>
            </div>
        </div>
    </div>



</asp:Content>
