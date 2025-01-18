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


//función del formulario de recuperacion de contraseña
function mtdMostrarSugerencias() {

    alertify.alert("Sugerencias","➢ Verifica tener una conexion a internet estable para revisar tu correo. <br>➢ Asegurate de no haber eliminado la cuenta de correo con la que te registraste. <br>➢ Revisa la bandeja de spam o correo no deseado. <br>➢ La bandeja de entrada de tu correo podría estar llena.");

}