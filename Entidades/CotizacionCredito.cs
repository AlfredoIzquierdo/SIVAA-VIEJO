using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CotizacionCredito
    {
        public string IDCotizacion { get; set; }
        public int Plazo { get; set; }
        public double Enganche { get; set; }
        public double Anualidad { get; set; }
        public double Precio { get; set; }
        public string Interes { get; set; }
        public double Mensualidad { get; set; }
        public string PorcentajeEnganche { get; set; }
        public double Financiamiento { get; set; }

    }
}
