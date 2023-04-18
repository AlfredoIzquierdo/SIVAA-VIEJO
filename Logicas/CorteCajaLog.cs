using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class CorteCajaLog
    {
        private CorteCajaD Pdto = new CorteCajaD();//No poner public
        public readonly StringBuilder Mensaje = new StringBuilder();

        public void Registrar(CorteCaja Pd)
        {
            Mensaje.Clear();
            if (ValidarProducto(Pd))
            {
                if (Pdto.ObtenerPdto(Pd.IDCorteCaja) == null)
                    //No se encuentra el dato (El código no existe)
                    Pdto.Insertar(Pd);
                else
                    Mensaje.Append("El Codigo del corte de caja ya se encuentra en la B.D.");
            }
        }

        public List<CorteCaja> ListadoAll()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }

        public CorteCaja LeerPorClave(string ClPdto)
        {
            CorteCaja Pd = null;
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ObtenerPdto(ClPdto);
                if (Pd == null)
                    Mensaje.Append("Codigo del corte de caja no existe en la B.D.");
                return Pd;
            }
            return null;
        }

        public CorteCaja BuscarCajaAbierta()
        {
            CorteCaja Pd = null;
            Mensaje.Clear();
                Pd = Pdto.BuscarCajaAbierta();
                if (Pd == null)
                    Mensaje.Append("No hay una caja abierta");
                return Pd;
        }

        //public List<Pago> ListadoPorNA(string ClPdto, string Ap)
        //{
        //    List<Pago> Pd = new List<Pago>();
        //    Mensaje.Clear();
        //    if (ClPdto == "0")
        //        Mensaje.Append("Por favor proporcionar una clave valida");
        //    if (Mensaje.Length == 0)
        //    {
        //        Pd = Pdto.ListadoTotalESP(ClPdto, Ap);
        //        if (Pd == null)
        //            Mensaje.Append("Nombre o apellido del cliente no existe en la B.D.");
        //        return Pd;
        //    }
        //    return null;
        //}

        //public void Eliminar(string CodPqte)
        //{
        //    Mensaje.Clear();
        //    if (CodPqte == "0")
        //        Mensaje.Append("Por favor proporcionar un Codigo valido");
        //    if (Mensaje.Length == 0)
        //        Pdto.Eliminar(CodPqte);
        //}

        private bool ValidarProducto(CorteCaja Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq.IDEmpleado)|| Pq.IDEmpleado=="IDCajero")
                Mensaje.Append("El campo IDEmpleado no puede estar vacio");
            if (Pq.Dia < 1 || Pq.Dia > 31)
                Mensaje.Append("El campo dia no puede ser menor que 1 o mayor que 31");
            if (Pq.Mes < 1 || Pq.Mes > 12)
                Mensaje.Append("El campo mes no puede ser menor que 1 o mayor que 12");
            if (Pq.Año != 2023)
                Mensaje.Append("El campo año no puede ser menor o mayor que 2023");
            if (string.IsNullOrEmpty(Pq.Hora))
                Mensaje.Append("El campo hora no puede estar vacio");
            if (Pq.FondoInicial < 0)
                Mensaje.Append("El fondo inicial no puede ser negativo");
            if (Pq.EfectivoFinal < 0)
                Mensaje.Append("El efectivo final no puede ser negativo");
            if (Pq.TarjetaFinal < 0)
                Mensaje.Append("El efectivo final no puede ser negativo");
            if (Pq.TotalFinal < 0)
                Mensaje.Append("El total final no puede ser negativo");
            if (Pq.BalanceEfectivo < 0)
                Mensaje.Append("El balance efectivo no puede ser negativo");
            if (Pq.BalanceTarjeta < 0)
                Mensaje.Append("El balance tarjeta no puede ser negativo");
            return Mensaje.Length == 0;

        }
        private bool ValidarProducto2(CorteCaja Pq)
        {
            Mensaje.Clear();
            
            if (Pq.EfectivoFinal < 0)
                Mensaje.Append("El efectivo final no puede ser negativo");
            if (Pq.TarjetaFinal < 0)
                Mensaje.Append("El efectivo final no puede ser negativo");
            if (Pq.TotalFinal < 0)
                Mensaje.Append("El total final no puede ser negativo");
            if (Pq.BalanceEfectivo < 0)
                Mensaje.Append("El balance efectivo no puede ser negativo");
            if (Pq.BalanceTarjeta < 0)
                Mensaje.Append("El balance tarjeta no puede ser negativo");
            return Mensaje.Length == 0;

        }
        public void ModificarEstado(CorteCaja Pqte)
        {
            if (ValidarProducto2(Pqte))
            {
                Pdto.ActualizarEstado(Pqte);

            }
        }
    }
}
