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

        public bool mtdRegistrarUsuario(clUsuarioE objUsuarioE, string idTipo)
        {
            bool validacion = false;

            int contador = 0;

            int idUsuario = objUsuarioD.mtdRegistrarUsuario(objUsuarioE);

            int idTipoUsuario = 0;

            if (idUsuario != 0)
            {

                int IDTipo = int.Parse(idTipo.ToString());

                contador += 1;
                idTipoUsuario = objUsuarioD.mtdRegistrarUsuario(null, IDTipo, idUsuario);


            }

            if (idTipoUsuario != 0)
            {


                contador += 1;

            }


            return contador == 2 ? validacion = true : validacion = false;
        }

    }
}