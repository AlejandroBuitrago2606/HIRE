<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/panelEmpresa.Master" AutoEventWireup="true" CodeBehind="vacantesEmpresa.aspx.cs" Inherits="HIRE.Vista.indexEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="server">
    <link rel="stylesheet" href="/Content/alertifyjs/alertify.css" />
    <link rel="stylesheet" href="/Content/alertifyjs/themes/default.css" />
    <script src="/Scripts/alertify.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="server">


    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="content-body-scrollable">
        <div class="container">

            <br />
            <div class=" d-flex justify-content-center">
                <h3>Tus vacantes publicadas</h3>
                <br />
            </div>

            <br />

            <div class="d-flex justify-content-center">
                <div class="input-group mb-3" style="width: 50%;">
                    <asp:TextBox ID="txtBuscarVacante" CssClass="form-control" placeholder="Buscar vacantes..." runat="server"></asp:TextBox>
                    <button class="btn btn-outline-warning" onserverclick="btnBuscarVacante_ServerClick" runat="server" id="btnBuscarVacante">Buscar</button>
                </div>
            </div>

            <br />

            <div runat="server" id="domMsg" class="mt-4" visible="false">
                <div class="d-flex justify-content-center">
                    <h4 runat="server" id="tituloMsg">No has publicado ninguna vacante</h4>
                </div>
                <div class="d-flex justify-content-center">
                    <a href="#" runat="server" id="btnPublicar" class="btn btn-success">Publicar vacante</a>
                </div>
            </div>




            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8">

                    <button runat="server" onserverclick="Unnamed_ServerClick" class="btn btn-success ml-0 mb-5">+ Agregar vacante</button>


                    <%-- contenido de la pagina aqui --%>
                    <asp:Repeater runat="server" ID="rpVacantes">
                        <ItemTemplate>
                            <div class="card sombra1 mb-4 shadow-sm">
                                <div class="card-body" style="margin-top: 0">
                                    <div class="row">
                                        <div class="col-md-9">
                                            <div class="row">
                                                <h3 style="font-size: 100%;" id="txtTitulo"><b>Vacante:</b><%# " " + Eval("titulo") %></h3>
                                            </div>
                                            <div class="row">
                                                <h4 style="font-size: 80%; color: gray;" id="H1"><b>Fecha de publicación:</b><%# " " + Convert.ToDateTime(Eval("fechaPublicacion")).ToString("yyyy-MM-dd") %></h4>

                                            </div>
                                            <div class="row">
                                                <h3 style="font-size: 80%;"><b>Numero de postulados:</b><%# " " + Eval("numeroPostulados") %></h3>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button ID="btnPanelEmpresa" CssClass="btn btn-warning" OnCommand="btnVerVacante_Click" CommandName="enviarIDVacante" CommandArgument='<%# Eval("idVacante") %>' runat="server" Text="Ver vacante" />
                                            <asp:Button ID="btnEliminarVacante" OnClick="btnEliminarVacante_Click" CommandName="EliminarVacante" CommandArgument='<%# Eval("idVacante") %>' CssClass="btn btn-outline-danger" runat="server" Text="🗑️" />
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

    <!-- modal mostrar datos vacante -->
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

    <!-- modal registro vacante -->

    <div class="modal fade" id="modalregistro" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="staticBackdropLabel">Registrar vacante</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="container content-body-scrollable">
                        <br />

                        <div class="form-group mt-4">
                            <label>Título de la Vacante</label>
                            <asp:TextBox ID="txtTituloVacante" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mt-4">
                            <label>Descripción</label>
                            <asp:TextBox ID="txtDescripcionVacante" CssClass="form-control" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mt-4">
                            <label>Tiempo de Experiencia</label>
                            <asp:TextBox ID="txtTiempoExperiencia" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mt-4">
                            <label>Funciones de la vancante</label>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>

                                    <asp:Repeater ID="rpFuncion" runat="server">
                                        <ItemTemplate>

                                            <h6 id="txtFuncion" runat="server"><%#" " + Eval("descripcionFuncion") %></h6>
                                            <asp:Button ID="btnEliminar" CssClass="btn btn-outline-danger" OnClick="btnEliminar_Click" Text="X" runat="server" />
                                            <asp:HiddenField Value="1" runat="server" />
                                            <br />
                                        </ItemTemplate>

                                    </asp:Repeater>


                                    <div class="input-group mt-2">
                                        <asp:TextBox ID="txtAgregarFuncionVacante" placeholder="Descripcion de la funcion...." CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <button id="a1" runat="server" onserverclick="agregarDetalles_ServerClick" class="btn btn-warning ml-2">+</button>

                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>


                        </div>


                        <div class="form-group mt-4">
                            <label>Requisitos de la Vacante</label>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>

                                    <asp:Repeater ID="rpRequisito" runat="server">
                                        <ItemTemplate>
                                            <h6 id="txtRequisito" runat="server"><%# " " + Eval("descripcionRequisito") %></h6>
                                            <asp:Button ID="btnEliminar" CssClass="btn btn-outline-danger" OnClick="btnEliminar_Click" Text="X" runat="server" />
                                            <asp:HiddenField Value="2" runat="server" />
                                            <br />
                                        </ItemTemplate>

                                    </asp:Repeater>


                                    <div class="input-group mt-2">
                                        <asp:TextBox ID="txtAgregarRequisitoVacante" placeholder="Descripcion del requisito...." CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                                        <button id="a2" runat="server" onserverclick="agregarDetalles_ServerClick" type="button" class="btn btn-warning ml-2">+</button>

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="form-group mt-4">
                            <label>Competencias de la Vacante</label>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>

                                    <asp:Repeater ID="rpCompetencia" runat="server">
                                        <ItemTemplate>
                                            <h6 id="txtCompetencia" runat="server"><%#" " + Eval("nombre") %></h6>
                                            <asp:Button ID="btnEliminar" CssClass="btn btn-outline-danger" OnClick="btnEliminar_Click" Text="X" runat="server" />
                                            <asp:HiddenField Value="3" runat="server" />
                                            <br />
                                        </ItemTemplate>

                                    </asp:Repeater>

                                    <div class="input-group">
                                        <asp:DropDownList ID="dpCompetencias" CssClass="form-control" runat="server">
                                            <asp:ListItem Enabled="true" Value="0" Text="Selecciona la competencia...."></asp:ListItem>


                                        </asp:DropDownList>
                                        <button id="a3" runat="server" onserverclick="agregarDetalles_ServerClick" type="button" class="btn btn-warning ml-2">+</button>

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="form-group mt-4">
                            <label>Niveles academicos de la Vacante</label>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>

                                    <asp:Repeater ID="rpNivelAcademicoAgregar" runat="server">
                                        <ItemTemplate>

                                            <h6 id="txtNivelAcademico" runat="server"><%# " " + Eval("nivelAcademico") %></h6>
                                            <asp:Button ID="btnEliminar" CssClass="btn btn-outline-danger" OnClick="btnEliminar_Click" Text="X" runat="server" />
                                            <asp:HiddenField Value="4" runat="server" />
                                            <br />
                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <div class="input-group">
                                        <asp:DropDownList ID="dpNivelAcademico" CssClass="form-control" runat="server">
                                            <asp:ListItem Enabled="true" Value="0" Text="Selecciona el nivel academico...."></asp:ListItem>
                                        </asp:DropDownList>
                                        <button id="a4" runat="server" onserverclick="agregarDetalles_ServerClick" type="button" class="btn btn-warning ml-2">+</button>

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                        <div class="form-group mt-4">
                            <label>Salario</label>
                            <asp:TextBox ID="txtSalarioVacante" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mt-4">
                            <label>Jornada</label>
                            <asp:TextBox ID="txtJornadaVacante" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mt-4">
                            <label>Horario</label>
                            <asp:TextBox ID="txtHorarioVacante" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mt-4">
                            <label>Idioma Requerido</label>
                            <asp:TextBox ID="txtIdiomaVacante" CssClass="form-control" TextMode="SingleLine" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mt-4">
                            <label>Fecha de Inicio</label>
                            <asp:TextBox ID="txtfechaInicioVacante" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>

                        </div>
                        <div class="form-group mt-4">
                            <label>Fecha Límite</label>
                            <asp:TextBox ID="txtFechaLimiteVacante" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>

                        </div>
                        <div class="form-group mt-4">
                            <label>Municipio</label>
                            <asp:DropDownList ID="ddlMunicipios" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Selecciona un municipio" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group mt-4">
                            <label>Tipo de Empleo</label>
                            <asp:DropDownList ID="ddlTipoEmpleo" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Selecciona un tipo de empleo" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group mt-4">
                            <label>Tipo de Contrato</label>
                            <asp:DropDownList ID="ddlTipoContrato" CssClass="form-control" runat="server">
                                <asp:ListItem Text="Selecciona un tipo de contrato" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAgregarVacante" CommandName="agregarVacante" OnClick="btnAgregarVacante_Click" CssClass="btn btn-success" runat="server" Text="Registrar" />
                </div>
            </div>

        </div>
    </div>



</asp:Content>
