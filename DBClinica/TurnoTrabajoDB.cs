using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace DBClinica
{
    public class TurnoTrabajoDB
    {
        public List<TurnoTrabajo> listar()
        {
            List<TurnoTrabajo> Lista = new List<TurnoTrabajo>();
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("select ID, Turno from TurnoTrabajo");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    TurnoTrabajo aux = new TurnoTrabajo();
                    aux.ID =  (int)datos.Lector["ID"];
                    aux.NombreTurno = (string)datos.Lector["Turno"];
                    Lista.Add(aux);
                }
                return Lista;
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
