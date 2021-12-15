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

                    //lista para modal de agregar especialidad
                    List<MedicoEspecialidades> espAgregadas = new List<MedicoEspecialidades>();
                    List<DiasHabilesMedico> diasAgregados = new List<DiasHabilesMedico>();
                    Session.Add("especialidadesAgregadas", espAgregadas);
                    Session.Add("diasAgregados", diasAgregados);
                   
                }
                if(Request.QueryString["accion"] != null)
                {
                    if (Request.QueryString["accion"] == "eliminar")
                    {
                        btnEliminarEspecialidad_Modal.Show();
                    }
                    else if (Request.QueryString["accion"] == "agregarDia")
                    {
                        if (!IsPostBack)
                        {
                            cargarHorarios(ddlistEntradaAgregarDia);
                            ddlistEntradaAgregarDia.Items.Insert(0, new ListItem("Seleccionar", "0"));
                        }
                       cargarDias(ddlistAgregarDiaEspecialidadExistente);
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
            DiasHabilesMedico diaSeleccionado = listaDias.Find(x => x.ID == (int)Session["idEditarDia"]);
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
                        if (ddlistDia.Items[x].Text == diaSeleccionado.NombreDia && ddlistDia.Items[x].Enabled == false)
                        {
                            ddlistDia.Items[x].Enabled = true;
                        }
                    }

                }
            }
        }
        protected void cargarDias(DropDownList ddlist)
        {
            MedicoDB medicoDB = new MedicoDB();
            List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);
           
             foreach (var item in listaDias)
             {

                 for (int x = 0; x < 7; x++)
                 {
                     if (ddlist.Items[x].Text == item.NombreDia)
                     {
                        ddlist.Items[x].Enabled = false;
                     }
                     
                 }

             }
        }
        protected void cargarHorarios(DropDownList ddlist)
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
        protected void cargarGrillaModal(GridView grilla)
        {

            if ((List<DiasHabilesMedico>)Session["diasAgregados"] != null)
            {

                List<DiasHabilesMedico> lista = (List<DiasHabilesMedico>)Session["diasAgregados"];
                grilla.DataSource = lista;
                grilla.DataBind();
            }
        }
        protected void cargarGrilla()
        {
            MedicoDB medicoDB = new MedicoDB();
            List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);
            Grilla.DataSource = listaDias;
            Grilla.DataBind();
        }


        //EDITAR DÍAS
        protected void Grilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cant = ddlistDia.Items.Count;
            
            int id = Convert.ToInt32(Grilla.SelectedDataKey.Value);
            Session.Add("idEditarDia", id);
            cargarDiasEditar(id); ;
            cargarHorarios(ddlistEntrada);
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

            cargarGrilla();

        }
        //ELIMINAR DÍAS
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
            List<DiasHabilesMedico> listaDias = medicoDB.listarDiasHabilesDeUnMedico(((Medico)Session["modificar"]).ID);
            Grilla.DataSource = listaDias;
            Grilla.DataBind();
        }



        //AGREGAR ESPECIALIDAD
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

            cargarDias(ddlistDiaAgregar);
            cargarHorarios(ddlistEntradaAgregar);
            ddlistEntradaAgregar.Items.Insert(0, new ListItem("Seleccionar", "0"));
            btnAgregarEspecialidad_Modal.Show();
        }
        protected void ddlistEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlistEspecialidad.SelectedIndex == 0)
            {
                ddlistDiaAgregar.Enabled = false;
            }
            else
            {
                ddlistDiaAgregar.Enabled = true;
            }
        }
        protected void ddlistDiaAgregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlistDiaAgregar.SelectedIndex == 0)
            {
                ddlistEntradaAgregar.Enabled = false;
            }
            else
            {
                ddlistEntradaAgregar.Enabled = true;
                cargarHorarios(ddlistEntradaAgregar);
            }
        }
        protected void ddlistEntradaAgregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlistDiaAgregar.SelectedIndex != 0)
            {
                System.TimeSpan horaSumar = new System.TimeSpan(0, 4, 0, 0);
                DateTime horaSalida = Convert.ToDateTime(ddlistEntradaAgregar.SelectedItem.ToString()) + horaSumar;
                txtSalidaAgregar.Text = horaSalida.ToShortTimeString();
                btnAgregarDia.Enabled = true;
            }

        }
        protected void btnAgregarDia_Click(object sender, EventArgs e)
        {
            DiasHabilesMedico diaAgregado = new DiasHabilesMedico();

            diaAgregado.Especialidad = new Especialidad();
            diaAgregado.Especialidad.Id = int.Parse(ddlistEspecialidad.SelectedValue);
            diaAgregado.Especialidad.Nombre = ddlistEspecialidad.SelectedItem.Text;
            diaAgregado.IdDia = ddlistDiaAgregar.SelectedIndex;
            diaAgregado.NombreDia = ddlistDiaAgregar.SelectedItem.Text;
            diaAgregado.HorarioEntrada = DateTime.Parse(ddlistEntradaAgregar.SelectedItem.Value);
            diaAgregado.HorarioSalida = DateTime.Parse(txtSalidaAgregar.Text);


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
                if (ddlistDiaAgregar.Items[x].Text == diaAgregado.NombreDia)
                {
                    ddlistDiaAgregar.Items[x].Enabled = false;
                }
            }

            
            ddlistEntradaAgregar.TabIndex = 0;
            ddlistDiaAgregar.TabIndex = 0;
            ddlistEntradaAgregar.SelectedIndex = ddlistEntrada.TabIndex;
            ddlistDiaAgregar.SelectedIndex = ddlistEspecialidad.TabIndex;

            ddlistEntradaAgregar.Enabled = false;
            txtSalidaAgregar.Text = "";
            txtSalidaAgregar.Enabled = false;
            btnAgregarDia.Enabled = false;

            cargarGrillaModal(grillaDiasAgregados);
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ((List<DiasHabilesMedico>)Session["diasAgregados"]).Clear();
            ((List<MedicoEspecialidades>)Session["especialidadesAgregadas"]).Clear();
        }
        protected void btnAceptarAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                MedicoDB cargar = new MedicoDB();
                int idMedico = ((Medico)Session["modificar"]).ID;
                List<DiasHabilesMedico> listaDias = (List<DiasHabilesMedico>)Session["diasAgregados"];
                List<MedicoEspecialidades> listaEsp = (List<MedicoEspecialidades>)Session["especialidadesAgregadas"];

                foreach (DiasHabilesMedico obj in listaDias)
                {
                    obj.Medico = new Medico();
                    obj.Medico.ID = idMedico;
                    cargar.agregarDiasHabiles(obj);
                }

                foreach (MedicoEspecialidades obj in listaEsp)
                {
                    obj.ID = idMedico;
                    cargar.agregarEspecialidades(obj);
                }

                Response.Redirect("ModificarMedico.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ((List<DiasHabilesMedico>)Session["diasAgregados"]).Clear();
            ((List<MedicoEspecialidades>)Session["especialidadesAgregadas"]).Clear();
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
        protected void btnCancelarEliminarEsp_Click(object sender, EventArgs e)
        {
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
            dia.NombreDia = ddlistAgregarDiaEspecialidadExistente.SelectedItem.Value;
            dia.Medico = new Medico();
            dia.Medico.ID = ((Medico)Session["modificar"]).ID;
            dia.Especialidad = new Especialidad();
            dia.Especialidad.Id = int.Parse(Request.QueryString["id"]);
            dia.HorarioEntrada = DateTime.Parse(ddlistEntradaAgregar.SelectedItem.Value);
            dia.HorarioSalida = DateTime.Parse(txtSalidaAgregarDia.Text);

            MedicoDB medicoDB = new MedicoDB();
            medicoDB.agregarDiasHabiles(dia);
            ((List<DiasHabilesMedico>)Session["diasAgregados"]).Add(dia);
            ddlistAgregarDiaEspecialidadExistente.TabIndex = 0;
            ddlistAgregarDiaEspecialidadExistente.SelectedIndex = ddlistAgregarDiaEspecialidadExistente.TabIndex;
            ddlistEntradaAgregarDia.TabIndex = 0;
            ddlistEntradaAgregarDia.SelectedIndex = ddlistEntradaAgregarDia.TabIndex;
            cargarDias(ddlistAgregarDiaEspecialidadExistente);
            cargarHorarios(ddlistEntradaAgregarDia);
            txtSalidaAgregarDia.Text = "";
            ddlistEntradaAgregar.Items.Insert(0, new ListItem("Seleccionar", "0"));


            cargarGrillaModal(grillaAgregarDia);
            cargarGrilla();

        }
        protected void btnCancelarDia_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificarMedico.aspx");
        }

    }
}
