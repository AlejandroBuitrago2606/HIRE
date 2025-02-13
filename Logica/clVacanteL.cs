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


        public bool mtdRegistrarSolicitud(int idUsuario, int idCV, int idVacante, string fechaEnvio)
        {
            return (objVacanteD.mtdRegistrarSolicitud(idUsuario, idCV, idVacante, fechaEnvio));
        }

        public (List<clSolicitudE>, List<clVacanteE>) mtdListarSolicitudes(int idUsuario, int estado, int idEmpresa)
        {
            var objListadoSolicitudes = objVacanteD.mtdListarSolicitudes(idUsuario, estado, idEmpresa);
            return (objListadoSolicitudes.Item1, objListadoSolicitudes.Item2);

        }


        public List<clSolicitudE> mtdBuscarSolicitud(int idUsuario, string parametro, int estado, int idEmpresa)
        {
            return (objVacanteD.mtdBuscarSolicitud(idUsuario, parametro, estado, idEmpresa));
        }


        public bool mtdRegistrarVacante(clVacanteE objDatosVacante = null, List<clFuncionE> objFuncion = null, List<clRequisitoE> objRequisito = null, List<clNivelAcademicoE> objNivelAcademico = null, List<clCompetenciaE> objCompetencia = null)
        {
            int contador = 0;
            int idVacanteRegistrado = objVacanteD.mtdRegistrarVacante(1, objDatosVacante, 0, null, null, null, null).Item1;

            if (idVacanteRegistrado > 0)
            {
                contador++;
                bool validacion = objVacanteD.mtdRegistrarVacante(2, null, idVacanteRegistrado, objFuncion, objRequisito, objNivelAcademico, objCompetencia).Item2;

                if (validacion)
                {
                    contador++;
                }
                else
                {
                    objVacanteD.mtdEliminarVacante(idVacanteRegistrado);
                    contador = 3;
                }

            }

            return (contador == 2 ? true : false);

        }


        public (List<clVacanteE>, int) mtdListarVacantes(int opcion, int idEmpresa = 0, int idVacante = 0)
        {

            return (objVacanteD.mtdListarVacantes(opcion, idEmpresa, idVacante));

        }

        public List<clVacanteE> mtdListarVacantesBusqueda(int idEmpresa, string parametros)
        {

            return (objVacanteD.mtdListarVacantesBusqueda(idEmpresa, parametros));

        }

        public (List<clVacanteE>, List<clVacanteE>) mtdListarFiltros2()
        {

            var resultado = objVacanteD.mtdListarFiltros2();
            List<clVacanteE> tipoEmpleo = resultado.Item1;
            List<clVacanteE> tipoContrato = resultado.Item2;

            return (tipoEmpleo, tipoContrato);



        }

        public bool mtdEliminarVacante(int idVacante)
        {
            return objVacanteD.mtdEliminarVacante(idVacante);
        }


        public (List<clSolicitudE>, List<clVacanteE>) mtdListarSolicitudesEmpresa(int idEmpresa)
        {

            var resultado = objVacanteD.mtdListarSolicitudesEmpresa(idEmpresa);
            List <clSolicitudE> objSolicitudes = resultado.Item1;
            List<clVacanteE> objVacantes = resultado.Item2;

            return(objSolicitudes, objVacantes);
        }

    }
}