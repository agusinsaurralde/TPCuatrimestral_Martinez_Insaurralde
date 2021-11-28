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
    public partial class Formulario_web2 : System.Web.UI.Page
    {

        protected void Page_Load(Paciente modPaciente)
        {
            
        }
        protected void Click_Aceptar(object sender, EventArgs e)
        {
            Paciente ModPaciente = new Paciente();
            PacienteDB cargar = new PacienteDB();
            string modificado = "Paciente";
            string error = "paciente";

            try
            {
                ModPaciente.DNI = txtDNI.Text;
                ModPaciente.Apellido = txtApellido.Text;
                ModPaciente.Nombre = txtNombre.Text;
                ModPaciente.Cobertura = new Cobertura();
                ModPaciente.Cobertura.Id = int.Parse(ddlistCobertura.SelectedItem.Value);
                ModPaciente.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                ModPaciente.Telefono = txtTelefono.Text;
                ModPaciente.Email = txtEmail.Text;
                ModPaciente.Dirección = txtDireccion.Text;
                ModPaciente.Estado = true;
                cargar.modificar(ModPaciente);

                Response.Redirect("AgregarCorrecto.aspx?modificado=" + modificado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
            }

        }
    }
}