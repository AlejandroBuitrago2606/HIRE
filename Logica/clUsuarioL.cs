using HIRE.Datos;
using HIRE.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace HIRE.Logica
{
    public class clUsuarioL
    {

        public clUsuarioE mtdValidarUsuario(clUsuarioE objUsuario, int idUsuario)
        {
            clUsuarioE objDatosUsuario = new clUsuarioE();
            clUsuarioD objUsuarioD = new clUsuarioD();

            if (objUsuario == null)
            {
                objDatosUsuario = objUsuarioD.mtdTraerUsuario(idUsuario);

            }
            else
            {

                objDatosUsuario = objUsuarioD.mtdValidarUsuario(objUsuario, idUsuario);


            }
            return objDatosUsuario;

        }


    }
}