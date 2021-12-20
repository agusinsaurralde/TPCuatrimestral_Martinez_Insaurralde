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
    public partial class PRUEBA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RangeValidator.MaximumValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
                RangeValidator.MinimumValue = DateTime.Now.Date.AddYears(-100).ToString("yyyy-MM-dd");

                EspecialidadDB espDB = new EspecialidadDB();
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

                MultiView.ActiveViewIndex = 0;
                lblDatos.Font.Bold = true;
                lblDatos.ForeColor = System.Drawing.Color.RoyalBlue;
                lblEspecialidades.ForeColor = System.Drawing.Color.Gray;
                lblUsuario.ForeColor = System.Drawing.Color.Gray;

            }


        }

        //botones 
        protected void btn0a1_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            MultiView.ActiveViewIndex = 1;
            lblDatos.Font.Bold = false;
            lblDatos.ForeColor = System.Drawing.Color.Gray;
            lblEspecialidades.Font.Bold = true;
            lblEspecialidades.ForeColor = System.Drawing.Color.RoyalBlue;

        }
        protected void btn1a2_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            if (Grilla.Rows.Count != 0)
            {
                errorEspecialidad.Visible = false;
                MultiView.ActiveViewIndex = 2;
                lblEspecialidades.Font.Bold = false;
                lblEspecialidades.ForeColor = System.Drawing.Color.Gray;
                lblUsuario.Font.Bold = true;
                lblUsuario.ForeColor = System.Drawing.Color.RoyalBlue;
            }
            else
            {
                errorEspecialidad.Visible = true;
            }

        }
        protected void btn1a0_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 0;
            lblEspecialidades.Font.Bold = false;
            lblEspecialidades.ForeColor = System.Drawing.Color.Gray;
            lblDatos.Font.Bold = true;
            lblDatos.ForeColor = System.Drawing.Color.RoyalBlue;

        }
        protected void btn2a1_Click(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 1;
            lblUsuario.Font.Bold = false;
            lblUsuario.ForeColor = System.Drawing.Color.Gray;
            lblEspecialidades.Font.Bold = true;
            lblEspecialidades.ForeColor = System.Drawing.Color.RoyalBlue;
        }

        //validaciones
        protected void CustomValidatorDNI_ServerValidate(object source, ServerValidateEventArgs args)
        {
            MedicoDB medicoDB = new MedicoDB();
            List<Medico> lista = medicoDB.listarMedico();
            if (lista.Find(x => x.DNI == args.Value && x.Estado == true) != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        protected void CustomValidatorMatricula_ServerValidate(object source, ServerValidateEventArgs args)
        {
            MedicoDB medicoDB = new MedicoDB();
            List<Medico> lista = medicoDB.listarMedico();
            if (lista.Find(x => x.Matricula == args.Value && x.Estado == true) != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        protected void CustomValidatorEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            MedicoDB medicoDB = new MedicoDB();
            List<Medico> lista = medicoDB.listarMedico();
            if (lista.Find(x => x.Email.ToUpper() == args.Value.ToUpper() && x.Estado == true) != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        protected void CustomValidatorEspecialidad_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (Grilla.Rows.Count == 0)
            {
                if (ddlistEspecialidad.SelectedIndex == 0)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
        }
        protected void CustomValidatorDia_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Grilla.Rows.Count == 0)
            {
                if (ddlistDias.SelectedIndex == 0)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
        }
        protected void CustomValidatorEntrada_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Grilla.Rows.Count == 0)
            {
                if (ddlistEntrada.SelectedIndex == 0)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
        }
        protected void CustomValidator1Usuario_ServerValidate(object source, ServerValidateEventArgs args)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            List<Usuario> lista = usuarioDB.listar();
            if (lista.Find(x => x.NombreUsuario.ToUpper() == args.Value.ToUpper() && x.Estado == true) != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        protected void ddlistEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlistEspecialidad.SelectedIndex == 0)
            {
                ddlistDias.Enabled = false;

                if (ddlistEntrada.Enabled)
                    ddlistEntrada.Enabled = false;

                if (btnAgregarDia.Enabled)
                    btnAgregarDia.Enabled = false;
            }
            else
            {
                ddlistDias.Enabled = true;
                if (!btnAgregarDia.Enabled)
                    btnAgregarDia.Enabled = true;
            }
        }
        protected void ddlistDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlistDias.SelectedIndex == 0)
            {
                ddlistEntrada.Enabled = false;
                if (btnAgregarDia.Enabled)
                    btnAgregarDia.Enabled = false;
            }
            else
            {
                if (!btnAgregarDia.Enabled)
                    btnAgregarDia.Enabled = true;
                ddlistEntrada.Enabled = true;

                if (ddlistEntrada.Items.Count != 0)
                    ddlistEntrada.Items.Clear();

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
            if (ddlistDias.SelectedIndex != 0)
            {
                System.TimeSpan horaSumar = new System.TimeSpan(0, 3, 0, 0);
                DateTime horaSalida = Convert.ToDateTime(ddlistEntrada.SelectedItem.ToString()) + horaSumar;
                txtHoraSalida.Text = horaSalida.ToShortTimeString();
                btnAgregarDia.Enabled = true;
            }
            else
            {
                if (btnAgregarDia.Enabled)
                    btnAgregarDia.Enabled = false;
            }

        }
        protected void Click_AgregarDia(object sender, EventArgs e)
        {
            errorEspecialidad.Visible = false;
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
            if ((List<MedicoEspecialidades>)Session["especialidadesAgregadas"] != null)
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
                if (ddlistDias.Items[x].Text == diaAgregado.NombreDia)
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
            if ((List<DiasHabilesMedico>)Session["diasAgregados"] != null)
            {
                List<DiasHabilesMedico> lista = (List<DiasHabilesMedico>)Session["diasAgregados"];
                Grilla.DataSource = lista;
                Grilla.DataBind();
            }
        }


        protected void Aceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
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