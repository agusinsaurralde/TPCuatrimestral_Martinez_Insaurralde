using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Formulario_web120 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string agregado = Request.QueryString["agregado"].ToString();
            lblAgregado.Text = agregado + " agregado exitosamente.";
        }
        protected void Click_Volver(object sender, EventArgs e)
        {
            string agregado = Request.QueryString["agregado"].ToString();
            if (agregado == "Médico")
            {
                Response.Redirect("Medicos.aspx", false);
            }
            else if(agregado == "Paciente")
            {
                Response.Redirect("Pacientes.aspx", false);
            }
            else if (agregado == "Empleado")
            {
                Response.Redirect("Empleados.aspx", false);
            }
            else if (agregado == "Usuario")
            {
                Response.Redirect("Usuarios.aspx", false);
            }
            else if (agregado == "Cobertura")
            {
                Response.Redirect("Coberturas.aspx", false);
            }
            else if (agregado == "Especialidad")
            {
                Response.Redirect("SpecialitysViews.aspx", false);
            }
        }
    }
}