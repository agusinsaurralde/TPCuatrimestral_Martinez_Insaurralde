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
        CoberturaDB coberturaDB = new CoberturaDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            Grilla.DataSource = coberturaDB.lista();
            Grilla.DataBind();
        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCobertura.aspx");
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {  
            Session.Add("eliminar", coberturaDB.buscarporID((int)Grilla.DataKeys[e.RowIndex].Values[0]));
            Response.Redirect("EliminarCobertura.aspx");
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            Session.Add("modificar", coberturaDB.buscarporID((int)Grilla.DataKeys[e.NewEditIndex].Values[0]));
            Response.Redirect("ModificarCobertura.aspx");
        }
        protected void Click_Buscar(object sender, EventArgs e)
        {
            List<Cobertura> coberturasBusqueda = coberturaDB.buscar(txtBusqueda.Text);
            if (coberturasBusqueda != null)
            {
                Grilla.DataSource = coberturasBusqueda;
                Grilla.DataBind();
            }
        }

    }
}


