﻿using System;
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
                List<Empleado> emp = empledoDB.listarEmpleado();
                ddlistRecepcionista.DataSource = emp;
                ddlistRecepcionista.DataTextField = "Apellido";
                ddlistRecepcionista.DataValueField = "ID";
                ddlistRecepcionista.DataBind();
                //provisiorio
                List<EstadoTurno> estado = estadoDB.listar();
                ddlistEstado.DataSource = estado;
                ddlistEstado.DataTextField = "Estado";
                ddlistEstado.DataValueField = "ID";
                ddlistEstado.DataBind();

                /* List<Medico> medico = medicoDB.listarMedico();
                 Session["listaMedico"] = medico;*/
                List<MedicoEspecialidades> espMedicos = medicoDB.listarEspecialidadesMedico();
                Session["listaMedicoEsp"] = espMedicos;
                ddlistMedico.DataSource = espMedicos;
                ddlistMedico.DataTextField = "NombreCompleto";
                ddlistMedico.DataValueField = "ID";
                ddlistMedico.DataBind();
                ddlistMedico.Items.Insert(0, new ListItem("Seleccionar", "0"));


                /*ddlistMedico.DataSource = medico;
                ddlistMedico.DataTextField = "NombreCompleto";
                ddlistMedico.DataValueField = "ID";
                ddlistMedico.DataBind();
                ddlistMedico.Items.Insert(0, new ListItem("Seleccionar", "0"));*/

            }

        }
        protected void ddlistEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(ddlistEspecialidad.SelectedItem.Value);
            
            ddlistMedico.DataSource = ((List<MedicoEspecialidades>)Session["listaMedicoEsp"]).FindAll(x => x.especialidad.Id == ID);
            ddlistMedico.DataBind();
            ddlistMedico.Enabled = true;
            txtFecha.Enabled = true;
        }
        protected void txtFecha_textChanged(object sender, EventArgs e)
        {
            ddlistHora.Enabled = true;
   
           /* int idMedico = int.Parse(ddlistMedico.SelectedItem.Value);
            Medico medSeleccionado = medicoDB.buscarporID(idMedico);
            DateTime hora = medSeleccionado.HorarioEntrada;
            System.TimeSpan horaSumar = new System.TimeSpan(0, 1, 0, 0);
            TurnoDB turnoDB = new TurnoDB();
            List<Turno> listaTurno = turnoDB.listarTurno();
            int contTotal = 0;
            bool bandera = false;
            bool banderaAux = false;

            if (IsPostBack)
            {
                ddlistHora.Items.Clear();
            }

            for (int x = 0; x < 3; x++) //muestra los horarios posibles
            {
                if (bandera == false)
                {
                    foreach (Turno turno in listaTurno)
                    {
                        if (turno.Medico.ID == medSeleccionado.ID)
                        {
                            contTotal++; //CUENTA SI EXISTEN TURNOS DEL MÉDICO

                            if (turno.Dia != DateTime.Parse(txtFecha.Text)) //NO EXISTEN TURNOS EN EL DIA SELECCIONADO
                            {
                                bandera = true;
                            }
                            else if (turno.Dia == DateTime.Parse(txtFecha.Text)) //COMPARA CADA HORARIO POSIBLE CON LOS DE LOS TURNOS EXISTENTES
                            {
                                if (banderaAux == false && turno.Estado.Estado == "Programado" && hora.ToString("HH.mm") != turno.HorarioInicio.ToString("HH.mm"))
                                {
                                    ddlistHora.Items.Add(new ListItem(hora.ToString("HH:mm")));
                                    banderaAux = true;
                                }
                                else if (banderaAux == false && turno.Estado.Estado == "Cancelado" && hora.ToString("HH.mm") == turno.HorarioInicio.ToString("HH.mm"))
                                {
                                    ddlistHora.Items.Add(new ListItem(hora.ToString("HH:mm")));
                                    banderaAux = true;
                                }
                            }

                        }
                        if (contTotal == 0)
                            bandera = true; //NO REPITE FOREACH
                    }
                    if (bandera == true)
                        ddlistHora.Items.Add(new ListItem(hora.ToString("HH:mm")));

                    hora += horaSumar;
                    banderaAux = false;
                }
                if (bandera == true && x > 0)
                {
                    ddlistHora.Items.Add(new ListItem(hora.ToString("HH:mm")));
                    hora += horaSumar;
                }
            }*/
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
            }
            else
            {
                txtPaciente.Text = "Paciente existente";
                txtApellido.Text = "Apellido: " + datosPaciente.Apellido;
                txtNombre.Text = "Nombre: " + datosPaciente.Nombre;
                txtCobertura.Text = "Cobertura: " + datosPaciente.Cobertura.Nombre;
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

            System.TimeSpan horaSumar = new System.TimeSpan(0, 1, 0, 0);

            try
            {
                NuevoTurno.Paciente = pacientes.Find(x => x.DNI == txtDNI.Text);
                NuevoTurno.Especialidad = new Especialidad();
                NuevoTurno.Especialidad.Id = int.Parse(ddlistEspecialidad.SelectedItem.Value);
                NuevoTurno.Especialidad.Nombre = ddlistEspecialidad.SelectedItem.Text;
                NuevoTurno.Medico = new Medico();
                NuevoTurno.Medico.ID = int.Parse(ddlistMedico.SelectedItem.Value);
                NuevoTurno.Medico.NombreCompleto = ddlistMedico.SelectedItem.Text;
                NuevoTurno.Dia = DateTime.Parse(txtFecha.Text);
                NuevoTurno.HorarioInicio = DateTime.Parse(ddlistHora.SelectedItem.Value);
                DateTime horaFInal = DateTime.Parse(ddlistHora.SelectedItem.Value) + horaSumar;
                NuevoTurno.HorarioFin = horaFInal;
                NuevoTurno.Observaciones = txtObservaciones.Text;
                NuevoTurno.AdministrativoResponsable = new Empleado();
                NuevoTurno.AdministrativoResponsable.ID = int.Parse(ddlistRecepcionista.SelectedItem.Value);
                NuevoTurno.Estado = new EstadoTurno();
                NuevoTurno.Estado.ID = int.Parse(ddlistEstado.SelectedItem.Value);

                cargar.agregar(NuevoTurno);
                List<Turno> listaturnos = cargar.listarTurno();

                NuevoTurno.Numero = listaturnos.Count;
                Session.Add("NuevoTurno", NuevoTurno);

                Response.Redirect("AgregarCorrecto.aspx?agregado=" + agregado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
            }
        }

        protected void Calendario_SelectionChanged(object sender, EventArgs e)
        {
            txtFecha.Text = Calendario.SelectedDate.ToString();
        }
    }
}