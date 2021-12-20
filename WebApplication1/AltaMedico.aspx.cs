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
    public partial class AltaMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Medicos.aspx");
        }

        protected void Click_Aceptar(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            Medico modMedico = new Medico();
            Usuario modUsuario = new Usuario();
            MedicoDB cargar = new MedicoDB();
            UsuarioDB cargarUsuario = new UsuarioDB();

            try
            {
                modMedico.ID = (int)Session["ID"];
                modMedico.DNI = txtDNI.Text;
                modMedico.Apellido = txtApellido.Text;
                modMedico.Nombre = txtNombre.Text;
                modMedico.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                modMedico.Telefono = txtTelefono.Text;
                modMedico.Email = txtEmail.Text;
                modMedico.Dirección = txtDireccion.Text;
                modMedico.Estado = true;
                modUsuario.IDUsuario = (int)Session["ID"];
                modUsuario.NombreUsuario = txtNombreUsuario.Text;
                modUsuario.Contraseña = txtContraseña.Text;
                modUsuario.Estado = true;

                cargar.modificar(modMedico);
                cargarUsuario.ModificarUsuario(modUsuario);

                lblTituloAlertModal.Text = "Alta médico";
                lblVerificacion.Text = "El médico " + modMedico.Nombre + " " + modMedico.Apellido + " fue dado de alta con éxito.";
                verificacion_Modal.Show();
            }
            catch (Exception)
            {
                lblTituloAlertModal.Text = "Error";
                lblVerificacion.Text = "Hubo un problema al dar de alta al médico.";
                verificacion_Modal.Show();

            }

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                MedicoDB medicoDB = new MedicoDB();
                List<Medico> lista = medicoDB.listarMedicoInactivo();
                Medico medico = lista.Find(x => x.DNI == txtDNI.Text);

                if (medico != null)
                {
                    Session.Add("ID", medico.ID);
                    UsuarioDB usuarioDB = new UsuarioDB();
                    List<Usuario> listaU = usuarioDB.listarInactivo();
                    Usuario usuario = listaU.Find(x => x.IDUsuario == medico.ID);

                    RangeValidator.MaximumValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    RangeValidator.MinimumValue = DateTime.Now.Date.AddYears(-100).ToString("yyyy-MM-dd");


                    txtDNI.Text = medico.DNI;
                    txtApellido.Text = medico.Apellido;
                    txtNombre.Text = medico.Nombre;
                    txtFechaNac.Text = medico.FechaNacimiento.ToString("yyyy-MM-dd");
                    txtTelefono.Text = medico.Telefono;
                    txtMatricula.Text = medico.Matricula;
                    txtEmail.Text = medico.Email;
                    txtDireccion.Text = medico.Dirección;
                    txtNombreUsuario.Text = usuario.NombreUsuario;
                    txtContraseña.Text = usuario.Contraseña;
                }
                else
                {

                    lblTituloAlertModal.Text = "Error";
                    lblVerificacion.Text = "Hubo un problema al dar de alta el médico.";
                    verificacion_Modal.Show();
                }


            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                //throw ex;
            }
        }


        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            Response.Redirect("Medicos.aspx", false);
        }
    }
}