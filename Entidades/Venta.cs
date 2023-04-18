using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        public string IDVenta { get; set; }
        public string IDEmpleado { get; set; }
        public string NoSerie { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
        public string Hora { get; set; }
        public double Subtotal { get; set; }
        public string TipoVenta { get; set; }
    }
}
