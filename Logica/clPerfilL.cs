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


        public clTraerPerfilCV mtdListarCV(int idUsuario)
        {
            clPerfilD objDatosD = new clPerfilD();
            clTraerPerfilCV objPerfilCV = objDatosD.mtdListarPerfil(idUsuario);

            return objPerfilCV;

        }
    }
}