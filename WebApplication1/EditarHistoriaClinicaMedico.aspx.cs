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
            HistoriaClinica datos = (HistoriaClinica)Session["modificar"];
            txtNombrePaciente.Text = datos.Paciente.NombreCompleto;
            lblFecha.Text = datos.Fecha.ToShortDateString();
            txtDescripcion.Text = datos.Descripcion;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string modificado = "Historia clínica";
            string error = "historia clínica";
            try
            {

                HistoriaClinica hc = new HistoriaClinica();
                HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
                HistoriaClinica datos = (HistoriaClinica)Session["modificar"];

                hc.Paciente = new Paciente();
                hc.Paciente.ID = datos.Paciente.ID;
                hc.Descripcion = txtDescripcion.Text;
                hc.Fecha = DateTime.Now;


                hcDB.ModificarHistoriaClinica(hc);

                ejecutarModalModificarHistoria();
                //Response.Redirect("ModificarCorrecto.aspx?modificado=" + modificado, false);
            }
            catch (Exception ex)
            {
                //Response.Redirect("ErrorModificar.aspx?agregado=" + error, false);

                ejecutarModalModificarHistoria();

                throw ex;
            }

        }


        protected void btnCerrarModalModificarHistoriaClinica_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistoriaClinica.aspx", false);
        }

        protected void ejecutarModalModificarHistoria()
        {
            lblTituloModificarHistoriaClinica.Text = "Modificado! ";
            lblHistoriaClinicaContext.Text = "Se modifico correctamente!";
            btnEditarHistoriaClinica_Modal.Show();
        }

        protected void ejecutarModalModificarHistoriaCatch()
        {
            lblTituloModificarHistoriaClinica.Text = "Error! ";
            lblHistoriaClinicaContext.Text = "No se pudieron guardar los cambios!.";
            btnEditarHistoriaClinica_Modal.Show();
        }



    }
}