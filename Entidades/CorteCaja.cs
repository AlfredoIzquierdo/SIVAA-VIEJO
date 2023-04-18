using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CorteCaja
    {
        public string IDCorteCaja { get; set; }
        public string IDEmpleado { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
        public string Hora { get; set; }
        public double FondoInicial { get; set; }
        public double EfectivoFinal { get; set; }
        public double TarjetaFinal { get; set; }
        public double TotalFinal { get; set; }
        public double BalanceEfectivo { get; set; }
        public double BalanceTarjeta { get; set; }
        public string Estado { get; set; }

    }
}
