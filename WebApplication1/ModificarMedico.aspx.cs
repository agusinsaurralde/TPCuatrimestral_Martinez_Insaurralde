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
    public partial class Formulario_web21 : System.Web.UI.Page
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

                    Medico medico = new Medico();
                    medico = (Medico)Session["modificar"];
                    txtDNI.Text = medico.DNI;
                    txtMatricula.Text = medico.Matricula;
                    txtApellido.Text = medico.Apellido;
                    txtNombre.Text = medico.Nombre;
                    ddlistEspecialidad.SelectedValue = medico.Especialidad.Id.ToString();
                    txtFechaNac.Text = medico.FechaNacimiento.ToString();
                    txtTelefono.Text = medico.Telefono;
                    txtEmail.Text = medico.Email;
                    txtDireccion.Text = medico.Dirección;
                    ddlistTurno.SelectedValue = medico.Turno.ID.ToString();
                    txtEntrada.Text = medico.HorarioEntrada.ToString();
                    txtSalida.Text = medico.HorarioSalida.ToString();
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
            Medico modMedico = new Medico();
            MedicoDB cargar = new MedicoDB();
            string modificado = "Médico";
            string error = "médico";

            try
            {
                modMedico.ID = ((Medico)Session["modificar"]).ID;
                modMedico.DNI = txtDNI.Text;
                modMedico.Matricula = txtMatricula.Text;
                modMedico.Apellido = txtApellido.Text;
                modMedico.Nombre = txtNombre.Text;
                modMedico.Especialidad = new Especialidad();
                modMedico.Especialidad.Id = int.Parse(ddlistEspecialidad.SelectedItem.Value);
                modMedico.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                modMedico.Telefono = txtTelefono.Text;
                modMedico.Email = txtEmail.Text;
                modMedico.Dirección = txtDireccion.Text;
                modMedico.Turno = new TurnoTrabajo();
                modMedico.Turno.ID = int.Parse(ddlistTurno.SelectedItem.Value);
                modMedico.HorarioEntrada = DateTime.Parse(txtEntrada.Text);
                modMedico.HorarioSalida = DateTime.Parse(txtSalida.Text);

                cargar.modificar(modMedico);

                Response.Redirect("ModificarCorrecto.aspx?modificado=" + modificado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorModificar.aspx?error=" + error, false);
            }

        }
    }
}
