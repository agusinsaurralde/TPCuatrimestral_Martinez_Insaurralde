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
        public Medico IDMedico { get; set; }
        public Especialidad IDEspecialidad { get; set; }
        public string NombreDia { get; set; }
        public DateTime HorarioEntrada { get; set; }
        public DateTime HorarioSalida { get; set; }
    }
}
