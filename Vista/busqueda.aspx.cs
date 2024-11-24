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
    public partial class busqueda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                clVacanteL objVacanteL = new clVacanteL();
                cbMunicipios.DataSource = objVacanteL.mtdListarFiltros().Item1;
                cbContratos.DataSource = objVacanteL.mtdListarFiltros().Item2;
                cbEmpleos.DataSource = objVacanteL.mtdListarFiltros().Item3;
                cbMunicipios.DataBind();
                cbContratos.DataBind();
                cbEmpleos.DataBind();
                rpVacantes.DataSource = objVacanteL.mtdBuscarVacante();
                rpVacantes.DataBind();
            }



        }

        protected void buscarVacante_ServerClick(object sender, EventArgs e)
        {
            clVacanteE objVacante = new clVacanteE();
            string parametros = "";

            parametros = string.IsNullOrEmpty(txtParametros.Text) ? null : txtParametros.Text;


            objVacante.municipio = string.IsNullOrEmpty(cbMunicipios.SelectedValue) ? null : cbMunicipios.SelectedValue;
            objVacante.tipoContrato = string.IsNullOrEmpty(cbContratos.SelectedValue) ? null : cbContratos.SelectedValue;
            objVacante.tipoEmpleo = string.IsNullOrEmpty(cbEmpleos.SelectedValue) ? null : cbEmpleos.SelectedValue;

            clVacanteL objVacanteL = new clVacanteL();
            List<clVacanteE> objVacantes = objVacanteL.mtdBuscarVacante(objVacante, parametros);

            rpVacantes.DataSource = objVacantes;
            rpVacantes.DataBind();





        }
    }
}