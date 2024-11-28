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
                ArrayList municipios = objListarMunicipios.mtdListarFiltros().Item1;

                cbMunicipios.DataSource = municipios;
                cbMunicipios.DataBind();

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
    }
}