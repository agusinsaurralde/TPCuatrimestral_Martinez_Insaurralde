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
    public partial class AgregarHistoriaClinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Turno datos = (Turno)Session["agregarHistoriaClinica"];
           txtNombrePaciente.Text = datos.Paciente.NombreCompleto;
            lblFecha.Text = datos.Dia.ToShortDateString();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string agregado = "Historia clínica";
            string error = "historia clínica";
            try
            { 

                HistoriaClinica hc = new HistoriaClinica();
                HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
                Turno datos = (Turno)Session["agregarHistoriaClinica"];

                hc.Paciente = new Paciente();
                hc.Paciente.ID = datos.Paciente.ID;
                hc.Descripcion = txtDescripcion.Text;
                hc.Fecha = datos.Dia;
                

                hcDB.AgregarHistoriaClinica(hc);
                Response.Redirect("AgregarCorrecto.aspx?agregado=" + agregado, false);
            }
            catch (Exception ex)
            {
                //Response.Redirect("ErrorAgregar.aspx?agregado=" + error, false);

               throw ex;
            }
           
        }
    }
}