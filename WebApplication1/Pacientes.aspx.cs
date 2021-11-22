using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Click_Modificar(object sender, EventArgs e)
        {
            Response.Redirect("ModificarPaciente.aspx");
        }
        protected void Click_Eliminar(object sender, EventArgs e)
        {
            Response.Redirect("EliminarPaciente.aspx");
        }

        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPaciente.aspx");
        }


    }
}