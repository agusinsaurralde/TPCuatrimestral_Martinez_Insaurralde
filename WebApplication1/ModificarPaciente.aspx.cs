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
            Usuario userLog = (Usuario)Session["Usuario"];

            if ((Paciente)Session["modificar"] == null)
            {
                Response.Redirect("ErrorPermisosAcceso");
            }
            else if (userLog.TipoUsuario.Nombre == "Médico")
            {
                Session.Add("Error", "Acceso denegado"); ;
                Response.Redirect("ErrorPermisosAcceso.aspx", false);

            }
           
            CoberturaDB db = new CoberturaDB();
            try
            {
                if (!IsPostBack)
                {
                    RangeValidator.MaximumValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    RangeValidator.MinimumValue = DateTime.Now.Date.AddYears(-100).ToString("yyyy-MM-dd");

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
                    txtFechaNac.Text = paciente.FechaNacimiento.ToString("yyyy-MM-dd");
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
            if (!Page.IsValid)
                return;
            Paciente ModPaciente = new Paciente();
            PacienteDB cargar = new PacienteDB();


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

                lblVerificacion.Text = "Paciente modificado exitosamente.";
                verificacion_Modal.Show();
            }
            catch (Exception)
            {
                lblTituloAlertModal.Text = "Error";
                lblVerificacion.Text = "Hubo un problema al modificar el paciente.";
                verificacion_Modal.Show();
            }

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx");

        }
        protected void CustomValidatorDNIInactivo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            PacienteDB pacienteDB = new PacienteDB();
            List<Paciente> inactivos = pacienteDB.listarPacienteInactivo();
            if (inactivos.Find(x => x.DNI == args.Value) != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        protected void CustomValidatorDNI_ServerValidate(object source, ServerValidateEventArgs args)
        {
            PacienteDB pacienteDB = new PacienteDB();
            List<Paciente> lista = pacienteDB.listarPaciente();
            if (lista.Find(x => x.DNI == args.Value && x.Estado == true && x.ID != ((Paciente)Session["modificar"]).ID) != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx");
        }
    }
}