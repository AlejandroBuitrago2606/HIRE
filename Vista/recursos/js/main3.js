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