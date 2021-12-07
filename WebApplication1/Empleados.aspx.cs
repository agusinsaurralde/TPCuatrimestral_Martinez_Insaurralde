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
            UsuarioDB usuarioDB = new UsuarioDB();
            Session.Add("eliminar", db.buscarporID((int)Grilla.DataKeys[e.RowIndex].Values[0]));
            Session.Add("eliminarUsuario", usuarioDB.buscarporID((int)Grilla.DataKeys[e.RowIndex].Values[0]));
            Response.Redirect("EliminarEmpleado.aspx");
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            Session.Add("modificar", db.buscarporID((int)Grilla.DataKeys[e.NewEditIndex].Values[0]));
            Session.Add("modificarUsuario", usuarioDB.buscarporID((int)Grilla.DataKeys[e.NewEditIndex].Values[0]));
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

        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            Session.Add("DetalleEmpleado", usuarioDB.buscarporID(Convert.ToInt32(Grilla.SelectedDataKey.Value)));
            Response.Redirect("DetalleEmpleados.aspx");

        }
    }
}