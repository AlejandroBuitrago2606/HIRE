using HIRE.Datos;
using HIRE.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIRE.Logica
{
    public class clVacanteL
    {

        clVacanteD objVacanteD = new clVacanteD();


        public List<clVacanteE> mtdBuscarVacante(clVacanteE objVacante, string parametros)
        {

            List<clVacanteE> objBusqueda = objVacanteD.mtdBuscarVacante(objVacante, parametros);
            return objBusqueda;

        }

        public clDatosVacante mtdTraerVacante(int idVacante)
        {

            clDatosVacante objDatosVacante = objVacanteD.mtdTraerVacante(idVacante);
            return objDatosVacante;
        }

        public (ArrayList, ArrayList, ArrayList) mtdListarFiltros()
        {

            ArrayList municipios = new ArrayList();
            ArrayList tipoContrato = new ArrayList();
            ArrayList tipoEmpleo = new ArrayList();

            municipios = objVacanteD.mtdListarFiltros().Item1;
            tipoContrato = objVacanteD.mtdListarFiltros().Item2;
            tipoEmpleo = objVacanteD.mtdListarFiltros().Item3;

            return (municipios, tipoContrato, tipoEmpleo);
        }


    }
}