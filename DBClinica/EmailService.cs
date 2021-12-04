using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Dominio;

namespace DBClinica
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("programationiii@gmail.com", "programacion3");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(Turno turnoAgregado)
        {
            PacienteDB datosPaciente = new PacienteDB();
            Paciente paciente = datosPaciente.buscarporID(turnoAgregado.Paciente.ID);

            email = new MailMessage();
            email.From = new MailAddress("noresponder@clinicademar.com");
            email.To.Add(paciente.Email);
            email.Subject = "Confirmación de turno - Clínica Demar";
            email.IsBodyHtml = true;
            string esp = turnoAgregado.Especialidad.Nombre;
            string medico = turnoAgregado.Medico.Nombre;
            email.Body = "<h3>COMPROBANTE DE RESERVA DE TURNO</h3> <br>" +
                "Nro de Turno: " + turnoAgregado.Numero + "<br>" +
                "Paciente: " + turnoAgregado.Paciente.Nombre + " " + turnoAgregado.Paciente.Apellido + "<br>" +
                "Especialidad: " + turnoAgregado.Especialidad.Nombre + "<br>" +
                "Profesional: " + turnoAgregado.Medico.NombreCompleto + "<br>" +
                "Fecha: " + turnoAgregado.Dia.ToString("dd/mm/yyyy") + "<br>" +
                "Horario: " + turnoAgregado.HorarioInicio.ToString("HH:mm") + "<br>" +
                "Observaciones: " + turnoAgregado.Observaciones + "<br><br> En caso de cancelar, avisar con anticipación al teléfono 4856-5673.";
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

