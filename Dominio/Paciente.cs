using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Paciente : Persona
    {
        public Coberturas Cobertura { get; set; }
        public string Descripcion { get; set; }
    }
}
