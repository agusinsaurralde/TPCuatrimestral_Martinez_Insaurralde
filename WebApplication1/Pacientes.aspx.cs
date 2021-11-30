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
    public partial class About : Page
    {
        PacienteDB db = new PacienteDB();
        Paciente pac = new Paciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            Grilla.DataSource = db.listarPaciente();
            Grilla.DataBind();
        }

        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPaciente.aspx");
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {
            pac.ID = (int)Grilla.DataKeys[e.RowIndex].Values[0];
            Session.Add("eliminar", db.buscarporID(pac));
            Response.Redirect("EliminarPaciente.aspx");
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            pac.ID = (int)Grilla.DataKeys[e.NewEditIndex].Values[0];
            Session.Add("modificar", db.buscarporID(pac));
            Response.Redirect("ModificarPaciente.aspx");
        }
    }
}