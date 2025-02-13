using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace HIRE.Datos
{
    public class clSolicitudD
    {
        ClConexion objConexion = new ClConexion();

        public bool mtdEvaluarSolicitud(int idSolicitud, int estado)
        {

            bool validar = false;
            try
            {

                SqlCommand cmd = new SqlCommand("spEvaluarSolicitud", objConexion.MtdAbrirConexion());
                cmd.Parameters.AddWithValue("@idSolicitud", idSolicitud);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                objConexion.MtdCerrarConexion();
                validar = true;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


            return validar;

        }



    }
}