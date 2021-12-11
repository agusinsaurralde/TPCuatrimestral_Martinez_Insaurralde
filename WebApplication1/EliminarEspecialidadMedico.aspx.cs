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
    public partial class EliminarEspecialidadMedico : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Click_Aceptar(object sender, EventArgs e)
        {
            MedicoEspecialidades eliminar = (MedicoEspecialidades)Session["eliminar"];
            MedicoDB medicoDB = new MedicoDB();
            medicoDB.eliminarEspecialidad(eliminar);
        }
        protected void Click_Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("ModificarEspecialidadMedico.aspx");
        }
    }
}