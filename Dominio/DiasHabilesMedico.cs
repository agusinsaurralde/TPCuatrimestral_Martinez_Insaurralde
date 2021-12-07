using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DiasHabilesMedico 
    {
        public int ID { get; set; }
        public Medico Medico { get; set; }
        public Especialidad Especialidad { get; set; }
        public int IdDia { get; set; }
        public string NombreDia { get; set; }
        public DateTime HorarioEntrada { get; set; }
        public DateTime HorarioSalida { get; set; }
        public bool Estado { get; set; }
    }
}
