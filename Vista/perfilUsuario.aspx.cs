using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Drawing;
using Image = System.Drawing.Image;
using Org.BouncyCastle.Crypto.Generators;



namespace HIRE.Vista
{
    public partial class perfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                clVacanteL objfiltrosL = new clVacanteL();
                var filtros = objfiltrosL.mtdListarFiltros();

                foreach (clMunicipioE municipio in filtros.Item1)
                {
                    dpMunicipios.Items.Add(new ListItem(municipio.nombre, municipio.idMunicipio.ToString()));
                }

                foreach (clCargoE cargo in filtros.Item4)
                {
                    dpCargo.Items.Add(new ListItem(cargo.cargo, cargo.idTipo.ToString()));
                }

                dpEstadoCivil.DataSource = filtros.Item5;
                dpEstadoCivil.DataBind();
                Session["coordenadas"] = "";

            }

            Session["coordenadas"] = hfCoordenadas.Value;
            mtdTraerUsuario(1);

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
                            txtNumeroHijos.Text = "";
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

                        if (CommandArgument == "Si")
                        {

                            string obtenerUbicacion = @"obtenerUbicacion();";
                            ScriptManager.RegisterStartupScript(this, GetType(), "obtenerUbicacion", obtenerUbicacion, true);

                        }
                        else
                        {

                            hfCoordenadas.Value = "";

                        }

                    }
                }
            }
        }

        protected void btnSolicitudA_Click(object sender, EventArgs e)
        {

            domAccionesFoto.Visible = true;
            domActualizarFoto.Visible = true;
            lblNombreFoto.Visible = false;
            domBtnSolicitudA.Visible = false;
            lblNombreApellido.Visible = false;
            domNombreApellido.Visible = true;
            lblDocumento.Visible = false;
            domDocumento.Visible = true;
            lblFechaNacimiento.Visible = false;
            domFechaNacimiento.Visible = true;
            lblEstadoCivil.Visible = false;
            domEstadoCivil.Visible = true;
            lblNumeroHijos.Visible = false;
            domNumeroHijos.Visible = true;
            lblCargoActual.Visible = false;
            domCargo.Visible = true;
            lblCorreo.Visible = false;
            domCorreo.Visible = true;
            lblTelefono.Visible = false;
            domTelefono.Visible = true;
            lblDireccion.Visible = false;
            domDireccion.Visible = true;
            lblMunicipio.Visible = false;
            domMunicipio.Visible = true;
            lblUbicacion.Visible = false;
            domUbicacion.Visible = true;
            domClave.Visible = true;
            domBtnActualizar.Visible = true;
            mtdTraerUsuario(2);


        }

        protected void accionesFoto_ServerClick(object sender, EventArgs e)
        {
            HtmlButton btnSeleccionado = (HtmlButton)sender;


            switch (btnSeleccionado.ID)
            {

                case "btnEliminarFoto":
                    hfFtUsuario.Value = "";
                    hfFtUsuario.Value = "~/Vista/recursos/imagenes/perfil.png";
                    imgFotoUsuario.Src = ResolveUrl("~/Vista/recursos/imagenes/perfil.png");

                    ScriptManager.RegisterStartupScript(this, GetType(), "clearFileUpload", "document.getElementById('Content_Body_imgCargarFoto').value = '';", true);
                    break;

                case "btnRestaurarFoto":
                    hfFtUsuario.Value = "";
                    hfFtUsuario.Value = hfFotoUsuarioDefault.Value;
                    imgFotoUsuario.Src = ResolveUrl(hfFotoUsuarioDefault.Value);
                    ScriptManager.RegisterStartupScript(this, GetType(), "clearFileUpload", "document.getElementById('Content_Body_imgCargarFoto').value = '';", true);
                    break;

            }

        }



        /// <summary>
        /// Carga los datos del usuario en la pagina (1 para mostrar datos, 2 para cargar datos)
        /// </summary>
        /// <param name="opcion">1 para mostrar datos, 2 para cargar datos</param>
        private void mtdTraerUsuario(int opcion)
        {
            clUsuarioL objDatosUsuarioL = new clUsuarioL();
            clUsuarioE datosUsuario = objDatosUsuarioL.mtdValidarUsuario(null, int.Parse(Session["idUsuario"].ToString()));

            switch (opcion)
            {

                case 1:

                    //Cargar datos del usuario en los labels.
                    imgFotoUsuario.Src = ResolveUrl(datosUsuario.foto);
                    lblNombreFoto.InnerHtml = "<b>" + datosUsuario.nombre + " " + datosUsuario.apellido + "</b>";
                    lblNombreApellido.InnerHtml = "<b>Nombre completo:</b>" + " " + datosUsuario.nombre + " " + datosUsuario.apellido;
                    lblDocumento.InnerHtml = "<b>Documento:</b>" + " " + datosUsuario.documento;
                    lblFechaNacimiento.InnerHtml = "<b>Fecha de nacimiento:</b>" + " " + DateTime.Parse(datosUsuario.fechaNacimiento).ToString("yyyy-MM-dd");
                    lblEstadoCivil.InnerHtml = "<b>Estado civil:</b>" + " " + datosUsuario.estadoCivil;
                    lblNumeroHijos.InnerHtml = "<b>Número de hijos:</b>" + " " + datosUsuario.numeroHijos;
                    lblCorreo.InnerHtml = "<b>Correo:</b>" + " " + datosUsuario.correo;
                    lblTelefono.InnerHtml = "<b>Teléfono:</b>" + " " + datosUsuario.telefono;
                    lblDireccion.InnerHtml = "<b>Dirección:</b>" + " " + datosUsuario.direccion;

                    foreach (ListItem item in dpMunicipios.Items)
                    {


                        if (datosUsuario.idMunicipio == item.Value)
                        {
                            lblMunicipio.InnerHtml = "<b>Municipio:</b>" + " " + item.Text + ", Boyaca";
                            break;
                        }

                    }

                    hfCoordenadas.Value = datosUsuario.ubicacion.ToString();

                    string script = "mostrarUbicacion()";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarUbicacion", script, true);



                    foreach (ListItem item in dpCargo.Items)
                    {
                        if (datosUsuario.idTipo == item.Value)
                        {
                            lblCargoActual.InnerHtml = "<b>Cargo actual:</b>" + " " + item.Text;
                            break;
                        }
                    }

                    hfClaveUsuario.Value = datosUsuario.contrasena.ToString();
                    hfFotoUsuarioDefault.Value = datosUsuario.foto;

                    break;


                case 2:


                    //Cargar datos del usuario en los inputs
                    txtNombre.Text = datosUsuario.nombre;
                    txtApellido.Text = datosUsuario.apellido;
                    txtDocumento.Text = datosUsuario.documento;
                    txtFechaNacimiento.Text = DateTime.Parse(datosUsuario.fechaNacimiento).ToString("yyyy-MM-dd");
                    dpEstadoCivil.SelectedValue = datosUsuario.estadoCivil;

                    if (int.Parse(datosUsuario.numeroHijos) > 0)
                    {
                        rbSi.Checked = true;
                        txtNumeroHijos.Visible = true;
                        lblMsgNumeroH.Visible = true;
                        txtNumeroHijos.Text = datosUsuario.numeroHijos;
                    }
                    else
                    {
                        rbNo.Checked = true;
                        txtNumeroHijos.Text = datosUsuario.numeroHijos;
                    }

                    txtCorreo.Text = datosUsuario.correo;
                    txtTelefono.Text = datosUsuario.telefono;
                    txtDireccion.Text = datosUsuario.direccion;
                    dpMunicipios.SelectedValue = datosUsuario.idMunicipio;

                    if (!string.IsNullOrEmpty(datosUsuario.ubicacion))
                    {
                        rbSiUbicacion.Checked = true;
                    }
                    else
                    {
                        rbNoUbicacion.Checked = true;
                    }
                    dpCargo.SelectedValue = datosUsuario.idTipo;



                    break;

            }

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtNuevaClave.Text) && string.IsNullOrEmpty(txtConfirmarClave.Text))
            {
                string validacionClave = "alert('Confirma tu nueva contraseña.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "validacionClave", validacionClave, true);

            }
            else
            {
                string coordenadas = Session["coordenadas"].ToString();
                string claveUsuario = "";

                if (!string.IsNullOrEmpty(txtConfirmarClave.Text))
                {

                    try
                    {
                        using (SHA256 sha256 = SHA256.Create())
                        {

                            // Convertir la contraseña en bytes
                            byte[] bytes = Encoding.UTF8.GetBytes(txtConfirmarClave.Text);

                            // Obtener el hash de la contraseña
                            byte[] hashBytes = sha256.ComputeHash(bytes);

                            // Convertir el hash en una cadena hexadecimal
                            StringBuilder sb = new StringBuilder();
                            foreach (byte b in hashBytes)
                            {
                                sb.Append(b.ToString("x2"));  // Convierte el byte a un valor hexadecimal
                            }
                            claveUsuario = sb.ToString();

                        }
                    }
                    catch (Exception exception)
                    {

                        Console.WriteLine(exception.Message);
                    }

                }
                else
                {
                    claveUsuario = hfClaveUsuario.Value.ToString();

                }


                string rutaImagen = "";

                if (!string.IsNullOrEmpty(hfFtUsuario.Value))
                {

                    if (!EsImagenBase64(hfFtUsuario.Value) && System.IO.File.Exists(Server.MapPath(hfFtUsuario.Value)))
                    {
                        if (hfFtUsuario.Value == "~/Vista/recursos/imagenes/perfil.png")
                        {
                            if (hfFotoUsuarioDefault.Value == "~/Vista/recursos/imagenes/perfil.png")
                            {
                                rutaImagen = hfFtUsuario.Value;
                            }
                            else
                            {
                                string rutaCompletaFotoDefault = Server.MapPath(hfFotoUsuarioDefault.Value);
                                System.IO.File.Delete(rutaCompletaFotoDefault);
                                rutaImagen = hfFtUsuario.Value;
                            }


                        }
                        else
                        {
                            rutaImagen = hfFtUsuario.Value;
                        }

                    }
                    else
                    {

                        try
                        {
                            if (hfFotoUsuarioDefault.Value != "~/Vista/recursos/imagenes/perfil.png")
                            {
                                string rutaCompletaFotoDefault = Server.MapPath(hfFotoUsuarioDefault.Value);
                                System.IO.File.Delete(rutaCompletaFotoDefault);
                            }


                            byte[] imageBytes = Convert.FromBase64String(hfFtUsuario.Value);

                            // Genera un nombre aleatorio para el archivo
                            Random idFinalAleatorio = new Random();
                            string fileName = "imgUsuario" + idFinalAleatorio.Next(1000, 9999).ToString() + ".png";

                            // Define la ruta relativa y completa
                            string rutaRelativa = "~/Vista/recursos/fotosPerfil/" + fileName;
                            string rutaCompleta = Server.MapPath(rutaRelativa);

                            // Guarda los bytes como un archivo de imagen en la ruta completa
                            System.IO.File.WriteAllBytes(rutaCompleta, imageBytes);
                            rutaImagen = rutaRelativa;
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }

                    }

                }
                else
                {
                    rutaImagen = hfFotoUsuarioDefault.Value;
                }


                clUsuarioE objDatosUsuario = new clUsuarioE
                {
                    idUsuario = int.Parse(Session["idUsuario"].ToString()),
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    documento = txtDocumento.Text,
                    fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text).ToString("yyyy-MM-dd"),
                    estadoCivil = dpEstadoCivil.SelectedItem.Text,
                    numeroHijos = txtNumeroHijos.Text,
                    idTipo = dpCargo.SelectedValue,
                    correo = txtCorreo.Text,
                    telefono = txtTelefono.Text,
                    direccion = txtDireccion.Text,
                    idMunicipio = dpMunicipios.SelectedValue,
                    ubicacion = Session["coordenadas"].ToString(),
                    contrasena = claveUsuario,
                    foto = rutaImagen

                };

                //Envio los datos al metodo para actualizar el usuario
                clUsuarioL objUsuarioL = new clUsuarioL();
                if (objUsuarioL.mtdActualizarUsuario(objDatosUsuario))
                {
                    string modificacionExistosa = @"alertify.success('Información actualizada correctamente');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "modificacionExistosa", modificacionExistosa, true);

                }
                else
                {
                    string modificacionFallida = @"alert('Ocurrio un error al actualizar tu informacion, intenta nuevamente.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "modificacionFallida", modificacionFallida, true);

                }

            }

        }

        private bool EsImagenBase64(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
                return false;

            try
            {
                // Verificar si es una cadena Base64 válida
                byte[] imageBytes = Convert.FromBase64String(base64String);

                // Intentar convertir los bytes en una imagen
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    using (Image img = Image.FromStream(ms))
                    {
                        // Si no lanza una excepción, es una imagen válida
                        return true;
                    }
                }
            }
            catch
            {
                return false; // Si hay una excepción, no es una imagen válida
            }
        }

    }


}