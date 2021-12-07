using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string modificado = Request.QueryString["modificado"].ToString();
            lblModificado.Text = modificado + " modificado exitosamente.";
        }
        protected void Click_Volver(object sender, EventArgs e)
        {
            string modificado = Request.QueryString["modificado"].ToString();
            if (modificado == "Médico")
            {
                Response.Redirect("Medicos.aspx", false);
            }
            else if (modificado == "Paciente")
            {
                Response.Redirect("Pacientes.aspx", false);
            }
            else if (modificado == "Empleado")
            {
                Response.Redirect("Empleados.aspx", false);
            }
            else if (modificado == "Usuario")
            {
                Response.Redirect("Usuarios.aspx", false);
            }
            else if (modificado == "Cobertura")
            {
                Response.Redirect("Coberturas.aspx", false);
            }
            else if (modificado == "Especialidad")
            {
                Response.Redirect("SpecialtysViews.aspx", false);
            }
            else if (modificado == "Historia clínica")
            {
                Response.Redirect("HistoriaClinica.aspx", false);
            }
            else if (modificado == "Turno")
            {
                Response.Redirect("VerTurno.aspx", false);
            }
        }
    }
}
