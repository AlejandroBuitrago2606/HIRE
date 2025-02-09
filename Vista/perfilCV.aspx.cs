using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class perfilCV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clPerfilL objPErfilL = new clPerfilL();
            clTraerPerfilCV objDatosCV = objPErfilL.mtdListarCV(int.Parse(Session["idUsuario"].ToString()));
            Session["idCV"] = objDatosCV.objDatosCV.idCurriculumVitae;
            if (!IsPostBack)
            {
                txtNuevaDescripcion.Text = "";
                Session["registro"] = false;

                clPerfilL objFiltrosL = new clPerfilL();
                var resultado = objFiltrosL.mtdListarFiltros();

                foreach (clNivelAcademicoE listaNivelAcademico in resultado.Item2)
                {

                    dpNivelAcademico.Items.Add(new ListItem(listaNivelAcademico.nivelAcademico, listaNivelAcademico.idVacanteNivelAcademico.ToString()));

                }
                foreach (clNivelAcademicoE listaNivelAcademico in resultado.Item2)
                {

                    dpActualizarNivelAcademico.Items.Add(new ListItem(listaNivelAcademico.nivelAcademico, listaNivelAcademico.idVacanteNivelAcademico.ToString()));

                }
                foreach (clCompetenciaE objCompetencia in resultado.Item1)
                {
                    dpCompetencia.Items.Add(new ListItem(objCompetencia.descripcion, objCompetencia.idCompetencia.ToString()));

                }

                foreach (clCompetenciaE objCompetencia in resultado.Item1)
                {
                    dpActualizarCompetencia.Items.Add(new ListItem(objCompetencia.descripcion, objCompetencia.idCompetencia.ToString()));

                }

                foreach (var idiomas in resultado.Item3)
                {
                    dpIdiomas.Items.Add(new ListItem(idiomas.ToString()));

                }

                foreach (var idiomas in resultado.Item3)
                {
                    dpActualizarIdioma.Items.Add(new ListItem(idiomas.ToString()));

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

            clVacanteL objfiltrosL = new clVacanteL();
            var filtros = objfiltrosL.mtdListarFiltros();

            List<clCargoE> objCargo = filtros.Item4;


            clUsuarioL objDatosUsuarioL = new clUsuarioL();
            clUsuarioE datosUsuario = objDatosUsuarioL.mtdValidarUsuario(null, int.Parse(Session["idUsuario"].ToString()));



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
                btnMostrarHojaVida.Visible = false;
                a1.Visible = false;
                a9.Visible = false;
            }
            else
            {
                txtDescripcionCV.InnerText = objDatosCV.objDatosCV.perfilProfesional;
                btnAgregarCV.Visible = false;
                domDetallesCV.Visible = true;
                a1.Visible = true;
                a9.Visible = true;
            }

            if (!string.IsNullOrEmpty(objDatosCV.objDatosCV.hojaVida))
            {
                hfHojaVida.Value = objDatosCV.objDatosCV.hojaVida;
                txtMensaje.Visible = false;
            }
            else
            {

                txtMensaje.Visible = true;
                txtMensaje.InnerHtml = "No has subido tu hoja de vida <br /> Ve a la sección 'Actualizar CV'";
            }


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
                        objPerfilCV.hojaVida = "";

                    }

                }
                else
                {
                    objPerfilCV.hojaVida = "";
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

        protected void btnAgregarDetalles_ServerClick(object sender, EventArgs e)
        {
            int idCV = (int)Session["idCV"];


            Button button = (Button)sender;

            clDetallesPerfilCV objDetallesCV = new clDetallesPerfilCV();

            clPerfilL objPerfilL = new clPerfilL();

            switch (button.ID)
            {


                case "btnAgregarExp":

                    string rutaArchivo = "";

                    if (fuSoporteExp.HasFile)
                    {
                        string nombreSoporte = Path.GetFileName(fuSoporteExp.FileName);

                        try
                        {
                            //subir foto al servidor
                            Random idFinalAletorio = new Random();

                            string rutaRelativa = "~/Vista/recursos/soportesExp/" + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + nombreSoporte;
                            string rutaCompleta = Server.MapPath(rutaRelativa);

                            // Guardar el archivo en el servidor
                            fuSoporteExp.SaveAs(rutaCompleta);

                            rutaArchivo = rutaRelativa;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            rutaArchivo = "";

                        }

                    }
                    else
                    {
                        rutaArchivo = "";
                    }




                    clExperienciaE objDatosExp = new clExperienciaE
                    {
                        titulo = txtTituloExp.Text,
                        descripcion = txtDescripExp.Text,
                        soporte = rutaArchivo
                    };

                    objDetallesCV.ExperienciaCV = objDatosExp;

                    if (objPerfilL.mtdRegistrarCvL(7, objDetallesCV, idCV))
                    {
                        recargarRepeaters();
                        string registroDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "registroDetallesExitoso", registroDetallesExitoso, true);

                    }
                    else
                    {

                        if (objDatosExp.soporte != null)
                        {
                            string rutaCompleta = Server.MapPath(objDatosExp.soporte);

                            if (System.IO.File.Exists(rutaCompleta))
                            {
                                System.IO.File.Delete(rutaCompleta);
                            }

                        }
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);


                    }
                    break;


                case "btnAgregarProD":

                    clProyectoDesarrolloE objPRoD = new clProyectoDesarrolloE
                    {
                        titulo = txtTituloProD.Text,
                        descripcion = txtDescripcionProD.Text
                    };
                    objDetallesCV.proyectoDesarrolloCV = objPRoD;
                    if (objPerfilL.mtdRegistrarCvL(4, objDetallesCV, idCV))
                    {
                        recargarRepeaters();
                        string registroDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "registroDetallesExitoso", registroDetallesExitoso, true);
                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }

                    break;


                case "btnAgregarLogroA":

                    clLogroAcademicoE objLogroA = new clLogroAcademicoE
                    {

                        tituloLogroAcademico = txtTituloLogro.Text,
                        nombreInstitucion = txtInstitucion.Text,
                        periodoTiempo = txtPeriodoLogro.Text,
                        ubicacion = txtUbicacionlogro.Text,
                        fechaEntrega = DateTime.Parse(txtFechaEntregaLogro.Text).ToString("yyyy-MM-dd"),
                        idNivelAcademico = int.Parse(dpNivelAcademico.SelectedValue)

                    };
                    objDetallesCV.logroAcademicoCV = objLogroA;
                    if (objPerfilL.mtdRegistrarCvL(8, objDetallesCV, idCV))
                    {
                        recargarRepeaters();
                        string registroDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "registroDetallesExitoso", registroDetallesExitoso, true);
                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }

                    break;


                case "btnAgregarCertf":
                    clCertificacionE objCertf = new clCertificacionE
                    {

                        descripcionCertificacion = txtTituloCertf.Text,
                        nombreInstitucion = txtInstitutoCertf.Text,
                        fechaObtencion = DateTime.Parse(txtFechaObtencion.Text).ToString("yyyy-MM-dd")

                    };
                    objDetallesCV.certificacionCV = objCertf;
                    if (objPerfilL.mtdRegistrarCvL(3, objDetallesCV, idCV))
                    {
                        recargarRepeaters();
                        string registroDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "registroDetallesExitoso", registroDetallesExitoso, true);
                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }


                    break;


                case "btnAgregarCompt":

                    clCompetenciaE objCompt = new clCompetenciaE
                    {
                        idCompetencia = int.Parse(dpCompetencia.SelectedValue)
                    };
                    objDetallesCV.CompetenciaCV = objCompt;
                    if (objPerfilL.mtdRegistrarCvL(2, objDetallesCV, idCV))
                    {
                        recargarRepeaters();
                        string registroDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "registroDetallesExitoso", registroDetallesExitoso, true);
                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }


                    break;


                case "btnAgregarRef":
                    clReferenciaE objReferencia = new clReferenciaE
                    {

                        nombreReferencia = txtNombreRef.Text,
                        cargo = txtCargoRef.Text,
                        nombreEmpresa = txtNombreEmpresaRef.Text,
                        telefono = txtTelefonoRef.Text,
                        correo = txtCorreoRef.Text,
                        tipoReferencia = dpTipoRef.SelectedValue,
                        relacionProfesional = dpRelacionProRef.SelectedValue

                    };
                    objDetallesCV.referenciaCV = objReferencia;
                    if (objPerfilL.mtdRegistrarCvL(5, objDetallesCV, idCV))
                    {
                        recargarRepeaters();
                        string registroDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "registroDetallesExitoso", registroDetallesExitoso, true);
                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }

                    break;


                case "btnAgregarIdi":
                    clIdiomaE objIdioma = new clIdiomaE
                    {
                        nombre = dpIdiomas.SelectedItem.Text,
                        nivel = txtNivelIdi.Text
                    };
                    objDetallesCV.idiomaCV = objIdioma;
                    if (objPerfilL.mtdRegistrarCvL(6, objDetallesCV, idCV))
                    {
                        recargarRepeaters();
                        string registroDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "registroDetallesExitoso", registroDetallesExitoso, true);
                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }

                    break;

            }



        }

        protected void rpExperiencia_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "abrirSoporte")
            {
                HiddenField hfSeleccionado = (HiddenField)e.Item.FindControl("hfRutaSoporte");
                hfSoporte.Value = hfSeleccionado.Value;

                string mostrarPDF = @"mostrarSoportePDF();";
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarPDF", mostrarPDF, true);
            }

        }

        private void recargarRepeaters()
        {

            clPerfilL objPErfilL = new clPerfilL();
            clTraerPerfilCV objDatosCV = objPErfilL.mtdListarCV(int.Parse(Session["idUsuario"].ToString()));
            Session["idCV"] = objDatosCV.objDatosCV.idCurriculumVitae;

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

        protected void btnActualizarDetalles_ServerClick(object sender, EventArgs e)
        {

            Button botonSeleccionado = (Button)sender;
            int idCV = int.Parse(Session["idCV"].ToString());
            int accionAejecutar = int.Parse(botonSeleccionado.ID.Replace("d", ""));

            clPerfilL objPerfilL = new clPerfilL();
            clDetallesPerfilCV objDetallesPerfil = new clDetallesPerfilCV();
            string rutaArchivo = "";

            switch (accionAejecutar)
            {

                case 11:
                    clPerfilE objDatosPerfil = new clPerfilE { perfilProfesional = txtActualizarDescripcion.Value };
                    objDetallesPerfil.DatosCV = objDatosPerfil;
                    if (objPerfilL.mtdActualizarCV(accionAejecutar, objDetallesPerfil, idCV))
                    {

                        string actualizacionDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "actualizacionDetallesExitoso", actualizacionDetallesExitoso, true);

                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }

                    break;

                case 12:




                    if (fuUrlArchivo.HasFile)
                    {
                        string nombreSoporte = Path.GetFileName(fuUrlArchivo.FileName);

                        try
                        {
                            if (!string.IsNullOrEmpty(hfHojaVida.Value))
                            {

                                string rutaArchivoEliminar = Server.MapPath(hfHojaVida.Value);

                                if (System.IO.File.Exists(rutaArchivoEliminar))
                                {
                                    System.IO.File.Delete(rutaArchivoEliminar);
                                }

                            }

                            //subir foto al servidor
                            Random idFinalAletorio = new Random();

                            string rutaRelativa = "~/Vista/recursos/hv-PDF/" + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + nombreSoporte;
                            string rutaCompleta = Server.MapPath(rutaRelativa);

                            // Guardar el archivo en el servidor
                            fuUrlArchivo.SaveAs(rutaCompleta);

                            rutaArchivo = rutaRelativa;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                    else
                    {
                        rutaArchivo = "";
                    }

                    clPerfilE objDatosPerfilHV = new clPerfilE { hojaVida = rutaArchivo };
                    objDetallesPerfil.DatosCV = objDatosPerfilHV;
                    if (objPerfilL.mtdActualizarCV(accionAejecutar, objDetallesPerfil, idCV))
                    {

                        string actualizacionDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "actualizacionDetallesExitoso", actualizacionDetallesExitoso, true);

                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }


                    break;

                case 2:

                    clCompetenciaE objCompt = new clCompetenciaE
                    {
                        idCompetencia = int.Parse(dpActualizarCompetencia.SelectedValue),
                        idCurriculumVitaeCompetencia = int.Parse(hfIdDetalle.Value),
                    };
                    objDetallesPerfil.CompetenciaCV = objCompt;
                    if (objPerfilL.mtdActualizarCV(accionAejecutar, objDetallesPerfil, idCV))
                    {
                        string actualizacionDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "actualizacionDetallesExitoso", actualizacionDetallesExitoso, true);
                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }

                    break;

                case 3:

                    clCertificacionE objCertf = new clCertificacionE
                    {
                        idCertificacion = int.Parse(hfIdDetalle.Value),
                        descripcionCertificacion = txtActualizarDescripcionCertificacion.Value,
                        nombreInstitucion = txtActualizarEntidad.Text,
                        fechaObtencion = DateTime.Parse(txtActualizarFecha.Text).ToString("yyyy-MM-dd")
                    };
                    objDetallesPerfil.certificacionCV = objCertf;
                    if (objPerfilL.mtdActualizarCV(accionAejecutar, objDetallesPerfil))
                    {
                        string actualizacionDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "actualizacionDetallesExitoso", actualizacionDetallesExitoso, true);
                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }

                    break;

                case 4:

                    clProyectoDesarrolloE objProD = new clProyectoDesarrolloE
                    {
                        idProyectoDesarrollo = int.Parse(hfIdDetalle.Value),
                        titulo = txtActualizarTitulo.Text,
                        descripcion = txtActualizarDescripcionProyecto.Value
                    };
                    objDetallesPerfil.proyectoDesarrolloCV = objProD;
                    if (objPerfilL.mtdActualizarCV(accionAejecutar, objDetallesPerfil))
                    {
                        string actualizacionDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "actualizacionDetallesExitoso", actualizacionDetallesExitoso, true);
                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }

                    break;

                case 5:

                    clReferenciaE objRef = new clReferenciaE
                    {

                        idReferencia = int.Parse(hfIdDetalle.Value),
                        nombreReferencia = txtActualizarNombre.Text,
                        cargo = txtActualizarCargo.Text,
                        nombreEmpresa = txtActualizarEmpresaRef.Text,
                        telefono = txtActualizarTelefono.Text,
                        correo = txtActualizarCorreo.Text,
                        tipoReferencia = dpActualizarTipoRef.SelectedValue,
                        relacionProfesional = dpActualizarRelacionPro.SelectedValue

                    };
                    objDetallesPerfil.referenciaCV = objRef;
                    if (objPerfilL.mtdActualizarCV(accionAejecutar, objDetallesPerfil))
                    {
                        string actualizacionDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "actualizacionDetallesExitoso", actualizacionDetallesExitoso, true);
                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }

                    break;

                case 6:
                    clIdiomaE objIdioma = new clIdiomaE
                    {
                        idIdioma = int.Parse(hfIdDetalle.Value),
                        nombre = dpActualizarIdioma.SelectedItem.Text,
                        nivel = txtActualizarNivel.Text
                    };
                    objDetallesPerfil.idiomaCV = objIdioma;

                    if (objPerfilL.mtdActualizarCV(accionAejecutar, objDetallesPerfil))
                    {
                        string actualizacionDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "actualizacionDetallesExitoso", actualizacionDetallesExitoso, true);
                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }

                    break;

                case 7:

                    if (fuUrlArchivoExperiencia.HasFile)
                    {
                        string nombreSoporte = Path.GetFileName(fuUrlArchivoExperiencia.FileName);

                        try
                        {
                            if (!string.IsNullOrEmpty(hfSoporte.Value))
                            {

                                string rutaArchivoEliminar = Server.MapPath(hfSoporte.Value);

                                if (System.IO.File.Exists(rutaArchivoEliminar))
                                {
                                    System.IO.File.Delete(rutaArchivoEliminar);
                                }

                            }

                            //subir foto al servidor
                            Random idFinalAletorio = new Random();

                            string rutaRelativa = "~/Vista/recursos/hv-PDF/" + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + idFinalAletorio.Next(1, 10).ToString() + nombreSoporte;
                            string rutaCompleta = Server.MapPath(rutaRelativa);

                            // Guardar el archivo en el servidor
                            fuUrlArchivoExperiencia.SaveAs(rutaCompleta);

                            rutaArchivo = rutaRelativa;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(hfSoporte.Value))
                        {
                            rutaArchivo = hfSoporte.Value;
                        }

                    }

                    clExperienciaE objExperiencia = new clExperienciaE
                    {
                        idExperiencia = int.Parse(hfIdDetalle.Value),
                        titulo = txtActualizarTituloExperiencia.Text,
                        descripcion = txtActualizarDescripcionExperiencia.Value,
                        soporte = rutaArchivo
                    };
                    objDetallesPerfil.ExperienciaCV = objExperiencia;

                    if (objPerfilL.mtdActualizarCV(accionAejecutar, objDetallesPerfil))
                    {
                        string actualizacionDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "actualizacionDetallesExitoso", actualizacionDetallesExitoso, true);
                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }

                    break;

                case 8:

                    clLogroAcademicoE objLogroAcademico = new clLogroAcademicoE
                    {

                        idLogroAcademico = int.Parse(hfIdDetalle.Value),
                        tituloLogroAcademico = txtActualizarTituloLogro.Text,
                        nombreInstitucion = txtActualizarEntidadLogro.Text,
                        periodoTiempo = txtActualizarPeriodoLogro.Text,
                        ubicacion = txtActualizarUbicacionLogro.Text,
                        fechaEntrega = DateTime.Parse(txtActualizarFechaLogro.Text).ToString("yyyy-MM-dd"),
                        idNivelAcademico = int.Parse(dpActualizarNivelAcademico.SelectedValue)
                    };
                    objDetallesPerfil.logroAcademicoCV = objLogroAcademico;

                    if (objPerfilL.mtdActualizarCV(accionAejecutar, objDetallesPerfil))
                    {
                        string actualizacionDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 1000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "actualizacionDetallesExitoso", actualizacionDetallesExitoso, true);
                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }

                    break;

            }

        }

        protected void btnAbrirModalActualizarCV_ServerClick(object sender, EventArgs e)
        {

            hfIdDetalle.Value = "";
            hfSoporte.Value = "";
            mtdRestaurarDivs();
            int idCV = int.Parse(Session["idCV"].ToString());
            clPerfilL objPErfilL = new clPerfilL();
            clDetallesPerfilCV objDetalles = new clDetallesPerfilCV();
            string mostrarModal = "";

            Button boton = (Button)sender;

            int opcion = int.Parse(boton.ID.Replace("a", ""));

            if (opcion == 1)
            {
                objDetalles = objPErfilL.mtdTraerDetalle(opcion, idCV);

                txtActualizarDescripcion.Value = objDetalles.DatosCV.perfilProfesional;
                hfIdDetalle.Value = idCV.ToString();
                divPerfilProfesional.Visible = true;
                d11.Visible = true;
                modalTitleDynamic.InnerText = "Actualizar descripción";
                mostrarModal = @"const modal = new bootstrap.Modal(document.getElementById('modalActualizarDetalles'));
                    modal.show();";
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModal", mostrarModal, true);
            }
            else if (opcion == 9)
            {
                divHojadeVida.Visible = true;
                d12.Visible = true;
                hfIdDetalle.Value = idCV.ToString();
                modalTitleDynamic.InnerText = "Actualizar hoja de vida";
                mostrarModal = @"const modal = new bootstrap.Modal(document.getElementById('modalActualizarDetalles'));
                modal.show();";
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModal", mostrarModal, true);
            }
            else
            {
                RepeaterItem item = (RepeaterItem)boton.NamingContainer;
                switch (opcion)
                {


                    case 2:

                        HiddenField hfIDcvc = (HiddenField)item.FindControl("hfIDcvc");

                        if (!string.IsNullOrEmpty(hfIDcvc.Value))
                        {
                            objDetalles = objPErfilL.mtdTraerDetalle(opcion, int.Parse(hfIDcvc.Value));
                            hfIdDetalle.Value = hfIDcvc.Value;
                            dpActualizarCompetencia.SelectedValue = objDetalles.CompetenciaCV.idCompetencia.ToString();
                            modalTitleDynamic.InnerText = "Cambiar competencia";
                            d2.Visible = true;
                            divRegistroCompetencia.Visible = true;

                            mostrarModal = @"const modal = new bootstrap.Modal(document.getElementById('modalActualizarDetalles'));
                            modal.show();";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModal", mostrarModal, true);
                        }
                        break;

                    case 3:

                        HiddenField hfIDCertf = (HiddenField)item.FindControl("hfIDCertificacion");
                        if (!string.IsNullOrEmpty(hfIDCertf.Value))
                        {
                            objDetalles = objPErfilL.mtdTraerDetalle(opcion, int.Parse(hfIDCertf.Value));
                            clCertificacionE objCertificacion = objDetalles.certificacionCV;
                            txtActualizarDescripcionCertificacion.Value = objCertificacion.descripcionCertificacion;
                            txtActualizarEntidad.Text = objCertificacion.nombreInstitucion;
                            txtActualizarFecha.Text = DateTime.Parse(objCertificacion.fechaObtencion).ToString("yyyy-MM-dd");
                            hfIdDetalle.Value = hfIDCertf.Value;
                            modalTitleDynamic.InnerText = "Actualizar certificación";
                            d3.Visible = true;
                            divCertificacion.Visible = true;

                            mostrarModal = @"const modal = new bootstrap.Modal(document.getElementById('modalActualizarDetalles'));
                            modal.show();";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModal", mostrarModal, true);

                        }
                        break;

                    case 4:
                        HiddenField hfIDProyectoD = (HiddenField)item.FindControl("hfIDProD");
                        if (!string.IsNullOrEmpty(hfIDProyectoD.Value))
                        {
                            objDetalles = objPErfilL.mtdTraerDetalle(opcion, int.Parse(hfIDProyectoD.Value));
                            hfIdDetalle.Value = hfIDProyectoD.Value;
                            txtActualizarTitulo.Text = objDetalles.proyectoDesarrolloCV.titulo;
                            txtActualizarDescripcionProyecto.Value = objDetalles.proyectoDesarrolloCV.descripcion;
                            modalTitleDynamic.InnerText = "Actualizar proyecto de desarrollo";
                            d4.Visible = true;
                            divProyectoDesarrollo.Visible = true;

                            mostrarModal = @"const modal = new bootstrap.Modal(document.getElementById('modalActualizarDetalles'));
                            modal.show();";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModal", mostrarModal, true);
                        }
                        break;

                    case 5:

                        HiddenField hfIDRef = (HiddenField)item.FindControl("hfIDReferencia");
                        if (!string.IsNullOrEmpty(hfIDRef.Value))
                        {
                            objDetalles = objPErfilL.mtdTraerDetalle(opcion, int.Parse(hfIDRef.Value));
                            hfIdDetalle.Value = hfIDRef.Value;
                            txtActualizarNombre.Text = objDetalles.referenciaCV.nombreReferencia;
                            txtActualizarCargo.Text = objDetalles.referenciaCV.cargo;
                            txtActualizarEmpresaRef.Text = objDetalles.referenciaCV.nombreEmpresa;
                            txtActualizarTelefono.Text = objDetalles.referenciaCV.telefono;
                            txtActualizarCorreo.Text = objDetalles.referenciaCV.correo;
                            dpActualizarTipoRef.SelectedValue = objDetalles.referenciaCV.tipoReferencia;
                            dpActualizarRelacionPro.SelectedValue = objDetalles.referenciaCV.relacionProfesional;
                            modalTitleDynamic.InnerText = "Actualizar referencia";
                            d5.Visible = true;
                            divReferencia.Visible = true;
                            mostrarModal = @"const modal = new bootstrap.Modal(document.getElementById('modalActualizarDetalles'));
                            modal.show();";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModal", mostrarModal, true);


                        }
                        break;

                    case 6:

                        HiddenField hfIDidi = (HiddenField)item.FindControl("hfIDidioma");
                        if (!string.IsNullOrEmpty(hfIDidi.Value))
                        {
                            objDetalles = objPErfilL.mtdTraerDetalle(opcion, int.Parse(hfIDidi.Value));
                            hfIdDetalle.Value = hfIDidi.Value;
                            dpActualizarIdioma.SelectedValue = objDetalles.idiomaCV.nombre;
                            txtActualizarNivel.Text = objDetalles.idiomaCV.nivel;
                            modalTitleDynamic.InnerText = "Actualizar idioma";
                            d6.Visible = true;
                            divIdioma.Visible = true;
                            mostrarModal = @"const modal = new bootstrap.Modal(document.getElementById('modalActualizarDetalles'));
                            modal.show();";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModal", mostrarModal, true);

                        }
                        break;

                    case 7:

                        HiddenField hfIDExp = (HiddenField)item.FindControl("hfIDExperiencia");
                        if (!string.IsNullOrEmpty(hfIDExp.Value))
                        {
                            objDetalles = objPErfilL.mtdTraerDetalle(opcion, int.Parse(hfIDExp.Value));
                            hfIdDetalle.Value = hfIDExp.Value;
                            txtActualizarTituloExperiencia.Text = objDetalles.ExperienciaCV.titulo;
                            txtActualizarDescripcionExperiencia.Value = objDetalles.ExperienciaCV.descripcion;
                            hfSoporte.Value = objDetalles.ExperienciaCV.soporte;
                            modalTitleDynamic.InnerText = "Actualizar experiencia";
                            d7.Visible = true;
                            divExperiencia.Visible = true;

                            mostrarModal = @"const modal = new bootstrap.Modal(document.getElementById('modalActualizarDetalles'));
                            modal.show();";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModal", mostrarModal, true);
                        }


                        break;

                    case 8:
                        HiddenField hfIDLogroA = (HiddenField)item.FindControl("hfIDlogroAcademico");
                        if (!string.IsNullOrEmpty(hfIDLogroA.Value))
                        {
                            objDetalles = objPErfilL.mtdTraerDetalle(opcion, int.Parse(hfIDLogroA.Value));
                            hfIdDetalle.Value = hfIDLogroA.Value;
                            txtActualizarTituloLogro.Text = objDetalles.logroAcademicoCV.tituloLogroAcademico;
                            txtActualizarEntidadLogro.Text = objDetalles.logroAcademicoCV.nombreInstitucion;
                            txtActualizarPeriodoLogro.Text = objDetalles.logroAcademicoCV.periodoTiempo;
                            txtActualizarUbicacionLogro.Text = objDetalles.logroAcademicoCV.ubicacion;
                            txtActualizarFechaLogro.Text = DateTime.Parse(objDetalles.logroAcademicoCV.fechaEntrega).ToString("yyyy-MM-dd");
                            dpActualizarNivelAcademico.SelectedValue = objDetalles.logroAcademicoCV.idNivelAcademico.ToString();
                            modalTitleDynamic.InnerText = "Actualizar logro academico";
                            d8.Visible = true;
                            divLogroAcademico.Visible = true;
                            mostrarModal = @"const modal = new bootstrap.Modal(document.getElementById('modalActualizarDetalles'));
                            modal.show();";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModal", mostrarModal, true);

                        }

                        break;

                }

            }

        }

        private void mtdRestaurarDivs()
        {
            divCertificacion.Visible = false;
            divExperiencia.Visible = false;
            divHojadeVida.Visible = false;
            divIdioma.Visible = false;
            divLogroAcademico.Visible = false;
            divPerfilProfesional.Visible = false;
            divReferencia.Visible = false;
            divRegistroCompetencia.Visible = false;
            divProyectoDesarrollo.Visible = false;
            d11.Visible = false;
            d12.Visible = false;
            d2.Visible = false;
            d3.Visible = false;
            d4.Visible = false;
            d5.Visible = false;
            d6.Visible = false;
            d7.Visible = false;
            d8.Visible = false;

        }

    }

}

