using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace DBClinica
{
    public class EspecialidadDB
    {
        public List<Especialidad> lista()
        {
            List<Especialidad> lista = new List<Especialidad>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT ID, Nombre,Estado from Especialidad ORDER BY Nombre ASC WHERE ESTADO = 1 ORDER BY NOMBRE ASC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
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

        public void AgregarEspecialidad(Especialidad EspecialidadNueva)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("INSERT Especialidad(Nombre, Estado) VALUES(@NombreE, @Estado)");
                datos.setearParametro("@NombreE", EspecialidadNueva.Nombre);
                datos.setearParametro("@Estado", EspecialidadNueva.Estado);
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

        public void ModificarEspecialidad( Especialidad EspecialidadMod ) 
        {
            ConexionDB dato = new ConexionDB();
            try
            {
                dato.setearConsulta("UPDATE Especialidad SET Nombre=@Nombre where ID="+ EspecialidadMod.Id +"");
                dato.setearParametro("@Nombre", EspecialidadMod.Nombre);
                dato.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dato.cerrarConexion();
            }
        }

        public void EliminarEspecialidad(Especialidad EspecialidadDelete)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("UPDATE Especialidad SET Estado = 0 WHERE ID = " + EspecialidadDelete.Id + "");
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

        public Especialidad buscarporID(int IDBuscado)
        {

            EspecialidadDB especialidadDB = new EspecialidadDB();
            List<Especialidad> listaespecialidades = especialidadDB.lista();
            Especialidad especialidad = listaespecialidades.Find(x => x.Id == IDBuscado);
            return especialidad;
        }

        public List<Especialidad> buscar(string especialidad)
        {
            List<Especialidad> lista = new List<Especialidad>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT ID, Nombre,Estado from Especialidad WHERE Nombre LIKE '" + especialidad + "%' AND ESTADO = 1 ORDER BY NOMBRE ASC");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
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