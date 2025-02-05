using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class perfilCV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNuevaDescripcion.Text = "";
                Session["registro"] = false;
            }

            clVacanteL objfiltrosL = new clVacanteL();
            var filtros = objfiltrosL.mtdListarFiltros();

            List<clCargoE> objCargo = filtros.Item4;


            clUsuarioL objDatosUsuarioL = new clUsuarioL();
            clUsuarioE datosUsuario = objDatosUsuarioL.mtdValidarUsuario(null, int.Parse(Session["idUsuario"].ToString()));

            clPerfilL objPErfilL = new clPerfilL();
            clTraerPerfilCV objDatosCV = objPErfilL.mtdListarCV(int.Parse(Session["idUsuario"].ToString()));
            Session["idCV"] = objDatosCV.objDatosCV.idCurriculumVitae;

            txtNombreUsuario.InnerText = datosUsuario.nombre + " " + datosUsuario.apellido;

            foreach (clCargoE cargo in objCargo)
            {
                if (int.Parse(datosUsuario.idTipo) == cargo.idTipo)
                {
                    txtCargo.InnerText = cargo.cargo;
                }

            }

            txtTelefono.InnerText = datosUsuario.telefono;
            txtCorreo.InnerText = datosUsuario.correo;
            txtDireccion.InnerText = datosUsuario.direccion;
            imgFotoPerfil.Src = ResolveUrl(datosUsuario.foto);

            if (objDatosCV.objDatosCV.perfilProfesional == "Agrega información a tu perfil profesional")
            {
                txtDescripcionCV.InnerText = objDatosCV.objDatosCV.perfilProfesional;
                domDetallesCV.Visible = false;
                btnAgregarCV.Visible = true;
            }
            else
            {
                txtDescripcionCV.InnerText = objDatosCV.objDatosCV.perfilProfesional;
                btnAgregarCV.Visible = false;
                domDetallesCV.Visible = true;
            }


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

        }

        protected void btnAgregarCV_ServerClick(object sender, EventArgs e)
        {
            if ((bool)Session["registro"] == false)
            {
                clPerfilL objDatosL = new clPerfilL();
                clDetallesPerfilCV objDetallesCV = new clDetallesPerfilCV();
                clPerfilE objPerfilCV = new clPerfilE();
                objPerfilCV.perfilProfesional = txtNuevaDescripcion.Text;


                if (cargarDocPDF.HasFile)
                {
                    string nombrePDF = Path.GetFileName(cargarDocPDF.FileName);

                    try
                    {
                        //subir foto al servidor
                        Random idFinalAletorio = new Random();

                        string rutaRelativa = "~/Vista/recursos/hv-PDF/" + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + nombrePDF;
                        string rutaCompleta = Server.MapPath(rutaRelativa);

                        // Guardar el archivo en el servidor
                        cargarDocPDF.SaveAs(rutaCompleta);

                        objPerfilCV.hojaVida = rutaRelativa;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        objPerfilCV.hojaVida = null;

                    }

                }
                else
                {
                    objPerfilCV.hojaVida = null;
                }

                objPerfilCV.idUsuario = int.Parse(Session["idUsuario"].ToString());
                objDetallesCV.DatosCV = objPerfilCV;

                clPerfilL objPErfilL = new clPerfilL();
                clTraerPerfilCV objDatosCV = objPErfilL.mtdListarCV(int.Parse(Session["idUsuario"].ToString()));
                if (objDatosCV.objDatosCV.perfilProfesional == "Agrega información a tu perfil profesional")
                {
                    if (objDatosL.mtdRegistrarCvL(1, objDetallesCV))
                    {
                        Session["registro"] = true;
                        string registroCVExitoso = "alertify.success('Has creado tu perfil profesional.'); setTimeout(function(){ location.reload(true); }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "registroCVExitoso", registroCVExitoso, true);

                    }
                    else
                    {

                        if (objPerfilCV.hojaVida != null)
                        {
                            string rutaCompleta = Server.MapPath(objPerfilCV.hojaVida);

                            if (System.IO.File.Exists(rutaCompleta))
                            {
                                System.IO.File.Delete(rutaCompleta);
                            }

                        }


                        string registroCVFallido = "alert('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "registroCVFallido", registroCVFallido, true);

                    }

                }
                else
                {

                    if (objPerfilCV.hojaVida != null)
                    {
                        string rutaCompleta = Server.MapPath(objPerfilCV.hojaVida);

                        if (System.IO.File.Exists(rutaCompleta))
                        {
                            System.IO.File.Delete(rutaCompleta);
                        }

                    }


                } 
            }

        }
    }
}