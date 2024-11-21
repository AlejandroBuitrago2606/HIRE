using HIRE.Entidades;
using System;
using System.Collections.Generic;
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


            return objVacanteE;

        }

    }

}