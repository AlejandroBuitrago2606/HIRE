﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HIRE.Datos
{
    public class ClConexion
    {

        SqlConnection conex = null;

        public ClConexion()
        {

            conex = new SqlConnection("Data Source=.;Initial Catalog=dbProyectoHIRE;Integrated Security=True");

        }
        public SqlConnection MtdAbrirConexion()
        {

            conex.Open();
            return conex;
        }



        public void MtdCerrarConexion()
        {

            conex.Close();

        }
    }
}