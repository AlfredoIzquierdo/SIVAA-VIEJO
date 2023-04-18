using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class CotizacionCreditoLog
    {
        private CotizacionCreditoD Pdto = new CotizacionCreditoD();//No poner public
        public readonly StringBuilder Mensaje = new StringBuilder();

        public void Registrar(CotizacionCredito Pd)
        {
            Mensaje.Clear();
            if (ValidarProducto(Pd))
            {
                if (Pdto.ObtenerPdto(Pd.IDCotizacion) == null)
                    //No se encuentra el dato (El código no existe)
                    Pdto.Insertar(Pd);
                else
                    Mensaje.Append("El Codigo de la Cotizacion ya se encuentra en la B.D.");
            }
        }

        public List<CotizacionCredito> ListadoAll()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }

        public CotizacionCredito LeerPorClave(string ClPdto)
        {
            CotizacionCredito Pd = null;
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ObtenerPdto(ClPdto);
                if (Pd == null)
                    Mensaje.Append("Codigo de la Cotizacion no existe en la B.D.");
                return Pd;
            }
            return null;
        }

        public void Eliminar(string CodPqte)
        {
            Mensaje.Clear();
            if (CodPqte == "0")
                Mensaje.Append("Por favor proporcionar un Codigo valido");
            if (Mensaje.Length == 0)
                Pdto.Eliminar(CodPqte);
        }

        private bool ValidarProducto(CotizacionCredito Pq)
        {
            Mensaje.Clear();
            if (Pq.Plazo<1)
                Mensaje.Append("El campo plazo no puede ser negativo");
            if (Pq.Enganche < 1)
                Mensaje.Append("El campo enganche no puede ser negativo");
            if (Pq.Anualidad < 1)
                Mensaje.Append("El campo anualidad no puede ser negativo");
            if (Pq.Precio < 1)
                Mensaje.Append("El campo precio no puede ser negativo");
            //if (Pq.Interes < 1)
                //Mensaje.Append("El campo interes no puede ser negativo");
            if (Pq.Mensualidad < 1)
                Mensaje.Append("El campo mensualidad no puede ser negativo");
            //if (Pq.PorcentajeEnganche < 1)
                //Mensaje.Append("El campo Porcentaje enganche no puede ser negativo");
            if (Pq.Financiamiento < 1)
                Mensaje.Append("El campo financiamento no puede ser negativo");
            //if (string.IsNullOrEmpty(Pq.IDCotizacion))
            //    Mensaje.Append("El campo nombre no puede estar vacio");
            return Mensaje.Length == 0;

        }

        public void Modificar(CotizacionCredito Pqte)
        {
            if (ValidarProducto(Pqte))
            {
                Pdto.Actualizar(Pqte);

            }


        }
    }
}
