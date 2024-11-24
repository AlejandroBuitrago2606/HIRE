<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/menu.Master" AutoEventWireup="true" CodeBehind="busqueda.aspx.cs" Inherits="HIRE.Vista.busqueda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">
    <title>Inicio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_Body" runat="server">


    <div class="row rowSearch">

        <div class="col-md-2"></div>
        <div class="col-md-3">

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
                    <h5 style="margin-left: 8px"><b>Filtros de busqueda</b></h5>
                </div>

                <div class="row" style="margin-top: 40px;">
                    <div class="row">

                        <div class="col-md-8">
                            <h6><b>Municipio</b></h6>
                            <asp:DropDownList ID="cbMunicipios" CssClass="form-control" Style="border-radius: 20px; width: auto; height: 38px; margin-left: 15px" runat="server"></asp:DropDownList>
                        </div>

                        <div class="col-md-4">
                            <h6><b>Modalidad</b></h6>
                            <asp:DropDownList ID="cbEmpleos" CssClass="form-control" Style="border-radius: 20px; width: auto; height: 38px; margin-left: 15px" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row" style="margin-top: 27px">
                        <h6><b>Tipo de contrato</b></h6>
                        <asp:DropDownList ID="cbContratos" CssClass="form-control" Style="border-radius: 20px; width: auto; height: 38px; margin-left: 15px" runat="server"></asp:DropDownList>
                    </div>




                </div>
            </div>

        </div>
        <div class="col-md-5">

            <div style="max-height: calc(100vh - 150px); overflow-y: auto;">
                <asp:Repeater runat="server" ID="rpVacantes">

                    <ItemTemplate>


                        <div class="card mb-4 shadow-sm">
                            <div class="card-body" style="margin-top: 0">
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
                                    <asp:Button runat="server" CssClass="btn btn-warning" Style="color: black;" Text="Ver mas..." />
                                </div>
                            </div>


                        </div>



                    </ItemTemplate>

                </asp:Repeater>
            </div>
        </div>
        <div class="col-md-2"></div>
</asp:Content>
