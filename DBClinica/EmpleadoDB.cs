using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace DBClinica
{
    public class EmpleadoDB
    {
        public List<Empleado> listarEmpleado()
        {
            List<Empleado> lista = new List<Empleado>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT E.ID, E.DNI, CONCAT(E.Nombre,' ', E.Apellido) as NombreCompleto, E.Apellido, E.Nombre, E.Telefono, E.Email, E.Direccion, E.FechaNacimiento, E.IDTipo, T.Tipo, E.Estado FROM Empleado AS E INNER JOIN TipoEmpleado AS T ON T.ID = E.IDTipo WHERE T.Tipo = 'Administrador' OR T.Tipo = 'Recepcionista' order by e.apellido asc");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.NombreCompleto = (string)datos.Lector["NombreCompleto"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dirección = (string)datos.Lector["Direccion"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.TipoEmp = new TipoEmpleado();
                    aux.TipoEmp.ID = (int)datos.Lector["IDTipo"];
                    aux.TipoEmp.Nombre = (string)datos.Lector["Tipo"];
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

        public List<Empleado> listarRecepcionista()
        {
            List<Empleado> lista = new List<Empleado>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT E.ID, E.DNI, CONCAT(E.Nombre, ' ', E.Apellido) as NombreCompleto, E.Apellido, E.Nombre, E.Telefono, E.Email, E.Direccion, E.FechaNacimiento, E.IDTipo, T.Tipo, E.Estado FROM Empleado AS E INNER JOIN TipoEmpleado AS T ON T.ID = E.IDTipo WHERE T.Tipo LIKE 'Recepcionista'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.NombreCompleto = (string)datos.Lector["NombreCompleto"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dirección = (string)datos.Lector["Direccion"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.TipoEmp = new TipoEmpleado();
                    aux.TipoEmp.ID = (int)datos.Lector["IDTipo"];
                    aux.TipoEmp.Nombre = (string)datos.Lector["Tipo"];
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
        public List<Empleado> listarAdministrador()
        {
            List<Empleado> lista = new List<Empleado>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT E.ID, E.DNI,CONCAT(E.Nombre, ' ', E.Apellido) as NombreCompleto, E.Apellido, E.Nombre, E.Telefono, E.Email, E.Direccion, E.FechaNacimiento, E.IDTipo, T.Tipo, E.Estado FROM Empleado AS E INNER JOIN TipoEmpleado AS T ON T.ID = E.IDTipo WHERE T.Tipo LIKE 'Administrador'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.NombreCompleto = (string)datos.Lector["NombreCompleto"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dirección = (string)datos.Lector["Direccion"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.TipoEmp = new TipoEmpleado();
                    aux.TipoEmp.ID = (int)datos.Lector["IDTipo"];
                    aux.TipoEmp.Nombre = (string)datos.Lector["Tipo"];
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
        public void agregar(Empleado EmpleadoNuevo)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("insert Empleado(DNI, IDTipo, Nombre, Apellido, Telefono, Email, Direccion, FechaNacimiento, Estado)VALUES(@DNI, @IDTipo, @Nombre, @Apellido, @Telefono, @Email, @Direccion, @FechaNacimiento, 1)");
                datos.setearParametro("@DNI", EmpleadoNuevo.DNI);
                datos.setearParametro("@IDTipo", EmpleadoNuevo.TipoEmp.ID);
                datos.setearParametro("@Nombre", EmpleadoNuevo.Nombre);
                datos.setearParametro("@Apellido", EmpleadoNuevo.Apellido);
                datos.setearParametro("@Telefono", EmpleadoNuevo.Telefono);
                datos.setearParametro("@Email", EmpleadoNuevo.Email);
                datos.setearParametro("@Direccion", EmpleadoNuevo.Dirección);
                datos.setearParametro("@FechaNacimiento", EmpleadoNuevo.FechaNacimiento);

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

        public void modificar(Empleado ModEmpleado)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("UPDATE Empleado SET DNI = @DNI, Apellido = @Apellido, Nombre = @Nombre, Telefono = @Telefono, Email = @Email, Direccion = @Direccion, FechaNacimiento = @FechaNacimiento, IDTipo = @IDTipo WHERE ID =" + ModEmpleado.ID + "");
                datos.setearParametro("@DNI", ModEmpleado.DNI);
                datos.setearParametro("@Apellido", ModEmpleado.Apellido);
                datos.setearParametro("@Nombre", ModEmpleado.Nombre);
                datos.setearParametro("@Telefono", ModEmpleado.Telefono);
                datos.setearParametro("@Email", ModEmpleado.Email);
                datos.setearParametro("@Direccion", ModEmpleado.Dirección);
                datos.setearParametro("@FechaNacimiento", ModEmpleado.FechaNacimiento);
                datos.setearParametro("@IDTipo", ModEmpleado.TipoEmp.ID);

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

        public void eliminar(int ElimEmpleado)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("Update Empleado SET Estado = 0 where ID = " + ElimEmpleado + "");
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

        public Empleado buscarporID(int IDBuscado)
        {

            EmpleadoDB empleadoDB = new EmpleadoDB();
            List<Empleado> listaempleados = empleadoDB.listarEmpleado();
            Empleado empleado = listaempleados.Find(x => x.ID == IDBuscado);
            return empleado;
        }

        public List<Empleado> buscarEmpleado(string empleado)
        {
            List<Empleado> lista = new List<Empleado>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT E.ID, E.DNI, E.Apellido, E.Nombre, E.Telefono, E.Email, E.Direccion, E.FechaNacimiento, E.IDTipo, T.Tipo, E.Estado FROM Empleado AS E INNER JOIN TipoEmpleado AS T ON T.ID = E.IDTipo WHERE (T.Tipo = 'Administrador' OR T.Tipo = 'Recepcionista') AND (E.Nombre LIKE '" + empleado + "%' OR E.Apellido LIKE '"+ empleado + "%' OR CONCAT(E.Apellido, ' ', E.Nombre) LIKE '"+ empleado + "%' )");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();

                    aux.ID = (int)datos.Lector["ID"];
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Telefono = (string)datos.Lector["Telefono"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Dirección = (string)datos.Lector["Direccion"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                    aux.TipoEmp = new TipoEmpleado();
                    aux.TipoEmp.ID = (int)datos.Lector["IDTipo"];
                    aux.TipoEmp.Nombre = (string)datos.Lector["Tipo"];
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

        public Empleado empleadoLogueado(int IDUsuarioLogueado)
        { // le das el ID de usuario y te trae el empleado logueado.
            ConexionDB datos = new ConexionDB();
            Empleado empleadoEncontrado = new Empleado();

            try
            {
                datos.setearConsulta("SELECT E.ID as ID, E.DNI as DNI, E.Nombre as Nombre, E.Apellido as Apellido, E.Telefono as Telefono, E.Email as Email, E.Direccion as Direccion, E.FechaNacimiento as FechaNacimiento, E.IDTipo as IDTipo, U.NombreUsuario as NombreUsuario, E.Estado as Estado FROM Empleado as E INNER JOIN Usuario as U on E.ID = U.ID WHERE E.ID =" + IDUsuarioLogueado + ""); // aca una consulta que tragia los datos de ese usuario
                datos.ejecutarLectura();

                datos.Lector.Read();

                empleadoEncontrado.ID = (int)datos.Lector["ID"];
                empleadoEncontrado.DNI = (string)datos.Lector["DNI"];
                empleadoEncontrado.NombreCompleto = (string)datos.Lector["Nombre"] + (string)datos.Lector["Apellido"];
                empleadoEncontrado.Nombre = (string)datos.Lector["Nombre"];
                empleadoEncontrado.Apellido = (string)datos.Lector["Apellido"];
                empleadoEncontrado.Telefono = (string)datos.Lector["Telefono"];
                empleadoEncontrado.Email = (string)datos.Lector["Email"];
                empleadoEncontrado.Dirección = (string)datos.Lector["Email"];
                empleadoEncontrado.FechaNacimiento = (DateTime)datos.Lector["FechaNacimiento"];
                empleadoEncontrado.TipoEmp = new TipoEmpleado();
                empleadoEncontrado.TipoEmp.ID = (int)datos.Lector["IDTipo"];
                empleadoEncontrado.TipoEmp.Nombre = (string)datos.Lector["NombreUsuario"];
                empleadoEncontrado.Estado = (bool)datos.Lector["Estado"];

                return empleadoEncontrado;
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

