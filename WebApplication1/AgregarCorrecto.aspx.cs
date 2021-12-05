using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBClinica;

namespace WebApplication1
{
    public partial class Formulario_web120 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string agregado = Request.QueryString["agregado"].ToString();
            lblAgregado.Text = agregado + " agregado exitosamente.";
            if (agregado == "Turno")
            {
                EmailService emailService = new EmailService();
                emailService.armarCorreo((Dominio.Turno)Session["NuevoTurno"]);
                try
                {
                    emailService.enviarEmail();
                    lblTurno.Text = "Se envió un mail de confimarción.";
                }
                catch (Exception ex)
                {
                    throw ex;
                    //Session.Add("error", ex);
                }
            }
                
        }
        protected void Click_Volver(object sender, EventArgs e)
        {
            string agregado = Request.QueryString["agregado"].ToString();
            if (agregado == "Turno")
            {
                Response.Redirect("VerTurno.aspx", false);
            }
            else if(agregado == "Paciente")
            {
                Response.Redirect("Pacientes.aspx", false);
            }
            else if (agregado == "Médico")
            {
                Response.Redirect("Medicos.aspx", false);
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
                Response.Redirect("SpecialtysViews.aspx", false);
            }
        }
    }
}