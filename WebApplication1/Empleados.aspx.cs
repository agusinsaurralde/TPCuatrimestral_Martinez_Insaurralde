﻿using System;
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
            Usuario userLog = (Usuario)Session["Usuario"];

            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "Debes iniciar sesión");
                Response.Redirect("ErrorIngreso.aspx", false);
            }
            else if(userLog.TipoUsuario.Nombre == "Médico")
            {
                Session.Add("Error", "Acceso denegado"); ;
                Response.Redirect("ErrorPermisosAcceso.aspx", false);

            }

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
            Session.Add("eliminar", (int)Grilla.DataKeys[e.RowIndex].Values[0]);
            btnEliminar_Modal.Show();
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
            Grilla.DataSource = empleadoBusqueda;
            Grilla.DataBind();
            if (empleadoBusqueda.Count != 0)
            {
                resultados.Visible = false;
            }
            else
            {
                resultados.Visible = true;
            }

        }

        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        { 
            UsuarioDB usuarioDB = new UsuarioDB();
            Usuario usuario = usuarioDB.buscarporID(Convert.ToInt32(Grilla.SelectedDataKey.Value));
            lblUsuario.Text = usuario.NombreUsuario;
            lblContraseña.Text = usuario.Contraseña;
            btnUsuario_Modal.Show();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            EmpleadoDB empleadoDB = new EmpleadoDB();
            empleadoDB.eliminar((int)Session["eliminar"]);
            UsuarioDB usuarioDB = new UsuarioDB();
            usuarioDB.eliminar((int)Session["eliminar"]);
            Grilla.DataSource = db.listarEmpleado();
            Grilla.DataBind();
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Empleado> empleadoBusqueda = db.buscarEmpleado(txtBusqueda.Text);
            Grilla.DataSource = empleadoBusqueda;
            Grilla.DataBind();
            if (empleadoBusqueda.Count != 0)
            {
                resultados.Visible = false;
            }
            else
            {
                resultados.Visible = true;
            }
        }
    }
}