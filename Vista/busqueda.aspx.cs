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

            }

        }

        protected void buscarVacante_ServerClick(object sender, EventArgs e)
        {

        }
    }
}