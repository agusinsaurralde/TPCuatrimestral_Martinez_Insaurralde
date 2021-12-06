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
        EspecialidadDB especialidadDB = new EspecialidadDB();
        protected void Page_Load(object sender, EventArgs e)
        { 
            Grilla.DataSource = especialidadDB.lista();
            Grilla.DataBind();
        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEspecialidad.aspx");
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {
            Session.Add("eliminar", especialidadDB.buscarporID((int)Grilla.DataKeys[e.RowIndex].Values[0]));
            Response.Redirect("EliminarEspecialidad.aspx");
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            Session.Add("modificar", especialidadDB.buscarporID((int)Grilla.DataKeys[e.NewEditIndex].Values[0]));
            Response.Redirect("ModificarEspecialidad.aspx");
        }

        protected void Click_Buscar(object sender, EventArgs e)
        {
            List<Especialidad> especialidadBusqueda = especialidadDB.buscar(txtBusqueda.Text);
            if (especialidadBusqueda != null)
            {
                Grilla.DataSource = especialidadBusqueda;
                Grilla.DataBind();
            }
        }

    }
}