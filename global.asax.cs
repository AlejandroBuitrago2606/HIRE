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

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            clUsuarioE objUsuario = new clUsuarioE();

            Session["sessionActiva"] = false;
            Session["idUsuario"] = 0;
            Session["sesion"] = "false";



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
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}