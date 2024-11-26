<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/menu.Master" AutoEventWireup="true" CodeBehind="perfilCV.aspx.cs" Inherits="HIRE.Vista.perfilCV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">
    <title>Perfil CV</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_Body" runat="server">

    <div class="content-body-scrollable">

        <h2 style="text-align: center"><b>Perfil profesional</b></h2>


        <br />
        <div class=" row">
            <br />

            <div class="col-md-2"></div>
            <div class="col-md-8">

                <h4 id="txtDescripcionCV" runat="server"></h4>

                <br />
                <br />

                <h4 class="colorBase" style="border-radius: 6px; color: white; margin-bottom: 2%; text-align: center">Habilidades: </h4>
                <asp:Repeater ID="rpCompetencias" runat="server">
                    <ItemTemplate>
                        <div class=" card">
                            <div class=" container" style="margin-top: 3%; margin-bottom: auto; margin-bottom: 3%;">
                                <h5><b>Nombre:</b>
                                    <h6><%#Eval("nombre") %></h6>
                                </h5>

                                <br />
                                <h5><b>Descripción:</b>
                                    <h6><%#Eval("descripcion") %></h6>

                                </h5>

                                <br />
                                <h5><b>Categoria:<b>
                                    <h6><%#Eval("nombreCategoria") %></h6></h5>

                            </div>

                        </div>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <br />

                <h4 class="colorBase" style="border-radius: 6px; color: white; margin-bottom: 2%; text-align: center">Experiencia: </h4>
                <asp:Repeater ID="rpExperiencia" runat="server">
                    <ItemTemplate>
                        <div class=" card">
                            <div class=" container" style="margin-top: 3%; margin-bottom: auto; margin-bottom: 3%;">
                                <h5><b>Titulo: </b></h5>
                                <h6><%#Eval("titulo") %></h6>
                                <br />
                                <h5><b>Descripción: </b></h5>
                                <h6><%#Eval("descripcion") %></h6>

                            </div>
                        </div>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <br />

                <h4 class="colorBase" style="border-radius: 6px; color: white; margin-bottom: 2%; text-align: center">Referencias: </h4>
                <asp:Repeater ID="rpReferencia" runat="server">
                    <ItemTemplate>
                        <div class=" card">
                            <div class=" container" style="margin-top: 3%; margin-bottom: auto; margin-bottom: 3%;">
                                <h5><b>Persona: </b></h5>
                                <h6><%#Eval("nombreReferencia") %></h6>
                                <br />
                                <h5><b>Cargo:</b> </h5>
                                <h6><%#Eval("cargo") %></h6>
                                <br />
                                <h5><b>Empresa: </b></h5>
                                <h6><%#Eval("nombreEmpresa") %></h6>
                                <br />
                                <h5><b>Contacto: </b></h5>
                                <h6><%#Eval("telefono") %></h6>
                                <br />
                                <h5><b>Email: </b></h5>
                                <h6><%#Eval("correo") %></h6>
                                <br />
                                <h5><b>Tipo de referencia: </b></h5>
                                <h6><%#Eval("tipoReferencia") %></h6>
                                <br />
                                <h5><b>Relacion profesional: </b></h5>
                                <h6><%#Eval("relacionProfesional") %></h6>
                            </div>
                        </div>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <br />

                <h4 class="colorBase" style="border-radius: 6px; color: white; margin-bottom: 2%; text-align: center">Certificaciones: </h4>
                <asp:Repeater ID="rpCertificaciones" runat="server">
                    <ItemTemplate>
                        <div class=" card">
                            <div class=" container" style="margin-top: 3%; margin-bottom: auto; margin-bottom: 3%;">
                                <h5><b>Certificacion: </b></h5>
                                <h6><%#Eval("descripcionCertificacion") %></h6>
                                <br />
                                <h5><b>Institucion: </b></h5>
                                <h6><%#Eval("nombreInstitucion") %></h6>
                                <br />
                                <h5><b>Fecha: </b></h5>
                                <h6><%#Eval("fechaObtencion") %></h6>
                            </div>
                        </div>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <br />

                <h4 class="colorBase" style="border-radius: 6px; color: white; margin-bottom: 2%; text-align: center">Proyectos de desarrollo: </h4>
                <asp:Repeater ID="rpProyectosDesarrollo" runat="server">
                    <ItemTemplate>
                        <div class=" card">
                            <div class=" container" style="margin-top: 3%; margin-bottom: auto; margin-bottom: 3%;">
                                <h5><b>Proyecto de desarrollo: </b></h5>
                                <h6><%#Eval("titulo") %></h6>
                                <br />
                                <h5><b>Descripcion: </b></h5>
                                <h6><%#Eval("descripcion") %></h6>
                            </div>
                        </div>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <br />

                <h4 class="colorBase" style="border-radius: 6px; color: white; margin-bottom: 2%; text-align: center">Idiomas: </h4>
                <asp:Repeater ID="rpIdioma" runat="server">
                    <ItemTemplate>
                        <div class=" card">
                            <div class=" container" style="margin-top: 3%; margin-bottom: auto; margin-bottom: 3%;">
                                <h5><b>Idioma: </b></h5>
                                <h6><%#Eval("nombre") %></h6>
                                <br />
                                <h5><b>Nivel: </b></h5>
                                <h6><%#Eval("nivel") %></h6>
                            </div>
                        </div>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <br />

                <h4 class="colorBase" style="border-radius: 6px; color: white; margin-bottom: 2%; text-align: center">Logros academicos: </h4>
                <asp:Repeater ID="rpLogroAcademico" runat="server">
                    <ItemTemplate>
                        <div class=" card">
                            <div class=" container" style="margin-top: 3%; margin-bottom: auto; margin-bottom: 3%;">
                                <h5><b>Logro academico: </b></h5>
                                <h6><%#Eval("tituloLogroAcademico") %></h6>
                                <br />
                                <h5><b>Institucion: </b></h5>
                                <h6><%#Eval("nombreInstitucion") %></h6>
                                <br />
                                <h5><b>Periodo de tiempo: </b></h5>
                                <h6><%#Eval("periodoTiempo") %></h6>
                                <br />
                                <h5><b>Ubicacion: </b></h5>
                                <h6><%#Eval("ubicacion") %></h6>
                                <br />
                                <h5><b>Se entrego el: </b></h5>
                                <h6><%#Eval("fechaEntrega") %></h6>
                                <br />
                                <h5><b>Nivel: </b></h5>
                                <h6><%#Eval("nivel") %></h6>
                            </div>
                        </div>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <br />









            </div>
            <div class="col-md-2"></div>




        </div>

    </div>
</asp:Content>
