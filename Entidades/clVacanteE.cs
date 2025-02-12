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
        public int idEmpresa { get; set; }
        public string fechaPublicacion { get; set; }
        public string tipoEmpleo { get; set; }
        public string tipoContrato { get; set; }
        public string municipio { get; set; }
        public int idTipoEmpleo { get; set; }
        public int idTipoContrato { get; set; }
        public int idMunicipio { get; set; }

    }

    public class clNivelAcademicoE
    {
        public int idVacanteNivelAcademico { get; set; }
        public int idNivelAcademico { get; set; }
        public string nivelAcademico { get; set; }

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
        public string nombreCompetencia { get; set; }
        public string descripcion { get; set; }



    }


    public class clDatosVacante
    {

        public clVacanteE objVacante { get; set; }
        public List<clNivelAcademicoE> objNivelAcademico { get; set; }
        public List<clFuncionE> objFuncion { get; set; }
        public List<clRequisitoE> objRequisito { get; set; }
        public List<clHabilidadE> objHabilidad { get; set; }


    }

}