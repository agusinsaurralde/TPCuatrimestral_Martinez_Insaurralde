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
    public partial class Formulario_web110 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtEspecialidad.Text = ((Especialidad)Session["modificar"]).Nombre;
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
            Especialidad modEspecialidad = new Especialidad();
            EspecialidadDB cargar = new EspecialidadDB();
            string modificado = "Especialidad";
            string error = "especialidad";

            try
            {
                modEspecialidad.Id = ((Especialidad)Session["modificar"]).Id;
                modEspecialidad.Nombre = txtEspecialidad.Text;

                cargar.ModificarEspecialidad(modEspecialidad);

                Response.Redirect("ModificarCorrecto.aspx?modificado=" + modificado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorModificar.aspx?error=" + error, false);
            }

        }

        protected void Click_Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("SpecialtysViews.aspx", false);
        }
    }
}