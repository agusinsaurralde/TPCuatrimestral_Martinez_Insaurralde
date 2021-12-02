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

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {
            int med = (int)Grilla.DataKeys[e.RowIndex].Values[0];
            Session.Add("eliminar", medico.buscarporID(med));
            Response.Redirect("EliminarMedico.aspx");
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            int med = (int)Grilla.DataKeys[e.NewEditIndex].Values[0];
            Session.Add("modificar", medico.buscarporID(med)); 
            Response.Redirect("ModificarMedico.aspx");
        }

        
    }
}