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
    public partial class AgregarHistoriaClinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario userLog = (Usuario)Session["Usuario"];

            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "Debes iniciar sesión");
                Response.Redirect("ErrorIngreso.aspx", false);
            }

            Turno datos = (Turno)Session["agregarHistoriaClinica"];
           txtNombrePaciente.Text = datos.Paciente.NombreCompleto;
            lblFecha.Text = datos.Dia.ToShortDateString();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string agregado = "Historia clínica";
            string error = "historia clínica";
            Usuario userLog = (Usuario)Session["Usuario"];
            EmpleadoDB empleadoLogDB = new EmpleadoDB();
            Empleado empleadoLog = new Empleado();
            empleadoLog = empleadoLogDB.empleadoLogueado((int)userLog.IDUsuario);
            try
            { 

                HistoriaClinica hc = new HistoriaClinica();
                HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
                Turno datos = (Turno)Session["agregarHistoriaClinica"];

                hc.Paciente = new Paciente();
                hc.Paciente.ID = datos.Paciente.ID;
                hc.Medico = new Medico();
                if(empleadoLog.TipoEmp.Nombre == "Médico")
                {
                    hc.Medico.ID = empleadoLog.ID;
                }
                hc.Descripcion = txtDescripcion.Text;
                hc.Fecha = datos.Dia;
                

                hcDB.AgregarHistoriaClinica(hc);

                ejecutarModalModificarHistoria();
                //Response.Redirect("AgregarCorrecto.aspx?agregado=" + agregado, false);
            }
            catch (Exception ex)
            {
                //Response.Redirect("ErrorAgregar.aspx?agregado=" + error, false);

                ejecutarModalModificarHistoriaCatch();

                //throw ex;
            }
           
        }


        protected void btnCerrarModalModificarHistoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistoriaClinica.aspx", false);
        }

        protected void ejecutarModalModificarHistoria()
        {
            lblTituloModificarHistoria.Text = "Modificado! ";
            lblHistoriaContext.Text = "Se modifico correctamente!";
            btnEditarHistoria_Modal.Show();
        }

        protected void ejecutarModalModificarHistoriaCatch()
        {
            lblTituloModificarHistoria.Text = "Error! ";
            lblHistoriaContext.Text = "No se pudieron guardar los cambios!.";
            btnEditarHistoria_Modal.Show();
        }



    }
}