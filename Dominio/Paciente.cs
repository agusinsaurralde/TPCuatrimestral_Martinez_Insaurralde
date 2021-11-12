using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Paciente : Persona
    {
        public Cobertura Cobertura { get; set; }
        public string Descripcion { get; set; }
    }
}
