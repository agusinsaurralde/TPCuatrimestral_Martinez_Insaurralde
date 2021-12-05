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
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EstadoTurnoDB estadoDB = new EstadoTurnoDB();
            EspecialidadDB especialidadBD = new EspecialidadDB();
            MedicoDB medicoBD = new MedicoDB();

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

                List<Medico> listMedico = medicoBD.listarMedico();
                ddlistMedicoNombre.DataSource = listMedico;
                ddlistMedicoApellido.DataSource = listMedico;
                ddlistMedicoNombre.DataTextField = "Nombre";
                ddlistMedicoApellido.DataTextField = "Apellido";
                ddlistMedicoNombre.DataValueField = "ID";
                ddlistMedicoApellido.DataValueField = "ID";
                ddlistMedicoNombre.DataBind();
                ddlistMedicoApellido.DataBind();

                if (Session["editarTurno"] != null) {
                    Turno turnoSesion = new Turno();
                    turnoSesion = (Turno)Session["editarTurno"];
                    lblNumeroTurno.Text = "N° Turno" + turnoSesion.Numero.ToString();
                    lblPacienteNombre.Text = "Nombre de Paciente:";
                    txtPacienteNombre.Text = turnoSesion.Paciente.Nombre;

                    lblPacienteApellido.Text = "Apellido del Paciente:";
                    txtPacienteApellido.Text = turnoSesion.Paciente.Apellido;

                    lblEspecialidad.Text = "Especialidad:";
                    ddlistEspecialidad.Text = turnoSesion.Especialidad.Nombre;
                    ddlistEspecialidad.DataValueField = turnoSesion.Especialidad.Id.ToString();
                    
                    lblMedicoNombre.Text = "Medico Nombre:";
                    ddlistMedicoNombre.SelectedItem.Text = turnoSesion.Medico.Nombre; // tira error, supongo que cuando se cargue la grilla de especialidades y tire la orden esta se cargara sola
                    lblMedicoApellido.Text = "Medico Apellido";
                    ddlistMedicoApellido.SelectedItem.Text = turnoSesion.Medico.Apellido;

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
            //else // sin este else se pisa el drown down list del estado del turno
            //{
            //    List<EstadoTurno> estado = estadoDB.listar();
            //    ddlistEstado.DataSource = estado;
            //    ddlistEstado.DataTextField = "Estado";
            //    ddlistEstado.DataValueField = "ID";
            //    ddlistEstado.DataBind();

            //    List<Especialidad> listEspecialidad = especialidadBD.lista();
            //    ddlistEspecialidad.DataSource = listEspecialidad;
            //    ddlistEspecialidad.DataTextField = "Nombre";
            //    ddlistEspecialidad.DataValueField = "ID";
            //    ddlistEspecialidad.DataBind();

            //    List<Medico> listMedico = medicoBD.listarMedico();
            //    ddlistMedicoNombre.DataSource = listMedico;
            //    ddlistMedicoApellido.DataSource = listMedico;
            //    ddlistMedicoNombre.DataTextField = "Nombre";
            //    ddlistMedicoApellido.DataTextField = "Apellido";
            //    ddlistMedicoNombre.DataValueField = "ID";
            //    ddlistMedicoApellido.DataValueField = "ID";
            //    ddlistMedicoNombre.DataBind();
            //    ddlistMedicoApellido.DataBind();
            //}
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
            //turnoModificado.Numero = int.Parse(lblNumeroTurno.Text);

            turnoModificado.Paciente = new Paciente();
            turnoModificado.Paciente.Nombre = txtPacienteNombre.Text.ToString();
            turnoModificado.Paciente.Apellido = txtPacienteApellido.Text;

            turnoModificado.Especialidad = new Especialidad();
            turnoModificado.Especialidad.Id = int.Parse(ddlistEspecialidad.SelectedItem.Value.ToString());// 
            turnoModificado.Especialidad.Nombre = ddlistEspecialidad.SelectedItem.Text;

            turnoModificado.Medico = new Medico();
            turnoModificado.Medico.Nombre = ddlistMedicoNombre.SelectedItem.Text;
            turnoModificado.Medico.Apellido = ddlistMedicoApellido.SelectedItem.Text;

            turnoModificado.HorarioInicio = DateTime.Parse(txtHoraInicio.Text);
            turnoModificado.HorarioFin = DateTime.Parse(txtHoraFin.Text);
            turnoModificado.Dia = DateTime.Parse(txtFecha.Text);

            turnoModificado.Observaciones = txtObservaciones.Text;

            turnoModificado.AdministrativoResponsable = new Empleado();
            turnoModificado.AdministrativoResponsable.Nombre = txtEmpleadoNombre.Text;
            turnoModificado.AdministrativoResponsable.Apellido = txtEmpleadoApellido.Text;

            turnoModificado.Estado = new EstadoTurno();
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
            // los medicos no tienen ID especialidad en la DB.
            // si o si tenes que compárar contra la tabla que tiene EspecialidadXmedico
            int ID = int.Parse(ddlistEspecialidad.SelectedItem.Value);
            MedicoDB dato = new MedicoDB();
            List<Medico> listMedico = dato.listarMedicoXEspecialidad(ID);
            ddlistMedicoNombre.DataSource = listMedico;
            ddlistMedicoNombre.DataTextField = "Nombre";
            ddlistMedicoNombre.DataValueField = "Id";
            ddlistMedicoNombre.DataBind();
            ddlistMedicoApellido.DataSource = listMedico;
            ddlistMedicoApellido.DataTextField = "Apellido";
            ddlistMedicoApellido.DataValueField = "Id";
            ddlistMedicoApellido.DataBind();
        }
    }
}