using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VentasEntrega
    {
        public string IDVenta { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
        public string Hora { get; set; }
        public string TipoVenta { get; set; }
        public string Vehiculo { get; set; }
        public string Version { get; set; }
        public string Cilindraje { get; set; }
        public string Transmision { get; set; }
        public string Modelo { get; set; }
    }
}
