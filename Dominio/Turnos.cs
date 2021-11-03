using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Turnos
    {
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public Especialidades Especialidad { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFin { get; set; }
        public Medico NombreMedico { get; set; } 
        public DateTime Dia { get; set; }
        public string Observaciones { get; set; }
        public int Numero { get; set; }
        public Recepcionista AdministrativoResponsable { get; set; }
        public EstadosTurno Estado { get; set; }
    }
}
