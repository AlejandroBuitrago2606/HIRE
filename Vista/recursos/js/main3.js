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

    alertify.alert("○ Verifica tener una conexion a internet estable para revisar tu correo. \n ○ Asegurate de no haber eliminado la cuenta de correo con la que te registraste. \n ○ Revisa la bandeja de spam o correo no deseado. \n ○ La bandeja de entrada de tu correo podría estar llena.");

}