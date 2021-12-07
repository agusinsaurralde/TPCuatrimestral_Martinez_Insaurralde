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
    public partial class ModificarEspecialidadesMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<DiasHabilesMedico> listaDias = (List<DiasHabilesMedico>)Session["DiasModificar"];
            Grilla.DataSource = listaDias;
            Grilla.DataBind();

        }

        protected void Grilla_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DiasHabilesMedico dia = ((List<DiasHabilesMedico>)Session["DiasModificar"]).Find(x => x.ID == (int)Grilla.DataKeys[e.NewEditIndex].Values[0]);
            Session.Add("modificarDia", dia);
            Response.Redirect("ModificarDiaMedico.aspx");
        }

        protected void Grilla_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}