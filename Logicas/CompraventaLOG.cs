using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class CompraventaLOG
    {
        private VentaD PdtoVen = new VentaD(); //no poner publico
        private CotizacionD PdtoCot = new CotizacionD(); //no poner publico
        private VersionD pdtover = new VersionD();
        private ModeloD pdtomod = new ModeloD();
        private VehiculoD pdtoVeh = new VehiculoD();
        private CotizacionCreditoD pdcotcred = new CotizacionCreditoD();
        private ModeloVersionD pdtModVer = new ModeloVersionD();
        public ModeloVersion ObtenerModeloVersion(string idversion)
        {
            ModeloVersion datos = pdtModVer.ObtenerPdto(idversion);
            return datos;
        }
        public Cotizacion datoscotizacion(string idcotizacion)
        {
            Cotizacion datos;
            datos = PdtoCot.ObtenerPdto(idcotizacion);
            return datos;
        }
        public CotizacionCredito datoscotizacionCredito(string idcotizacion)
        {
            CotizacionCredito datos;
            datos = pdcotcred.ObtenerPdto(idcotizacion);
            return datos;
        }
        public Entidades.Versions datosversion(string idversion)
        {
            Versions datosversion;
            datosversion = pdtover.ObtenerPdto(idversion);
            return datosversion;
        }
        public Modelo datosmodelo(string idmodelo)
        {
            Modelo datosmodelo;

            datosmodelo = pdtomod.ObtenerPdto(idmodelo);
            return datosmodelo;
        }
        public Vehiculo datosvehiculo(string idvehiculo)
        {
            Vehiculo vehiculo;

            vehiculo = pdtoVeh.ObtenerPdto(idvehiculo);
            return vehiculo;

        }
    }
}
