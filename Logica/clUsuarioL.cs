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

        public (bool, int, int, int) mtdRegistrarUsuario(clUsuarioE objUsuarioE = null, string correo = null)
        {

            int contador = 0;
            int idTipoUsuario = 0;
            int correoExistente = 0;
            int idUsuario = 0;


            if (correo != null)
            {
                var resultado = objUsuarioD.mtdRegistrarUsuario(null, correo);
                correoExistente = resultado.Item2;

            }
            else
            {

                var resultado = objUsuarioD.mtdRegistrarUsuario(objUsuarioE);
                idUsuario = resultado.Item1;

                if (idUsuario != 0 && objUsuarioE.idTipo.Length > 0)
                {

                    int IDTipo = int.Parse(objUsuarioE.idTipo.ToString());
                    idTipoUsuario = objUsuarioD.mtdRegistrarUsuario(null, null, IDTipo, idUsuario).Item1;
                    contador++;

                }

                if (idTipoUsuario > 0)
                {
                    contador++;

                }

            }

            return (contador == 2 ? true : false, correoExistente, idUsuario, idTipoUsuario);
        }

        public bool mtdEliminarUsuario(int idTipoUsuario, int idUsuario)
        {
            bool validacion = objUsuarioD.mtdEliminarUsuario(idTipoUsuario, idUsuario);
            return validacion;

        }
    }
}