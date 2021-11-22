using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace DBClinica
{
    class MedicoDB
    {
        public List<Medico> listarMedico()
        {
            List<Medico> lista = new List<Medico>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT M.ID, M.DNI, M.Matricula, M.Apellido, M.Nombre, M.Telefono, M.Email, M.Direccion, M.FechaNacimiento, M.IDTurnoTrabajo, T.Turno, M.HoraEntrada, M.HoraSalida, M.Estado FROM Medico AS M INNER JOIN TurnoTrabajo AS T ON T.ID = M.IDTurnoTrabajo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Matricula = (string)datos.Lector["Matricula"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
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
                datos.setearConsulta("INSERT Medico(DNI, Matricula, Apellido, Nombre, Telefono, Email, Direccion, FechaNacimiento, IDTurnoTrabajo, HoraEntrada, HoraSalida, Estado) VALUES(@DNI, @Matricula, @Apellido, @Nombre, @Telefono, @Email, @Direccion, @FechaNacimiento, @IDTurnoTrabajo, @HoraEntrada, @HoraSalida, @Estado)");
                datos.setearParametro("@DNI", MedicoNuevo.DNI);
                datos.setearParametro("@Matricula", MedicoNuevo.Matricula);
                datos.setearParametro("@Apellido", MedicoNuevo.Apellido);
                datos.setearParametro("@Nombre", MedicoNuevo.Nombre);
                datos.setearParametro("@Telefono", MedicoNuevo.Telefono);
                datos.setearParametro("@Email", MedicoNuevo.Email);
                datos.setearParametro("@Direccion", MedicoNuevo.Dirección);
                datos.setearParametro("@FechaNacimiento", MedicoNuevo.FechaNacimiento);
                datos.setearParametro("@IDTurnoTrabajo", MedicoNuevo.Turno);
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
                datos.setearConsulta("UPDATE MEDICO SET DNI = @DNI, Matricula = @Matricula, Apellido = @Apellido, Nombre = @Nombre, Telefono = @Telefono, Email = @Email, Direccion = @Direccion, FechaNacimiento = @FechaNacimiento, IDTurnoTrabajo = @IDTurnoTrabajo,  HoraEntrada =  @HoraEntrada, HoraSalida = @HoraSalida, Estado = @Estado WHERE ID =" + ModMedico.ID +"");
                datos.setearParametro("@DNI", ModMedico.DNI);
                datos.setearParametro("@Matricula", ModMedico.Matricula);
                datos.setearParametro("@Apellido", ModMedico.Apellido);
                datos.setearParametro("@Nombre", ModMedico.Nombre);
                datos.setearParametro("@Telefono", ModMedico.Telefono);
                datos.setearParametro("@Email", ModMedico.Email);
                datos.setearParametro("@Direccion", ModMedico.Dirección);
                datos.setearParametro("@FechaNacimiento", ModMedico.FechaNacimiento);
                datos.setearParametro("@IDTurnoTrabajo", ModMedico.Turno);
                datos.setearParametro("@HoraEntrada", ModMedico.HorarioEntrada);
                datos.setearParametro("@HoraSalida", ModMedico.HorarioSalida);
                datos.setearParametro("@Estado", ModMedico.Estado);
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
                datos.setearConsulta("Update Medico SET Estado = 0 where ID = " + ElimMedico.ID + "");
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
