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

                    }
                    else
                    {
                        objDatosVacante = null;

                    }

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

    }

}