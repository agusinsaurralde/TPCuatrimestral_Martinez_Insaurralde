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
    public partial class AltaEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario userLog = (Usuario)Session["Usuario"];

                if (userLog == null)
                {
                    Response.Redirect("LogIn.aspx");
                }
                else if (userLog.TipoUsuario.Nombre == "Médico")
                {
                    Session.Add("Error", "Acceso denegado"); ;
                    Response.Redirect("ErrorPermisosAcceso.aspx", false);

                }
                else if (userLog.TipoUsuario.Nombre == "Recepcionista")
                {
                    Session.Add("Error", "Acceso denegado"); ;
                    Response.Redirect("ErrorPermisosAcceso.aspx", false);
                }
               
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            List<Usuario> lista = usuarioDB.listar();
            if (lista.Find(x => x.NombreUsuario.ToUpper() == args.Value.ToUpper() && x.Estado == true && x.IDUsuario != (int)Session["ID"]) != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

    

        protected void Click_Aceptar(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            Empleado modEmpleado = new Empleado();
            Usuario modUsuario = new Usuario();
            EmpleadoDB cargar = new EmpleadoDB();
            UsuarioDB cargarUsuario = new UsuarioDB();

            try
            {
                modEmpleado.ID = (int)Session["ID"];
                modEmpleado.DNI = txtDNI.Text;
                modEmpleado.Apellido = txtApellido.Text;
                modEmpleado.Nombre = txtNombre.Text;
                modEmpleado.TipoEmp = new TipoEmpleado();
                modEmpleado.TipoEmp.ID = int.Parse(ddlistTipoEmpleado.SelectedItem.Value);
                modEmpleado.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                modEmpleado.Telefono = txtTelefono.Text;
                modEmpleado.Email = txtEmail.Text;
                modEmpleado.Dirección = txtDireccion.Text;
                modEmpleado.Estado = true;
                modUsuario.IDUsuario = (int)Session["ID"];
                modUsuario.NombreUsuario = txtNombreUsuario.Text;
                modUsuario.Contraseña = txtContraseña.Text;
                modUsuario.TipoUsuario = new TipoUsuario();
                modUsuario.TipoUsuario.Id = int.Parse(ddlistTipoEmpleado.SelectedItem.Value);
                modUsuario.Estado = true;

                cargar.modificar(modEmpleado);
                cargarUsuario.ModificarUsuario(modUsuario);

                lblTituloAlertModal.Text = "Alta empleado";
                lblVerificacion.Text = "El empleado " + modEmpleado.Nombre + " " + modEmpleado.Apellido + " fue dado de alta con éxito.";
                verificacion_Modal.Show();
            }
            catch (Exception)
            {
                lblTituloAlertModal.Text = "Error";
                lblVerificacion.Text = "Hubo un problema al dar de alta el empleado.";
                verificacion_Modal.Show();

            }

        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
            try
            {
                EmpleadoDB empleadoDB = new EmpleadoDB();
                List<Empleado> lista = empleadoDB.listarEmpleadoInactivo();
                Empleado empleado = lista.Find(x => x.DNI == txtDNI.Text);
                
               

                if (empleado != null)
                {
                    Session.Add("ID", empleado.ID);
                    UsuarioDB usuarioDB = new UsuarioDB();
                    List<Usuario> listaU = usuarioDB.listarInactivo();
                    Usuario usuario = listaU.Find(x => x.IDUsuario == empleado.ID);
                    RangeValidator.MaximumValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    RangeValidator.MinimumValue = DateTime.Now.Date.AddYears(-100).ToString("yyyy-MM-dd");

                    TipoEmpleadoDB db = new TipoEmpleadoDB();
                    List<TipoEmpleado> tipo = db.listar();
                    ddlistTipoEmpleado.DataSource = tipo;
                    ddlistTipoEmpleado.DataTextField = "Nombre";
                    ddlistTipoEmpleado.DataValueField = "ID";
                    ddlistTipoEmpleado.DataBind();

                    txtDNI.Text = empleado.DNI;
                    txtApellido.Text = empleado.Apellido;
                    txtNombre.Text = empleado.Nombre;
                    ddlistTipoEmpleado.SelectedValue = empleado.TipoEmp.ID.ToString();
                    txtFechaNac.Text = empleado.FechaNacimiento.ToString("yyyy-MM-dd");
                    txtTelefono.Text = empleado.Telefono;
                    txtEmail.Text = empleado.Email;
                    txtDireccion.Text = empleado.Dirección;
                    txtNombreUsuario.Text = usuario.NombreUsuario;
                    txtContraseña.Text = usuario.Contraseña;
                }
                else
                {

                    lblTituloAlertModal.Text = "Error";
                    lblVerificacion.Text = "Hubo un problema al dar de alta el empleado.";
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
            Response.Redirect("Empleados.aspx", false);
        }

    }
}