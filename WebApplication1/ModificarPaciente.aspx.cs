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

        protected void Page_Load(object sender, EventArgs e)
        {
            CoberturaDB db = new CoberturaDB();
            try
            {
                if (!IsPostBack)
                {
                    List<Cobertura> cob = db.lista();
                    ddlistCobertura.DataSource = cob;
                    ddlistCobertura.DataTextField = "Nombre";
                    ddlistCobertura.DataValueField = "Id";
                    ddlistCobertura.DataBind();

                    Paciente paciente = new Paciente();
                    paciente = (Paciente)Session["modificar"];
                    txtDNI.Text = paciente.DNI;
                    txtApellido.Text = paciente.Apellido;
                    txtNombre.Text = paciente.Nombre;
                    ddlistCobertura.SelectedValue = paciente.Cobertura.Id.ToString();
                    txtFechaNac.Text = paciente.FechaNacimiento.ToString();
                    txtTelefono.Text = paciente.Telefono;
                    txtEmail.Text = paciente.Email;
                    txtDireccion.Text = paciente.Dirección;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                //throw ex;
            }
        }
        protected void Click_Aceptar(object sender, EventArgs e)
        {
            Paciente ModPaciente = new Paciente();
            PacienteDB cargar = new PacienteDB();
            string modificado = "Paciente";
            string error = "paciente";

            try
            {
                ModPaciente.ID = ((Paciente)Session["modificar"]).ID;
                ModPaciente.DNI = txtDNI.Text;
                ModPaciente.Apellido = txtApellido.Text;
                ModPaciente.Nombre = txtNombre.Text;
                ModPaciente.Cobertura = new Cobertura();
                ModPaciente.Cobertura.Id = int.Parse(ddlistCobertura.SelectedItem.Value);
                ModPaciente.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                ModPaciente.Telefono = txtTelefono.Text;
                ModPaciente.Email = txtEmail.Text;
                ModPaciente.Dirección = txtDireccion.Text;
                cargar.modificar(ModPaciente);

                Response.Redirect("ModificarCorrecto.aspx?modificado=" + modificado, false);
            }
            catch (Exception)
            {
                 Response.Redirect("ErrorModificar.aspx?error=" + error, false);
            }

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx");

        }
    }
}