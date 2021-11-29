using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace DBClinica
{
    public class TipoEmpleadoDB
    {
        public List<TipoEmpleado> listar()
        {
            List<TipoEmpleado> lista = new List<TipoEmpleado>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT ID, Tipo from TipoEmpleado ORDER BY ID ASC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoEmpleado aux = new TipoEmpleado();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Tipo"];

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
