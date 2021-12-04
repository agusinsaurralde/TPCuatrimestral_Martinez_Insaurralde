using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using DBClinica;
// La idea es de donde se muestran los turnos, trasladar el N° de turno hasta la pagina para editar el turno.
namespace WebApplication1
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EstadoTurnoDB estadoDB = new EstadoTurnoDB();
            EspecialidadDB especialidadBD = new EspecialidadDB();

            if (!IsPostBack)
            {
                List<EstadoTurno> estado = estadoDB.listar();
                ddlistEstado.DataSource = estado;
                ddlistEstado.DataTextField = "Estado";
                ddlistEstado.DataValueField = "ID";
                ddlistEstado.DataBind();

                List<Especialidad> listEspecialidad = especialidadBD.lista();
                ddlistEspecialidad.DataSource = listEspecialidad;
                ddlistEspecialidad.DataTextField = "Nombre";
                ddlistEspecialidad.DataValueField = "ID";
                ddlistEspecialidad.DataBind();


                if (Session["editar"] != null) {
                    Turno turnoSesion = new Turno();
                    turnoSesion = (Turno)Session["editar"];
                    lblNumeroTurno.Text = "N° Turno" + turnoSesion.Numero.ToString();
                    lblPacienteNombre.Text = "Nombre de Paciente:";
                    txtPacienteNombre.Text = turnoSesion.Paciente.Nombre;

                    lblPacienteApellido.Text = "Apellido del Paciente:";
                    txtPacienteApellido.Text = turnoSesion.Paciente.Apellido;

                    lblEspecialidad.Text = "Especialidad:";
                    ddlistEspecialidad.Text = turnoSesion.Especialidad.Nombre;
                    ddlistEspecialidad.DataValueField = turnoSesion.Especialidad.Id.ToString();
                    
                    lblMedicoNombre.Text = "Medico Nombre:";
                    ddlistMedicoNombre.Text = turnoSesion.Medico.Nombre;
                    lblMedicoApellido.Text = "Medico Apellido";
                    ddlistMedicoApellido.Text = turnoSesion.Medico.Apellido;

                    lblHoraInicio.Text = "Hora de inicio del turno:";
                    txtHoraInicio.Text = turnoSesion.HorarioInicio.ToString("HH:mm");

                    lblHoraFin.Text = "Hora de fin del turno";
                    txtHoraFin.Text = turnoSesion.HorarioFin.ToString("HH:mm");

                    lblFecha.Text = "Fecha del turno:";
                    txtFecha.Text = turnoSesion.Dia.ToString("dd/MM/yyyy");

                    lblObservaciones.Text = "Observaciones:";
                    txtObservaciones.Text = turnoSesion.Observaciones;

                    lblEmpleadoNombre.Text = "Nombre Empleado:";
                    txtEmpleadoNombre.Text = turnoSesion.AdministrativoResponsable.Nombre;

                    lblEmpleadoApellido.Text = "Apellido Empleado:";
                    txtEmpleadoApellido.Text = turnoSesion.AdministrativoResponsable.Apellido;

                    ddlistEstado.SelectedItem.Text = turnoSesion.Estado.Estado.ToString();
                }
                
            }
            else // sin este else se pisa el drown down list del estado del turno
            {
                List<EstadoTurno> estado = estadoDB.listar();
                ddlistEstado.DataSource = estado;
                ddlistEstado.DataTextField = "Estado";
                ddlistEstado.DataValueField = "ID";
                ddlistEstado.DataBind();

                List<Especialidad> listEspecialidad = especialidadBD.lista();
                ddlistEspecialidad.DataSource = listEspecialidad;
                ddlistEspecialidad.DataTextField = "Nombre";
                ddlistEspecialidad.DataValueField = "ID";
                ddlistEspecialidad.DataBind();
            }
        }
        //protected void Click_Aceptar(object sender, EventArgs e)
        //{
        //    Response.Redirect("ModificarTurno.aspx",false);
        //}

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            TurnoDB turno = new TurnoDB();
            Turno turnitoChiquito = new Turno();
            int NumeroTurno = int.Parse(txtBuscar.Text.ToString());
            turnitoChiquito=turno.buscarTurno(NumeroTurno);
            lblNumeroTurno.Text = "N° Turno: " + turnitoChiquito.Numero.ToString();
            lblPacienteNombre.Text = "Nombre de Paciente:";
            txtPacienteNombre.Text = turnitoChiquito.Paciente.Nombre;
            lblPacienteApellido.Text = "Apellido del Paciente:";
            txtPacienteApellido.Text = turnitoChiquito.Paciente.Apellido;
            lblEspecialidad.Text = "Especialidad:";
            ddlistEspecialidad.DataTextField = turnitoChiquito.Especialidad.Nombre; // khe?
            ddlistEspecialidad.SelectedValue = turnitoChiquito.Especialidad.Id.ToString();
            lblMedicoNombre.Text = "Medico Nombre:";
            ddlistMedicoNombre.Text = turnitoChiquito.Medico.Nombre;
            lblMedicoApellido.Text = "Medico Apellido";
            ddlistMedicoApellido.Text = turnitoChiquito.Medico.Apellido;
            lblHoraInicio.Text = "Hora de inicio del turno:";
            txtHoraInicio.Text = turnitoChiquito.HorarioInicio.ToString("HH:mm");
            lblHoraFin.Text = "Hora de fin del turno";
            txtHoraFin.Text = turnitoChiquito.HorarioFin.ToString("HH:mm");
            lblFecha.Text = "Fecha del turno:";
            txtFecha.Text = turnitoChiquito.Dia.ToString("dd/MM/yyyy");
            lblObservaciones.Text = "Observaciones:";
            txtObservaciones.Text = turnitoChiquito.Observaciones;
            lblEmpleadoNombre.Text = "Nombre Empleado:";
            txtEmpleadoNombre.Text = turnitoChiquito.AdministrativoResponsable.Nombre;
            lblEmpleadoApellido.Text = "Apellido Empleado:";
            txtEmpleadoApellido.Text = turnitoChiquito.AdministrativoResponsable.Apellido;
            ddlistEstado.SelectedItem.Text = turnitoChiquito.Estado.Estado.ToString();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Turno turnoModificado = new Turno();
            TurnoDB cargar = new TurnoDB();
            turnoModificado.Numero = int.Parse(lblNumeroTurno.Text);
            turnoModificado.Paciente.Nombre = txtPacienteNombre.Text;
            turnoModificado.Paciente.Apellido = txtPacienteApellido.Text;
            turnoModificado.Especialidad.Id = int.Parse(ddlistEspecialidad.SelectedItem.Value.ToString());// 
            turnoModificado.Especialidad.Nombre = ddlistEspecialidad.Text;

            turnoModificado.Medico.Nombre = ddlistMedicoNombre.Text; //de aca tiene q salir un ddlist en el que muestre los medicos dependiendo de la especialidad seleccionada.
            turnoModificado.Medico.Apellido = ddlistMedicoApellido.Text;
            turnoModificado.HorarioInicio = DateTime.Parse(txtHoraInicio.Text);
            turnoModificado.HorarioFin = DateTime.Parse(txtHoraFin.Text);
            turnoModificado.Dia = DateTime.Parse(txtFecha.Text);
            turnoModificado.Observaciones = txtObservaciones.Text;
            turnoModificado.AdministrativoResponsable.Nombre = txtEmpleadoNombre.Text;
            turnoModificado.AdministrativoResponsable.Apellido = txtEmpleadoApellido.Text;
            turnoModificado.Estado.ID = int.Parse(ddlistEstado.SelectedValue.ToString());
            turnoModificado.Estado.Estado = ddlistEstado.SelectedItem.Text;
            cargar.modificar(turnoModificado);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Session.Clear(); // esto limpia hasta la sesion iniciada para ver los turnos.
            EstadoTurnoDB estadoDB = new EstadoTurnoDB();
            List<EstadoTurno> estado = estadoDB.listar();
            ddlistEstado.DataSource = estado;
            ddlistEstado.DataTextField = "Estado";
            ddlistEstado.DataValueField = "ID";
            ddlistEstado.DataBind();

            lblNumeroTurno.Text = "";
            lblPacienteNombre.Text = "Nombre de Paciente:";
            txtPacienteNombre.Text = "";
            lblPacienteApellido.Text = "Apellido del Paciente:";
            txtPacienteApellido.Text = "";
            lblEspecialidad.Text = "Especialidad:";
            ddlistEspecialidad.Text = "";
            lblMedicoNombre.Text = "Medico Nombre:";
            ddlistMedicoNombre.Text = "";
            lblMedicoApellido.Text = "Medico Apellido";
            ddlistMedicoApellido.Text = "";
            lblHoraInicio.Text = "Hora de inicio del turno:";
            txtHoraInicio.Text = "";
            lblHoraFin.Text = "Hora de fin del turno";
            txtHoraFin.Text = "";
            lblFecha.Text = "Fecha del turno:";
            txtFecha.Text = "";
            lblObservaciones.Text = "Observaciones:";
            txtObservaciones.Text = "";
            lblEmpleadoNombre.Text = "Nombre Empleado:";
            txtEmpleadoNombre.Text = "";
            lblEmpleadoApellido.Text = "Apellido Empleado:";
            txtEmpleadoApellido.Text = "";
            //ddlistEstado.SelectedItem.Text = "";
        }

        protected void ddlistEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> idListaMedicosxEspecialidad = new List<int>();
            List<Medico> medicoList = new List<Medico>();
            MedicoDB listaMedicoDB = new MedicoDB();
            //medicoList = listaMedicoDB.listarMedico().FindAll(x=> x.Especialidad.Id == )
        }
    }
}