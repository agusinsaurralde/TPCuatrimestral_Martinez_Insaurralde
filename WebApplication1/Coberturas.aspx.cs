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
            if (!IsPostBack)
            {
                Grilla.DataSource = coberturaDB.lista();
                Grilla.DataBind();
            }  
        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            btnAgregarCobertura_Modal.Show();
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {  
            Session.Add("eliminar", coberturaDB.buscarporID((int)Grilla.DataKeys[e.RowIndex].Values[0]));
            eliminarCobertura_Modal.Show();
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            Session.Add("modificar", coberturaDB.buscarporID((int)Grilla.DataKeys[e.NewEditIndex].Values[0]));
            txtEditarCobertura.Text = ((Cobertura)Session["modificar"]).Nombre;
            editarCobertura_Modal.Show();
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

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Cobertura NuevaCobertura = new Cobertura();
            CoberturaDB cargar = new CoberturaDB();
            string error = "cobertura";

            try
            {
                NuevaCobertura.Nombre = txtCobertura.Text;
                NuevaCobertura.Estado = true;
                cargar.AgregarCobertura(NuevaCobertura);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
            }
        }

        protected void btnAceptarEliminar_Click(object sender, EventArgs e)
        {
            string error = "cobertura";
            try
            {

                Cobertura cobertura = new Cobertura();
                CoberturaDB db = new CoberturaDB();
                cobertura = (Cobertura)Session["eliminar"];
                db.EliminarCobertura(cobertura);
                Grilla.DataSource = coberturaDB.lista();
                Grilla.DataBind();


            }
            catch (Exception)
            {
                Response.Redirect("ErrorEliminar.aspx?error=" + error, false);
            }
        }

        protected void btnAceptarEditar_Click(object sender, EventArgs e)
        {
            Cobertura modCobertura = new Cobertura();
            CoberturaDB cargar = new CoberturaDB();
            string error = "cobertura";

            try
            {
                modCobertura.Id = ((Cobertura)Session["modificar"]).Id;
                modCobertura.Nombre = txtEditarCobertura.Text;

                cargar.ModificarCobertura(modCobertura);

            }
            catch (Exception)
            {
                Response.Redirect("ErrorModificar.aspx?error=" + error, false);
            }
        }
    }
}


