using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace DBClinica
{
    class CoberturaDB
    {
        public List<Cobertura> lista()
        {
            List<Cobertura> lista = new List<Cobertura>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT ID, Nombre FROM Cobertura ORDER BY ID ASC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cobertura aux = new Cobertura();
                    aux.Id = (int)datos.Lector["ID"];
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

        public void AgregarCobertura(Cobertura CoberturaNueva)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("INSERT Cobertura(ID, Nombre, Estado) VALUES(@IDE ,@NombreE)");
                datos.setearParametro("@IDE", CoberturaNueva.Id);
                datos.setearParametro("@NombreE", CoberturaNueva.Nombre);
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

        public void ModificarCobertura(Cobertura CoberturaMod)
        {
            ConexionDB dato = new ConexionDB();
            try
            {
                dato.setearConsulta("UPDATE Cobertura set ID=@ID,Nombre=@Nombre where ID=" + CoberturaMod.Id + "");
                dato.setearParametro("@ID", CoberturaMod.Id);
                dato.setearParametro("@Nombre", CoberturaMod.Nombre);
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
        public void EliminarCobertura(Cobertura coberturaDelete)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("UPDATE Cobertura SET Estado = 0 WHERE ID = " + coberturaDelete.Id + "");
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
