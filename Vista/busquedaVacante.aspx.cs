﻿using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class busqueda : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            clVacanteL objVacanteL = new clVacanteL();
            if (!IsPostBack)
            {
                Session["idVacante"] = 0;

                List<clMunicipioE> listaMunicipios = objVacanteL.mtdListarFiltros().Item1;

                foreach (clMunicipioE municipio in listaMunicipios)
                {
                    cbMunicipios.Items.Add(new ListItem(municipio.nombre, municipio.idMunicipio.ToString()));
                }



                cbContratos.DataSource = objVacanteL.mtdListarFiltros().Item2;
                cbEmpleos.DataSource = objVacanteL.mtdListarFiltros().Item3;


                cbMunicipios.DataBind();
                cbContratos.DataBind();
                cbEmpleos.DataBind();
                List<clVacanteE> objVacantes = objVacanteL.mtdBuscarVacante();
                rpVacantes.DataSource = objVacantes;
                rpVacantes.DataBind();
                txtTotalVacantes.InnerText = "N° de vacantes disponibles: " + objVacantes.Count.ToString();

                string sesion = Session["sesion"].ToString();
                if (sesion == "true")
                {
                    fila.Attributes["style"] = "margin-left: 3%;";
                    contenedorDerecho.Visible = false;
                    contenedorIzquierdo.Visible = false;
                    contenedorBusqueda.Attributes["class"] = "col-md-4";
                    contenedorRepeater.Attributes["class"] = "col-md-6";


                }



            }


        }

        protected void buscarVacante_ServerClick(object sender, EventArgs e)
        {

            string parametros = string.IsNullOrEmpty(txtParametros.Text) ? null : txtParametros.Text;

            clVacanteL objVacanteL = new clVacanteL();
            List<clVacanteE> objVacantes = objVacanteL.mtdBuscarVacante(null, parametros);
            if (objVacantes.Count.ToString() != "0")
            {
                txtTotalVacantes.InnerText = "N° de vacantes disponibles: " + objVacantes.Count.ToString();

            }
            else
            {

                txtTotalVacantes.InnerText = "No hay vacantes disponibles";
            }


            rpVacantes.DataSource = objVacantes;
            rpVacantes.DataBind();





        }

        protected void btnBuscarVacanteFiltros_ServerClick(object sender, EventArgs e)
        {




            clVacanteE objVacante = new clVacanteE
            {
                municipio = string.IsNullOrEmpty(cbMunicipios.SelectedItem.Text) ? null : cbMunicipios.SelectedItem.Text,
                tipoContrato = string.IsNullOrEmpty(cbContratos.SelectedValue) ? null : cbContratos.SelectedValue,
                tipoEmpleo = string.IsNullOrEmpty(cbEmpleos.SelectedValue) ? null : cbEmpleos.SelectedValue
            };

            clVacanteL objVacanteL = new clVacanteL();
            List<clVacanteE> objVacantes = objVacanteL.mtdBuscarVacante(objVacante);
            if (objVacantes.Count.ToString() != "0")
            {
                txtTotalVacantes.InnerText = "N° de vacantes disponibles: " + objVacantes.Count.ToString();
            
            }
            else
            {

                txtTotalVacantes.InnerText = "No hay vacantes disponibles";
            }


            rpVacantes.DataSource = objVacantes;
            rpVacantes.DataBind();

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

                string abrirModal = @"
                  $(document).ready(function () {
                  $('#datosVacante').modal('show');
                  });";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", abrirModal, true);

            }



        }

        protected void btnPostularse_ServerClick(object sender, EventArgs e)
        {

            int idUsuario = int.Parse(Session["idUsuario"].ToString());
            int idVacante = int.Parse(Session["idVacante"].ToString());
            int idCV = int.Parse(Session["idCV"].ToString());
            string fechaEnvio = DateTime.Now.ToString("yyy-MM-dd");
            
            clVacanteL objvacante = new clVacanteL();
            if (objvacante.mtdRegistrarSolicitud(idUsuario, idCV, idVacante, fechaEnvio))
            {
                string SolicitudEnviada = @"alert('Solicitud Enviada'); setTimeout(function(){ window.location.href = 'busquedaVacante.aspx';}, 1000);";
                ScriptManager.RegisterStartupScript(this, GetType(), "SolicitudEnviada", SolicitudEnviada, true);

            }
            else
            {
                string SolicitudEnviada = @"alert('Ocurrio un error intenta nuevamente.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "SolicitudEnviada", SolicitudEnviada, true);

            }

        }

        protected void btnPostulacion_Click(object sender, EventArgs e)
        {
            if (int.Parse(Session["idUsuario"].ToString()) > 0 && int.Parse(Session["idCV"].ToString()) > 0)
            {

                string abrirModal = @"
                  $(document).ready(function () {
                  $('#modalPostularse').modal('show');
                  });";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", abrirModal, true);

            }
            else
            {
                string alerta = "alert('Inicia Sesion primero');" +
                " setTimeout(function(){window.location='../Vista/login.aspx'}, 1000);";
                ClientScript.RegisterStartupScript(this.GetType(), "alertRedirect", alerta, true);
            }

        }

    }

}


