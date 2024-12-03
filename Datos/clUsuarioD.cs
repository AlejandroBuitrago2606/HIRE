using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using HIRE.Entidades;
using HIRE.Logica;

namespace HIRE.Datos
{
    public class clUsuarioD
    {
        ClConexion objConexion = new ClConexion();
        public clUsuarioE mtdValidarUsuario(clUsuarioE objUsuario, int idUsuario)
        {
            clUsuarioE objDatosE = new clUsuarioE();

            try
            {

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

        public clUsuarioE mtdRecuperarContrasena(string idUsuario = null, string correo = null, string contrasena = null)
        {

            clUsuarioE objUsuarioE = new clUsuarioE();

            if (correo == null)
            {


                try
                {

                    SqlCommand cmd = new SqlCommand("spRecuperarContrasena", objConexion.MtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@idUsuario", int.Parse(idUsuario));
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    objUsuarioE.validar = true;

                }
                catch (Exception e)
                {
                    objUsuarioE.validar = false;
                    Console.WriteLine(e.Message);
                }









            }
            else
            {


                try
                {
                    SqlCommand cmd = new SqlCommand("spRecuperarContrasena", objConexion.MtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader fila = cmd.ExecuteReader())
                    {

                        if (fila.HasRows)
                        {
                            while (fila.Read())
                            {

                                objUsuarioE.idUsuario = int.Parse(fila["idUsuario"].ToString());
                                objUsuarioE.nombre = fila["nombre"].ToString();
                                objUsuarioE.apellido = fila["apellido"].ToString();
                                objUsuarioE.correo = fila["correo"].ToString();
                                objUsuarioE.validar = true;
                            }

                        }
                        else
                        {
                            objUsuarioE.validar = false;
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

            return objUsuarioE;

        }

    }

}
