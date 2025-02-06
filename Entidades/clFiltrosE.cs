using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIRE.Entidades
{
    public class clFiltrosE
    {


    }

    public class clCargoE {


        public int idTipo { get; set; }
        public string cargo { get; set; }



    }

    public class clMunicipioE
    {

        public int idMunicipio { get; set; }
        public string nombre { get; set; }
    }

    public class clSectorE
    {

        public int idSector { get; set; }
        public string sector { get; set; }
    }

    public class clTipoNegocioE
    {

        public int idTipoNegocio { get; set; }
        public string tipoNegocio { get; set; }
    }   

}