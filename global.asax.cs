using HIRE.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace HIRE
{
    public class global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["objDatosU"] = null;
        }

        protected void Session_Start(object sender, EventArgs e)
        {


            Session["sessionActiva"] = false;
            Session["idUsuario"] = 0;
            Session["sesion"] = "false";
            Session["autenticacion"] = "";
            Session["correoUsuario"] = "";
            Session["ruta"] = "";
            Session["correoEnviado"] = "false";
            Session["registro"] = "false";
            Session["codigo"] = "";
            Session["foto"] = "";

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

            Session["sessionActiva"] = false;
            Session["idUsuario"] = 0;
            Session["sesion"] = "false";
            Session["autenticacion"] = "";
            Session["correoUsuario"] = "";
            Session["ruta"] = "";
            Session["correoEnviado"] = "false";
            Session["registro"] = "false";
            Session["codigo"] = "";
            
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Application["objDatosU"] = null;
        }
    }
}