using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class panelTrabajador : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                clUsuarioL objDatosL = new clUsuarioL();
                clUsuarioE objDatosUsuario = objDatosL.mtdValidarUsuario(null, int.Parse(Session["idUsuario"].ToString()));

                if (objDatosUsuario != null)
                {
                    if (string.IsNullOrEmpty(objDatosUsuario.foto))
                    {
                        imgUsuario.Src = ResolveUrl("recursos/imagenes/perfil.png");
                    }
                    else
                    {
                        imgUsuario.Src = ResolveUrl(objDatosUsuario.foto);
                    }
                    h6NombreUsuario.InnerText = objDatosUsuario.nombre + " " + objDatosUsuario.apellido + " (" + objDatosUsuario.estado + ") ";

                }
            }
        }
    }
}