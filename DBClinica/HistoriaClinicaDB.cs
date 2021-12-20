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
                datos.setearConsulta("SELECT H.ID, H.IDPaciente, CONCAT(P.Nombre, ' ', P.Apellido) as NombreCompleto, P.Apellido, P.Nombre, H.IDMedico, M.Apellido as ApellidoMedico, M.Nombre as NombreMedico,  CONCAT(M.Nombre, ' ', M.Apellido) as NombreCompletoMedico,  H.Fecha, H.Descripcion FROM  HistoriaClinica AS H INNER JOIN Paciente AS P ON P.ID = H.IDPaciente INNER JOIN EMPLEADO AS M ON M.ID = H.IDMedico");
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
                    aux.Medico = new Medico();
                    aux.Medico.ID = (int)datos.Lector["IDMedico"];
                    aux.Medico.Apellido = (string)datos.Lector["ApellidoMedico"];
                    aux.Medico.Nombre = (string)datos.Lector["NombreMedico"];
                    aux.Medico.NombreCompleto = (string)datos.Lector["NombreCompletoMedico"];
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
                datos.setearConsulta("INSERT HistoriaClinica(IDPaciente, IDMedico, Fecha, Descripcion, Estado) VALUES(@IDPaciente, @IDMedico, @Fecha, @Descripcion, 1)");
                datos.setearParametro("@IDPaciente", HCNueva.Paciente.ID);
                datos.setearParametro("@IDMedico", HCNueva.Medico.ID);
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
                datos.setearConsulta("UPDATE HistoriaClinica SET Descripcion = @Descripcion WHERE ID=" + ModHistoriaClinica.ID + "");
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

        public HistoriaClinica buscarporMedico(int id)
        {
            HistoriaClinicaDB hcDB = new HistoriaClinicaDB();
            List<HistoriaClinica> listahc = hcDB.lista();
            HistoriaClinica hc = listahc.Find(x => x.Medico.ID == id);
            return hc;
        }

        public List<HistoriaClinica> buscar(string nombre)
        {
            List<HistoriaClinica> lista = new List<HistoriaClinica>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT H.ID ,H.IDPaciente, CONCAT(P.Nombre, ' ', P.Apellido) as NombreCompleto, P.Apellido, P.Nombre, H.IDMedico,  M.Apellido as ApellidoMedico, M.Nombre as NombreMedico,  CONCAT(M.Nombre, ' ', M.Apellido) as NombreCompletoMedico, H.Fecha, H.Descripcion FROM  HistoriaClinica AS H INNER JOIN Paciente AS P ON P.ID = H.IDPaciente INNER JOIN EMPLEADO AS M ON M.ID = H.IDMedico WHERE P.Apellido LIKE '" + nombre + "%' OR P.Nombre LIKE '" + nombre + "%' OR CONCAT(P.Nombre, ' ', P.Apellido)  LIKE '" + nombre + "%'");
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
                    aux.Medico = new Medico();
                    aux.Medico.ID = (int)datos.Lector["IDPaciente"];
                    aux.Medico.Apellido = (string)datos.Lector["Apellido"];
                    aux.Medico.Nombre = (string)datos.Lector["Nombre"];
                    aux.Medico.NombreCompleto = (string)datos.Lector["NombreCompleto"];
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

