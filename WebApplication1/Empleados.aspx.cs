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
    public partial class Empleados : System.Web.UI.Page
    {
        EmpleadoDB db = new EmpleadoDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnTodos.BackColor = System.Drawing.Color.RoyalBlue;
                btnAdmin.BackColor = System.Drawing.Color.DodgerBlue;
                btnRecep.BackColor = System.Drawing.Color.DodgerBlue;
                Session.Add("btn", "Todos");
                Usuario userLog = (Usuario)Session["Usuario"];

                 if (Session["Usuario"] == null)
                 {
                     Session.Add("Error", "Debes iniciar sesión");
                     Response.Redirect("ErrorIngreso.aspx", false);
                 }
                 else if(userLog.TipoUsuario.Nombre == "Médico")
                 {
                     Session.Add("Error", "Acceso denegado"); ;
                     Response.Redirect("ErrorPermisosAcceso.aspx", false);

                 }
                 else if (userLog.TipoUsuario.Nombre == "Recepcionista")
                 {
                     Session.Add("Error", "Acceso denegado"); ;
                     Response.Redirect("ErrorPermisosAcceso.aspx", false);
                 }

            
                Grilla.DataSource = db.listarEmpleado();
                Grilla.DataBind();
            } 
        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEmpleado.aspx");
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {
            Session.Add("eliminar", (int)Grilla.DataKeys[e.RowIndex].Values[0]);
            btnEliminar_Modal.Show();
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            Session.Add("modificar", db.buscarporID((int)Grilla.DataKeys[e.NewEditIndex].Values[0]));
            Session.Add("modificarUsuario", usuarioDB.buscarporID((int)Grilla.DataKeys[e.NewEditIndex].Values[0]));
            Response.Redirect("ModificarEmpleado.aspx");
        }
        protected void Click_Buscar(object sender, EventArgs e)
        {
            string criterio = (string)Session["btn"];
            List<Empleado> empleadoBusqueda = db.buscarEmpleado(criterio, txtBusqueda.Text);
            Grilla.DataSource = empleadoBusqueda;
            Grilla.DataBind();
            if (empleadoBusqueda.Count != 0)
            {
                resultados.Visible = false;
            }
            else
            {
                resultados.Visible = true;
            }

        }

        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        { 
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario usuario = usuarioDB.buscarporID(Convert.ToInt32(Grilla.SelectedDataKey.Value));
            lblUsuario.Text = usuario.NombreUsuario;
            lblContraseña.Text = usuario.Contraseña;
            btnUsuario_Modal.Show();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                EmpleadoDB empleadoDB = new EmpleadoDB();
                empleadoDB.eliminar((int)Session["eliminar"]);
                UsuarioDB usuarioDB = new UsuarioDB();
                usuarioDB.eliminar((int)Session["eliminar"]);
                Grilla.DataSource = db.listarEmpleado();
                Grilla.DataBind();
                lblTituloAlertModal.Text = "Eliminar Empleado";
                lblVerificacion.Text = "El empleado fue eliminado con éxito.";
                verificacion_Modal.Show();
            }
            catch (Exception)
            {
                lblTituloAlertModal.Text = "Error";
                lblVerificacion.Text = "Hubo un error al eliminar el empleado.";
                verificacion_Modal.Show();
            }
            
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string criterio = (string)Session["btn"];
            List<Empleado> empleadoBusqueda = db.buscarEmpleado(criterio, txtBusqueda.Text);
            Grilla.DataSource = empleadoBusqueda;
            Grilla.DataBind();
            if (empleadoBusqueda.Count != 0)
            {
                resultados.Visible = false;
            }
            else
            {
                resultados.Visible = true;
            }
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            Grilla.DataSource = db.listarEmpleado();
            Grilla.DataBind();
            btnTodos.BackColor = System.Drawing.Color.RoyalBlue;
            btnAdmin.BackColor = System.Drawing.Color.DodgerBlue;
            btnRecep.BackColor = System.Drawing.Color.DodgerBlue;
            Session.Add("btn", "Todos");

        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Grilla.DataSource = db.listarAdministrador();
            Grilla.DataBind();
            btnAdmin.BackColor = System.Drawing.Color.RoyalBlue;
            btnTodos.BackColor = System.Drawing.Color.DodgerBlue;
            btnRecep.BackColor = System.Drawing.Color.DodgerBlue;
            Session.Add("btn", "Administradores");

        }

        protected void btnRecep_Click(object sender, EventArgs e)
        {
            Grilla.DataSource = db.listarRecepcionista();
            Grilla.DataBind();
            btnRecep.BackColor = System.Drawing.Color.RoyalBlue;
            btnTodos.BackColor = System.Drawing.Color.DodgerBlue;
            btnAdmin.BackColor = System.Drawing.Color.DodgerBlue;
            Session.Add("btn", "Recepcionistas");

        }

        protected void btnDarDeAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaEmpleado.aspx");
        }
    }
}