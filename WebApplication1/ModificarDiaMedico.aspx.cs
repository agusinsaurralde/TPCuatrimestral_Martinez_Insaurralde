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
    public partial class ModificarDiaMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime hora = DateTime.Parse("8:00");
                DateTime horaMax = DateTime.Parse("19:00");
                System.TimeSpan horaSumar = new System.TimeSpan(0, 1, 0, 0);


                while (hora < horaMax)
                {
                    ddlistEntrada.Items.Add(hora.ToShortTimeString());
                    hora += horaSumar;
                }
                ddlistEntrada.Items.Insert(0, new ListItem("Seleccionar", "0"));


                lblEspecialidad.Text = ((DiasHabilesMedico)Session["modificarDia"]).Especialidad.Nombre;
                ddlistDias.Text = ((DiasHabilesMedico)Session["modificarDia"]).NombreDia;
                ddlistEntrada.SelectedValue = (((DiasHabilesMedico)Session["modificarDia"]).HorarioEntrada).ToShortTimeString();
                txtHoraSalida.Text = (((DiasHabilesMedico)Session["modificarDia"]).HorarioSalida).ToShortTimeString();
            }
            
        }

        protected void btnModificarDia_Click(object sender, EventArgs e)
        {
            try
            {
                string modificado = "Día";
                string error = "día";

                MedicoDB medicoDB = new MedicoDB();
                DiasHabilesMedico dia = new DiasHabilesMedico();

                dia.ID = ((DiasHabilesMedico)Session["modificarDia"]).ID;
                dia.IdDia = ddlistDias.SelectedIndex;
                dia.NombreDia = ddlistDias.SelectedItem.Text; ;
                dia.HorarioEntrada = DateTime.Parse(ddlistEntrada.SelectedItem.Value);
                dia.HorarioSalida = DateTime.Parse(txtHoraSalida.Text);

                medicoDB.modificarDias(dia);
       
                Response.Redirect("ModificarCorrecto.aspx?modificado=" + modificado, false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        protected void ddlistEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.TimeSpan horaSumar = new System.TimeSpan(0, 4, 0, 0);
            DateTime horaSalida = Convert.ToDateTime(ddlistEntrada.SelectedItem.ToString()) + horaSumar;
            txtHoraSalida.Text = horaSalida.ToShortTimeString();
        }
    }
}