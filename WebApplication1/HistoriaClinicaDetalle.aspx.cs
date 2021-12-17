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
    public partial class Formulario_web16 : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario userLog = (Usuario)Session["Usuario"];

            if (userLog == null)
            {
                Session.Add("Error", "Debes iniciar sesión");
                Response.Redirect("ErrorIngreso.aspx", false);
            }
            else
            {
                //carga datos empleado logueado
                EmpleadoDB empleadoLogDB = new EmpleadoDB();
                Empleado empleadoLog = new Empleado();
                empleadoLog = empleadoLogDB.empleadoLogueado((int)userLog.IDUsuario);
                //lista de descripciones
                List<HistoriaClinica> listaPorPaciente = (List<HistoriaClinica>)Session["Historia"];


                lblNombrePaciente.Text = listaPorPaciente[0].Paciente.NombreCompleto;


                //filtra historias según el médico logueado
                if (userLog.TipoUsuario.Nombre == "Médico")
                {
                    List<HistoriaClinica> listaFiltradaMedico = listaPorPaciente.FindAll(x => x.Medico.ID == empleadoLog.ID);
                    Grilla.DataSource = listaFiltradaMedico;
                    Grilla.DataBind();
                }
                else
                {
                    Grilla.DataSource = listaPorPaciente;
                    Grilla.DataBind();
                }
               
            }
            
        }
        protected void Click_Editar(object sender, EventArgs e)
        {
            Response.Redirect("EditarHistoriaClinicaMedico.aspx", false);
        }

        protected void Grilla_RowEditing(object sender, GridViewEditEventArgs e)
        {
            HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
            Session.Add("modificar", hcDB.buscarporID((int)Grilla.DataKeys[e.NewEditIndex].Values[0]));
            Response.Redirect("EditarHistoriaClinicaMedico.aspx");
        }
    }
} 