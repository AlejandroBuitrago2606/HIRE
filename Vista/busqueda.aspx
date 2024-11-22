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
                <div class="search-bar input-group">

                    <asp:TextBox ID="txtParametros" TextMode="SingleLine" CssClass="form-control search-input" Style="width: auto; height: 52px" placeholder="Buscar..." runat="server"></asp:TextBox>
                    <button class="btn search-button" id="buscarVacante" style="height: 52px;" runat="server" onserverclick="buscarVacante_ServerClick">
                        <i class="fas fa-fw fa-search" style="color: white;"></i>
                    </button>

                </div>
                <div class="row" style="margin-top: 20px;">

                    <asp:DropDownList ID="cbMunicipios" CssClass="form-control" Style="border-radius: 20px; width: auto; height: 38px; margin-left: 15px" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="cbContratos" CssClass="form-control" Style="border-radius: 20px; width: auto; height: 38px; margin-left: 15px" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="cbEmpleos" CssClass="form-control" Style="border-radius: 20px; width: auto; height: 38px; margin-left: 15px" runat="server"></asp:DropDownList>

                </div>
            </div>

        </div>
        <div class="col-md-5 ">

            <asp:Repeater runat="server" ID="rpVacantes">

                <ItemTemplate>


                    <div class="card mb-4 shadow-sm">
                        <div class="card-body" style="margin-top: 0">

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row" style="text-align:center">
                                        <h3 runat="server" style="font-size: 160%;" id="txtNombreEmpresa"><b><%# Eval("titulo") %></b></h3>
                                    </div>
                                    <div class="row">
                                        <h6 runat="server" style="font-size: 83%; color: gray;"><%# Eval("salario") %></h6>

                                    </div>
                                    <div class="row">
                                        <h6 runat="server" style="font-size: 83%; color: gray;"><b>Lugar: </b><%# Eval("municipio") %></h6>

                                    </div>
                                    <div class="row">
                                        <h6 runat="server" style="font-size: 83%; color: gray;"><b>Contrato: </b><%# Eval("tipoContrato") %>, Boyaca</h6>

                                    </div>
                                    <div class="row">
                                        <h6 runat="server" style="font-size: 83%; color: gray;"><%# Eval("tipoEmpleo") %>, Boyaca</h6>

                                    </div>
                                    <div class="row">
                                        <h6 runat="server" style="font-size: 83%; color: gray;"><b>Maximo hasta: </b><%# Eval("fechaLimite") %>, Boyaca</h6>

                                    </div>

                                </div>
                                <div class="col-md-3">
                                    <asp:Button runat="server" CssClass="btn btn-warning" Style="color: black; margin-top: 40px; width: 80px; margin-left: 50%;" Text="Ir" />
                                </div>

                            </div>



                        </div>
                </ItemTemplate>

            </asp:Repeater>
        </div>
        </div>
        <div class="col-md-2"></div>




</asp:Content>
