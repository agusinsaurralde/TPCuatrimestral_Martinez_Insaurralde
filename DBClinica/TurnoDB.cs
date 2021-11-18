using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace DBClinica
{
    public class TurnoDB
    {
        public List<Turno> listarTurno()
        {
            List<Turno> lista = new List<Turno>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT Numero, IDPaciente, ApellidoPaciente, NombrePaciente, IDEspecialidad, Especialidad, IDMedico, ApellidoMedico, NombreMedico, HoraInicio, HoraFin, Dia, Observaciones, IDRecepcionista, ApellidoRecepcionista, NombreRecepcionista, IDEstado, Estado FROM VW_TURNOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.Numero = (int)datos.Lector["Número"];
                    aux.Paciente = new Paciente();
                    aux.Paciente.ID = (int)datos.Lector["ID Paciente"];
                    aux.Paciente.Apellido = (string)datos.Lector["Apellido"];
                    aux.Paciente.Nombre = (string)datos.Lector["Nombre"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = (int)datos.Lector["IDEspecialidad"];
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    aux.Medico = new MedicoDB();
                    aux.Medico.ID = (int)datos.Lector["ID Médico"];
                    aux.Medico.Apellido = (string)datos.Lector["Apellido Médico"];
                    aux.Medico.Nombre = (string)datos.Lector["Nombre Médico"];
                    aux.HorarioInicio = (DateTime)datos.Lector["Horario Inicial"];
                    aux.HorarioFin = (DateTime)datos.Lector["Horario Final"];
                    aux.Dia = (DateTime)datos.Lector["Día"];
                    aux.Observaciones = (string)datos.Lector["Observaciones"];
                    aux.AdministrativoResponsable = new Empleado();
                    aux.AdministrativoResponsable.ID = (int)datos.Lector["ID Recepcionista"];
                    aux.AdministrativoResponsable.Apellido = (string)datos.Lector["Apellido Recepcionista"];
                    aux.AdministrativoResponsable.Nombre = (string)datos.Lector["Nombre Recepcionista"];
                    aux.Estado = new EstadoTurno();
                    aux.Estado.ID = (int)datos.Lector["IDEstado"];
                    aux.Estado.Estado = (string)datos.Lector["Estado"];

                    lista.Add(aux);
                }
                return lista;
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally{
                datos.cerrarConexion();
            }
        }

        public void agregar(Turno turnoNuevo)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("EXEC SP_ASIGNARTURNO @IDPaciente, @IDEspecialidad, @IDMedico, @Dia, @HoraInicio, @HoraFin, @Observaciones, @IDRecepcionista, @Estado");
                datos.setearParametro("@IDPaciente", turnoNuevo.Paciente.ID);
                datos.setearParametro("@IDEspecialidad", turnoNuevo.Especialidad);
                datos.setearParametro("@IDMedico", turnoNuevo.Medico.ID);
                datos.setearParametro("@Dia", turnoNuevo.Dia);
                datos.setearParametro("@HoraInicio", turnoNuevo.HorarioInicio);
                datos.setearParametro("@HoraFin", turnoNuevo.HorarioInicio);
                datos.setearParametro("@Observaciones", turnoNuevo.Observaciones);
                datos.setearParametro("@IDRecepcionista", turnoNuevo.AdministrativoResponsable.ID);
                datos.setearParametro("@IDEstado", turnoNuevo.Estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Turno turnoNuevo)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("EXEC SP_MODIFICARTURNO @IDPaciente, @IDEspecialidad, @IDMedico, @Dia, @HoraInicio, @HoraFin, @Observaciones, @IDRecepcionista, @Estado, @Numero");
                datos.setearParametro("@IDPaciente", turnoNuevo.Paciente.ID);
                datos.setearParametro("@IDEspecialidad", turnoNuevo.Especialidad);
                datos.setearParametro("@IDMedico", turnoNuevo.Medico.ID);
                datos.setearParametro("@Dia", turnoNuevo.Dia);
                datos.setearParametro("@HoraInicio", turnoNuevo.HorarioInicio);
                datos.setearParametro("@HoraFin", turnoNuevo.HorarioInicio);
                datos.setearParametro("@Observaciones", turnoNuevo.Observaciones);
                datos.setearParametro("@IDRecepcionista", turnoNuevo.AdministrativoResponsable.ID);
                datos.setearParametro("@IDEstado", turnoNuevo.Estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
