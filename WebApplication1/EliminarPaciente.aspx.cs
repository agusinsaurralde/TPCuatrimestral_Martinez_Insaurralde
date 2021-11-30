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
    public partial class Formulario_web3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNombre.Text = ((Paciente)Session["eliminar"]).Nombre + " " + ((Paciente)Session["eliminar"]).Apellido;
            }

        }

        protected void Click_Aceptar(object sender, EventArgs e)
        {
            string eliminado = "Paciente";
            string error = "paciente";
            try
            {
                Paciente paciente = new Paciente();
                PacienteDB db = new PacienteDB();
                paciente = (Paciente)Session["eliminar"];
                db.eliminar(paciente);

                int id = paciente.ID;

                Response.Redirect("EliminarCorrecto.aspx?eliminado=" + eliminado, false);
            }
            catch (Exception)
            {
               Response.Redirect("ErrorEliminar.aspx?error=" + error, false);
            }

        }
        protected void Click_Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx", false);
        }
    }
}
