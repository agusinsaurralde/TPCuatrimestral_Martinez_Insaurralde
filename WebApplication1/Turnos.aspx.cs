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
                Grilla.DataSource = turnoBD.listarTurno();
                Grilla.DataBind();
            }

        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {

            Session.Add("agregarHistoriaClinica", turnoBD.buscarporNumero((int)Grilla.DataKeys[e.NewEditIndex].Values[0]));
            Response.Redirect("AgregarHistoriaClinica.aspx");

        }

        protected void Click_Agregar(object sender, EventArgs e)
        {

            Response.Redirect("AsignarTurno.aspx");

        }

        protected void Click_Buscar(object sender, EventArgs e)
        {
            List<Turno> turnosBusqueda = turnoBD.buscar(ddlistCriterio.SelectedItem.Text, txtBusqueda.Text);
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
                btnEditarRestringido_Modal.Show();
            }
        }

        protected void AsignarTurno_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarTurno.aspx");
        }

        protected void Grilla_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session.Add("id", (int)Grilla.DataKeys[e.RowIndex].Values[0]);
            cancelarTurno_Modal.Show();
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