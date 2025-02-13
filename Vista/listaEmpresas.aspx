<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/menu.Master" AutoEventWireup="true" CodeBehind="listaEmpresas.aspx.cs" Inherits="HIRE.Vista.listaEmpresas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">
    <title>Empresas</title>
    <link href="recursos/css/main3.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_Body" runat="server">

    <div class="container-fluid">


        <div class="row">
            <div class="d-flex justify-content-center">
                <h2>Mis Empresas</h2>
            </div>
            <hr class="my-4 w-100 mx-auto" style="background-color: #10317A">
            <asp:Label ID="txtValidar" runat="server" Text=""></asp:Label>
            <br />
            <div class=" d-flex justify-content-center">
                <asp:Button ID="btnCrearEmpresa" OnClick="btnCrearEmpresa_Click" CssClass="btn btn-success" runat="server" Text="Registrar Empresa" Visible="false" />
            </div>



        </div>

        <div class="row">

            <div class="col-md-2"></div>
            <div class="col-md-8">

                <%-- contenido de la pagina aqui --%>


                <div class="content-body-scrollable">
                    <asp:Repeater runat="server" ID="rpEmpresas">

                        <itemtemplate>


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
                                                <h4 runat="server" style="font-size: 83%; color: gray;" id="H1"><b>NIT: </b><%# Eval("nit") %></h4>

                                            </div>
                                            <div class="row">
                                                <h6 runat="server" style="font-size: 83%; color: gray;" id="H2"><b>Pagina Web: </b><%# Eval("url") %></h6>

                                            </div>
                                            <div class="row">
                                                <h6 runat="server" style="font-size: 83%; color: gray;" id="H3"><b>Ubicacion: </b><%# Eval("municipio") %>, Boyaca</h6>

                                            </div>

                                        </div>
                                        <div class="col-md-3 d-flex align-items-center">
                                            <button runat="server" id="btnPanelEmpresa" onserverclick="btnPanelEmpresa_Click" class="btn btn-warning w-50">
                                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                                    <g fill="none" stroke="#fff" stroke-linecap="round" stroke-linejoin="round" stroke-width="2.6">
                                                        <path stroke-dasharray="20" stroke-dashoffset="20" d="M3 12h17.5">
                                                            <animate fill="freeze" attributeName="stroke-dashoffset" dur="0.27s" values="20;0" />
                                                        </path>
                                                        <path stroke-dasharray="12" stroke-dashoffset="12" d="M21 12l-7 7M21 12l-7 -7">
                                                            <animate fill="freeze" attributeName="stroke-dashoffset" begin="0.27s" dur="0.27s" values="12;0" />
                                                        </path>
                                                    </g></svg>
                                            </button>
                                            <asp:HiddenField ID="hfIdEmpresa" Value='<%# Eval("idEmpresa") %>' runat="server" />

                                        </div>



                                    </div>


                                </div>

                            </div>
                        </itemtemplate>

                    </asp:Repeater>

                </div>
                <br />

            </div>
            <div class="col-md-2"></div>
        </div>











    </div>


</asp:Content>
