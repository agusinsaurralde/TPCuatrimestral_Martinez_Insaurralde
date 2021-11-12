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
                datos.setearConsulta("SELECT * FROM VW_TURNO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.Numero = (int)datos.Lector["Número"];
                    aux.Paciente = new Paciente();
                    aux.Paciente.Apellido = (string)datos.Lector["Apellido"];
                    aux.Paciente.Nombre = (string)datos.Lector["Nombre"];
                    aux.Especialidad = (string)datos.Lector["Especialidad"];
                    aux.Medico = new Medico();
                    aux.Medico.Apellido = (string)datos.Lector["Apellido Médico"];
                    aux.Medico.Nombre = (string)datos.Lector["Nombre Médico"];
                    aux.HorarioInicio = (DateTime)datos.Lector["Horario Inicial"];
                    aux.HorarioFin = (DateTime)datos.Lector["Horario Final"];
                    aux.Dia = (DateTime)datos.Lector["Día"];
                    aux.Observaciones = (string)datos.Lector["Observaciones"];
                    aux.AdministrativoResponsable = new Empleado();
                    aux.AdministrativoResponsable.Apellido = (string)datos.Lector["Apellido Recepcionista"];
                    aux.AdministrativoResponsable.Nombre = (string)datos.Lector["Nombre Recepcionista"];
                    aux.Estado = new EstadoTurno();
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
                datos.setearConsulta("INSERT Turno(IDPaciente, IDEspXMedico, Dia, Observaciones, IDRecepcionista, IDEstado, HoraInicio, HoraFin)VALUES(@IDPaciente, @IDEspXMedico, @Dia, @Observaciones,@IDRecepcionista, @IDEstado, @HoraInicio, @HoraFin)");
               
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
