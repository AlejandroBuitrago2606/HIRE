<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/panelTrabajador.Master" AutoEventWireup="true" CodeBehind="empleoUsuario.aspx.cs" Inherits="HIRE.Vista.empleoUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">
    <link href="Vista/recursos/css/main3.css" rel="stylesheet" />
    <link rel="stylesheet" href="/Content/alertifyjs/alertify.css" />
    <link rel="stylesheet" href="/Content/alertifyjs/themes/default.css" />
    <script src="/Scripts/alertify.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_Body" runat="server">

    <div class="content-body-scrollable">
        <div class="container">
            <br />
            <div class=" d-flex justify-content-center">
                <h3>Empleos aprobados.</h3>
                <br />
            </div>

            <br />

<%--            <div class="d-flex justify-content-center">
                <div class="input-group mb-3" style="width: 50%;">
                    <asp:TextBox ID="txtBuscar" CssClass="form-control" placeholder="Buscar postulaciones..." runat="server"></asp:TextBox>
                    <button class="btn" style="background-color: #10317a;" runat="server" onserverclick="btnBuscarSolicitud_ServerClick" id="btnBuscarSolicitud">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                            <path fill="#fff" d="M9.5 16q-2.725 0-4.612-1.888T3 9.5t1.888-4.612T9.5 3t4.613 1.888T16 9.5q0 1.1-.35 2.075T14.7 13.3l5.6 5.6q.275.275.275.7t-.275.7t-.7.275t-.7-.275l-5.6-5.6q-.75.6-1.725.95T9.5 16m0-2q1.875 0 3.188-1.312T14 9.5t-1.312-3.187T9.5 5T6.313 6.313T5 9.5t1.313 3.188T9.5 14" />
                        </svg>
                    </button>
                </div>
            </div>
            <br />--%>

            <div runat="server" id="domMsg" class="mt-4" visible="false">
                <div class="d-flex justify-content-center">
                    <h4 runat="server" id="tituloMsg">No te han aprobado ninguna solicitud de empleo</h4>
                </div>
                <div class="d-flex justify-content-center">
                    <a href="busquedaVacante.aspx" runat="server" id="btnRegresar" class="btn btn-success">Postularme a un empleo</a>
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
                                        <div class="col-md-7">
                                            <div class="row">
                                                <h3 runat="server" style="font-size: 100%;" id="txtTitulo"><b>Vacante:</b><%# " " + Eval("titulo") %></h3>
                                            </div>
                                            <div class="row">
                                                <h4 runat="server" style="font-size: 80%; color: gray;" id="H1"><b>Fecha de postulación:</b><%# " " + Convert.ToDateTime(Eval("fechaEnvio")).ToString("yyyy-MM-dd") %></h4>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnPanelEmpresa" CssClass="btn btn-warning" OnCommand="btnVerVacante_Click" data-bs-toggle="modal" data-bs-target="#datosVacante"
                                                CommandName="enviarIDVacante" CommandArgument='<%# Eval("idVacante") %>' runat="server" Text="Ver vacante" />

                                        </div>
                                        <div class="col-md-2">

                                            <asp:Button ID="btnRenunciarEmpleo" OnClick="btnAbrirModalConfirmar_ServerClick" CssClass="btn btn-danger" CommandName="renunciarEmpleo" CommandArgument='<%# Eval("idSolicitud") %>' runat="server" Text="Dejar mi puesto" />

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


    <div class="modal fade" id="modalRenunciar" tabindex="-1" aria-labelledby="exampleModalLabel2" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel2">Confirmar</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    ⚠️¿Renunciaras a este puesto de trabajo?
                    <asp:HiddenField ID="hfIDsolicitud" runat="server" />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnRenunciar" OnClick="btnRenunciar_ServerClick" CommandName="renunciarConfirmado" CssClass="btn btn-outline-danger" runat="server" Text="Renunciar a este empleo" />

                </div>
            </div>
        </div>
    </div>



</asp:Content>
