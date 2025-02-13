<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/menu.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HIRE.Vista.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">

    <title>Principal</title>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Content_Body" runat="server">
    <div class="content-body-scrollable">
        <h3 runat="server" style="margin-left: 2%" id="msgBienvenida"></h3>
        <br />
        <div class="container">
            <h5>¿Que haras hoy?</h5>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-5">                    
                    <br />
                    <div class="card" style="border-radius: 30px; margin-right: 0">

                        <div class="container h-auto">

                            <div class="row">
                                <div class="col-md-11">
                                    <div class="row mt-4 mb-3">
                                        <h5><a href="solicitudesUsuario.aspx">Mis solicitudes de empleo</a></h5>
                                    </div>


                                    <div class="row mb-3">
                                        <h5><a href="empleoUsuario.aspx">Mis Empleos</a></h5>
                                    </div>


                                    <div class="row mb-3">
                                        <h5><a href="perfilCV.aspx">Modificar información de mi CV.</a></h5>
                                    </div>


                                    <div class="row mb-3">
                                        <h5><a href="perfilUsuario.aspx">Editar mi cuenta de usuario.</a></h5>
                                    </div>


                                    <div class="row mb-3">
                                        <h5><a href="listaEmpresas.aspx">Administrar mis empresas</a></h5>
                                    </div>


                                </div>


                                <div class="col-md-1 mt-0">
                                    <div class="row mt-4 mb-3">
                                        <h5><a href="solicitudesUsuario.aspx">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                                <path fill="none" stroke="#4e73df" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 12h14m-6 6l6-6m-6-6l6 6" />
                                            </svg></a></h5>
                                    </div>


                                    <div class="row mb-3">
                                        <h6><a href="empleoUsuario.aspx">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                                <path fill="none" stroke="#4e73df" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 12h14m-6 6l6-6m-6-6l6 6" />
                                            </svg></a></h6>
                                    </div>


                                    <div class="row mb-3">
                                        <h6><a href="perfilCV.aspx">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                                <path fill="none" stroke="#4e73df" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 12h14m-6 6l6-6m-6-6l6 6" />
                                            </svg></a></h6>
                                    </div>


                                    <div class="row mb-3">
                                        <h6><a href="perfilUsuario.aspx">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                                <path fill="none" stroke="#4e73df" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 12h14m-6 6l6-6m-6-6l6 6" />
                                            </svg></a></h6>
                                    </div>


                                    <div class="row mb-3">
                                        <h6><a href="listaEmpresas.aspx">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24">
                                                <path fill="none" stroke="#4e73df" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 12h14m-6 6l6-6m-6-6l6 6" />
                                            </svg></a></h6>
                                    </div>


                                </div>
                            </div>


                        </div>


                    </div>
                </div>
                <div class="col-md-5">
                    <img class="d-flex justify-content-center align-items-center" src="../Vista/recursos/img/oficinista.png" alt="registrarEmpresa"
                        style="width: 100%; height: 100%; object-fit: cover; margin-top: 2%" />
                </div>
                <div class="col-md-1"></div>

            </div>

        </div>


    </div>
</asp:Content>
