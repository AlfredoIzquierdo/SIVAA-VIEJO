using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        public string IDPedido { get; set; }
        public string IDProveedor { get; set; }
        public string IDEmpleado { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
        public double Importe { get; set; }
    }
}
