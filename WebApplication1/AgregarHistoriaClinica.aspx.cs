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
            if (!IsPostBack)
            {
                Usuario userLog = (Usuario)Session["Usuario"];

                if (Session["Usuario"] == null)
                {
                    Response.Redirect("LogIn.aspx");
                }
                else if (userLog.UsuarioRecepcionista(userLog))
                {
                    Session.Add("Error", "Acceso denegado");
                    Response.Redirect("ErrorPermisosAcceso.aspx", false);
                }


                Turno datos = (Turno)Session["agregarHistoriaClinica"];
                txtNombrePaciente.Text = datos.Paciente.NombreCompleto;
                lblFecha.Text = datos.Dia.ToShortDateString();
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

                HistoriaClinica hc = new HistoriaClinica();
                HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
                Turno datos = (Turno)Session["agregarHistoriaClinica"];

                hc.ID = datos.Numero;
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

                ejecutarModal();

            }
            catch (Exception)
            {
                ejecutarModalCatch();
            }
           
        }


        protected void btnCerrarModalModificarHistoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistoriaClinica.aspx", false);
        }

        protected void ejecutarModal()
        {
            lblTituloModificarHistoria.Text = "Historia Clínica";
            lblHistoriaContext.Text = "La historia clínica se agregó correctamente.";
            btnEditarHistoria_Modal.Show();
        }

        protected void ejecutarModalCatch()
        {
            lblTituloModificarHistoria.Text = "Error! ";
            lblHistoriaContext.Text = "No se pudieron guardar los cambios!.";
            btnEditarHistoria_Modal.Show();
        }



    }
}