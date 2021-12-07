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
   
          
        }

        protected void Click_Aceptar(object sender, EventArgs e)
        {
            Medico NuevoMedico = new Medico();
            Usuario nuevoUsuario = new Usuario();
            MedicoDB cargar = new MedicoDB();
            UsuarioDB cargarUsuario = new UsuarioDB();
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

                List<Medico> medicos = cargar.listarMedico();
                Medico ultMedico = medicos.Find(x => x.DNI == txtDNI.Text);
                nuevoUsuario.IDUsuario = ultMedico.ID;
                nuevoUsuario.NombreUsuario = txtNombreUsuario.Text;
                nuevoUsuario.Contraseña = txtContraseña.Text;
                nuevoUsuario.TipoUsuario = new TipoUsuario();
                nuevoUsuario.TipoUsuario.Id = 1;
                nuevoUsuario.TipoUsuario.Nombre = "Médico";
                nuevoUsuario.Estado = true;

                cargarUsuario.AgregarUsuario(nuevoUsuario);

                Response.Redirect("AgregarCorrecto.aspx?agregado=" + agregado, false);
            }
            catch (Exception ex)
            {
                //Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
                throw ex;
            }
            
        }
    }
}