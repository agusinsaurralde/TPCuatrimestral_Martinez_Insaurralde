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
        EspecialidadDB ClinicaDB = new EspecialidadDB();
        protected void Page_Load(object sender, EventArgs e)
        { 
            Grilla.DataSource = ClinicaDB.lista();
            Grilla.DataBind();
        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEspecialidad.aspx");
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {
            Especialidad esp = new Especialidad();
            esp.Id = (int)Grilla.DataKeys[e.RowIndex].Values[0];
            Session.Add("eliminar", ClinicaDB.buscarporID(esp));
            Response.Redirect("EliminarEspecialidad.aspx");
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            Especialidad esp = new Especialidad();
            esp.Id = (int)Grilla.DataKeys[e.NewEditIndex].Values[0];
            Session.Add("modificar", ClinicaDB.buscarporID(esp));
            Response.Redirect("ModificarEspecialidad.aspx");
        }

    }
}