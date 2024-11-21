using HIRE.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HIRE.Entidades
{
    public class clEmpresaL
    {

        public List<clEmpresaE> mtdListarEmpresas(int id)
        {

            clEmpresaD objEmpresaD = new clEmpresaD();
            List<clEmpresaE> objEmpresas = objEmpresaD.mtdListarEmpresas(id);

            return objEmpresas;

        }

    }
}