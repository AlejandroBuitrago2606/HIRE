using HIRE.Datos;
using HIRE.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIRE.Logica
{
    public class clPerfilL
    {

        clPerfilD objDatosD = new clPerfilD();
        public clTraerPerfilCV mtdListarCV(int idUsuario)
        {

            clTraerPerfilCV objPerfilCV = objDatosD.mtdListarPerfil(idUsuario);

            return objPerfilCV;

        }

        public bool mtdRegistrarCvL(int opcion, clDetallesPerfilCV objDatosCV, int idCV = 0)
        {
            return (objDatosD.mtdRegistrarCvD(opcion, objDatosCV, idCV));
        }

    }
}