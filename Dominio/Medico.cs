using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Medico : Usuario
    {
        public string Matricula { get; set; }
        public Especialidades Especialidad { get; set; }
        public string Turno { get; set; }
        public DateTime HorarioEntrada { get; set; }
        public DateTime HorarioESalida { get; set; }
    }
}
