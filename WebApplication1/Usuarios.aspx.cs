using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Formulario_web117 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarUsuario.aspx");
        }
        protected void Click_Modificar(object sender, EventArgs e)
        {
            Response.Redirect("ModificarUsuario.aspx");
        }
        protected void Click_Eliminar(object sender, EventArgs e)
        {
            Response.Redirect("EliminarUsuario.aspx");
        }
    }
}