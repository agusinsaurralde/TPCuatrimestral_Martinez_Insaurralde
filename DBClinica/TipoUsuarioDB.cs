using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace DBClinica
{
    class TipoUsuarioDB
    {
        public List<TipoUsuario> listar()
        {
            List<TipoUsuario> lista = new List<TipoUsuario>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT ID, Nombre from TipoUsuario ORDER BY ID ASC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoUsuario aux = new TipoUsuario();
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

        public void AgregarTipoUsuario(TipoUsuario tipoUsuarioNuevo)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("INSERT TipoUsuario(Nombre, Estado) VALUES(@Nombre, @Estado)");
                datos.setearParametro("@Nombre", tipoUsuarioNuevo.Nombre);
                datos.setearParametro("@Estado",tipoUsuarioNuevo.Estado);
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
        public void ModificarTipoUsuario(TipoUsuario TipoUsuarioMod)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("UPDATE TipoUsuario Nombre=@Nombre, Estado = @Estado where ID=" + TipoUsuarioMod.Id + "");
                datos.setearParametro("@Nombre", TipoUsuarioMod.Nombre);
                datos.setearParametro("@Estado", TipoUsuarioMod.Estado);
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
        public void EliminarTipoUsuario(TipoUsuario tipoUsuarioDelete)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("UPDATE TipoUsuario SET Estado = 0 WHERE ID = " + tipoUsuarioDelete.Id + "");
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
