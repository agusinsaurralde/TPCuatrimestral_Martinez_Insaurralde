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
                NuevoMedico.DNI = txtDNI.Text;
                NuevoMedico.Matricula = txtMatricula.Text;
                NuevoMedico.Apellido = txtApellido.Text;
                NuevoMedico.Nombre = txtNombre.Text;
                NuevoMedico.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                NuevoMedico.Telefono = txtTelefono.Text;
                NuevoMedico.Email = txtEmail.Text;
                NuevoMedico.Dirección = txtDireccion.Text;
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