<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/menu.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="HIRE.Vista.inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">
    <link href="img/favicon.ico" rel="icon">

    <!-- Google Web Fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&family=Roboto:wght@300;500;700&display=swap" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">

    <!-- Libraries Stylesheet -->
    <link href="recursos/lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">
    <link href="recursos/lib/tempusdominus/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />

    <%--    <!-- Customized Bootstrap Stylesheet -->
    <link href="recursos/css/style.css" rel="stylesheet">--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_Body" runat="server">

    <!-- Carousel Start -->
    <div class="container-fluid p-0 mb-5 pb-5">
        <div id="header-carousel" class="carousel slide carousel-fade" data-ride="carousel">
            <div class="carousel-inner">



                <div class="carousel-item position-relative active" style="height: 100vh; min-height: 200px;">
                    <div class="overlay"></div>
                    <!-- Capa de fondo oscuro -->
                    <img class="position-absolute w-100 h-100" src="recursos/imagenes/carrusel1.jpg" style="object-fit: cover; border-radius: 10px;">
                    <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">
                        <div class="p-3" style="max-width: 900px;">
                            <h4 class="text-white text-uppercase mb-4" style="letter-spacing: 3px;">Encuentra tu futuro</h4>
                            <h3 class="display-2 text-capitalize text-white mb-4">Miles de empleos te esperan</h3>

                        </div>
                    </div>
                </div>

                <div class="carousel-item position-relative" style="height: 100vh; min-height: 200px;">
                    <div class="overlay"></div>
                    <!-- Capa de fondo oscuro -->
                    <img class="position-absolute w-100 h-100" src="recursos/imagenes/carrusel2.jpg" style="object-fit: cover; border-radius: 10px;">
                    <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">
                        <div class="p-3" style="max-width: 900px;">
                            <h4 class="text-white text-uppercase mb-4" style="letter-spacing: 3px;">Impulsa tu carrera</h4>
                            <h3 class="display-2 text-capitalize text-white mb-4">Postúlate y crece profesionalmente</h3>

                        </div>
                    </div>
                </div>

                <div class="carousel-item position-relative" style="height: 100vh; min-height: 200px;">
                    <div class="overlay"></div>

                    <!-- Capa de fondo oscuro -->
                    <img class="position-absolute w-100 h-100" src="recursos/imagenes/carrusel3.jpg" style="object-fit: cover; border-radius: 10px;">
                    <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">
                        <div class="p-3" style="max-width: 900px;">
                            <h4 class="text-white text-uppercase mb-4" style="letter-spacing: 3px;">Eficiencia en tus manos</h4>
                            <h3 class="display-2 text-capitalize text-white mb-4">Administra empleos fácilmente</h3>

                        </div>
                    </div>
                </div>


                <div class="carousel-item position-relative" style="height: 100vh; min-height: 200px;">
                    <div class="overlay"></div>
                    <!-- Capa de fondo oscuro -->
                    <img class="position-absolute w-100 h-100" src="recursos/imagenes/carrusel4.jpg" style="object-fit: cover; border-radius: 10px;">
                    <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">
                        <div class="p-3" style="max-width: 900px;">
                            <h4 class="text-white text-uppercase mb-4" style="letter-spacing: 3px;">Conecta con empresas</h4>
                            <h3 class="display-2 text-capitalize text-white mb-4">Publica ofertas y encuentra talento</h3>

                        </div>
                    </div>
                </div>
            </div>
            <a class="carousel-control-prev" href="#header-carousel" data-slide="prev">
                <div class="btn btn-lg btn-secondary btn-lg-square">
                    <span class="carousel-control-prev-icon"></span>
                </div>
            </a>
            <a class="carousel-control-next" href="#header-carousel" data-slide="next">
                <div class="btn btn-lg btn-secondary btn-lg-square">
                    <span class="carousel-control-next-icon"></span>
                </div>
            </a>
        </div>
    </div>
    <!-- Carousel End -->


    <!-- About Start -->
    <div class="container-fluid py-5">
        <div class="container py-5">
            <div class="row">
                <div class="col-md-5">
                    <img class="img-fluid rounded" src="https://careerspages.com/wp-content/uploads/2021/06/0932756a6bdee8384cf14768fc8b342c_Job-Search.jpeg" alt="">
                </div>
                <div class="col-md-7 mt-4 mt-lg-0">
                    <h2 class="position-relative text-center bg-white text-primary rounded p-3 mt-4 mb-4 d-none d-lg-block" style="width: 350px; margin-left: -205px;">Que es HIRE?</h2>
                    <h1 class="mb-4">Encuentra empleo de forma rápida y sencilla</h1>
                    <p>HIRE es una innovadora plataforma web diseñada para gestionar y buscar empleos en el departamento de Boyacá. Con un enfoque en la simplicidad y eficiencia, permite a los usuarios encontrar oportunidades laborales con solo unos clics, optimizando todo el proceso de búsqueda y aplicación.</p>
                </div>
            </div>
        </div>
    </div>
    <!-- About End -->


    <!-- Services Start -->
    <div class="container-fluid py-5">
        <div class="container py-5">
            <div class="row">
                <div class="col-lg-3">
                    <h6 class="text-uppercase">Tu Portal de Empleo</h6>
                    <h1 class="mb-4">Áreas de Interés</h1>
                    <p>Explora las principales áreas laborales en Boyacá. Encuentra oportunidades que se adapten a tus habilidades, experiencia y metas. Nuestra plataforma está diseñada para conectarte con empresas locales y ayudarte a crecer profesionalmente.</p>
                    <a href="#" class="btn btn-primary mt-2">Ver Más Áreas</a>
                </div>
                <div class="col-lg-9 pt-5 pt-lg-0">
                    <div class="bg-primary rounded" style="height: 200px;"></div>
                    <div class="owl-carousel service-carousel position-relative" style="margin-top: -100px; padding: 0 30px;">
                        <div class="d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-briefcase"></i>
                            </div>
                            <h5 class="mb-4 px-4">Administración y Gestión</h5>
                            <p class="m-0">Encuentra empleos en áreas administrativas, gestión de proyectos y recursos humanos en empresas de Boyacá.</p>
                        </div>
                        <div class="d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-hammer"></i>
                            </div>
                            <h5 class="mb-4 px-4">Construcción y Obra</h5>
                            <p class="m-0">Postúlate a trabajos en construcción, arquitectura e ingeniería civil en tu región.</p>
                        </div>
                        <div class="d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-leaf"></i>
                            </div>
                            <h5 class="mb-4 px-4">Agricultura y Ambiente</h5>
                            <p class="m-0">Contribuye al crecimiento del sector agropecuario y cuidado ambiental en Boyacá.</p>
                        </div>
                        <div class="d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-code"></i>
                            </div>
                            <h5 class="mb-4 px-4">Tecnología e Innovación</h5>
                            <p class="m-0">Descubre oportunidades en desarrollo de software, soporte técnico y proyectos tecnológicos.</p>
                        </div>
                        <div class="d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-store"></i>
                            </div>
                            <h5 class="mb-4 px-4">Comercio y Ventas</h5>
                            <p class="m-0">Aplica a trabajos en viveres locales, minimarkets, megamarkets y almacenes de cadena en Boyacá.</p>
                        </div>
                        <div class="d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-stethoscope"></i>
                            </div>
                            <h5 class="mb-4 px-4">Salud y Cuidado Personal</h5>
                            <p class="m-0">Encuentra oportunidades como asistente médico, enfermería o cuidado en salud en tu región.</p>
                        </div>
                        <div class="d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-utensils"></i>
                            </div>
                            <h5 class="mb-4 px-4">Gastronomía y Turismo</h5>
                            <p class="m-0">Postúlate en el sector de restaurantes, cafeterías, hoteles y servicios turísticos locales.</p>
                        </div>
                        <div class="d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-book"></i>
                            </div>
                            <h5 class="mb-4 px-4">Educación y Entrenamiento</h5>
                            <p class="m-0">Contribuye a la formación en instituciones educativas o capacitación especializada en Boyacá.</p>
                        </div>
                        <div class="d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-paint-brush"></i>
                            </div>
                            <h5 class="mb-4 px-4">Arte y Diseño</h5>
                            <p class="m-0">Apoya proyectos creativos, diseño gráfico y artes visuales en empresas locales.</p>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Services End -->


    <!-- Features Start -->
    <div class="container-fluid py-5">
        <div class="container py-5">
            <div class="row">
                <div class="col-lg-6" style="min-height: 500px;">
                    <div class="position-relative h-100 rounded overflow-hidden">
                        <img class="position-absolute w-100 h-100" src="recursos/imagenes/bannerFinal.jpg" style="object-fit: cover;">
                    </div>
                </div>
                <div class="col-lg-6 pt-5 pb-lg-5">
                    <div class="feature-text bg-white rounded p-lg-5">
                        <h6 class="text-uppercase">Características Principales</h6>
                        <h1 class="mb-4">¿Por qué Elegirnos?</h1>
                        <div class="d-flex mb-4">
                            <div class="btn-primary btn-lg-square px-3" style="border-radius: 50px;">
                                <h4 class="text-white m-2">01</h4>
                            </div>
                            <div class="ml-4">
                                <h5>Conexión Local</h5>
                                <p class="m-0">Nuestra plataforma se enfoca en empresas y empleos dentro de Boyacá, fortaleciendo la economía local.</p>
                            </div>
                        </div>
                        <div class="d-flex mb-4">
                            <div class="btn-primary btn-lg-square px-3" style="border-radius: 50px;">
                                <h4 class="text-white m-2">02</h4>
                            </div>
                            <div class="ml-4">
                                <h5>Fácil de Usar</h5>
                                <p class="m-0">Una interfaz amigable que te permite buscar empleos, gestionar tu perfil y conectar con empresas en pocos pasos.</p>
                            </div>
                        </div>
                        <div class="d-flex">
                            <div class="btn-primary btn-lg-square px-3" style="border-radius: 50px;">
                                <h4 class="text-white m-2">03</h4>
                            </div>
                            <div class="ml-4">
                                <h5>Resultados Rápidos</h5>
                                <p class="m-0">Encuentra las mejores oportunidades de empleo y conecta con empresas de manera inmediata.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Features End -->

    <%--    <!-- Testimonial Start -->
    <div class="container-fluid py-5">
        <div class="container py-5">
            <div class="text-center pb-5">
                <h6 class="text-uppercase">Testimonial</h6>
                <h1 class="mb-5">What Our Clients Say</h1>
            </div>
            <div class="owl-carousel testimonial-carousel">
                <div class="testimonial-item">
                    <div class="testimonial-text position-relative bg-secondary text-light rounded p-5 mb-4">
                        Sed ea amet kasd elitr stet nonumy, stet rebum et ipsum est duo elitr clita lorem
                    </div>
                    <div class="d-flex align-items-center pt-3">
                        <img class="img-fluid rounded-circle" src="img/testimonial-1.jpg" style="width: 80px; height: 80px;" alt="">
                        <div class="pl-4">
                            <h5>Client Name</h5>
                            <p class="m-0">Profession</p>
                        </div>
                    </div>
                </div>
                <div class="testimonial-item">
                    <div class="testimonial-text position-relative bg-secondary text-light rounded p-5 mb-4">
                        Sed ea amet kasd elitr stet nonumy, stet rebum et ipsum est duo elitr clita lorem
                    </div>
                    <div class="d-flex align-items-center pt-3">
                        <img class="img-fluid rounded-circle" src="img/testimonial-2.jpg" style="width: 80px; height: 80px;" alt="">
                        <div class="pl-4">
                            <h5>Client Name</h5>
                            <p class="m-0">Profession</p>
                        </div>
                    </div>
                </div>
                <div class="testimonial-item">
                    <div class="testimonial-text position-relative bg-secondary text-light rounded p-5 mb-4">
                        Sed ea amet kasd elitr stet nonumy, stet rebum et ipsum est duo elitr clita lorem
                    </div>
                    <div class="d-flex align-items-center pt-3">
                        <img class="img-fluid rounded-circle" src="img/testimonial-3.jpg" style="width: 80px; height: 80px;" alt="">
                        <div class="pl-4">
                            <h5>Client Name</h5>
                            <p class="m-0">Profession</p>
                        </div>
                    </div>
                </div>
                <div class="testimonial-item">
                    <div class="testimonial-text position-relative bg-secondary text-light rounded p-5 mb-4">
                        Sed ea amet kasd elitr stet nonumy, stet rebum et ipsum est duo elitr clita lorem
                    </div>
                    <div class="d-flex align-items-center pt-3">
                        <img class="img-fluid rounded-circle" src="img/testimonial-4.jpg" style="width: 80px; height: 80px;" alt="">
                        <div class="pl-4">
                            <h5>Client Name</h5>
                            <p class="m-0">Profession</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Testimonial End -->--%>


    <!-- Back to Top -->
    <a href="#" class="btn btn-primary px-3 back-to-top"><i class="fa fa-angle-double-up"></i></a>




    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.bundle.min.js"></script>
    <script src="recursos/lib/easing/easing.min.js"></script>
    <script src="recursos/lib/waypoints/waypoints.min.js"></script>
    <script src="recursos/lib/owlcarousel/owl.carousel.min.js"></script>
    <script src="recursos/lib/tempusdominus/js/moment.min.js"></script>
    <script src="recursos/lib/tempusdominus/js/moment-timezone.min.js"></script>
    <script src="recursos/lib/tempusdominus/js/tempusdominus-bootstrap-4.min.js"></script>

    <!-- Template Javascript -->
    <script src="recursos/js/main2.js"></script>


</asp:Content>
