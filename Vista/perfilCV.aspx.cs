using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
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
                foreach (clCompetenciaE objCompetencia in resultado.Item1)
                {
                    dpCompetencia.Items.Add(new ListItem(objCompetencia.descripcion, objCompetencia.idCompetencia.ToString()));

                }

                foreach (var idiomas in resultado.Item3)
                {
                    dpIdiomas.Items.Add(new ListItem(idiomas.ToString()));

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
            }
            else
            {
                txtDescripcionCV.InnerText = objDatosCV.objDatosCV.perfilProfesional;
                btnAgregarCV.Visible = false;
                domDetallesCV.Visible = true;
            }

            if (!string.IsNullOrEmpty(objDatosCV.objDatosCV.hojaVida))
            {
                hfHojaVida.Value = objDatosCV.objDatosCV.hojaVida;
                TituloModal2.InnerText = "Hoja de vida";
                txtMensaje.Visible = false;
            }
            else
            {
                TituloModal2.InnerText = "No has subido tu hoja de vida";
                txtMensaje.Visible = true;
                txtMensaje.InnerText = "Ve a la sección 'Actualizar CV'";
            }


            if (true)
            {

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
                string valor = hfSeleccionado.Value;
                hfSoporte.Value = valor;

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

            switch (accionAejecutar)
            {

                case 11:
                    clPerfilE objDatosPerfil = new clPerfilE { perfilProfesional = txtActualizarDescripcion.Value};
                    objDetallesPerfil.DatosCV = objDatosPerfil;
                    if (objPerfilL.mtdActualizarCV(accionAejecutar, objDetallesPerfil, idCV))
                    {

                        string actualizacionDetallesExitoso = "alertify.success('Perfil Actualizado'); setTimeout(function(){ window.location.href = 'perfilCV.aspx'; }, 2000);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "actualizacionDetallesExitoso", actualizacionDetallesExitoso, true);

                    }
                    else
                    {
                        string detallesCVFallido = "alertify.error('Ocurrio un error, verifica la informacion ingresada.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "detallesCVFallido", detallesCVFallido, true);
                    }

                    break;

                case 12:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                case 6:
                    break;

                case 7:
                    break;

                case 8:
                    break;
            
            }



        }

        protected void btnAbrirModalActualizarCV_ServerClick(object sender, EventArgs e)
        {
            hfIdDetalle.Value = "";
            int idCV = int.Parse(Session["idCV"].ToString());
            clPerfilL objPErfilL = new clPerfilL();
            clDetallesPerfilCV objDetalles = objPErfilL.mtdTraerDetalle(1, idCV);

            txtActualizarDescripcion.Value = objDetalles.DatosCV.perfilProfesional;
            hfIdDetalle.Value = idCV.ToString();
            divPerfilProfesional.Visible = true;
            d11.Visible = true;
            modalTitleDynamic.InnerText = "Actualizar descripción";

            string mostrarModal = @"const modal = new bootstrap.Modal(document.getElementById('modalActualizarDetalles'));
            modal.show();";
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarModal", mostrarModal, true);

        }
    }
}