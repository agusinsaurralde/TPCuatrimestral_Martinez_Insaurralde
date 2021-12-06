﻿using System;
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
                datos.setearConsulta("SELECT ID, DNI, CONCAT(Nombre, ' ', Apellido) AS NombreCompleto,  Nombre, Apellido, Matricula, Direccion, FechaNacimiento, Telefono, Email, Estado FROM VW_MEDICO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Matricula = (string)datos.Lector["Matricula"];
                    aux.NombreCompleto = (string)datos.Lector["NombreCompleto"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    //aux.Especialidad = new Especialidad();
                    //aux.Especialidad.Id = (int)datos.Lector["IDEspecialidad"];
                    //aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dirección = (string)datos.Lector["Direccion"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    //aux.Turno = new TurnoTrabajo();
                    //aux.Turno.ID = (int)datos.Lector["IDTurnoTrabajo"];
                    //aux.Turno.NombreTurno = (string)datos.Lector["Turno"];
                    //aux.HorarioEntrada = (DateTime)datos.Lector["HoraEntrada"];
                    //aux.HorarioSalida = (DateTime)datos.Lector["HoraSalida"];
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
       /* public List<Medico> listarEspecialidadesMedico(int id)
        {
            List<Medico> lista = new List<Medico>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT IDEspecialidad, E.Nombre as Especialidad, IDMedico, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, IDTurnoTrabajo, T.Turno, HorarioEntrada, HorarioSalida FROM EspecialidadXMedico AS EXM INNER JOIN TurnoTrabajo AS T ON T.ID = EXM.IDTurnoTrabajo INNER JOIN Especialidad AS E ON E.ID = EXM.IDEspecialidad WHERE IDMedico = " + id + "");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.ID = (int)datos.Lector["IDMedico"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = (int)datos.Lector["IDEspecialidad"];
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    aux.Turno = new TurnoTrabajo();
                    aux.Turno.ID = (int)datos.Lector["IDTurnoTrabajo"];
                    aux.Turno.NombreTurno = (string)datos.Lector["Turno"];
                    aux.Lunes = (bool)datos.Lector["Lunes"];
                    aux.Martes = (bool)datos.Lector["Martes"];
                    aux.Miercoles = (bool)datos.Lector["Miercoles"];
                    aux.Jueves = (bool)datos.Lector["Jueves"];
                    aux.Viernes = (bool)datos.Lector["Viernes"];
                    aux.Sabado = (bool)datos.Lector["Sabado"];
                    aux.HorarioEntrada = (DateTime)datos.Lector["HorarioEntrada"];
                    aux.HorarioSalida = (DateTime)datos.Lector["HorarioSalida"];

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
        }*/
        public void agregar(Medico MedicoNuevo)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("EXEC SP_AGREGARMEDICO @DNI, @Matricula, @Apellido, @Nombre, @Telefono, @Email, @Direccion, @FechaNacimiento");
                datos.setearParametro("@DNI", MedicoNuevo.DNI);
                datos.setearParametro("@Matricula", MedicoNuevo.Matricula);
                datos.setearParametro("@Apellido", MedicoNuevo.Apellido);
                datos.setearParametro("@Nombre", MedicoNuevo.Nombre);
                datos.setearParametro("@Telefono", MedicoNuevo.Telefono);
                datos.setearParametro("@Email", MedicoNuevo.Email);
                datos.setearParametro("@Direccion", MedicoNuevo.Dirección);
                datos.setearParametro("@FechaNacimiento", MedicoNuevo.FechaNacimiento);
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
                datos.setearConsulta("EXEC SP_MODIFICARMEDICO @ID, @DNI, @Matricula, @Apellido, @Nombre, @Telefono, @Email, @Direccion, @FechaNacimiento");
                datos.setearParametro("@ID", ModMedico.ID);
                datos.setearParametro("@DNI", ModMedico.DNI);
                datos.setearParametro("@Matricula", ModMedico.Matricula);
                datos.setearParametro("@Apellido", ModMedico.Apellido);
                datos.setearParametro("@Nombre", ModMedico.Nombre);
                datos.setearParametro("@Telefono", ModMedico.Telefono);
                datos.setearParametro("@Email", ModMedico.Email);
                datos.setearParametro("@Direccion", ModMedico.Dirección);
                datos.setearParametro("@FechaNacimiento", ModMedico.FechaNacimiento);
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

        public Medico buscarporID(int ID)
        {
            MedicoDB medicoDB = new MedicoDB();
            List<Medico> listamedicos = medicoDB.listarMedico();
            Medico medico = listamedicos.Find(x => x.ID == ID);
            return medico;
        }

        public List<Medico> buscar(string valorBuscado)
        {
            List<Medico> lista = new List<Medico>();
            ConexionDB datos = new ConexionDB();
            try
            {

                
                datos.setearConsulta("SELECT ID, DNI, CONCAT(Nombre, ' ', Apellido) AS NombreCompleto, Nombre, Apellido, Matricula, Direccion, FechaNacimiento, Telefono, Email, Estado FROM VW_MEDICO WHERE Apellido LIKE '" + valorBuscado + "%' OR Nombre LIKE '" + valorBuscado + "%' OR  CONCAT(Nombre, ' ', Apellido) LIKE '" + valorBuscado + "%' OR M.Matricula LIKE '" + valorBuscado + "%'"); 
                datos.ejecutarLectura();      

                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Matricula = (string)datos.Lector["Matricula"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.NombreCompleto = (string)datos.Lector["NombreCompleto"];  
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dirección = (string)datos.Lector["Direccion"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
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

        public List<MedicoEspecialidades> listarEspecialidadesMedico()
        {
            List<MedicoEspecialidades> lista = new List<MedicoEspecialidades>();
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("SELECT EXM.IDEspecialidad as IDEspecialidad, ESP.Nombre as Especialidad, EXM.IDMedico, E.Apellido, CONCAT(E.Nombre, ' ', E.Apellido) as NombreCompleto, E.Nombre, E.Apellido FROM EspecialidadXMedico AS EXM INNER JOIN Empleado AS E ON E.ID = EXM.IDMedico INNER JOIN Especialidad AS ESP ON ESP.ID = EXM.IDEspecialidad");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    MedicoEspecialidades aux = new MedicoEspecialidades();
                    aux.ID = (int)datos.Lector["IDMedico"];
                    aux.especialidad = new Especialidad();
                    aux.especialidad.Id = (int)datos.Lector["IDEspecialidad"];
                    aux.especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    aux.NombreCompleto = (string)datos.Lector["NombreCompleto"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];   

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

        public List<DiasHabilesMedico> listarDiasHabiles()
        {
            List<DiasHabilesMedico> lista = new List<DiasHabilesMedico>();
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("SELECT DH.ID, DH.IDMedico, CONCAT(E.Apellido, ' ', E.Nombre) AS NombreCompleto, E.Apellido, E.Nombre, DH.IDEspecialidad, ESP.Nombre, DH.NombreDia, DH.HorarioEntrada, DH.HorarioSalida FROM DiasHabilesMedico as DH INNER JOIN Empleado AS E ON E.ID = DH.IDMedico INNER JOIN Especialidad AS ESP ON ESP.ID = DH.IDEspecialidad");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DiasHabilesMedico aux = new DiasHabilesMedico();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = (int)datos.Lector["IDEspecialidad"];
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    aux.Medico = new Medico();
                    aux.Medico.ID = (int)datos.Lector["IDMedico"];
                    aux.Medico.NombreCompleto = (string)datos.Lector["NombreCompleto"];
                    aux.Medico.Nombre = (string)datos.Lector["Nombre"];
                    aux.Medico.Apellido = (string)datos.Lector["Apellido"];
                    aux.NombreDia = (string)datos.Lector["NombreDia"];
                    aux.HorarioEntrada = (DateTime)datos.Lector["HorarioSalida"];

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

        /*public List<Medico> listarMedicoXEspecialidad(int IDEspecialidad)
        {
            List<Medico> lista = new List<Medico>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT M.ID, M.DNI, M.Matricula, M.Apellido, M.Nombre, E.ID AS IDEspecialidad, E.Nombre AS Especialidad, M.Telefono, M.Email, M.Direccion, M.FechaNacimiento, M.IDTurnoTrabajo, T.Turno, M.HoraEntrada, M.HoraSalida, M.Estado FROM Medico AS M INNER JOIN TurnoTrabajo AS T ON T.ID = M.IDTurnoTrabajo INNER JOIN EspecialidadXMedico AS EXM ON EXM.IDMedico = M.ID INNER JOIN Especialidad AS E ON E.ID = EXM.IDEspecialidad WHERE EXM.IDMedico=M.ID AND EXM.IDEspecialidad =" + IDEspecialidad + "");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Matricula = (string)datos.Lector["Matricula"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
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
        }*/

    }
}
