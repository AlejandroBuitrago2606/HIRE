using HIRE.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HIRE.Datos
{
    public class clVacanteD
    {
        ClConexion objConexion = new ClConexion();
        public List<clVacanteE> mtdBuscarVacante(clVacanteE objVacante, string parametros)
        {
            List<clVacanteE> objVacanteE = new List<clVacanteE>();


            try
            {

                SqlCommand cmd = new SqlCommand("spExplorarVacantes", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@parametros", parametros);
                cmd.Parameters.AddWithValue("@municipio", objVacante.municipio);
                cmd.Parameters.AddWithValue("@tipoContrato", objVacante.tipoContrato);
                cmd.Parameters.AddWithValue("@tipoEmpleo", objVacante.tipoEmpleo);

                using (SqlDataReader fila = cmd.ExecuteReader())
                {
                    while (fila.Read())
                    {

                        objVacanteE.Add(new clVacanteE
                        {
                            idVacante = int.Parse(fila["idVacante"].ToString()),
                            titulo = fila["titulo"].ToString(),
                            salario = fila["salario"].ToString(),
                            municipio = fila["municipio"].ToString(),
                            tipoContrato = fila["tipoContrato"].ToString(),
                            tipoEmpleo = fila["tipoEmpleo"].ToString(),
                            fechaLimite = fila["fechaLimite"].ToString()
                        });

                    }



                    objConexion.MtdCerrarConexion();
                    fila.Close();

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
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

                            objNivelAcademico.Add(new clNivelAcademicoE
                            {

                                nivelAcademico = fila["nivelAcademico"].ToString(),


                            });

                        }

                        if (fila.NextResult())
                        {
                            while (fila.Read())
                            {
                                objFuncion.Add(new clFuncionE
                                {

                                    descripcionFuncion = fila["descripcionFuncion"].ToString()

                                });


                            }

                        }

                        if (fila.NextResult())
                        {

                            while (fila.Read())
                            {

                                objRequisito.Add(new clRequisitoE
                                {

                                    descripcionRequisito = fila["descripcionRequisito"].ToString()

                                });


                            }

                        }

                        if (fila.NextResult())
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

                        if (fila.NextResult())
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


                        objDatosVacante.ClNivelAcademico = objNivelAcademico;
                        objDatosVacante.ClFuncion = objFuncion;
                        objDatosVacante.ClRequisito = objRequisito;
                        objDatosVacante.ClHabilidad = objHabilidad;
                        objDatosVacante.ClVacante = objVacante;

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

    }

}