<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/menu.Master" AutoEventWireup="true" CodeBehind="busquedaEmpresa.aspx.cs" Inherits="HIRE.Vista.busquedaEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">
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
                        <button class="btn search-button" id="buscarEmpresa" style="height: 52px;" runat="server" onserverclick="buscarEmpresa_ServerClick">
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
                            <asp:DropDownList ID="cbMunicipios" CssClass="form-control" Style="border-radius: 38px; width: 221px; height: 38px; margin-left: 15px" runat="server" OnSelectedIndexChanged="buscarEmpresaPorMunicipio" AutoPostBack="true">
                            </asp:DropDownList>

                        </div>

                    </div>
                </div>

            </div>

            <div class="col-md-5" runat="server" id="contenedorRepeater">

                <div style="max-height: calc(100vh - 150px); overflow-y: auto;">
                    <h5 runat="server" id="txtTotalEmpresas"></h5>

                    <asp:Repeater runat="server" ID="rpEmpresas">

                        <ItemTemplate>


                            <div class="card mb-4 shadow-sm">
                                <div class="card-body" style="margin-top: 0">

                                    <div class="row">
                                        <div class="col-md-3">

                                            <img class="img-profile rounded-circle"
                                                src='<%# ResolveUrl(Eval("foto").ToString()) %>' alt="error" width="100px" height="100px">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="row">
                                                <h3 runat="server" style="font-size: 160%;" id="txtNombreEmpresa"><%# Eval("nombre") %></h3>
                                            </div>
                                            <div class="row">
                                                <h4 runat="server" style="font-size: 83%; color: gray;" id="H1"><%# Eval("sector") %></h4>

                                            </div>
                                            <div class="row">
                                                <h6 runat="server" style="font-size: 83%; color: gray;" id="H2"><b>Ubicacion: </b><%# Eval("municipio") %>, Boyacá</h6>

                                            </div>
                                            <div class="row">
                                                <h6 runat="server" style="font-size: 83%; color: gray;" id="H3"><%# Eval("descripcion") %></h6>

                                            </div>
                                            <div class="row">
                                                <h6 runat="server" style="font-size: 83%; color: gray;" id="H4"><b><%# Eval("totalVacantes") %> vacantes disponibles</b></h6>                                                
                                            </div>

                                        </div>

                                    </div>
                                </div>

                                <div class="card-footer">
                                    <div class="col-md-3" style="margin-bottom: 10px; margin-top: 2px;">
                                        <asp:Button runat="server" CssClass="btn btn-warning" OnCommand="traerEmpresa_Click" CommandName="traerEmpresa" CommandArgument='<%# Eval("idEmpresa") %>' Style="color: black;" Text="Ver mas →" />
                                    </div>
                                </div>



                            </div>
                        </ItemTemplate>

                    </asp:Repeater>


                    <div class="modal fade" id="datosEmpresa" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-scrollable">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <div class="d-flex justify-content-center">
                                        <h1 class="modal-title fs-4" style="text-align: center" id="exampleModalLabel">Informacion del negocio.</h1>
                                    </div>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">

                                    <div class="d-flex justify-content-center">
                                        <h5 runat="server" id="txtNombreEmpresa" style="font-weight: bold;"></h5>
                                    </div>

                                    <br />
                                    <br />

                                    <div class="d-flex justify-content-center">
                                        <img class="img-profile rounded-circle" runat="server" id="imgEmpresa"
                                            alt="error" width="100" height="100">
                                    </div>

                                    <br />
                                    <h6 runat="server" id="txtDescripcionEmpresa"></h6>
                                    <br />

                                    <div class="input-group">
                                        <h6><b>Numero de Empleados</b></h6>
                                        <h6 runat="server" id="txtNumeroEmpleados"></h6>
                                    </div>

                                    <div class="input-group">
                                        <h6><b>Ubicación </b></h6>
                                        <h6 runat="server" id="txtUbicacion"></h6>
                                    </div>

                                    <div class="input-group" style="margin-top: 2%">

                                        <span>📞</span>
                                        <h6 runat="server" id="txtTelefono"></h6>
                                    </div>

                                    <div class="input-group">
                                        <span>✉️</span>
                                        <h6 runat="server" id="txtCorreo"></h6>

                                    </div>
                                    <div class="input-group">
                                        <span>🌐</span>
                                        <a id="Web" runat="server"></a>
                                    </div>


                                    <br />
                                    <br />

                                    <div class="input-group">
                                        
                                            <h6><b runat="server" id="txtVacantesPublicadas"></b></h6>
                                        <br />
                                        <div style="max-height: calc(100vh - 100px); overflow-y: auto;">
                                        <asp:Repeater ID="rpVacantesPublicadas" runat="server">

                                            <ItemTemplate>

                                                <div class="card mb-4 shadow-sm">
                                                    <div class="card-body" style="margin-top: 2%">
                                                        <div class="row" style="text-align: center">
                                                            <h3 runat="server" style="font-size: 160%;" id="txtNombreEmpresa"><b><%# Eval("titulo") %></b></h3>
                                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <h6 runat="server" style="font-size: 83%; color: mediumseagreen;"><b><%# Eval("salario") %></b></h6>

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

                                                            <asp:Button ID="btnVerVacante" CssClass="btn btn-warning" data-bs-toggle="modal" runat="server" Style="color: black;" Text="Ver mas →" />
                                                        </div>

                                                    </div>


                                                </div>

                                            </ItemTemplate>

                                        </asp:Repeater>
                                            </div>
                                    </div>

                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                                </div>
                            </div>
                        </div>
                    </div>



                </div>
            </div>
            <div class="col-md-2" runat="server" id="contenedorDerecho"></div>
        </div>
    </div>

</asp:Content>
