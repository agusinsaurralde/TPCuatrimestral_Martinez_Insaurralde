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
    public partial class EliminarEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNombre.Text = ((Empleado)Session["eliminar"]).Nombre + " " + ((Empleado)Session["eliminar"]).Apellido;
            }
        }

        protected void Click_Aceptar(object sender, EventArgs e)
        {
            string eliminado = "Empleado";
            string error = "empleado";
            try
            {
                Empleado empleado = new Empleado();
                EmpleadoDB db = new EmpleadoDB();
                empleado = (Empleado)Session["eliminar"];
                db.eliminar(empleado);

                Usuario usuario = new Usuario();
                UsuarioDB usuarioDB = new UsuarioDB();
                usuario = (Usuario)Session["eliminarUsuario"];
                usuarioDB.eliminar(usuario);

                Response.Redirect("EliminarCorrecto.aspx?eliminado=" + eliminado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorEliminar.aspx?error=" + error, false);
            }

        }
        protected void Click_Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("Empleados.aspx", false);
        }
    }
}
