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


        public List<clVacanteE> mtdBuscarVacante(clVacanteE objVacante = null, string parametros = null)
        {

            List<clVacanteE> objBusqueda = objVacanteD.mtdBuscarVacante(objVacante, parametros);
            return objBusqueda;

        }

        public clDatosVacante mtdTraerVacante(int idVacante)
        {

            clDatosVacante objDatosVacante = objVacanteD.mtdTraerVacante(idVacante);
            return objDatosVacante;
        }

        public (List<clMunicipioE>, ArrayList, ArrayList, List<clCargoE>, ArrayList) mtdListarFiltros()
        {


            List<clMunicipioE> objMunicipios = objVacanteD.mtdListarFiltros().Item1;
            ArrayList tipoContrato = objVacanteD.mtdListarFiltros().Item2;
            ArrayList tipoEmpleo = objVacanteD.mtdListarFiltros().Item3;
            List<clCargoE> cargo = objVacanteD.mtdListarFiltros().Item4;


            ArrayList estadoCivil = new ArrayList();
            estadoCivil.Add("Soltero");
            estadoCivil.Add("Casado");
            estadoCivil.Add("Union Libre");
            estadoCivil.Add("Separado");
            estadoCivil.Add("Divorciado");
            estadoCivil.Add("Viudo");
            estadoCivil.Add("Prefiero no decirlo");
            

            return (objMunicipios, tipoContrato, tipoEmpleo, cargo, estadoCivil);
        }


    }
}