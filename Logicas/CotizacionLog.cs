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
    public class CotizacionLog
    {
        private CotizacionD Pdto = new CotizacionD();//No poner public
        public readonly StringBuilder Mensaje = new StringBuilder();
        private VersionD datosVersion = new VersionD();
        private UnidadD datosUnidad = new UnidadD();
        private VehiculoD datosVehiculo= new VehiculoD();
        private ModeloD datosmodelo= new ModeloD();
        private ModeloVersionD datosModeloVersion = new ModeloVersionD();

        //public Unidad ObtenerUnidades(string IDVersion)
        //{
        //    Unidad datos=datosUnidad.ObtenerPdtoPorVersion(IDVersion);

        //    return datos;
        //}
        public List<Unidad> BuscarColores(string NombreVersion,string NombreVehiculo)
        {
            List<Unidad> unidadesDisponibles = new List<Unidad>();
            Vehiculo vehiculoDeseado = datosVehiculo.ObtenerPdtoPorNombre(NombreVehiculo);
            Versions versionDeseada = datosVersion.ObtenerPdtoPorNombreModelo(NombreVersion,vehiculoDeseado.Nombre.Trim());
            List<Unidad> datos = datosUnidad.ObtenerPdtoPorVersion(versionDeseada.IDVersion);
            return datos;
        }
        public List<Modelo> ObtenerModeloPorNombre(string NombreVersion,string NombreVehiculo)
        {
            Vehiculo vehiculoDeseado = datosVehiculo.ObtenerPdtoPorNombre(NombreVehiculo);
            Versions versionDeseada = datosVersion.ObtenerPdtoPorNombreModelo(NombreVersion, vehiculoDeseado.Nombre);
            ModeloVersion modeloVersion = datosModeloVersion.ObtenerPdto(versionDeseada.IDVersion);
            List<Modelo> datos = datosmodelo.ObtenerPdtoLista(modeloVersion.IDModelo);

            return datos;
        }
        public Versions ObtenerVersionPrecio(string NombreVersion,string NombreVehiculo)
        {
            Vehiculo vehiculoDeseado = datosVehiculo.ObtenerPdtoPorNombre(NombreVehiculo);
            Versions datos = datosVersion.ObtenerPdtoPorNombreModelo(NombreVersion, vehiculoDeseado.Nombre);
            return datos;
        }
        public void Registrar(Cotizacion Pd)
        {
            Mensaje.Clear();
            if (ValidarProducto(Pd))
            {
                if (Pdto.ObtenerPdto(Pd.IDCliente) == null)
                    //No se encuentra el dato (El código no existe)
                    Pdto.Insertar(Pd);
                else
                    Mensaje.Append("El Codigo del Cotizacion ya se encuentra en la B.D.");
            }
        }


        public List<Cotizacion> ListadoAll()
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotal();
        }
        public List<Cotizacion> ListadoAllPorCliente(string idcliente)
        {
            //Método que obtiene la lista dinámica de todos los registro que tiene mi tabla
            return Pdto.ListadoTotalPorCliente(idcliente);
        }


        public Cotizacion LeerPorClave(string ClPdto)
        {
            Cotizacion Pd = null;
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ObtenerPdto(ClPdto);
                if (Pd == null)
                    Mensaje.Append("Codigo del Cotizacion no existe en la B.D.");
                return Pd;
            }
            return null;
        }
        public List<Cotizacion> ListadoAllEsp(string ClPdto)
        {
            List<Cotizacion> Pd = new List<Cotizacion>();
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ListadoTotalESP(ClPdto);
                if (Pd == null)
                    Mensaje.Append("el cliente no tiene cotizaciones existentes en la B.D.");
                return Pd;
            }
            return null;
        }
        public List<Cotizacion> ListadoAllEspCred(string ClPdto)
        {
            List<Cotizacion> Pd = new List<Cotizacion>();
            Mensaje.Clear();
            if (ClPdto == "0")
                Mensaje.Append("Por favor proporcionar una clave valida");
            if (Mensaje.Length == 0)
            {
                Pd = Pdto.ListadoTotalESPCred(ClPdto);
                if (Pd == null)
                    Mensaje.Append("el cliente no tiene cotizaciones existentes en la B.D.");
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

        private bool ValidarProducto(Cotizacion Pq)
        {
            Mensaje.Clear();
            if (string.IsNullOrEmpty(Pq.IDVersion))
                Mensaje.Append("El campo Version no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.IDEmpleado))
                Mensaje.Append("El campo empleado no puede estar vacio");
            if (string.IsNullOrEmpty(Pq.IDCliente))
                Mensaje.Append("El campo cliente no puede estar vacio");
            if (Pq.Dia<0 || Pq.Dia>31)
                Mensaje.Append("El campo dia no puede ser menor que 0 ni mayor que 31");
            if (Pq.Mes < 0 || Pq.Mes> 12)
                Mensaje.Append("El campo mes no puede ser menor que 0 ni mayor que 12");
            if (Pq.Año < 2022 || Pq.Año > 2024)
                Mensaje.Append("El campo año no puede ser menor que 2022 ni mayor que 2024");
            if (string.IsNullOrEmpty(Pq.Hora))
                Mensaje.Append("El campo hora no puede estar vacio");
            if (Pq.PrecioInicial < 0)
                Mensaje.Append("El campo precio inicial no puede ser negativo");
            if (string.IsNullOrEmpty(Pq.TipoPago))
                Mensaje.Append("El campo de Tipo pago no puede estar vacio");
            return Mensaje.Length == 0;

        }

        public void Modificar(Cotizacion Pqte)
        {
            if (ValidarProducto(Pqte))
            {
                Pdto.Actualizar(Pqte);

            }


        }
    }
}
