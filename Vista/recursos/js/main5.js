document.addEventListener("DOMContentLoaded", function () {
    var fileInput = document.getElementById('Content_Body_cargarDocPDF');
    if (fileInput) {
        fileInput.addEventListener('change', function (event) {
            const file = event.target.files[0];

            if (file) {
                //Validar el tipo de archivo
                if (file.type === 'application/pdf') {
                    // Validar el tamaño del archivo
                    if (file.size > 5 * 1024 * 1024) { // 5MB
                        alert("El archivo debe ser menor a 5MB.");
                        event.target.value = ''; // Limpiar el input si el archivo no es válido
                    }
                } else {
                    alert("Solo se permiten archivos en formato PDF.");
                    event.target.value = ''; // Limpiar el input si no es un PDF
                }
            }
        });
    }
});


document.addEventListener("DOMContentLoaded", function () {
    var fileInput = document.getElementById('Content_Body_fuSoporteExp');
    if (fileInput) {
        fileInput.addEventListener('change', function (event) {
            const file = event.target.files[0];

            if (file) {
                // Definir los tipos de archivos permitidos: PDF, DOC y DOCX
                const tiposPermitidos = [
                    'application/pdf'
                ];

                // Validar el tipo de archivo
                if (tiposPermitidos.includes(file.type)) {
                    // Validar el tamaño del archivo (máximo 5MB)
                    if (file.size > 2 * 1024 * 1024) {
                        alert("El archivo debe ser menor a 2MB.");
                        event.target.value = ''; // Limpiar el input si el archivo no es válido
                    }
                } else {
                    alert("Solo se permiten soportes en formato PDF.");
                    event.target.value = ''; // Limpiar el input si no es un formato permitido
                }
            }
        });
    }
});


document.addEventListener("DOMContentLoaded", function () {
    // Capturar todos los botones "Agregar"
    document.querySelectorAll(".btnAgregar").forEach(function (boton) {
        boton.addEventListener("click", function (event) {
            // Obtener la pestaña donde se encuentra el botón
            let tabPane = this.closest(".tab-pane");

            // Validar solo los inputs y selects dentro de esta pestaña
            let inputs = tabPane.querySelectorAll("input, select");
            let valid = true;

            inputs.forEach(function (elemento) {
                if (elemento.value.trim() === "") {
                    elemento.classList.add("is-invalid"); // Agrega un borde rojo si está vacío
                    valid = false;
                } else {
                    elemento.classList.remove("is-invalid"); // Elimina el borde rojo si ya se corrigió
                }
            });

            // Si hay algún campo vacío, se evita el envío
            if (!valid) {
                event.preventDefault();
                alert("Por favor, completa todos los campos obligatorios en esta pestaña.");
            }
        });
    });
});

function mostrarPDF() {

    const urlHf = document.getElementById('Content_Body_hfHojaVida').value;

    if (urlHf !== null) {

        const url = urlHf.replace('~', '..');

        let currentPage = 1;
        let pdfDoc = null;
        const canvas = document.getElementById('pdf-canvasO');
        const context = canvas.getContext('2d');

        // Configuración de PDF.js
        const loadingTask = pdfjsLib.getDocument(url);
        loadingTask.promise.then(pdf => {
            pdfDoc = pdf;
            renderPage(currentPage);
        }).catch(error => {
            console.error('Error al cargar el PDF:', error);
        });

        // Función para renderizar una página
        function renderPage(pageNum) {
            pdfDoc.getPage(pageNum).then(page => {
                const viewport = page.getViewport({ scale: 1 });
                canvas.height = viewport.height;
                canvas.width = viewport.width;

                const renderContext = {
                    canvasContext: context,
                    viewport: viewport
                };
                page.render(renderContext);
            });
        }

        // Navegación de páginas
        document.getElementById('prev-page').addEventListener('click', () => {
            if (currentPage > 1) {
                currentPage--;
                renderPage(currentPage);
            }
        });

        document.getElementById('next-page').addEventListener('click', () => {
            if (currentPage < pdfDoc.numPages) {
                currentPage++;
                renderPage(currentPage);
            }
        });

    }

}

function mostrarSoportePDF() {
    const urlSoporte = document.getElementById('Content_Body_hfSoporte');
    //const abrirModal = document.getElementById('Content_Body_hfAbrirModal');   


    if (urlSoporte.value && urlSoporte.value.trim() !== '') {
        const url = urlSoporte.value.replace('~', '..');

        const modal = new bootstrap.Modal(document.getElementById('modal3'));
        modal.show();

        let currentPage = 1;
        let pdfDoc = null;
        const canvas = document.getElementById('pdf-canvas2');
        const context = canvas.getContext('2d');

        const loadingTask = pdfjsLib.getDocument(url);
        loadingTask.promise.then(pdf => {
            pdfDoc = pdf;
            renderPage(currentPage);
        }).catch(error => {
            alert('Error al cargar el PDF');
            console.log(error);
        });

        function renderPage(pageNum) {
            pdfDoc.getPage(pageNum).then(page => {
                const viewport = page.getViewport({ scale: 1 });
                canvas.height = viewport.height;
                canvas.width = viewport.width;

                const renderContext = {
                    canvasContext: context,
                    viewport: viewport
                };
                page.render(renderContext);
            });
        }

        document.getElementById('prev-page2').addEventListener('click', () => {
            if (currentPage > 1) {
                currentPage--;
                renderPage(currentPage);
            }
        });

        document.getElementById('next-page2').addEventListener('click', () => {
            if (currentPage < pdfDoc.numPages) {
                currentPage++;
                renderPage(currentPage);
            }
        });

    }


    urlSoporte.value = '';
}
