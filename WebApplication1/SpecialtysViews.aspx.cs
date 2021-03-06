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
    public partial class SpecialtysViews : System.Web.UI.Page
    {
        EspecialidadDB especialidadDB = new EspecialidadDB();
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
                Grilla.Columns[0].Visible = false;
                Grilla.Columns[2].Visible = false;
                Grilla.Columns[3].Visible = false;
                btnDarDeAlta.Visible = false;
                btnAgregar.Visible = false;
            }
            if (!IsPostBack)
            {
                Grilla.DataSource = especialidadDB.lista();
                Grilla.DataBind();
            }

            
        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            if(txtEspecialidad.Text != "")
                txtEspecialidad.Text = "";

            if (errorAgregar.Visible)
                errorAgregar.Visible = false;
            btnAgregarEspecialidad_Modal.Show();
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {
            Session.Add("eliminar", especialidadDB.buscarporID((int)Grilla.DataKeys[e.RowIndex].Values[0]));
            eliminarEspecialidad_Modal.Show();
        }

        protected void Click_Buscar(object sender, EventArgs e)
        {
            List<Especialidad> especialidadBusqueda = especialidadDB.buscar(txtBusqueda.Text);
            Grilla.DataSource = especialidadBusqueda;
            Grilla.DataBind();
            if (especialidadBusqueda.Count != 0)
            {
                resultados.Visible = false;
            }
            else
            {
                resultados.Visible = true;
            }
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Especialidad> especialidadBusqueda = especialidadDB.buscar(txtBusqueda.Text);
            Grilla.DataSource = especialidadBusqueda;
            Grilla.DataBind();
            if (especialidadBusqueda.Count != 0)
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
            Especialidad NuevaEspecialidad = new Especialidad();
            EspecialidadDB cargar = new EspecialidadDB();

            List<Especialidad> lista = especialidadDB.lista();
            if (lista.Find(x => x.Nombre.ToUpper() == txtEspecialidad.Text.ToUpper() && x.Estado == true) != null)
            {
                errorAgregar.Visible = true;
                errorAgregar.Text = "*La especialidad ingresada ya existe";
                btnAgregarEspecialidad_Modal.Show();

            }
            else if (txtEspecialidad.Text == "")
            {
                errorAgregar.Visible = true;
                errorAgregar.Text = "*Debe completar el campo";
                btnAgregarEspecialidad_Modal.Show();
            }
            else
            {
                try
                {
                    NuevaEspecialidad.Nombre = txtEspecialidad.Text;
                    NuevaEspecialidad.Estado = true;
                    cargar.AgregarEspecialidad(NuevaEspecialidad);
                    Grilla.DataSource = especialidadDB.lista();
                    Grilla.DataBind();

                    lblTituloAlertModal.Text = "Agregar Especialidad";
                    lblVerificacion.Text = "Especialidad agregada con éxito.";
                    verificacion_Modal.Show();
                }
                catch (Exception)
                {
                    lblTituloAlertModal.Text = "Error";
                    lblVerificacion.Text = "Hubo un error al agregar la especialidad.";
                    verificacion_Modal.Show();

                }
            }
               
        }
        protected void btnAceptarEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                Especialidad especialidad = new Especialidad();
                EspecialidadDB db = new EspecialidadDB();
                especialidad = (Especialidad)Session["eliminar"];
                db.EliminarEspecialidad(especialidad);
                Grilla.DataSource = db.lista();
                Grilla.DataBind();
                lblTituloAlertModal.Text = "Eliminar Especialidad";
                lblVerificacion.Text = "Especialidad eliminada con éxito.";
                verificacion_Modal.Show();

            }
            catch (Exception)
            {
                lblTituloAlertModal.Text = "Error";
                lblVerificacion.Text = "Hubo un error al eliminar la especialidad.";
                verificacion_Modal.Show();
            }
        }

        protected void btnAceptarEditar_Click(object sender, EventArgs e)
        {
            List<Especialidad> lista = especialidadDB.lista();
            if (lista.Find(x => x.Nombre.ToUpper() == txtEditarEspecialidad.Text.ToUpper() && x.Estado == true && x.Id != (int)Session["idEditarEspecialidad"]) != null)
            {
                errorEditar.Visible = true;
                errorEditar.Text = "*La cobertura ingresada ya existe";
                editarEspecialidad_Modal.Show();
            }
            else if (txtEditarEspecialidad.Text == "")
            {
                errorEditar.Visible = true;
                errorEditar.Text = "*Debe completar el campo";
                editarEspecialidad_Modal.Show();

            }
            else
            {
                Especialidad modEspecialidad = new Especialidad();
                EspecialidadDB cargar = new EspecialidadDB();
                try
                {
                    modEspecialidad.Id = (int)Session["idEditarEspecialidad"];
                    modEspecialidad.Nombre = txtEditarEspecialidad.Text;

                    cargar.ModificarEspecialidad(modEspecialidad);
                    Grilla.DataSource = especialidadDB.lista();
                    Grilla.DataBind();
                    lblTituloAlertModal.Text = "Modificar Especialidad";
                    lblVerificacion.Text = "Especialidad modificada con éxito.";
                    verificacion_Modal.Show();

                }
                catch (Exception)
                {
                    lblTituloAlertModal.Text = "Error";
                    lblVerificacion.Text = "Hubo un error al modificar la especialidad.";
                    verificacion_Modal.Show();
                }
            }
                
        }

        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(errorEditar.Visible)
                errorEditar.Visible = false;

            int id = Convert.ToInt32(Grilla.SelectedDataKey.Value);
            Session.Add("idEditarEspecialidad", id);
            Especialidad esp = especialidadDB.buscarporID(id);
            txtEditarEspecialidad.Text = esp.Nombre;
            editarEspecialidad_Modal.Show();
        }

        protected void btnDarDeAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaEspecialidad.aspx");
        }
    }
}