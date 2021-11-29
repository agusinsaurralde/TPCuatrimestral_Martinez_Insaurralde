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
    public partial class Formulario_web115 : System.Web.UI.Page
    {
        CoberturaDB ClinicaDB = new CoberturaDB();
        Cobertura cob = new Cobertura();
        protected void Page_Load(object sender, EventArgs e)
        {
            Grilla.DataSource = ClinicaDB.lista();
            Grilla.DataBind();
        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCobertura.aspx");
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {  
            cob.Id = (int)Grilla.DataKeys[e.RowIndex].Values[0];
            Session.Add("eliminar", ClinicaDB.buscarporID(cob));
            Response.Redirect("EliminarCobertura.aspx");
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            cob.Id = (int)Grilla.DataKeys[e.NewEditIndex].Values[0];
            Session.Add("modificar", ClinicaDB.buscarporID(cob));
            Response.Redirect("ModificarCobertura.aspx");
        }

    }
}


