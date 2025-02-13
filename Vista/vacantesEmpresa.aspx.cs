using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class indexEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                List<clFuncionE> objFunciones = new List<clFuncionE>();
                List<clRequisitoE> objRequisitos = new List<clRequisitoE>();
                List<clCompetenciaE> objCompetencias = new List<clCompetenciaE>();
                List<clNivelAcademicoE> objNivelAcademico = new List<clNivelAcademicoE>();
                Session["funciones"] = objFunciones;
                Session["requisitos"] = objRequisitos;
                Session["competencias"] = objCompetencias;
                Session["nivelesAcademicos"] = objNivelAcademico;

                domMsg.Visible = false;
                clVacanteL objDatosL = new clVacanteL();
                var resultado = objDatosL.mtdListarFiltros2();
                var filtros = objDatosL.mtdListarFiltros();


                clPerfilL objFiltrosL = new clPerfilL();
                var resultado1 = objFiltrosL.mtdListarFiltros();



                foreach (clVacanteE tipoEmpleo in resultado.Item1)
                {

                    ddlTipoEmpleo.Items.Add(new ListItem(tipoEmpleo.tipoEmpleo, tipoEmpleo.idTipoEmpleo.ToString()));

                }

                foreach (clVacanteE tipoContrato in resultado.Item2)
                {

                    ddlTipoContrato.Items.Add(new ListItem(tipoContrato.tipoContrato, tipoContrato.idTipoContrato.ToString()));

                }

                foreach (clNivelAcademicoE listaNivelAcademico in resultado1.Item2)
                {

                    dpNivelAcademico.Items.Add(new ListItem(listaNivelAcademico.nivelAcademico, listaNivelAcademico.idVacanteNivelAcademico.ToString()));

                }
                foreach (clCompetenciaE objCompetencia in resultado1.Item1)
                {
                    dpCompetencias.Items.Add(new ListItem(objCompetencia.descripcion, objCompetencia.idCompetencia.ToString()));

                }

                foreach (clMunicipioE municipio in filtros.Item1)
                {
                    ddlMunicipios.Items.Add(new ListItem(municipio.nombre, municipio.idMunicipio.ToString()));
                }


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
                tituloMsg.InnerText = "No has publicado ninguna vacante";
                domMsg.Visible = false;
                rpVacantes.Visible = true;

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

                rpVacantes.DataSource = objVacantesMostrar;
                rpVacantes.DataBind();

            }
            else
            {
                               
                tituloMsg.InnerText = "No se encontraron vacantes relacionadas";
                domMsg.Visible = true;
                rpVacantes.Visible = false;
           
            }



        }

        protected void btnAgregarVacante_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;

            if (boton.CommandName == "agregarVacante")
            {
                if (boton.ID == "btnAgregarVacante")
                {
                    clVacanteE objDatosVacante = new clVacanteE
                    {

                        titulo = txtTituloVacante.Text,
                        descripcion = txtDescripcionVacante.Text,
                        tiempoExperiencia = txtTiempoExperiencia.Text,
                        salario = txtSalarioVacante.Text,
                        jornada = txtJornadaVacante.Text,
                        horario = txtHorarioVacante.Text,
                        idiomaRequerido = txtIdiomaVacante.Text,
                        fechaInicio = DateTime.Parse(txtfechaInicioVacante.Text).ToString("yyyy-MM-dd"),
                        fechaLimite = DateTime.Parse(txtFechaLimiteVacante.Text).ToString("yyyy-MM-dd"),
                        fechaPublicacion = DateTime.Now.ToString("yyyy-MM-dd"),
                        idMunicipio = int.Parse(ddlMunicipios.SelectedValue),
                        idTipoEmpleo = int.Parse(ddlTipoEmpleo.SelectedValue),
                        idEmpresa = int.Parse(Session["idEmpresa"].ToString()),
                        idTipoContrato = int.Parse(ddlTipoContrato.SelectedValue)

                    };

                    clVacanteL objVacanteL = new clVacanteL();

                    List<clFuncionE> objFunciones = (List<clFuncionE>)Session["funciones"];
                    List<clRequisitoE> objRequisitos = (List<clRequisitoE>)Session["requisitos"];
                    List<clCompetenciaE> objCompetencias = (List<clCompetenciaE>)Session["competencias"];
                    List<clNivelAcademicoE> objNivelAcademico = (List<clNivelAcademicoE>)Session["nivelesAcademicos"];

                    bool validar = objVacanteL.mtdRegistrarVacante(objDatosVacante, objFunciones, objRequisitos, objNivelAcademico, objCompetencias);
                    if (validar)
                    {
                        string registroVacanteExitoso = "alertify.success('Vacante publicada correctamente'); setTimeout(function(){ window.location.href = '../Vista/vacantesEmpresa.aspx'; }, 900);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "registroVacanteExitoso", registroVacanteExitoso, true);
                    }
                    else
                    {
                        string registroVacanteFallido = "alert('Error al publicar la vacante, verifica la información ingresada');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "registroVacanteFallido", registroVacanteFallido, true);
                    }
                }
            }


        }

        protected void agregarDetalles_ServerClick(object sender, EventArgs e)
        {

            HtmlButton boton = (HtmlButton)sender;
            List<clFuncionE> objFunciones = (List<clFuncionE>)Session["funciones"];
            List<clRequisitoE> objRequisitos = (List<clRequisitoE>)Session["requisitos"];
            List<clCompetenciaE> objCompetencias = (List<clCompetenciaE>)Session["competencias"];
            List<clNivelAcademicoE> objNivelAcademico = (List<clNivelAcademicoE>)Session["nivelesAcademicos"];

            switch (boton.ID)
            {

                case "a1":
                    objFunciones.Add(new clFuncionE { descripcionFuncion = txtAgregarFuncionVacante.Text });
                    txtAgregarFuncionVacante.Text = "";
                    rpFuncion.DataSource = objFunciones;
                    rpFuncion.DataBind();
                    break;

                case "a2":
                    objRequisitos.Add(new clRequisitoE { descripcionRequisito = txtAgregarRequisitoVacante.Text });
                    txtAgregarRequisitoVacante.Text = "";
                    rpRequisito.DataSource = objRequisitos;
                    rpRequisito.DataBind();
                    break;

                case "a3":
                    objCompetencias.Add(new clCompetenciaE { idCompetencia = int.Parse(dpCompetencias.SelectedValue), nombre = dpCompetencias.SelectedItem.Text });
                    dpCompetencias.SelectedValue = "0";
                    rpCompetencia.DataSource = objCompetencias;
                    rpCompetencia.DataBind();
                    break;

                case "a4":
                    objNivelAcademico.Add(new clNivelAcademicoE { idNivelAcademico = int.Parse(dpNivelAcademico.SelectedValue), nivelAcademico = dpNivelAcademico.SelectedItem.Text });
                    dpNivelAcademico.SelectedValue = "0";
                    rpNivelAcademicoAgregar.DataSource = objNivelAcademico;
                    rpNivelAcademicoAgregar.DataBind();
                    break;

            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            HiddenField hfEliminar = null;

            RepeaterItem repeaterCapturado = (RepeaterItem)boton.NamingContainer;
            foreach (Control control in repeaterCapturado.Controls)
            {
                if (control is HiddenField)
                {
                    hfEliminar = (HiddenField)control;
                    break; // Salimos del bucle una vez que encontramos el HiddenField
                }

            }

            if (hfEliminar != null)
            {



                switch (hfEliminar.Value)
                {

                    case "1":
                        List<clFuncionE> funciones = (List<clFuncionE>)Session["funciones"];
                        HtmlGenericControl txtFuncion = (HtmlGenericControl)repeaterCapturado.FindControl("txtFuncion");

                        clFuncionE objEliminar1 = null;

                        foreach (clFuncionE objFuncion in funciones)
                        {

                            if (txtFuncion.InnerText.Trim() == objFuncion.descripcionFuncion)
                            {

                                objEliminar1 = objFuncion;
                                break;

                            }

                        }

                        if (objEliminar1 != null)
                        {
                            funciones.Remove(objEliminar1);
                        }

                        Session["funciones"] = funciones;

                        rpFuncion.DataSource = funciones;
                        rpFuncion.DataBind();

                        break;


                    case "2":

                        List<clRequisitoE> requisitos = (List<clRequisitoE>)Session["requisitos"];


                        HtmlGenericControl txtRequisito = (HtmlGenericControl)repeaterCapturado.FindControl("txtRequisito");


                        clRequisitoE objEliminar2 = null;



                        foreach (clRequisitoE objRequisito in requisitos)
                        {

                            if (txtRequisito.InnerText.Trim() == objRequisito.descripcionRequisito)
                            {

                                objEliminar2 = objRequisito;
                                break;

                            }

                        }

                        if (objEliminar2 != null)
                        {
                            requisitos.Remove(objEliminar2);
                        }

                        Session["requisitos"] = requisitos;

                        rpRequisito.DataSource = requisitos;
                        rpRequisito.DataBind();

                        break;


                    case "3":


                        List<clCompetenciaE> competencias = (List<clCompetenciaE>)Session["competencias"];


                        HtmlGenericControl txtCompetencia = (HtmlGenericControl)repeaterCapturado.FindControl("txtCompetencia");

                        clCompetenciaE objEliminar3 = null;

                        foreach (clCompetenciaE objCompt in competencias)
                        {

                            if (txtCompetencia.InnerText.Trim() == objCompt.nombre)
                            {

                                objEliminar3 = objCompt;

                            }

                        }

                        if (objEliminar3 != null)
                        {
                            competencias.Remove(objEliminar3);
                        }

                        Session["competencias"] = competencias;
                        rpCompetencia.DataSource = competencias;
                        rpCompetencia.DataBind();

                        break;


                    case "4":

                        List<clNivelAcademicoE> nivelesAcademicos = (List<clNivelAcademicoE>)Session["nivelesAcademicos"];


                        HtmlGenericControl txtNivelAcademico = (HtmlGenericControl)repeaterCapturado.FindControl("txtNivelAcademico");

                        clNivelAcademicoE objEliminar4 = null;

                        foreach (clNivelAcademicoE objNivelAcademico in nivelesAcademicos)
                        {

                            if (txtNivelAcademico.InnerText.Trim() == objNivelAcademico.nivelAcademico)
                            {

                                objEliminar4 = objNivelAcademico;
                                break;

                            }

                        }

                        if (objEliminar4 != null)
                        {
                            nivelesAcademicos.Remove(objEliminar4);
                        }

                        Session["nivelesAcademicos"] = nivelesAcademicos;
                        rpNivelAcademicoAgregar.DataSource = nivelesAcademicos;
                        rpNivelAcademicoAgregar.DataBind();

                        break;




                }
            }




        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            List<clFuncionE> objFunciones = new List<clFuncionE>();
            List<clRequisitoE> objRequisitos = new List<clRequisitoE>();
            List<clCompetenciaE> objCompetencias = new List<clCompetenciaE>();
            List<clNivelAcademicoE> objNivelAcademico = new List<clNivelAcademicoE>();
            Session["funciones"] = objFunciones;
            Session["requisitos"] = objRequisitos;
            Session["competencias"] = objCompetencias;
            Session["nivelesAcademicos"] = objNivelAcademico;

            string abrirModal = @"const modal = new bootstrap.Modal(document.getElementById('modalregistro')); modal.show();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", abrirModal, true);

        }

        protected void btnEliminarVacante_Click(object sender, EventArgs e)
        {
            clVacanteL objVacanteL = new clVacanteL();

            Button boton = (Button)sender;
            if (boton.CommandName == "EliminarVacante")
            {

                if (!string.IsNullOrEmpty(boton.CommandArgument))
                {

                    int idVacante = int.Parse(boton.CommandArgument);

                    if (objVacanteL.mtdEliminarVacante(idVacante))
                    {
                        string script1 = "alertify.warning('Vacante eliminada correctamente'); setTimeout(function(){window.location.href='../Vista/vacantesEmpresa.aspx'},900);";
                        ScriptManager.RegisterStartupScript(this, GetType(), "script1", script1, true);

                    }
                    else
                    {
                        string alerta = "alert('Ocurrio un error al eliminar esta vacante');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);
                    }



                }

            }


        }

    }
}