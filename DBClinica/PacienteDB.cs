using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace DBClinica
{
    class PacienteDB
    {
        public List<Paciente> listarPaciente()
        {
            List<Paciente> lista = new List<Paciente>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT P.ID, P.DNI, P.Nombre, P.Apellido, P.FechaNacimiento, P.Cobertura, C.Nombre, P.Telefono, P.Email, P.Direccion, P.Estado FROM Paciente AS P INNER JOIN Cobertura as C on C.ID = P.Cobertura");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["Fecha de Nacimiento"];
                    aux.Cobertura = new Cobertura();
                    aux.Cobertura.Id = (int)datos.Lector["ID Cobertura"];
                    aux.Cobertura.Nombre = (string)datos.Lector["Cobertura"];
                    aux.Telefono = (string)datos.Lector["Teléfono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dirección = (string)datos.Lector["Dirección"];
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

        public void agregar(Paciente PacienteNuevo)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("INSERT Paciente(DNI, Nombre, Apellido, FechaNacimiento, Cobertura, Telefono, Email, Direccion, Estado)VALUES(@DNI, @Nombre, @Apellido, @FechaNacimiento, @IDCobertura, @Telefono, @Email, @Direccion, @Estado)");
                datos.setearParametro("@DNI", PacienteNuevo.DNI);
                datos.setearParametro("@Nombre", PacienteNuevo.Nombre);
                datos.setearParametro("@Apellido", PacienteNuevo.Apellido);
                datos.setearParametro("@FechaNacimiento", PacienteNuevo.FechaNacimiento);
                datos.setearParametro("@IDCobertura", PacienteNuevo.Telefono);
                datos.setearParametro("@Email", PacienteNuevo.Email);
                datos.setearParametro("@Direccion", PacienteNuevo.Dirección);
                datos.setearParametro("@Estado", PacienteNuevo.Estado);
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

        public void modificar(Paciente ModPaciente)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("UPDATE Paciente SET DNI = @DNI, Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, Cobertura = @IDCobertura, Telefono = @Telefono, Email = @Email, Direccion = @Direccion, Estado = @Estado WHERE ID =" + ModPaciente.ID + "");
                datos.setearParametro("@DNI", ModPaciente.DNI);
                datos.setearParametro("@Nombre", ModPaciente.Nombre);
                datos.setearParametro("@Apellido", ModPaciente.Apellido);
                datos.setearParametro("@FechaNacimiento", ModPaciente.FechaNacimiento);
                datos.setearParametro("@IDCobertura", ModPaciente.Telefono);
                datos.setearParametro("@Email", ModPaciente.Email);
                datos.setearParametro("@Direccion", ModPaciente.Dirección);
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

        public void eliminar(Paciente ElimPaciente)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("Update Pacientes SET Estado = 0 where ID = " + ElimPaciente.ID + "");
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

