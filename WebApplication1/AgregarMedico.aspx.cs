using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Dominio;
using DBClinica;

namespace WebApplication1
{
    public partial class Formulario_web113 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            TurnoTrabajoDB ttdb = new TurnoTrabajoDB();
            try
            {
                if (!IsPostBack)
                {
                    List<TurnoTrabajo> turnot = ttdb.listar();
                    ddlist.DataSource = turnot;
                    ddlist.DataTextField = "NombreTurno";
                    ddlist.DataValueField = "ID";
                    ddlist.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Medico NuevoMedico = new Medico();
            MedicoDB cargar = new MedicoDB();
            try
            {
                NuevoMedico.DNI = txtDNI.Text.ToString();
                NuevoMedico.Matricula = txtMatricula.Text.ToString();
                NuevoMedico.Apellido = txtApellido.Text.ToString();
                NuevoMedico.Nombre = txtNombre.Text.ToString();
                NuevoMedico.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text.ToString());
                NuevoMedico.Telefono = txtTelefono.Text.ToString();
                NuevoMedico.Email = txtEmail.Text.ToString();
                NuevoMedico.Dirección = txtDireccion.Text.ToString();

                NuevoMedico.Turno = new TurnoTrabajo();
                NuevoMedico.Turno.ID = int.Parse(ddlist.SelectedItem.Value);
                NuevoMedico.Turno.NombreTurno = ddlist.SelectedItem.Text;
                
                NuevoMedico.HorarioEntrada = DateTime.Parse(txtHorarioEntrada.Text.ToString());
                NuevoMedico.HorarioSalida = DateTime.Parse(txtHorarioSalida.Text.ToString());
                NuevoMedico.Estado = true;
                cargar.agregar(NuevoMedico);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
    }
}