using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using HIRE.Entidades;

namespace HIRE.Datos
{
    public class clUsuarioD
    {

        public clUsuarioE mtdValidarUsuario(clUsuarioE objUsuario, int idUsuario)
        {
            clUsuarioE objDatosE = new clUsuarioE();

            try
            {
                ClConexion objConexion = new ClConexion();
                SqlCommand cmd = new SqlCommand("spValidarUsuario", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@correo", objUsuario.correo.ToString());
                cmd.Parameters.AddWithValue("@contrasena", objUsuario.contrasena.ToString());
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure; //le especifico que es un SP
                cmd.ExecuteNonQuery();//ejecutar consulta SP


                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tblDatos = new DataTable();
                adaptador.Fill(tblDatos);

                if (tblDatos.Rows.Count > 0)
                {
                    foreach (DataRow fila in tblDatos.Rows)
                    {

                        objDatosE.validar = true;
                        objDatosE.idUsuario = int.Parse(fila["idUsuario"].ToString());
                        objDatosE.nombre = fila["nombre"].ToString();
                        objDatosE.apellido = fila["apellido"].ToString();

                    }

                }
                else
                {
                    objDatosE.validar = false;
                }
                objConexion.MtdCerrarConexion();

            }

            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return objDatosE;
        }
        public clUsuarioE mtdTraerUsuario(int idUsuario)
        {
            clUsuarioE objDatosE = new clUsuarioE();

            try
            {
                ClConexion objConexion = new ClConexion();
                SqlCommand cmd = new SqlCommand("spValidarUsuario", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.CommandType = CommandType.StoredProcedure; //le especifico que es un SP
                cmd.ExecuteNonQuery();//ejecutar consulta SP
                objConexion.MtdCerrarConexion();

                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable tblDatos = new DataTable();
                adaptador.Fill(tblDatos);

                if (tblDatos.Rows.Count > 0)
                {
                    foreach (DataRow fila in tblDatos.Rows)
                    {

                        objDatosE.validar = true;
                        objDatosE.idUsuario = int.Parse(fila["idUsuario"].ToString());
                        objDatosE.nombre = fila["nombre"].ToString();
                        objDatosE.apellido = fila["apellido"].ToString();
                        objDatosE.foto = fila["foto"].ToString();

                    }

                }
                else
                {
                    objDatosE.validar = false;
                }


            }

            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return objDatosE;
        }



    }
}