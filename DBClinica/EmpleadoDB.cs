using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace DBClinica
{
    class EmpleadoDB
    {
        public List<Empleado> listarEmpleado()
        {
            List<Empleado> lista = new List<Empleado>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT E.ID, E.DNI, E.Apellido, E.Nombre, E.Telefono, E.Email, E.Direccion, E.FechaNacimiento, E.IDTipo, T.Tipo, E.Estado FROM Empleado AS E INNER JOIN TipoEmpleado AS T ON T.ID = E.IDTipo");
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

        public void agregar(Empleado EmpleadoNuevo)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("INSERT Empelado(DNI, Apellido, Nombre, Telefono, Email, Direccion, FechaNacimiento, IDTipo, Estado)VALUES(@DNI, @Apellido, @Nombre, @Telefono, @Email, @Direccion, @FechaNacimiento, @IDTipo, @Estado)");
                datos.setearParametro("@DNI", EmpleadoNuevo.DNI);
                datos.setearParametro("@Apellido", EmpleadoNuevo.Apellido);
                datos.setearParametro("@Nombre", EmpleadoNuevo.Nombre);
                datos.setearParametro("@Telefono", EmpleadoNuevo.Telefono);
                datos.setearParametro("@Email", EmpleadoNuevo.Email);
                datos.setearParametro("@Direccion", EmpleadoNuevo.Dirección);
                datos.setearParametro("@FechaNacimiento", EmpleadoNuevo.FechaNacimiento);
                datos.setearParametro("@IDTipo", EmpleadoNuevo.TipoEmp);
                datos.setearParametro("@Estado", EmpleadoNuevo.Estado);
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
                datos.setearConsulta("UPDATE Paciente SET DNI = @DNI, Apellido = @Apellido, Nombre = @Nombre, Telefono = @Telefono, Email = @Email, Direccion = @Direccion, FechaNacimiento = @FechaNacimiento, IDTipo = @IDTipo, Estado = @Estado WHERE ID =" + ModEmpleado.ID + "");
                datos.setearParametro("@DNI", ModEmpleado.DNI);
                datos.setearParametro("@Apellido", ModEmpleado.Apellido);
                datos.setearParametro("@Nombre", ModEmpleado.Nombre);
                datos.setearParametro("@Telefono", ModEmpleado.Telefono);
                datos.setearParametro("@Email", ModEmpleado.Email);
                datos.setearParametro("@Direccion", ModEmpleado.Dirección);
                datos.setearParametro("@FechaNacimiento", ModEmpleado.FechaNacimiento);
                datos.setearParametro("@IDTipo", ModEmpleado.TipoEmp);
                datos.setearParametro("@Estado", ModEmpleado.Estado);
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

        public void eliminar(Empleado ElimEmpleado)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("Update Empelado SET Estado = 0 where ID = " + ElimEmpleado.ID + "");
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

