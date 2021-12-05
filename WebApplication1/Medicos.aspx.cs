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
        MedicoDB medicoDB = new MedicoDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            Grilla.DataSource = medicoDB.listarMedico();
            Grilla.DataBind();
        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMedico.aspx");
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {
            int med = (int)Grilla.DataKeys[e.RowIndex].Values[0];
            Session.Add("eliminar", medicoDB.buscarporID(med));
            Response.Redirect("EliminarMedico.aspx");
        }  
        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            int med = (int)Grilla.DataKeys[e.NewEditIndex].Values[0];
            Session.Add("modificar", medicoDB.buscarporID(med)); 
            Response.Redirect("ModificarMedico.aspx");
        }
 

        protected void Click_Buscar(object sender, EventArgs e)
        {
            List<Medico> medicosBusqueda = medicoDB.buscar(txtBusqueda.Text);
            if (medicosBusqueda != null)
            {
                Grilla.DataSource = medicosBusqueda;
                Grilla.DataBind();
            }
            else
            {
                lblBusquedaIncorrecta.Text = "No se encontraron resultados.";
            }

        }

        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Add("EspMedico", medicoDB.listarEspecialidadesMedico(Convert.ToInt32(Grilla.SelectedDataKey.Value)));
            Response.Redirect("EspecialidadesMedico.aspx");
        }
    }
}