using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class ProveedorLog
    {
        private ProveedorD Pdto = new ProveedorD();//No poner public
        public readonly StringBuilder Mensaje = new StringBuilder();

        public void Registrar(Proveedor Pd)
        {
            Mensaje.Clear();
            if (ValidarProducto(Pd))
            {
                if (Pdto.ObtenerPdto(Pd.IDProveedor) == null)
                    //No se encuentra el dato (El código no existe)
                    Pdto.Insertar(Pd);
                else
                    Mensaje.Append("El Codigo del Cliente ya se encuentra en la B.D.");
            }
        }

        public List<Proveedor> ListadoAll()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }


        public void Modificar(Proveedor Pqte)
        {
            if (ValidarProducto(Pqte))
            {
                Pdto.Actualizar(Pqte);

            }
        }

        private bool ValidarProducto(Proveedor Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq.Nombre))
                Mensaje.Append("El campo nombre no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.RFC))
                Mensaje.Append("El campo RFC no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.NoExterior))
                Mensaje.Append("El campo NoExterior materno no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Colonia))
                Mensaje.Append("El campo Colonia no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Ciudad))
                Mensaje.Append("El campo Ciudad no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Estado))
                Mensaje.Append("El campo Estado no puede estar vacio");
            return Mensaje.Length == 0;

        }
    }
}
