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
            Session.Add("eliminar", (int)Grilla.DataKeys[e.RowIndex].Values[0]);
            EliminarPaciente_Modal.Show();
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
            Grilla.DataSource = pacientesBusqueda;
            Grilla.DataBind();
            if (pacientesBusqueda.Count != 0)
            {
                resultados.Visible = false;
            }
            else
            {
                resultados.Visible = true;
            }

        }

        protected void btnAceptarEliminar_Click(object sender, EventArgs e)
        {
            string error = "paciente";
            try
            {
                int idPaciente = (int)Session["eliminar"];
                db.eliminar(idPaciente);
                Grilla.DataSource = db.listarPaciente();
                Grilla.DataBind();
            }
            catch (Exception)
            {
                Response.Redirect("ErrorEliminar.aspx?error=" + error, false);
            }
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Paciente> pacientesBusqueda = db.buscar(txtBusqueda.Text);
            Grilla.DataSource = pacientesBusqueda;
            Grilla.DataBind();
            if (pacientesBusqueda.Count != 0)
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