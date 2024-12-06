using HIRE.Entidades;
using HIRE.Logica;
using System;

namespace HIRE.Vista
{
    public partial class menu : System.Web.UI.MasterPage
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            string sesion = Session["sesion"].ToString();

            string ruta = Request.Url.AbsolutePath.ToString();

            if (!IsPostBack)
            {
                if (ruta.Contains("Default") || ruta.Contains("busqueda") && sesion == "false")
                {


                    menuLateral.Visible = false;
                    opcionesAdministracion.Visible = false;
                    imgFotoPerfil.Visible = false;
                    logoutModal.Visible = false;
                    alerta.Visible = false;
                    barraDivisora.Visible = false;
                    menuSuperior.Attributes["style"] = "position: sticky";

                }
                else
                {
                    ftLogo.Visible = false;
                    pcsAutenticacion.Visible = false;
                    opcionesBusqueda.Visible = false;

                    clUsuarioL objTraerDatosUsuario = new clUsuarioL();
                    int idUsuario = int.Parse(Session["idUsuario"].ToString());
                    clUsuarioE objDatosEnvio = new clUsuarioE();
                    clUsuarioE objUsuarioE = new clUsuarioE();
                    objUsuarioE = objTraerDatosUsuario.mtdValidarUsuario(objDatosEnvio = null, idUsuario);


                    if (objUsuarioE != null)
                    {
                        txtNombreUsuario.InnerText = objUsuarioE.nombre + " " + objUsuarioE.apellido;

                        // Verifica si la foto es null o vacía
                        if (string.IsNullOrEmpty(objUsuarioE.foto))
                        {
                            imgFotoPerfil.Src = "recursos/imagenes/perfil.png";
                        }
                        else
                        {
                            imgFotoPerfil.Src = ResolveUrl(objUsuarioE.foto.ToString()); // Ya no se necesita .ToString()
                        }
                    }

                }

            }

        }



        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Default.aspx");

        }
    }
}