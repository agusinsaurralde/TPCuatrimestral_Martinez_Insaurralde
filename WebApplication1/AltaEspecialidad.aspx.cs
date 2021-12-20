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
    public partial class AltaEspecialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario userlog = (Usuario)Session["Usuario"];
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("LogIn.aspx", false);
                }
                else if (userlog.TipoUsuario.Nombre == "Médico")
                {
                    Session.Add("Error", "Acceso denegado"); ;
                    Response.Redirect("ErrorPermisosAcceso.aspx", false);

                }
                else if (userlog.TipoUsuario.Nombre == "Recepcionista")
                {
                    Session.Add("Error", "Acceso denegado"); ;
                    Response.Redirect("ErrorPermisosAcceso.aspx", false);

                }
            }
            
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            EspecialidadDB especialidadDB = new EspecialidadDB();
            List<Especialidad> lista = especialidadDB.listaInactivo();
            Especialidad especialidad = lista.Find(x => x.Id == int.Parse(txtEspecialidad.Text));

            if (especialidad != null)
            {
                Session.Add("especialidad", especialidad);
                lblCobertura.ForeColor = System.Drawing.Color.Green;
                lblCobertura.Text = "Especialidad: " + especialidad.Nombre;

            }
            else
            {
                lblCobertura.ForeColor = System.Drawing.Color.Red;
                lblCobertura.Text = "*No se encontraron resultados";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                EspecialidadDB especialidadDB = new EspecialidadDB();
                Especialidad especialidad = new Especialidad();

                if ((Especialidad)Session["especialidad"] != null)
                {
                    especialidad.Id = ((Cobertura)Session["especialidad"]).Id;
                    especialidad.Estado = true;
                    especialidad.Nombre = ((Cobertura)Session["cobertura"]).Nombre;
                    especialidadDB.ModificarEspecialidad(especialidad);
                    lblTituloAlertModal.Text = "Alta de especialidad";
                    lblVerificacion.Text = "La especialidad fue dada de alta exitosamente.";
                    verificacion_Modal.Show();
                }

            }
            catch (Exception)
            {

                lblTituloAlertModal.Text = "Error";
                lblVerificacion.Text = "Hubo un problema al dar el alta de la especialidad.";
                verificacion_Modal.Show();
            }

        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("SpecialtysViews.aspx");
        }
    }
}