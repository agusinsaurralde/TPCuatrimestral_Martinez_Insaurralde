using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class MedicoEspecialidades : Medico
    {
        public int IDregistro { get; set; }
        public Especialidad especialidad { get; set; }
    }
}
