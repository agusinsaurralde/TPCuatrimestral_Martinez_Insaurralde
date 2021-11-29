using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Formulario_web124 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string eliminado = Request.QueryString["eliminado"].ToString();
            lblEliminado.Text = eliminado + " eliminado exitosamente.";
        }
        protected void Click_Volver(object sender, EventArgs e)
        {
            string eliminado = Request.QueryString["eliminado"].ToString();
            if (eliminado == "Médico")
            {
                Response.Redirect("Medicos.aspx", false);
            }
            else if (eliminado == "Paciente")
            {
                Response.Redirect("Pacientes.aspx", false);
            }
            else if (eliminado == "Empleado")
            {
                Response.Redirect("Empleados.aspx", false);
            }
            else if (eliminado == "Usuario")
            {
                Response.Redirect("Usuarios.aspx", false);
            }
            else if (eliminado == "Cobertura")
            {
                Response.Redirect("Coberturas.aspx", false);
            }
            else if (eliminado == "Especialidad")
            {
                Response.Redirect("SpecialitysViews.aspx", false);
            }
        }
    }
}
