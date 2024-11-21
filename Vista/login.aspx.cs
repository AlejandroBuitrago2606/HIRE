using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Web.UI;


namespace HIRE.Vista
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCorreo.Attributes["required"] = "required";
                txtContrasena.Attributes["required"] = "required";
                txtCorreo.Text = "";
                txtContrasena.Text = "";

            }

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            clUsuarioL objUsuarioL = new clUsuarioL();
            clUsuarioE objDatosU = new clUsuarioE();
            objDatosU.correo = txtCorreo.Text;
            objDatosU.contrasena = txtContrasena.Text;

            clUsuarioE objDatosE = objUsuarioL.mtdValidarUsuario(objDatosU, 0);

            if (objDatosE.validar == true)
            {
                string nombreCompleto = objDatosE.nombre + " " + objDatosE.apellido;
                Session["idUsuario"] = objDatosE.idUsuario;
                Session["sesion"] = "true";

                string alerta = "alertify.alert('Iniciaste Sesion', 'Bienvenido " + nombreCompleto + " ').set('onok', function(closeEvent){ window.location.href = 'index.aspx'; });";
                ClientScript.RegisterStartupScript(this.GetType(), "alertify", alerta, true);
                

            }
            else
            {

                string alerta = "alertify.error('El usuario no existe');";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertify", alerta, true);

            }


        }


    }
}