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
    public partial class Formulario_web31 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNombre.Text = ((Medico)Session["eliminar"]).Nombre + " " + ((Medico)Session["eliminar"]).Apellido;
            }

        }

        protected void Click_Aceptar(object sender, EventArgs e)
        {
            string eliminado = "Médico";
            string error = "médico";
            try
            {
                Medico medico = new Medico();
                MedicoDB db = new MedicoDB();
                medico = (Medico)Session["eliminar"];
                db.eliminar(medico);

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
            Response.Redirect("Medicos.aspx", false);
        }
    }
}