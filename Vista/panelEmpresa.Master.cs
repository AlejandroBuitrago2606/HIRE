using HIRE.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class panelEmpresa : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {

                clEmpresaL objClEmpresaL = new clEmpresaL();
                clEmpresaE datosEmpresa = objClEmpresaL.mtdTraerEmpresa(int.Parse(Session["idEmpresa"].ToString())).Item1;

                if (!string.IsNullOrEmpty(datosEmpresa.foto))
                {
                    imgEmpresa.Src = ResolveUrl(datosEmpresa.foto);
                }
                else
                {
                    imgEmpresa.Src = ResolveUrl("~/Vista/recursos/fotosEmpresa/default.png");
                }

                h6NombreEmpresa.InnerText = datosEmpresa.nombre;



            }

        }
    }
}