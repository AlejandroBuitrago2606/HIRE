﻿using HIRE.Entidades;
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
    public partial class solicitudesEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clVacanteL objVacante = new clVacanteL();

            var resultado = objVacante.mtdListarSolicitudesEmpresa(int.Parse(Session["idEmpresa"].ToString()));

            List<clSolicitudE> listasolicitudes = resultado.Item1;
            List<clVacanteE> listaVacantes = resultado.Item2;
            List<clSolicitudesEmpresa> objSolicitudesEmpresa = new List<clSolicitudesEmpresa>();

            if (!IsPostBack)
            {
                Session["idUsuarioVer"] = 0;
                if (listasolicitudes.Count > 0 && listaVacantes.Count > 0 && listasolicitudes.Count == listaVacantes.Count)
                {
                    domMsg.Visible = false;
                    for (int i = 0; i < listasolicitudes.Count; i++)
                    {

                        string estado = "";
                        if (listasolicitudes[i].ToString() == "0")
                        {
                            estado = "En revision";
                        }

                        objSolicitudesEmpresa.Add(new clSolicitudesEmpresa
                        {

                            titulo = listaVacantes[i].titulo.ToString(),
                            fechaEnvio = listasolicitudes[i].fechaEnvio.ToString(),
                            estado = estado,
                            idUsuario = int.Parse(listasolicitudes[i].idUsuario.ToString()),
                            idVacante = int.Parse(listaVacantes[i].idVacante.ToString()),
                            idSolicitud = int.Parse(listasolicitudes[i].idSolicitud.ToString())

                        });


                    }


                }
                else
                {

                    domMsg.Visible = true;

                }

                rpSolicitudes.DataSource = objSolicitudesEmpresa;
                rpSolicitudes.DataBind();
            }

        }


        protected void btnBuscarSolicitud_ServerClick(object sender, EventArgs e)
        {
            clVacanteL objDatos = new clVacanteL();

            int idEmpresa = int.Parse(Session["idEmpresa"].ToString());

            List<clSolicitudE> objSolicitudesEncontradas = objDatos.mtdBuscarSolicitud(0, txtBuscar.Text, 0, idEmpresa);
            List<clSolicitudesUsuario> listaMostrarSolicitudes = new List<clSolicitudesUsuario>();
            if (objSolicitudesEncontradas.Count > 0)
            {
                domMsg.Visible = false;
                tituloMsg.InnerText = "No has hecho ninguna solicitud de empleo";


                // Obtener las solicitudes y vacantes del usuario
                var objListarDatos = objDatos.mtdListarSolicitudes(0, 0, idEmpresa);
                List<clSolicitudE> listasolicitudes = objListarDatos.Item1;
                List<clVacanteE> listaVacantes = objListarDatos.Item2;

                // Usar un HashSet para mejorar la búsqueda
                var solicitudesEncontradasSet = new HashSet<int>(objSolicitudesEncontradas.Select(s => s.idSolicitud));

                // Filtrar las solicitudes y vacantes
                for (int j = 0; j < listasolicitudes.Count; j++)
                {
                    if (solicitudesEncontradasSet.Contains(listasolicitudes[j].idSolicitud))
                    {
                        // Encontrar la vacante correspondiente
                        var vacante = listaVacantes.FirstOrDefault(v => v.idVacante == listasolicitudes[j].idVacante);
                        if (vacante != null)
                        {
                            listaMostrarSolicitudes.Add(new clSolicitudesUsuario
                            {
                                titulo = vacante.titulo,
                                fechaEnvio = listasolicitudes[j].fechaEnvio,
                                idVacante = vacante.idVacante,
                                idSolicitud = listasolicitudes[j].idSolicitud
                            });
                        }
                    }
                }

                // Asignar la lista filtrada al Repeater
                rpSolicitudes.DataSource = listaMostrarSolicitudes;
                rpSolicitudes.DataBind();
            }
            else
            {

                domMsg.Visible = true;
                tituloMsg.InnerText = "No se encontraron vacantes";
                rpSolicitudes.DataSource = null;
                rpSolicitudes.DataBind();

            }




        }

        private class clSolicitudesUsuario
        {

            public int idSolicitud { get; set; }
            public int idCV { get; set; }
            public string fechaEnvio { get; set; }
            public int idUsuario { get; set; }
            public int idVacante { get; set; }
            public string titulo { get; set; }

        }



        private class clSolicitudesEmpresa
        {

            public int idSolicitud { get; set; }
            public int idCV { get; set; }
            public string fechaEnvio { get; set; }
            public int idUsuario { get; set; }
            public int idVacante { get; set; }
            public string titulo { get; set; }
            public string estado { get; set; }

        }

        protected void btnVerVacante_Click(object sender, CommandEventArgs e)
        {
            Session["idVacante"] = 0;

            int idVacante = int.Parse(e.CommandArgument.ToString());
            Session["idVacante"] = idVacante.ToString();

            if (e.CommandName == "enviarIDVacante")
            {

                clVacanteL objVacanteL = new clVacanteL();
                clDatosVacante objDatosVacante = objVacanteL.mtdTraerVacante(idVacante);

                clVacanteE objVacante = objDatosVacante.objVacante;

                txtTitulo.InnerHtml = objVacante.titulo;
                txtDescripcion.InnerHtml = objVacante.descripcion;
                txtExperienciaMinima.InnerHtml = ": " + objVacante.tiempoExperiencia;
                txtSalario.InnerHtml = ": " + objVacante.salario;
                txtJornada.InnerHtml = ": " + objVacante.jornada;
                txtHorario.InnerHtml = ": " + objVacante.horario;
                txtIdiomaRequerido.InnerHtml = ": " + objVacante.idiomaRequerido;
                txtTipoEmpleo.InnerHtml = ": " + objVacante.tipoEmpleo;
                txtTipoContrato.InnerHtml = ": " + objVacante.tipoContrato;
                txtMunicipio.InnerHtml = ": " + objVacante.municipio + ", Boyacá";

                DateTime fechaI = DateTime.Parse(objVacante.fechaInicio);
                DateTime fechaL = DateTime.Parse(objVacante.fechaLimite);
                DateTime fechaPub = DateTime.Parse(objVacante.fechaPublicacion);

                string fechaInicio = fechaI.ToString("yyyy-MM-dd");
                string fechaLimite = fechaL.ToString("yyyy-MM-dd");
                string fechaPublicacion = fechaPub.ToString("yyyy-MM-dd");

                txtFechaInicio.InnerHtml = ": " + fechaInicio;
                txtFechaLimite.InnerHtml = ": " + fechaLimite;
                txtFechaPublicacion.InnerHtml = ": " + fechaPublicacion;

                List<clNivelAcademicoE> objNivelAcademico = objDatosVacante.objNivelAcademico;
                rpNivelAcademico.DataSource = objNivelAcademico;
                rpNivelAcademico.DataBind();


                List<clRequisitoE> objRequisito = objDatosVacante.objRequisito;
                rpRequisitos.DataSource = objRequisito;
                rpRequisitos.DataBind();

                List<clHabilidadE> objHabilidad = objDatosVacante.objHabilidad;
                rpHabilidades.DataSource = objHabilidad;
                rpHabilidades.DataBind();

                List<clFuncionE> objFuncion = objDatosVacante.objFuncion;
                rpFunciones.DataSource = objFuncion;
                rpFunciones.DataBind();

                string abrirModal = @"const modal = new bootstrap.Modal(document.getElementById('datosVacante')); modal.show();";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", abrirModal, true);

            }

        }

        protected void btnVerDatos_Command(object sender, EventArgs e)
        {
            Session["idUsuarioVer"] = 0;

            Button btn = (Button)sender;


            if (btn.CommandName == "verDatos")
            {

                if (!string.IsNullOrEmpty(btn.CommandArgument))
                {

                    if (btn.ID == "btnVerCV")
                    {
                        Session["idUsuarioVer"] = int.Parse(btn.CommandArgument);
                        Response.Redirect("~/Vista/verCV.aspx");


                    }
                    else if (btn.ID == "btnVerUsuario")
                    {
                        Session["idUsuarioVer"] = int.Parse(btn.CommandArgument);
                        Response.Redirect("~/Vista/verUsuario.aspx");
                    }


                }


            }

        }

        protected void btnEvaluarSolicitud_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            clSolicitudL objSolicitudL = new clSolicitudL();

            if (!string.IsNullOrEmpty(btn.CommandArgument))
            {
                int idSolicitud = int.Parse(btn.CommandArgument);

                switch (btn.ID)
                {

                    case "btnSi":



                        if (objSolicitudL.mtdEvaluarSolicitud(idSolicitud, 1))
                        {
                            string evaluarSi = "alertify.success('Solicitud Evaluada.'); setTimeout(function(){ window.location.href = '../Vista/solicitudesEmpresa.aspx'; }, 900);";
                            ScriptManager.RegisterStartupScript(this, GetType(), "evaluarSi", evaluarSi, true);
                        }
                        else
                        {
                            string evaluarNo = "alert('Ocurrio un error, solicitud no evaluada.');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "evaluarNo", evaluarNo, true);
                        }



                        break;


                    case "btnNo":



                        if (objSolicitudL.mtdEvaluarSolicitud(idSolicitud, 2))
                        {
                            string evaluarSi = "alertify.success('Solicitud Evaluada.'); setTimeout(function(){ window.location.href = '../Vista/solicitudesEmpresa.aspx'; }, 900);";
                            ScriptManager.RegisterStartupScript(this, GetType(), "evaluarSi", evaluarSi, true);
                        }
                        else
                        {
                            string evaluarNo = "alert('Ocurrio un error, solicitud no evaluada.');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "evaluarNo", evaluarNo, true);
                        }



                        break;


                }

            }




        }

    }

}