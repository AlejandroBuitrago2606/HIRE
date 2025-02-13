function mostrarPDF2() {

    const urlHf = document.getElementById('ContentBody_hfHojaVida').value;

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

function mostrarSoportePDF2() {
    const urlSoporte = document.getElementById('ContentBody_hfSoporte');
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