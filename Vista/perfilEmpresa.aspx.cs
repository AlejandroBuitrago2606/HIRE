using HIRE.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Image = System.Drawing.Image;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace HIRE.Vista
{
    public partial class perfilEmpresa1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Session["coordenadas"] = "";
                clEmpresaL objEmpresaL = new clEmpresaL();
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

                //Session["fotoEmpresa"] = null;
                hfCoordenadas.Value = "";

            }
            Session["coordenadas"] = hfCoordenadas.Value;
            mtdCargarDatos(1);

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

        protected void rbSiUbicacion_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton radioButton = sender as RadioButton;


            if (radioButton != null && radioButton.Checked)
            {

                if (radioButton.Attributes["CommandName"].ToString() == "PermitirUbicacion")
                {

                    if (radioButton.Attributes["CommandArgument"].ToString() == "Si")
                    {
                        string script11 = "obtenerUbicacion()";
                        ScriptManager.RegisterStartupScript(this, GetType(), "script11", script11, true);

                    }
                    else
                    {
                        hfCoordenadas.Value = "";
                    }

                }


            }

        }

        protected void btnSolicitudA_Click(object sender, EventArgs e)
        {
            h3TituloActualizar.InnerText = "Actualizar información.";
            mtdCargarDatos(2);

            domNombre.Visible = true;
            lblNombre.Visible = false;

            lblNit.Visible = false;
            domNIT.Visible = true;

            lblDireccion.Visible = false;
            domDireccion.Visible = true;

            domTelefono1.Visible = true;
            lblTelefono1.Visible = false;

            domCorreo.Visible = true;
            lblCorreo.Visible = false;

            domTNegocio.Visible = true;
            lblTipodeNegocio.Visible = false;

            domMunicipio.Visible = true;
            lblNombreMunicipio.Visible = false;

            domSector.Visible = true;
            lblSector.Visible = false;

            domDescripcion.Visible = true;
            lblDescripcion.Visible = false;

            domFechaConstitucion.Visible = true;
            lblFechaConstitucion.Visible = false;

            domTelefono2.Visible = true;
            lblTelefono2.Visible = false;

            domEmpleados.Visible = true;
            lblCantidadEmpleados.Visible = false;

            domActualizarFoto.Visible = true;

            domBtnActualizar.Visible = true;

            lblNombreFoto.Visible = false;

            lblUbicacion.Visible = false;
            domUbicacion.Visible = true;

            domBtnSolicitudA.Visible = false;

            domAccionesFoto.Visible = true;

            lblUrl.Visible = false;
            domUrl.Visible = true;

        }


        protected void mtdCargarDatos(int opcion)
        {

            clEmpresaL objClEmpresaL = new clEmpresaL();
            clEmpresaE datosEmpresa = objClEmpresaL.mtdTraerEmpresa(int.Parse(Session["idEmpresa"].ToString())).Item1;
            clEmpresaL objEmpresaL = new clEmpresaL();
            var filtros = objEmpresaL.mtdListarFiltros();

            switch (opcion)
            {

                case 1:

                    imgFotoEmpresa.Src = ResolveUrl(datosEmpresa.foto);
                    lblNombreFoto.InnerText = datosEmpresa.nombre;
                    lblNombre.InnerHtml = "<b>Razon Social:</b>" + " " + datosEmpresa.nombre;
                    lblNit.InnerHtml = "<b>NIT:</b>" + " " + datosEmpresa.nit;
                    lblDireccion.InnerHtml = "<b>Dirección:</b>" + " " + datosEmpresa.direccion;
                    lblTelefono1.InnerHtml = "<b>Telefono de Contacto 1:</b>" + " " + datosEmpresa.telefono1;
                    lblCorreo.InnerHtml = "<b>Correo electronico:</b>" + " " + datosEmpresa.correo;
                    lblUrl.InnerHtml = "<b>Pagina Web:</b>" + " " + datosEmpresa.url;

                    foreach (clTipoNegocioE obj in filtros.Item2)
                    {
                        if (obj.idTipoNegocio == datosEmpresa.idTipoNegocio)
                        {
                            lblTipodeNegocio.InnerHtml = "<b>Tipo de Negocio:</b>" + " " + obj.tipoNegocio;
                            break;
                        }
                    }

                    foreach (clMunicipioE obj in filtros.Item1)
                    {
                        if (obj.idMunicipio == datosEmpresa.idMunicipio)
                        {
                            lblNombreMunicipio.InnerHtml = "<b>Municipio:</b>" + " " + obj.nombre + ", " + "Boyaca";
                            break;
                        }

                    }

                    foreach (clSectorE obj in filtros.Item3)
                    {
                        if (obj.idSector == datosEmpresa.idSector)
                        {
                            lblSector.InnerHtml = "<b>Sector:</b>" + " " + obj.sector;
                            break;
                        }

                    }

                    lblDescripcion.InnerText = datosEmpresa.descripcion;
                    lblFechaConstitucion.InnerHtml = "<b>Fecha de constitución:</b>" + " " + DateTime.Parse(datosEmpresa.fechaConstitucion).ToString("yyyy-MM-dd");
                    lblTelefono2.InnerHtml = "<b>Telefono de contacto 2:</b>" + " " + datosEmpresa.telefono2;
                    lblCantidadEmpleados.InnerHtml = "<b>Numero de empleados:</b>" + " " + datosEmpresa.numeroEmpleados;
                    hfCoordenadas.Value = datosEmpresa.ubicacion;
                    hfFotoEmpresaDefault.Value = datosEmpresa.foto;

                    string mostrarUbicacion = "mostrarUbicacion()";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarUbicacion", mostrarUbicacion, true);

                    break;


                case 2:

                    txtDescripcion.Value = datosEmpresa.descripcion;
                    txtNombre.Text = datosEmpresa.nombre;
                    txtNit.Text = datosEmpresa.nit;
                    txtDireccion.Text = datosEmpresa.direccion;
                    txtTelefono1.Text = datosEmpresa.telefono1;
                    txtCorreo.Text = datosEmpresa.correo;
                    dpTiposNegocio.SelectedValue = datosEmpresa.idTipoNegocio.ToString();
                    dpMunicipios.SelectedValue = datosEmpresa.idMunicipio.ToString();
                    dpSector.SelectedValue = datosEmpresa.idSector.ToString();
                    cFechaConstitucion.Text = DateTime.Parse(datosEmpresa.fechaConstitucion).ToString("yyyy-MM-dd");
                    txtTelefono2.Text = datosEmpresa.telefono2;
                    txtUrl.Text = datosEmpresa.url;

                    if (int.Parse(datosEmpresa.numeroEmpleados) > 0)
                    {

                        txtNumeroEmpleados.Text = datosEmpresa.numeroEmpleados;
                        txtNumeroEmpleados.Visible = true;
                        rbSi.Checked = true;

                    }
                    else
                    {

                        rbNo.Checked = true;
                        txtNumeroEmpleados.Text = datosEmpresa.numeroEmpleados;

                    }

                    if (!string.IsNullOrEmpty(datosEmpresa.ubicacion))
                    {
                        rbSiUbicacion.Checked = true;
                        hfCoordenadas.Value = datosEmpresa.ubicacion;

                    }
                    else
                    {
                        rbNoUbicacion.Checked = true;

                    }


                    break;

            }

        }



        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string rutaArchivo = "";



            if (!string.IsNullOrEmpty(hfFotoEmpresa.Value))
            {

                if (!EsImagenBase64(hfFotoEmpresa.Value) && System.IO.File.Exists(Server.MapPath(hfFotoEmpresa.Value)))
                {

                    if (hfFotoEmpresa.Value == "~/Vista/recursos/fotosEmpresa/default.png")
                    {

                        if (hfFotoEmpresaDefault.Value == "~/Vista/recursos/fotosEmpresa/default.png")
                        {
                            rutaArchivo = hfFotoEmpresa.Value;

                        }
                        else
                        {

                            string rutaArchivoEliminar = Server.MapPath(hfFotoEmpresaDefault.Value);
                            System.IO.File.Delete(rutaArchivoEliminar);
                            rutaArchivo = hfFotoEmpresa.Value;

                        }



                    }
                    else
                    {
                        rutaArchivo = hfFotoEmpresa.Value;
                    }

                }
                else
                {
                    try
                    {
                        if (hfFotoEmpresaDefault.Value != "~/Vista/recursos/fotosEmpresa/default.png")
                        {
                            string rutaCompletaFotoDefault = Server.MapPath(hfFotoEmpresaDefault.Value);
                            System.IO.File.Delete(rutaCompletaFotoDefault);
                        }


                        byte[] imageBytes = Convert.FromBase64String(hfFotoEmpresa.Value);

                        // Genera un nombre aleatorio para el archivo
                        Random idFinalAleatorio = new Random();
                        string fileName = "logoEmpresa" + idFinalAleatorio.Next(1000, 9999).ToString() + ".png";

                        // Define la ruta relativa y completa
                        string rutaR = "~/Vista/recursos/fotosEmpresa/" + fileName;
                        string rutaComp = Server.MapPath(rutaR);

                        // Guarda los bytes como un archivo de imagen en la ruta completa
                        System.IO.File.WriteAllBytes(rutaComp, imageBytes);
                        rutaArchivo = rutaR;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
            else
            {
                rutaArchivo = hfFotoEmpresaDefault.Value;
            }




            clEmpresaE objEmpresa = new clEmpresaE
            {
                idEmpresa = int.Parse(Session["idEmpresa"].ToString()),
                descripcion = txtDescripcion.Value,
                nombre = txtNombre.Text,
                nit = txtNit.Text,
                direccion = txtDireccion.Text,
                telefono1 = txtTelefono1.Text,
                telefono2 = txtTelefono2.Text,
                url = txtUrl.Text,
                correo = txtCorreo.Text,
                idTipoNegocio = int.Parse(dpTiposNegocio.SelectedValue),
                idMunicipio = int.Parse(dpMunicipios.SelectedValue),
                idSector = int.Parse(dpSector.SelectedValue),
                fechaConstitucion = DateTime.Parse(cFechaConstitucion.Text).ToString("yyyy-MM-dd"),
                numeroEmpleados = txtNumeroEmpleados.Text,
                ubicacion = Session["coordenadas"].ToString(),
                foto = rutaArchivo

            };

            clEmpresaL objEmpresaL = new clEmpresaL();
            if (objEmpresaL.mtdActualizarEmpresa(objEmpresa))
            {
                string modificacionExistosa = @"alertify.success('Información actualizada correctamente');";
                ScriptManager.RegisterStartupScript(this, GetType(), "modificacionExistosa", modificacionExistosa, true);

            }
            else
            {
                string modificacionFallida = @"alertify.error('Ocurrio un error al actualizar la información, intenta nuevamente.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "modificacionFallida", modificacionFallida, true);

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

        protected void accionesFoto_ServerClick(object sender, EventArgs e)
        {
            HtmlButton btnSeleccionado = (HtmlButton)sender;


            switch (btnSeleccionado.ID)
            {

                case "btnEliminarFoto":
                    hfFotoEmpresa.Value = "";
                    hfFotoEmpresa.Value = "~/Vista/recursos/fotosEmpresa/default.png";
                    imgFotoEmpresa.Src = ResolveUrl("~/Vista/recursos/fotosEmpresa/default.png");

                    ScriptManager.RegisterStartupScript(this, GetType(), "clearFileUpload", "document.getElementById('ContentBody_imgCargarFoto').value = '';", true);
                    break;

                case "btnRestaurarFoto":
                    hfFotoEmpresa.Value = "";
                    hfFotoEmpresa.Value = hfFotoEmpresaDefault.Value;
                    imgFotoEmpresa.Src = ResolveUrl(hfFotoEmpresaDefault.Value);
                    ScriptManager.RegisterStartupScript(this, GetType(), "clearFileUpload", "document.getElementById('ContentBody_imgCargarFoto').value = '';", true);
                    break;

            }

        }

    }
}