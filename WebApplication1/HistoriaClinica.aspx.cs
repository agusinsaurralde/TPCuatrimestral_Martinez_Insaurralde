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
            Usuario userLog = (Usuario)Session["Usuario"];

            if (userLog == null)
            {
                Session.Add("Error", "Debes iniciar sesión");
                Response.Redirect("ErrorIngreso.aspx", false);
            }
            else if (userLog.TipoUsuario.Nombre == "Recepcionista")
            {
                Session.Add("Error", "Acceso denegado");
                Response.Redirect("ErrorPermisosAcceso.aspx", false);
            }
            else
            {
                EmpleadoDB empleadoLogDB = new EmpleadoDB();
                Empleado empleadoLog = new Empleado();
                empleadoLog = empleadoLogDB.empleadoLogueado((int)userLog.IDUsuario);

                HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
                List<HistoriaClinica> lista = hcDB.lista();


                List<HistoriaClinica> listaFiltrada = new List<HistoriaClinica>();
                HistoriaClinica historia = new HistoriaClinica();
                PacienteDB pacienteDB = new PacienteDB();
                List<Paciente> listaPacientes = pacienteDB.listarPaciente();

               
                

                //filtra historias según el médico logueado
                if (userLog.TipoUsuario.Nombre == "Médico")
                {
                    //guarda última historia clinica por paciente
                    foreach (Paciente obj in listaPacientes)
                    {
                        if (lista.FindLast(x => x.Paciente.ID == obj.ID && x.Medico.ID == empleadoLog.ID) != null)
                        {
                            historia = lista.FindLast(x => x.Paciente.ID == obj.ID && x.Medico.ID == empleadoLog.ID);
                            listaFiltrada.Add(historia);
                        }

                    }

                    Grilla.DataSource = listaFiltrada;
                    Grilla.DataBind();
                    Session.Add("listaMedico", listaFiltrada);
                }
                else
                {//lista para administrador
                    foreach (Paciente obj in listaPacientes)
                    {
                        if (lista.FindLast(x => x.Paciente.ID == obj.ID) != null)
                        {
                            historia = lista.FindLast(x => x.Paciente.ID == obj.ID);
                            listaFiltrada.Add(historia);
                        }

                    }
                    Grilla.DataSource = listaFiltrada;
                    Grilla.DataBind();
                    Session.Add("listaAdmin", listaFiltrada);

                }
            }
            

          
            //Session.Add("hcFiltrada", listaFiltrada);
        }
        protected void Click_Buscar(object sender, EventArgs e)
        {
            HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
            List<HistoriaClinica> hcBusqueda = hcDB.buscar(txtBusqueda.Text);

            Grilla.DataSource = hcBusqueda;
            Grilla.DataBind();
            if (hcBusqueda.Count != 0)
            {
                resultados.Visible = false;
            }
            else
            {
                resultados.Visible = true;
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

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
            List<HistoriaClinica> hcBusqueda = hcDB.buscar(txtBusqueda.Text);

            if(((Usuario)Session["Usuario"]).TipoUsuario.Nombre == "Médico")
            {
                List<HistoriaClinica> listaFiltradaMedico = (List<HistoriaClinica>)Session["listaMedico"];
                HistoriaClinica historia = new HistoriaClinica();
                List<HistoriaClinica> listaFinal = new List<HistoriaClinica>();

                   
                foreach (var item in listaFiltradaMedico)
                {
                    int id = item.ID;
                    historia = hcBusqueda.Find(x => x.ID == item.ID);
                    if (historia != null)
                    {
                        listaFinal.Add(historia);
                    }
                    
                }

                Grilla.DataSource = listaFinal;
                Grilla.DataBind();
                
                if(listaFinal.Count != 0)
                {

                    resultados.Visible = false;
                }
                else
                {
 
                    resultados.Visible = true;
                }
            }
            else
            {
                List<HistoriaClinica> listaFiltrada = (List<HistoriaClinica>)Session["listaAdmin"];
                HistoriaClinica historia = new HistoriaClinica();
                List<HistoriaClinica> listaFinal = new List<HistoriaClinica>();
                foreach (var item in listaFiltrada)
                {
                    historia = hcBusqueda.Find(x => x.ID == item.ID);
                    if (historia != null)
                    {
                        listaFinal.Add(historia);
                    }
                }

                Grilla.DataSource = listaFinal;
                Grilla.DataBind();
                if (listaFinal.Count != 0)
                {
                    resultados.Visible = false;
                }
                else
                {
                    resultados.Visible = true;
                }
            }

               
          
            
        }
    }
}