using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace DBClinica
{
    public class HistoriaClinicaDB
    {
        public List<HistoriaClinica> lista()
        {
            List<HistoriaClinica> lista = new List<HistoriaClinica>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT H.ID, H.IDPaciente, CONCAT(P.Nombre, ' ', P.Apellido) as NombreCompleto, P.Apellido, P.Nombre, H.Fecha, H.Descripcion FROM  HistoriaClinica AS H INNER JOIN Paciente AS P ON P.ID = H.IDPaciente");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    HistoriaClinica aux = new HistoriaClinica();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.Paciente = new Paciente();
                    aux.Paciente.ID = (int)datos.Lector["IDPaciente"];
                    aux.Paciente.Apellido = (string)datos.Lector["Apellido"];
                    aux.Paciente.Nombre = (string)datos.Lector["Nombre"];
                    aux.Paciente.NombreCompleto = (string)datos.Lector["NombreCompleto"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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

        public void AgregarHistoriaClinica(HistoriaClinica HCNueva)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("INSERT HistoriaClinica(IDPaciente, Fecha, Descripcion, Estado) VALUES(@IDPaciente, @Fecha, @Descripcion, 1)");
                datos.setearParametro("@IDPaciente", HCNueva.Paciente.ID);
                datos.setearParametro("@Fecha", HCNueva.Fecha);
                datos.setearParametro("@Descripcion", HCNueva.Descripcion);
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

        public void ModificarHistoriaClinica(HistoriaClinica ModHistoriaClinica)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("UPDATE HistoriaClinica SET IDPaciente = @IDPaciente, Fecha = @Fecha, Descripcion = @Descripcion WHERE ID=" + ModHistoriaClinica.ID + "");
                datos.setearParametro("@IDPaciente", ModHistoriaClinica.Paciente.ID);
                datos.setearParametro("@Fecha", ModHistoriaClinica.Fecha);
                datos.setearParametro("@Descripcion", ModHistoriaClinica.Descripcion);
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
        public void EliminarHistoriaClinica(HistoriaClinica ElimHistoriaClinica)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("UPDATE HistoriaClinica SET Estado = 0 WHERE ID = " + ElimHistoriaClinica.ID + "");
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

        public HistoriaClinica buscarporID(int id)
        {
            HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
            List<HistoriaClinica> listahc = hcDB.lista();
            HistoriaClinica hc = listahc.Find(x => x.ID == id);
            return hc;
        }

        public List<HistoriaClinica> buscar(string nombre)
        {
            List<HistoriaClinica> lista = new List<HistoriaClinica>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT DISTINCT H.IDPaciente, CONCAT(P.Nombre, ' ', P.Apellido) as NombreCompleto, P.Apellido, P.Nombre, H.Fecha, H.Descripcion FROM  HistoriaClinica AS H INNER JOIN Paciente AS P ON P.ID = H.IDPaciente WHERE P.Apellido LIKE '" + nombre + "%' OR P.Nombre LIKE '" + nombre + "%' OR CONCAT(P.Nombre, ' ', P.Apellido)  LIKE '" + nombre + "%'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    HistoriaClinica aux = new HistoriaClinica();
                    //aux.ID = (int)datos.Lector["ID"];
                    aux.Paciente = new Paciente();
                    aux.Paciente.ID = (int)datos.Lector["IDPaciente"];
                    aux.Paciente.Apellido = (string)datos.Lector["Apellido"];
                    aux.Paciente.Nombre = (string)datos.Lector["Nombre"];
                    aux.Paciente.NombreCompleto = (string)datos.Lector["NombreCompleto"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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

