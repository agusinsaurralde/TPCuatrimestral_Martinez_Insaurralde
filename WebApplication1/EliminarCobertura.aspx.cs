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
    public partial class Formulario_web32 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNombre.Text = ((Cobertura)Session["eliminar"]).Nombre;
            }
        }

        protected void Click_Aceptar(object sender, EventArgs e)
        {
            string eliminado = "Cobertura";
            string error = "cobertura";
            try
            {
                Cobertura cobertura = new Cobertura();
                CoberturaDB db = new CoberturaDB();
                cobertura = (Cobertura)Session["eliminar"];
                db.EliminarCobertura(cobertura);

                Response.Redirect("EliminarCorrecto.aspx?eliminado=" + eliminado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorEliminar.aspx?error=" + error, false);
            }
        }
        protected void Click_Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("Coberturas.aspx", false);
        }
    }
}
