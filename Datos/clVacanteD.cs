using HIRE.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HIRE.Datos
{
    public class clVacanteD
    {
        ClConexion objConexion = new ClConexion();
        public List<clVacanteE> mtdBuscarVacante(clVacanteE objVacante = null, string parametros = null)
        {
            List<clVacanteE> objVacanteE = new List<clVacanteE>();


            if (objVacante == null && parametros == null)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("spExplorarVacantes", objConexion.MtdAbrirConexion());
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader fila = cmd.ExecuteReader())
                    {

                        while (fila.Read())
                        {
                            DateTime fechaLimiteConHoras = Convert.ToDateTime(fila["fechaLimite"].ToString());
                            string fechaLimite = fechaLimiteConHoras.ToString("dd-MM-yyyy");


                            if (fila["tipoEmpleo"].ToString() == "Remoto" || fila["tipoEmpleo"].ToString() == "")
                            {

                                objVacanteE.Add(new clVacanteE
                                {
                                    idVacante = int.Parse(fila["idVacante"].ToString()),
                                    titulo = fila["titulo"].ToString(),
                                    salario = fila["salario"].ToString(),
                                    municipio = "No aplica",
                                    tipoContrato = fila["tipoContrato"].ToString(),
                                    tipoEmpleo = fila["tipoEmpleo"].ToString(),
                                    fechaLimite = fechaLimite

                                });

                            }
                            else
                            {

                                objVacanteE.Add(new clVacanteE
                                {
                                    idVacante = int.Parse(fila["idVacante"].ToString()),
                                    titulo = fila["titulo"].ToString(),
                                    salario = fila["salario"].ToString(),
                                    municipio = fila["municipio"].ToString(),
                                    tipoContrato = fila["tipoContrato"].ToString(),
                                    tipoEmpleo = fila["tipoEmpleo"].ToString(),
                                    fechaLimite = fechaLimite

                                });


                            }

                        }

                        objConexion.MtdCerrarConexion();
                        fila.Close();

                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }



            }

            else if (parametros == null)
            {


                try
                {
                    SqlCommand cmd = new SqlCommand("spExplorarVacantes", objConexion.MtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@municipio", objVacante.municipio);
                    cmd.Parameters.AddWithValue("@tipoContrato", objVacante.tipoContrato);
                    cmd.Parameters.AddWithValue("@tipoEmpleo", objVacante.tipoEmpleo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader fila = cmd.ExecuteReader())
                    {
                        while (fila.Read())
                        {
                            DateTime fechaLimiteConHoras = Convert.ToDateTime(fila["fechaLimite"].ToString());
                            string fechaLimite = fechaLimiteConHoras.ToString("dd-MM-yyyy");

                            if (fila["tipoEmpleo"].ToString() == "Remoto" || fila["tipoEmpleo"].ToString() == "")
                            {

                                objVacanteE.Add(new clVacanteE
                                {
                                    idVacante = int.Parse(fila["idVacante"].ToString()),
                                    titulo = fila["titulo"].ToString(),
                                    salario = fila["salario"].ToString(),
                                    municipio = "No aplica",
                                    tipoContrato = fila["tipoContrato"].ToString(),
                                    tipoEmpleo = fila["tipoEmpleo"].ToString(),
                                    fechaLimite = fechaLimite

                                });

                            }
                            else
                            {

                                objVacanteE.Add(new clVacanteE
                                {
                                    idVacante = int.Parse(fila["idVacante"].ToString()),
                                    titulo = fila["titulo"].ToString(),
                                    salario = fila["salario"].ToString(),
                                    municipio = fila["municipio"].ToString(),
                                    tipoContrato = fila["tipoContrato"].ToString(),
                                    tipoEmpleo = fila["tipoEmpleo"].ToString(),
                                    fechaLimite = fechaLimite

                                });



                            }




                        }



                        objConexion.MtdCerrarConexion();
                        fila.Close();

                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }

            else if (objVacante == null)
            {



                try
                {
                    SqlCommand cmd = new SqlCommand("spExplorarVacantes", objConexion.MtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@parametros", parametros);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader fila = cmd.ExecuteReader())
                    {
                        while (fila.Read())
                        {
                            DateTime fechaLimiteConHoras = Convert.ToDateTime(fila["fechaLimite"].ToString());
                            string fechaLimite = fechaLimiteConHoras.ToString("dd-MM-yyyy");

                            if (fila["tipoEmpleo"].ToString() == "Remoto" || fila["tipoEmpleo"].ToString() == "")
                            {

                                objVacanteE.Add(new clVacanteE
                                {
                                    idVacante = int.Parse(fila["idVacante"].ToString()),
                                    titulo = fila["titulo"].ToString(),
                                    salario = fila["salario"].ToString(),
                                    municipio = "No aplica",
                                    tipoContrato = fila["tipoContrato"].ToString(),
                                    tipoEmpleo = fila["tipoEmpleo"].ToString(),
                                    fechaLimite = fechaLimite

                                });

                            }
                            else
                            {

                                objVacanteE.Add(new clVacanteE
                                {
                                    idVacante = int.Parse(fila["idVacante"].ToString()),
                                    titulo = fila["titulo"].ToString(),
                                    salario = fila["salario"].ToString(),
                                    municipio = fila["municipio"].ToString(),
                                    tipoContrato = fila["tipoContrato"].ToString(),
                                    tipoEmpleo = fila["tipoEmpleo"].ToString(),
                                    fechaLimite = fechaLimite

                                });



                            }




                        }



                        objConexion.MtdCerrarConexion();
                        fila.Close();

                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }



            }


            return objVacanteE;

        }

        public clDatosVacante mtdTraerVacante(int idVacante)
        {

            clDatosVacante objDatosVacante = new clDatosVacante();

            try
            {

                List<clNivelAcademicoE> objNivelAcademico = new List<clNivelAcademicoE>();
                List<clFuncionE> objFuncion = new List<clFuncionE>();
                List<clRequisitoE> objRequisito = new List<clRequisitoE>();
                List<clHabilidadE> objHabilidad = new List<clHabilidadE>();
                clVacanteE objVacante = new clVacanteE();

                SqlCommand cmd = new SqlCommand("spExplorarVacantes", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@idVacante", idVacante);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader fila = cmd.ExecuteReader())
                {

                    if (fila.HasRows)
                    {
                        while (fila.Read())
                        {

                            objNivelAcademico.Add(new clNivelAcademicoE { nivelAcademico = fila["nivelAcademico"].ToString() });

                        }
                    }

                    if (fila.NextResult())
                    {

                        if (fila.HasRows)
                        {

                            while (fila.Read())
                            {
                                objFuncion.Add(new clFuncionE { descripcionFuncion = fila["descripcionFuncion"].ToString() });


                            }
                        }

                    }

                    if (fila.NextResult())
                    {

                        if (fila.HasRows)
                        {

                            while (fila.Read())
                            {

                                objRequisito.Add(new clRequisitoE { descripcionRequisito = fila["descripcionRequisito"].ToString() });


                            }
                        }

                    }

                    if (fila.NextResult())
                    {

                        if (fila.HasRows)
                        {

                            while (fila.Read())
                            {

                                objHabilidad.Add(new clHabilidadE
                                {

                                    nombreCompetencia = fila["nombreCompetencia"].ToString(),
                                    descripcion = fila["descripcion"].ToString()

                                });

                            }
                        }

                    }

                    if (fila.NextResult())
                    {
                        if (fila.HasRows)
                        {

                            while (fila.Read())
                            {

                                objVacante.titulo = fila["titulo"].ToString();
                                objVacante.descripcion = fila["descripcion"].ToString();
                                objVacante.tiempoExperiencia = fila["tiempoExperiencia"].ToString();
                                objVacante.salario = fila["salario"].ToString();
                                objVacante.jornada = fila["jornada"].ToString();
                                objVacante.horario = fila["horario"].ToString();
                                objVacante.idiomaRequerido = fila["idiomaRequerido"].ToString();
                                objVacante.fechaInicio = fila["fechaInicio"].ToString();
                                objVacante.fechaLimite = fila["fechaLimite"].ToString();
                                objVacante.fechaPublicacion = fila["fechaPublicacion"].ToString();
                                objVacante.tipoEmpleo = fila["tipoEmpleo"].ToString();
                                objVacante.tipoContrato = fila["tipoContrato"].ToString();
                                objVacante.municipio = fila["municipio"].ToString();

                            }

                        }


                    }


                    objDatosVacante.objNivelAcademico = objNivelAcademico;
                    objDatosVacante.objFuncion = objFuncion;
                    objDatosVacante.objRequisito = objRequisito;
                    objDatosVacante.objHabilidad = objHabilidad;
                    objDatosVacante.objVacante = objVacante;

                    fila.Close();
                    objConexion.MtdCerrarConexion();

                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }



            return objDatosVacante;
        }

        public (List<clMunicipioE>, ArrayList, ArrayList, List<clCargoE>) mtdListarFiltros()
        {
            SqlCommand cmd = new SqlCommand("spListarFiltros", objConexion.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@filtros2", 0);
            cmd.CommandType = CommandType.StoredProcedure;

            List<clMunicipioE> municipios = new List<clMunicipioE>();
            ArrayList tipoContrato = new ArrayList();
            ArrayList tipoEmpleo = new ArrayList();
            List<clCargoE> cargo = new List<clCargoE>();

            try
            {
                using (SqlDataReader fila = cmd.ExecuteReader())
                {
                    if (fila.HasRows)
                    {

                        while (fila.Read())
                        {

                            municipios.Add(new clMunicipioE
                            {

                                idMunicipio = int.Parse(fila["idMunicipio"].ToString()),
                                nombre = fila["municipio"].ToString()

                            });

                        }

                        if (fila.NextResult())
                        {
                            tipoContrato.Add("");
                            while (fila.Read())
                            {

                                tipoContrato.Add(fila["tipoContrato"].ToString());
                            }
                        }

                        if (fila.NextResult())
                        {

                            while (fila.Read())
                            {

                                cargo.Add(new clCargoE
                                {

                                    idTipo = int.Parse(fila["idTipo"].ToString()),
                                    cargo = fila["cargo"].ToString()
                                });
                            }
                        }


                        if (fila.NextResult())
                        {
                            tipoEmpleo.Add("");
                            while (fila.Read())
                            {

                                tipoEmpleo.Add(fila["tipoEmpleo"].ToString());
                            }
                        }


                    }
                    else
                    {

                        //CORREGIR ELSE'S DE TODOS LOS RESULTADOS
                        municipios = null;
                        tipoContrato = null;
                        tipoEmpleo = null;
                    }

                    fila.Close();
                    objConexion.MtdCerrarConexion();

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return (municipios, tipoContrato, tipoEmpleo, cargo);

        }

        public bool mtdRegistrarSolicitud(int idUsuario, int idCV, int idVacante, string fechaEnvio)
        {

            bool validar = false;

            try
            {
                SqlCommand cmd = new SqlCommand("spRegistrarSolicitud", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@idVacante", idVacante);
                cmd.Parameters.AddWithValue("@fechaEnvio", fechaEnvio);
                cmd.Parameters.AddWithValue("@idCV", idCV);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                validar = true;

                objConexion.MtdCerrarConexion();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }


            return validar;

        }

        public (List<clSolicitudE>, List<clVacanteE>) mtdListarSolicitudes(int idUsuario)
        {


            List<clSolicitudE> objSolicitudes = new List<clSolicitudE>();
            List<clVacanteE> objVacantes = new List<clVacanteE>();
            try
            {


                SqlCommand cmd = new SqlCommand("spListarSolicitudes", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader filas = cmd.ExecuteReader())
                {
                    if (filas.HasRows)
                    {
                        while (filas.Read())
                        {
                            objSolicitudes.Add(new clSolicitudE
                            {

                                idSolicitud = int.Parse(filas["idSolicitud"].ToString()),
                                idCurriculumVitae = int.Parse(filas["idCurriculumVitae"].ToString()),
                                fechaEnvio = filas["fechaEnvio"].ToString(),
                                estado = int.Parse(filas["estado"].ToString()),
                                idUsuario = int.Parse(filas["idUsuario"].ToString()),
                                idVacante = int.Parse(filas["idVacante"].ToString())

                            });

                        }

                    }
                    if (filas.NextResult())
                    {
                        if (filas.HasRows)
                        {
                            while (filas.Read())
                            {

                                objVacantes.Add(new clVacanteE
                                {

                                    idVacante = int.Parse(filas["idVacante"].ToString()),
                                    titulo = filas["titulo"].ToString(),
                                    fechaInicio = filas["fechaInicio"].ToString(),
                                    fechaLimite = filas["fechaLimite"].ToString(),

                                });

                            }

                        }

                    }

                    filas.Close();
                    objConexion.MtdCerrarConexion();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return (objSolicitudes, objVacantes);

        }

        public List<clSolicitudE> mtdBuscarSolicitud(int idUsuario, string parametro)
        {
            List<clSolicitudE> objSolicitudes = new List<clSolicitudE>();
            try
            {
                SqlCommand cmd = new SqlCommand("spBuscarSolicitud", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@parametro", parametro);
                cmd.CommandType = CommandType.StoredProcedure;



                using (SqlDataReader fila = cmd.ExecuteReader())
                {
                    if (fila.HasRows)
                    {

                        while (fila.Read())
                        {
                            objSolicitudes.Add(new clSolicitudE
                            {

                                idSolicitud = int.Parse(fila["idSolicitud"].ToString()),
                                idCurriculumVitae = int.Parse(fila["idCurriculumVitae"].ToString()),
                                idUsuario = int.Parse(fila["idUsuario"].ToString()),
                                idVacante = int.Parse(fila["idVacante"].ToString())

                            });

                        }

                    }
                    fila.Close();


                }

                objConexion.MtdCerrarConexion();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


            return objSolicitudes;

        }

        public (int, bool) mtdRegistrarVacante(int opcion, clVacanteE objDatosVacante = null, int idVacante = 0, List<clFuncionE> objFuncion = null, List<clRequisitoE> objRequisito = null, List<clNivelAcademicoE> objNivelAcademico = null, List<clCompetenciaE> objCompetencia = null)
        {

            int idValorRetorno = 0;
            bool validar = false;

            if (opcion == 1 && objDatosVacante != null)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("spRegistrarVacante", objConexion.MtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@titulo", objDatosVacante.titulo);
                    cmd.Parameters.AddWithValue("@descripcion", objDatosVacante.descripcion);
                    cmd.Parameters.AddWithValue("@tiempoExperiencia", objDatosVacante.tiempoExperiencia);
                    cmd.Parameters.AddWithValue("@salario", objDatosVacante.salario);
                    cmd.Parameters.AddWithValue("@jornada", objDatosVacante.jornada);
                    cmd.Parameters.AddWithValue("@horario", objDatosVacante.horario);
                    cmd.Parameters.AddWithValue("@idiomaRequerido", objDatosVacante.idiomaRequerido);
                    cmd.Parameters.AddWithValue("@fechaInicio", objDatosVacante.fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaLimite", objDatosVacante.fechaLimite);
                    cmd.Parameters.AddWithValue("@fechaPublicacion", objDatosVacante.fechaPublicacion);
                    cmd.Parameters.AddWithValue("@idTipoEmpleo", objDatosVacante.idTipoEmpleo);
                    cmd.Parameters.AddWithValue("@idTipoContrato", objDatosVacante.idTipoContrato);
                    cmd.Parameters.AddWithValue("@idEmpresa", objDatosVacante.idEmpresa);
                    cmd.Parameters.AddWithValue("@idMunicipio", objDatosVacante.idMunicipio);
                    cmd.CommandType = CommandType.StoredProcedure;


                    SqlParameter idVacanteR = new SqlParameter("@parametroDevuelto", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idVacanteR);
                    cmd.ExecuteNonQuery();

                    idValorRetorno = int.Parse(idVacanteR.Value.ToString());
                    objConexion.MtdCerrarConexion();


                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }
            else
            {
                if (idVacante > 0)
                {

                    try
                    {

                        if (objFuncion != null)
                        {

                            foreach (clFuncionE funciones in objFuncion)
                            {
                                SqlCommand cmd = new SqlCommand("spAgregarDetallesVacante", objConexion.MtdAbrirConexion());
                                cmd.Parameters.AddWithValue("@idVacante", idVacante);
                                cmd.Parameters.AddWithValue("@descripcionFuncion", funciones.descripcionFuncion);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.ExecuteNonQuery();
                                objConexion.MtdCerrarConexion();
                            }


                        }


                        if (objRequisito != null)
                        {

                            foreach (clRequisitoE requisitos in objRequisito)
                            {
                                SqlCommand cmd = new SqlCommand("spAgregarDetallesVacante", objConexion.MtdAbrirConexion());
                                cmd.Parameters.AddWithValue("@idVacante", idVacante);
                                cmd.Parameters.AddWithValue("@descripcionRequisito", requisitos.descripcionRequisito);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.ExecuteNonQuery();
                                objConexion.MtdCerrarConexion();

                            }

                        }


                        if (objCompetencia != null)
                        {

                            foreach (clCompetenciaE competencias in objCompetencia)
                            {
                                SqlCommand cmd = new SqlCommand("spAgregarDetallesVacante", objConexion.MtdAbrirConexion());
                                cmd.Parameters.AddWithValue("@idVacante", idVacante);
                                cmd.Parameters.AddWithValue("@idCompetencia", competencias.idCompetencia);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.ExecuteNonQuery();
                                objConexion.MtdCerrarConexion();

                            }

                        }


                        if (objNivelAcademico != null)
                        {

                            foreach (clNivelAcademicoE nivelesAcademicos in objNivelAcademico)
                            {
                                SqlCommand cmd = new SqlCommand("spAgregarDetallesVacante", objConexion.MtdAbrirConexion());
                                cmd.Parameters.AddWithValue("@idVacante", idVacante);
                                cmd.Parameters.AddWithValue("@idNivelAcademico", nivelesAcademicos.idNivelAcademico);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.ExecuteNonQuery();
                                objConexion.MtdCerrarConexion();
                            }

                        }

                        validar = true;

                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }

                }

            }

            return (idValorRetorno, validar);

        }

        public bool mtdEliminarVacante(int idVacante)
        {

            bool validacion = false;

            try
            {
                SqlCommand cmd = new SqlCommand("spEliminarVacante", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@idVacante", idVacante);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                objConexion.MtdCerrarConexion();
                validacion = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return validacion;

        }

        public (List<clVacanteE>, int) mtdListarVacantes(int opcion, int idEmpresa = 0, int idVacante = 0)
        {
            List<clVacanteE> vacantes = new List<clVacanteE>();
            int numeroPostulados = 0;

            try
            {
                if (opcion == 1 && idEmpresa > 0)
                {
                    SqlCommand cmd = new SqlCommand("spListarVacantesEmpresa", objConexion.MtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                    cmd.Parameters.AddWithValue("@opcion", opcion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader fila = cmd.ExecuteReader())
                    {
                        if (fila.HasRows)
                        {
                            while (fila.Read())
                            {
                                vacantes.Add(new clVacanteE
                                {
                                    idVacante = int.Parse(fila["idVacante"].ToString()),
                                    titulo = fila["titulo"].ToString(),
                                    fechaPublicacion = fila["fechaPublicacion"].ToString()
                                });

                            }
                        }

                        fila.Close();
                        objConexion.MtdCerrarConexion();

                    }


                }
                else if (opcion == 2)
                {
                    SqlCommand cmd = new SqlCommand("spListarVacantesEmpresa", objConexion.MtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@idVacante", idVacante);
                    cmd.Parameters.AddWithValue("@opcion", opcion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader fila = cmd.ExecuteReader())
                    {
                        if (fila.HasRows)
                        {
                            while (fila.Read())
                            {
                                numeroPostulados++;
                            }
                        }

                        fila.Close();
                        objConexion.MtdCerrarConexion();

                    }

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return (vacantes, numeroPostulados);

        }

        public List<clVacanteE> mtdListarVacantesBusqueda(int idEmpresa, string parametros)
        {
            List<clVacanteE> vacantes = new List<clVacanteE>();


            try
            {
                SqlCommand cmd = new SqlCommand("spBuscarVacantes", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                cmd.Parameters.AddWithValue("@parametros", parametros);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader fila = cmd.ExecuteReader())
                {
                    if (fila.HasRows)
                    {
                        while (fila.Read())
                        {
                            vacantes.Add(new clVacanteE
                            {
                                idVacante = int.Parse(fila["idVacante"].ToString()),
                                titulo = fila["titulo"].ToString(),
                                fechaPublicacion = fila["fechaPublicacion"].ToString()
                            });

                        }
                    }

                    fila.Close();
                    objConexion.MtdCerrarConexion();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return vacantes;
        }

        public (List<clVacanteE>, List<clVacanteE>) mtdListarFiltros2()
        {

            List<clVacanteE> tipoContrato = new List<clVacanteE>();
            List<clVacanteE> tipoEmpleo = new List<clVacanteE>();
            try
            {
                SqlCommand cmd = new SqlCommand("spListarFiltros2", objConexion.MtdAbrirConexion());

                using (SqlDataReader filas = cmd.ExecuteReader())
                {


                    if (filas.HasRows)
                    {
                        while (filas.Read())
                        {
                            tipoEmpleo.Add(new clVacanteE
                            {
                                idTipoEmpleo = int.Parse(filas["idTipoEmpleo"].ToString()),
                                tipoEmpleo = filas["tipoEmpleo"].ToString()
                            });

                        }
                    }

                    if (filas.NextResult())
                    {

                        while (filas.Read())
                        {
                            tipoContrato.Add(new clVacanteE
                            {

                                idTipoContrato = int.Parse(filas["idTipoContrato"].ToString()),
                                tipoContrato = filas["tipoContrato"].ToString()

                            });

                        }

                    }


                    filas.Close();
                    objConexion.MtdCerrarConexion();

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return (tipoEmpleo, tipoContrato);

        }


        public (List<clSolicitudE>, List<clVacanteE>) mtdListarSolicitudesEmpresa(int idEmpresa)
        {


            List<clSolicitudE> objSolicitudes = new List<clSolicitudE>();
            List<clVacanteE> objVacantes = new List<clVacanteE>();
            try
            {


                SqlCommand cmd = new SqlCommand("spListarSolicitudesEmpresa", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader filas = cmd.ExecuteReader())
                {
                    if (filas.HasRows)
                    {
                        while (filas.Read())
                        {
                            objSolicitudes.Add(new clSolicitudE
                            {

                                idSolicitud = int.Parse(filas["idSolicitud"].ToString()),
                                idCurriculumVitae = int.Parse(filas["idCurriculumVitae"].ToString()),
                                fechaEnvio = filas["fechaEnvio"].ToString(),                                
                                estado = int.Parse(filas["estado"].ToString()),
                                idUsuario = int.Parse(filas["idUsuario"].ToString()),
                                idVacante = int.Parse(filas["idVacante"].ToString())

                            });

                        }

                    }
                    if (filas.NextResult())
                    {
                        if (filas.HasRows)
                        {
                            while (filas.Read())
                            {

                                objVacantes.Add(new clVacanteE
                                {

                                    idVacante = int.Parse(filas["idVacante"].ToString()),
                                    titulo = filas["titulo"].ToString(),
                                    fechaInicio = filas["fechaInicio"].ToString(),
                                    fechaLimite = filas["fechaLimite"].ToString(),

                                });

                            }

                        }

                    }

                    filas.Close();
                    objConexion.MtdCerrarConexion();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return (objSolicitudes, objVacantes);

        }


    }

}