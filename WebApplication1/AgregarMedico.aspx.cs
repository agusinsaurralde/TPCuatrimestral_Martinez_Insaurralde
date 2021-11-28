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
    public partial class Formulario_web113 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            TurnoTrabajoDB ttdb = new TurnoTrabajoDB();
            EspecialidadDB espDB = new EspecialidadDB();
            try
            {
                if (!IsPostBack)
                { 
                    List<TurnoTrabajo> turnot = ttdb.listar();
                    ddlistTurno.DataSource = turnot;
                    ddlistTurno.DataTextField = "NombreTurno";
                    ddlistTurno.DataValueField = "ID";
                    ddlistTurno.DataBind();

                    List<Especialidad> esp = espDB.lista();
                    ddlistEspecialidad.DataSource = esp;
                    ddlistEspecialidad.DataTextField = "Nombre";
                    ddlistEspecialidad.DataValueField = "ID";
                    ddlistEspecialidad.DataBind();
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
            Medico NuevoMedico = new Medico();
            MedicoDB cargar = new MedicoDB();
            string agregado = "Médico";
            string error = "médico";

            try
            { 
                NuevoMedico.DNI = txtDNI.Text.ToString();
                NuevoMedico.Matricula = txtMatricula.Text.ToString();
                NuevoMedico.Apellido = txtApellido.Text.ToString();
                NuevoMedico.Nombre = txtNombre.Text.ToString();
                NuevoMedico.Especialidad = new Especialidad();
                NuevoMedico.Especialidad.Id = int.Parse(ddlistEspecialidad.SelectedItem.Value);
                NuevoMedico.FechaNacimiento = DateTime.Parse(txtFechaNac.Text.ToString());
                NuevoMedico.Telefono = txtTelefono.Text.ToString();
                NuevoMedico.Email = txtEmail.Text.ToString();
                NuevoMedico.Dirección = txtDireccion.Text.ToString();
                NuevoMedico.Turno = new TurnoTrabajo();
                NuevoMedico.Turno.ID = int.Parse(ddlistTurno.SelectedItem.Value);
                NuevoMedico.HorarioEntrada = DateTime.Parse(txtEntrada.Text.ToString());
                NuevoMedico.HorarioSalida = DateTime.Parse(txtSalida.Text.ToString());
                NuevoMedico.Estado = true;
                cargar.agregar(NuevoMedico);

                Response.Redirect("AgregarCorrecto.aspx?agregado=" + agregado, false);
            }
            catch (Exception )
            {
                Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
            }
            
        }
    }
}