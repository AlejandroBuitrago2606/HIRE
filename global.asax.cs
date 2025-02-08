using HIRE.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace HIRE
{
    public class global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["objDatosU"] = null;

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
            new ScriptResourceDefinition
            {
                Path = "https://code.jquery.com/jquery-3.6.0.min.js",
                DebugPath = "https://code.jquery.com/jquery-3.6.0.js"
            });

        }

        protected void Session_Start(object sender, EventArgs e)
        {


            Session["sessionActiva"] = false;
            Session["idUsuario"] = 0;
            Session["sesion"] = "false";
            Session["autenticacion"] = "";
            Session["ruta"] = "";
            Session["correoEnviado"] = "false";
            Session["registro"] = false;
            Session["codigo"] = "";            
            Session["contador"] = 0;
            Session["fotoEmpresa"] = "";
            Session["coordenadas"] = "";
            Session["idCV"] = "";

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
            Session["ruta"] = "";
            Session["correoEnviado"] = "false";
            Session["registro"] = false;
            Session["codigo"] = "";
            Session["contador"] = 0;
            Session["fotoEmpresa"] = "";
            Session["coordenadas"] = "";            
            Session["idCV"] = "";

        }

        protected void Application_End(object sender, EventArgs e)
        {
            Application["objDatosU"] = null;
        }
    }
}