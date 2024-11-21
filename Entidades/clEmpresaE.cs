using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIRE.Entidades
{
    public class clEmpresaE
    {

        public int idEmpresa { get; set; }
        public string nombre { get; set; }
        public string nit { get; set; }
        public string descripcion { get; set; }
        public string fechaConstitucion { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string url { get; set; }
        public string foto { get; set; }
        public string tipoNegocio { get; set; }
        public string municipio { get; set; }
        public bool validacion { get; set; }
    }

}