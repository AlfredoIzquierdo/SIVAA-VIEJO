using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cita
    {
        public string IDCita { get; set; }
        public string IDEmpleado { get; set; }
        public string IDCliente { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
        public string Hora { get; set; }
    }
}
