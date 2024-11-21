using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIRE.Entidades
{

   
    public class clPerfilE
    {

        public int idCurriculumVitae { get; set; }
        public string perfilProfesional { get; set; }
        public string hojaVida { get; set; }

    }


    /// //////////////////////////////////////

    public class clCompetenciaE
    {
        public int idCurriculumVitaeCompetencia { get; set; }
        public int idCompetencia { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int idCategoria { get; set; }
        public string nombreCategoria { get; set; }

    }

    public class clExperienciaE
    {
        public int idExperiencia { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string soporte { get; set; }

    }

    public class clReferenciaE
    {
        public int idReferencia { get; set; }
        public string nombreReferencia { get; set; }
        public string cargo { get; set; }
        public string nombreEmpresa { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string tipoReferencia { get; set; }
        public string relacionProfesional { get; set; }

    }

    public class clCertificacionE
    {
        public int idCertificacion { get; set; }
        public string descripcionCertificacion { get; set; }
        public string nombreInstitucion { get; set; }
        public string fechaObtencion { get; set; }



    }

    public class clProyectoDesarrolloE
    {

        public int idProyectoDesarrollo { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }

    }

    public class clIdiomaE
    {
        public int idIdioma { get; set; }
        public string nombre { get; set; }
        public string nivel { get; set; }

    }

    public class clLogroAcademicoE
    {

        public int idLogroAcademico { get; set; }
        public string tituloLogroAcademico { get; set; }
        public string nombreInstitucion { get; set; }
        public string periodoTiempo{ get; set; }
        public string ubicacion { get; set; }
        public string fechaEntrega{ get; set; }
        public string nivel { get; set; }


    }



    public class clTraerPerfilCV
    {
        public clPerfilE objDatosCV { get; set; }
        public List<clCompetenciaE> objCompetenciaCV { get; set; }
        public List<clExperienciaE> objExperienciaCV { get; set; }
        public List<clReferenciaE> objReferenciaCV { get; set; }
        public List<clCertificacionE> objCertificacionCV { get; set; }
        public List<clProyectoDesarrolloE> objProyectoDesarrolloCV { get; set; }
        public List<clIdiomaE> objIdiomaCV { get; set; }
        public List<clLogroAcademicoE> objLogroAcademicoCV { get; set; }

    }








}
