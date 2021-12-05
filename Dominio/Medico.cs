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
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
    }
}
