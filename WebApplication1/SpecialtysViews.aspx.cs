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
            if (!IsPostBack)
            {
                Grilla.DataSource = especialidadDB.lista();
                Grilla.DataBind();
            }

            
        }
        protected void Click_Agregar(object sender, EventArgs e)
        {
            btnAgregarEspecialidad_Modal.Show();
        }

        protected void Grilla_eliminar(object sender, GridViewDeleteEventArgs e)
        {
            Session.Add("eliminar", especialidadDB.buscarporID((int)Grilla.DataKeys[e.RowIndex].Values[0]));
            eliminarEspecialidad_Modal.Show();
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            /*Session.Add("modificar", especialidadDB.buscarporID((int)Grilla.DataKeys[e.NewEditIndex].Values[0]));
            txtEditarEspecialidad.Text = ((Especialidad)Session["modificar"]).Nombre;
            editarEspecialidad_Modal.Show();*/
            precargar((int)Grilla.DataKeys[e.NewEditIndex].Values[0]);
            editarEspecialidad_Modal.Show();
        }

        protected void precargar(int id)
        {
           Especialidad esp = especialidadDB.buscarporID(id);
           txtEditarEspecialidad.Text = esp.Nombre;
        }

        protected void Click_Buscar(object sender, EventArgs e)
        {
            List<Especialidad> especialidadBusqueda = especialidadDB.buscar(txtBusqueda.Text);
            if (especialidadBusqueda != null)
            {
                Grilla.DataSource = especialidadBusqueda;
                Grilla.DataBind();
            }
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Especialidad> especialidadBusqueda = especialidadDB.buscar(txtBusqueda.Text);
            if (especialidadBusqueda != null)
            {
                Grilla.DataSource = especialidadBusqueda;
                Grilla.DataBind();
            }
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Especialidad NuevaEspecialidad = new Especialidad();
            EspecialidadDB cargar = new EspecialidadDB();
            string error = "especialidad";

            try
            {
                NuevaEspecialidad.Nombre = txtEspecialidad.Text;
                NuevaEspecialidad.Estado = true;
                cargar.AgregarEspecialidad(NuevaEspecialidad);
                Grilla.DataSource = especialidadDB.lista();
                Grilla.DataBind();
            }
            catch (Exception)
            {
                Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
            }
        }
        protected void btnAceptarEliminar_Click(object sender, EventArgs e)
        {
            string error = "especialidad";
            try
            {

                Especialidad especialidad = new Especialidad();
                EspecialidadDB db = new EspecialidadDB();
                especialidad = (Especialidad)Session["eliminar"];
                db.EliminarEspecialidad(especialidad);
                Grilla.DataSource = db.lista();
                Grilla.DataBind();


            }
            catch (Exception)
            {
                Response.Redirect("ErrorEliminar.aspx?error=" + error, false);
            }
        }

        protected void btnAceptarEditar_Click(object sender, EventArgs e)
        {
            Especialidad modEspecialidad = new Especialidad();
            EspecialidadDB cargar = new EspecialidadDB();
            string error = "especialidad";

            try
            {
                modEspecialidad.Id = ((Especialidad)Session["id"]).Id;
                modEspecialidad.Nombre = txtEditarEspecialidad.Text;

                cargar.ModificarEspecialidad(modEspecialidad);

            }
            catch (Exception)
            {
                Response.Redirect("ErrorModificar.aspx?error=" + error, false);
            }
        }

       
    }
}