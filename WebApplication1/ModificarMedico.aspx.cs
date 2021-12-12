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

                    List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);
                    Grilla.DataSource = listaDias;
                    Grilla.DataBind();

                    List<MedicoEspecialidades> espAgregadas = new List<MedicoEspecialidades>();
                    List<DiasHabilesMedico> diasAgregados = new List<DiasHabilesMedico>();

                    Session.Add("diasAgregadros", diasAgregados);

                }
                if(Request.QueryString["accion"] != null)
                {
                    if (Request.QueryString["accion"] == "eliminar")
                    {
                        btnEliminarEspecialidad_Modal.Show();
                    }
                    else if (Request.QueryString["accion"] == "agregarDia")
                    {
                       cargarDiasAgregarAEspExistente();
                       cargarHorarios();
                       ddlistEntradaAgregarDia.Items.Insert(0, new ListItem("Seleccionar", "0"));
                        List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);
                        grillaAgregarDia.DataSource = listaDias.FindAll(x => x.Especialidad.Id == int.Parse(Request.QueryString["id"]));
                        grillaAgregarDia.DataBind();
                        btnModalAgregarDia_Modal.Show();
                    }
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

        protected void cargarDiasAgregarAEspExistente()
        {
            MedicoDB medicoDB = new MedicoDB();
            List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);

            foreach (var item in listaDias)
            {
                for (int x = 0; x < 7; x++)
                {
                    if (ddlistAgregarDiaEspecialidadExistente.Items[x].Text == item.NombreDia)
                    {
                        ddlistAgregarDiaEspecialidadExistente.Items[x].Enabled = false;
                    }
                }

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
                ddlistEntradaAgregarDia.Items.Add(horaEntrada.ToShortTimeString());
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


        //EDITAR DÍAS
        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Grilla.SelectedDataKey.Value);
            Session.Add("idEditarDia", id);
            cargarDiasEditar(id); ;
            cargarHorarios();
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
        //ELIMINAR DÍAS
        protected void btnAceptarEliminar_Click(object sender, EventArgs e)
        {
            MedicoDB medicoDB = new MedicoDB();
            medicoDB.eliminarDias((int)Session["idEliminarDia"]);
            List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);
            Grilla.DataSource = listaDias;
            Grilla.DataBind();
        }


        //AGREGAR ESPECIALIDAD
        //abre modal
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            //limpia el form
            if(ddlistEspecialidad.SelectedIndex != 0)
            {
                ddlistEspecialidad.TabIndex = 0;
                ddlistEspecialidad.SelectedIndex = ddlistEspecialidad.TabIndex;
                ddlistEspecialidad.Enabled = true;
                ddlistDiaAgregar.TabIndex = 0;
                ddlistDiaAgregar.SelectedIndex = ddlistDiaAgregar.TabIndex;
                ddlistEntradaAgregar.TabIndex = 0;
                ddlistEntradaAgregar.SelectedIndex = ddlistEntradaAgregar.TabIndex;
                txtSalidaAgregar.Text = "";
                lblAgregado.Visible = false;
                btnAgregarEspecialidadDB.Enabled = true;
                grillaDiasAgregados.DataSource = null;
                grillaDiasAgregados.DataBind();
                btnAgregarEspecialidad_Modal.Show();
            }
            
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
            cargarHorarios();
            ddlistEntradaAgregar.Items.Insert(0, new ListItem("Seleccionar", "0"));
            btnAgregarEspecialidad_Modal.Show();
        }
        //agrega especialidad a la DB
        protected void btnAgregarEspecialidadDB_Click(object sender, EventArgs e)
        {
            MedicoEspecialidades espAgregada = new MedicoEspecialidades();
            try
            {
                espAgregada.especialidad = new Especialidad();
                espAgregada.especialidad.Id = int.Parse(ddlistEspecialidad.SelectedValue);
                espAgregada.ID = ((Medico)Session["modificar"]).ID;
                MedicoDB medicoDB = new MedicoDB();
                medicoDB.agregarEspecialidades(espAgregada);

                btnCerrar.Enabled = false;
                lblAgregado.Visible = true;
                ddlistDiaAgregar.Enabled = true;
                ddlistEntradaAgregar.Enabled = true;
                ddlistEspecialidad.Enabled = false;
                btnAgregarEspecialidadDB.Enabled = false;
                ddlistDiaAgregar.Enabled = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //agrega horario de entrada y salida
        protected void ddlistEntradaAgregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.TimeSpan horaSumar = new System.TimeSpan(0, 4, 0, 0);
            DateTime horaSalida = Convert.ToDateTime(ddlistEntradaAgregar.SelectedItem.ToString()) + horaSumar;
            txtSalidaAgregar.Text = horaSalida.ToShortTimeString();
            btnAgregarDia.Enabled = true;
           
        }
        //agrega dia a la base de datos
        protected void btnAgregarDia_Click(object sender, EventArgs e)
        {

            DiasHabilesMedico diaAgregado = new DiasHabilesMedico();

            diaAgregado.Especialidad = new Especialidad();
            diaAgregado.Especialidad.Id = int.Parse(ddlistEspecialidad.SelectedValue);
            diaAgregado.IdDia = ddlistDiaAgregar.SelectedIndex;
            diaAgregado.Medico = new Medico();
            diaAgregado.Medico.ID = ((Medico)Session["modificar"]).ID;
            diaAgregado.NombreDia = ddlistDiaAgregar.SelectedItem.Text;
            diaAgregado.HorarioEntrada = DateTime.Parse(ddlistEntradaAgregar.SelectedItem.Value);
            diaAgregado.HorarioSalida = DateTime.Parse(txtSalidaAgregar.Text);


            MedicoDB medicoDB = new MedicoDB();
            medicoDB.agregarDiasHabiles(diaAgregado);

            //saca dias que ya fueron agregados de la ddlist
            for (int x = 0; x < 7; x++)
            {
                if (ddlistDiaAgregar.Items[x].Text == diaAgregado.NombreDia)
                {
                    ddlistDiaAgregar.Items[x].Enabled = false;
                }
            }

            //limpia form para cargar otro día
            ddlistEntradaAgregar.TabIndex = 0;
            ddlistDiaAgregar.TabIndex = 0;
            ddlistEntradaAgregar.SelectedIndex = ddlistEntrada.TabIndex;
            ddlistDiaAgregar.SelectedIndex = ddlistEspecialidad.TabIndex;

            ddlistEntrada.Enabled = false;
            txtSalidaAgregar.Text = "";
            txtSalidaAgregar.Enabled = false;
            btnAgregarDia.Enabled = false;
            //btnAgregarOtraEspecialidad.Enabled = true;

            //carga grilla con los días agregados
            List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);
            Grilla.DataSource = listaDias;
            Grilla.DataBind();

        }
        protected void btnAgregarOtraEspecialidad_Click(object sender, EventArgs e)
        {
            ddlistEspecialidad.TabIndex = 0;
            ddlistEspecialidad.SelectedIndex = ddlistEspecialidad.TabIndex;
            ddlistEspecialidad.Enabled = true;
            ddlistDiaAgregar.TabIndex = 0;
            ddlistDiaAgregar.SelectedIndex = ddlistDiaAgregar.TabIndex;
            ddlistEntradaAgregar.TabIndex = 0;
            ddlistEntradaAgregar.SelectedIndex = ddlistEntradaAgregar.TabIndex;
            txtSalidaAgregar.Text = "";
            lblAgregado.Visible = false;
            btnAgregarEspecialidadDB.Enabled = true;
            grillaDiasAgregados.DataSource = null;
            grillaDiasAgregados.DataBind();
            btnAgregarEspecialidad_Modal.Show();
        }
        //ELIMINAR ESPECIALIDAD
        protected void btnAceptarEliminarEspecialidad_Click(object sender, EventArgs e)
        {
            MedicoDB medicoDB = new MedicoDB();
            MedicoEspecialidades medico = new MedicoEspecialidades();
            medico.especialidad = new Especialidad();
            medico.especialidad.Id = int.Parse(Request.QueryString["id"]);
            medico.ID = ((Medico)Session["modificar"]).ID;
            medicoDB.eliminarEspecialidad(medico);
            Response.Redirect("ModificarMedico.aspx");
        }



        //AGREGA DÍA A ESPECIALIDAD EXISTENTE
        protected void ddlistEntradaAgregarDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.TimeSpan horaSumar = new System.TimeSpan(0, 4, 0, 0);
            DateTime horaSalida = Convert.ToDateTime(ddlistEntradaAgregarDia.SelectedItem.ToString()) + horaSumar;
            txtSalidaAgregarDia.Text = horaSalida.ToShortTimeString();
        }
        protected void btnAceptarAgregarDia_Click(object sender, EventArgs e)
        {
            DiasHabilesMedico dia = new DiasHabilesMedico();
            dia.IdDia = ddlistAgregarDiaEspecialidadExistente.SelectedIndex;
            dia.Medico = new Medico();
            dia.Medico.ID = ((Medico)Session["modificar"]).ID;
            dia.Especialidad = new Especialidad();
            dia.Especialidad.Id = int.Parse(Request.QueryString["id"]);
            dia.HorarioEntrada = DateTime.Parse(ddlistEntradaAgregar.SelectedItem.Value);
            dia.HorarioSalida = DateTime.Parse(txtSalidaAgregarDia.Text);

            MedicoDB medicoDB = new MedicoDB();
            medicoDB.agregarDiasHabiles(dia);
            ddlistAgregarDiaEspecialidadExistente.TabIndex = 0;
            ddlistAgregarDiaEspecialidadExistente.SelectedIndex = ddlistAgregarDiaEspecialidadExistente.TabIndex;
            ddlistEntradaAgregarDia.TabIndex = 0;
            ddlistEntradaAgregarDia.SelectedIndex = ddlistEntradaAgregarDia.TabIndex;
            cargarDiasAgregarAEspExistente();
            cargarHorarios();
            txtSalidaAgregarDia.Text = "";
            ddlistEntradaAgregar.Items.Insert(0, new ListItem("Seleccionar", "0"));
            List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);
            grillaAgregarDia.DataSource = listaDias.FindAll(x => x.Especialidad.Id == int.Parse(Request.QueryString["id"]));
            grillaAgregarDia.DataBind();

            Grilla.DataSource = listaDias;
            Grilla.DataBind();

        }

    }
}
