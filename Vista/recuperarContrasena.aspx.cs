using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class recuperarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) //Si se carga la pagina por primera vez.
            {

                Session["contador"] = 0;
                Session["codigo"] = "";
                Session["idUsuario"] = 0;

            }
            //Si es un postback normal, usar else para trabajarlo.
        
        }


        //Este evento del boton dinamico tiene 2 procesos diferentes, el primero es enviar un correo con un codigo de 4 digitos y el segundo es verificar el codigo ingresado por el usuario.
        protected void btnDinamico_Click(object sender, EventArgs e)
        {
            clUsuarioL objUsuarioL = new clUsuarioL();

            int contador = int.Parse(Session["contador"].ToString());

            if (contador == 0)
            {
                //ENVIAR CORREO
                if (!string.IsNullOrEmpty(txtParametros.Text))
                {

                    clUsuarioE objUsuarioE = objUsuarioL.mtdRecuperarContrasena(null, txtParametros.Text, null);

                    if (objUsuarioE.validar)
                    {

                        if (mtdComprobarInternet())
                        {
                            Session["codigo"] = "";
                            clEnviarCorreoL objEnviarCorreo = new clEnviarCorreoL();

                            string nombreCompleto = objUsuarioE.nombre + " " + objUsuarioE.apellido;
                            Random codigo4Digitos = new Random();
                            int codigo = codigo4Digitos.Next(1000, 10000);
                            Session["codigo"] = codigo.ToString();
                            clEnviarCorreoL objEnviarCodigo = new clEnviarCorreoL();
                            string asunto = "Recuperacion de contraseña, (Equipo de cuentas HIRE)";
                            string cuerpo = "Hola," + " " + nombreCompleto + " " + "Ingresa el codigo " + " *" + codigo + "* " + " en la plataforma para actualizar tu contraseña y entrar a tu cuenta";

                            //Enviar correo luego de validar el correo y el internet del usuario.
                            if (objEnviarCorreo.enviarCorreo(objUsuarioE.correo, nombreCompleto, asunto, cuerpo))
                            {

                                string alerta = @"alertify.success('Codigo enviado correctamente');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);
                                Session["idUsuario"] = objUsuarioE.idUsuario;
                                txtMensajePrincipal.InnerHtml = "Ingresa el codigo de cuatro digitos enviado a (<b>" + objUsuarioE.correo + "</b>).";
                                txtParametros.Attributes["placeholder"] = "";                                
                                txtParametros.Text = "";
                                
                                txtMensaje2.Visible = false;
                                btnDinamico.Text = "Verificar Codigo";
                                Session["contador"] = 1;
                                btnSugerencias.Visible = true;
                                                              
                            }

                        }
                        else
                        {

                            string alerta = "alertify.error('Conectate a internet para completar el registro');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);

                        }

                    }
                    else
                    {

                        string script = "alert('Usuario no registrado');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);
                    }
                }
                else
                {

                    string script = "alert('Ingresa un correo electronico');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);

                }
            }
            else
            {                

                string codigo = Session["codigo"].ToString();

                //VERIFICAR CODIGO
                if (string.IsNullOrEmpty(codigo))
                {
                    Session["contador"] = 0;
                    Session["codigo"] = "";
                    Session.Clear();
                    Session.Abandon();
                    string script = "alert('Ocurrió un error. Intenta generar el código nuevamente.'); setTimeout(function(){window.location.href = 'recuperarContraseña.aspx'}, 1000);";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);


                }
                else if (string.IsNullOrEmpty(txtParametros.Text) || txtParametros.Text.Length < 4 || txtParametros.Text.Length > 4)
                {
                    string script = "alertify.error('Por favor ingresa un codigo de 4 digitos');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertify", script, true);
                }
                else
                {

                    if (codigo == txtParametros.Text)
                    {
                        Session["codigo"] = "";
                        string alerta = @"alertify.success('Codigo verificado correctamente');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);

                        string Modal = @"
                        var myModal = new bootstrap.Modal(document.getElementById('actualizarClave'));
                        myModal.show();
                        ";

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", Modal, true);

                    }
                    else
                    {

                        string script = "alertify.warning('Codigo incorrecto');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertify", script, true);


                    }

                }

            }

        }

        protected void btnActualizarC_ServerClick(object sender, EventArgs e)
        {
            clUsuarioL objUsuarioL = new clUsuarioL();

            if (string.IsNullOrEmpty(txtContrasena.Text))
            {
                string script = "alert('La contraseña no puede estar vacia.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);
            }
            else if (txtContrasena.Text.Length > 8)
            {
                string script = "alert('Ingresa una contraseña de maximo 8 digitos.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);
            }
            else if (txtContrasena.Text.Length < 5)
            {
                string script = "alert('Ingresa una contraseña de minimo 5 digitos.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);
            }
            else
            {
                string idUsuario = Session["idUsuario"].ToString();
                string contrasenaUsuario = "";
                Session["idUsuario"] = 0;
                using (SHA256 sha256 = SHA256.Create())
                {

                    // Convertir la contraseña en bytes
                    byte[] bytes = Encoding.UTF8.GetBytes(txtContrasena.Text);

                    // Obtener el hash de la contraseña
                    byte[] hashBytes = sha256.ComputeHash(bytes);

                    // Convertir el hash en una cadena hexadecimal
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("x2"));  // Convierte el byte a un valor hexadecimal
                    }

                    contrasenaUsuario = sb.ToString();
                }

                clUsuarioE objUsuarioE = objUsuarioL.mtdRecuperarContrasena(idUsuario, null, contrasenaUsuario);
                if (objUsuarioE.validar)
                {
                    Session.Clear();
                    Session.Abandon();
                    string alerta = @"alertify.success('Contraseña actualizada correctamente, Inicia Sesion!!');  
                         setTimeout(function() {
                         window.location.href = 'login.aspx';
                         }, 1000);";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);
                }
                else
                {
                    string script = "alertify.error('Ocurrio un error al actualizar tu contraseña, vuelve a intentarlo');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertify", script, true);
                }

            }

        }

        private bool mtdComprobarInternet()
        {
            try
            {
                // Intenta hacer ping a Google DNS (8.8.8.8)
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("8.8.8.8", 3000); // Timeout de 4 segundos
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (PingException)
            {
                // Si ocurre una excepción, significa que no hay conexión.
                return false;
            }
        }

    }
}