using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class solicitudesUsuario : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                clVacanteL objDatosL = new clVacanteL();
                int idUsuario = int.Parse(Session["idUsuario"].ToString());
                var objListarDatos = objDatosL.mtdListarSolicitudes(idUsuario);
                List<clSolicitudE> listasolicitudes = objListarDatos.Item1;
                List<clVacanteE> listaVacantes = objListarDatos.Item2;
                List<clSolicitudesUsuario> listaMostrarSolicitudes = new List<clSolicitudesUsuario>();



                if (listasolicitudes.Count > 0 && listaVacantes.Count > 0 && listasolicitudes.Count == listaVacantes.Count)
                {
                    domMsg.Visible = false;
                    for (int i = 0; i < listasolicitudes.Count; i++)
                    {

                        listaMostrarSolicitudes.Add(new clSolicitudesUsuario
                        {

                            titulo = listaVacantes[i].titulo.ToString(),
                            fechaEnvio = listasolicitudes[i].fechaEnvio.ToString(),
                            idVacante = int.Parse(listaVacantes[i].idVacante.ToString()),
                            idSolicitud = int.Parse(listasolicitudes[i].idSolicitud.ToString())

                        });


                    }


                }
                else
                {

                    domMsg.Visible = true;

                }


                rpSolicitudes.DataSource = listaMostrarSolicitudes;
                rpSolicitudes.DataBind();
            }

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

        private class clSolicitudesUsuario
        {

            public int idSolicitud { get; set; }
            public int idCV { get; set; }
            public string fechaEnvio { get; set; }
            public int idUsuario { get; set; }
            public int idVacante { get; set; }
            public string titulo { get; set; }

        }

        protected void btnBuscarSolicitud_ServerClick(object sender, EventArgs e)
        {
            clVacanteL objDatos = new clVacanteL();

            int idUsuario = int.Parse(Session["idUsuario"].ToString());

            List<clSolicitudE> objSolicitudesEncontradas = objDatos.mtdBuscarSolicitud(idUsuario, txtBuscar.Text);
            List<clSolicitudesUsuario> listaMostrarSolicitudes = new List<clSolicitudesUsuario>();
            if (objSolicitudesEncontradas.Count > 0)
            {
                domMsg.Visible = false;
                btnRegresar.Visible = true;
                tituloMsg.InnerText = "No has hecho ningun solicitud de empleo";


                // Obtener las solicitudes y vacantes del usuario
                var objListarDatos = objDatos.mtdListarSolicitudes(idUsuario);
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
                btnRegresar.Visible = false;
                rpSolicitudes.DataSource = null;
                rpSolicitudes.DataBind();

            }




        }

    }

}