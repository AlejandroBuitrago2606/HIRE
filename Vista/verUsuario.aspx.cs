using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class verUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                int idUsuario = int.Parse(Session["idUsuarioVer"].ToString());
                if (idUsuario > 0)
                {

                    clUsuarioL objDatosUsuarioL = new clUsuarioL();
                    clUsuarioE datosUsuario = objDatosUsuarioL.mtdValidarUsuario(null, idUsuario);
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

                    clVacanteL objfiltrosL = new clVacanteL();
                    var filtros = objfiltrosL.mtdListarFiltros();


                    foreach (clMunicipioE item in filtros.Item1)
                    {

                        if (int.Parse(datosUsuario.idMunicipio) == item.idMunicipio)
                        {
                            lblMunicipio.InnerHtml = "<b>Municipio:</b>" + " " + item.nombre + ", Boyaca";
                            break;
                        }

                    }

                    hfCoordenadas.Value = datosUsuario.ubicacion.ToString();

                    string script = "mostrarUbicacion2()";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarUbicacion", script, true);



                    foreach (clCargoE item in filtros.Item4)
                    {
                        if (int.Parse(datosUsuario.idTipo) == item.idTipo)
                        {
                            lblCargoActual.InnerHtml = "<b>Cargo actual:</b>" + " " + item.cargo;
                            break;
                        }
                    }

                    hfClaveUsuario.Value = datosUsuario.contrasena.ToString();
                    hfFotoUsuarioDefault.Value = datosUsuario.foto;

                }

            }

        }

    }
}