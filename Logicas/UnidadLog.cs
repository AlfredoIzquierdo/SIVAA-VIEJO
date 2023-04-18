using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logicas
{
    public class UnidadLog
    {
        private UnidadD Pdto = new UnidadD();//No poner public
        private UnidadD Pdto2 = new UnidadD();//No poner public
        public readonly StringBuilder Mensaje = new StringBuilder();
        public readonly StringBuilder Mensaje2 = new StringBuilder();
        public void Registrar(Unidad Pd)
        {
            Mensaje.Clear();
            if (ValidarProducto(Pd))
            {
                if (Pdto.ObtenerPdto(Pd.NoSerie) == null)
                    //No se encuentra el dato (El código no existe)
                    Pdto.Insertar(Pd);
                else
                    Mensaje.Append("El Codigo del Cliente ya se encuentra en la B.D.");
            }
        }

        public List<Unidad> ListadoAll()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }
        public List<UnidadNoUsar> Inventario()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.InventarioGral();
        }
        public List<UnidadNoUsar> InventarioFiltro(string disp)
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.InventarioFiltro(disp);
        }

        public AutoNoUsar BuscarAuto(string ClPdto)
        {
            AutoNoUsar Pd = null;
            Mensaje.Clear();
            if (ClPdto == "")
                Mensaje.Append("Por favor proporcionar una correo valido");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ObtenerAuto(ClPdto);
                if (Pd == null)
                    Mensaje.Append("El auto de la cotizacion no existe en la B.D.");
                return Pd;
            }
            return null;
        }
        public void ModificarEstatus(string serie, string est)
        {
            if (ValidarProductoest(est))
            {
                Pdto.Actualizarest(serie, est);
            }
        }
        private bool ValidarProductoest(string Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq))
                Mensaje.Append("El campo NoSerie no puede estar vacio");
            return Mensaje.Length == 0;

        }
        public List<Unidad> ListadoPorNA(string ClPdto)
        {
            List<Unidad> Pd = new List<Unidad>();
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ListadoTotalESP(ClPdto);
                if (Pd == null)
                    Mensaje.Append("No hay un vehiculo con esa version no existe en la B.D.");
                return Pd;
            }
            return null;
        }
        public List<UnidadNoUsar> ListadoESPECIFICO(string ClPdto)
        {
            List<UnidadNoUsar> Pd = new List<UnidadNoUsar>();
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto2.ListadoUnidESP(ClPdto);
                if (Pd == null)
                    Mensaje.Append("No hay un vehiculo con esa version no existe en la B.D.");
                return Pd;
            }
            return null;
        }
        public Unidad LeerPorClave(string ClPdto)
        {
            Unidad Pd = null;
            Mensaje.Clear();
            if (ClPdto == "")
                Mensaje.Append("Por favor proporcionar una correo valido");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ObtenerPdto(ClPdto);
                if (Pd == null)
                    Mensaje.Append("El correo no existe en la B.D.");
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

        private bool ValidarProducto(Unidad Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq.NoSerie))
                Mensaje.Append("El campo NoSerie no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.IDVersion))
                Mensaje.Append("El campo IDVersion no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.IDPedido))
                Mensaje.Append("El campo IDPedido no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Color))
                Mensaje.Append("El campo Color no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.Color))
                Mensaje.Append("El campo Estatus no puede estar vacio");
            return Mensaje.Length == 0;

        }

        public void Modificar(Unidad Pqte)
        {
            if (ValidarProducto(Pqte))
            {
                Pdto.Actualizar(Pqte);

            }
        }

    }
}
