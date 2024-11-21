using HIRE.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HIRE.Vista
{
    public partial class listaEmpresas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int idUsuario = int.Parse(Session["idUsuario"].ToString());
                clEmpresaL objEmpresaL = new clEmpresaL();
                List<clEmpresaE> objListaEmpresas = objEmpresaL.mtdListarEmpresas(idUsuario);



                foreach (clEmpresaE empresa in objListaEmpresas)
                {
                    if (empresa.validacion == false)
                    {
                        txtValidar.Text = "No tienes empresas creadas";
                        btnCrearEmpresa.Visible = true;
                    }
                    else
                    {
                        rpEmpresas.DataSource = objListaEmpresas;
                        rpEmpresas.DataBind();
                    }
                }









            }




        }

        protected void btnCrearEmpresa_Click(object sender, EventArgs e)
        {

        }
    }
}