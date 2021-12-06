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

                    Medico medico = new Medico();
                    medico = (Medico)Session["modificar"];
                    Usuario usuario = (Usuario)Session["modificarUsuario"];
                    txtDNI.Text = medico.DNI;
                    txtMatricula.Text = medico.Matricula;
                    txtApellido.Text = medico.Apellido;
                    txtNombre.Text = medico.Nombre;
                    txtFechaNac.Text = medico.FechaNacimiento.ToString("dd-mm-yyyy");
                    txtTelefono.Text = medico.Telefono;
                    txtEmail.Text = medico.Email;
                    txtDireccion.Text = medico.Dirección;
                    txtNombreUsuario.Text = usuario.NombreUsuario;
                    txtContraseña.Text = usuario.Contraseña;

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
            Usuario modUsuario = new Usuario();
            MedicoDB cargar = new MedicoDB();
            UsuarioDB cargarUsuario = new UsuarioDB();
            string modificado = "Médico";
            string error = "médico";

            try
            {
                modMedico.ID = ((Medico)Session["modificar"]).ID;
                modMedico.DNI = txtDNI.Text;
                modMedico.Matricula = txtMatricula.Text;
                modMedico.Apellido = txtApellido.Text;
                modMedico.Nombre = txtNombre.Text;
                modMedico.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                modMedico.Telefono = txtTelefono.Text;
                modMedico.Email = txtEmail.Text;
                modMedico.Dirección = txtDireccion.Text;

                cargar.modificar(modMedico);

  
                modUsuario.IDUsuario = ((Medico)Session["modificar"]).ID;
                modUsuario.NombreUsuario = txtNombreUsuario.Text;
                modUsuario.Contraseña = txtContraseña.Text;
                modUsuario.TipoUsuario = new TipoUsuario();
                modUsuario.TipoUsuario.Id = 1;
                modUsuario.TipoUsuario.Nombre = "Médico";
                modUsuario.Estado = true;

                cargarUsuario.ModificarUsuario(modUsuario);

                Response.Redirect("ModificarCorrecto.aspx?modificado=" + modificado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorModificar.aspx?error=" + error, false);
            }

        }
    }
}
