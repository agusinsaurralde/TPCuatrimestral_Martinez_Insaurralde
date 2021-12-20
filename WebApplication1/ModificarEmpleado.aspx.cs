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
    public partial class ModificarEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario userLog = (Usuario)Session["Usuario"];

            if ((Empleado)Session["modificar"] == null)
            {
                Response.Redirect("ErrorPermisosAcceso");
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
                    List<TipoEmpleado> tipo = db.listar();
                    ddlistTipoEmpleado.DataSource = tipo;
                    ddlistTipoEmpleado.DataTextField = "Nombre";
                    ddlistTipoEmpleado.DataValueField = "ID";
                    ddlistTipoEmpleado.DataBind();

                    Empleado empleado = new Empleado();
                    Usuario usuario = new Usuario();
                    empleado = (Empleado)Session["modificar"];
                    usuario = (Usuario)Session["modificarUsuario"];
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
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                //throw ex;
            }


        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx");
        }
        protected void Click_Aceptar(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            Empleado modEmpleado = new Empleado();
            Usuario modUsuario = new Usuario();
            EmpleadoDB cargar = new EmpleadoDB();
            UsuarioDB cargarUsuario = new UsuarioDB();
            string modificado = "Empleado";
            string error = "empleado";

            try
            {
                modEmpleado.ID = ((Empleado)Session["modificar"]).ID;
                modEmpleado.DNI = txtDNI.Text;
                modEmpleado.Apellido = txtApellido.Text;
                modEmpleado.Nombre = txtNombre.Text;
                modEmpleado.TipoEmp = new TipoEmpleado();
                modEmpleado.TipoEmp.ID = int.Parse(ddlistTipoEmpleado.SelectedItem.Value);
                modEmpleado.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                modEmpleado.Telefono = txtTelefono.Text;
                modEmpleado.Email = txtEmail.Text;
                modEmpleado.Dirección = txtDireccion.Text;
                modUsuario.IDUsuario = ((Empleado)Session["modificar"]).ID;
                modUsuario.NombreUsuario = txtNombreUsuario.Text;
                modUsuario.Contraseña = txtContraseña.Text;
                modUsuario.TipoUsuario = new TipoUsuario();
                modUsuario.TipoUsuario.Id = int.Parse(ddlistTipoEmpleado.SelectedItem.Value);

                cargar.modificar(modEmpleado);
                cargarUsuario.ModificarUsuario(modUsuario);
                ejecutarModalModificar();
                //Response.Redirect("ModificarCorrecto.aspx?modificado=" + modificado, false);
            }
            catch (Exception)
            {
                ejecutarModalModificarcatch();
                //Response.Redirect("ErrorModificar.aspx?error=" + error, false);
            }

        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            List<Usuario> lista = usuarioDB.listar();
            if (lista.Find(x => x.NombreUsuario.ToUpper() == args.Value.ToUpper() && x.Estado == true && x.IDUsuario != ((Empleado)Session["modificar"]).ID) != null)
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
            if (lista.Find(x => x.DNI == args.Value && x.Estado == true && x.ID != ((Empleado)Session["modificar"]).ID) != null)
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
            if (lista.Find(x => x.Email.ToUpper() == args.Value.ToUpper() && x.Estado == true && x.ID != ((Empleado)Session["modificar"]).ID) != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }


        protected void ejecutarModalModificar()
        {
            lblTituloAlertModalModificarEmpleado.Text = "Modificado! ";
            lblEmpleadoModificadoContext.Text = txtNombre.Text + " " + txtApellido.Text;
            lblEmpleadoConfirmModificado.Text = "Empleado modificado correctamente.";
            btnRevisaSiModifica_Modal.Show();
        }

        protected void ejecutarModalModificarcatch()
        {
            lblTituloAlertModalModificarEmpleado.Text = "Error! ";
            lblEmpleadoModificadoContext.Text = txtNombre.Text + " " + txtApellido.Text;
            lblEmpleadoConfirmModificado.Text = "No se pudieron guardar los cambios!.";
            btnRevisaSiModifica_Modal.Show();
        }

        protected void btnCerrarModalModiciarEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx", false);
        }




    }
}
