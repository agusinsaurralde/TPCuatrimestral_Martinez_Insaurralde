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
            if (!IsPostBack)
            {
                Grilla.DataSource = db.listarEmpleado();
                Grilla.DataBind();

            }

        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEmpleado.aspx");
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {
            emp.ID = (int)Grilla.DataKeys[e.RowIndex].Values[0];
            Session.Add("eliminar", db.buscarporID(emp));
            Response.Redirect("EliminarEmpleado.aspx");
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            emp.ID = (int)Grilla.DataKeys[e.NewEditIndex].Values[0];
            Session.Add("modificar", db.buscarporID(emp));
            Response.Redirect("ModificarEmpleado.aspx");
        }
    }
}