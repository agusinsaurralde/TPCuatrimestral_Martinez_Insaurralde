﻿using System;
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
        public List<Especialidad> lista()
        {
            List<Especialidad> lista = new List<Especialidad>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT ID, Nombre from Especialidad ORDER BY ID ASC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
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

        public void AgregarEspecialidad(Especialidad EspecialidadNueva)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta("INSERT Especialidad(ID, Nombre, Estado) VALUES(@IDE ,@NombreE)");
                datos.setearParametro("@IDE", EspecialidadNueva.Id);
                datos.setearParametro("@NombreE", EspecialidadNueva.Nombre);
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

        public void ModificarEspecialidad( Especialidad EspecialidadMod ) 
        {
            ConexionDB dato = new ConexionDB();
            try
            {
                dato.setearConsulta("UPDATE Especialidad set ID=@ID,Nombre=@Nombre where ID="+ EspecialidadMod.Id +"");
                dato.setearParametro("@ID", EspecialidadMod.Id);
                dato.setearParametro("@Nombre", EspecialidadMod.Nombre);
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
        

        public void EliminarEspecialidad(Especialidad EspecialidadDelete)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("UPDATE Especialidad SET Estado = 0 WHERE ID = " + EspecialidadDelete.Id + "");
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