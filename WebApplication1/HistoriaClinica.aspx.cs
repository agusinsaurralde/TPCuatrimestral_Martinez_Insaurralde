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
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
            List<HistoriaClinica> lista = hcDB.lista();

            
            List<HistoriaClinica> listaFiltrada = new List<HistoriaClinica>();
            HistoriaClinica historia = new HistoriaClinica();
            PacienteDB pacienteDB = new PacienteDB();
            List<Paciente> listaPacientes = pacienteDB.listarPaciente();

            //guarda última historia clinica por paciente
            foreach (Paciente obj in listaPacientes)
            {
                if(lista.FindLast(x => x.Paciente.ID == obj.ID) != null)
                {
                    historia = lista.FindLast(x => x.Paciente.ID == obj.ID);
                    listaFiltrada.Add(historia);
                }

            }

            Grilla.DataSource = listaFiltrada;
            Grilla.DataBind();
            Session.Add("hcFiltrada", listaFiltrada);
        }
        protected void Click_Buscar(object sender, EventArgs e)
        {
            HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
            List<HistoriaClinica> hcBusqueda = hcDB.buscar(txtBusqueda.Text); 

            if (hcBusqueda != null)
            {
                Grilla.DataSource = hcBusqueda;
                Grilla.DataBind();
            }

        }


        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
            List<HistoriaClinica> lista = hcDB.lista();
            HistoriaClinica historiaSeleccionada = lista.Find(x => x.ID == (Convert.ToInt32(Grilla.SelectedDataKey.Value)));

            Session.Add("Historia", lista.FindAll(x => x.Paciente.ID == historiaSeleccionada.Paciente.ID));
            Response.Redirect("HistoriaClinicaDetalle.aspx");
        }
    }
}