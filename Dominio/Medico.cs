using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Medico : Usuario
    {
        public int ID { get; set; }
        public string Matricula { get; set; }
        public Especialidad Especialidad { get; set; }
        public string Turno { get; set; }
        public DateTime HorarioEntrada { get; set; }
        public DateTime HorarioESalida { get; set; }
    }
}
