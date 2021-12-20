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
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        TurnoDB turnoBD = new TurnoDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario userLog = (Usuario)Session["Usuario"];

                 if (Session["Usuario"] == null)
                 {
                     Session.Add("Error", "Debes iniciar sesión");
                     Response.Redirect("ErrorIngreso.aspx", false);
                 }
                 else if (userLog.UsuarioMedico(userLog))
                 {
                     
                     Grilla.Columns[2].Visible = false;
                     Grilla.Columns[6].Visible = false;
                     Grilla.Columns[9].Visible = false;
                     Grilla.Columns[10].Visible = false;
                     btnAsignarTurno.Visible = false;
                     EmpleadoDB empleadoLogDB = new EmpleadoDB();
                     Empleado empleadoLog = empleadoLogDB.empleadoLogueado((int)userLog.IDUsuario);

                     List<Turno> lista = turnoBD.listarTurno();
                     List<Turno> listaFiltrada = lista.FindAll(x => x.Medico.ID == empleadoLog.ID);
                     Grilla.DataSource = listaFiltrada;
                     Grilla.DataBind();

                    
                 }
                 else if (userLog.UsuarioRecepcionista(userLog))
                 {

                      Grilla.Columns[8].Visible = false;
                      EmpleadoDB empleadoLogDB = new EmpleadoDB();
                      Empleado empleadoLog = empleadoLogDB.empleadoLogueado((int)userLog.IDUsuario);
                      Grilla.DataSource = turnoBD.listarTurno();
                      Grilla.DataBind();

                 }
                 else
                 {
                    
                     Grilla.DataSource = turnoBD.listarTurno();
                     Grilla.DataBind();
                    
                 }
            }

        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            Session.Add("agregarHistoriaClinica", turnoBD.buscarporNumero((int)Grilla.DataKeys[e.NewEditIndex].Values[0]));
            if(((Turno)Session["agregarHistoriaClinica"]).Estado.Estado != "Cerrado" && ((Turno)Session["agregarHistoriaClinica"]).Estado.Estado != "Cancelado")
            {
                Response.Redirect("AgregarHistoriaClinica.aspx");
            }
            else
            {
                Response.Redirect("ErrorPermisosAcceso.aspx");
                Session.Add("Error", "No se puede modificar un turno cerrado.");
            }

        }

        protected void Click_Agregar(object sender, EventArgs e)
        {

            Response.Redirect("AsignarTurno.aspx");

        }

        protected void Click_Buscar(object sender, EventArgs e)
        {
            List<Turno> turnosBusqueda = turnoBD.buscar(ddlistCriterio.SelectedItem.Text, txtBusqueda.Text);
            if (((Usuario)Session["Usuario"]).TipoUsuario.Nombre == "Médico")
            {
                EmpleadoDB empleadoLogDB = new EmpleadoDB();
                Empleado empleadoLog = new Empleado();
                empleadoLog = empleadoLogDB.empleadoLogueado((int)((Usuario)Session["Usuario"]).IDUsuario);
                List<Turno> busquedaFiltrada = turnosBusqueda.FindAll(x => x.Medico.ID == empleadoLog.ID);
                Grilla.DataSource = busquedaFiltrada;
                Grilla.DataBind();
                if (busquedaFiltrada.Count != 0)
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
                Grilla.DataSource = turnosBusqueda;
                Grilla.DataBind();
                if (turnosBusqueda.Count != 0)
                {
                    resultados.Visible = false;
                }
                else
                {
                    resultados.Visible = true;
                }
            }
  

        }

        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(Grilla.SelectedDataKey.Value);
            Session.Add("editarTurno", turnoBD.buscarporNumero(num));
            if (((Turno)Session["editarTurno"]).Estado.Estado != "Cerrado")
            {
                Response.Redirect("ModificarTurno.aspx");
            }
            else
            {
                lblTituloAlertModal.Text = "Acceso Restringido";
                lblRestringido.Text = "No se puede modificar un turno cerrado.";
                btnRestringido_Modal.Show();
            }
        }

        protected void AsignarTurno_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarTurno.aspx");
        }

        protected void Grilla_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session.Add("id", (int)Grilla.DataKeys[e.RowIndex].Values[0]);
            Turno turno = turnoBD.buscarporNumero((int)Grilla.DataKeys[e.RowIndex].Values[0]);
            if(turno.Estado.Estado != "Cerrado" && turno.Estado.Estado != "Cancelado")
            {
                cancelarTurno_Modal.Show();
            }
            else
            {
                lblTituloAlertModal.Text = "Acceso Restringido";
                lblRestringido.Text = "No se puede cancelar un turno cerrado o cancelado con anterioridad.";
                btnRestringido_Modal.Show();
            }
        }

        protected void btnAceptarCancelar_Click(object sender, EventArgs e)
        {
            TurnoDB turnoDB = new TurnoDB();
            turnoDB.cancelarTurno((int)Session["id"]);
            Grilla.DataSource = turnoBD.listarTurno();
            Grilla.DataBind();
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Turno> turnosBusqueda = turnoBD.buscar(ddlistCriterio.SelectedItem.Text, txtBusqueda.Text);
            if (((Usuario)Session["Usuario"]).TipoUsuario.Nombre == "Médico")
            {
                EmpleadoDB empleadoLogDB = new EmpleadoDB();
                Empleado empleadoLog = new Empleado();
                empleadoLog = empleadoLogDB.empleadoLogueado((int)((Usuario)Session["Usuario"]).IDUsuario);
                List<Turno> busquedaFiltrada = turnosBusqueda.FindAll(x => x.Medico.ID == empleadoLog.ID);
                Grilla.DataSource = busquedaFiltrada;
                Grilla.DataBind();
                if (busquedaFiltrada.Count != 0)
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
                Grilla.DataSource = turnosBusqueda;
                Grilla.DataBind();
                if (turnosBusqueda.Count != 0)
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