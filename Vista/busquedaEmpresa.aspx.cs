using HIRE.Entidades;
using HIRE.Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class busquedaEmpresa : System.Web.UI.Page
    {
        clEmpresaL objEmpresaL = new clEmpresaL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                clEmpresaL objEmpresaL = new clEmpresaL();

                List<clEmpresaE> objEmpresas = objEmpresaL.mtdBuscarEmpresa();
                clVacanteL objListarMunicipios = new clVacanteL();
                List<clMunicipioE> listaMunicipios = objListarMunicipios.mtdListarFiltros().Item1;

                foreach (clMunicipioE municipio in listaMunicipios)
                {
                    cbMunicipios.Items.Add(new ListItem(municipio.nombre, municipio.idMunicipio.ToString()));                    
                }

                int totalEmpresas = objEmpresas.Count;

                txtTotalEmpresas.InnerText = totalEmpresas > 100 ? "Mas de 100 empresas existentes" : totalEmpresas + " " + "empresas existentes";
                rpEmpresas.DataSource = objEmpresas;
                rpEmpresas.DataBind();

                string sesion = Session["sesion"].ToString();
                if (sesion == "true")
                {
                    fila.Attributes["style"] = "margin-left: 3%;";
                    contenedorDerecho.Visible = false;
                    contenedorIzquierdo.Visible = false;
                    contenedorBusqueda.Attributes["class"] = "col-md-4";
                    contenedorRepeater.Attributes["class"] = "col-md-6";

                }

            }

        }

        protected void buscarEmpresaPorMunicipio(object sender, EventArgs e)
        {
            string municipioSeleccionado = cbMunicipios.SelectedItem.Text;


            List<clEmpresaE> objEmpresas = objEmpresaL.mtdBuscarEmpresa(null, municipioSeleccionado);

            int totalEmpresas = objEmpresas.Count;

            txtTotalEmpresas.InnerText = totalEmpresas + " " + "empresas existentes";


            rpEmpresas.DataSource = objEmpresas;
            rpEmpresas.DataBind();




        }

        protected void buscarEmpresa_ServerClick(object sender, EventArgs e)
        {

            string parametros = txtParametros.Text;

            List<clEmpresaE> objEmpresas = objEmpresaL.mtdBuscarEmpresa(parametros, null);

            int totalEmpresas = objEmpresas.Count;

            txtTotalEmpresas.InnerText = totalEmpresas + " " + "empresas existentes";


            rpEmpresas.DataSource = objEmpresas;
            rpEmpresas.DataBind();


        }

        protected void traerEmpresa_Click(object sender, CommandEventArgs e)
        {

            int idEmpresa = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "traerEmpresa")
            {

                clEmpresaL objEmpresaL = new clEmpresaL();

                clEmpresaE objDatosEmpresa = objEmpresaL.mtdTraerEmpresa(idEmpresa).Item1;
                List<clVacanteE> objVacantesE = objEmpresaL.mtdTraerEmpresa(idEmpresa).Item2;

                int totalVacantesPub = objVacantesE.Count;

                txtNombreEmpresa.InnerText = objDatosEmpresa.nombre;
                imgEmpresa.Src = ResolveUrl(objDatosEmpresa.foto);

                txtDescripcionEmpresa.InnerText = objDatosEmpresa.descripcion;
                txtNumeroEmpleados.InnerText = ": " +  objDatosEmpresa.numeroEmpleados;
                txtUbicacion.InnerText = ": " +  objDatosEmpresa.direccion + ", " + objDatosEmpresa.municipio;
                txtTelefono.InnerText = " " +  objDatosEmpresa.telefono1;
                txtCorreo.InnerText = " " + objDatosEmpresa.correo;
                Web.InnerText = " " + objDatosEmpresa.url;
                Web.HRef = ResolveUrl(objDatosEmpresa.url);
                txtVacantesPublicadas.InnerText = "Vacantes publicadas " + "(" +  totalVacantesPub.ToString() + ")";
                rpVacantesPublicadas.DataSource = objVacantesE;
                rpVacantesPublicadas.DataBind();




                string abrirModal = @"
                  $(document).ready(function () {
                  $('#datosEmpresa').modal('show');
                  });";


                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", abrirModal, true);

                


            }

        }

    }
}