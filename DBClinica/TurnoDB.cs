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
                datos.setearConsulta("SELECT Numero, IDPaciente, CONCAT(NombrePaciente, ' ', ApellidoPaciente) as NombreCompletoPaciente, ApellidoPaciente, NombrePaciente, IDEspecialidad, Especialidad, IDMedico, CONCAT(NombreMedico,' ', ApellidoMedico) as NombreCompletoMedico, ApellidoMedico, NombreMedico, HoraInicio, HoraFin, Dia, Observaciones, IDRecepcionista, CONCAT(NombreRecepcionista,' ', ApellidoRecepcionista) as NombreCompletoRecepcionista, ApellidoRecepcionista, NombreRecepcionista, IDEstado, Estado FROM VW_TURNOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Paciente = new Paciente();
                    aux.Paciente.ID = (int)datos.Lector["IDPaciente"];
                    aux.Paciente.Apellido = (string)datos.Lector["ApellidoPaciente"];
                    aux.Paciente.Nombre = (string)datos.Lector["NombrePaciente"];
                    aux.Paciente.NombreCompleto = (string)datos.Lector["NombreCompletoPaciente"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = (int)datos.Lector["IDEspecialidad"];
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    aux.Medico = new Medico();
                    aux.Medico.ID = (int)datos.Lector["IDMedico"];
                    aux.Medico.Apellido = (string)datos.Lector["ApellidoMedico"];
                    aux.Medico.Nombre = (string)datos.Lector["NombreMedico"];
                    aux.Medico.NombreCompleto = (string)datos.Lector["NombreCompletoMedico"];
                    aux.HorarioInicio = (DateTime)datos.Lector["HoraInicio"];
                    aux.HorarioFin = (DateTime)datos.Lector["HoraFin"];
                    aux.Dia = (DateTime)datos.Lector["Dia"];
                    aux.Observaciones = (string)datos.Lector["Observaciones"];
                    aux.AdministrativoResponsable = new Empleado();
                    aux.AdministrativoResponsable.ID = (int)datos.Lector["IDRecepcionista"];
                    aux.AdministrativoResponsable.Apellido = (string)datos.Lector["ApellidoRecepcionista"];
                    aux.AdministrativoResponsable.Nombre = (string)datos.Lector["NombreRecepcionista"];
                    aux.AdministrativoResponsable.NombreCompleto = (string)datos.Lector["NombreCompletoRecepcionista"];
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
                datos.setearParametro("@IDEspecialidad", turnoNuevo.Especialidad.Id);
                datos.setearParametro("@IDMedico", turnoNuevo.Medico.ID);
                datos.setearParametro("@Dia", turnoNuevo.Dia);
                datos.setearParametro("@HoraInicio", turnoNuevo.HorarioInicio);
                datos.setearParametro("@HoraFin", turnoNuevo.HorarioInicio);
                datos.setearParametro("@Observaciones", turnoNuevo.Observaciones);
                datos.setearParametro("@IDRecepcionista", turnoNuevo.AdministrativoResponsable.ID);
                datos.setearParametro("@Estado", turnoNuevo.Estado.ID);
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
                datos.setearConsulta("EXEC SP_MODIFICARTURNO @IDPaciente, @IDEspecialidad, @IDMedico, @Dia, @HoraInicio, @HoraFin, @Observaciones, @IDRecepcionista, @IDEstado, @Numero");
                datos.setearParametro("@Numero", turnoNuevo.Numero);
                datos.setearParametro("@IDPaciente", turnoNuevo.Paciente.ID);
                datos.setearParametro("@IDEspecialidad", turnoNuevo.Especialidad.Id);
                datos.setearParametro("@IDMedico", turnoNuevo.Medico.ID);
                datos.setearParametro("@Dia", DateTime.Parse(turnoNuevo.Dia.ToString()));
                datos.setearParametro("@HoraInicio", DateTime.Parse(turnoNuevo.HorarioInicio.ToString())); ;
                datos.setearParametro("@HoraFin", DateTime.Parse(turnoNuevo.HorarioInicio.ToString()));
                datos.setearParametro("@Observaciones", turnoNuevo.Observaciones);
                datos.setearParametro("@IDRecepcionista", turnoNuevo.AdministrativoResponsable.ID);
                datos.setearParametro("@IDEstado", turnoNuevo.Estado.ID);
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
        public Turno buscarTurno(int NumeroTurno) // busca directamente un turno pára modificar
        {  
          ConexionDB datos = new ConexionDB();
           try
           {

               datos.setearConsulta("SELECT Numero, IDPaciente, ApellidoPaciente, NombrePaciente, IDEspecialidad, Especialidad, IDMedico, ApellidoMedico, NombreMedico, HoraInicio, HoraFin, Dia, Observaciones, IDRecepcionista, ApellidoRecepcionista, NombreRecepcionista, IDEstado, Estado FROM VW_TURNOS WHERE NUMERO =" + NumeroTurno +"");
               // consulta que traiga el turno con todos sus datos no sus ID
               datos.ejecutarLectura();
               datos.Lector.Read();
               Turno aux = new Turno();
                aux.Numero = (int)datos.Lector["Numero"];
                aux.Paciente = new Paciente();
                aux.Paciente.ID = (int)datos.Lector["IDPaciente"];
                aux.Paciente.Apellido = (string)datos.Lector["ApellidoPaciente"];
                aux.Paciente.Nombre = (string)datos.Lector["NombrePaciente"];
                aux.Especialidad = new Especialidad();
                aux.Especialidad.Id = (int)datos.Lector["IDEspecialidad"];
                aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                aux.Medico = new Medico();
                aux.Medico.ID = (int)datos.Lector["IDMedico"];
                aux.Medico.Apellido = (string)datos.Lector["ApellidoMedico"];
                aux.Medico.Nombre = (string)datos.Lector["NombreMedico"];
                aux.HorarioInicio = (DateTime)datos.Lector["HoraInicio"];
                aux.HorarioFin = (DateTime)datos.Lector["HoraFin"];
                aux.Dia = (DateTime)datos.Lector["Dia"];
                aux.Observaciones = (string)datos.Lector["Observaciones"];
                aux.AdministrativoResponsable = new Empleado();
                aux.AdministrativoResponsable.ID = (int)datos.Lector["IDRecepcionista"];
                aux.AdministrativoResponsable.Apellido = (string)datos.Lector["ApellidoRecepcionista"];
                aux.AdministrativoResponsable.Nombre = (string)datos.Lector["NombreRecepcionista"];
                aux.Estado = new EstadoTurno();
                aux.Estado.ID = (int)datos.Lector["IDEstado"];
                aux.Estado.Estado = (string)datos.Lector["Estado"];


                return aux;
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
