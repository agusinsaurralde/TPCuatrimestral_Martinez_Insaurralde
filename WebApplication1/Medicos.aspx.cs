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
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MedicoDB medico = new MedicoDB();
            Grilla.DataSource = medico.listarMedico();
            Grilla.DataBind();
        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMedico.aspx");
        }
        protected void Click_Modificar(object sender, EventArgs e)
        {
            Response.Redirect("ModificarMedico.aspx");
        }
        protected void Click_Eliminar(object sender, EventArgs e)
        {
            Response.Redirect("EliminarMedico.aspx");
        }
    }
}