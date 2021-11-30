using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Formulario_web125 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string error = Request.QueryString["error"].ToString();
            lblEliminado.Text = "Hubo un problema al eliminar el " + error + ".";
        }
        protected void Click_Volver(object sender, EventArgs e)
        {
            string error = Request.QueryString["error"].ToString();
            if (error == "médico")
            {
                Response.Redirect("Medicos.aspx", false);
            }
            else if (error == "paciente")
            {
                Response.Redirect("Pacientes.aspx", false);
            }
            else if (error == "empleado")
            {
                Response.Redirect("Empleados.aspx", false);
            }
            else if (error == "usuario")
            {
                Response.Redirect("Usuarios.aspx", false);
            }
            else if (error == "cobertura")
            {
                Response.Redirect("Coberturas.aspx", false);
            }
            else if (error == "especialidad")
            {
                Response.Redirect("SpecialityViews.aspx", false);
            }
        }
    }
}
