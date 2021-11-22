using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario : Persona
    {
        public int IDUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string Contraseña { get; set; }


        public Usuario(string usuario, string contraseña, TipoUsuario tipoUsuario)
        {
            NombreUsuario = usuario;
            Contraseña = contraseña;
            TipoUsuario = tipoUsuario;

        }
        public Usuario()
        {

        }
    }
}
