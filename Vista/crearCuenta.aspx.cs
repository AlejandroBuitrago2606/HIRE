using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{

    public partial class crearCuenta : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                clVacanteL objfiltrosL = new clVacanteL();
                List<clMunicipioE> listaMunicipios = objfiltrosL.mtdListarFiltros().Item1;
                List<clCargoE> listaCargos = objfiltrosL.mtdListarFiltros().Item4;
                ArrayList estadoCivil = objfiltrosL.mtdListarFiltros().Item5;

                foreach (clMunicipioE municipio in listaMunicipios)
                {
                    dpMunicipios.Items.Add(new ListItem(municipio.nombre, municipio.idMunicipio.ToString()));
                }

                foreach (clCargoE cargo in listaCargos)
                {
                    dpCargo.Items.Add(new ListItem(cargo.cargo, cargo.idTipo.ToString()));
                }

                dpEstadoCivil.DataSource = estadoCivil;
                dpEstadoCivil.DataBind();
                txtAyuda1.Visible = false;
                txtAyuda2.Visible = false;
                txtAyuda3.Visible = false;

                rbSiUbicacion.Attributes["onclick"] = "obtenerUbicacion()";


            }

        }

        protected void rbSi_CheckedChanged(object sender, EventArgs e)
        {

            var cbNumeroHijos = sender as RadioButton;

            if (cbNumeroHijos != null)
            {

                if (cbNumeroHijos.Checked)
                {

                    string CommandName = cbNumeroHijos.Attributes["CommandName"];
                    string CommandArgument = cbNumeroHijos.Attributes["CommandArgument"];


                    if (CommandName == "SeleccionarHijos")
                    {
                        if (CommandArgument == "Si")
                        {
                            txtNumeroHijos.Visible = true;
                            lblMsgNumeroH.Visible = true;
                        }
                        else
                        {

                            txtNumeroHijos.Visible = false;
                            lblMsgNumeroH.Visible = false;
                            txtNumeroHijos.Text = "0";

                        }


                    }

                }

            }

        }

        protected void rbSiUbicacion_CheckedChanged(object sender, EventArgs e)
        {

            var opcion = sender as RadioButton;

            if (opcion != null)
            {

                if (opcion.Checked)
                {

                    string CommandName = opcion.Attributes["CommandName"];
                    string CommandArgument = opcion.Attributes["CommandArgument"];


                    if (CommandName == "PermitirUbicacion")
                    {

                        if (CommandArgument != "Si")
                        {
                            txtMsgUbicacion.InnerHtml = "<em>Puedes permitirla luego, en los ajustes de tu cuenta</em>";
                            txtMsgUbicacion.Visible = true;
                        }
                        else
                        {
                            txtMsgUbicacion.Visible = false;
                        }

                    }


                }
            }
        }

        protected void btnRegistrarse_ServerClick(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrEmpty(txtDocumento.Text) || string.IsNullOrEmpty(txtNumeroHijos.Text) || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrWhiteSpace(dpMunicipios.SelectedItem.Text) || string.IsNullOrWhiteSpace(dpEstadoCivil.SelectedItem.Text) || string.IsNullOrWhiteSpace(dpCargo.SelectedItem.Text) || txtContrasena.Text.Length > 8)
            {

                if (txtContrasena.Text.Length > 8)
                {
                    string script1 = "alert('La contraseña no debe tener mas de 8 digitos');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script1, true);

                }
                else
                {

                    string script = "alert('Completa los campos obligatorios');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);

                }

            }
            else
            {
                clUsuarioE objDatosE = new clUsuarioE();
                Application["objDatosU"] = null;
                Session["codigo"] = "";

                objDatosE.nombre = txtNombre.Text;
                objDatosE.apellido = txtApellidos.Text;
                objDatosE.documento = txtDocumento.Text;
                objDatosE.fechaNacimiento = dFechaNacimiento.Text;
                objDatosE.estadoCivil = dpEstadoCivil.SelectedItem.Value;
                objDatosE.numeroHijos = txtNumeroHijos != null ? txtNumeroHijos.Text : "0";
                objDatosE.correo = txtCorreo.Text;
                objDatosE.telefono = txtTelefono.Text;
                objDatosE.direccion = txtDireccion != null ? txtDireccion.Text : null;


                //CORREGIR FUNCION
                if (hfCoordenadas.Value != null)
                {
                    objDatosE.ubicacion = hfCoordenadas.Value.ToString();
                }
                else
                {
                    objDatosE.ubicacion = null;
                }

                //Encriptar contraseña.
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
                    objDatosE.contrasena = sb.ToString();

                }


                objDatosE.estado = "Buscando empleo";

                objDatosE.idMunicipio = dpMunicipios.SelectedValue;

                objDatosE.idTipo = dpCargo.SelectedValue;

                if (mtdComprobarInternet())
                {

                    //comprueba si el correo ya esta registrado
                    clUsuarioL objDatosL = new clUsuarioL();
                    var correoExistente = objDatosL.mtdRegistrarUsuario(null, txtCorreo.Text);

                    if (correoExistente.Item2 > 0)
                    {

                        string script = "alert('No se pudo completar el registro. Por favor, verifica tus datos.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);

                    }
                    else
                    {

                        var respuesta = MtdEnviarCorreo(txtCorreo.Text, 1);

                        if (respuesta.Item1)
                        {
                            Application["objDatosU"] = objDatosE;
                            Session["codigo"] = respuesta.Item2.ToString();

                            string Modal = @"
                            var myModal = new bootstrap.Modal(document.getElementById('modalRegistro'));
                            myModal.show();";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", Modal, true);

                        }
                        else
                        {

                            string script = "alertify.error('Hubo un error al enviarte el codigo, por favor verifica la direccion de correo que ingresaste.');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "alertify", script, true);

                        }

                    }

                }
                else
                {
                    string alerta = "alertify.error('Conectate a internet para completar el registro');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);

                }

            }

        }

        public static bool mtdComprobarInternet()
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

        private (bool, int) MtdEnviarCorreo(string correo, int opcion, string nombre = null, string apellido = null)
        {
            bool validarCorreo;
            clEnviarCorreoL objEnviarCorreo = new clEnviarCorreoL();
            int codigo4D = 0;

            if (opcion <= 1)
            {

                Random codigo4Digitos = new Random();

                codigo4D = codigo4Digitos.Next(1000, 10000);

                string asunto = "Codigo de Verificación,  (Equipo de cuentas HIRE)";
                string cuerpo = "Hola por favor introduce este codigo de 4 digitos para continuar con el registro:" + " " + codigo4D;
                validarCorreo = objEnviarCorreo.enviarCorreo(correo, "", asunto, cuerpo);

            }
            else
            {
                string nombreCompleto = nombre + " " + apellido;
                string asunto = "Bienvenido a HIRE,  (Equipo de cuentas HIRE)";
                string cuerpo = "Hola " + nombreCompleto + " " + "recientemente creaste una cuenta en nuestra plataforma, disfruta de todos nuestros servicios: " +
                    "\n • Encuentra tu empleo ideal." +
                    "\n • Publica empleos y Administra tus empresas." +
                    "\n • Encuentra talento para tus empresas." +
                    "\n • Administra tu perfil profesional." +
                    "\n • Mira estadisticas de rendimiento.";

                validarCorreo = objEnviarCorreo.enviarCorreo(correo, nombreCompleto, asunto, cuerpo);

            }

            return (validarCorreo, codigo4D);

        }

        protected void txtMostrarAyuda_ServerClick(object sender, EventArgs e)
        {

            if (txtAyuda1.Visible == false && txtAyuda2.Visible == false && txtAyuda3.Visible == false)
            {
                txtAyuda1.Visible = true;
                txtAyuda2.Visible = true;
                txtAyuda3.Visible = true;
            }
            else
            {
                txtAyuda1.Visible = false;
                txtAyuda2.Visible = false;
                txtAyuda3.Visible = false;
            }

        }

        protected void btnVerificarCodigo_Click(object sender, EventArgs e)
        {
            if (mtdComprobarInternet())
            {

                if (!string.IsNullOrEmpty(txtCodigo4D.Text) && txtCodigo4D.Text.Length == 4)
                {

                    string codigo4D = Session["codigo"].ToString();
                    if (codigo4D == txtCodigo4D.Text)
                    {
                        clUsuarioE objDatosE = (clUsuarioE)Application["objDatosU"];
                        Session["codigo"] = "";
                        Application["objDatosU"] = null;

                        //SUBIR FOTO AL SERVER
                        string nombreImg = Path.GetFileName(fotoPerfil.FileName);
                        if (fotoPerfil.HasFile)
                        {

                            try
                            {
                                //subir foto al servidor
                                Random idFinalAletorio = new Random();


                                string rutaRelativa = "~/Vista/recursos/fotosPerfil/" + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + nombreImg;
                                string rutaCompleta = Server.MapPath(rutaRelativa);


                                // Guardar el archivo en el servidor
                                fotoPerfil.SaveAs(rutaCompleta);

                                objDatosE.foto = rutaRelativa;

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                objDatosE.foto = null;

                            }

                        }
                        else
                        {
                            objDatosE.foto = null;
                        }

                        clUsuarioL objUsuarioL = new clUsuarioL();
                        var respuesta = objUsuarioL.mtdRegistrarUsuario(objDatosE);

                        if (respuesta.Item1)
                        {

                            var respuestaCorreo = MtdEnviarCorreo(objDatosE.correo, 2, objDatosE.nombre, objDatosE.apellido);

                            hfCoordenadas.Value = null;

                            if (respuestaCorreo.Item1)
                            {

                                string script = "alertify.success('Registro exitoso'); setTimeout(function(){ window.location = 'login.aspx'}, 1500)";
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertify", script, true);

                            }
                            else
                            {

                                string script = "alertify.success('Registro exitoso'); setTimeout(function(){ window.location = 'login.aspx'}, 4000)";
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertify", script, true);

                            }

                        }
                        else
                        {
                            try
                            {

                                hfCoordenadas.Value = null;

                                //Eliminar foto del servidor si el correo existe
                                string rutaCompleta = Server.MapPath(objDatosE.foto);
                                if (objDatosE.foto != null && System.IO.File.Exists(rutaCompleta))
                                {

                                    System.IO.File.Delete(rutaCompleta);

                                }


                                string script = @"alert('No se pudo completar el registro. Por favor, verifica tus datos.');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);

                            }
                            catch (Exception error)
                            {
                                Console.WriteLine(error.Message);
                                string script = "alert('Estamos experimentando algunos inconvenientes. Por favor, recarga la página. ERROR:" + " *" + error.ToString() + "*');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "alert", script, true);
                            }

                        }

                    }
                    else
                    {

                        string script = "alertify.warning('Codigo Incorrecto');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertify", script, true);

                    }

                }
                else
                {
                    string script = "alert('⚠️ Por favor, introduce un código de 4 dígitos.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);

                }

            }
            else
            {
                string alerta = "alertify.error('Conectate a internet para completar el registro');";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);

            }

        }

    }
}