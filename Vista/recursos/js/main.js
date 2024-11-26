
    document.addEventListener("DOMContentLoaded", function () {
        const currentPath = window.location.pathname.split('/').pop();
    const links = document.querySelectorAll(".nav-Link");

        links.forEach(link => {
        // Limpiar clases activas previamente
        link.parentElement.classList.remove("active");

    // Agregar clase "active" si coincide con la ruta
    if (link.getAttribute("href") === currentPath) {
        link.parentElement.classList.add("active");
            }
        });
    });
