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
    public partial class SiteMaster : MasterPage
    {
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            usuario = (Usuario)Session["Usuario"];
            if (usuario == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            EmpleadoDB empleadoDB = new EmpleadoDB();
            Empleado empleado = empleadoDB.empleadoLogueado(usuario.IDUsuario);
            btnLogOut.Text = empleado.NombreCompleto + " - CERRAR SESIÓN";
            
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("LogIn.aspx");
        }
    }
}