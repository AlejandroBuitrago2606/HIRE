using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

                txtNombre.Attributes["required"] = "required";
                txtApellidos.Attributes["required"] = "required";
                txtContrasena.Attributes["required"] = "required";
                txtCorreo.Attributes["required"] = "required";
                txtDocumento.Attributes["required"] = "required";
                txtNumeroHijos.Attributes["required"] = "required";
                txtTelefono.Attributes["required"] = "required";
                dpMunicipios.Attributes["required"] = "required";
                dpEstadoCivil.Attributes["required"] = "required";
                dpCargo.Attributes["required"] = "required";




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

        protected void btnRegistrarse_ServerClick(object sender, EventArgs e)
        {

            clUsuarioE objDatosE = new clUsuarioE();




            if (Session["registro"].ToString() == "false")
            {

                objDatosE.nombre = txtNombre.Text;
                objDatosE.apellido = txtApellidos.Text;
                objDatosE.documento = txtDocumento.Text;
                objDatosE.fechaNacimiento = dFechaNacimiento.Text;
                objDatosE.estadoCivil = dpEstadoCivil.SelectedItem.Value;
                objDatosE.numeroHijos = txtNumeroHijos != null ? txtNumeroHijos.Text : "0";
                objDatosE.correo = txtCorreo.Text;
                objDatosE.telefono = txtTelefono.Text;
                objDatosE.direccion = txtDireccion != null ? txtDireccion.Text : null;

                if (hfLatitud.Value != null && hfLongitud.Value != null)
                {
                    string latitud = hfLatitud.Value.ToString();
                    string longitud = hfLongitud.Value.ToString();
                    objDatosE.ubicacion = latitud + " " + "|" + " " + longitud;

                }
                else
                {
                    objDatosE.ubicacion = null;
                }






                try
                {
                    if (fotoPerfil.HasFile)
                    {
                        //subir foto al servidor

                        string nombreImg = Path.GetFileName(fotoPerfil.FileName);
                        string rutaCompleta = Server.MapPath("~/Vista/recursos/fotosPerfil/") + nombreImg;

                        // Guardar el archivo en el servidor
                        fotoPerfil.SaveAs(rutaCompleta);

                        // Convertir la ruta completa en una ruta relativa
                        string rutaRelativa = "~/Vista/recursos/fotosPerfil/" + nombreImg;
                        objDatosE.foto = rutaRelativa;


                    }
                    else
                    {
                        objDatosE.foto = null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    objDatosE.foto = null;
                    throw;
                }

                objDatosE.contrasena = txtContrasena.Text;

                objDatosE.estado = "Desempleado";

                objDatosE.idMunicipio = dpMunicipios.SelectedValue;

                string idTipo = dpCargo.SelectedValue;

                clUsuarioL objUsuarioL = new clUsuarioL();

                bool validar = objUsuarioL.mtdRegistrarUsuario(objDatosE, idTipo);



                if (validar)
                {
                    Session["registro"] = "true";



                    string nombreCompleto = txtNombre.Text + " " + txtApellidos.Text;
                    string asunto = "Bienvenido a HIRE,  (Equipo de cuentas HIRE)";
                    string cuerpo = "Hola " + nombreCompleto + " " + "recientemente creaste una cuenta en nuestra plataforma, disfruta de todos nuestros servicios: " +
                        "\n \u0097 Encuentra tu empleo ideal." +
                        "\n \u0097 Publica empleos y Administra tus empresas." +
                        "\n \u0097 Encuentra talento para tus empresas." +
                        "\n \u0097 Administra tu perfil profesional." +
                        "\n \u0097 Mira estadisticas de rendimiento.";



                    clEnviarCorreoL objEnviarCorreo = new clEnviarCorreoL();
                    bool validarCorreo = objEnviarCorreo.enviarCorreo(txtCorreo.Text, nombreCompleto, asunto, cuerpo);


                    if (validarCorreo)
                    {

                        string alerta = @"alertify.success('Registro exitoso');  
                         setTimeout(function() {
                         window.location.href = 'login.aspx';
                         }, 800);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);

                    }
                    else
                    {

                        string alerta = @"alertify.error('Hubo un error al enviar el correo');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);

                        txtNombre.Text = "";
                        txtApellidos.Text = "";
                        txtContrasena.Text = "";
                        txtCorreo.Text = "";
                        txtDocumento.Text = "";
                        txtDireccion.Text = "";
                        txtNumeroHijos.Text = "";
                        txtTelefono.Text = "";
                        dpCargo.SelectedIndex = 0;
                        dpEstadoCivil.SelectedIndex = 0;
                        dpMunicipios.SelectedIndex = 0;
                        dFechaNacimiento.Text = "";

                    }

                }
                else
                {
                    Session["registro"] = "false";
                    string alerta = @"alertify.error('Hubo un error al registrarte, vuelve a intentarlo');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);

                    txtNombre.Text = "";
                    txtApellidos.Text = "";
                    txtContrasena.Text = "";
                    txtCorreo.Text = "";
                    txtDocumento.Text = "";
                    txtNumeroHijos.Text = "";
                    txtDireccion.Text = "";
                    txtTelefono.Text = "";
                    dpCargo.SelectedIndex = 0;
                    dpEstadoCivil.SelectedIndex = 0;
                    dpMunicipios.SelectedIndex = 0;
                    dFechaNacimiento.Text = "";




                }
            }
            else
            {
                Session["registro"] = "true";



                string nombreCompleto = txtNombre.Text + " " + txtApellidos.Text;
                string asunto = "Bienvenido a HIRE,  (Equipo de cuentas HIRE)";
                string cuerpo = "Hola " + nombreCompleto + "recientemente creaste una cuenta en nuestra plataforma, disfruta de todos nuestros servicios: " +
                    "\n \u0097 Encuentra tu empleo ideal." +
                    "\n \u0097 Publica empleos y Administra tus empresas." +
                    "\n \u0097 Encuentra talento para tus empresas." +
                    "\n \u0097 Administra tu perfil profesional." +
                    "\n \u0097 Mira estadisticas de rendimiento.";



                clEnviarCorreoL objEnviarCorreo = new clEnviarCorreoL();
                bool validarCorreo = objEnviarCorreo.enviarCorreo(txtCorreo.Text, nombreCompleto, asunto, cuerpo);


                if (validarCorreo)
                {

                    txtNombre.Text = "";
                    txtApellidos.Text = "";
                    txtContrasena.Text = "";
                    txtDireccion.Text = "";
                    txtCorreo.Text = "";
                    txtDocumento.Text = "";
                    txtNumeroHijos.Text = "";
                    txtTelefono.Text = "";
                    dpCargo.SelectedIndex = 0;
                    dpEstadoCivil.SelectedIndex = 0;
                    dpMunicipios.SelectedIndex = 0;
                    dFechaNacimiento.Text = "";

                    Session["registro"] = "false";
                    
                    
                    string alerta = @"alertify.success('Registro exitoso');  
                         setTimeout(function() {
                         window.location.href = 'login.aspx';
                         }, 800);";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);

                }
                else
                {

                    txtNombre.Text = "";
                    txtApellidos.Text = "";
                    txtContrasena.Text = "";
                    txtCorreo.Text = "";
                    txtDocumento.Text = "";
                    txtNumeroHijos.Text = "";
                    txtDireccion.Text = "";
                    txtTelefono.Text = "";
                    dpCargo.SelectedIndex = 0;
                    dpEstadoCivil.SelectedIndex = 0;
                    dpMunicipios.SelectedIndex = 0;
                    dFechaNacimiento.Text = "";

                    Session["registro"] = "false";


                    string alerta = @"

                            alertify.error('Hubo un error al enviar el correo');
                            ";

                    ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);

                    string redireccion = @"
                                alertify.success('Registro exitoso');
                                setTimeout(function () {

                                    window.location.href = 'login.aspx';


                                }, 2000)";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertify", redireccion, true);

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

                        if (CommandArgument == "Si")
                        {

                            string script = "obtenerUbicacion();";
                            ClientScript.RegisterStartupScript(this.GetType(), "obtenerUbicacion", script, true);

                        }
                        else
                        {

                            txtMsgUbicacion.InnerHtml = "<em>Puedes permitirla luego, en los ajustes de tu cuenta</em>";
                        }



                    }


                }




            }



        }
    }
}