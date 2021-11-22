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
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Click_Ingresar(object sender, EventArgs e)
        {
            Usuario Usuario;
            UsuarioDB UsuarioDB = new UsuarioDB();
            TipoUsuario tipoUsuario = new TipoUsuario();

            try
            {
                Usuario = new Usuario(txtbxUsuario.Text, txtbxContraseña.Text, tipoUsuario);
                if (UsuarioDB.Ingresar(Usuario))
                {
                   Session.Add("Usuario", Usuario);
                    Response.Redirect("Turnos.aspx", false);
                }
                else
                {
                    Session.Add("Error", "Usuario o contraseña incorrecto");
                    Response.Redirect("ErrorIngreso.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("ErrorIngreso.aspx");
            }
        }

        public bool UsuarioAdmin()
        {
            if (Session["Usuario"] != null && ((Dominio.Usuario)Session["Usuario"]).TipoUsuario.Nombre == "Administrador")
            {
                return true;
            }
            return false;
        }

        public bool UsuarioMedico()
        {
            if (Session["Usuario"] != null && ((Dominio.Usuario)Session["Usuario"]).TipoUsuario.Nombre == "Médico")
            {
                return true;
            }
            return false;
        }
        public bool UsuarioRecepcionista()
        {
            if (Session["Usuario"] != null && ((Dominio.Usuario)Session["Usuario"]).TipoUsuario.Nombre == "Recepcionista")
            {
                return true;
            }
            return false;
        }
    }
}