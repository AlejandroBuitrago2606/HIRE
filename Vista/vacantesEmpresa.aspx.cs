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
    public partial class indexEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                domMsg.Visible = false;
                clVacanteL objDatosL = new clVacanteL();
                var objListarDatos = objDatosL.mtdListarVacantes(1, int.Parse(Session["idEmpresa"].ToString()), 0);

                List<clVacantesEmpresa> objVacantes = new List<clVacantesEmpresa>();

                if (objListarDatos.Item1.Count > 0)
                {
                    foreach (clVacanteE objVacante in objListarDatos.Item1)
                    {
                        int numeroPostulaciones = objDatosL.mtdListarVacantes(2, 0, objVacante.idVacante).Item2;

                        objVacantes.Add(new clVacantesEmpresa
                        {

                            fechaPublicacion = objVacante.fechaPublicacion,
                            idVacante = objVacante.idVacante,
                            titulo = objVacante.titulo,
                            numeroPostulados = numeroPostulaciones

                        });


                    }

                    rpVacantes.DataSource = objVacantes;
                    rpVacantes.DataBind();

                }
                else
                {
                    domMsg.Visible = true;
                }

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


        private class clVacantesEmpresa
        {



            public string fechaPublicacion { get; set; }
            public int idVacante { get; set; }
            public string titulo { get; set; }
            public int numeroPostulados { get; set; }

        }

        protected void btnBuscarVacante_ServerClick(object sender, EventArgs e)
        {
            clVacanteL objDatosL = new clVacanteL();
            int idEmpresa = int.Parse(Session["idEmpresa"].ToString());
            List<clVacanteE> objVacantes = objDatosL.mtdListarVacantesBusqueda(idEmpresa, txtBuscarVacante.Text);
            List<clVacantesEmpresa> objVacantesMostrar = new List<clVacantesEmpresa>();

            if (objVacantes.Count > 0)
            {

                domMsg.Visible = false;
                btnPublicar.Visible = true;
                tituloMsg.InnerText = "No has publicado ninguna vacante";
                tituloMsg.Visible = false;

                foreach (clVacanteE objVacante in objVacantes)
                {
                    int numeroPostulaciones = objDatosL.mtdListarVacantes(2, 0, objVacante.idVacante).Item2;

                    objVacantesMostrar.Add(new clVacantesEmpresa
                    {

                        fechaPublicacion = objVacante.fechaPublicacion,
                        idVacante = objVacante.idVacante,
                        titulo = objVacante.titulo,
                        numeroPostulados = numeroPostulaciones

                    });

                }
            }
            else
            {
                domMsg.Visible = true;
                btnPublicar.Visible = false;
                tituloMsg.InnerText = "No se encontraron vacantes relacionadas";
                tituloMsg.Visible = true;

            }



        }
    }
}