<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/panelTrabajador.Master" AutoEventWireup="true" CodeBehind="solicitudesUsuario.aspx.cs" Inherits="HIRE.Vista.solicitudesUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">
    <link href="Vista/recursos/css/main3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_Body" runat="server">

    <div class="content-body-scrollable">
        <div class="container">
            <br />
            <div class=" d-flex justify-content-center">
                <h3>Solicitudes de empleo enviadas</h3>
                <br />
            </div>

            <br />

            <div class="d-flex justify-content-center">
                <div class="input-group mb-3" style="width: 50%;">
                    <asp:TextBox ID="txtBuscar" CssClass="form-control" placeholder="Buscar postulaciones..." runat="server"></asp:TextBox>                    
                    <button class="btn btn-outline-warning" runat="server" onserverclick="btnBuscarSolicitud_ServerClick" id="btnBuscarSolicitud">Buscar</button>
                </div>
            </div>
            <br />

            <div runat="server" id="domMsg" class="mt-4" visible="false">
                <div class="d-flex justify-content-center">
                    <h4 runat="server" id="tituloMsg">No has hecho ningun solicitud de empleo</h4>
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
                                        <div class="col-md-9">
                                            <div class="row">
                                                <h3 runat="server" style="font-size: 100%;" id="txtTitulo"><b>Vacante:</b><%# " " + Eval("titulo") %></h3>
                                            </div>
                                            <div class="row">
                                                <h4 runat="server" style="font-size: 50%; color: gray;" id="H1"><b>Fecha de postulación:</b><%# " " + Convert.ToDateTime(Eval("fechaEnvio")).ToString("yyyy-MM-dd") %></h4>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button ID="btnPanelEmpresa" CssClass="btn btn-warning" OnCommand="btnVerVacante_Click" data-bs-toggle="modal" data-bs-target="#datosVacante"
                                                CommandName="enviarIDVacante" CommandArgument='<%# Eval("idVacante") %>' runat="server" Text="Ver vacante" />
                                            <asp:HiddenField ID="hfIdSolicitud" Value='<%# Eval("idSolicitud") %>' runat="server" />
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

                    <div class="input-group">
                        <h6><b>Nivel academico: </b></h6>
                        <asp:Repeater ID="rpNivelAcademico" runat="server">

                            <ItemTemplate>
                                <div class="row">
                                    <h6><%# Eval("nivelAcademico") %></h6>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>



                    </div>

                    <div class="input-group">
                        <h6><b>Requisitos: </b></h6>
                        <asp:Repeater ID="rpRequisitos" runat="server">

                            <ItemTemplate>
                                <div class="row">
                                    <h6><%# Eval("descripcionRequisito") %></h6>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>



                    </div>

                    <div class="input-group">
                        <h6><b>Habilidades: </b></h6>
                        <asp:Repeater ID="rpHabilidades" runat="server">

                            <ItemTemplate>

                                <div class="row" style="margin-left: 5%">
                                    <h6><b><%# Eval("nombreCompetencia") %></b></h6>
                                    <h6><%# Eval("descripcion") %></h6>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>



                    </div>

                    <br />

                    <div class="input-group">
                        <h6><b>Funciones: </b></h6>
                        <asp:Repeater ID="rpFunciones" runat="server">

                            <ItemTemplate>
                                <div class="row">
                                    <h6><%# Eval("descripcionFuncion") %></h6>
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>

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
