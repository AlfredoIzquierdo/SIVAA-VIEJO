using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class CitaLog
    {
        private CitaD Pdto = new CitaD();//No poner public
        public readonly StringBuilder Mensaje = new StringBuilder();

        public void Registrar(Cita Pd)
        {
            Mensaje.Clear();
            if (ValidarProducto(Pd))
            {
                if (Pdto.ObtenerPdto(Pd.IDCita) == null)
                    //No se encuentra el dato (El código no existe)
                    Pdto.Insertar(Pd);
                else
                    Mensaje.Append("El Codigo del Cliente ya se encuentra en la B.D.");
            }
        }

        public List<Cita> ListadoAll()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }
        public List<Cita> ListadoAllCliente(string idclient)
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla

            return Pdto.ListadoTotalPorCliente(idclient);
        }


        public void Modificar(Cita Pqte)
        {
            if (ValidarProducto(Pqte))
                Pdto.Actualizar(Pqte);


        }

        private bool ValidarProducto(Cita Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq.IDEmpleado))
                Mensaje.Append("El campo id en empleado no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.IDCliente))
                Mensaje.Append("El campo id en Cliente no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Dia.ToString()))
                Mensaje.Append("El campo dia no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Mes.ToString()))
                Mensaje.Append("El campo Mes no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Año.ToString()))
                Mensaje.Append("El campo año no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Hora.ToString()))
                Mensaje.Append("El campo hora no puede estar vacio");
            return Mensaje.Length == 0;

        }
    }
}
