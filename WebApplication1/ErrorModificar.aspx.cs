using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Formulario_web123 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string error = Request.QueryString["error"].ToString();
            lblModificado.Text = "Hubo un problema al modificar el " + error + ".";
        }
        protected void Click_Volver(object sender, EventArgs e)
        {
            string error = Request.QueryString["error"].ToString();
            if (error == "médico")
            {
                Response.Redirect("ModificarMedico.aspx", false);
            }
            else if (error == "paciente")
            {
                Response.Redirect("ModificarPaciente.aspx", false);
            }
            else if (error == "empleado")
            {
                Response.Redirect("ModificarEmpleado.aspx", false);
            }
            else if (error == "usuario")
            {
                Response.Redirect("ModificarUsuario.aspx", false);
            }
            else if (error == "cobertura")
            {
                Response.Redirect("ModificarCobertura.aspx", false);
            }
            else if (error == "especialidad")
            {
                Response.Redirect("ModificarEspecialidad.aspx", false);
            }
            else if (error == "historia clínica")
            {
                Response.Redirect("HistoriaClinica.aspx", false);
            }
            else if (error == "turno")
            {
                Response.Redirect("VerTurno.aspx", false);
            }
        }
    }
}
