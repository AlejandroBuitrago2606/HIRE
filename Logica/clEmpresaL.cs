using HIRE.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIRE.Entidades
{
    public class clEmpresaL
    {
        private clEmpresaD objEmpresaD = new clEmpresaD();

        public List<clEmpresaE> mtdListarEmpresas(int id)
        {

            clEmpresaD objEmpresaD = new clEmpresaD();
            List<clEmpresaE> objEmpresas = objEmpresaD.mtdListarEmpresas(id);

            return objEmpresas;

        }

        public List<clEmpresaE> mtdBuscarEmpresa(string parametros = null, string municipio = null)
        {

            List<clEmpresaE> objEmpresaE = objEmpresaD.mtdBuscarEmpresa(parametros, municipio);

            return objEmpresaE;

        }

        public (clEmpresaE, List<clVacanteE>) mtdTraerEmpresa(int idEmpresa)
        {

            clEmpresaE objEmpresaE = objEmpresaD.mtdTraerEmpresa(idEmpresa).Item1;
            List<clVacanteE> objVacantesE = objEmpresaD.mtdTraerEmpresa(idEmpresa).Item2;

            return (objEmpresaE, objVacantesE);           

        }

        public bool mtdRegistrarEmpresa(clEmpresaE objEmpresaE)
        {
            bool validacion = objEmpresaD.mtdRegistrarEmpresa(objEmpresaE);
            return validacion;
        }

        public (List<clMunicipioE>, List<clTipoNegocioE>, List<clSectorE>) mtdListarFiltros() { 
        
            var filtros = objEmpresaD.mtdListarFiltros();
            return (filtros.Item1, filtros.Item2, filtros.Item3);

        }

        public (int,int) mtdValidarEmpresa(string nit, string correo)
        {
            return (objEmpresaD.mtdValidarEmpresa(nit, null), objEmpresaD.mtdValidarEmpresa(null, correo));
        }

    }
}