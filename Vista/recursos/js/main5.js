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
    } else {
        alert("No se encontró el input de archivo.");
    }
});