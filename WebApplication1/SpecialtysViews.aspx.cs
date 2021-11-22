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
    public partial class SpecialtysViews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadDB ClinicaDB = new EspecialidadDB();
            Grilla.DataSource = ClinicaDB.lista();
            Grilla.DataBind();
        }

        protected void Click_Modificar(object sender, EventArgs e)
        {
            Response.Redirect("ModificarEspecialidad.aspx");
        }
        protected void Click_Eliminar(object sender, EventArgs e)
        {
            Response.Redirect("EliminarEspecialidad.aspx");
        }
    }
}