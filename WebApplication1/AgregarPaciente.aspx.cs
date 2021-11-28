using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Dominio;
using DBClinica;

namespace WebApplication1
{
    public partial class Formulario_web112 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CoberturaDB cobDB = new CoberturaDB();
            try
            {
                if (!IsPostBack)
                {
                    List<Cobertura> cobertura = cobDB.lista();
                    ddlistCobertura.DataSource = cobertura;
                    ddlistCobertura.DataTextField = "Nombre";
                    ddlistCobertura.DataValueField = "ID";
                    ddlistCobertura.DataBind();
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
            Paciente NuevoPaciente = new Paciente();
            PacienteDB cargar = new PacienteDB();
            string agregado = "Paciente";
            string error = "paciente";

            try
            {
                NuevoPaciente.DNI = txtDNI.Text.ToString();
                NuevoPaciente.Apellido = txtApellido.Text.ToString();
                NuevoPaciente.Nombre = txtNombre.Text.ToString();
                NuevoPaciente.Cobertura = new Cobertura();
                NuevoPaciente.Cobertura.Id = int.Parse(ddlistCobertura.SelectedItem.Value);
                NuevoPaciente.FechaNacimiento = DateTime.Parse(txtFechaNac.Text.ToString());
                NuevoPaciente.Telefono = txtTelefono.Text.ToString();
                NuevoPaciente.Email = txtEmail.Text.ToString();
                NuevoPaciente.Dirección = txtDireccion.Text.ToString();
                NuevoPaciente.Estado = true;
                cargar.agregar(NuevoPaciente);

                Response.Redirect("AgregarCorrecto.aspx?agregado=" + agregado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
            }

        }
    }
}