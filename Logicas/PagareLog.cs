using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class PagareLog
    {
        private CotizacionCreditoD Pdto = new CotizacionCreditoD();//No poner public

        public readonly StringBuilder Mensaje = new StringBuilder();

        public CotizacionCredito DatosCotizacion(string idcotizacion)
        {
            CotizacionCredito coti;
            coti = Pdto.ObtenerPdto(idcotizacion);

            return coti;

        }
    }
}
