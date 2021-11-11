using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Turno
    {
        public Paciente Paciente { get; set; 
        public string Especialidad { get; set; } //no
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFin { get; set; }
        public Medico Medico { get; set; } 
        public DateTime Dia { get; set; }
        public string Observaciones { get; set; }
        public int Numero { get; set; }
        public Empleado AdministrativoResponsable { get; set; }
        public EstadoTurno Estado { get; set; }
    }
}
