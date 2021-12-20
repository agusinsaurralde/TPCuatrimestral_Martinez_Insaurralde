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
             Usuario userLog = (Usuario)Session["Usuario"];

            if (Session["Usuario"] == null)
            {
                Session.Add("Error", "Debes iniciar sesión");
                Response.Redirect("ErrorIngreso.aspx", false);
            }
            else if (userLog.TipoUsuario.Nombre == "Médico")
            {
                Session.Add("Error", "Acceso denegado"); ;
                Response.Redirect("ErrorPermisosAcceso.aspx", false);

            }
           
            CoberturaDB cobDB = new CoberturaDB();
            try
            {
                if (!IsPostBack)
                {
                    RangeValidator.MaximumValue = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    RangeValidator.MinimumValue = DateTime.Now.Date.AddYears(-100).ToString("yyyy-MM-dd");

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
            if (!Page.IsValid)
                return;
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
                Response.Redirect("ErrorAgregar.aspx?error=" + error, false);
            }

        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Pacientes.aspx");
            
        }

        protected void CustomValidatorDNI_ServerValidate(object source, ServerValidateEventArgs args)
        {
            PacienteDB pacienteDB = new PacienteDB();
            List<Paciente> lista = pacienteDB.listarPaciente();
            if (lista.Find(x => x.DNI == args.Value && x.Estado == true) != null)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}
