using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Medico : Persona
    {
        public int ID { get; set; }
        public string Matricula { get; set; }
        public Especialidad Especialidad { get; set; }
        public TurnoTrabajo Turno { get; set; }
        public DateTime HorarioEntrada { get; set; }
        public DateTime HorarioSalida { get; set; }
    }
}
