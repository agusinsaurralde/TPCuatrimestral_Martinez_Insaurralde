using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using DBClinica;

namespace WebApplication1
{
    public partial class Formulario_web22 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtCobertura.Text = ((Cobertura)Session["modificar"]).Nombre;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                //throw ex;
            }

        }
        protected void Click_Aceptar(object sender, EventArgs e)
        {
            Cobertura modCobertura = new Cobertura();
            CoberturaDB cargar = new CoberturaDB();
            string modificado = "Cobertura";
            string error = "cobertura";

            try
            {
                modCobertura.Id = ((Cobertura)Session["modificar"]).Id;
                modCobertura.Nombre = txtCobertura.Text;

                cargar.ModificarCobertura(modCobertura);

                Response.Redirect("ModificarCorrecto.aspx?modificado=" + modificado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorModificar.aspx?error=" + error, false);
            }

        }

        protected void Click_Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("Coberturas.aspx", false);
        }
    }
}
