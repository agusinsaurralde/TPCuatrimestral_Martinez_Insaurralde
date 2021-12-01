using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace DBClinica
{
   public class PacienteDB
   {
        public List<Paciente> listarPaciente()
        {
            List<Paciente> lista = new List<Paciente>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT P.ID, P.DNI, P.Nombre, P.Apellido, P.FechaNacimiento, P.Cobertura as IDCobertura, C.Nombre as Cobertura, P.Telefono, P.Email, P.Direccion, P.Estado FROM Paciente AS P INNER JOIN Cobertura as C on C.ID = P.Cobertura");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.Cobertura = new Cobertura();
                    aux.Cobertura.Id = (int)datos.Lector["IDCobertura"];
                    aux.Cobertura.Nombre = (string)datos.Lector["Cobertura"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dirección = (string)datos.Lector["Direccion"];
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
                datos.setearConsulta("INSERT Paciente(DNI, Apellido, Nombre, FechaNacimiento, Cobertura, Telefono, Email, Direccion, Estado)VALUES(@DNI, @Nombre, @Apellido, @FechaNacimiento, @IDCobertura, @Telefono, @Email, @Direccion, @Estado)");
                datos.setearParametro("@DNI", PacienteNuevo.DNI);
                datos.setearParametro("@Apellido", PacienteNuevo.Apellido);
                datos.setearParametro("@Nombre", PacienteNuevo.Nombre);
                datos.setearParametro("@FechaNacimiento", PacienteNuevo.FechaNacimiento);
                datos.setearParametro("@IDCobertura", PacienteNuevo.Cobertura.Id);
                datos.setearParametro("@Telefono", PacienteNuevo.Telefono);
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
                datos.setearConsulta("UPDATE Paciente SET DNI = @DNI, Apellido = @Apellido, Nombre = @Nombre, FechaNacimiento = @FechaNacimiento, Cobertura = @IDCobertura, Telefono = @Telefono, Email = @Email, Direccion = @Direccion WHERE ID =" + ModPaciente.ID + "");
                datos.setearParametro("@DNI", ModPaciente.DNI);
                datos.setearParametro("@Apellido", ModPaciente.Apellido);
                datos.setearParametro("@Nombre", ModPaciente.Nombre);
                datos.setearParametro("@FechaNacimiento", ModPaciente.FechaNacimiento);
                datos.setearParametro("@IDCobertura", ModPaciente.Cobertura.Id);
                datos.setearParametro("@Telefono", ModPaciente.Telefono);
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
                datos.setearConsulta("Update Paciente SET Estado = 0 where ID = " + ElimPaciente.ID + "");
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

        public Paciente buscarObjeto(string criterio, Paciente valor)
        {
            ConexionDB datos = new ConexionDB();
            try
            {   
                if(criterio == "DNI")
                {
                    datos.setearConsulta("SELECT P.ID, P.DNI, P.Nombre, P.Apellido, P.FechaNacimiento, P.Cobertura as IDCobertura, C.Nombre as Cobertura, P.Telefono, P.Email, P.Direccion, P.Estado FROM Paciente AS P INNER JOIN Cobertura as C on C.ID = P.Cobertura WHERE P.DNI = " + valor.DNI + "");
                }
                if(criterio == "ID")
                {
                    datos.setearConsulta("SELECT P.ID, P.DNI, P.Nombre, P.Apellido, P.FechaNacimiento, P.Cobertura as IDCobertura, C.Nombre as Cobertura, P.Telefono, P.Email, P.Direccion, P.Estado FROM Paciente AS P INNER JOIN Cobertura as C on C.ID = P.Cobertura WHERE P.ID = " + valor.ID + "");
                }

                datos.ejecutarLectura();
                datos.Lector.Read();

                valor.ID = (int)datos.Lector["ID"];
                valor.DNI = (string)datos.Lector["DNI"];
                valor.Nombre = (string)datos.Lector["Nombre"];
                valor.Apellido = (string)datos.Lector["Apellido"];
                valor.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                valor.Cobertura = new Cobertura();
                valor.Cobertura.Id = (int)datos.Lector["IDCobertura"];
                valor.Cobertura.Nombre = (string)datos.Lector["Cobertura"];
                valor.Telefono = (string)datos.Lector["Telefono"];
                valor.Email = (string)datos.Lector["Email"];
                valor.Dirección = (string)datos.Lector["Direccion"];
                valor.Estado = (bool)datos.Lector["Estado"];

                return valor;
            }
            catch (Exception)
            {
                datos.cerrarConexion();
                return valor = null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Paciente> buscar(string criterio, Paciente valorBuscado)
        {
            List<Paciente> lista = new List<Paciente>();
            ConexionDB datos = new ConexionDB();
            try
            {

                if (criterio == "DNI")
                {
                    datos.setearConsulta("SELECT P.ID, P.DNI, P.Nombre, P.Apellido, P.FechaNacimiento, P.Cobertura as IDCobertura, C.Nombre as Cobertura, P.Telefono, P.Email, P.Direccion, P.Estado FROM Paciente AS P INNER JOIN Cobertura as C on C.ID = P.Cobertura WHERE P.DNI = " + valorBuscado.DNI +"");
                }


                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.Cobertura = new Cobertura();
                    aux.Cobertura.Id = (int)datos.Lector["IDCobertura"];
                    aux.Cobertura.Nombre = (string)datos.Lector["Cobertura"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dirección = (string)datos.Lector["Direccion"];
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


