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
    public partial class verCV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clPerfilL objPErfilL = new clPerfilL();


            if (!IsPostBack)
            {


                int idUsuario = (int)Session["idUsuarioVer"];

                if (idUsuario > 0)
                {

                    clTraerPerfilCV objDatosCV = objPErfilL.mtdListarCV(idUsuario);

                    rpExperiencia.DataSource = objDatosCV.objExperienciaCV;
                    rpExperiencia.DataBind();
                    rpProyectoDesarrollo.DataSource = objDatosCV.objProyectoDesarrolloCV;
                    rpProyectoDesarrollo.DataBind();
                    rpLogroAcademico.DataSource = objDatosCV.objLogroAcademicoCV;
                    rpLogroAcademico.DataBind();
                    rpCertificacion.DataSource = objDatosCV.objCertificacionCV;
                    rpCertificacion.DataBind();
                    rpCompetencia.DataSource = objDatosCV.objCompetenciaCV;
                    rpCompetencia.DataBind();
                    rpReferencia.DataSource = objDatosCV.objReferenciaCV;
                    rpReferencia.DataBind();
                    rpIdioma.DataSource = objDatosCV.objIdiomaCV;
                    rpIdioma.DataBind();


                    clUsuarioL objDatosUsuarioL = new clUsuarioL();
                    clUsuarioE datosUsuario = objDatosUsuarioL.mtdValidarUsuario(null, int.Parse(Session["idUsuarioVer"].ToString()));
                    txtNombreUsuario.InnerText = datosUsuario.nombre + " " + datosUsuario.apellido;
                    txtTelefono.InnerText = datosUsuario.telefono;
                    txtCorreo.InnerText = datosUsuario.correo;
                    txtDireccion.InnerText = datosUsuario.direccion;
                    imgFotoPerfil.Src = ResolveUrl(datosUsuario.foto);
                    hfHojaVida.Value = objDatosCV.objDatosCV.hojaVida;

                    clVacanteL objfiltrosL = new clVacanteL();
                    var filtros = objfiltrosL.mtdListarFiltros();

                    List<clCargoE> objCargo = filtros.Item4;

                    foreach (clCargoE cargo in objCargo)
                    {
                        if (int.Parse(datosUsuario.idTipo) == cargo.idTipo)
                        {
                            txtCargo.InnerText = cargo.cargo;
                        }

                    }
                    if (objDatosCV.objDatosCV.perfilProfesional == "Agrega información a tu perfil profesional")
                    {
                        txtDescripcionCV.InnerText = "El usuario no agrego detalles a su CV";
                        domDetallesCV.Visible = false;
                    }
                    else
                    {
                        txtDescripcionCV.InnerText = objDatosCV.objDatosCV.perfilProfesional;
                        domDetallesCV.Visible = true;

                    }


                }


            }

        }





        protected void rpExperiencia_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "abrirSoporte")
            {
                HiddenField hfSeleccionado = (HiddenField)e.Item.FindControl("hfRutaSoporte");
                hfSoporte.Value = hfSeleccionado.Value;

                string mostrarPDF = @"mostrarSoportePDF2();";
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarPDF", mostrarPDF, true);
            }

        }

    }
}