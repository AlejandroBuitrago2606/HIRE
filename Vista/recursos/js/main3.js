function verContrasena() {

    const txtContrasena = document.getElementById('<%= txtContrasena.ClientID %>');
    const toggleIcon = document.getElementById('btnVer');

    // Cambiar el atributo 'type' (relevante en el navegador)
    if (txtContrasena.getAttribute("type") == "password") {
        txtContrasena.setAttribute("type", "text");
        toggleIcon.className = "bi bi-eye-slash";
    } else {
        txtContrasena.setAttribute("type", "password");
        toggleIcon.className = "bi bi-eye";
    }

}

//Lo consume el formulario de recuperar contraseña
function mtdMostrarSugerencias() {

    alertify.alert("Sugerencias", "➢ Verifica tener una conexion a internet estable para revisar tu correo. <br>➢ Asegurate de no haber eliminado la cuenta de correo con la que te registraste. <br>➢ Revisa la bandeja de spam o correo no deseado. <br>➢ La bandeja de entrada de tu correo podría estar llena.");

}

//Lo consume el formulario de registro de empresa
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

//Funcion para validar el tamaño de la imagen 
// Se activa con el evento 'change' luego de elegir un archivo en el input:file

document.getElementById('Content_Body_ftEmpresa').addEventListener('change', function (event) {
    const file = event.target.files[0];
    const hfFotoEmpresa = document.getElementById("Content_Body_hfFotoEmpresa");

    if (file) {

        //Validar el tipo de archivo
        if (file.type.startsWith('image/')) {

            // Validar el tamaño del archivo
            if (file.size > 2 * 1024 * 1024) { // 2MB



                alert("La imagen debe ser menor a un peso de 2MB.");
                // Limpia el input si el archivo no es válido
                event.target.value = '';
            }
            else {
                const reader = new FileReader();
                reader.onload = function (e) {
                    const base64String = e.target.result.split(',')[1]; // Obtener solo la parte base64

                    // Guardar la cadena base64 en el HiddenField
                    hfFotoEmpresa.value = base64String;                 
                };
                reader.readAsDataURL(file);
                
            }
        }
        else {
            alert("Los formatos admitidos son (.png, .jpeg)");
            event.target.value = '';
        }

    }
});


