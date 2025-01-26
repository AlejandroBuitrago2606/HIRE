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
                            telefono1 = fila["telefono1"].ToString(),
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

            if (parametros == null && municipio == null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spExplorarEmpresas", objConexion.MtdAbrirConexion());
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

            else if (municipio == null)
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
            else if (parametros == null)
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
                        objEmpresaE.foto = fila["foto"].ToString();
                        objEmpresaE.descripcion = fila["descripcion"].ToString();
                        objEmpresaE.numeroEmpleados = fila["numeroEmpleados"].ToString();
                        objEmpresaE.direccion = fila["direccion"].ToString();
                        objEmpresaE.municipio = fila["municipio"].ToString();
                        objEmpresaE.telefono1 = fila["telefono1"].ToString();
                        objEmpresaE.correo = fila["correo"].ToString();
                        objEmpresaE.url = fila["url"].ToString();

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

        public bool mtdRegistrarEmpresa(clEmpresaE objDatosEmpresa)
        {

            bool validar = false;

            try
            {
                SqlCommand cmd = new SqlCommand("spRegistrarEmpresa", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@nombre", objDatosEmpresa.nombre);
                cmd.Parameters.AddWithValue("@nit", objDatosEmpresa.nit);
                cmd.Parameters.AddWithValue("@descripcion", objDatosEmpresa.descripcion);
                cmd.Parameters.AddWithValue("@numeroEmpleados", int.Parse(objDatosEmpresa.numeroEmpleados));
                cmd.Parameters.AddWithValue("@fechaConstitucion", objDatosEmpresa.fechaConstitucion);
                cmd.Parameters.AddWithValue("@direccion", objDatosEmpresa.direccion);
                cmd.Parameters.AddWithValue("@ubicacion", objDatosEmpresa.ubicacion);
                cmd.Parameters.AddWithValue("@telefono1", objDatosEmpresa.telefono1);
                cmd.Parameters.AddWithValue("@telefono2", objDatosEmpresa.telefono2);
                cmd.Parameters.AddWithValue("@correo", objDatosEmpresa.correo);
                cmd.Parameters.AddWithValue("@url", objDatosEmpresa.url);
                cmd.Parameters.AddWithValue("@foto", objDatosEmpresa.foto);
                cmd.Parameters.AddWithValue("@idTipoNegocio", objDatosEmpresa.idTipoNegocio);
                cmd.Parameters.AddWithValue("@idUsuario", objDatosEmpresa.idUsuario);
                cmd.Parameters.AddWithValue("@idMunicipio", objDatosEmpresa.idMunicipio);
                cmd.Parameters.AddWithValue("@idSector", objDatosEmpresa.idSector);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                validar = true;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }

            return validar;

        }

        public (List<clMunicipioE>, List<clTipoNegocioE>, List<clSectorE>) mtdListarFiltros()
        {
            List<clMunicipioE> municipios = new List<clMunicipioE>();
            List<clTipoNegocioE> tiposNegocios = new List<clTipoNegocioE>();
            List<clSectorE> sectores = new List<clSectorE>();



            try
            {
                SqlCommand cmd = new SqlCommand("spListarFiltros", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@filtros2", 1);
                cmd.CommandType = CommandType.StoredProcedure;

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

                    }
                    else
                    {
                        municipios = null;

                    }

                    if (fila.NextResult())
                    {

                        if (fila.HasRows)
                        {

                            while (fila.Read())
                            {

                                tiposNegocios.Add(new clTipoNegocioE
                                {

                                    idTipoNegocio = int.Parse(fila["idTipoNegocio"].ToString()),
                                    tipoNegocio = fila["tipoNegocio"].ToString()

                                });
                            }
                        }
                        else
                        {
                            tiposNegocios = null;
                        }
                    }

                    if (fila.NextResult())
                    {

                        if (fila.HasRows)
                        {

                            while (fila.Read())
                            {

                                sectores.Add(new clSectorE
                                {

                                    idSector = int.Parse(fila["idSector"].ToString()),
                                    sector = fila["sector"].ToString()

                                });

                            }
                        }
                        else
                        {
                            sectores = null;
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

            return (municipios, tiposNegocios, sectores);
        }

        public int mtdValidarEmpresa(string nit = null, string correo = null)
        {

            int contador = 0;

            try
            {
                if (correo == null)
                {
                    SqlCommand cmd = new SqlCommand("spValidarEmpresa", objConexion.MtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@nit", nit);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();


                    SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                    DataTable fila = new DataTable();
                    adaptador.Fill(fila);

                    if (fila.Rows.Count > 0)
                    {
                        contador = 1;
                    }

                    objConexion.MtdCerrarConexion();

                }
                else
                {

                    SqlCommand cmd = new SqlCommand("spValidarEmpresa", objConexion.MtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();


                    SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                    DataTable fila = new DataTable();
                    adaptador.Fill(fila);

                    if (fila.Rows.Count > 0)
                    {
                        contador = 1;
                    }

                    objConexion.MtdCerrarConexion();
                }
            }
            catch (Exception e)
            {
                contador = 2;
                Console.WriteLine(e.Message);
                objConexion.MtdCerrarConexion();

            }

            return contador;

        }

    }

}

