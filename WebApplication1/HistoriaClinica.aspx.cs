using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Click_Ver(object sender, EventArgs e)
        {
            Response.Redirect("HistoriaClinicaDetalle.aspx", false);
        }
        protected void Click_Eliminar(object sender, EventArgs e)
        {
            Response.Redirect("EliminarHistoriaClinica.aspx", false);
        }

    }
}