using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class AbonoLog
    {
        private AbonoD Pdto = new AbonoD();//No poner public
        public readonly StringBuilder Mensaje = new StringBuilder();

        public void Registrar(Abono Pd)
        {
            Mensaje.Clear();
            if (ValidarProducto(Pd))
            {
                if (Pdto.ObtenerPdto(Pd.IDAbono) == null)
                    //No se encuentra el dato (El código no existe)
                    Pdto.Insertar(Pd);
                else
                    Mensaje.Append("El Codigo del abono ya se encuentra en la B.D.");
            }
        }

        public List<Abono> ListadoAll()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }

        public Abono BuscarSaldos(string ClPdto)
        {
            Abono Pd = null;
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.Obtenersaldos(ClPdto);
                if (Pd == null)
                    Mensaje.Append("Codigo de la venta no existe en la B.D.");
                return Pd;
            }
            return null;
        }
        public Abono BuscarAbonosEfec(string ClPdto)
        {
            Abono Pd = null;
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.Obtenerabonosefectivo(ClPdto);
                if (Pd == null)
                    Mensaje.Append("Codigo de la venta no existe en la B.D.");
                return Pd;
            }
            return null;
        }
        public Abono BuscarAbonosTar(string ClPdto)
        {
            Abono Pd = null;
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.Obtenerabonostarjeta(ClPdto);
                if (Pd == null)
                    Mensaje.Append("Codigo de la venta no existe en la B.D.");
                return Pd;
            }
            return null;
        }
        public Abono LeerPorClave(string ClPdto)
        {
            Abono Pd = null;
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ObtenerPdto(ClPdto);
                if (Pd == null)
                    Mensaje.Append("Codigo del abono no existe en la B.D.");
                return Pd;
            }
            return null;
        }
        public List<Abono> ListadoEspecificp(string ClPdto)
        {
            List<Abono> Pd = null;
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ListadoTotalEspecifico(ClPdto);
                if (Pd == null)
                    Mensaje.Append("Codigo del abono no existe en la B.D.");
                return Pd;
            }
            return null;
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

        private bool ValidarProducto(Abono Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq.IDVenta))
                Mensaje.Append("El campo IDVenta no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.IDEmpleado))
                Mensaje.Append("El campo IDEmpleado no puede estar vacio");
            if (Pq.SaldoActual < 0)
                Mensaje.Append("El campo saldo actual no puede ser negativo");
            if (Pq.SaldoAnterior < 0)
                Mensaje.Append("El campo saldo anterior no puede ser negativo");
            if (Pq.Monto < 0)
                Mensaje.Append("El campo monto no puede ser negativo");
            if (Pq.Dia < 1 || Pq.Dia > 31)
                Mensaje.Append("El campo dia no puede ser menor que 1 o mayor que 31");
            if (Pq.Mes < 1 || Pq.Mes > 12)
                Mensaje.Append("El campo mes no puede ser menor que 1 o mayor que 12");
            if (Pq.Año != 2023)
                Mensaje.Append("El campo año no puede ser menor o mayor que 2023");
            if (string.IsNullOrEmpty(Pq.Tipo))
                Mensaje.Append("El campo tipo no puede estar vacio");
            return Mensaje.Length == 0;

        }

        //public void Modificar(Pago Pqte)
        //{
        //    if (ValidarProducto(Pqte))
        //    {
        //        Pdto.Actualizar(Pqte);

        //    }
        //}
    }
}
