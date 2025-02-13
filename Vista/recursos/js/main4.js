function mostrarUbicacion() {
    var coordenadasJSON = document.getElementById('Content_Body_hfCoordenadas').value;

    if (coordenadasJSON) {
        try {
            var coordenadas = JSON.parse(coordenadasJSON); // Convertir de JSON a objeto
            var lat = coordenadas.lat;
            var lng = coordenadas.lng;

            var map = L.map('Content_Body_map').setView([lat, lng], 13);

            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '&copy; OpenStreetMap contributors'
            }).addTo(map);

            L.marker([lat, lng]).addTo(map)
                .bindPopup('Ubicación: ' + lat + '</br>' + lng)
                .openPopup();
        } catch (error) {
            console.error('Error al cargar tu ubicación:', error);
        }
    }
}
function mostrarUbicacion2() {
    var coordenadasJSON = document.getElementById('ContentBody_hfCoordenadas').value;

    if (coordenadasJSON) {
        try {
            var coordenadas = JSON.parse(coordenadasJSON); // Convertir de JSON a objeto
            var lat = coordenadas.lat;
            var lng = coordenadas.lng;

            var map = L.map('ContentBody_map').setView([lat, lng], 13);

            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '&copy; OpenStreetMap contributors'
            }).addTo(map);

            L.marker([lat, lng]).addTo(map)
                .bindPopup('Ubicación: ' + lat + '</br>' + lng)
                .openPopup();
        } catch (error) {
            console.error('Error al cargar tu ubicación:', error);
        }
    }
}


function obtenerUbicacion() {

    if (!navigator.geolocation) {
        console.error("La geolocalización no está soportada por este navegador.");
        return;
    }

    const opciones = {
        enableHighAccuracy: true,
        timeout: 10000,
        maximumAge: 0
    };

    navigator.geolocation.getCurrentPosition(
        (position) => {

            const latitud = position.coords.latitude;
            const longitud = position.coords.longitude;

            // Crear el objeto coordenadas
            const coordenadas = { lat: latitud, lng: longitud };
            document.getElementById("Content_Body_hfCoordenadas").value = JSON.stringify(coordenadas); // Guarda como string

        },
        (error) => {
            alert("Error al obtener la ubicación: " + error.message);
        },
        opciones
    );
}



document.getElementById('Content_Body_imgCargarFoto').addEventListener('change', function (event) {

    const file = event.target.files[0];
    const hfFotoUsuario = document.getElementById("Content_Body_hfFtUsuario");
    const imgFotoUsuario = document.getElementById("Content_Body_imgFotoUsuario");

    if (file) {

        //Validar el tipo de archivo
        if (file.type.startsWith('image/')) {

            // Validar el tamaño del archivo
            if (file.size > 2 * 1024 * 1024) { // 2MB


                imgFotoUsuario.src = '../Vista/recursos/imagenes/perfil.png';
                alert("La imagen debe ser menor a un peso de 2MB.");
                // Limpia el input si el archivo no es válido
                event.target.value = '';
            }
            else {
                const reader = new FileReader();
                reader.onload = function (e) {
                    const base64String = e.target.result.split(',')[1]; // Obtener solo la parte base64

                    // Guardar la cadena base64 en el HiddenField
                    hfFotoUsuario.value = base64String;
                    imgFotoUsuario.src = e.target.result;
                };
                reader.readAsDataURL(file);

            }
        }
        else {
            imgFotoUsuario.src = '../Vista/recursos/imagenes/perfil.png';
            alert("Los formatos admitidos son (.png, .jpeg)");
            event.target.value = '';
        }

    }
});



document.getElementById("Content_Body_txtFechaNacimiento").addEventListener("change", function () {
    var fechaSeleccionada = new Date(this.value);
    var fechaActual = new Date();

    // Calcular la fecha límite para que sea mayor de 18 años
    var fechaMinima = new Date();
    fechaMinima.setFullYear(fechaActual.getFullYear() - 18);

    if (fechaSeleccionada > fechaMinima) {
        alert('Debes ser mayor de 18 años');
        this.value = ""; // Limpia el campo si la fecha no es válida
    }
});

function actualizacionSi() {
    alertify.success('Información actualizada correctamente');
    setTimeout(function () { window.location.reload();}, 2000);
}
function actualizacionNo() {
    alert('Ocurrio un error al actualizar tu informacion, intenta nuevamente.');
    setTimeout(function () { window.location.reload(); }, 2000);
}

