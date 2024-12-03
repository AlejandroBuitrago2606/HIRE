using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class recuperarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string ruta = Session["ruta"].ToString();
            string rutaA = Request.Url.AbsolutePath.ToString();
            string nombreArchivo = System.IO.Path.GetFileName(rutaA); //obtener el nombre del archivo de la ruta

            if (ruta == nombreArchivo)
            {
                string estadoAutenticacion = Session["autenticacion"].ToString();
                if (estadoAutenticacion == "ComprobarCodigo")
                {

                    string correoUsuario = Session["correoUsuario"].ToString();
                    Session["autenticacion"] = "ComprobarCodigo";

                }
                else if (estadoAutenticacion == "ActualizarContrasena")
                {

                    txtMensaje3.InnerText = "Ingresa tu nueva contraseña";
                    string Modal = @"
                    var myModal = new bootstrap.Modal(document.getElementById('actualizarClave'));
                    myModal.show();
                    ";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", Modal, true);
                    Session["autenticacion"] = "ActualizarContrasena";


                }



            }
            else
            {
                               
                Session["ruta"] = nombreArchivo;
                btnEnviarCorreo.Visible = true;
                txtMensaje2.Visible = true;

            }





        }

        protected void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            Session["autenticacion"] = "EnviarCorreo";
            string correo = txtParametros.Text;
            clUsuarioL objUsuarioL = new clUsuarioL();
            clUsuarioE objUsuarioE = objUsuarioL.mtdRecuperarContrasena(null, correo, null);

            string correoEnviado = Session["correoEnviado"].ToString();
            if (correoEnviado == "false")
            {

                if (objUsuarioE.validar == true)
                {
                    string nombreCompleto = objUsuarioE.nombre + " " + objUsuarioE.apellido;
                    Random codigo4Digitos = new Random();
                    int codigo = codigo4Digitos.Next(1000, 10000);
                    txtCodigo.Value = codigo.ToString();
                    clEnviarCorreoL objEnviarCodigo = new clEnviarCorreoL();
                    string asunto = "Recuperacion de contraseña, (Equipo de cuentas HIRE)";
                    string cuerpo = "Hola," + " " + nombreCompleto + " " + "Ingresa el codigo " + " *" + codigo + "* " + " en la plataforma para actualizar tu contraseña y entrar a tu cuenta";



                    bool validacion = objEnviarCodigo.enviarCorreo(objUsuarioE.correo, nombreCompleto, asunto, cuerpo);
                    if (validacion == true)
                    {
                        Session["correoEnviado"] = "true";
                        string alerta = @"alertify.success('Codigo enviado correctamente');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);
                        Session["idUsuario"] = objUsuarioE.idUsuario;

                        txtParametros.Attributes["placeholder"] = "";
                        txtParametros.Text = "";
                        txtParametros.TextMode = TextBoxMode.SingleLine;
                        btnEnviarCorreo.Visible = false;
                        txtMensajePrincipal.InnerHtml = "Ingresa el codigo de cuatro dijitos enviado a (<b>" + objUsuarioE.correo + "</b>).";
                        txtMensaje2.Visible = false;
                        btnVerificarCodigo.Visible = true;
                        Session["autenticacion"] = "ComprobarCodigo";
                        Session["correoUsuario"] = objUsuarioE.correo;
                    }
                    else
                    {

                        string alerta = @"alertify.warning('Hubo un error al enviar el correo');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);
                        txtCodigo.Value = "";
                    }

                }
                else
                {

                    string alerta = "alertify.warning('Usuario no registrado');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);

                }




            }
            else
            {

                string correoUsuario = Session["correoUsuario"].ToString();

                txtParametros.Attributes["placeholder"] = "";
                txtParametros.TextMode = TextBoxMode.SingleLine;
                btnEnviarCorreo.Visible = false;
                txtMensajePrincipal.InnerHtml = "Ingresa el codigo de 4 digitos enviado a (<b>" + correoUsuario + "</b>).";
                txtMensaje2.Visible = false;
                btnVerificarCodigo.Visible = true;
                Session["autenticacion"] = "ComprobarCodigo";
                Session["correoUsuario"] = correoUsuario;

            }






        }

        protected void btnVerificarCodigo_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Value == "")
            {
                Session["correoUsuario"] = "";
                Session["correoEnviado"] = "false";
                Session["autenticacion"] = "";
                Session["ruta"] = "";
                Response.Redirect(Request.RawUrl);//restablece todos los elementos y valores de la pagina actual, a su estado inicial.

            }
            else
            {

                string codigoRecibido = txtParametros.Text;
                if (codigoRecibido == txtCodigo.Value)
                {

                    string alerta = @"alertify.success('Codigo verificado correctamente');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);


                    txtMensaje3.InnerText = "Ingresa tu nueva contraseña";
                    string Modal = @"
                    var myModal = new bootstrap.Modal(document.getElementById('actualizarClave'));
                    myModal.show();
                    ";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", Modal, true);
                    Session["autenticacion"] = "ActualizarContrasena";


                }
                else
                {
                    string alerta = @"alertify.error('Codigo incorrecto');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);

                }

            }





        }

        protected void btnActualizarC_ServerClick(object sender, EventArgs e)
        {
            txtCodigo.Value = "";

            string contrasenaIngresada = txtContrasena.Text;

            if (contrasenaIngresada.Length < 9)
            {

                clUsuarioL objUsuarioE = new clUsuarioL();


                if (contrasenaIngresada.Length == 0)
                {

                    txtMensaje3.Attributes["style"] = "color: darkred;";
                    txtMensaje3.InnerText = "la contraseña no puede estar vacia";

                }
                else
                {
                    string idUsuario = Session["idUsuario"].ToString();
                    clUsuarioE objUsuarioValidacion = objUsuarioE.mtdRecuperarContrasena(idUsuario, null, contrasenaIngresada);
                    if (objUsuarioValidacion.validar == true)
                    {

                        Session.Clear();
                        Session.Abandon();


                        string alerta = @"alertify.success('Contraseña actualizada correctamente, Inicia Sesion!!');  
                         setTimeout(function() {
                         window.location.href = 'login.aspx';
                         }, 800);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);


                    }
                }

            }
            else
            {

                txtMensaje3.Attributes["style"] = "color: darkred;";
                txtMensaje3.InnerText = "la contraseña no puede ser de mas de 8 caracteres";

            }





        }
    }
}