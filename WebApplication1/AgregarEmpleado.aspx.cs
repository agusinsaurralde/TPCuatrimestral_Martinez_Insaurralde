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
            if (!IsPostBack)
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
                    
                     RangeValidator.MaximumValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
                     RangeValidator.MinimumValue = DateTime.Now.Date.AddYears(-100).ToString("yyyy-MM-dd");


                     List<TipoEmpleado> empleado = db.listar();
                     List<TipoEmpleado> empleadosSinMedico = empleado.FindAll(x => x.Nombre != "Médico");
                     ddlistTipoEmpleado.DataSource = empleadosSinMedico;
                     ddlistTipoEmpleado.DataTextField = "Nombre";
                     ddlistTipoEmpleado.DataValueField = "ID";
                     ddlistTipoEmpleado.DataBind();
                   
                }
                catch (Exception ex)
                {
                Session.Add("Error", ex);
                //throw ex;
            }
            }
        }

        protected void Click_Aceptar(object sender, EventArgs e)
        {

            if(!Page.IsValid)
                     return;
            try
            {
                Empleado NuevoEmpleado = new Empleado();
                EmpleadoDB cargar = new EmpleadoDB();
                Usuario nuevoUsuario = new Usuario();
                UsuarioDB cargarUsuario = new UsuarioDB();
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
            }
            catch (Exception)
            {

                ejecutarModalcatch();
            }
            
           
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx");
        }

        //validaciones
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            List<Usuario> lista = usuarioDB.listar();
            if (lista.Find(x => x.NombreUsuario.ToUpper() == args.Value.ToUpper()) != null)
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
            MedicoDB medicoDB = new MedicoDB();
            List<Medico> listaMedico = medicoDB.listarMedico();
            if (lista.Find(x => x.DNI == args.Value) != null || (listaMedico.Find(x => x.DNI == args.Value) != null))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidatorDNIInactivo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            EmpleadoDB empleadoDB = new EmpleadoDB();
            List<Empleado> inactivos = empleadoDB.listarEmpleadoInactivo();
            if (inactivos.Find(x => x.DNI == args.Value) != null)
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
            MedicoDB medicoDB = new MedicoDB();
            List<Medico> listaMedico = medicoDB.listarMedico();
            if (listaMedico.Find(x => x.DNI == args.Value) != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
            List<Empleado> inactivos = empleadoDB.listarEmpleadoInactivo();
            if (inactivos.Find(x => x.Email == args.Value) != null)
            {
                args.IsValid = false;
                CustomValidatorDNI.ErrorMessage = "*El email ingresado pertenece a un empleado inactivo";
            }
            else
            {
                args.IsValid = true;
            }
        }

        //modal
        protected void btnCerrarModalAgrearEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx", false);
        }
        protected void ejecutarModal()
        {
            lblTituloAlertModalEmpleado.Text = "Agregado! ";
            lblEmpleadoContext.Text = "El Empleado " + txtNombre.Text + " " + txtApellido.Text + " se agrego de manera correcta!" ;
            btnRevisaSiAgrega_Modal.Show();
        }
        protected void ejecutarModalcatch()
        {
            lblTituloAlertModalEmpleado.Text = "Error! ";
            lblEmpleadoContext.Text = "Hubo un error al agregar el empleado";
            btnRevisaSiAgrega_Modal.Show();
        }




    }
}
