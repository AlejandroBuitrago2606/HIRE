<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/menu.Master" AutoEventWireup="true" CodeBehind="listaEmpresas.aspx.cs" Inherits="HIRE.Vista.listaEmpresas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">
    <title>Empresas</title>
    <link href="recursos/css/main3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_Body" runat="server">
    <div class="content-body-scrollable">
        <div class="container">


            <div class="row">

                <h3>Mis Empresas</h3>

                <asp:Label ID="txtValidar" runat="server" Text=""></asp:Label>
                <br />
                <div class=" d-flex justify-content-center">
                    <asp:Button ID="btnCrearEmpresa" OnClick="btnCrearEmpresa_Click" CssClass="btn btn-success" runat="server" Text="Registrar Empresa" Visible="false" />
                </div>

            </div>

            <br />
            <div class="row">

                <div class="col-md-2"></div>
                <div class="col-md-8">

                    <%-- contenido de la pagina aqui --%>



                    <asp:Repeater runat="server" ID="rpEmpresas">

                        <ItemTemplate>


                            <div class="card sombra1 mb-4 shadow-sm">
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
                                                <h4 runat="server" style="font-size: 83%; color: gray;" id="H1"><b>NIT: </b><%# Eval("nit") %></h4>

                                            </div>
                                            <div class="row">
                                                <h6 runat="server" style="font-size: 83%; color: gray;" id="H2"><b>Pagina Web: </b><%# Eval("url") %></h6>

                                            </div>
                                            <div class="row">
                                                <h6 runat="server" style="font-size: 83%; color: gray;" id="H3"><b>Ubicacion: </b><%# Eval("municipio") %>, Boyaca</h6>

                                            </div>

                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button runat="server" CssClass="btn btn-warning" Style="color: black; margin-top: 40px; width: 80px; margin-left: 50%;" Text="Ir" />
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

</asp:Content>
