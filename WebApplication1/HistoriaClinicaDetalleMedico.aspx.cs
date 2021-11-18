using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Formulario_web16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Click_Editar(object sender, EventArgs e)
        {
            Response.Redirect("EditarHistoriaClinicaMedico.aspx", false);
        }
    }
}