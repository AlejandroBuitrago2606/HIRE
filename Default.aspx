<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/menu.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HIRE.Vista.inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content_Head" runat="server">
    <link href="img/favicon.ico" rel="icon">

    <!-- Google Web Fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&family=Roboto:wght@300;500;700&display=swap" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">

    <!-- Libraries Stylesheet -->
    <link href="Vista/recursos/lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">
    <link href="Vista/recursos/lib/tempusdominus/css/tempusdominus-bootstrap-4.min.css" rel="stylesheet" />
    <title>Inicio</title>
    <link href="Vista/recursos/css/main3.css" rel="stylesheet" />

    <%--    <!-- Customized Bootstrap Stylesheet -->
    <link href="recursos/css/style.css" rel="stylesheet">--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content_Body" runat="server">

    <!-- Carousel Start -->
    <div class="container-fluid mb-0 pb-5">
        <div id="header-carousel" class="carousel slide carousel-fade" data-ride="carousel">
            <div class="carousel-inner">



                <div class="carousel-item position-relative active" style="height: 100vh; min-height: 200px;">
                    <div class="overlay"></div>
                    <!-- Capa de fondo oscuro -->
                    <img class="position-absolute w-100 h-100" src="Vista/recursos/imagenes/carrusel1.jpg" style="object-fit: cover; border-radius: 10px;">
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
                    <img class="position-absolute w-100 h-100" src="Vista/recursos/imagenes/carrusel2.jpg" style="object-fit: cover; border-radius: 10px;">
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
                    <img class="position-absolute w-100 h-100" src="Vista/recursos/imagenes/carrusel3.jpg" style="object-fit: cover; border-radius: 10px;">
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
                    <img class="position-absolute w-100 h-100" src="Vista/recursos/imagenes/carrusel4.jpg" style="object-fit: cover; border-radius: 10px;">
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
    <div class="container-fluid mt-0">
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
    <div class="container-fluid mt-5">
        <div class="container py-5">
            <div class="row">
                <div class="col-lg-3">
                    <h6 class="text-uppercase">Tu Portal de Empleo</h6>
                    <h1 class="mb-4">Áreas de Interés</h1>
                    <p>Explora las principales áreas laborales en Boyacá. Encuentra oportunidades que se adapten a tus habilidades, experiencia y metas. Nuestra plataforma está diseñada para conectarte con empresas locales y ayudarte a crecer profesionalmente.</p>

                </div>
                <div class="col-lg-9 pt-5 pt-lg-0">
                    <div class="bg-primary rounded" style="height: 200px;"></div>
                    <div class="owl-carousel service-carousel position-relative" style="margin-top: -100px; padding: 0 30px;">

                        <div class="sombra2 d-flex flex-column align-items-center text-center bg-white rounded pt-4 mb-2">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-briefcase"></i>
                            </div>
                            <h5 class="mb-4 px-4">Administración y Gestión</h5>
                            <p class="m-0">Encuentra empleos en áreas administrativas, gestión de proyectos y recursos humanos en empresas de Boyacá.</p>
                        </div>
                        <div class="sombra2 d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-hammer"></i>
                            </div>
                            <h5 class="mb-4 px-4">Construcción y Obra</h5>
                            <p class="m-0">Postúlate a trabajos en construcción, arquitectura e ingeniería civil en tu región.</p>
                        </div>
                        <div class="sombra2 d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-leaf"></i>
                            </div>
                            <h5 class="mb-4 px-4">Agricultura y Ambiente</h5>
                            <p class="m-0">Contribuye al crecimiento del sector agropecuario y cuidado ambiental en Boyacá.</p>
                        </div>
                        <div class="sombra2 d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-code"></i>
                            </div>
                            <h5 class="mb-4 px-4">Tecnología e Innovación</h5>
                            <p class="m-0">Descubre oportunidades en desarrollo de software, soporte técnico y proyectos tecnológicos.</p>
                        </div>
                        <div class="sombra2 d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-store"></i>
                            </div>
                            <h5 class="mb-4 px-4">Comercio y Ventas</h5>
                            <p class="m-0">Aplica a trabajos en viveres locales, minimarkets, megamarkets y almacenes de cadena en Boyacá.</p>
                        </div>
                        <div class="sombra2 d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-stethoscope"></i>
                            </div>
                            <h5 class="mb-4 px-4">Salud y Cuidado Personal</h5>
                            <p class="m-0">Encuentra oportunidades como asistente médico, enfermería o cuidado en salud en tu región.</p>
                        </div>
                        <div class="sombra2 d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-utensils"></i>
                            </div>
                            <h5 class="mb-4 px-4">Gastronomía y Turismo</h5>
                            <p class="m-0">Postúlate en el sector de restaurantes, cafeterías, hoteles y servicios turísticos locales.</p>
                        </div>
                        <div class="sombra2 d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-book"></i>
                            </div>
                            <h5 class="mb-4 px-4">Educación y Entrenamiento</h5>
                            <p class="m-0">Contribuye a la formación en instituciones educativas o capacitación especializada en Boyacá.</p>
                        </div>
                        <div class="sombra2 d-flex flex-column align-items-center text-center bg-white rounded pt-4">
                            <div class="icon-box text-primary mt-2 mb-4">
                                <i class="fa fa-2x fa-paint-brush"></i>
                            </div>
                            <h5 class="mb-4 px-4">Arte y Diseño</h5>
                            <p class="m-0">Apoya proyectos creativos, diseño gráfico y artes visuales en empresas locales.</p>
                        </div>
                        <br />
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
                        <video class="position-absolute w-100 h-100" autoplay muted loop style="object-fit: cover;">
                            <source src="../Vista/recursos/videos/vBannerFinal.mp4" type="video/mp4">
                            Tu navegador no soporta la etiqueta de video.
                        </video>
                    </div>
                </div>
                <div class="col-lg-6 pt-5 pb-lg-5">
                    <div class="feature-text bg-white rounded p-lg-5">
                        <h6 class="text-uppercase">Características Principales</h6>
                        <h1 class="mb-4">¿Por qué Elegirnos?</h1>
                        <div class="d-flex mb-4">
                            <div class="btn-primary btn-lg-square px-3 d-flex align-items-center" style="border-radius: 50px;">
                                <h4 class="text-white m-2">01</h4>
                            </div>
                            <div class="ml-4">
                                <h5>Conexión Local</h5>
                                <p class="m-0">Nuestra plataforma se enfoca en empresas y empleos dentro de Boyacá, fortaleciendo la economía local.</p>
                            </div>
                        </div>
                        <div class="d-flex mb-4">
                            <div class="btn-primary btn-lg-square px-3 d-flex align-items-center" style="border-radius: 50px;">
                                <h4 class="text-white m-2">02</h4>
                            </div>
                            <div class="ml-4">
                                <h5>Fácil de Usar</h5>
                                <p class="m-0">Una interfaz amigable que te permite buscar empleos, gestionar tu perfil y conectar con empresas en pocos pasos.</p>
                            </div>
                        </div>
                        <div class="d-flex">
                            <div class="btn-primary btn-lg-square px-3 d-flex align-items-center" style="border-radius: 50px;">
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


    <%-- Sección de Testimonios --%>
    <div class="container py-5">
        <h2 class="text-center mb-4">Lo que dicen nuestros usuarios</h2>
        <hr class="my-4 w-auto mx-auto" style="background-color: #10317A">
        <div class="owl-carousel testimonial-carousel">
            <div class="testimonial-item">
                <div class="rating">
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>

                </div>
                <p class="testimonial-text">"HIRE me ayudó a encontrar el trabajo de mis sueños en solo unas semanas!"</p>
                <h5>Juan Pérez</h5>
                <p>Ingeniero Civil</p>
            </div>

            <div class="testimonial-item">
                <div class="rating">
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>

                </div>
                <p class="testimonial-text">"Una plataforma fácil de usar y con muchas oportunidades."</p>
                <h5>Pedro Pascasio Martinez Chaparro</h5>
                <p>Maestro de Obra de Construcción</p>
            </div>

            <div class="testimonial-item">
                <div class="rating">
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                </div>
                <p class="testimonial-text">"Excelente experiencia, encontré el trabajo perfecto para mí."</p>
                <h5>Carlos Gómez</h5>
                <p>Desarrollador de Software</p>
            </div>

            <div class="testimonial-item">
                <div class="rating">
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                </div>
                <p class="testimonial-text">"La interfaz es muy intuitiva y fácil de navegar."</p>
                <h5>Ana Torres</h5>
                <p>Marketing Digital</p>
            </div>

            <div class="testimonial-item">
                <div class="rating">
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                </div>
                <p class="testimonial-text">"Recomiendo HIRE a todos mis amigos, es increíble!"</p>
                <h5>Laura Martínez</h5>
                <p>Arquitecta</p>
            </div>
            <div class="testimonial-item">
                <div class="rating">
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                </div>
                <p class="testimonial-text">"HIRE me ayudó a encontrar el trabajo de mis sueños en solo unas semanas!"</p>
                <h5>Juan Pérez</h5>
                <p>Ingeniero Civil</p>
            </div>

            <div class="testimonial-item">
                <div class="rating">
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                </div>
                <p class="testimonial-text">"Una plataforma fácil de usar y con muchas oportunidades."</p>
                <h5>María López</h5>
                <p>Diseñadora Gráfica</p>
            </div>

            <div class="testimonial-item">
                <div class="rating">
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                </div>
                <p class="testimonial-text">"Excelente experiencia, encontré el trabajo perfecto para mí."</p>
                <h5>Carlos Gómez</h5>
                <p>Desarrollador de Software</p>
            </div>

            <div class="testimonial-item">
                <div class="rating">
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                </div>
                <p class="testimonial-text">"La interfaz es muy intuitiva y fácil de navegar."</p>
                <h5>Ana Torres</h5>
                <p>Marketing Digital</p>
            </div>

            <div class="testimonial-item">
                <div class="rating">
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                    <span class="fa fa-star checked"></span>
                </div>
                <p class="testimonial-text">"Recomiendo HIRE a todos mis amigos, es increíble!"</p>
                <h5>Laura Martínez</h5>
                <p>Arquitecta</p>
            </div>
        </div>
    </div>


    <%-- Sección de Preguntas Frecuentes (FAQ) --%>
    <div class="container py-5">
        <h2 class="text-center mb-4">Preguntas Frecuentes</h2>
        <hr class="my-4 w-auto mx-auto" style="background-color: #10317A">
        <div class="accordion mt-3" id="faqAccordion">
            <div class="card sombra1">
                <div class="card-header" id="headingOne">
                    <h5 class="mb-0">
                        <button class="btn" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                            ●  ¿Cómo puedo postularme a empleos en Boyacá?
                        </button>
                    </h5>
                </div>
                <div id="collapseOne" class="collapse hide" aria-labelledby="headingOne" data-parent="#faqAccordion">
                    <div class="card-body">
                        Para postularte, solo necesitas crear una cuenta en la plataforma y completar tu CV, luego podrás buscar empleos disponibles en Boyacá y aplicar a las ofertas que se ajusten a tu perfil.
                    </div>
                </div>
            </div>
            <div class="card sombra1">
                <div class="card-header" id="headingTwo">
                    <h5 class="mb-0">
                        <button class="btn" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="true" aria-controls="collapseTwo">
                            ●  ¿Cómo puedo recuperar mi cuenta si olvidé la contraseña?
                        </button>
                    </h5>
                </div>
                <div id="collapseTwo" class="collapse hide" aria-labelledby="headingTwo" data-parent="#faqAccordion">
                    <div class="card-body">
                        Si olvidaste tu contraseña, haz clic en "Olvidaste tu contraseña?" en la página de inicio de sesión. Ingresas tu correo registrado y te enviaremos un codigo de 4 digitos para que puedas restablecerla.
                    </div>
                </div>
            </div>
            <div class="card sombra1">
                <div class="card-header" id="headingThree">
                    <h5 class="mb-0">
                        <button class="btn" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="true" aria-controls="collapseThree">
                            ●  ¿Cómo puedo registrar mi empresa para publicar ofertas de empleo?
                        </button>
                    </h5>
                </div>
                <div id="collapseThree" class="collapse hide" aria-labelledby="headingThree" data-parent="#faqAccordion">
                    <div class="card-body">
                        Para registrar tu empresa, crea una cuenta en la plataforma y selecciona la opción "Registrar Empresa". Completa la información requerida y podrás comenzar a publicar tus ofertas de empleo.
                    </div>
                </div>
            </div>
            <div class="card sombra1">
                <div class="card-header" id="headingFive">
                    <h5 class="mb-0">
                        <button class="btn" type="button" data-toggle="collapse" data-target="#collapseFive" aria-expanded="true" aria-controls="collapseFive">
                            ●  ¿Cómo puedo administrar mis publicaciones de empleo si soy una empresa?
                        </button>
                    </h5>
                </div>
                <div id="collapseFive" class="collapse hide" aria-labelledby="headingFive" data-parent="#faqAccordion">
                    <div class="card-body">
                        Después de registrar tu empresa, buscas tu empresa en 'Mis empresas' luego seleccionas 'Ir' y podrás acceder a un panel de administración donde podrás ver, gestionar y actualizar tus ofertas de empleo.
                    </div>
                </div>
            </div>
            <div class="card sombra1">
                <div class="card-header" id="headingSix">
                    <h5 class="mb-0">
                        <button class="btn" type="button" data-toggle="collapse" data-target="#collapseSix" aria-expanded="true" aria-controls="collapseSix">
                            ●  ¿La plataforma ofrece oportunidades laborales en todas las áreas en Boyacá?
                        </button>
                    </h5>
                </div>
                <div id="collapseSix" class="collapse hide" aria-labelledby="headingSix" data-parent="#faqAccordion">
                    <div class="card-body">
                        Sí, ofrecemos una amplia gama de oportunidades laborales en diversas áreas como administración, construcción, tecnología, salud, gastronomía, educación, y más. Puedes explorar todas las ofertas de diversas areas pulsando click <a href="Vista/busquedaVacante.aspx">aqui</a>.
                    </div>
                </div>
            </div>
            <div class="card sombra1">
                <div class="card-header" id="headingEight">
                    <h5 class="mb-0">
                        <button class="btn" type="button" data-toggle="collapse" data-target="#collapseEight" aria-expanded="true" aria-controls="collapseEight">
                            ●  ¿La plataforma es gratuita para los usuarios que buscan empleo?
                        </button>
                    </h5>
                </div>
                <div id="collapseEight" class="collapse hide" aria-labelledby="headingEight" data-parent="#faqAccordion">
                    <div class="card-body">
                        Sí, la plataforma es completamente gratuita para los usuarios que buscan empleo. Solo necesitas registrarte y crear un perfil para acceder a todas las ofertas laborales disponibles en Boyacá.
                    </div>
                </div>
            </div>
        </div>

    </div>


    <%-- Sección de Contacto --%>
    <div class="container py-5">
        <h2 class="text-center mb-4">Contáctanos</h2>

        <div class="form-group">
            <label for="name">Nombre</label>
            <input type="text" class="form-control" id="name">
        </div>
        <div class="form-group">
            <label for="email">Correo Electrónico</label>
            <input type="email" class="form-control" id="email">
        </div>
        <div class="form-group">
            <label for="message">Mensaje</label>
            <textarea class="form-control" id="message" rows="3" placeholder="Tu mensaje"></textarea>
        </div>
        <div class="d-flex justify-content-center">
            <button type="submit" class="btn btn-primary w-25">Enviar</button>
        </div>

    </div>


    <!-- Back to Top -->
    <a href="#" class="btn btn-primary px-3 back-to-top mb-5"><i class="fa fa-angle-double-up"></i></a>




    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.bundle.min.js"></script>
    <script src="Vista/recursos/lib/easing/easing.min.js"></script>
    <script src="Vista/recursos/lib/waypoints/waypoints.min.js"></script>
    <script src="Vista/recursos/lib/owlcarousel/owl.carousel.min.js"></script>
    <script src="Vista/recursos/lib/tempusdominus/js/moment.min.js"></script>
    <script src="Vista/recursos/lib/tempusdominus/js/moment-timezone.min.js"></script>
    <script src="Vista/recursos/lib/tempusdominus/js/tempusdominus-bootstrap-4.min.js"></script>

    <!-- Template Javascript -->
    <script src="Vista/recursos/js/main2.js"></script>


</asp:Content>
