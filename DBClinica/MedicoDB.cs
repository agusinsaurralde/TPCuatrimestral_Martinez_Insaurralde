using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace DBClinica
{
    public class MedicoDB
    {
        public List<Medico> listarMedico()
        {
            List<Medico> lista = new List<Medico>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT M.ID, M.DNI, M.Matricula, CONCAT(M.Nombre, ' ', M.Apellido) AS NombreCompleto, E.ID AS IDEspecialidad, E.Nombre AS Especialidad, M.Telefono, M.Email, M.Direccion, M.FechaNacimiento, M.IDTurnoTrabajo, T.Turno, M.HoraEntrada, M.HoraSalida, M.Estado FROM Medico AS M INNER JOIN TurnoTrabajo AS T ON T.ID = M.IDTurnoTrabajo INNER JOIN EspecialidadXMedico AS EXM ON EXM.IDMedico = M.ID INNER JOIN Especialidad AS E ON E.ID = EXM.IDEspecialidad");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();
                    //CONCAT(M.Nombre, ' ', M.Apellido) AS NombreCompleto
                    aux.ID = (int)datos.Lector["ID"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Matricula = (string)datos.Lector["Matricula"];
                    aux.NombreCompleto = (string)datos.Lector["NombreCompleto"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = (int)datos.Lector["IDEspecialidad"];
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dirección = (string)datos.Lector["Direccion"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.Turno = new TurnoTrabajo();
                    aux.Turno.ID = (int)datos.Lector["IDTurnoTrabajo"];
                    aux.Turno.NombreTurno = (string)datos.Lector["Turno"];
                    aux.HorarioEntrada = (DateTime)datos.Lector["HoraEntrada"];
                    aux.HorarioSalida = (DateTime)datos.Lector["HoraSalida"];
                    aux.Estado = (bool)datos.Lector["Estado"];

                    lista.Add(aux);
                }
                return lista;
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

        public void agregar(Medico MedicoNuevo)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("EXEC SP_AGREGARMEDICO @DNI, @Matricula, @Apellido, @Nombre, @IDEspecialidad, @Telefono, @Email, @Direccion, @FechaNacimiento, @IDTurnoTrabajo, @HoraEntrada, @HoraSalida, @Estado");
                datos.setearParametro("@DNI", MedicoNuevo.DNI);
                datos.setearParametro("@Matricula", MedicoNuevo.Matricula);
                datos.setearParametro("@Apellido", MedicoNuevo.Apellido);
                datos.setearParametro("@Nombre", MedicoNuevo.Nombre);
                datos.setearParametro("@IDEspecialidad", MedicoNuevo.Especialidad.Id);
                datos.setearParametro("@Telefono", MedicoNuevo.Telefono);
                datos.setearParametro("@Email", MedicoNuevo.Email);
                datos.setearParametro("@Direccion", MedicoNuevo.Dirección);
                datos.setearParametro("@FechaNacimiento", MedicoNuevo.FechaNacimiento);
                datos.setearParametro("@IDTurnoTrabajo", MedicoNuevo.Turno.ID);
                datos.setearParametro("@HoraEntrada", MedicoNuevo.HorarioEntrada);
                datos.setearParametro("@HoraSalida", MedicoNuevo.HorarioSalida);
                datos.setearParametro("@Estado", MedicoNuevo.Estado);
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

        public void modificar(Medico ModMedico)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("EXEC SP_MODIFICARMEDICO @ID, @DNI, @Matricula, @Apellido, @Nombre, @IDEspecialidad, @Telefono, @Email, @Direccion, @FechaNacimiento, @IDTurnoTrabajo, @HoraEntrada, @HoraSalida");
                datos.setearParametro("@ID", ModMedico.ID);
                datos.setearParametro("@DNI", ModMedico.DNI);
                datos.setearParametro("@Matricula", ModMedico.Matricula);
                datos.setearParametro("@Apellido", ModMedico.Apellido);
                datos.setearParametro("@Nombre", ModMedico.Nombre);
                datos.setearParametro("@IDEspecialidad", ModMedico.Especialidad.Id);
                datos.setearParametro("@Telefono", ModMedico.Telefono);
                datos.setearParametro("@Email", ModMedico.Email);
                datos.setearParametro("@Direccion", ModMedico.Dirección);
                datos.setearParametro("@FechaNacimiento", ModMedico.FechaNacimiento);
                datos.setearParametro("@IDTurnoTrabajo", ModMedico.Turno.ID);
                datos.setearParametro("@HoraEntrada", ModMedico.HorarioEntrada);
                datos.setearParametro("@HoraSalida", ModMedico.HorarioSalida);
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

        public void eliminar(Medico ElimMedico)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("EXEC SP_ELIMINARMEDICO @IDMedico");
                datos.setearParametro("@IDMedico", ElimMedico.ID);
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

        public Medico buscarporID(int IDBuscado)
        {
            ConexionDB datos = new ConexionDB();
            try
            {

                    datos.setearConsulta("SELECT M.ID, M.DNI, M.Matricula, M.Apellido, M.Nombre, E.ID AS IDEspecialidad, E.Nombre AS Especialidad, M.Telefono, M.Email, M.Direccion, M.FechaNacimiento, M.IDTurnoTrabajo, T.Turno, M.HoraEntrada, M.HoraSalida, M.Estado FROM Medico AS M INNER JOIN TurnoTrabajo AS T ON T.ID = M.IDTurnoTrabajo INNER JOIN EspecialidadXMedico AS EXM ON EXM.IDMedico = M.ID INNER JOIN Especialidad AS E ON E.ID = EXM.IDEspecialidad WHERE M.ID = " + IDBuscado + "");

                    datos.ejecutarLectura();
                    datos.Lector.Read();
                    Medico aux = new Medico();
                    aux.ID = (int)datos.Lector["ID"];
                    int id = aux.ID;
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Matricula = (string)datos.Lector["Matricula"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = (int)datos.Lector["IDEspecialidad"];
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dirección = (string)datos.Lector["Direccion"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.Turno = new TurnoTrabajo();
                    aux.Turno.ID = (int)datos.Lector["IDTurnoTrabajo"];
                    aux.Turno.NombreTurno = (string)datos.Lector["Turno"];
                    aux.HorarioEntrada = (DateTime)datos.Lector["HoraEntrada"];
                    aux.HorarioSalida = (DateTime)datos.Lector["HoraSalida"];
                    aux.Estado = (bool)datos.Lector["Estado"];

               
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

        public List<Medico> buscar(string criterio, Medico valorBuscado)
        {
            List<Medico> lista = new List<Medico>();
            ConexionDB datos = new ConexionDB();
            try
            {

                try
                {
                    if (criterio == "DNI")
                    {
                        datos.setearConsulta("SELECT M.ID, M.DNI, M.Matricula, M.Apellido, M.Nombre, E.ID AS IDEspecialidad, E.Nombre AS Especialidad, M.Telefono, M.Email, M.Direccion, M.FechaNacimiento, M.IDTurnoTrabajo, T.Turno, M.HoraEntrada, M.HoraSalida, M.Estado FROM Medico AS M INNER JOIN TurnoTrabajo AS T ON T.ID = M.IDTurnoTrabajo INNER JOIN EspecialidadXMedico AS EXM ON EXM.IDMedico = M.ID INNER JOIN Especialidad AS E ON E.ID = EXM.IDEspecialidad WHERE M.ID = " + valorBuscado.DNI + "");
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }

                datos.ejecutarLectura();      

                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Matricula = (string)datos.Lector["Matricula"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = (int)datos.Lector["IDEspecialidad"];
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dirección = (string)datos.Lector["Direccion"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.Turno = new TurnoTrabajo();
                    aux.Turno.ID = (int)datos.Lector["IDTurnoTrabajo"];
                    aux.Turno.NombreTurno = (string)datos.Lector["Turno"];
                    aux.HorarioEntrada = (DateTime)datos.Lector["HoraEntrada"];
                    aux.HorarioSalida = (DateTime)datos.Lector["HoraSalida"];
                    aux.Estado = (bool)datos.Lector["Estado"];

                    lista.Add(aux);
                }

                return lista;
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
