﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado : Usuario
    {
        public int ID { get; set; }
        public string TipoEmpleado { get; set; }
    }
}