using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Entidades;
using Datos;
using System.Runtime.CompilerServices;

namespace Logicas
{
    public class ClienteLog
    {
        private ClienteD Pdto = new ClienteD();//No poner public
        public readonly StringBuilder Mensaje = new StringBuilder();
        private CitaD pdtoCita = new CitaD();
        private CotizacionD pdtocotizacion = new CotizacionD();
        readonly CitaLog citaLog = new CitaLog();
        public void Registrar(Cliente Pd)
        {
            Mensaje.Clear();
            if (ValidarProducto(Pd))
            {
                if (Pdto.ObtenerPdto(Pd.IDCliente) == null)
                    //No se encuentra el dato (El código no existe)
                    Pdto.Insertar(Pd);
                else
                    Mensaje.Append("El Codigo del Cliente ya se encuentra en la B.D.");
            }
        }

        public List<Cliente> ListadoAll()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }

        public Cliente LeerPorClave(string ClPdto)
        {
            Cliente Pd = null;
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ObtenerPdto(ClPdto);
                if (Pd == null)
                    Mensaje.Append("Codigo del cliente no existe en la B.D.");
                return Pd;
            }
            return null;
        }
        public List<Cliente> ListadoPorNA(string ClPdto,string Ap)
        {
            List<Cliente> Pd = new List<Cliente>();
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd=Pdto.ListadoTotalESP(ClPdto, Ap);
                if (Pd == null)
                    Mensaje.Append("Nombre o apellido del cliente no existe en la B.D.");
                return Pd;
            }
            return null;
        }

        public List<Cliente> ListadoPorIDCliente(string ClPdto)
        {
            List<Cliente> Pd = new List<Cliente>();
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ListadoTotalIDCliente(ClPdto);
                if (Pd == null)
                    Mensaje.Append(ClPdto+" no existe en la B.D.");
                return Pd;
            }
            return null;
        }

        public List<Cliente> ListadoEspecifico(string ClPdto,string parametro)
        {
            List<Cliente> Pd = new List<Cliente>();
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ListadoTotalEspecifico(ClPdto,parametro);
                if (Pd == null)
                    Mensaje.Append(ClPdto + " no existe en la B.D.");
                return Pd;
            }
            return null;
        }


        public void Eliminar(string CodPqte)
        {
            //Agregar esto
            Mensaje.Clear();
            if (CodPqte == null)
                Mensaje.Append("Por favor proporcionar un Codigo valido");
            if (Mensaje.Length == 0)
            {
                List<Cita> citas = new List<Cita>();
                List<Cotizacion> cotizaciones = new List<Cotizacion>();
                citas = pdtoCita.ListadoTotalPorCliente(CodPqte);
                cotizaciones = pdtocotizacion.ListadoTotalPorCliente(CodPqte);
                foreach(Cita clientcita in citas)
                {
                    pdtoCita.Eliminar(clientcita.IDCita);
                }
                foreach (Entidades.Cotizacion cliencoti in cotizaciones)
                {
                    pdtocotizacion.Eliminar(cliencoti.IDCotizacion);
                }
                Pdto.EliminarDesaparecer(CodPqte);
                //Mensaje.Append("Eliminado con exito");
            }
               
               
        }
        public void EliminarPorStatus(string CodPqte)
        {
            //Agregar esto
            Mensaje.Clear();
            if (CodPqte == null)
                Mensaje.Append("Por favor proporcionar un Codigo valido");
            if (Mensaje.Length == 0)
            {
                Pdto.EliminarDesaparecer(CodPqte);
            }


        }


        private bool ValidarProducto(Cliente Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq.Nombre))
                Mensaje.Append("El campo nombre no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.ApellidoPat))
                Mensaje.Append("El campo apellido paterno no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.ApellidoMat))
                Mensaje.Append("El campo apellido materno no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.RFC))
                Mensaje.Append("El campo RFC no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Correo))
                Mensaje.Append("El campo correo no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Telefono))
                Mensaje.Append("El campo telefono no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.NoExterior))
                Mensaje.Append("El campo no.exterior no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Colonia))
                Mensaje.Append("El campo colonia no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Ciudad))
                Mensaje.Append("El campo de ciudad no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Estado))
                Mensaje.Append("El campo estado no puede estar vacio");
            return Mensaje.Length == 0;

        }

        public void Modificar(Cliente Pqte)
        {
            if (ValidarProducto(Pqte))
            {
                Pdto.Actualizar(Pqte);

            }
        }
    }
}
