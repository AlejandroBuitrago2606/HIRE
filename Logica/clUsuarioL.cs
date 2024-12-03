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
        clUsuarioD objUsuarioD = new clUsuarioD();
        public clUsuarioE mtdValidarUsuario(clUsuarioE objUsuario, int idUsuario)
        {
            clUsuarioE objDatosUsuario = new clUsuarioE();

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

        public clUsuarioE mtdRecuperarContrasena(string idUsuario = null, string correo = null, string contrasena = null)
        {

            clUsuarioE objUsuarioE = objUsuarioD.mtdRecuperarContrasena(idUsuario, correo, contrasena);
            return objUsuarioE;
        }

    }
}