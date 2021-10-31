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
        public List<Especialidades> lista()
        {
            List<Especialidades> lista = new List<Especialidades>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearQuery("Select Codigo, Nombre from Especialidad");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidades aux = new Especialidades();
                    aux.Id = (int)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

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