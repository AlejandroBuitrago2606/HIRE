using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIRE.Entidades
{
    public class clSolicitudE
    {
        public int idSolicitud { get; set; }
        public int idCurriculumVitae { get; set; }
        public int idVacante { get; set; }
        public int idUsuario { get; set; }
        public string fechaEnvio { get; set; }
        public int estado { get; set; }

    }

}