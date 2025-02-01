using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                clUsuarioL objDatosL = new clUsuarioL();
                clUsuarioE objDatosUsuario = objDatosL.mtdValidarUsuario(null, int.Parse(Session["idUsuario"].ToString()));

                if (objDatosUsuario != null)
                {

                    string HoraActual = DateTime.Now.ToString("HH:mm:ss");
                    DateTime horaActual = DateTime.Parse(HoraActual);  // Primera hora
                    DateTime dia = DateTime.Parse("05:00:00");
                    DateTime tarde = DateTime.Parse("12:00:00");
                    DateTime noche = DateTime.Parse("19:00:00");


                    if (horaActual >= dia && horaActual < tarde)
                    {
                        msgBienvenida.InnerHtml = "Buenos dias" + " " + "<b>" + objDatosUsuario.nombre + "</b>";
                    }
                    else if (horaActual >= tarde && horaActual < noche)
                    {
                        msgBienvenida.InnerHtml = "Buenas tardes" + " " + "<b>" + objDatosUsuario.nombre + "</b>";
                    }
                    else if (horaActual >= noche || horaActual < dia)
                    {
                        msgBienvenida.InnerHtml = "Buenas noches" + " " + "<b>" + objDatosUsuario.nombre + "</b>";
                    }

                }

            }

        }
    }
}