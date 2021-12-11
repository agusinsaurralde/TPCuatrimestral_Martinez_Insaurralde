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
    public partial class Formulario_web21 : System.Web.UI.Page
    {
        public List<MedicoEspecialidades> listaEsp { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            MedicoDB medicoDB = new MedicoDB(); 
            listaEsp = medicoDB.listarEspecialidadesDeUnMedico(((Medico)Session["modificar"]).ID);

            try
            {
                if (!IsPostBack)
                {

                    Medico medico = new Medico();
                    medico = (Medico)Session["modificar"];
                    Usuario usuario = (Usuario)Session["modificarUsuario"];
                    txtDNI.Text = medico.DNI;
                    txtMatricula.Text = medico.Matricula;
                    txtApellido.Text = medico.Apellido;
                    txtNombre.Text = medico.Nombre;
                    txtFechaNac.Text = medico.FechaNacimiento.ToString("dd-mm-yyyy");
                    txtTelefono.Text = medico.Telefono;
                    txtEmail.Text = medico.Email;
                    txtDireccion.Text = medico.Dirección;
                    txtNombreUsuario.Text = usuario.NombreUsuario;
                    txtContraseña.Text = usuario.Contraseña;

                    EspecialidadDB especialidadDB = new EspecialidadDB();
                    List<Especialidad> esp = especialidadDB.lista();
                    ddlistEspecialidad.DataSource = esp;
                    ddlistEspecialidad.DataValueField = "ID";
                    ddlistEspecialidad.DataTextField = "Nombre";
                    ddlistEspecialidad.DataBind();
                    ddlistEspecialidad.Items.Insert(0, new ListItem("Seleccionar", "0"));


                    List<MedicoEspecialidades> espAgregadas = new List<MedicoEspecialidades>();
                    List<DiasHabilesMedico> diasAgregados = new List<DiasHabilesMedico>();
                    Session.Add("especialidadesAgregadas", espAgregadas);
                    Session.Add("diasAgregadros", diasAgregados);

                    cargarHorarios();

                }

                if (Request.QueryString["id"] != null)
                {
                    btnEliminarEspecialidad_Modal.Show();
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                //throw ex;
            }


        }

        protected void Click_Aceptar(object sender, EventArgs e)
        {
            Medico modMedico = new Medico();
            Usuario modUsuario = new Usuario();
            MedicoDB cargar = new MedicoDB();
            UsuarioDB cargarUsuario = new UsuarioDB();
            string modificado = "Médico";
            string error = "médico";

            try
            {
                modMedico.ID = ((Medico)Session["modificar"]).ID;
                modMedico.DNI = txtDNI.Text;
                modMedico.Matricula = txtMatricula.Text;
                modMedico.Apellido = txtApellido.Text;
                modMedico.Nombre = txtNombre.Text;
                modMedico.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                modMedico.Telefono = txtTelefono.Text;
                modMedico.Email = txtEmail.Text;
                modMedico.Dirección = txtDireccion.Text;

                cargar.modificar(modMedico);

  
                modUsuario.IDUsuario = ((Medico)Session["modificar"]).ID;
                modUsuario.NombreUsuario = txtNombreUsuario.Text;
                modUsuario.Contraseña = txtContraseña.Text;
                modUsuario.TipoUsuario = new TipoUsuario();
                modUsuario.TipoUsuario.Id = 1;
                modUsuario.TipoUsuario.Nombre = "Médico";
                modUsuario.Estado = true;

                cargarUsuario.ModificarUsuario(modUsuario);

                //Response.Redirect("ModificarCorrecto.aspx?modificado=" + modificado, false);
            }
            catch (Exception)
            {
                Response.Redirect("ErrorModificar.aspx?error=" + error, false);
              
            }

        }

      
        protected void cargarDiasEditar(int id)
        {
            MedicoDB medicoDB = new MedicoDB();
            List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);
            if (listaDias.FindAll(x => x.ID != id) != null)
            {
                List<DiasHabilesMedico> listaDiasFiltrados = listaDias.FindAll(x => x.ID != id);



                foreach (var item in listaDiasFiltrados)
                {
                    int c = ddlistDia.Items.Count;
                    for (int x = 0; x < 6; x++)
                    {
                        string nombre = ddlistDia.Items[x].Text;
                        string filt = item.NombreDia;
                        if (ddlistDia.Items[x].Text == item.NombreDia)
                        {
                            ddlistDia.Items[x].Enabled = false;
                        }
                    }

                }
            }
        }
        protected void cargarDias()
        {
            MedicoDB medicoDB = new MedicoDB();
            List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);
           
             foreach (var item in listaDias)
             {

                 for (int x = 0; x < 7; x++)
                 {
                     if (ddlistDiaAgregar.Items[x].Text == item.NombreDia)
                     {
                        ddlistDiaAgregar.Items[x].Enabled = false;
                     }
                 }

             }
            
        }
        protected void cargarHorarios()
        {
            DateTime horaEntrada = Convert.ToDateTime("8:00");
            DateTime horaMaxEntrada = Convert.ToDateTime("18:00");
            System.TimeSpan horaSumar = new System.TimeSpan(0, 1, 0, 0);

            while (horaEntrada <= horaMaxEntrada)
            {
                ddlistEntrada.Items.Add(horaEntrada.ToShortTimeString());
                ddlistEntradaAgregar.Items.Add(horaEntrada.ToShortTimeString());
                horaEntrada += horaSumar;
            }

        }
        protected void cargarValoresAnteriores(int id)
        {

            MedicoDB medicoDB = new MedicoDB();
            List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);

            DiasHabilesMedico diaSeleccionado = listaDias.Find(x => x.ID == id);
            ddlistDia.Text = diaSeleccionado.NombreDia;
            ddlistEntrada.SelectedValue = diaSeleccionado.HorarioEntrada.ToShortTimeString();
            txtHoraSalida.Text = diaSeleccionado.HorarioSalida.ToShortTimeString();

        }

        //Editar y eliminar días
        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Grilla.SelectedDataKey.Value);
            Session.Add("idEditarDia", id);
            cargarDiasEditar(id); ;
            //cargarHorarios();
            cargarValoresAnteriores(id);
            btnEditar_ModalPopupExtender.Show();
        }
        protected void ddlistEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.TimeSpan horaSumar = new System.TimeSpan(0, 4, 0, 0);
            txtHoraSalida.Text = (Convert.ToDateTime(ddlistEntrada.SelectedValue) + horaSumar).ToShortTimeString();
        }
        protected void btnAceptarEditar_Click(object sender, EventArgs e)
        {
            DiasHabilesMedico modificarDia = new DiasHabilesMedico();

            modificarDia.ID = (int)Session["idEditarDia"];
            modificarDia.IdDia = ddlistDia.SelectedIndex + 1;
            modificarDia.HorarioEntrada = Convert.ToDateTime(ddlistEntrada.SelectedValue);
            modificarDia.HorarioSalida = DateTime.Parse(txtHoraSalida.Text);

            MedicoDB medicoDB = new MedicoDB();
            medicoDB.modificarDias(modificarDia);

            List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);
            Grilla.DataSource = listaDias;
            Grilla.DataBind();
        }
        protected void Grilla_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            btnEliminar_ModalPopupExtender.Show();
            int id = (int)Grilla.DataKeys[e.RowIndex].Values[0];
            Session.Add("idEliminarDia", id);

        }
        protected void btnAceptarEliminar_Click(object sender, EventArgs e)
        {
            MedicoDB medicoDB = new MedicoDB();
            medicoDB.eliminarDias((int)Session["idEliminarDia"]);


        }


        //agregar especialidad
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ddlistEspecialidad.TabIndex = 0;
            ddlistEspecialidad.SelectedIndex = ddlistEspecialidad.TabIndex;
            ddlistEspecialidad.Enabled = true;
            ddlistDiaAgregar.TabIndex = 0;
            ddlistDiaAgregar.SelectedIndex = ddlistDiaAgregar.TabIndex;
            ddlistEntradaAgregar.TabIndex = 0;
            ddlistEntradaAgregar.SelectedIndex = ddlistEntradaAgregar.TabIndex;
            txtSalidaAgregar.Text = "";

            //quita especialidades que ya tiene el médico
            int cantEsp = ddlistEspecialidad.Items.Count-1;

            foreach (var item in listaEsp)
            {
                for (int i = 0; i <= cantEsp; i++)
                {
                    if (item.especialidad.Nombre == ddlistEspecialidad.Items[i].Text)
                    {
                        ddlistEspecialidad.Items[i].Enabled = false;
                    }
                }
            }

            cargarDias();
            //cargarHorarios();
            ddlistEntradaAgregar.Items.Insert(0, new ListItem("Seleccionar", "0"));
            btnAgregarEspecialidad_Modal.Show();
        }
        protected void ddlistEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDias.Visible = true;
            ddlistDiaAgregar.Visible = true;
            ddlistEspecialidad.Enabled = false;
        }
        protected void ddlistDiaAgregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlistEntradaAgregar.Visible = true;
            txtSalidaAgregar.Visible = true;

        }
        protected void ddlistEntradaAgregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.TimeSpan horaSumar = new System.TimeSpan(0, 4, 0, 0);
            //
            DateTime horaSalida = Convert.ToDateTime(ddlistEntradaAgregar.SelectedItem.ToString()) + horaSumar;
            txtSalidaAgregar.Text = horaSalida.ToShortTimeString();
            btnAgregarDia.Visible = true;
            btnAgregaEspecialidadModal.Visible = true;
        }
        protected void btnAgregarDia_Click(object sender, EventArgs e)
        {

            DiasHabilesMedico diaAgregado = new DiasHabilesMedico();

            diaAgregado.Especialidad = new Especialidad();
            diaAgregado.Especialidad.Id = int.Parse(ddlistEspecialidad.SelectedValue);
            diaAgregado.IdDia = ddlistDiaAgregar.SelectedIndex;
            diaAgregado.NombreDia = ddlistDiaAgregar.SelectedItem.Text;
            diaAgregado.HorarioEntrada = DateTime.Parse(ddlistEntradaAgregar.SelectedItem.Value);
            diaAgregado.HorarioSalida = DateTime.Parse(txtSalidaAgregar.Text);

            ((List<DiasHabilesMedico>)Session["diasAgregadros"]).Add(diaAgregado);

            //saca dias que ya fueron agregados
            for (int x = 0; x < 7; x++)
            {
                if (ddlistDiaAgregar.Items[x].Text == diaAgregado.NombreDia)
                {
                    ddlistDiaAgregar.Items[x].Enabled = false;
                }
            }

            ddlistEntradaAgregar.TabIndex = 0;
            ddlistDiaAgregar.TabIndex = 0;
            ddlistEntradaAgregar.SelectedIndex = ddlistEntrada.TabIndex;
            ddlistDiaAgregar.SelectedIndex = ddlistEspecialidad.TabIndex;

            ddlistEntrada.Visible = false;
            lblDias.Visible = false;
            txtSalidaAgregar.Text = "";
            txtSalidaAgregar.Visible = false;
            btnAgregarDia.Visible = false;
            btnAgregaEspecialidadModal.Visible = true;

        }
        protected void btnAgregarEspecialidadModal_Click(object sender, EventArgs e)
        {
            MedicoEspecialidades espAgregada = new MedicoEspecialidades();

            espAgregada.especialidad = new Especialidad();
            espAgregada.especialidad.Id = int.Parse(ddlistEspecialidad.SelectedValue);
            espAgregada.especialidad.Nombre = ddlistEspecialidad.SelectedItem.Value;

            ((List<MedicoEspecialidades>)Session["especialidadesAgregadas"]).Add(espAgregada);


            int cantEsp = ddlistEspecialidad.Items.Count;
            for (int i = 0; i < cantEsp; i++)
            {
                if (ddlistEspecialidad.Items[i].Enabled == true && ddlistEspecialidad.Items[i].Text == espAgregada.especialidad.Nombre)
                {
                    ddlistEspecialidad.Items[i].Enabled = false;
                }
            }


            ddlistEspecialidad.TabIndex = 0;
            ddlistEntradaAgregar.TabIndex = 0;
            ddlistDiaAgregar.TabIndex = 0;
            ddlistEntradaAgregar.SelectedIndex = ddlistEntrada.TabIndex;
            ddlistDiaAgregar.SelectedIndex = ddlistDiaAgregar.TabIndex;
            ddlistEspecialidad.SelectedIndex = ddlistEspecialidad.TabIndex;

            ddlistEntradaAgregar.Visible = false;
            lblDias.Visible = false;
            ddlistDiaAgregar.Visible = false;
            txtSalidaAgregar.Text = "";
            txtSalidaAgregar.Visible = false;
            btnAgregarDia.Visible = false;
            btnAgregaEspecialidadModal.Visible = false;

            ddlistEspecialidad.Enabled = true;

        }
        protected void btnAceptarEspecialidad_Click(object sender, EventArgs e)
        {
            MedicoDB medicoDB = new MedicoDB();
            List<DiasHabilesMedico> listaDiasAgregados = (List<DiasHabilesMedico>)Session["diasAgregadros"];
            List<MedicoEspecialidades> listaEspAgregadas = (List<MedicoEspecialidades>)Session["especialidadesAgregadas"];

            int idMedico = ((Medico)Session["modificar"]).ID;

           int c= listaDiasAgregados.Count;
            int d=listaEspAgregadas.Count;

            foreach (DiasHabilesMedico obj in listaDiasAgregados)
            {
                obj.Medico = new Medico();
                obj.Medico.ID = idMedico;

                medicoDB.agregarDiasHabiles(obj);
            }

            foreach (MedicoEspecialidades obj in listaEspAgregadas)
            {
                obj.ID = idMedico;

                medicoDB.agregarEspecialidades(obj);
            }

            List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);
            Grilla.DataSource = listaDias;
            Grilla.DataBind();
        }

        protected void exitAgregar_Click(object sender, EventArgs e)
        {
            

           
        }

        protected void btnAceptarEliminarEspecialidad_Click(object sender, EventArgs e)
        {
            MedicoDB medicoDB = new MedicoDB();
            MedicoEspecialidades medico = new MedicoEspecialidades();
            medico.especialidad = new Especialidad();
            medico.especialidad.Id = int.Parse(Request.QueryString["id"]);
            medico.ID = ((Medico)Session["modificar"]).ID;
            medicoDB.eliminarEspecialidad(medico);

        }
    }
}
