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

        public int mtdRegistrarUsuario(clUsuarioE objDatosE = null, int idTipo = 0, int idUsuario = 0)
        {

            int idValorRetorno = 0;



            if (idTipo == 0 && idUsuario == 0)
            {


                try
                {
                    SqlCommand cmd = new SqlCommand("spRegistrarCuenta", objConexion.MtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@nombre", objDatosE.nombre);
                    cmd.Parameters.AddWithValue("@apellido", objDatosE.apellido);
                    cmd.Parameters.AddWithValue("@documento", objDatosE.documento);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", objDatosE.fechaNacimiento);
                    cmd.Parameters.AddWithValue("@estadoCivil", objDatosE.estadoCivil);
                    cmd.Parameters.AddWithValue("@numeroHijos", objDatosE.numeroHijos);
                    cmd.Parameters.AddWithValue("@correo", objDatosE.correo);
                    cmd.Parameters.AddWithValue("@telefono", objDatosE.telefono);
                    cmd.Parameters.AddWithValue("@direccion", objDatosE.direccion == null ? "" : objDatosE.direccion);
                    cmd.Parameters.AddWithValue("@ubicacion", objDatosE.ubicacion == null ? "" : objDatosE.ubicacion);
                    cmd.Parameters.AddWithValue("@foto", objDatosE.foto == null ? "" : objDatosE.foto);
                    cmd.Parameters.AddWithValue("@contrasena", objDatosE.contrasena);
                    cmd.Parameters.AddWithValue("@estado", objDatosE.estado);
                    cmd.Parameters.AddWithValue("@idMunicipio", objDatosE.idMunicipio);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Obtengo el parametro de salida
                    SqlParameter idUsuarioR = new SqlParameter("@parametroDevuelto", SqlDbType.Int)
                    {

                        Direction = ParameterDirection.Output

                    };
                    cmd.Parameters.Add(idUsuarioR);

                    cmd.ExecuteNonQuery();
                    objConexion.MtdCerrarConexion();

                    idValorRetorno = int.Parse(idUsuarioR.Value.ToString());



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
                    //Registrar tipoUsuario
                    SqlCommand cmd = new SqlCommand("spRegistrarCuenta", objConexion.MtdAbrirConexion());
                    cmd.Parameters.AddWithValue("@idTipo", idTipo);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter idTipoUsuarioR = new SqlParameter("@parametroDevuelto", SqlDbType.Int)
                    {

                        Direction = ParameterDirection.Output

                    };
                    cmd.Parameters.Add(idTipoUsuarioR);

                    cmd.ExecuteNonQuery();
                    objConexion.MtdCerrarConexion();

                    idValorRetorno = int.Parse(idTipoUsuarioR.Value.ToString());


                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);

                }

            }



            return idValorRetorno;

        }

    }

}
