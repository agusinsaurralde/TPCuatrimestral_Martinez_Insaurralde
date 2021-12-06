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
    public partial class Empleados : System.Web.UI.Page
    {
        EmpleadoDB db = new EmpleadoDB();
        Empleado emp = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {
                Grilla.DataSource = db.listarEmpleado();
                Grilla.DataBind();
        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEmpleado.aspx");
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {
            Session.Add("eliminar", db.buscarporID((int)Grilla.DataKeys[e.RowIndex].Values[0]));
            Response.Redirect("EliminarEmpleado.aspx");
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            Session.Add("modificar", db.buscarporID((int)Grilla.DataKeys[e.NewEditIndex].Values[0]));
            Response.Redirect("ModificarEmpleado.aspx");
        }
        protected void Click_Buscar(object sender, EventArgs e)
        {
            List<Empleado> empleadoBusqueda = db.buscarEmpleado(txtBusqueda.Text);
            if (empleadoBusqueda != null)
            {
                Grilla.DataSource = empleadoBusqueda;
                Grilla.DataBind();
            }

        }
    }
}