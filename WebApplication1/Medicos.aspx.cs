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
            if (!IsPostBack)
            {
                List<Medico> listaMedicos = medicoDB.listarMedico();
                Grilla.DataSource = listaMedicos;
                Grilla.DataBind();
            }

        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMedico.aspx");
        }
        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {
            Session.Add("idEliminar", (int)Grilla.DataKeys[e.RowIndex].Values[0]);
            btnEliminar_Modal.Show();
        }  
        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            int ID = (int)Grilla.DataKeys[e.NewEditIndex].Values[0];
            Medico medico = medicoDB.buscarporID(ID);
            Usuario usuario = usuarioDB.buscarporID(ID);
            Session.Add("modificar", medico);
            Session.Add("modificarUsuario", usuario);
            Response.Redirect("ModificarMedico.aspx");
        }

        protected void Click_Buscar(object sender, EventArgs e)
        {
            List<Medico> medicosBusqueda = medicoDB.buscar(txtBusqueda.Text);
            Grilla.DataSource = medicosBusqueda;
            Grilla.DataBind();
            if (medicosBusqueda.Count != 0)
            {
                lblBusquedaIncorrecta.Visible = false;
            }
            else
            {
                lblBusquedaIncorrecta.Visible = true;
            }

        }

        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        {   
            Session.Add("EspMedico", medicoDB.listarEspecialidadesDeUnMedico(Convert.ToInt32(Grilla.SelectedDataKey.Value)));
            Session.Add("DiasHabiles", medicoDB.listarDiasHabilesDeUnMedico(Convert.ToInt32(Grilla.SelectedDataKey.Value)));
            Response.Redirect("EspecialidadesMedico.aspx");
        }

        protected void btnAceptarEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                MedicoDB medicoDB = new MedicoDB();
                medicoDB.eliminar((int)Session["idEliminar"]);
                Grilla.DataSource = medicoDB.listarMedico();
                Grilla.DataBind();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Medico> medicosBusqueda = medicoDB.buscar(txtBusqueda.Text);
            Grilla.DataSource = medicosBusqueda;
            Grilla.DataBind();
            if (medicosBusqueda.Count != 0)
            {
                lblBusquedaIncorrecta.Visible = false;
            }
            else
            {
                lblBusquedaIncorrecta.Visible = true;
            }
        }
    }
}