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
        Paciente paciente = new Paciente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Grilla.DataSource = db.listarPaciente();
                Grilla.DataBind();
            }

        }

        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPaciente.aspx");
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {
            paciente = db.buscarporID((int)Grilla.DataKeys[e.RowIndex].Values[0]);
            Session.Add("eliminar", paciente);
            Response.Redirect("EliminarPaciente.aspx");
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            paciente = db.buscarporID((int)Grilla.DataKeys[e.NewEditIndex].Values[0]);
            Session.Add("modificar", paciente);
            Response.Redirect("ModificarPaciente.aspx");
        }

        protected void Click_Buscar(object sender, EventArgs e)
        {
            List<Paciente> pacientesBusqueda = db.buscar(txtBusqueda.Text);
            if(pacientesBusqueda != null)
            {
                Grilla.DataSource = pacientesBusqueda;
                Grilla.DataBind();
            }

        }

    }
}