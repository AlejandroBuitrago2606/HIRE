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
                if (ruta.Contains("inicio") || ruta.Contains("busqueda") && sesion == "false")
                {


                    menuLateral.Visible = false;
                    opcionesAdministracion.Visible = false;
                    imgFotoPerfil.Visible = false;
                    logoutModal.Visible = false;
                    alerta.Visible = false;
                    barraDivisora.Visible = false;
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


                    if (objUsuarioE.foto == "")
                    {
                        txtNombreUsuario.InnerText = objUsuarioE.nombre + " " + objUsuarioE.apellido;
                        imgFotoPerfil.Src = "recursos/imagenes/perfil.png";


                    }
                    else
                    {
                        txtNombreUsuario.InnerText = objUsuarioE.nombre + " " + objUsuarioE.apellido;

                        if (ruta.Contains("inicio") && sesion == "false")
                        {
                            imgFotoPerfil.Src = "recursos/imagenes/perfil.png";
                        }
                        else
                        {
                            imgFotoPerfil.Src = ResolveUrl("recursos/fotosPerfil/" + objUsuarioE.foto.ToString());
                            imgFotoPerfil.Alt = "error";
                        }
                    }

                }

            }

        }



        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("inicio.aspx");

        }
    }
}