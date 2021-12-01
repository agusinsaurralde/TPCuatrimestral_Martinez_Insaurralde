using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace DBClinica
{
    public class EstadoTurnoDB
    {
        public List<EstadoTurno> listar()
        {
            List<EstadoTurno> lista = new List<EstadoTurno>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT ID, Descripcion FROM EstadoTurno");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    EstadoTurno aux = new EstadoTurno();
                    aux.ID = (int)datos.Lector["ID"];
                    aux.Estado = (string)datos.Lector["Descripcion"];
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
