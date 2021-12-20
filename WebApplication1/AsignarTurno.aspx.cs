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
    public partial class prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario userLog = (Usuario)Session["Usuario"];

            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "Debes iniciar sesión");
                Response.Redirect("ErrorIngreso.aspx", false);
            }
            else if (userLog.UsuarioMedico(userLog))
            {
                Session.Add("Error", "Acceso denegado"); ;
                Response.Redirect("ErrorPermisosAcceso.aspx", false);

            }
            if (!IsPostBack)
            {
                EspecialidadDB espDB = new EspecialidadDB();
                EmpleadoDB empledoDB = new EmpleadoDB();
                EstadoTurnoDB estadoDB = new EstadoTurnoDB();
                MedicoDB medicoDB = new MedicoDB();

                List<Especialidad> esp = espDB.lista();
                ddlistEspecialidad.DataSource = esp;
                ddlistEspecialidad.DataTextField = "Nombre";
                ddlistEspecialidad.DataValueField = "ID";
                ddlistEspecialidad.DataBind();
                ddlistEspecialidad.Items.Insert(0, new ListItem("Seleccionar Especialidad", "0"));

                List<MedicoEspecialidades> espMedicos = medicoDB.listarEspecialidadesMedico();
                Session["listaMedicoEsp"] = espMedicos;
                ddlistMedico.DataSource = espMedicos;
                ddlistMedico.DataTextField = "NombreCompleto";
                ddlistMedico.DataValueField = "ID";
                ddlistMedico.DataBind();
                ddlistMedico.Items.Insert(0, new ListItem("Seleccionar Médico", "0"));

                MultiView.ActiveViewIndex = 0;
                lblPaciente.Font.Bold = true;
                lblPaciente.ForeColor = System.Drawing.Color.RoyalBlue;
                lblServicio.ForeColor = System.Drawing.Color.Gray;
                lblHorario.ForeColor = System.Drawing.Color.Gray;

            }
 

        }

        protected void btn0a1_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 1;
            lblPaciente.Font.Bold = false;
            lblPaciente.ForeColor = System.Drawing.Color.Gray;
            lblServicio.Font.Bold = true;
            lblServicio.ForeColor = System.Drawing.Color.RoyalBlue;

        }
        protected void btn1a2_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            MultiView.ActiveViewIndex = 2;
            lblServicio.Font.Bold = false;
            lblServicio.ForeColor = System.Drawing.Color.Gray;
            lblHorario.Font.Bold = true;
            lblHorario.ForeColor = System.Drawing.Color.RoyalBlue;
        }
        protected void btn1a0_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 0;
            lblServicio.Font.Bold = false;
            lblServicio.ForeColor = System.Drawing.Color.Gray;
            lblPaciente.Font.Bold = true;
            lblPaciente.ForeColor = System.Drawing.Color.RoyalBlue;

        }
        protected void btn2a1_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 1;
            lblHorario.Font.Bold = false;
            lblHorario.ForeColor = System.Drawing.Color.Gray;
            lblServicio.Font.Bold = true;
            lblServicio.ForeColor = System.Drawing.Color.RoyalBlue;
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            PacienteDB pacienteDB = new PacienteDB();
            List<Paciente> listapacientes = pacienteDB.listarPaciente();
            Paciente datosPaciente = listapacientes.Find(x => x.DNI == txtDNI.Text);

            if (datosPaciente == null)
            {
                txtPaciente.Text = "Paciente inexistente";

                txtDNI.Text = "";
                txtCobertura.Visible = false;
                ddlistEspecialidad.Enabled = false;
                ddlistMedico.Enabled = false;
                Calendario.Enabled = false;
                ddlistHora.Enabled = false;
            }
            else
            {
                txtPaciente.Text = "Nombre: " + datosPaciente.NombreCompleto;
                txtCobertura.Text = "Cobertura: " + datosPaciente.Cobertura.Nombre;

                txtCobertura.Visible = true;
                ddlistEspecialidad.Enabled = true;
                ddlistMedico.Enabled = false;
                Calendario.Enabled = false;
                ddlistHora.Enabled = false;
            }
        }

        protected void ddlistEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(ddlistEspecialidad.SelectedItem.Value);

            if (((List<MedicoEspecialidades>)Session["listaMedicoEsp"]).FindAll(x => x.especialidad.Id == ID) != null)
            {
                ddlistMedico.DataSource = ((List<MedicoEspecialidades>)Session["listaMedicoEsp"]).FindAll(x => x.especialidad.Id == ID);
                ddlistMedico.DataBind();
                ddlistMedico.Items.Insert(0, new ListItem("Seleccionar", "0"));

            }

            ddlistMedico.Enabled = true;
            Calendario.Enabled = true;
            ddlistHora.Enabled = false;

        }

        protected void Calendario_SelectionChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = true;
            if (IsPostBack)
            {
                ddlistHora.Items.Clear();
            }
            ddlistHora.Enabled = true;

            int espSeleccionada = int.Parse(ddlistEspecialidad.SelectedItem.Value);
            int medSeleccionado = int.Parse(ddlistMedico.SelectedItem.Value);


            DiasHabilesMedico horarioMedico = ((List<DiasHabilesMedico>)Session["listaFiltradaDiasHabiles"]).Find(x => x.IdDia == ((int)Calendario.SelectedDate.DayOfWeek)); //devuelve objeto de dias habiles segun el dia de la semana seleccionado
            DateTime horaInicio = horarioMedico.HorarioEntrada;
            System.TimeSpan horaSumar = new System.TimeSpan(0, 1, 0, 0);

            TurnoDB turnoDB = new TurnoDB();
            List<Turno> listaTurnos = turnoDB.listarTurno();
            List<Turno> turnosFiltradosMedico = listaTurnos.FindAll(x => x.Dia.ToShortDateString() == Calendario.SelectedDate.ToShortDateString() && x.Medico.ID == medSeleccionado && (x.Estado.Estado == "Programado" || x.Estado.Estado == "Reprogramado")); //lista con turnos programados del medico en el dia seleccionado
            List<Turno> turnosFiltradosPaciente = listaTurnos.FindAll(x => x.Dia.ToShortDateString() == Calendario.SelectedDate.ToShortDateString() && x.Paciente.DNI == txtDNI.Text && (x.Estado.Estado == "Programado" || x.Estado.Estado == "Reprogramado")); //lista con turnos programados del paciente en el dia seleccionado

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

        protected void ddlistMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            int medSeleccionado = int.Parse(ddlistMedico.SelectedItem.Value);
            Session.Add("medSeleccionado", medSeleccionado);
        }

        protected void Calendario_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Day.IsSelectable = false;
            int espSeleccionada = int.Parse(ddlistEspecialidad.SelectedItem.Value);
            if ((Session["medSeleccionado"]) != null)
            {
                MedicoDB medicoDB = new MedicoDB();
                int medSeleccionado = int.Parse(ddlistMedico.SelectedItem.Value);
                List<DiasHabilesMedico> listaDiasHabiles = medicoDB.listarDiasHabiles();
                List<DiasHabilesMedico> listaFiltrada = listaDiasHabiles.FindAll(x => x.Especialidad.Id == espSeleccionada && x.Medico.ID == medSeleccionado);
                Session.Add("listaFiltradaDiasHabiles", listaFiltrada);

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

        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            Turno NuevoTurno = new Turno();
            TurnoDB cargar = new TurnoDB();
            string agregado = "Turno";
            string error = "turno";

            PacienteDB pacienteDB = new PacienteDB();
            List<Paciente> pacientes = pacienteDB.listarPaciente();

            Usuario userLog = (Usuario)Session["Usuario"];
            EmpleadoDB empleadoLogDB = new EmpleadoDB();
            Empleado empleadoLog = new Empleado();
            empleadoLog = empleadoLogDB.empleadoLogueado((int)userLog.IDUsuario);


            try
            {
                NuevoTurno.Paciente = pacientes.Find(x => x.DNI == txtDNI.Text);
                NuevoTurno.Especialidad = new Especialidad();
                NuevoTurno.Especialidad.Id = int.Parse(ddlistEspecialidad.SelectedItem.Value);
                NuevoTurno.Especialidad.Nombre = ddlistEspecialidad.SelectedItem.Text;
                NuevoTurno.Medico = new Medico();
                NuevoTurno.Medico.ID = int.Parse(ddlistMedico.SelectedItem.Value);
                NuevoTurno.Medico.NombreCompleto = ddlistMedico.SelectedItem.Text;
                NuevoTurno.Dia = Calendario.SelectedDate;
                NuevoTurno.HorarioInicio = DateTime.Parse(ddlistHora.SelectedItem.Value);
                NuevoTurno.Observaciones = txtObservaciones.Text;
                NuevoTurno.AdministrativoResponsable = new Empleado();
                NuevoTurno.AdministrativoResponsable.ID = empleadoLog.ID; //int.Parse(ddlistRecepcionista.SelectedItem.Value);
                NuevoTurno.Estado = new EstadoTurno();
                NuevoTurno.Estado.ID = 1;

                cargar.agregar(NuevoTurno);
                List<Turno> listaturnos = cargar.listarTurno();

                Turno ultTurno = listaturnos.FindLast(x => x.Paciente.ID == NuevoTurno.Paciente.ID);
                NuevoTurno.Numero = ultTurno.Numero;
                Session.Add("NuevoTurno", NuevoTurno);

                Response.Redirect("AgregarCorrecto.aspx?agregado=" + agregado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
            }
        }

        protected void CustomValidatorEspecialidad_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(ddlistEspecialidad.SelectedIndex == 0)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidatorMedico_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlistMedico.SelectedIndex == 0)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}