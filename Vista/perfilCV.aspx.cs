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
    public partial class perfilCV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                int idUsuario = int.Parse(Session["idUsuario"].ToString());

                clPerfilL objPerfilCV = new clPerfilL();
                clTraerPerfilCV objDatosPerfil = objPerfilCV.mtdListarCV(idUsuario);


                if (objDatosPerfil != null)
                {
                    clPerfilE objPerfilDatos = objDatosPerfil.objDatosCV;
                    txtDescripcionCV.InnerHtml = objPerfilDatos.perfilProfesional.ToString();


                    List<clCompetenciaE> objCompetenciaCV = objDatosPerfil.objCompetenciaCV;
                    rpCompetencias.DataSource = objCompetenciaCV;
                    rpCompetencias.DataBind();


                    List<clExperienciaE> objExperienciaE = objDatosPerfil.objExperienciaCV;
                    rpExperiencia.DataSource = objExperienciaE;
                    rpExperiencia.DataBind();


                    List<clReferenciaE> objReferenciaCV = objDatosPerfil.objReferenciaCV;
                    rpReferencia.DataSource = objReferenciaCV;
                    rpReferencia.DataBind();


                    List<clCertificacionE> objCertificacionCV = objDatosPerfil.objCertificacionCV;
                    rpCertificaciones.DataSource = objCertificacionCV;
                    rpCertificaciones.DataBind();



                    List<clProyectoDesarrolloE> objProyectoDesarrolloCV = objDatosPerfil.objProyectoDesarrolloCV;
                    rpProyectosDesarrollo.DataSource = objProyectoDesarrolloCV;
                    rpProyectosDesarrollo.DataBind();



                    List<clIdiomaE> objIdiomaCV = objDatosPerfil.objIdiomaCV;
                    rpIdioma.DataSource = objIdiomaCV;
                    rpIdioma.DataBind();



                    List<clLogroAcademicoE> objLogroAcademico = objDatosPerfil.objLogroAcademicoCV;
                    rpLogroAcademico.DataSource = objLogroAcademico;
                    rpLogroAcademico.DataBind();
                }
                else
                {


                    txtDescripcionCV.InnerText = "";


                }




            }

        }
    }
}