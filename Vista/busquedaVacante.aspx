<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/menu.Master" AutoEventWireup="true" CodeBehind="busquedaVacante.aspx.cs" Inherits="HIRE.Vista.busqueda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">
    <title>Explorar</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_Body" runat="server">
    <div class="content-body-scrollable">

        <div class="row" runat="server" id="fila">

            <div class="col-md-2" runat="server" id="contenedorIzquierdo"></div>
            <div class="col-md-3" runat="server" id="contenedorBusqueda">

                <div style="margin-top: 100px">
                    <h4>Encuentra el empleo ideal para ti...</h4>
                    <div class="search-bar input-group" style="position: sticky;">

                        <asp:TextBox ID="txtParametros" TextMode="SingleLine" CssClass="form-control search-input" Style="width: auto; height: 52px" placeholder="Buscar..." runat="server"></asp:TextBox>
                        <button class="btn search-button" id="buscarVacante" style="height: 52px;" runat="server" onserverclick="buscarVacante_ServerClick">
                            <i class="fas fa-fw fa-search" style="color: white;"></i>
                        </button>

                    </div>
                    <hr class="sidebar-divider">
                    <div class="input-group">
                        <svg xmlns="http://www.w3.org/2000/svg" width="1em" height="1em" viewBox="0 0 16 16">
                            <path fill="#858796" d="M6 1a3 3 0 0 0-2.83 2H0v2h3.17a3.001 3.001 0 0 0 5.66 0H16V3H8.83A3 3 0 0 0 6 1M5 4a1 1 0 1 1 2 0a1 1 0 0 1-2 0m5 5a3 3 0 0 0-2.83 2H0v2h7.17a3.001 3.001 0 0 0 5.66 0H16v-2h-3.17A3 3 0 0 0 10 9m-1 3a1 1 0 1 1 2 0a1 1 0 0 1-2 0" />
                        </svg>
                        <h5 style="margin-left: 8px"><b>Filtros</b></h5>
                    </div>

                    <div class="row" style="margin-top: 40px;">


                        <div class="col-md-10">
                            <h6><b>Municipio</b></h6>
                            <asp:DropDownList ID="cbMunicipios" CssClass="form-control" Style="border-radius: 38px; width: 221px; height: 38px; margin-left: 15px" runat="server">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>




                            <h6 style="margin-top: 20px"><b>Modalidad</b></h6>
                            <asp:DropDownList ID="cbEmpleos" Style="border-radius: 20px; width: 221px; height: 38px; margin-left: 15px" CssClass="form-control" runat="server">
                            </asp:DropDownList>



                            <h6 style="margin-top: 20px"><b>Tipo de contrato</b></h6>
                            <asp:DropDownList ID="cbContratos" Style="border-radius: 20px; width: 221px; height: 38px; margin-left: 15px" CssClass="form-control" runat="server">
                            </asp:DropDownList>

                        </div>
                        <div class="col-md-2" style="display: flex; align-items: center; justify-content: center;">
                            <button class="btn search-button rounded-circle" id="btnBuscarVacanteFiltros" style="height: 47px; width: 47px; border-radius: 15px; margin-left: 0; margin-right: 100%;" runat="server" onserverclick="btnBuscarVacanteFiltros_ServerClick">
                                <i class="fas fa-fw fa-search" style="color: white;"></i>
                            </button>
                        </div>





                    </div>
                </div>

            </div>

            <div class="col-md-5" runat="server" id="contenedorRepeater">

                <div style="max-height: calc(100vh - 150px); overflow-y: auto;">
                    <h5 runat="server" id="txtTotalVacantes"></h5>
                    <asp:Repeater runat="server" ID="rpVacantes">

                        <ItemTemplate>


                            <div class="card mb-4 shadow-sm">
                                <div class="card-body" style="margin-top: 0">
                                    <div class="row" style="text-align: center">
                                        <h3 runat="server" style="font-size: 160%;" id="txtNombreEmpresa"><b><%# Eval("titulo") %></b></h3>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <h6 runat="server" style="font-size: 83%; color: mediumseagreen;"><b>$<%# Eval("salario") %></b></h6>

                                    </div>
                                    <div class="row">
                                        <h6 runat="server" id="txtMunicipio" style="font-size: 83%; color: gray;"><b>Lugar: </b><%#Eval("municipio")%></h6>

                                    </div>
                                    <div class="row">
                                        <h6 runat="server" style="font-size: 83%; color: gray;"><b>Contrato: </b><%# Eval("tipoContrato")%>, (<%# Eval("tipoEmpleo") %>)</h6>

                                    </div>
                                    <div class="row">
                                        <h6 runat="server" style="font-size: 83%; color: gray;"><b>Maximo hasta: </b><%# Eval("fechaLimite") %></h6>

                                    </div>

                                </div>

                                <div class="card-footer">
                                    <div class="col-md-3" style="margin-bottom: 10px; margin-top: 2px;">

                                        <asp:Button ID="btnVerVacante" CssClass="btn btn-warning" data-bs-toggle="modal" runat="server" Style="color: black;" CommandName="enviarIDVacante" CommandArgument='<%# Eval("idVacante") %>' OnCommand="btnVerVacante_Click" data-bs-target="#exampleModal" Text="Ver mas →" />
                                    </div>

                                </div>


                            </div>



                        </ItemTemplate>

                    </asp:Repeater>

                    <h6 runat="server" id="ID"></h6>

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
                                    <asp:Button ID="btnPostulacion" CssClass="btn color2" CommandName="postulacion" CommandArgument='<%# Eval("idVacante") %>' Style="color: white" OnClick="btnPostulacion_Click" runat="server" Text="Postularme" />

                                </div>
                            </div>
                        </div>
                    </div>



                </div>
            </div>

            <div class="col-md-2" runat="server" id="contenedorDerecho"></div>

        </div>

        <!-- Modal -->
        <div class="modal fade" id="modalPostularse" tabindex="-1" aria-labelledby="exampleModalLabel2" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="exampleModalLabel2">Confirmar</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        Deseas postularte a esta vacante.
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnPostularse" onserverclick="btnPostularse_ServerClick" class="btn btn-warning" runat="server">Postularme</button>
                    </div>
                </div>
            </div>
        </div>



    </div>


    <script src="recursos/js/main3.js"></script>
</asp:Content>
