using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIRE.Entidades
{
    public class clVacanteE
    {

        public int idVacante { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string tiempoExperiencia { get; set; }
        public string salario { get; set; }
        public string jornada { get; set; }
        public string horario { get; set; }
        public string idiomaRequerido { get; set; }
        public string fechaInicio { get; set; }
        public string fechaLimite { get; set; }
        public string fechaPublicacion { get; set; }
        public string tipoEmpleo { get; set; }
        public string tipoContrato { get; set; }
        public string municipio { get; set; }
        public string idTipoEmpleo { get; set; }
        public string idTipoContrato { get; set; }
        public string idMunicipio { get; set; }

    }

    public class clNivelAcademicoE
    {
        public int idVacanteNivelAcademico { get; set; }
        public int nivelAcademico { get; set; }

    }

    public class clFuncionE
    {
        public int idFuncion { get; set; }
        public string descripcionFuncion { get; set; }
    }


    public class clRequisitoE
    {
        public int idRequisito { get; set; }
        public string descripcionRequisito { get; set; }

    }


    public class clHabilidadE
    {
        public int idCategoria { get; set; }
        public int idCompetenciaVacante { get; set; }
        public int nombreCompetencia { get; set; }
        public int descripcion { get; set; }



    }


    public class clDatosVacante
    {

        public List<clVacanteE> ClVacante { get; set; }
        public List<clNivelAcademicoE> ClNivelAcademico { get; set; }
        public List<clFuncionE> ClFuncion { get; set; }
        public List<clRequisitoE> ClRequisito { get; set; }
        public List<clHabilidadE> ClHabilidad { get; set; }


    }

}