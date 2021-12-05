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
    public partial class EspecialidadesMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Medico> listaEsp = (List<Medico>)Session["EspMedico"];

            foreach(Medico medico in listaEsp)
            {
                txtEspecialidad.Text = medico.Especialidad.Nombre;
                txtTurno.Text = medico.Turno.NombreTurno;
                txtEntrada.Text = medico.HorarioEntrada.ToString("HH:mm");
                txtSalida.Text = medico.HorarioSalida.ToString("HH:mm");
            }
        }
    }
}