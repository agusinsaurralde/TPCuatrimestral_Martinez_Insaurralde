using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Formulario_web122 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string error = Request.QueryString["error"].ToString();
            lblAgregado.Text = "Hubo un problema al agregar el " + error + ".";
        }
        protected void Click_Volver(object sender, EventArgs e)
        {
            string error = Request.QueryString["error"].ToString();

            if (error == "turno")
            {
                Response.Redirect("AsignarTurnos.aspx", false);
            }
            else if (error == "médico")
            {
                Response.Redirect("AgregarMedico.aspx", false);
            }
            else if (error == "paciente")
            {
                Response.Redirect("AgregarPaciente.aspx", false);
            }
            else if (error == "empleado")
            {
                Response.Redirect("AgregarEmpleado.aspx", false);
            }
            else if (error == "usuario")
            {
                Response.Redirect("AgregarUsuario.aspx", false);
            }
            else if (error == "cobertura")
            {
                Response.Redirect("AgregarCobertura.aspx", false);
            }
            else if (error == "especialidad")
            {
                Response.Redirect("AgregarEspecialidad.aspx", false);
            }
        }
    }
}
