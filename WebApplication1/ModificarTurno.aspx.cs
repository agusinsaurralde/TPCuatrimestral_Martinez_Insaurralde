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
            Usuario userLog = (Usuario)Session["Usuario"];

            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "Debes iniciar sesión");
                Response.Redirect("ErrorIngreso.aspx", false);
            }


            if (!IsPostBack)
            {
                List<EstadoTurno> estado = estadoDB.listar();
                ddlistEstado.DataSource = estado;
                ddlistEstado.DataTextField = "Estado";
                ddlistEstado.DataValueField = "ID";
                ddlistEstado.DataBind();

                //provisiorio
                EmpleadoDB empleadoDB = new EmpleadoDB();
                List<Empleado> emp = empleadoDB.listarRecepcionista();
                ddlistRecepcionista.DataSource = emp;
                ddlistRecepcionista.DataTextField = "NombreCompleto";
                ddlistRecepcionista.DataValueField = "ID";
                ddlistRecepcionista.DataBind();

                Empleado empleaLog = new Empleado();
                empleaLog = empleadoDB.empleadoLogueado((int)userLog.IDUsuario);
                lblUsuarioLogueado.Text = empleaLog.NombreCompleto;


                /*List<Especialidad> listEspecialidad = especialidadBD.lista();
                ddlistEspecialidad.DataSource = listEspecialidad;
                ddlistEspecialidad.DataTextField = "Nombre";
                ddlistEspecialidad.DataValueField = "ID";
                ddlistEspecialidad.DataBind();

                List<MedicoEspecialidades> espMedicos = medicoBD.listarEspecialidadesMedico();
                Session["listaMedicoEsp"] = espMedicos;
                ddlistMedico.DataSource = espMedicos;
                ddlistMedico.DataTextField = "NombreCompleto";
                ddlistMedico.DataValueField = "ID";
                ddlistMedico.DataBind();*/

                if (Session["editarTurno"] != null) {
                    Turno turnoSesion = new Turno();
                    turnoSesion = (Turno)Session["editarTurno"];
                    lblNumeroTurno.Text = "N°: " + turnoSesion.Numero.ToString();

                    lblPaciente.Text = "Paciente: " + turnoSesion.Paciente.Nombre + " " + turnoSesion.Paciente.Apellido;

                    lblEspecialidad.Text = "Especialidad: " + turnoSesion.Especialidad.Nombre;
                    
                    lblMedico.Text = "Medico: " + turnoSesion.Medico.Nombre + " "+ turnoSesion.Medico.Apellido;


                    //Calendario.SelectedDate = turnoSesion.Dia;

                    //ddlistHora.Text = turnoSesion.HorarioInicio.ToString("HH:mm");

                    lblObservaciones.Text = "Observaciones:";
                    txtObservaciones.Text = turnoSesion.Observaciones;


                    ddlistRecepcionista.SelectedValue = turnoSesion.AdministrativoResponsable.ID.ToString();

                    ddlistEstado.SelectedValue = turnoSesion.Estado.ID.ToString();
                }
                
            }
           
        }

        protected void Calendario_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Day.IsSelectable = false;
            MedicoDB medicoDB = new MedicoDB();
            int espSeleccionada = ((Turno)Session["editarTurno"]).Especialidad.Id;
            int medSeleccionado = ((Turno)Session["editarTurno"]).Medico.ID;
            List<DiasHabilesMedico> listaDiasHabiles = medicoDB.listarDiasHabiles();
            List<DiasHabilesMedico> listaFiltrada = listaDiasHabiles.FindAll(x => x.Especialidad.Id == espSeleccionada && x.Medico.ID == medSeleccionado);
            Session.Add("listaFiltradaDiasHabiles", listaFiltrada);

            if (e.Day.Date <= DateTime.Now)
            {
                e.Day.IsSelectable = false;
            }
            foreach (DiasHabilesMedico obj in listaFiltrada)
            {
                switch (obj.NombreDia)
                {
                    case "Lunes":
                        if (obj.NombreDia == "Lunes")
                        {
                            if (e.Day.Date.DayOfWeek == DayOfWeek.Monday)
                            {
                                e.Day.IsSelectable = true;
                            }

                        }
                        break;
                    case "Martes":
                        if (obj.NombreDia == "Martes")
                        {
                            if (e.Day.Date.DayOfWeek == DayOfWeek.Tuesday)
                            {
                                e.Day.IsSelectable = true;
                            }

                        }
                        break;
                    case "Miércoles":
                        if (obj.NombreDia == "Miércoles")
                        {
                            if (e.Day.Date.DayOfWeek == DayOfWeek.Wednesday)
                            {
                                e.Day.IsSelectable = true;
                            }

                        }
                        break;
                    case "Jueves":
                        if (obj.NombreDia == "Jueves")
                        {
                            if (e.Day.Date.DayOfWeek == DayOfWeek.Thursday)
                            {
                                e.Day.IsSelectable = true;
                            }

                        }
                        break;
                    case "Viernes":
                        if (obj.NombreDia == "Viernes")
                        {
                            if (e.Day.Date.DayOfWeek == DayOfWeek.Friday)
                            {
                                e.Day.IsSelectable = true;
                            }

                        }
                        break;
                    case "Sábado":
                        if (obj.NombreDia == "Sábado")
                        {
                            if (e.Day.Date.DayOfWeek == DayOfWeek.Saturday)
                            {
                                e.Day.IsSelectable = true;
                            }

                        }
                        break;

                }

            }
            if (e.Day.Date <= DateTime.Now)
            {
                e.Day.IsSelectable = false;
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
           /* TurnoDB turno = new TurnoDB();
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
            lblMedico.Text = "Medico Nombre:";
            ddlistMedico.Text = turnitoChiquito.Medico.Nombre;
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
            ddlistEstado.SelectedItem.Text = turnitoChiquito.Estado.Estado.ToString();*/
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string modificado = "Turno";
            string error = "turno";
            try
            {

                Turno turnoModificado = new Turno();
                TurnoDB cargar = new TurnoDB();
                turnoModificado.Numero = ((Turno)Session["EditarTurno"]).Numero;

                turnoModificado.Paciente = new Paciente();
                turnoModificado.Paciente = ((Turno)Session["EditarTurno"]).Paciente;

                turnoModificado.Especialidad = new Especialidad();
                turnoModificado.Especialidad = ((Turno)Session["EditarTurno"]).Especialidad;

                turnoModificado.Medico = new Medico();
                turnoModificado.Medico = ((Turno)Session["EditarTurno"]).Medico;

                turnoModificado.HorarioInicio = DateTime.Parse(ddlistHora.SelectedItem.Text);
                turnoModificado.Dia = Calendario.SelectedDate;

                turnoModificado.Observaciones = txtObservaciones.Text;

                turnoModificado.AdministrativoResponsable = new Empleado();
                turnoModificado.AdministrativoResponsable.ID = int.Parse(ddlistRecepcionista.SelectedItem.Value);

                turnoModificado.Estado = new EstadoTurno();
                turnoModificado.Estado.ID = int.Parse(ddlistEstado.SelectedValue.ToString());
                turnoModificado.Estado.Estado = ddlistEstado.SelectedItem.Text;

                cargar.modificar(turnoModificado);

                Response.Redirect("ModificarCorrecto.aspx?modificado=" + modificado, false);
            }
            catch (Exception ex)
            {
                throw ex;
                //Response.Redirect("ErrorModificar.aspx?error=" + error, false);
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerTurno.aspx", false);
        }

        protected void ddlistEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* int ID = int.Parse(ddlistEspecialidad.SelectedItem.Value);

            ddlistMedico.DataSource = ((List<MedicoEspecialidades>)Session["listaMedicoEsp"]).FindAll(x => x.especialidad.Id == ID);
            ddlistMedico.DataBind();*/
        }
        protected void Calendario_SelectionChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ddlistHora.Items.Clear();
            }
            ddlistHora.Enabled = true;

            int espSeleccionada = ((Turno)Session["editarTurno"]).Especialidad.Id;
            int medSeleccionado = ((Turno)Session["editarTurno"]).Medico.ID;

            ddlistHora.Enabled = true;

            DiasHabilesMedico horarioMedico = ((List<DiasHabilesMedico>)Session["listaFiltradaDiasHabiles"]).Find(x => x.IdDia == ((int)Calendario.SelectedDate.DayOfWeek)); //devuelve objeto de dias habiles segun el dia de la semana seleccionado
            DateTime horaInicio = horarioMedico.HorarioEntrada;
            System.TimeSpan horaSumar = new System.TimeSpan(0, 1, 0, 0);
            TurnoDB turnoDB = new TurnoDB();
            List<Turno> listaTurnos = turnoDB.listarTurno();
            List<Turno> turnosFiltradosMedico = listaTurnos.FindAll(x => x.Dia.ToShortDateString() == Calendario.SelectedDate.ToShortDateString() && x.Medico.ID == medSeleccionado && (x.Estado.Estado == "Programado" || x.Estado.Estado == "Reprogramado")); //lista con turnos programados del medico en el dia seleccionado
            List<Turno> turnosFiltradosPaciente = listaTurnos.FindAll(x => x.Dia.ToShortDateString() == Calendario.SelectedDate.ToShortDateString() && x.Paciente.DNI == ((Turno)Session["editarTurno"]).Paciente.DNI && (x.Estado.Estado == "Programado" || x.Estado.Estado == "Reprogramado")); //lista con turnos programados del paciente en el dia seleccionado

            List<string> horarios = new List<string>();
            for (int x = 0; x < 3; x++) //guarda los horarios
            {
                horarios.Add(horaInicio.ToShortTimeString());
                ddlistHora.Items.Add(horaInicio.ToShortTimeString());
                horaInicio += horaSumar;
            }

            if (turnosFiltradosMedico != null)
            {
                foreach (string hora in horarios)
                {
                    Turno turnoProgramado = turnosFiltradosMedico.Find(x => x.HorarioInicio.ToString("HH:mm") == hora);
                    if (turnoProgramado != null)
                    {
                        ddlistHora.Items.Remove(hora);
                    }
                }
            }
            if (turnosFiltradosPaciente != null)
            {
                foreach (string hora in horarios)
                {
                    Turno turnoProgramado = turnosFiltradosPaciente.Find(x => x.HorarioInicio.ToString("HH:mm") == hora);
                    if (turnoProgramado != null)
                    {
                        ddlistHora.Items.Remove(hora);
                    }
                }
            }
        }
     
    }
}