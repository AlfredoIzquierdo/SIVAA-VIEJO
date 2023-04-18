using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class CotizacionContadoLog
    {
        private CotizacionContadoD Pdto = new CotizacionContadoD();//No poner public
        public readonly StringBuilder Mensaje = new StringBuilder();

        public void Registrar(CotizacionContado Pd)
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

        public List<CotizacionContado> ListadoAll()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }

        public CotizacionContado LeerPorClave(string ClPdto)
        {
            CotizacionContado Pd = null;
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

        private bool ValidarProducto(CotizacionContado Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq.IDCotizacion))
                Mensaje.Append("El campo nombre no puede estar vacio");
            return Mensaje.Length == 0;

        }

        public void Modificar(CotizacionContado Pqte)
        {
            if (ValidarProducto(Pqte))
            {
                Pdto.Actualizar(Pqte);

            }


        }
    }
}
