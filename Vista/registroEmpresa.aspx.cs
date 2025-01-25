using HIRE.Entidades;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class registroEmpresa : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            clEmpresaL objEmpresaL = new clEmpresaL();

            if (!IsPostBack)
            {
                var filtros = objEmpresaL.mtdListarFiltros();

                dpMunicipios.Items.Add(new ListItem(""));
                foreach (clMunicipioE municipio in filtros.Item1)
                {
                    dpMunicipios.Items.Add(new ListItem(municipio.nombre, municipio.idMunicipio.ToString()));
                }

                dpTiposNegocio.Items.Add(new ListItem(""));
                foreach (clTipoNegocioE tipoNegocio in filtros.Item2)
                {
                    dpTiposNegocio.Items.Add(new ListItem(tipoNegocio.tipoNegocio, tipoNegocio.idTipoNegocio.ToString()));
                }

                dpSector.Items.Add(new ListItem(""));
                foreach (clSectorE sectorEconomico in filtros.Item3)
                {

                    dpSector.Items.Add(new ListItem(sectorEconomico.sector, sectorEconomico.idSector.ToString()));
                }

                txtMensajeUbicacion.Visible = false;
                Session["fotoEmpresa"] = null;
                hfCoordenadas.Value = "";

            }
            else
            {
                if (ftEmpresa.HasFile)
                {
                    Session["fotoEmpresa"] = ftEmpresa.PostedFile;
                }

            }

        }

        protected void rbSi_CheckedChanged(object sender, EventArgs e)
        {

            var rbNumeroEmpleados = sender as RadioButton;

            if (rbNumeroEmpleados != null && rbNumeroEmpleados.Checked)
            {

                string CommandName = rbNumeroEmpleados.Attributes["CommandName"];
                string CommandArgument = rbNumeroEmpleados.Attributes["CommandArgument"];

                if (CommandName == "numeroEmpleados")
                {
                    switch (CommandArgument)
                    {
                        case "Si":
                            lblMsgNumeroE.Visible = true;
                            txtNumeroEmpleados.Text = "";
                            txtNumeroEmpleados.Visible = true;
                            break;

                        case "No":
                            txtNumeroEmpleados.Text = "0";
                            txtNumeroEmpleados.Visible = false;
                            lblMsgNumeroE.Visible = false;
                            break;

                    }



                }



            }



        }

        protected void btnRegistrarEmpresa_Click(object sender, EventArgs e)
        {
            msgCorreo.Visible = false;
            msgNit.Visible = false;
            string fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime fHoy = DateTime.ParseExact(fechaHoy, "yyyy-MM-dd", null);
            DateTime? fechaConstitucion = null; // Permite valores nulos
            if (!string.IsNullOrEmpty(cFechaConstitucion.Text))
            {
                fechaConstitucion = DateTime.ParseExact(cFechaConstitucion.Text, "yyyy-MM-dd", null);
            }


            if (string.IsNullOrEmpty(txtNombreEmpresa.Text) || string.IsNullOrEmpty(txtNit.Text) || string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtTelefono1.Text) || string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrEmpty(dpTiposNegocio.Text) || string.IsNullOrEmpty(dpMunicipios.Text) || string.IsNullOrEmpty(dpSector.Text) || string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(cFechaConstitucion.Text) || string.IsNullOrEmpty(txtNumeroEmpleados.Text) || fechaConstitucion > fHoy)
            {
                if (string.IsNullOrEmpty(cFechaConstitucion.Text))
                {
                    string script1 = "alert('Ingresa una fecha valida.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "script1", script1, true);

                }
                else if (fechaConstitucion > fHoy)
                {
                    string script2 = "alert('La fecha de constitución no puede superar la actual.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "script2", script2, true);

                }
                else
                {
                    string script3 = "alert('Completa los campos obligatorios.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "script3", script3, true);

                }

            }
            else
            {

                if (Validar_reCAPTCHA())
                {
                    mssgRE.Style.Clear();

                    string script4 = @"grecaptcha.reset();";
                    ScriptManager.RegisterStartupScript(this, GetType(), "script4", script4, true);

                    mssgRE.Text = "Completa el reCAPTCHA";

                    clEmpresaL objEmpresaL = new clEmpresaL();
                    var respuestaValidacion = objEmpresaL.mtdValidarEmpresa(txtNit.Text, txtCorreo.Text);

                    if (respuestaValidacion.Item1 == 0 && respuestaValidacion.Item2 == 0)
                    {

                        //depurar...
                        clEmpresaE objDatosEmpresa = new clEmpresaE();
                        objDatosEmpresa.nombre = txtNombreEmpresa.Text;
                        objDatosEmpresa.nit = txtNit.Text;
                        objDatosEmpresa.descripcion = txtDescripcion.Text;
                        objDatosEmpresa.numeroEmpleados = txtNumeroEmpleados.Text;
                        objDatosEmpresa.fechaConstitucion = cFechaConstitucion.Text;
                        objDatosEmpresa.direccion = txtDireccion.Text;
                        objDatosEmpresa.ubicacion = hfCoordenadas.Value ?? "";
                        objDatosEmpresa.telefono1 = txtTelefono1.Text;
                        objDatosEmpresa.telefono2 = txtTelefono2.Text ?? "";
                        objDatosEmpresa.correo = txtCorreo.Text;
                        objDatosEmpresa.url = txtUrl.Text ?? "";
                        objDatosEmpresa.idTipoNegocio = int.Parse(dpTiposNegocio.SelectedValue);
                        objDatosEmpresa.idUsuario = int.Parse(Session["idUsuario"].ToString());
                        objDatosEmpresa.idMunicipio = int.Parse(dpMunicipios.SelectedValue);
                        objDatosEmpresa.idSector = int.Parse(dpSector.SelectedValue);


                        if (!string.IsNullOrEmpty(hfFotoEmpresa.Value))
                        {

                            byte[] imageBytes = Convert.FromBase64String(hfFotoEmpresa.Value);

                            // Genera un nombre aleatorio para el archivo
                            Random idFinalAleatorio = new Random();
                            string fileName = "imgEmpresa" + idFinalAleatorio.Next(1000, 9999).ToString() + ".png";

                            // Define la ruta relativa y completa
                            string rutaRelativa = "~/Vista/recursos/fotosEmpresa/" + fileName;
                            string rutaCompleta = Server.MapPath(rutaRelativa);

                            // Guarda los bytes como un archivo de imagen en la ruta completa
                            System.IO.File.WriteAllBytes(rutaCompleta, imageBytes);                            
                            objDatosEmpresa.foto = rutaRelativa;
                        }
                        else
                        {

                            objDatosEmpresa.foto = "~/Vista/recursos/fotosEmpresa/default.png";
                        }



                        if (objEmpresaL.mtdRegistrarEmpresa(objDatosEmpresa))
                        {
                            Session["fotoEmpresa"] = null;
                            hfCoordenadas.Value = "";

                            string alerta = @"alertify.success('Registro Exitoso');
                            setTimeout(function () {
                                window.location.href='../Vista/listaEmpresas.aspx';
                            }, 2000);";
                            ScriptManager.RegisterStartupScript(this, GetType(), "alerta", alerta, true);
                            //Response.Redirect("listaEmpresas.aspx");

                        }
                        else
                        {
                            //Eliminar foto del servidor si el registro falla
                            string rutaCompleta = Server.MapPath(objDatosEmpresa.foto);
                            if (System.IO.File.Exists(rutaCompleta) && objDatosEmpresa.foto != null && objDatosEmpresa.foto != "~/Vista/recursos/fotosEmpresa/default.png")
                            {
                                try
                                {
                                    System.IO.File.Delete(rutaCompleta);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                            }

                            string script5 = "alertify.error('Registro fallido. Verifica la información ingresada');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "script5", script5, true);

                        }

                    }
                    else
                    {
                        if (respuestaValidacion.Item1 == 2 && respuestaValidacion.Item2 == 2 || respuestaValidacion.Item1 == 2 || respuestaValidacion.Item2 == 2)
                        {

                            string script6 = "alert('Ocurrio un error, verifica la información ingresada');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "script6", script6, true);

                        }
                        else if (respuestaValidacion.Item1 > 0 && respuestaValidacion.Item2 == 0)
                        {

                            msgNit.Visible = true;
                            string script7 = @"const txtNit = document.getElementById('Content_Body_txtNit');                       
                            txtNit.classList.add('shake');                        
                            setTimeout(() => txtNit.classList.remove('shake'), 3000);                
                            txtNit.scrollIntoView({ behavior: 'smooth', block: 'center' });";
                            ScriptManager.RegisterStartupScript(this, GetType(), "script7", script7, true);

                        }
                        else if (respuestaValidacion.Item2 > 0 && respuestaValidacion.Item1 == 0)
                        {
                            msgCorreo.Visible = true;
                            string script8 = @"const txtCorreo = document.getElementById('Content_Body_txtCorreo');                       
                            txtCorreo.classList.add('shake');                        
                            setTimeout(() => txtCorreo.classList.remove('shake'), 3000);                        
                            txtCorreo.scrollIntoView({ behavior: 'smooth', block: 'center' });";
                            ScriptManager.RegisterStartupScript(this, GetType(), "script8", script8, true);
                        }
                        else
                        {

                            string script9 = "alert('Esta empresa ya esta registrada');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "script9", script9, true);

                        }

                    }

                }
                else
                {
                    mssgRE.Style.Add("color", "crimson");
                    mssgRE.Text = "Por favor verifica que no eres un robot.";
                    string script10 = @"
                    grecaptcha.reset();
                    setTimeout(function () {                    
                        const recaptchaContainer = document.getElementById('recaptcha-container');                       
                        recaptchaContainer.classList.add('shake');                        
                        setTimeout(() => recaptchaContainer.classList.remove('shake'), 4000);                        
                        recaptchaContainer.scrollIntoView({ behavior: 'smooth', block: 'center' });
                    }, 1000);";

                    ScriptManager.RegisterStartupScript(this, GetType(), "script10", script10, true);

                }

            }

        }

        protected void rbSiUbicacion_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton radioButton = sender as RadioButton;


            if (radioButton != null && radioButton.Checked)
            {

                if (radioButton.Attributes["CommandName"].ToString() == "PermitirUbicacion")
                {

                    if (radioButton.Attributes["CommandArgument"].ToString() == "Si")
                    {

                        txtMensajeUbicacion.Visible = false;
                        string script11 = "obtenerUbicacion()";
                        ScriptManager.RegisterStartupScript(this, GetType(), "script11", script11, true);

                    }
                    else
                    {
                        txtMensajeUbicacion.Visible = true;
                        hfCoordenadas.Value = null;
                    }

                }


            }

        }

        public bool Validar_reCAPTCHA()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = ConfigurationManager.AppSettings["SecretKey"];
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }


    }
}