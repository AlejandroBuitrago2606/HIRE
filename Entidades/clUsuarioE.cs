using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIRE.Entidades
{
    public class clUsuarioE
    {


        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public string foto { get; set; }
        public bool validar { get; set; }

    }
}