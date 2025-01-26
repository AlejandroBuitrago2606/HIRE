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
        public string sector { get; set; }
        public string descripcion { get; set; }
        public string fechaConstitucion { get; set; }
        public string direccion { get; set; }
        public string ubicacion { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string url { get; set; }
        public string foto { get; set; }
        public string tipoNegocio { get; set; }
        public string municipio { get; set; }
        public string totalVacantes { get; set; }
        public string correo { get; set; }
        public string numeroEmpleados { get; set; }
        public int idTipoNegocio { get; set; }
        public int idUsuario { get; set; }
        public int idMunicipio { get; set; }
        public int idSector { get; set; }
        public bool validacion { get; set; }
    }

}