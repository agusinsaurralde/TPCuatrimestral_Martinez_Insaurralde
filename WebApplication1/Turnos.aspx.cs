using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Redirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarTurno.aspx", false);
        }
        protected void Click_VerTurnos(object sender, EventArgs e)
        {
            Response.Redirect("VerTurno.aspx", false);
        }

        protected void SpecialtysView_Click(object sender, EventArgs e)
        {
            Response.Redirect("SpecialtysViews.aspx", false);
        }
    }
}