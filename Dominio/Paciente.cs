using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Paciente : Persona
    {
        public int ID { get; set; }
        public Cobertura Cobertura { get; set; }
    }
}
