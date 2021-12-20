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
            Usuario userLog = (Usuario)Session["Usuario"];

            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "Debes iniciar sesión");
                Response.Redirect("ErrorIngreso.aspx", false);
            }
            else if (userLog.TipoUsuario.Nombre == "Médico")
            {
                Session.Add("Error", "Acceso denegado"); ;
                Response.Redirect("ErrorPermisosAcceso.aspx", false);

            }
            else if (userLog.TipoUsuario.Nombre == "Recepcionista")
            {
                Session.Add("Error", "Acceso denegado"); ;
                Response.Redirect("ErrorPermisosAcceso.aspx", false);
            }
            if (!IsPostBack)
            {
                Grilla.DataSource = coberturaDB.lista();
                Grilla.DataBind();
            }  
        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            if (txtCobertura.Text != "")
                txtCobertura.Text = "";

            if(errorAgregar.Visible)
                 errorAgregar.Visible = false;
            btnAgregarCobertura_Modal.Show();
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {  
            Session.Add("eliminar", coberturaDB.buscarporID((int)Grilla.DataKeys[e.RowIndex].Values[0]));
            eliminarCobertura_Modal.Show();
        }

        protected void Click_Buscar(object sender, EventArgs e)
        {
            List<Cobertura> coberturasBusqueda = coberturaDB.buscar(txtBusqueda.Text);
            Grilla.DataSource = coberturasBusqueda;
            Grilla.DataBind();
            if (coberturasBusqueda.Count != 0)
            {
                resultados.Visible = false;
            }
            else
            {
                resultados.Visible = true;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Cobertura NuevaCobertura = new Cobertura();
            CoberturaDB cargar = new CoberturaDB();
            string error = "cobertura";


            List<Cobertura> lista = coberturaDB.lista();
            if (lista.Find(x => x.Nombre.ToUpper() == txtCobertura.Text.ToUpper() && x.Estado == true) != null)
            {
                errorAgregar.Visible = true;
                errorAgregar.Text = "*La cobertura ingresada ya existe";
                btnAgregarCobertura_Modal.Show();
            }
            else if (txtCobertura.Text == "")
            {
                errorAgregar.Visible = true;
                errorAgregar.Text = "*Debe completar el campo";
                btnAgregarCobertura_Modal.Show();
            }
            else
            {
                try
                {
                    NuevaCobertura.Nombre = txtCobertura.Text;
                    NuevaCobertura.Estado = true;
                    cargar.AgregarCobertura(NuevaCobertura);
                    Grilla.DataSource = coberturaDB.lista();
                    Grilla.DataBind();
                    lblTituloAlertModal.Text = "Agregar Cobertura";
                    lblVerificacion.Text = "Cobertura agregada con éxito.";
                    verificacion_Modal.Show();
                }
                catch (Exception)
                {
                    lblTituloAlertModal.Text = "Error";
                    lblVerificacion.Text = "Hubo un error al agregar la cobertura.";
                    verificacion_Modal.Show();
                }
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
                lblTituloAlertModal.Text = "Eliminar Cobertura";
                lblVerificacion.Text = "Cobertura eliminada con éxito.";
                verificacion_Modal.Show();


            }
            catch (Exception)
            {
                lblTituloAlertModal.Text = "Error";
                lblVerificacion.Text = "Hubo un error al eliminar la cobertura.";
                verificacion_Modal.Show();
            }
        }

        protected void btnAceptarEditar_Click(object sender, EventArgs e)
        {
            Cobertura modCobertura = new Cobertura();
            CoberturaDB cargar = new CoberturaDB();
            string error = "cobertura";
            List<Cobertura> lista = coberturaDB.lista();

            if (lista.Find(x => x.Nombre.ToUpper() == txtEditarCobertura.Text.ToUpper() && x.Estado == true && x.Id != ((Cobertura)Session["modificar"]).Id) != null)
            {
                errorEditar.Visible = true;
                errorEditar.Text = "*La cobertura ingresada ya existe";
                editarCobertura_Modal.Show();
            }
            else if (txtEditarCobertura.Text == "")
            {
                errorEditar.Visible = true;
                errorEditar.Text = "*Debe completar el campo";
                editarCobertura_Modal.Show();
            }
            else
            {
                try
                {
                    modCobertura.Id = ((Cobertura)Session["modificar"]).Id;
                    modCobertura.Nombre = txtEditarCobertura.Text;
                    modCobertura.Estado = true;

                    cargar.ModificarCobertura(modCobertura);
                    Grilla.DataSource = coberturaDB.lista();
                    Grilla.DataBind();
                    lblTituloAlertModal.Text = "Modificar Cobertura";
                    lblVerificacion.Text = "Cobertura modificada con éxito.";
                    verificacion_Modal.Show();

                }
                catch (Exception)
                {
                    lblTituloAlertModal.Text = "Error";
                    lblVerificacion.Text = "Hubo un error al modificar la cobertura.";
                    verificacion_Modal.Show();
                }
            }
           
        }

        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(errorEditar.Visible)
                errorEditar.Visible = false;
            Session.Add("modificar", coberturaDB.buscarporID(Convert.ToInt32(Grilla.SelectedDataKey.Value)));
            txtEditarCobertura.Text = ((Cobertura)Session["modificar"]).Nombre;
            editarCobertura_Modal.Show();
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Cobertura> cobertura = coberturaDB.buscar(txtBusqueda.Text);
            Grilla.DataSource = cobertura;
            Grilla.DataBind();
            if (cobertura.Count != 0)
            {
                resultados.Visible = false;
            }
            else
            {
                resultados.Visible = true;
            }
        }

        protected void btnDarDeAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaCobertura.aspx");
        }
    }
}


