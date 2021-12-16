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
            EspecialidadDB espDB = new EspecialidadDB();
            if (!IsPostBack)
            {
                List<Especialidad> lista = espDB.lista();
                Session["listaEsp"] = lista;
                ddlistEspecialidad.DataSource = lista;
                ddlistEspecialidad.DataTextField = "Nombre";
                ddlistEspecialidad.DataValueField = "ID";
                ddlistEspecialidad.DataBind();
                ddlistEspecialidad.Items.Insert(0, new ListItem("Seleccionar", "0"));

                //listas para guardar las especialidades y días agregados
                List<MedicoEspecialidades> especialidadesAgregadas = new List<MedicoEspecialidades>();
                Session.Add("especialidadesAgregadas", especialidadesAgregadas);
                List<DiasHabilesMedico> diasAgregados = new List<DiasHabilesMedico>();
                Session.Add("diasAgregados", diasAgregados);
            }
            


        }

        protected void ddlistEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlistEspecialidad.SelectedIndex == 0)
            { 
                ddlistDias.Enabled = false;
            }
            else
            {
                ddlistDias.Enabled = true;
            }
        }
        protected void ddlistDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlistDias.SelectedIndex == 0)
            {
                ddlistEntrada.Enabled = false;
            }
            else
            {
                ddlistEntrada.Enabled = true;
                DateTime hora = DateTime.Parse("8:00");
                DateTime horaMax = DateTime.Parse("19:00");
                System.TimeSpan horaSumar = new System.TimeSpan(0, 1, 0, 0);


                while (hora <= horaMax)
                {
                    ddlistEntrada.Items.Add(hora.ToShortTimeString());
                    hora += horaSumar;
                }
                ddlistEntrada.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

        }
        protected void ddlistEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlistDias.SelectedIndex != 0)
            {
                System.TimeSpan horaSumar = new System.TimeSpan(0, 3, 0, 0);
                DateTime horaSalida = Convert.ToDateTime(ddlistEntrada.SelectedItem.ToString()) + horaSumar;
                txtHoraSalida.Text = horaSalida.ToShortTimeString();
                btnAgregarDia.Enabled = true;
            }
         
        }
        protected void Click_AgregarDia(object sender, EventArgs e)
        {
            DiasHabilesMedico diaAgregado = new DiasHabilesMedico();

            diaAgregado.Especialidad = new Especialidad();
            diaAgregado.Especialidad.Id = int.Parse(ddlistEspecialidad.SelectedValue);
            diaAgregado.Especialidad.Nombre = ddlistEspecialidad.SelectedItem.Text;
            diaAgregado.IdDia = ddlistDias.SelectedIndex;
            diaAgregado.NombreDia = ddlistDias.SelectedItem.Text;
            diaAgregado.HorarioEntrada = DateTime.Parse(ddlistEntrada.SelectedItem.Value);
            diaAgregado.HorarioSalida = DateTime.Parse(txtHoraSalida.Text);

           
            //lista que guarda dias
            ((List<DiasHabilesMedico>)Session["diasAgregados"]).Add(diaAgregado);

            //lista que guarda especialidades
            if((List<MedicoEspecialidades>)Session["especialidadesAgregadas"] != null)
            {
                List<MedicoEspecialidades> listaEspAgregadas = (List<MedicoEspecialidades>)Session["especialidadesAgregadas"];

                if (listaEspAgregadas.Find(x => x.especialidad.Nombre == diaAgregado.Especialidad.Nombre) == null)
                {
                    MedicoEspecialidades esp = new MedicoEspecialidades();
                    esp.especialidad = new Especialidad();
                    esp.especialidad.Id = diaAgregado.Especialidad.Id;
                    esp.especialidad.Nombre = diaAgregado.Especialidad.Nombre;
                    ((List<MedicoEspecialidades>)Session["especialidadesAgregadas"]).Add(esp);
                }
            }
            else
            {
                MedicoEspecialidades esp = new MedicoEspecialidades();
                esp.ID = diaAgregado.Especialidad.Id;
                esp.Nombre = diaAgregado.Especialidad.Nombre;
                ((List<MedicoEspecialidades>)Session["especialidadesAgregadas"]).Add(esp);
            }

            //saca dias que ya fueron agregados
            for (int x = 0; x < 7; x++)
            {
                if(ddlistDias.Items[x].Text == diaAgregado.NombreDia)
                {
                    ddlistDias.Items[x].Enabled = false;
                }
            }

            ddlistEntrada.TabIndex = 0;
            ddlistDias.TabIndex = 0;
            ddlistEntrada.SelectedIndex = ddlistEntrada.TabIndex;
            ddlistDias.SelectedIndex = ddlistEspecialidad.TabIndex;

            ddlistEntrada.Enabled = false;
            txtHoraSalida.Text = "";
            txtHoraSalida.Enabled = false;
            btnAgregarDia.Enabled = false;

            cargarGrilla();
        }

        protected void cargarGrilla()
        {
            if((List<DiasHabilesMedico>)Session["diasAgregados"] != null)
            {
                List<DiasHabilesMedico> lista = (List<DiasHabilesMedico>)Session["diasAgregados"];
                Grilla.DataSource = lista;
                Grilla.DataBind();
            }   
        }

       
        protected void Click_Aceptar(object sender, EventArgs e)
        {
            Medico NuevoMedico = new Medico();
            Usuario nuevoUsuario = new Usuario();
            MedicoDB cargar = new MedicoDB();
            UsuarioDB cargarUsuario = new UsuarioDB();
            string error = "médico";

            try
            {
                NuevoMedico.DNI = txtDNI.Text;
                NuevoMedico.Matricula = txtMatricula.Text;
                NuevoMedico.Apellido = txtApellido.Text;
                NuevoMedico.Nombre = txtNombre.Text;
                NuevoMedico.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                NuevoMedico.Telefono = txtTelefono.Text;
                NuevoMedico.Email = txtEmail.Text;
                NuevoMedico.Dirección = txtDireccion.Text;
                NuevoMedico.Estado = true;
                cargar.agregar(NuevoMedico);

                List<Medico> medicos = cargar.listarMedico();
                Medico ultMedico = medicos.Find(x => x.DNI == txtDNI.Text);
                nuevoUsuario.IDUsuario = ultMedico.ID;
                nuevoUsuario.NombreUsuario = txtNombreUsuario.Text;
                nuevoUsuario.Contraseña = txtContraseña.Text;
                nuevoUsuario.TipoUsuario = new TipoUsuario();
                nuevoUsuario.TipoUsuario.Id = 1;
                nuevoUsuario.TipoUsuario.Nombre = "Médico";
                nuevoUsuario.Estado = true;

                cargarUsuario.AgregarUsuario(nuevoUsuario);

                List<DiasHabilesMedico> listaDias = (List<DiasHabilesMedico>)Session["diasAgregados"];
                List<MedicoEspecialidades> listaEsp = (List<MedicoEspecialidades>)Session["especialidadesAgregadas"];

                foreach (DiasHabilesMedico obj in listaDias)
                {
                    obj.Medico = new Medico();
                    obj.Medico.ID = ultMedico.ID;

                    cargar.agregarDiasHabiles(obj);
                }

                foreach (MedicoEspecialidades obj in listaEsp)
                {
                    obj.ID = ultMedico.ID;

                    cargar.agregarEspecialidades(obj);
                }

                Response.Redirect("Medicos.aspx");
            }
            catch (Exception ex)
            {
                //Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
                throw ex;
            }

        }

    }

}