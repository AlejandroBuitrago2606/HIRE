using HIRE.Datos;
using HIRE.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIRE.Logica
{
    public class clPerfilL
    {

        clPerfilD objDatosD = new clPerfilD();
        public clTraerPerfilCV mtdListarCV(int idUsuario)
        {

            clTraerPerfilCV objPerfilCV = objDatosD.mtdListarPerfil(idUsuario);

            return objPerfilCV;

        }

        public bool mtdRegistrarCvL(int opcion, clDetallesPerfilCV objDatosCV, int idCV = 0)
        {
            return (objDatosD.mtdRegistrarCvD(opcion, objDatosCV, idCV));
        }

        public (List<clCompetenciaE>, List<clNivelAcademicoE>, ArrayList) mtdListarFiltros()
        {

            ArrayList Idiomas = new ArrayList()
            {
                "Español",
                "Inglés",
                "Francés",
                "Portugués",
                "Alemán",
                "Italiano",
                "Mandarín",
                "Japonés",
                "Coreano",
                "Ruso",
                "Árabe",
                "Holandés",
                "Hebreo",
                "Turco",
                "Griego",
                "Sueco",
                "Danés",
                "Noruego",
                "Polaco",
                "Húngaro"
            };
            var resultado = objDatosD.mtdListarFiltros();
            List<clNivelAcademicoE> objNivelAcademico = resultado.Item2;
            List<clCompetenciaE> objCompetencia = resultado.Item1;



            return (objCompetencia,objNivelAcademico, Idiomas);
        }
    }
}