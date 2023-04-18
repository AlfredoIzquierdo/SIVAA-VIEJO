using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cotizacion
    {
        public string IDCotizacion { get; set; }
        public string IDVersion { get; set; }
        public string IDCliente { get; set; }
        public string IDEmpleado { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
        
        public double PrecioInicial { get; set; }
        public string TipoPago { get; set; }
        public string Hora { get; set; }
    }
}
