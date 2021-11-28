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
    public partial class Contact : Page
    {
        MedicoDB medico = new MedicoDB();
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {
            Medico med = new Medico();
            med.ID = (int)Grilla.DataKeys[e.RowIndex].Values[0];
            medico.eliminar(med);
            Grilla.EditIndex = -1;
            Grilla.DataSource = medico.listarMedico();
            Grilla.DataBind();
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            Medico med = new Medico();
            med.ID = (int)Grilla.DataKeys[e.NewEditIndex].Values[0];

            Session.Add("modificar", medico.buscarporID(med)); 
            Response.Redirect("ModificarMedico.aspx");
        }

        
    }
}