using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace DBClinica
{
    public class CoberturaDB
    {
        public List<Cobertura> listaInactiva()
        {
            List<Cobertura> lista = new List<Cobertura>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT ID, Nombre, Estado FROM Cobertura WHERE ESTADO = 0");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cobertura aux = new Cobertura();
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
        public List<Cobertura> lista()
        {
            List<Cobertura> lista = new List<Cobertura>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT ID, Nombre, Estado FROM Cobertura WHERE ESTADO = 1 ORDER BY Nombre ASC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cobertura aux = new Cobertura();
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
        public void AgregarCobertura(Cobertura CoberturaNueva)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("INSERT Cobertura(Nombre, Estado) VALUES(@Nombre, @Estado)");
                datos.setearParametro("@Nombre", CoberturaNueva.Nombre);
                datos.setearParametro("@Estado", CoberturaNueva.Estado);
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
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("UPDATE Cobertura SET Nombre=@Nombre, Estado = @Estado where ID=" + CoberturaMod.Id + "");
                datos.setearParametro("@Nombre", CoberturaMod.Nombre);
                datos.setearParametro("@Estado", CoberturaMod.Estado);
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
        public Cobertura buscarporID(int IDBuscado)
        {

            CoberturaDB coberturaDB = new CoberturaDB();
            List<Cobertura> listacoberturas = coberturaDB.lista();
            Cobertura cobertura = listacoberturas.Find(x => x.Id == IDBuscado);
            return cobertura;
        }

        public List<Cobertura> buscar(string cobertura)
        {
            List<Cobertura> lista = new List<Cobertura>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT ID, Nombre, Estado FROM Cobertura WHERE Nombre LIKE '" + cobertura + "%' AND ESTADO = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cobertura aux = new Cobertura();
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
   

