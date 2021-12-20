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
    public partial class AgregarEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario userLog = (Usuario)Session["Usuario"];

            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "Debes iniciar sesión");
                Response.Redirect("ErrorIngreso.aspx", false);
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

            TipoEmpleadoDB db = new TipoEmpleadoDB();
            try
            {
                if (!IsPostBack)
                {
                    RangeValidator.MaximumValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    RangeValidator.MinimumValue = DateTime.Now.Date.AddYears(-100).ToString("yyyy-MM-dd");


                    List<TipoEmpleado> empleado = db.listar();
                    List<TipoEmpleado> empleadosSinMedico = empleado.FindAll(x => x.Nombre != "Médico");
                    ddlistTipoEmpleado.DataSource = empleadosSinMedico;
                    ddlistTipoEmpleado.DataTextField = "Nombre";
                    ddlistTipoEmpleado.DataValueField = "ID";
                    ddlistTipoEmpleado.DataBind();
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

            Empleado NuevoEmpleado = new Empleado();
            EmpleadoDB cargar = new EmpleadoDB();
            Usuario nuevoUsuario = new Usuario();
            UsuarioDB cargarUsuario = new UsuarioDB();
            string agregado = "Empleado";
            string error = "empleado";

            if(!Page.IsValid)
                     return;
            try
            {
                NuevoEmpleado.DNI = txtDNI.Text;
                NuevoEmpleado.Apellido = txtApellido.Text;
                NuevoEmpleado.Nombre = txtNombre.Text;
                NuevoEmpleado.TipoEmp = new TipoEmpleado();
                NuevoEmpleado.TipoEmp.ID = int.Parse(ddlistTipoEmpleado.SelectedItem.Value);
                NuevoEmpleado.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                NuevoEmpleado.Telefono = txtTelefono.Text;
                NuevoEmpleado.Email = txtEmail.Text;
                NuevoEmpleado.Dirección = txtDireccion.Text;
                NuevoEmpleado.Estado = true;
                nuevoUsuario.Nombre = txtNombreUsuario.Text;
                cargar.agregar(NuevoEmpleado);


                List<Empleado> empleados = cargar.listarEmpleado();
                Empleado ultEmpleado = empleados.Find(x => x.DNI == txtDNI.Text);
                nuevoUsuario.IDUsuario = ultEmpleado.ID;
                nuevoUsuario.NombreUsuario = txtNombreUsuario.Text;
                nuevoUsuario.Contraseña = txtContraseña.Text;
                nuevoUsuario.TipoUsuario = new TipoUsuario();
                nuevoUsuario.TipoUsuario.Id = int.Parse(ddlistTipoEmpleado.SelectedItem.Value);
                nuevoUsuario.TipoUsuario.Nombre = ddlistTipoEmpleado.SelectedItem.Text;
                nuevoUsuario.Estado = true;

                cargarUsuario.AgregarUsuario(nuevoUsuario);

                ejecutarModal();
                //Response.Redirect("AgregarCorrecto.aspx?agregado=" + agregado, false);
            }
            catch (Exception)
            {

                ejecutarModalcatch();
                // Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
            }
            
           
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx");
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            List<Usuario> lista = usuarioDB.listar();
            if (lista.Find(x => x.NombreUsuario.ToUpper() == args.Value.ToUpper() && x.Estado == true) != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidatorDNI_ServerValidate(object source, ServerValidateEventArgs args)
        {
            EmpleadoDB empleadoDB = new EmpleadoDB();
            List<Empleado> lista = empleadoDB.listarEmpleado();
            if (lista.Find(x => x.DNI == args.Value && x.Estado == true) != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidatorEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            EmpleadoDB empleadoDB = new EmpleadoDB();
            List<Empleado> lista = empleadoDB.listarEmpleado();
            if (lista.Find(x => x.Email.ToUpper() == args.Value.ToUpper() && x.Estado == true) != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void btnCerrarModalAgrearEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx", false);
        }

        protected void ejecutarModal()
        {
            lblTituloAlertModalEmpleado.Text = "Agerado! ";
            lblEmpleadoContext.Text = txtNombre.Text + " " + txtApellido.Text;
            lblEmpleadoConfirmDNI.Text = "El Empleado se agrego de manera correcta!.";
            btnRevisaSiAgrega_Modal.Show();
        }

        protected void ejecutarModalcatch()
        {
            lblTituloAlertModalEmpleado.Text = "Error! ";
            lblEmpleadoContext.Text = txtNombre.Text + " " + txtApellido.Text;
            lblEmpleadoConfirmDNI.Text = "El Empleado no pudo ser agregado de forma correcta!.";
            btnRevisaSiAgrega_Modal.Show();
        }




    }
}
