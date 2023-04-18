using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class VehiculoLog
    {
        private VehiculoD Pdto = new VehiculoD();//No poner public
        public readonly StringBuilder Mensaje = new StringBuilder();

        public void Registrar(Vehiculo Pd)
        {
            Mensaje.Clear();
            if (ValidarProducto(Pd))
            {
                if (Pdto.ObtenerPdto(Pd.IDVehiculo) == null)
                    //No se encuentra el dato (El código no existe)
                    Pdto.Insertar(Pd);
                else
                    Mensaje.Append("El Codigo del Cliente ya se encuentra en la B.D.");
            }
        }

        public List<Vehiculo> ListadoAll()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }

        public void Modificar(Vehiculo Pqte)
        {
            if (ValidarProducto(Pqte))
                Pdto.Actualizar(Pqte);
        }

        private bool ValidarProducto(Vehiculo Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq.Nombre))
                Mensaje.Append("El campo nombre no puede estar vacio");
            return Mensaje.Length == 0;

        }
    }
}
