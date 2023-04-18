using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class VentaLog
    {
        private VentaD Pdto = new VentaD();//No poner public
        private ClienteD pdtoclien = new ClienteD();
        private UnidadD pdtounidad = new UnidadD();
        private EmpleadoD pdtoEmpleado = new EmpleadoD();
        public readonly StringBuilder Mensaje = new StringBuilder();

        public void Registrar(Venta Pd)
        {
            Mensaje.Clear();
            if (ValidarProducto(Pd))
            {
                if (Pdto.ObtenerPdto(Pd.IDVenta) == null)
                    //No se encuentra el dato (El código no existe)
                    Pdto.Insertar(Pd);
                else
                    Mensaje.Append("El Codigo de Venta ya se encuentra en la B.D.");
            }
        }

        public List<Venta> ListadoAll()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }

        public List<VentasEntrega> ListadoAllVentasEntrega()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotalVentasEntrega();
        }
        public List<VentasEntrega> ListadoAllVentasEntregaContado()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotalVentasEntregaContado();
        }
        public List<VentasEntrega> ListadoAllVentasEntregaCredito()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotalVentasEntregaCredito();
        }
        public List<VentasEntrega> ListadoAllVentasEntregaCredito2()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotalVentasEntregaCredito2();
        }
        public List<VentasEntrega> ListadoAllVentasABONOCredito()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotalVentasABONOCredito();
        }
        public List<VentasEntrega> Listaporcliente(string nom, string app)
        {
            List<VentasEntrega> Pd = null;
            Mensaje.Clear();
            if (app == "0")
                Mensaje.Append("Por favor proporcionar un nombre valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ListadoTotalVentasEntregaPorClientes(nom, app);
                if (Pd == null)
                    Mensaje.Append("nombre o apellido no encontrado en la B.D.");
                return Pd;
            }
            return null;
        }
        public List<VentasEntrega> ListaporclienteABONO(string nom, string app)
        {
            List<VentasEntrega> Pd = null;
            Mensaje.Clear();
            if (app == "0")
                Mensaje.Append("Por favor proporcionar un nombre valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ListadoTotalVentasABONOPorClientes(nom, app);
                if (Pd == null)
                    Mensaje.Append("nombre o apellido no encontrado en la B.D.");
                return Pd;
            }
            return null;
        }

        public Venta LeerPorClave(string ClPdto)
        {
            Venta Pd = null;
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ObtenerPdto(ClPdto);
                if (Pd == null)
                    Mensaje.Append("Codigo de Venta no existe en la B.D.");
                return Pd;
            }
            return null;
        }
        //public Venta LeerPorClaveVoucher(string ClPdto)
        //{
        //    Venta Pd = null;
        //    Mensaje.Clear();
        //    if (ClPdto == "0")
        //        Mensaje.Append("Por favor proporcionar una clave valida");
        //    if (Mensaje.Length == 0)
        //    {
        //        Pd = Pdto.ObtenerPdto(ClPdto);
        //        if (Pd == null)
        //            Mensaje.Append("Voucher no encontrado en la B.D.");
        //        return Pd;
        //    }
        //    return null;
        //}

        public void Eliminar(string CodPqte)
        {
            Mensaje.Clear();
            if (CodPqte == "0")
                Mensaje.Append("Por favor proporcionar un Codigo valido");
            if (Mensaje.Length == 0)
                Pdto.Eliminar(CodPqte);
        }

        private bool ValidarProducto(Venta Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq.IDEmpleado) || Pq.IDEmpleado == "IDEmpleado")
                Mensaje.Append("El campo empleado no puede estar vacio");
            if (!string.IsNullOrEmpty(Pq.NoSerie))
                Mensaje.Append("El campo No de serie debe estar vacio");
            if (Pq.Dia < 0 || Pq.Dia > 31)
                Mensaje.Append("El campo dia no puede ser menor que 0 ni mayor que 31");
            if (Pq.Mes < 0 || Pq.Mes > 12)
                Mensaje.Append("El campo mes no puede ser menor que 0 ni mayor que 12");
            if (Pq.Año < 2022 || Pq.Año > 2024)
                Mensaje.Append("El campo año no puede ser menor que 2022 ni mayor que 2024");
            if (string.IsNullOrEmpty(Pq.Hora))
                Mensaje.Append("El campo hora no puede estar vacio");
            if (Pq.Subtotal < 0)
                Mensaje.Append("El campo subtotal no puede ser negativo");
            if (string.IsNullOrEmpty(Pq.TipoVenta))
                Mensaje.Append("El campo de Tipo pago no puede estar vacio");
            return Mensaje.Length == 0;

        }
        private bool ValidarProductoserie(string Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq))
                Mensaje.Append("El campo Numero de serie no debe estar vacio");
            return Mensaje.Length == 0;

        }
        public void Modificar(Venta Pqte)
        {
            if (ValidarProducto(Pqte))
                Pdto.Actualizar(Pqte);


        }
        public void ModificarAuto(string idventa, string serie)
        {
            if (ValidarProductoserie(serie))
                Pdto.Actualizarserie(idventa, serie);
        }

        public string[] DatosFactura(Venta Pqte, string idcli, string nombreclien, string apellidoclien, string idempleado)
        {
            string[] datosfactura = new string[19];

            string noserie = Pqte.NoSerie;
            string hora = Pqte.Hora;
            int dia = Pqte.Dia;
            int mes = Pqte.Mes;
            int año = Pqte.Año;
            double subtotal = Pqte.Subtotal;
            double iva = subtotal * .16;
            double totalfinal = subtotal + iva;


            //llenar arreglo
            datosfactura[0] = noserie;
            datosfactura[1] = hora;
            datosfactura[2] = dia.ToString();
            datosfactura[3] = mes.ToString();
            datosfactura[4] = año.ToString();
            datosfactura[5] = subtotal.ToString();

            //cliente
            Cliente clientedatos = pdtoclien.ObtenerPdto2(idcli, apellidoclien);
            string nombrec = clientedatos.Nombre;
            string apellidopc = clientedatos.ApellidoPat;
            string apellidomc = clientedatos.ApellidoMat;
            string nombrecompletoc = nombrec.Trim() + " " + apellidopc.Trim() + " " + apellidomc.Trim();
            string rfc = clientedatos.RFC;
            string colonia = clientedatos.Colonia;
            string ciudad = clientedatos.Ciudad;
            string estado = clientedatos.Estado;
            string cdestado = ciudad + "," + estado;
            string telefono = clientedatos.Telefono;
            string clavecl = clientedatos.IDCliente;
            //llenar arreglo
            datosfactura[6] = nombrecompletoc;
            datosfactura[7] = rfc;
            datosfactura[8] = colonia;
            datosfactura[9] = estado;
            datosfactura[10] = telefono;
            datosfactura[11] = clavecl;
            datosfactura[12] = clientedatos.NoExterior;
            datosfactura[13] = ciudad;
            datosfactura[14] = iva.ToString();
            datosfactura[15] = totalfinal.ToString();

            //datosVehiculo
            Unidad pruebau = pdtounidad.ObtenerPdto(noserie);
            string color = pruebau.Color;
            string IdVer = pruebau.IDVersion;


            //llenar arreglo
            datosfactura[16] = color;
            datosfactura[18] = IdVer;

            //datosempleado
            Empleado empleado = pdtoEmpleado.ObtenerPdto(idempleado.Trim());
            string nombree = empleado.Nombre;
            string apellidope = empleado.ApellidoPat;
            string apellidome = empleado.ApellidoMat;
            string nombrecompletoe = nombree.Trim() + " " + apellidope.Trim() + " " + apellidome.Trim();
            datosfactura[17] = nombrecompletoe;
            return datosfactura;
        }
    }
}
