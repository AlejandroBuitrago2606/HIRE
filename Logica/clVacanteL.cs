using HIRE.Datos;
using HIRE.Entidades;
using System;
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
    }
}