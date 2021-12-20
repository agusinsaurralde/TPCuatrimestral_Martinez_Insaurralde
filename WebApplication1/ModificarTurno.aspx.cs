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
            if (!IsPostBack)
            {
                 EstadoTurnoDB estadoDB = new EstadoTurnoDB();
                 EspecialidadDB especialidadBD = new EspecialidadDB();
                 MedicoDB medicoBD = new MedicoDB();
                 Usuario userLog = (Usuario)Session["Usuario"];

                 if (Session["Usuario"] == null)
                 {
                     Response.Redirect("LogIn.aspx");
                 }
                else if (userLog.UsuarioMedico(userLog))
                {
                    Session.Add("Error", "Acceso denegado");
                    Response.Redirect("ErroAccesoPermisos.aspx");
                }
                else 
                 { 

                 
                     EmpleadoDB empleadoDB = new EmpleadoDB();
                     List<Empleado> emp = empleadoDB.listarRecepcionista();

                     Empleado empleaLog = new Empleado();
                     empleaLog = empleadoDB.empleadoLogueado((int)userLog.IDUsuario);



                     if (Session["editarTurno"] != null) {
                         Turno turnoSesion = new Turno();
                         turnoSesion = (Turno)Session["editarTurno"];
                         lblNumeroTurno.Text =turnoSesion.Numero.ToString();

                         lblPaciente.Text = turnoSesion.Paciente.Nombre + " " + turnoSesion.Paciente.Apellido;

                         lblEspecialidad.Text = turnoSesion.Especialidad.Nombre;
                         
                         lblMedico.Text = turnoSesion.Medico.Nombre + " "+ turnoSesion.Medico.Apellido;
                         Calendario.SelectedDate = turnoSesion.Dia;
                         precargarHorariosDiaSeleccionado();
                         txtObservaciones.Text = turnoSesion.Observaciones;

                     }
                     
                 }
            }

        }

        protected void precargarHorariosDiaSeleccionado()
        {
            int numero = ((Turno)Session["editarTurno"]).Numero;
            string dia = (((Turno)Session["editarTurno"]).Dia).ToShortDateString();
            int idPaciente = ((Turno)Session["editarTurno"]).Paciente.ID;
            int idMedico = ((Turno)Session["editarTurno"]).Medico.ID;
            MedicoDB medicoDB = new MedicoDB();
            List<DiasHabilesMedico> lista = medicoDB.listarDiasHabiles();
            List<DiasHabilesMedico> listafiltrada = lista.FindAll(x => x.Medico.ID == idMedico);
            DiasHabilesMedico horarioMedico = listafiltrada.Find(x => x.IdDia == ((int)Calendario.SelectedDate.DayOfWeek)); //devuelve objeto de dias habiles segun el dia de la semana 
            DateTime horaInicio = horarioMedico.HorarioEntrada;
            System.TimeSpan horaSumar = new System.TimeSpan(0, 1, 0, 0);

            TurnoDB turnoDB = new TurnoDB();
            List<Turno> turnos = turnoDB.listarTurno();
            //guarda turnos que tengan programados el medico y/o paciente en el dia seleccionado excepto el turno a modificar

            List<Turno> filtrados = turnos.FindAll(x => (x.Numero != numero) && (x.Dia.ToShortDateString() == dia) && (x.Paciente.ID == idPaciente || x.Medico.ID == idMedico) && (x.Estado.Estado == "Programado" || x.Estado.Estado == "Reprogramado"));
            int canti = filtrados.Count;

            foreach (var item in filtrados)
            {
                DateTime diaT = item.Dia;
                DateTime hora = item.HorarioInicio;
                string paciente = item.Paciente.NombreCompleto;
                string medico = item.Medico.NombreCompleto;
            }
            //carga horarios
            List<string> horarios = new List<string>();
            for (int x = 0; x < 3; x++) //guarda los horarios
            {
                ddlistHora.Items.Add(horaInicio.ToShortTimeString());
                horaInicio += horaSumar;
            }

            int cant = ddlistHora.Items.Count;

            for (int i = 0; i < cant; i++)
            {
                foreach (var item in filtrados)
                {
                    if (ddlistHora.Items[i].Text == item.HorarioInicio.ToShortTimeString())
                    {
                        ddlistHora.Items[i].Enabled = false;
                    }
                }
               
            }

            ddlistHora.SelectedValue = (((Turno)Session["editarTurno"]).HorarioInicio).ToShortTimeString();

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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            Usuario userLog = (Usuario)Session["Usuario"];
            EmpleadoDB empleadoLogDB = new EmpleadoDB();
            Empleado empleadoLog = new Empleado();
            empleadoLog = empleadoLogDB.empleadoLogueado((int)userLog.IDUsuario);

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


                turnoModificado.HorarioInicio = DateTime.Parse(ddlistHora.SelectedItem.Value);
                turnoModificado.Dia = Calendario.SelectedDate;

                turnoModificado.Observaciones = txtObservaciones.Text;

                turnoModificado.AdministrativoResponsable = new Empleado();
                if (empleadoLog.TipoEmp.Nombre == "Recepcionista")
                {
                    turnoModificado.AdministrativoResponsable.ID = empleadoLog.ID; 
                }
                else
                {
                    turnoModificado.AdministrativoResponsable.ID = ((Turno)Session["EditarTurno"]).AdministrativoResponsable.ID;
                }

                turnoModificado.Estado = new EstadoTurno();
                turnoModificado.Estado.ID = 3;

                cargar.modificar(turnoModificado);

                EmailService emailService = new EmailService();
                emailService.armarCorreo(turnoModificado);
                try
                {
                    emailService.enviarEmail();
                    lblTurnoEmail.Text = "Se envió un mail de confimarción. ";
                }
                catch (Exception)
                {
                    lblTurnoEmail.Text = "Hubo un error al enviar el mail de confimarción.";

                }
                ejecutarModalModificarTurno();
            }
            catch (Exception )
            {
                ejecutarModalModificarTurnoCatch();
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Turnos.aspx", false);
        }

        protected void cargarHorarios()
        {
            int espSeleccionada = ((Turno)Session["editarTurno"]).Especialidad.Id;
            int medSeleccionado = ((Turno)Session["editarTurno"]).Medico.ID;
            int num = ((Turno)Session["editarTurno"]).Numero;
            DiasHabilesMedico horarioMedico = ((List<DiasHabilesMedico>)Session["listaFiltradaDiasHabiles"]).Find(x => x.IdDia == ((int)Calendario.SelectedDate.DayOfWeek)); //devuelve objeto de dias habiles segun el dia de la semana seleccionado
            DateTime horaInicio = horarioMedico.HorarioEntrada;
            System.TimeSpan horaSumar = new System.TimeSpan(0, 1, 0, 0);
            TurnoDB turnoDB = new TurnoDB();
            List<Turno> listaTurnos = turnoDB.listarTurno();
            List<Turno> turnosFiltradosMedico = listaTurnos.FindAll(x => x.Dia.ToShortDateString() == Calendario.SelectedDate.ToShortDateString() && x.Medico.ID == medSeleccionado && (x.Estado.Estado == "Programado" || x.Estado.Estado == "Reprogramado") && (x.Numero != num)); //lista con turnos programados del medico en el dia seleccionado excepto el turno a modificar
            List<Turno> turnosFiltradosPaciente = listaTurnos.FindAll(x => x.Dia.ToShortDateString() == Calendario.SelectedDate.ToShortDateString() && x.Paciente.DNI == ((Turno)Session["editarTurno"]).Paciente.DNI && (x.Estado.Estado == "Programado" || x.Estado.Estado == "Reprogramado") && (x.Numero != num)); //lista con turnos programados del paciente en el dia seleccionado excepto el turno a modificar

            //List<string> horarios = new List<string>();
            for (int x = 0; x < 3; x++) //guarda los horarios
            {
               // horarios.Add(horaInicio.ToShortTimeString());
                ddlistHora.Items.Add(horaInicio.ToShortTimeString());
                horaInicio += horaSumar;
            }

            int cant = ddlistHora.Items.Count;
            if (turnosFiltradosMedico != null)
            {
                for (int i = 0; i < cant; i++)
                {
                    Turno turnoProgramado = turnosFiltradosMedico.Find(x => x.HorarioInicio.ToString("HH:mm") == ddlistHora.Items[i].Text);
                    if (turnoProgramado != null)
                    {
                        ddlistHora.Items[i].Enabled = false;
                    }

                }    
            }
            if (turnosFiltradosPaciente != null)
            {
                for (int i = 0; i < cant; i++)
                {
                    Turno turnoProgramado = turnosFiltradosPaciente.Find(x => x.HorarioInicio.ToString("HH:mm") == ddlistHora.Items[i].Text);
                    if (turnoProgramado != null)
                    {
                        ddlistHora.Items[i].Enabled = false;
                    }

                }
                
            }


        }
        protected void Calendario_SelectionChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ddlistHora.Items.Clear();
            }
            cargarHorarios();

        }


        protected void btnCerrarModalModificarTurno_Click(object sender, EventArgs e)
        {
            Response.Redirect("Turnos.aspx", false);
        }


        protected void ejecutarModalModificarTurno()
        {

            lblTituloModificarTurno.Text = "Modificado! ";
            lblTurnoModal.Text = "El turno se modifico correctamente!";
            btnEditarTurno_Modal.Show();
        }

        protected void ejecutarModalModificarTurnoCatch()
        {
            lblTituloModificarTurno.Text = "Error! ";
            lblTurnoModal.Text = "No se pudieron guardar los cambios!";
            btnEditarTurno_Modal.Show();
        }
    }

}