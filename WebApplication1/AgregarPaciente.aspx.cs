﻿using System;
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
    public partial class Formulario_web112 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CoberturaDB cobDB = new CoberturaDB();
            try
            {
                if (!IsPostBack)
                {
                    List<Cobertura> cobertura = cobDB.lista();
                    ddlistCobertura.DataSource = cobertura;
                    ddlistCobertura.DataTextField = "Nombre";
                    ddlistCobertura.DataValueField = "ID";
                    ddlistCobertura.DataBind();
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
            Paciente NuevoPaciente = new Paciente();
            PacienteDB cargar = new PacienteDB();
            string agregado = "Paciente";
            string error = "paciente";

            try
            {
                NuevoPaciente.DNI = txtDNI.Text;
                NuevoPaciente.Apellido = txtApellido.Text;
                NuevoPaciente.Nombre = txtNombre.Text;
                NuevoPaciente.Cobertura = new Cobertura();
                NuevoPaciente.Cobertura.Id = int.Parse(ddlistCobertura.SelectedItem.Value);
                NuevoPaciente.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                NuevoPaciente.Telefono = txtTelefono.Text;
                NuevoPaciente.Email = txtEmail.Text;
                NuevoPaciente.Dirección = txtDireccion.Text;
                NuevoPaciente.Estado = true;
                cargar.agregar(NuevoPaciente);

                Response.Redirect("AgregarCorrecto.aspx?agregado=" + agregado, false);
            }
            catch (Exception ex)
            {
                NuevoPaciente = null;
                revisaSiAgrego(NuevoPaciente);
                //Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
            }

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx");
        }

        protected void revisaSiAgrego(Paciente paciente)
        {

            try
            {
                if (paciente != null)
                {
                    lblTituloAlertModal.Text = "Agregado!";
                    lblPacienteDNI.Text = paciente.Nombre.ToString() + " " + paciente.Apellido.ToString();
                    lblPacienteConfirmDNI.Text = "Fue agregado exitosamente :D!";
                    btnRevisaSiAgrega_Modal.Show();
                }
                else
                {
                    lblTituloAlertModal.Text = "Error.";
                    lblTituloNombrePaciente.Text = "";
                    lblPacienteDNI.Text = "Error algo salio mal! :o .";
                    lblPacienteConfirmDNI.Text = "No pudo agregarse el paciente...";
                    btnRevisaSiAgrega_Modal.Show();
                }
            }
            catch (Exception)
            {
                lblTituloAlertModal.Text = "Error.";
                lblPacienteDNI.Text = "Error en curso";
                lblPacienteConfirmDNI.Text = "Error tipo Exepcion.";
                btnRevisaSiAgrega_Modal.Show();
                //throw ex;
            }

        }

        protected void btnCerrarModalAgregarPaciente_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pacientes.aspx", false);
        }

    }
}