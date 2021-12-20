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
    public partial class AltaPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario userLog = (Usuario)Session["Usuario"];

                if (userLog == null)
                {
                    Response.Redirect("LogIn.aspx");
                }
                else if (userLog.TipoUsuario.Nombre == "Médico")
                {
                    Session.Add("Error", "Acceso denegado"); ;
                    Response.Redirect("ErrorPermisosAcceso.aspx", false);

                }


            }
        }



        protected void Click_Aceptar(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            Paciente modPaciente = new Paciente();
            PacienteDB cargar = new PacienteDB();

            try
            {
                modPaciente.ID = (int)Session["ID"];
                modPaciente.DNI = txtDNI.Text;
                modPaciente.Apellido = txtApellido.Text;
                modPaciente.Nombre = txtNombre.Text;
                modPaciente.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                modPaciente.Telefono = txtTelefono.Text;
                modPaciente.Email = txtEmail.Text;
                modPaciente.Dirección = txtDireccion.Text;
                modPaciente.Estado = true;
                modPaciente.Cobertura = new Cobertura();
                modPaciente.Cobertura.Id = int.Parse(ddlistCobertura.SelectedItem.Value);


                cargar.modificar(modPaciente);

                lblTituloAlertModal.Text = "Alta paciente";
                lblVerificacion.Text = "El paciente " + modPaciente.Nombre + " " + modPaciente.Apellido + " fue dado de alta con éxito.";
                verificacion_Modal.Show();
            }
            catch (Exception)
            {
                lblTituloAlertModal.Text = "Error";
                lblVerificacion.Text = "Hubo un problema al dar de alta el paciente.";
                verificacion_Modal.Show();

            }

        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                PacienteDB pacienteDB = new PacienteDB();
                List<Paciente> lista = pacienteDB.listarPacienteInactivo();
                Paciente paciente = lista.Find(x => x.DNI == txtDNI.Text);



                if (paciente != null)
                {
                    Session.Add("ID", paciente.ID);
                    RangeValidator.MaximumValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    RangeValidator.MinimumValue = DateTime.Now.Date.AddYears(-100).ToString("yyyy-MM-dd");

                    CoberturaDB db = new CoberturaDB();
                    List<Cobertura> cobertura = db.lista();
                    ddlistCobertura.DataSource = cobertura;
                    ddlistCobertura.DataTextField = "Nombre";
                    ddlistCobertura.DataValueField = "ID";
                    ddlistCobertura.DataBind();

                    txtDNI.Text = paciente.DNI;
                    txtApellido.Text = paciente.Apellido;
                    txtNombre.Text = paciente.Nombre;
                    ddlistCobertura.SelectedValue = paciente.Cobertura.Nombre.ToString();
                    txtFechaNac.Text = paciente.FechaNacimiento.ToString("yyyy-MM-dd");
                    txtTelefono.Text = paciente.Telefono;
                    txtEmail.Text = paciente.Email;
                    txtDireccion.Text = paciente.Dirección;
 
                }
                else
                {

                    lblTituloAlertModal.Text = "Error";
                    lblVerificacion.Text = "Hubo un problema al dar de alta el empleado.";
                    verificacion_Modal.Show();
                }


            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                //throw ex;
            }
        }


        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx", false);
        }
    }
}