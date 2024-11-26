using HIRE.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HIRE.Datos
{
    public class clEmpresaD
    {
        ClConexion objConexion = new ClConexion();

        public List<clEmpresaE> mtdListarEmpresas(int id)
        {
            List<clEmpresaE> objEmpresaDatos = new List<clEmpresaE>();

            try
            {

                SqlCommand cmd = new SqlCommand("spListarEmpresas", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@idUsuario", id);
                cmd.CommandType = CommandType.StoredProcedure; //le especifico que es un SP
                using (SqlDataReader fila = cmd.ExecuteReader())
                {
                    while (fila.Read())
                    {




                        objEmpresaDatos.Add(new clEmpresaE
                        {

                            idEmpresa = int.Parse(fila["idEmpresa"].ToString()),
                            nombre = fila["nombre"].ToString(),
                            nit = fila["nit"].ToString(),
                            descripcion = fila["descripcion"].ToString(),
                            fechaConstitucion = fila["fechaConstitucion"].ToString(),
                            direccion = fila["direccion"].ToString(),
                            telefono = fila["telefono"].ToString(),
                            url = fila["url"].ToString(),
                            foto = fila["foto"].ToString(),
                            tipoNegocio = fila["tipoNegocio"].ToString(),
                            municipio = fila["municipio"].ToString(),
                            validacion = true
                        });


                    }
                    objConexion.MtdCerrarConexion();
                    fila.Close();




                }
            }
            catch (Exception e)
            {
                objEmpresaDatos.Add(new clEmpresaE { validacion = false });
                Console.WriteLine(e.Message);
            }


            return objEmpresaDatos;

        }

        public List<clEmpresaE> mtdBuscarEmpresa(string parametros = null, string municipio = null)
        {

            List<clEmpresaE> objEmpresaE = new List<clEmpresaE>();

            if (municipio == null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spExplorarEmpresas", objConexion.MtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@parametros", parametros);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader fila = cmd.ExecuteReader())
                    {

                        if (fila.HasRows)
                        {

                            while (fila.Read())
                            {


                                objEmpresaE.Add(new clEmpresaE
                                {

                                    idEmpresa = int.Parse(fila["idEmpresa"].ToString()),
                                    foto = fila["foto"].ToString(),
                                    nombre = fila["nombre"].ToString(),
                                    sector = fila["sector"].ToString(),
                                    municipio = fila["municipio"].ToString(),
                                    descripcion = fila["descripcion"].ToString(),
                                    totalVacantes = fila["totalVacantes"].ToString()

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





            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spExplorarEmpresas", objConexion.MtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@municipio", municipio);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader fila = cmd.ExecuteReader())
                    {

                        if (fila.HasRows)
                        {

                            while (fila.Read())
                            {


                                objEmpresaE.Add(new clEmpresaE
                                {

                                    idEmpresa = int.Parse(fila["idEmpresa"].ToString()),
                                    foto = fila["foto"].ToString(),
                                    nombre = fila["nombre"].ToString(),
                                    sector = fila["sector"].ToString(),
                                    municipio = fila["municipio"].ToString(),
                                    descripcion = fila["descripcion"].ToString(),
                                    totalVacantes = fila["totalVacantes"].ToString()

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

            }

            return objEmpresaE;

        }

        public (clEmpresaE, List<clVacanteE>) mtdTraerEmpresa(int idEmpresa)
        {
            clEmpresaE objEmpresaE = new clEmpresaE();
            List<clVacanteE> objVacantesE = new List<clVacanteE>();


            SqlCommand cmd = new SqlCommand("spExplorarEmpresas", objConexion.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);
            cmd.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader fila = cmd.ExecuteReader())
            {

                if (fila.HasRows)
                {

                    while (fila.Read())
                    {

                        objEmpresaE.idEmpresa = int.Parse(fila["idEmpresa"].ToString());
                        objEmpresaE.nombre = fila["nombre"].ToString();
                        objEmpresaE.nit = fila["nit"].ToString();
                        objEmpresaE.sector = fila["sector"].ToString();
                        objEmpresaE.descripcion = fila["descripcion"].ToString();
                        objEmpresaE.fechaConstitucion = fila["fechaConstitucion"].ToString();
                        objEmpresaE.direccion = fila["direccion"].ToString();
                        objEmpresaE.telefono = fila["telefono"].ToString();
                        objEmpresaE.url = fila["url"].ToString();
                        objEmpresaE.foto = fila["foto"].ToString();
                        objEmpresaE.tipoNegocio = fila["tipoNegocio"].ToString();
                        objEmpresaE.municipio = fila["municipio"].ToString();

                    };


                    if (fila.NextResult())
                    {

                        if (fila.HasRows)
                        {

                            while (fila.Read())
                            {

                                objVacantesE.Add(new clVacanteE
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

                        }

                    }

                }

                fila.Close();
                objConexion.MtdCerrarConexion();

            }

            return (objEmpresaE, objVacantesE);


        }

    }

}

