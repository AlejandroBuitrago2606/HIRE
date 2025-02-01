using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class perfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            mtdTraerUsuario(1);

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

                            string obtenerUbicacion = @"obtenerUbicacion();
                            setTimeout(function(){
                            let coordenadas = document.getElementById('Content_Body_hfCoordenadas').value;
                            alert('Las coordenadas obtenidas son:' + ' ' + coordenadas); }, 2000);";
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
                    imgFotoUsuario.Src = ResolveUrl("~/Vista/recursos/imagenes/perfil.png");
                    hfFotoUsuario.Value = "~/Vista/recursos/imagenes/perfil.png";
                    ScriptManager.RegisterStartupScript(this, GetType(), "clearFileUpload", "document.getElementById('Content_Body_imgCargarFoto').value = '';", true);
                    break;

                case "btnRestaurarFoto":
                    imgFotoUsuario.Src = ResolveUrl(hfFotoUsuarioDefault.Value);
                    hfFotoUsuario.Value = hfFotoUsuarioDefault.Value;
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
                            lblMunicipio.InnerText = "<b>Municipio:</b>" + " " + item.Text + ", Boyacá";
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

                    hfClaveUsuario.Value = datosUsuario.contrasena;
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
    }
}