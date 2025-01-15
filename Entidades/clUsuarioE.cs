using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

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
        public string documento { get; set; }
        public string fechaNacimiento { get; set; }
        public string estadoCivil { get; set; }
        public string numeroHijos { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string idMunicipio { get; set; }
        public string ubicacion { get; set; }
        public string estado { get; set; }
        public string idTipo { get; set; }

        }


}