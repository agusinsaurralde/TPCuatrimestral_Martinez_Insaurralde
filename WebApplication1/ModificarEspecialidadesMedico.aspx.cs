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


            int idMedico = listaDias[0].Medico.ID;
            List<MedicoEspecialidades> especialidades = new List<MedicoEspecialidades>();
            Session.Add("especialidades", especialidades);
            MedicoDB medicoDB = new MedicoDB();

            especialidades = medicoDB.listarEspecialidadesDeUnMedico(idMedico);

            GrillaEspecialidad.DataSource = especialidades;
            GrillaEspecialidad.DataBind();

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

        protected void GrillaEspecialidad_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MedicoEspecialidades especialidad = ((List<MedicoEspecialidades>)Session["especialidades"]).Find(x => x.IDregistro == (int)GrillaEspecialidad.DataKeys[e.RowIndex].Values[0]);
            Session.Add("eliminar", especialidad);
            Response.Redirect("EliminarEspecialidadMedico.aspx");
        }
    }
}