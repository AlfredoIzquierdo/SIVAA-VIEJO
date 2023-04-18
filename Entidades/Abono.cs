using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Abono
    {
        public string IDAbono { get; set; }
        public string IDEmpleado { get; set; }
        public string IDVenta { get; set; }
        public double SaldoActual { get; set; }
        public double SaldoAnterior { get; set; }
        public double Monto { get; set; }
        public string FormaPago { get; set; }

        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
        public string Tipo { get; set; }

    }
}
