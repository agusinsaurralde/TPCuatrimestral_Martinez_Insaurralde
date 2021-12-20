using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBClinica;
using Dominio;

namespace WebApplication1
{
    public partial class Formulario_web18 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario userLog = (Usuario)Session["Usuario"];

            if ((HistoriaClinica)Session["modificar"] == null)
            {
                Response.Redirect("ErrorPermisosAcceso");
            }
            else if (userLog.TipoUsuario.Nombre == "Recepcionista")
            {
                Session.Add("Error", "Acceso denegado"); ;
                Response.Redirect("ErrorPermisosAcceso.aspx", false);

            }
            if (!IsPostBack)
            {
                HistoriaClinica datos = (HistoriaClinica)Session["modificar"];
                txtNombrePaciente.Text = datos.Paciente.NombreCompleto;
                lblFecha.Text = datos.Fecha.ToShortDateString();
                txtDescripcion.Text = datos.Descripcion;
            }
           
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {

                HistoriaClinica hc = new HistoriaClinica();
                HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
                HistoriaClinica datos = (HistoriaClinica)Session["modificar"];

                hc.ID = ((HistoriaClinica)Session["modificar"]).ID;
                hc.Descripcion = txtDescripcion.Text;

                hcDB.ModificarHistoriaClinica(hc);
                ejecutarModalModificarHistoria();
            }
            catch (Exception)
            {
                ejecutarModalModificarHistoriaCatch();
            }

        }


        protected void btnCerrarModalModificarHistoriaClinica_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistoriaClinica.aspx", false);
        }

        protected void ejecutarModalModificarHistoria()
        {
            lblTituloModificarHistoriaClinica.Text = "Modificado!";
            lblHistoriaClinicaContext.Text = "La historia fue modificada con éxito!";
            btnEditarHistoriaClinica_Modal.Show();
        }

        protected void ejecutarModalModificarHistoriaCatch()
        {
            lblTituloModificarHistoriaClinica.Text = "Error!";
            lblHistoriaClinicaContext.Text = "No se pudieron guardar los cambios!";
            btnEditarHistoriaClinica_Modal.Show();
        }



    }
}