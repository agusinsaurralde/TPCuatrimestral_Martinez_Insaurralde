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
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        MedicoDB medicoDB = new MedicoDB();
        TurnoDB turnoDB = new TurnoDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadDB espDB = new EspecialidadDB();
            EmpleadoDB empledoDB = new EmpleadoDB();
            EstadoTurnoDB estadoDB = new EstadoTurnoDB();


            if (!IsPostBack)
            {
                List<Especialidad> esp = espDB.lista();
                ddlistEspecialidad.DataSource = esp;
                ddlistEspecialidad.DataTextField = "Nombre";
                ddlistEspecialidad.DataValueField = "ID";
                ddlistEspecialidad.DataBind();
                ddlistEspecialidad.Items.Insert(0, new ListItem("Seleccionar Especialidad", "0"));

                //provisiorio
                List<Empleado> emp = empledoDB.listarRecepcionista();
                ddlistRecepcionista.DataSource = emp;
                ddlistRecepcionista.DataTextField = "NombreCompleto";
                ddlistRecepcionista.DataValueField = "ID";
                ddlistRecepcionista.DataBind();
                //provisiorio
                List<EstadoTurno> estado = estadoDB.listar();
                ddlistEstado.DataSource = estado;
                ddlistEstado.DataTextField = "Estado";
                ddlistEstado.DataValueField = "ID";
                ddlistEstado.DataBind();

                List<MedicoEspecialidades> espMedicos = medicoDB.listarEspecialidadesMedico();
                Session["listaMedicoEsp"] = espMedicos;
                ddlistMedico.DataSource = espMedicos;
                ddlistMedico.DataTextField = "NombreCompleto";
                ddlistMedico.DataValueField = "ID";
                ddlistMedico.DataBind();
                ddlistMedico.Items.Insert(0, new ListItem("Seleccionar", "0"));

            }

        }
       
        protected void Click_Buscar(object sender, EventArgs e)
        {
            PacienteDB pacienteDB = new PacienteDB();
            List<Paciente> listapacientes = pacienteDB.listarPaciente();
            Paciente datosPaciente = listapacientes.Find(x => x.DNI == txtDNI.Text);

            if (datosPaciente == null)
            {
                txtPaciente.Text = "Paciente inexistente";
                txtApellido.Text = "";
                txtNombre.Text = "";

                lblEspecialidad.Visible = false;
                ddlistEspecialidad.Visible = false;
                lblMedico.Visible = false;
                ddlistMedico.Visible = false;
                Calendario.Visible = false;
                lblHora.Visible = false;
                ddlistHora.Visible = false;
                lblObservaciones.Visible = false;
                txtObservaciones.Visible = false;
            }
            else
            {
                txtPaciente.Text = "Paciente existente";
                txtApellido.Text = "Apellido: " + datosPaciente.Apellido;
                txtNombre.Text = "Nombre: " + datosPaciente.Nombre;
                txtCobertura.Text = "Cobertura: " + datosPaciente.Cobertura.Nombre;

                lblEspecialidad.Visible = true;
                ddlistEspecialidad.Visible = true;
                lblMedico.Visible = true;
                ddlistMedico.Visible = false;
                Calendario.Visible = false;
                lblHora.Visible = false;
                ddlistHora.Visible = false;
                lblObservaciones.Visible = false;
                txtObservaciones.Visible = false;
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

            lblMedico.Visible = true;
            ddlistMedico.Visible = true;
            Calendario.Visible = true;
            lblHora.Visible = false;
            ddlistHora.Visible = false;
            lblObservaciones.Visible = false;
            txtObservaciones.Visible = false;
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
            if((Session["medSeleccionado"]) != null)
            {
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
        protected void Calendario_SelectionChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ddlistHora.Items.Clear();
            }
            lblHora.Visible = true;
            ddlistHora.Visible = true;
            lblObservaciones.Visible = true;
            txtObservaciones.Visible = true;

            int espSeleccionada = int.Parse(ddlistEspecialidad.SelectedItem.Value);
            int medSeleccionado = int.Parse(ddlistMedico.SelectedItem.Value);

            ddlistHora.Enabled = true;


            DiasHabilesMedico horarioMedico = ((List<DiasHabilesMedico>)Session["listaFiltradaDiasHabiles"]).Find(x => x.IdDia == ((int)Calendario.SelectedDate.DayOfWeek)); //devuelve objeto de dias habiles segun el dia de la semana seleccionado
            DateTime horaInicio = horarioMedico.HorarioEntrada;
            System.TimeSpan horaSumar = new System.TimeSpan(0, 1, 0, 0);

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
                foreach(string hora in horarios)
                {
                    Turno turnoProgramado = turnosFiltradosMedico.Find(x => x.HorarioInicio.ToString("HH:mm") == hora);
                    if(turnoProgramado != null)
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

        protected void Click_Aceptar(object sender, EventArgs e)
        {

            Turno NuevoTurno = new Turno();
            TurnoDB cargar = new TurnoDB();
            string agregado = "Turno";
            string error = "turno";

            PacienteDB pacienteDB = new PacienteDB();
            List<Paciente> pacientes = pacienteDB.listarPaciente();


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
                NuevoTurno.AdministrativoResponsable.ID = int.Parse(ddlistRecepcionista.SelectedItem.Value);
                NuevoTurno.Estado = new EstadoTurno();
                NuevoTurno.Estado.ID = int.Parse(ddlistEstado.SelectedItem.Value);

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

    }
}