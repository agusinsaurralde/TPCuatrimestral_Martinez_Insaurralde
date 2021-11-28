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
    public partial class AgregarEspecialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Click_Aceptar(object sender, EventArgs e)
        {
            Especialidad NuevaEspecialidad = new Especialidad();
            EspecialidadDB cargar = new EspecialidadDB();
            string agregado = "Especialidad";
            string error = "especialidad";

            try
            {
                NuevaEspecialidad.Nombre = txtEspecialidad.Text;
                NuevaEspecialidad.Estado = true;
                cargar.AgregarEspecialidad(NuevaEspecialidad);
                Response.Redirect("AgregarCorrecto.aspx?agregado=" + agregado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
            }

        }
    }
}