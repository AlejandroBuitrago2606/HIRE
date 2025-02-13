using HIRE.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIRE.Logica
{
    public class clSolicitudL
    {
        clSolicitudD objSolicitudD = new clSolicitudD();

        public bool mtdEvaluarSolicitud(int idSolicitud, int estado)
        {
            return (objSolicitudD.mtdEvaluarSolicitud(idSolicitud, estado));

        }


    }
}