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

        public List<clEmpresaE> mtdListarEmpresas(int id)
        {
            List<clEmpresaE>objEmpresaDatos = new List<clEmpresaE>();

            try
            {
                ClConexion objConexion = new ClConexion();
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
                objEmpresaDatos.Add(new clEmpresaE{ validacion = false });
                Console.WriteLine(e.Message);
            }


            return objEmpresaDatos;

        }


    }
}