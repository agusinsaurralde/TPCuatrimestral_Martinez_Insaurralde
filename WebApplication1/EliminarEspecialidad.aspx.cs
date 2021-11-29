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
    public partial class Formulario_web111 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNombre.Text = ((Especialidad)Session["eliminar"]).Nombre;
            }
        }

        protected void Click_Aceptar(object sender, EventArgs e)
        {
            string eliminado = "Especialidad";
            string error = "especialidad";
            try
            {
                Especialidad especialidad = new Especialidad();
                EspecialidadDB db = new EspecialidadDB();
                especialidad = (Especialidad)Session["eliminar"];
                db.EliminarEspecialidad(especialidad);

                Response.Redirect("EliminarCorrecto.aspx?eliminado=" + eliminado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorEliminar.aspx?error=" + error, false);
            }
        }
        protected void Click_Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("SpecialitysViews.aspx", false);
        }
    }
}
