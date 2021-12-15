using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace DBClinica
{
    public class UsuarioDB
    {
        public bool Ingresar(Usuario Usuario)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("SELECT U.ID, U.IDTipo, T.Nombre FROM USUARIO AS U INNER JOIN TipoUsuario AS T ON T.ID = U.IDTipo WHERE NombreUsuario = @Usuario AND Contraseña = @Contraseña");
                datos.setearParametro("@Usuario", Usuario.NombreUsuario);
                datos.setearParametro("@Contraseña", Usuario.Contraseña); 
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario.IDUsuario = (int)datos.Lector["ID"];
                    Usuario.TipoUsuario = new TipoUsuario();
                    Usuario.TipoUsuario.Id = (int)datos.Lector["IDTipo"];
                    Usuario.TipoUsuario.Nombre = (string)datos.Lector["Nombre"];
                    return true;
                }
                return false;
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
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT ID, NombreUsuario, Contraseña, Estado FROM Usuario  ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IDUsuario = (int)datos.Lector["ID"];
                    aux.NombreUsuario = (string)datos.Lector["NombreUsuario"];
                    aux.Contraseña = (string)datos.Lector["Contraseña"];
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
        public void AgregarUsuario(Usuario UsuarioNuevo)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("INSERT Usuario(ID, NombreUsuario, Contraseña, IDTipo, Estado) VALUES(@ID, @NombreUsuario, @Contraseña, @IDTipo, 1)");
                datos.setearParametro("@ID", UsuarioNuevo.IDUsuario);
                datos.setearParametro("@NombreUsuario", UsuarioNuevo.NombreUsuario);
                datos.setearParametro("@Contraseña", UsuarioNuevo.Contraseña);
                datos.setearParametro("@IDTipo", UsuarioNuevo.TipoUsuario.Id);
        

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
        public void ModificarUsuario(Usuario ModUsuario)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("UPDATE Usuario set ID = @ID, NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, IDTipo = @IDTipo WHERE ID =" + ModUsuario.IDUsuario + "");
                datos.setearParametro("@ID", ModUsuario.IDUsuario);
                datos.setearParametro("@NombreUsuario", ModUsuario.NombreUsuario);
                datos.setearParametro("@Contraseña", ModUsuario.Contraseña);
                datos.setearParametro("@IDTipo", ModUsuario.TipoUsuario.Id);
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

        public Usuario buscarporID(int IDBuscado)
        {
            UsuarioDB usuarioDB = new UsuarioDB();
            List<Usuario> listausuarios = usuarioDB.listar();
            Usuario usuario = listausuarios.Find(x => x.IDUsuario == IDBuscado);
            return usuario;
        }

        public void eliminar(int ElimEUsuario)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("Update Usuario SET Estado = 0 where ID = " + ElimEUsuario + "");
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
       

